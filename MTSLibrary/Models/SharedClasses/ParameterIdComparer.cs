using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MTSLibrary.Models.SharedClasses
{
    public class ParameterIdComparer : IEqualityComparer<IParameterModel>
    {
        public bool Equals(IParameterModel x, IParameterModel y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            if (x is null || y is null)
            {
                return false;
            }
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] IParameterModel obj) => obj.Id.GetHashCode();
    }
}