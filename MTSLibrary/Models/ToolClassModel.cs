using System;
using System.Collections.Generic;
using System.Text;

namespace MTSLibrary.Models
{
    public class ToolClassModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string MainClassId { get; set; }
        public List<ToolGroupModel> ToolGroups { get; set; }
        public List<ToolClassParameterModel> ToolClassParameters { get; set; }
        public string DisplayName { get { return $"{Id} - {Name}"; } }
    }
}
