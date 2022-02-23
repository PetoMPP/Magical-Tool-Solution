using MTSLibrary.Models.Comps;

namespace MTSLibrary.Models.Tools
{
    public interface IToolComponentModel
    {
        IBasicCompModel BasicComp { get; set; }
        bool IsKey { get; set; }
        int Position { get; set; }
        int Quantity { get; set; }
    }
}