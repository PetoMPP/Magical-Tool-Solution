using System;
using System.Collections.Generic;
using System.Text;

namespace MTSLibrary.Models
{
    public class ToolModel
    {
        public string Id { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string ToolClassId { get; set; }
        public string ToolGroupId { get; set; }
        public string MachineInterfaceId { get; set; }
        public string DataStatus { get; set; }
        public SuitabilityModel Suitability { get; set; }
        public List<ParameterModel> Parameters { get; set; }
        public List<ToolComponentModel> Components { get; set; }
    }
}
