using MTSLibrary.Models.ToolClassParameters;
using MTSLibrary.Models.ToolGroups;
using System.Collections.Generic;

namespace MTSLibrary.Models.ToolClasses
{
    public interface IToolClassModel
    {
        string DisplayName { get; }
        string Id { get; set; }
        string MainClassId { get; set; }
        string Name { get; set; }
        IEnumerable<IToolClassParameterModel> ToolClassParameters { get; set; }
        IEnumerable<IToolGroupModel> ToolGroups { get; set; }
    }
}