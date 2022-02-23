using System.Collections.Generic;

namespace MTSLibrary.Models.ToolClassParameters
{
    public interface IToolClassParameterModel
    {
        string AssignedGroupsIdDisplayString { get; }
        IEnumerable<string> AssignedToolGroupIds { get; set; }
        string DataValueType { get; set; }
        string Description { get; set; }
        string Id { get; set; }
        string Name { get; set; }
        int Position { get; set; }
        string ToolClassId { get; set; }
    }
}