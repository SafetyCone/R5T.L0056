using System;

using R5T.T0132;

using R5T.T0221;


namespace R5T.L0056
{
    [FunctionalityMarker]
    public partial interface ITypeNameOperator : IFunctionalityMarker,
        L0053.ITypeNameOperator
    {
        public new string Append_ElementTypeRelationshipMarker(
            Type elementTypeParentType,
            string elementTypeNamespacedTypeName)
        {
            var elementTypeRelationship = Instances.ElementTypeRelationshipOperator.Get_ElementTypeRelationship(elementTypeParentType);

            // Has no known relationship.
            if (elementTypeRelationship == ElementTypeRelationships.None)
            {
                throw Instances.ExceptionOperator.Get_UnknownElementTypeRelationshipException();
            }

            var output = elementTypeNamespacedTypeName;

            // Is the type an array type?
            var isArray = Instances.FlagsOperator.Has_Flag(
                elementTypeRelationship,
                ElementTypeRelationships.Array);

            if (isArray)
            {
                output += Instances.TypeNameAffixes.Array_Suffix;
            }

            var isReference = Instances.FlagsOperator.Has_Flag(
                elementTypeRelationship,
                ElementTypeRelationships.Reference);

            if (isReference)
            {
                output += Instances.TypeNameAffixes.ByReference_Suffix;
            }

            var isByPointer = Instances.FlagsOperator.Has_Flag(
                elementTypeRelationship,
                ElementTypeRelationships.Reference);

            if (isByPointer)
            {
                output += Instances.TypeNameAffixes.Pointer_Suffix;
                return output;
            }

            return output;
        }
    }
}
