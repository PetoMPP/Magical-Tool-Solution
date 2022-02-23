using MTSLibrary.Models.Comps;
using MTSLibrary.Models.Tools;

namespace MTSLibrary.Models.Lists
{
    public interface IListPositionModel
    {
        IBasicCompModel BasicComp { get; set; }
        IBasicToolModel BasicTool { get; set; }
        int Position { get; set; }
        int Quantity { get; set; }
    }
}