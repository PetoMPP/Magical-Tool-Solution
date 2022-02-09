using System.Collections.Generic;

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
        public static explicit operator BasicToolClassModel(ToolClassModel model) => new() { Id = model.Id, Name = model.Name };
    }
}
