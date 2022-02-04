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
        public string AssignedGroupsIdDisplayString { get 
            {
                StringBuilder stringBuilder = new();
                if (AssignedGroupsIds.Count == 0)
                {
                    return "No Groups Assigned";
                }
                foreach (string id in AssignedGroupsIds)
                {
                    stringBuilder.Append(id + ", ");
                }
                stringBuilder.Remove(stringBuilder.Length - 2, 2);
                return stringBuilder.ToString();
            } 
        }
        public static explicit operator ParameterModel(ToolClassParameterModel model) => new() 
        { 
            Position = model.Position,
            ParameterId = model.Id,
            Name = model.Name,
            Description = model.Description,
            DataValueType = Enum.Parse<DataValueType>(model.DataValueType)
        };
    }
}
