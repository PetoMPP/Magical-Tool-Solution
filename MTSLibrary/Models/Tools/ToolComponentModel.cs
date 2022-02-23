using Dapper.FluentMap.Mapping;
using MTSLibrary.Models.Comps;

namespace MTSLibrary.Models.Tools
{
    public class ToolComponentModel : IToolComponentModel
    {
        public bool IsKey { get; set; }
        public int Position { get; set; }
        public IBasicCompModel BasicComp { get; set; }
        public int Quantity { get; set; }
    }
    internal class ToolComponentModelMap : EntityMap<ToolComponentModel>
    {
        internal ToolComponentModelMap()
        {
            Map(tc => tc.BasicComp.Id).ToColumn("CompId");
        }
    }
}