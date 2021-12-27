using System;
using System.Collections.Generic;
using System.Text;

namespace MTSLibrary.Models
{
    public class ToolClassParameterModel
    {
        public string Id { get; set; }
        public string ToolClassId { get; set; }
        public int Position { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DataValueType { get; set; }
        public List<string> AssignedGroupsIds { get; set; }
    }
}
