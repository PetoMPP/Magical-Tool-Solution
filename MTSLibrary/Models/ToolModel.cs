using System;
using System.Collections.Generic;
using System.Text;

namespace MTSLibrary.Models
{
    public class ToolModel
    {
        public string Id { get; set; }
        public string Desc1 { get; set; }
        public string Desc2 { get; set; }
        public string ToolClassId { get; set; }
        public string ToolGroupId { get; set; }
        public string MachineInterface { get; set; }
        public string DataStatus { get; set; }
        public SuitabilityModel Suitability { get; set; }
        public List<ParameterModel> Parameters { get; set; }
        public List<ToolComponentModel> Components { get; set; }
    }
}
