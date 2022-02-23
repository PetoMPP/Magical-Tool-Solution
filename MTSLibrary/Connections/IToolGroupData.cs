using MTSLibrary.Models.ToolGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTSLibrary.Connections
{
    public interface IToolGroupData
    {
        void CreateToolGroup(ToolGroupModel model);
        void DeleteToolGroupByIdToolClassId(string id, string toolClassId);
        void DeleteToolGroupsByToolClassId(string id);
        List<BasicToolGroupModel> GetBasicToolGroupsModels();
        ToolGroupModel GetToolGroupByIdToolClassId(string id, string toolClassId);
        string GetToolGroupNameByIdToolClassId(string toolGroupId, string toolClassId);
        void UpdateToolGroup(ToolGroupModel model);
        string ValidateToolClassIdToolGroupId(string toolGroup, string toolGroupId);
        bool ValidateToolGroupIdInClass(string id, string parentClassId);
    }
}
