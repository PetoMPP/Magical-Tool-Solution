using MTSLibrary.Connections;
using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTSInfrastructure.Connections
{
    public class TDMConnector : IDataConnection
    {
        public void CreateComp(CompModel comp) => throw new NotImplementedException();
        public void CreateList(ListModel list) => throw new NotImplementedException();
        public void CreateMainClass(BasicMainClassModel model) => throw new NotImplementedException();
        public void CreateTool(ToolModel tool) => throw new NotImplementedException();
        public void CreateToolClass(ToolClassModel model) => throw new NotImplementedException();
        public void CreateToolClassParameter(ToolClassParameterModel model) => throw new NotImplementedException();
        public void CreateToolGroup(ToolGroupModel model) => throw new NotImplementedException();
        public void DeleteCompById(string id) => throw new NotImplementedException();
        public void DeleteListById(string id) => throw new NotImplementedException();
        public void DeleteMainClassById(string id) => throw new NotImplementedException();
        public void DeleteToolById(string id) => throw new NotImplementedException();
        public void DeleteToolClassById(string id) => throw new NotImplementedException();
        public void DeleteToolClassParameterByParameterIdToolClassId(string parameterId, string toolClassId) => throw new NotImplementedException();
        public void DeleteToolClassParametersByToolClassId(string id) => throw new NotImplementedException();
        public void DeleteToolGroupByIdToolClassId(string id, string toolClassId) => throw new NotImplementedException();
        public void DeleteToolGroupsByToolClassId(string id) => throw new NotImplementedException();
        public List<string> GetAssignedGroupsIdsByClassIdAndParameterId(string classId, string parameterId) => throw new NotImplementedException();
        public BasicCompModel GetBasicCompModelById(string text) => throw new NotImplementedException();
        public List<BasicCompModel> GetBasicCompModels() => throw new NotImplementedException();
        public List<BasicListModel> GetBasicListModels() => throw new NotImplementedException();
        public List<BasicMainClassModel> GetBasicMainClassModels() => throw new NotImplementedException();
        public List<BasicToolClassModel> GetBasicToolClassModels() => throw new NotImplementedException();
        public List<BasicToolGroupModel> GetBasicToolGroupsModels() => throw new NotImplementedException();
        public BasicToolModel GetBasicToolModelById(string text) => throw new NotImplementedException();
        public List<BasicToolModel> GetBasicToolModels() => throw new NotImplementedException();
        public CompModel GetCompModelById(string compId) => throw new NotImplementedException();
        public List<ParameterModel> GetCompParametersById(string id) => throw new NotImplementedException();
        public List<string> GetDataValueTypes() => throw new NotImplementedException();
        public ListModel GetListModelById(string listId) => throw new NotImplementedException();
        public List<MainClassModel> GetMainClassesList() => throw new NotImplementedException();
        public string GetMainClassNameById(string mainClassId) => throw new NotImplementedException();
        public string GetManufacturerIdByName(string name) => throw new NotImplementedException();
        public List<ParameterModel> GetParametersByToolClassIdToolGroupId(string toolClassId, string toolGroupId) => throw new NotImplementedException();
        public ToolClassModel GetToolClassById(string id) => throw new NotImplementedException();
        public List<ToolClassModel> GetToolClassesList() => throw new NotImplementedException();
        public string GetToolClassNameById(string parentClassId) => throw new NotImplementedException();
        public int GetToolClassParameterNextPositionByToolClassId(string id) => throw new NotImplementedException();
        public ToolGroupModel GetToolGroupByIdToolClassId(string id, string toolClassId) => throw new NotImplementedException();
        public string GetToolGroupNameByIdToolClassId(string toolGroupId, string toolClassId) => throw new NotImplementedException();
        public ToolModel GetToolModelById(string toolId) => throw new NotImplementedException();
        public List<ToolClassModel> GetUnallocatedToolClasses() => throw new NotImplementedException();
        public List<string> GetUsers() => throw new NotImplementedException();
        public void SetMainClassIdById(string mainClassId, string toolClassId) => throw new NotImplementedException();
        public void UnallocateToolClasses(string id) => throw new NotImplementedException();
        public void UpdateBasicMainClass(BasicMainClassModel model) => throw new NotImplementedException();
        public void UpdateComp(CompModel comp) => throw new NotImplementedException();
        public void UpdateList(ListModel list) => throw new NotImplementedException();
        public void UpdateTool(ToolModel tool) => throw new NotImplementedException();
        public void UpdateToolClass(ToolClassModel model) => throw new NotImplementedException();
        public void UpdateToolClassParameter(ToolClassParameterModel model) => throw new NotImplementedException();
        public void UpdateToolGroup(ToolGroupModel model) => throw new NotImplementedException();
        public bool ValidateCompId(string id) => throw new NotImplementedException();
        public bool ValidateListId(string id) => throw new NotImplementedException();
        public string ValidateListPositions(List<ListPositionModel> tools) => throw new NotImplementedException();
        public string ValidateMachine(string machineId, string machineGroupId) => throw new NotImplementedException();
        public string ValidateMachineInterfaceName(string machineInterface) => throw new NotImplementedException();
        public bool ValidateMainClassId(string id) => throw new NotImplementedException();
        public string ValidateManufacturerName(string name) => throw new NotImplementedException();
        public string ValidateMaterial(string materialId) => throw new NotImplementedException();
        public bool ValidateToolClassId(string id) => throw new NotImplementedException();
        public string ValidateToolClassIdToolGroupId(string toolGroup, string toolGroupId) => throw new NotImplementedException();
        public string ValidateToolComponents(List<ToolComponentModel> components) => throw new NotImplementedException();
        public bool ValidateToolGroupIdInClass(string id, string parentClassId) => throw new NotImplementedException();
        public bool ValidateToolId(string id) => throw new NotImplementedException();
    }
}
