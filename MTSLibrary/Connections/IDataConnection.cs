using MTSLibrary.Models;
using System.Collections.Generic;

namespace MTSLibrary.Connections
{
    public interface IDataConnection : 
        ICompData, 
        IToolData, 
        IListData, 
        IMainClassData, 
        IToolClassData, 
        IToolGroupData, 
        IToolClassParameterData,
        IDataTypes,
        IMachineData,
        IManufacturerData,
        IMaterialData,
        IUserData
    {
    }
}
