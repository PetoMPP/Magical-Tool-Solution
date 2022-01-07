using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTSLibrary.Connections
{
    public class TDMConnector : IDataConnection
    {
        public void CreateClGrParameter(ToolClassParameterModel model)
        {
            throw new NotImplementedException();
        }

        public void CreateComp(CompModel comp)
        {
            throw new NotImplementedException();
        }

        public void CreateList(ListModel list)
        {
            throw new NotImplementedException();
        }

        public void CreateMainClass(MainClassModel model)
        {
            throw new NotImplementedException();
        }

        public void CreateTool(ToolModel tool)
        {
            throw new NotImplementedException();
        }

        public void CreateToolClass(ToolClassModel model)
        {
            throw new NotImplementedException();
        }

        public void CreateToolGroup(ToolGroupModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteCompById(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteListById(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteToolById(string id)
        {
            throw new NotImplementedException();
        }

        public CompModel GetBasicCompModelById(string text)
        {
            throw new NotImplementedException();
        }

        public ToolModel GetBasicToolModelById(string text)
        {
            throw new NotImplementedException();
        }

        public List<ToolClassModel> GetToolClassesList()
        {
            throw new NotImplementedException();
        }

        public List<MainClassModel> GetClassesListByMainClassId(string id)
        {
            throw new NotImplementedException();
        }

        public string GetClassNameById(string parentClassId)
        {
            throw new NotImplementedException();
        }

        public CompModel GetCompModelById(string compId)
        {
            throw new NotImplementedException();
        }

        public List<string> GetEnabledGroupsIdsByClassIdAndParameterId(string id, string parameterId)
        {
            throw new NotImplementedException();
        }

        public string GetToolGroupNameById(string toolGroupId) => throw new NotImplementedException();

        public ListModel GetListModelById(string listId)
        {
            throw new NotImplementedException();
        }

        public List<MainClassModel> GetMainClassesList()
        {
            throw new NotImplementedException();
        }

        public string GetMainClassNameById(string mainClassId)
        {
            throw new NotImplementedException();
        }

        public string GetManufacturerIdByName(string text) => throw new NotImplementedException();

        public ToolModel GetToolModelById(string toolId)
        {
            throw new NotImplementedException();
        }

        public List<ToolClassModel> GetUnallocatedToolClasses() => throw new NotImplementedException();

        public List<string> GetDataValueTypes()
        {
            throw new NotImplementedException();
        }

        public void SetMainClassIdById(string mainClassId, string toolClassId)
        {
            throw new NotImplementedException();
        }

        public void UpdateToolClassParameter(ToolClassParameterModel model)
        {
            throw new NotImplementedException();
        }

        public void UpdateComp(CompModel comp)
        {
            throw new NotImplementedException();
        }

        public void UpdateList(ListModel list)
        {
            throw new NotImplementedException();
        }

        public void UpdateMainClass(MainClassModel model)
        {
            throw new NotImplementedException();
        }

        public void UpdateTool(ToolModel tool)
        {
            throw new NotImplementedException();
        }

        public void UpdateToolClass(ToolClassModel model)
        {
            throw new NotImplementedException();
        }

        public void UpdateToolGroup(ToolGroupModel model)
        {
            throw new NotImplementedException();
        }

        public string ValidateClassGroupId(string toolClass, string toolGroup)
        {
            throw new NotImplementedException();
        }

        public string ValidateClassGroupId(string toolGroup) => throw new NotImplementedException();

        public bool ValidateCompId(string id)
        {
            throw new NotImplementedException();
        }

        public bool ValidateListId(string id)
        {
            throw new NotImplementedException();
        }

        public string ValidateListPositions(List<ListPositionModel> tools)
        {
            throw new NotImplementedException();
        }

        public string ValidateMachine(string machineId, string machineGroupId)
        {
            throw new NotImplementedException();
        }

        public string ValidateMachineInterfaceId(string machineInterface)
        {
            throw new NotImplementedException();
        }

        public bool ValidateMainClassId(string id)
        {
            throw new NotImplementedException();
        }

        public string ValidateManufacturerName(string name)
        {
            throw new NotImplementedException();
        }

        public string ValidateMaterial(string materialId)
        {
            throw new NotImplementedException();
        }

        public string ValidateParameters(List<ParameterModel> parameters)
        {
            throw new NotImplementedException();
        }

        public bool ValidateToolClassId(string id)
        {
            throw new NotImplementedException();
        }

        public string ValidateToolComponents(List<ToolComponentModel> components)
        {
            throw new NotImplementedException();
        }

        public bool ValidateToolGroupIdInClass(string id, string parentClassId)
        {
            throw new NotImplementedException();
        }

        public bool ValidateToolId(string id)
        {
            throw new NotImplementedException();
        }

        BasicCompModel IDataConnection.GetBasicCompModelById(string text) => throw new NotImplementedException();
        BasicToolModel IDataConnection.GetBasicToolModelById(string text) => throw new NotImplementedException();
    }
}
