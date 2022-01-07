using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTSLibrary.Connections
{
    public interface IDataConnection
    {
        void UpdateComp(CompModel comp);
        void UpdateTool(ToolModel tool);
        string ValidateMachine(string machineId, string machineGroupId);
        string ValidateMaterial(string materialId);
        bool ValidateToolId(string id);
        string ValidateClassGroupId(string toolGroup, string toolGroupId);
        string ValidateMachineInterfaceId(string machineInterface);
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
        void CreateClGrParameter(ToolClassParameterModel model);
        void UpdateToolClassParameter(ToolClassParameterModel model);
        bool ValidateToolClassId(string id);
        void SetMainClassIdById(string mainClassId, string toolClassId);
        bool ValidateToolGroupIdInClass(string id, string parentClassId);
        string GetClassNameById(string parentClassId);
        List<string> GetEnabledGroupsIdsByClassIdAndParameterId(string classId, string parameterId);
        bool ValidateMainClassId(string id);
        void CreateMainClass(MainClassModel model);
        void UpdateMainClass(MainClassModel model);
        string GetToolGroupNameById(string toolGroupId);
        string GetManufacturerIdByName(string name);
        void DeleteMainClassById(string id);
    }
}
