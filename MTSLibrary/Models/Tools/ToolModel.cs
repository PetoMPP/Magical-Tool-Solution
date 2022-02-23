using MTSLibrary.Models.SharedClasses;
using System.Collections.Generic;

namespace MTSLibrary.Models.Tools
{
    public class ToolModel
    {
        public string Id { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string ToolClassId { get; set; }
        public string ToolGroupId { get; set; }
        public string MachineInterfaceName { get; set; }
        public string DataStatus { get; set; }
        public ISuitabilityModel Suitability { get; set; }
        public IEnumerable<IParameterModel> Parameters { get; set; }
        public IEnumerable<IToolComponentModel> Components { get; set; }
    }
}
