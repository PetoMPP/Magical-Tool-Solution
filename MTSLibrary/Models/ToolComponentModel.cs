using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Dapper.FluentMap.Mapping;

namespace MTSLibrary.Models
{
    public class ToolComponentModel
    {
        public bool IsKey { get; set; }
        public int Position { get; set; }
        public BasicCompModel BasicComp { get; set; }
        public int Quantity { get; set; }
    }
    internal class ToolComponentModelMap : EntityMap<ToolComponentModel>
    {
        internal ToolComponentModelMap()
        {
            Map(tc => tc.BasicComp.Id).ToColumn("CompId");
        }
    }
    internal class ToolComponentModelPositionComparer : IEqualityComparer<ToolComponentModel>
    {
        public bool Equals(ToolComponentModel x, ToolComponentModel y)
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
        public int GetHashCode([DisallowNull] ToolComponentModel obj) => throw new System.NotImplementedException();
    }
    internal class ToolComponentModelComparer : IEqualityComparer<ToolComponentModel>
    {
        public bool Equals(ToolComponentModel x, ToolComponentModel y)
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
        public int GetHashCode([DisallowNull] ToolComponentModel obj) => throw new System.NotImplementedException();
    }
}