using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTSInfrastructure.Connections
{
    public interface IDataConnection
    {
        void UpdateComp(CompModel comp);
        void UpdateTool(ToolModel tool);
        string ValidateMachine(string machineId, string machineGroupId);
        string ValidateMaterial(string materialId);
        bool ValidateToolId(string id);
        string ValidateToolClassIdToolGroupId(string toolGroup, string toolGroupId);
        string ValidateMachineInterfaceName(string machineInterface);
        string ValidateToolComponents(List<ToolComponentModel> components);
        bool ValidateCompId(string id);
        List<ToolClassModel> GetToolClassesList();
        string ValidateManufacturerName(string name);
        bool ValidateListId(string id);
        string ValidateListPositions(List<ListPositionModel> tools);
        void UpdateList(ListModel list);
        void CreateComp(CompModel comp);
        void CreateTool(ToolModel tool);
        void CreateList(ListModel list);
        void DeleteListById(string id);
        void DeleteToolById(string id);
        List<ToolClassModel> GetUnallocatedToolClasses();
        void DeleteCompById(string id);
        CompModel GetCompModelById(string compId);
        List<MainClassModel> GetMainClassesList();
        ToolModel GetToolModelById(string toolId);
        ListModel GetListModelById(string listId);
        BasicCompModel GetBasicCompModelById(string text);
        BasicToolModel GetBasicToolModelById(string text);
        void CreateToolClass(ToolClassModel model);
        void UpdateToolClass(ToolClassModel model);
        void CreateToolGroup(ToolGroupModel model);
        List<string> GetDataValueTypes();
        string GetMainClassNameById(string mainClassId);
        void UpdateToolGroup(ToolGroupModel model);
        void CreateToolClassParameter(ToolClassParameterModel model);
        void UpdateToolClassParameter(ToolClassParameterModel model);
        bool ValidateToolClassId(string id);
        void SetMainClassIdById(string mainClassId, string toolClassId);
        List<BasicCompModel> GetBasicCompModels();
        bool ValidateToolGroupIdInClass(string id, string parentClassId);
        string GetToolClassNameById(string parentClassId);
        List<string> GetAssignedGroupsIdsByClassIdAndParameterId(string classId, string parameterId);
        List<BasicToolModel> GetBasicToolModels();
        bool ValidateMainClassId(string id);
        void CreateMainClass(BasicMainClassModel model);
        void UpdateBasicMainClass(BasicMainClassModel model);
        string GetToolGroupNameByIdToolClassId(string toolGroupId, string toolClassId);
        List<BasicListModel> GetBasicListModels();
        string GetManufacturerIdByName(string name);
        void DeleteMainClassById(string id);
        ToolClassModel GetToolClassById(string id);
        ToolGroupModel GetToolGroupByIdToolClassId(string id, string toolClassId);
        List<BasicToolClassModel> GetBasicToolClassModels();
        int GetToolClassParameterNextPositionByToolClassId(string id);
        void UnallocateToolClasses(string id);
        List<BasicToolGroupModel> GetBasicToolGroupsModels();
        List<BasicMainClassModel> GetBasicMainClassModels();
        void DeleteToolGroupsByToolClassId(string id);
        void DeleteToolClassParametersByToolClassId(string id);
        void DeleteToolClassById(string id);
        void DeleteToolGroupByIdToolClassId(string id, string toolClassId);
        List<ParameterModel> GetParametersByToolClassIdToolGroupId(string toolClassId, string toolGroupId);
        List<ParameterModel> GetCompParametersById(string id);
        void DeleteToolClassParameterByParameterIdToolClassId(string parameterId, string toolClassId);
        List<string> GetUsers();
    }
}
