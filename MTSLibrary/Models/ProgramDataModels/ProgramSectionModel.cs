using System.Collections.Generic;

namespace MTSLibrary.Models.ProgramDataModels
{
    public class ProgramSectionModel : IProgramSectionModel
    {
        public string Name { get; set; }
        public IEnumerable<IProgramModuleModel> AvailableModules { get; set; }
    }
}
