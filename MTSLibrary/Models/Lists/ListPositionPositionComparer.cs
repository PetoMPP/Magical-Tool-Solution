using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MTSLibrary.Models.Lists
{
    public class ListPositionPositionComparer : IEqualityComparer<IListPositionModel>
    {
        public bool Equals(IListPositionModel x, IListPositionModel y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            if (x is null || y is null)
            {
                return false;
            }
            return x.Position == y.Position;
        }
        public int GetHashCode([DisallowNull] IListPositionModel obj) => obj.Position;
    }
}