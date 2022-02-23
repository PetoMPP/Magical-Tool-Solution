using System.Collections.Generic;

namespace MTSLibrary.Models.ProgramDataModels
{
    public interface IProgramSectionModel
    {
        IEnumerable<IProgramModuleModel> AvailableModules { get; set; }
        string Name { get; set; }
    }
}