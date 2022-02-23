using MTSLibrary.Models.ToolClassParameters;
using MTSLibrary.Models.ToolGroups;
using System.Collections.Generic;

namespace MTSLibrary.Models.ToolClasses
{
    public class ToolClassModel : IToolClassModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string MainClassId { get; set; }
        public IEnumerable<IToolGroupModel> ToolGroups { get; set; }
        public IEnumerable<IToolClassParameterModel> ToolClassParameters { get; set; }
        public string DisplayName { get { return $"{Id} - {Name}"; } }
        public static explicit operator BasicToolClassModel(ToolClassModel model) => new() { Id = model.Id, Name = model.Name };
    }
}
