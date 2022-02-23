using MTSLibrary.Models.SharedClasses;
using System.Collections.Generic;

namespace MTSLibrary.Models.Comps
{
    public interface ICompModel: IBasicCompModel
    {
        string DataStatus { get; set; }
        string MachineInterfaceName { get; set; }
        string ManufacturerName { get; set; }
        IEnumerable<IParameterModel> Parameters { get; set; }
        ISuitabilityModel Suitability { get; set; }
        string ToolClassId { get; set; }
        string ToolGroupId { get; set; }
    }
}