using MTSLibrary.Models.ToolClasses;
using System.Collections.Generic;

namespace MTSLibrary.Models.MainClasses
{
    public interface IMainClassModel : IBasicMainClassModel
    {
        string DisplayName { get; }
        IEnumerable<IToolClassModel> ToolClasses { get; set; }
    }
}