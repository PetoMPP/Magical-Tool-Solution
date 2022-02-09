using System.Collections.Generic;

namespace MTSLibrary.Models
{
    public class CompModel
    {
        public string Id { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string ToolClassId { get; set; }
        public string ToolGroupId { get; set; }
        public string ManufacturerName { get; set; }
        public string MachineInterfaceName { get; set; }
        public string DataStatus { get; set; }
        public SuitabilityModel Suitability { get; set; }
        public List<ParameterModel> Parameters { get; set; }
    }
}