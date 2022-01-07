using System.Collections.Generic;

namespace MTSLibrary.Models
{
    public class MainClassModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DisplayName {
            get 
            {
                return $"{Id}, {Name}";
            }
        }
        public List<ToolClassModel> ToolClasses { get; set; }
    }
}