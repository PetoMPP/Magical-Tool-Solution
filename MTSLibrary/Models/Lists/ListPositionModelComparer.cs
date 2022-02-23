using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MTSLibrary.Models.Lists
{
    public class ListPositionModelComparer : IEqualityComparer<IListPositionModel>
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
            return x.Position == y.Position && x.BasicComp == y.BasicComp && x.BasicTool == y.BasicTool && x.Quantity == y.Quantity;
        }
        public int GetHashCode([DisallowNull] IListPositionModel obj) =>
            obj.Position.GetHashCode() ^ (obj.BasicComp == null ? 0 : obj.BasicComp.GetHashCode()) ^ (obj.BasicTool == null ? 0 : obj.GetHashCode()) ^ obj.Quantity.GetHashCode();
    }
}