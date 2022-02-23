using MTSLibrary.Models.SharedClasses;
using MTSLibrary.Models.ToolClassParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTSLibrary.Connections
{
    public interface IToolClassParameterData
    {
        void CreateToolClassParameter(ToolClassParameterModel model);
        void DeleteToolClassParameterByParameterIdToolClassId(string parameterId, string toolClassId);
        void DeleteToolClassParametersByToolClassId(string id);
        List<string> GetAssignedGroupsIdsByClassIdAndParameterId(string classId, string parameterId);
        int GetToolClassParameterNextPositionByToolClassId(string id);
        List<ParameterModel> GetParametersByToolClassIdToolGroupId(string toolClassId, string toolGroupId);
        void UpdateToolClassParameter(ToolClassParameterModel model);
    }
}
