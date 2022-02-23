using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MTSLibrary.Models.Tools
{
    public class ToolComponentPositionComparer : IEqualityComparer<IToolComponentModel>
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
            return x.Position == y.Position;
        }
        public int GetHashCode([DisallowNull] IToolComponentModel obj) => obj.Position;
    }
}