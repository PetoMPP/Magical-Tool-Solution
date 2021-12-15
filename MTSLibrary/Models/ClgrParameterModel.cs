using System;
using System.Collections.Generic;
using System.Text;

namespace MTSLibrary.Models
{
    public class ClgrParameterModel
    {
        public int Position { get; set; }
        public string ParameterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ValueType { get; set; }
        public List<string> AssignedGroupsIds { get; set; }
    }
}
