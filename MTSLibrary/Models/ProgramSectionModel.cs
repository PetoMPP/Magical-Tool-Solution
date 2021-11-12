using System;
using System.Collections.Generic;
using System.Text;

namespace MTSLibrary.Models
{
    public class ProgramSectionModel
    {
        public string Name { get; set; }
        public List<ProgramModuleModel> AvailableModules { get; set; }
    }
}
