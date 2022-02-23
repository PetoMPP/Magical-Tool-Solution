using MTSLibrary.Models.Comps;
using MTSLibrary.Models.Tools;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MTSLibrary.Models.Lists
{
    public class ListPositionModel : IListPositionModel
    {
        public int Position { get; set; }
        public IBasicCompModel BasicComp { get; set; }
        public IBasicToolModel BasicTool { get; set; }
        public int Quantity { get; set; }
    }
}