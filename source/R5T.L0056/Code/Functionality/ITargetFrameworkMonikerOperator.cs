using System;

using R5T.T0132;
using R5T.T0218;
using R5T.T0218.Extensions;
using R5T.T0219;


using ITargetFrameworkMonikers = R5T.Z0057.Platform.ITargetFrameworkMonikers;


namespace R5T.L0056
{
    [FunctionalityMarker]
    public partial interface ITargetFrameworkMonikerOperator : IFunctionalityMarker
    {
        public ITargetFrameworkMoniker Get_NonWindowsMoniker(ITargetFrameworkMoniker windowsTargetFrameworkMoniker)
        {
            var indexOfWindowsTokenSeparator = Instances.StringOperator.Get_IndexOf(
                windowsTargetFrameworkMoniker.Value,
                Instances.Characters.Dash);

            var output = Instances.StringOperator.Get_Substring_Upto_Exclusive(
                indexOfWindowsTokenSeparator,
                windowsTargetFrameworkMoniker.Value)
                .ToTargetFrameworkMoniker();

            return output;
        }

        public IDotnetMajorVersion Get_DotnetMajorVersion(ITargetFrameworkMoniker targetFrameworkMoniker)
        {
            // Deal with "net6.0-windows" for example.
            var isSuffixed = Instances.StringOperator.Contains(
                targetFrameworkMoniker.Value,
                Instances.Characters.Dash);

            var ensuredTargetFrameworkMoniker = isSuffixed
                ? Instances.StringOperator.Get_Substring_Upto_Exclusive(
                    Instances.StringOperator.Get_IndexOf(
                        targetFrameworkMoniker.Value,
                        Instances.Characters.Dash),
                    targetFrameworkMoniker.Value)
                : targetFrameworkMoniker.Value
                ;

            var output = ensuredTargetFrameworkMoniker switch
            {
                ITargetFrameworkMonikers.NET_5_Constant => Instances.DotnetMajorVersions.V5,
                ITargetFrameworkMonikers.NET_6_Constant => Instances.DotnetMajorVersions.V6,
                ITargetFrameworkMonikers.NET_7_Constant => Instances.DotnetMajorVersions.V7,
                ITargetFrameworkMonikers.NET_8_Constant => Instances.DotnetMajorVersions.V8,
                ITargetFrameworkMonikers.NET_App_2_2_Constant => Instances.DotnetMajorVersions.V2,
                ITargetFrameworkMonikers.NET_App_3_1_Constant => Instances.DotnetMajorVersions.V3,
                ITargetFrameworkMonikers.Net_Standard2_0_Constant => Instances.DotnetMajorVersions.V2,
                // Use V6 for netstandard2.1.
                ITargetFrameworkMonikers.Net_Standard2_1_Constant => Instances.DotnetMajorVersions.V6,
                _ => throw new Exception($"Unknown target framework moniker: {targetFrameworkMoniker}")
            };

            return output;
        }

        public bool Is_WindowsSpecific(ITargetFrameworkMoniker targetFrameworkMoniker)
        {
            var output = Instances.StringOperator.Contains(
                targetFrameworkMoniker.Value,
                Instances.TargetFrameworkMonikerTokens.Windows);

            return output;
        }
    }
}
