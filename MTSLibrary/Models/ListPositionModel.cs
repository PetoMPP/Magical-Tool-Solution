using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MTSLibrary.Models
{
    public class ListPositionModel
    {
        private BasicCompModel _comp;
        private BasicToolModel _tool;
        public int Position { get; set; }
        public BasicCompModel BasicComp {
            get => _comp;
            set {
                BasicTool = null;
                _comp = value;
            }
        }
        public BasicToolModel BasicTool {
            get => _tool;
            set {
                BasicComp = null;
                _tool = value;
            }
        }
        public int Quantity { get; set; }
    }
    internal class ListPositionModelPositionComparer : IEqualityComparer<ListPositionModel>
    {
        public bool Equals(ListPositionModel x, ListPositionModel y)
        {
            if (Object.ReferenceEquals(x, y))
            {
                return true;
            }
            if (x is null || y is null)
            {
                return false;
            }
            return x.Position == y.Position;
        }
        public int GetHashCode([DisallowNull] ListPositionModel obj) => throw new NotImplementedException();
    }
    internal class ListPositionModelComparer : IEqualityComparer<ListPositionModel>
    {
        public bool Equals(ListPositionModel x, ListPositionModel y)
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
        public int GetHashCode([DisallowNull] ListPositionModel obj) => throw new NotImplementedException();
    }
}