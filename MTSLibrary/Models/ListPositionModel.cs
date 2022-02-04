﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MTSLibrary.Models
{
    public class ListPositionModel
    {
        public int Position { get; set; }
        public BasicCompModel BasicComp { get; set; }
        public BasicToolModel BasicTool { get; set; }
        public int Quantity { get; set; }
    }
    internal class ListPositionModelPositionComparer : IEqualityComparer<ListPositionModel>
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
            return x.Position == y.Position;
        }
        public int GetHashCode([DisallowNull] ListPositionModel obj) => obj.Position;
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
        public int GetHashCode([DisallowNull] ListPositionModel obj) =>
            obj.Position.GetHashCode() ^ obj.BasicComp.GetHashCode() ^ obj.BasicTool.GetHashCode() ^ obj.Quantity.GetHashCode();
    }
}