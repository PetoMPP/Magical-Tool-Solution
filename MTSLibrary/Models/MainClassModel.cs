using System;
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

        public static explicit operator MainClassModel(BasicMainClassModel model) => new() { Id = model.Id, Name = model.Name };
    }
}