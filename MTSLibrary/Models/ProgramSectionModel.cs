using System.Collections.Generic;

namespace MTSLibrary.Models
{
    public class ProgramSectionModel
    {
        public string Name { get; set; }
        public List<ProgramModuleModel> AvailableModules { get; set; }
    }
}
