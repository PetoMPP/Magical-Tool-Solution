using MTSLibrary.Models.ToolClasses;
using System.Collections.Generic;

namespace MTSLibrary.Models.MainClasses
{
    public class MainClassModel : IMainClassModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DisplayName {
            get {
                return $"{Id}, {Name}";
            }
        }
        public IEnumerable<IToolClassModel> ToolClasses { get; set; }

        public static explicit operator MainClassModel(BasicMainClassModel model) => new() { Id = model.Id, Name = model.Name };
    }
}