using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MTSLibrary.Models.Tools
{
    public class ToolComponentModelComparer : IEqualityComparer<IToolComponentModel>
    {
        public bool Equals(IToolComponentModel x, IToolComponentModel y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            if (x is null || y is null)
            {
                return false;
            }
            return x.Position == y.Position
                && x.Quantity == y.Quantity
                && x.IsKey == y.IsKey
                && x.BasicComp.Id == y.BasicComp.Id;
        }
        public int GetHashCode([DisallowNull] IToolComponentModel obj) =>
            obj.Position.GetHashCode() ^ obj.Quantity.GetHashCode() ^ obj.IsKey.GetHashCode() ^ obj.BasicComp.Id.GetHashCode();
    }
}