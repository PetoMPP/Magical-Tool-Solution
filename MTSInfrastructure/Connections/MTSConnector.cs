using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;
using MTSLibrary.Models;
using MTSLibrary;
using MTSLibrary.Connections;

namespace MTSInfrastructure.Connections
{
    public class MTSConnector : IDataConnection
    {
        // TODO - Move error strings to Program Logic Class
        private static string GetConnectionString() =>
            ConfigurationManager.ConnectionStrings["MTSDatabase"].ConnectionString;
        private static int GetBitValueFromBool(bool boolean) => boolean == true ? 1 : 0;

        public void CreateToolClassParameter(ToolClassParameterModel model)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            InsertPrimaryParameterData(model, cnxn);
            if (model.AssignedToolGroupIds != null)
            {
                AssignToolGroupsToParameter(cnxn, model.AssignedToolGroupIds, model.ToolClassId, model.Id);
            }
        }

        private static void InsertPrimaryParameterData(ToolClassParameterModel model, IDbConnection cnxn)
        {
            DynamicParameters dp = new();
            dp.Add("@Id", model.Id);
            dp.Add("@ToolClassId", model.ToolClassId);
            dp.Add("@Position", model.Position);
            dp.Add("@Name", model.Name);
            dp.Add("@Description", model.Description);
            dp.Add("@DataValueType", model.DataValueType);
            cnxn.Execute("dbo.spToolClassParameters_Insert", dp, commandType: CommandType.StoredProcedure);
        }

        private static void AssignToolGroupsToParameter(IDbConnection cnxn, List<string> assignedToolGroupIds, string toolClassId, string parameterId)
        {
            foreach (string toolGroupId in assignedToolGroupIds)
            {
                DynamicParameters dp = new();
                dp.Add("@ToolClassId", toolClassId);
                dp.Add("@ParameterId", parameterId);
                dp.Add("@ToolGroupId", toolGroupId);
                cnxn.Execute("dbo.spToolClassParameterGroups_Insert", dp, commandType: CommandType.StoredProcedure);
            }
        }

        public void CreateComp(CompModel comp)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            InsertPrimaryCompData(comp, cnxn);
            if (comp.Suitability != null)
            {
                InsertCompSuitability(comp, cnxn);
            }
            if (comp.Parameters != null)
            {
                InsertCompParameters(cnxn, comp.Parameters, comp.Id);
            }
        }

        private static void InsertCompSuitability(CompModel comp, IDbConnection cnxn)
        {
            DynamicParameters dp = new();
            dp.Add("@CompId", comp.Id);
            dp.Add("@PSuitability", comp.Suitability.PSuitability);
            dp.Add("@MSuitability", comp.Suitability.MSuitability);
            dp.Add("@KSuitability", comp.Suitability.KSuitability);
            dp.Add("@NSuitability", comp.Suitability.NSuitability);
            dp.Add("@SSuitability", comp.Suitability.SSuitability);
            dp.Add("@HSuitability", comp.Suitability.HSuitability);
            cnxn.Execute("dbo.spCompSuitability_Insert", dp, commandType: CommandType.StoredProcedure);
        }
        private static void InsertPrimaryCompData(CompModel comp, IDbConnection cnxn)
        {
            DynamicParameters dp = new();
            dp.Add("@Id", comp.Id);
            dp.Add("@Description1", comp.Description1);
            dp.Add("@Description2", string.IsNullOrWhiteSpace(comp.Description2) ? null : comp.Description2);
            dp.Add("@ToolClassId", comp.ToolClassId);
            dp.Add("@ToolGroupId", comp.ToolGroupId);
            dp.Add("@ManufacturerName", string.IsNullOrWhiteSpace(comp.ManufacturerName) ? null : comp.ManufacturerName);
            dp.Add("@MachineInterfaceName", string.IsNullOrWhiteSpace(comp.MachineInterfaceName) ? null : comp.MachineInterfaceName);
            dp.Add("@DataStatus", string.IsNullOrWhiteSpace(comp.DataStatus) ? null : comp.DataStatus);
            cnxn.Execute("dbo.spComps_Insert", dp, commandType: CommandType.StoredProcedure);
        }

        private static void InsertCompParameters(IDbConnection cnxn, List<ParameterModel> parameters, string compId)
        {
            foreach (ParameterModel pm in parameters)
            {
                DynamicParameters dp = new();
                dp.Add("@CompId", compId);
                dp.Add("@ParameterId", pm.Id);
                dp.Add("@TextValue", pm.DataValueType == DataValueType.Text ? pm.TextValue : null);
                dp.Add("@NumericValue", pm.DataValueType == DataValueType.Numeric ? pm.NumericValue : null);
                cnxn.Execute("dbo.spCompParameters_Insert", dp, commandType: CommandType.StoredProcedure);
            }
        }

        public void CreateList(ListModel list)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            InsertPrimaryListData(list, cnxn);
            if (list.ListPositions != null)
            {
                InsertListPositions(list.Id, list.ListPositions, cnxn);
            }
        }

        private static void InsertListPositions(string listId, List<ListPositionModel> listPositions, IDbConnection cnxn)
        {
            foreach (ListPositionModel lp in listPositions)
            {
                DynamicParameters dp = new();
                dp.Add("@ListId", listId);
                dp.Add("@Position", lp.Position);
                dp.Add("@CompId", lp.BasicComp?.Id);
                dp.Add("@ToolId", lp.BasicTool?.Id);
                dp.Add("@Quantity", lp.Quantity);
                cnxn.Execute("dbo.spListPositions_Insert", dp, commandType: CommandType.StoredProcedure);
            }
        }

        private static void InsertPrimaryListData(ListModel list, IDbConnection cnxn)
        {
            DynamicParameters dp = new();
            dp.Add("@Id", list.Id);
            dp.Add("@Description1", list.Description1);
            dp.Add("@Description2", string.IsNullOrWhiteSpace(list.Description2) ? null : list.Description2);
            dp.Add("@MachineId", string.IsNullOrWhiteSpace(list.MachineId) ? null : list.MachineId);
            dp.Add("@MachineGroupId", string.IsNullOrWhiteSpace(list.MachineGroupId) ? null : list.MachineGroupId);
            dp.Add("@MaterialId", string.IsNullOrWhiteSpace(list.MaterialId) ? null : list.MaterialId);
            dp.Add("@DataStatus", string.IsNullOrWhiteSpace(list.DataStatus) ? null : list.DataStatus);
            dp.Add("@CreatorName", string.IsNullOrWhiteSpace(list.CreatorName) ? null : list.CreatorName);
            dp.Add("@LastModifiedName", string.IsNullOrWhiteSpace(list.LastModifiedName) ? null : list.LastModifiedName);
            dp.Add("@OwnerName", string.IsNullOrWhiteSpace(list.OwnerName) ? null : list.OwnerName);
            cnxn.Execute("dbo.spLists_Insert", dp, commandType: CommandType.StoredProcedure);
        }

        public void CreateMainClass(BasicMainClassModel model)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            InsertPrimaryMainClassData(model, cnxn);
        }

        private static void InsertPrimaryMainClassData(BasicMainClassModel model, IDbConnection cnxn)
        {
            DynamicParameters dp = new();
            dp.Add("@Id", model.Id);
            dp.Add("@Name", model.Name);
            cnxn.Execute("dbo.spMainClasses_Insert", dp, commandType: CommandType.StoredProcedure);
        }

        public void CreateTool(ToolModel tool)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            InsertPrimaryToolData(tool, cnxn);
            if (tool.Suitability != null)
            {
                InsertToolSuitability(tool, cnxn);
            }
            if (tool.Parameters != null)
            {
                InsertToolParameters(tool.Id, tool.Parameters, cnxn);
            }
            if (tool.Components != null)
            {
                InsertToolComponents(tool.Id, tool.Components, cnxn);
            }
        }

        private static void InsertToolComponents(string toolId, List<ToolComponentModel> components, IDbConnection cnxn)
        {
            foreach (ToolComponentModel tc in components)
            {
                DynamicParameters dp = new();
                dp.Add("@ToolId", toolId);
                dp.Add("@CompId", tc.BasicComp.Id);
                dp.Add("@Quantity", tc.Quantity);
                dp.Add("@Position", tc.Position);
                dp.Add("@IsKey", GetBitValueFromBool(tc.IsKey));
                cnxn.Execute("dbo.spToolComponents_Insert", dp, commandType: CommandType.StoredProcedure);
            }
        }

        private static void InsertToolParameters(string toolId, List<ParameterModel> parameters, IDbConnection cnxn)
        {
            foreach (ParameterModel pm in parameters)
            {
                DynamicParameters dp = new();
                dp.Add("@ToolId", toolId);
                dp.Add("@ParameterId", pm.Id);
                dp.Add("@TextValue", pm.DataValueType == DataValueType.Text ? pm.TextValue : null);
                dp.Add("@NumericValue", pm.DataValueType == DataValueType.Numeric ? pm.NumericValue : null);
                cnxn.Execute("dbo.spToolParameters_Insert", dp, commandType: CommandType.StoredProcedure);
            }
        }

        private static void InsertToolSuitability(ToolModel tool, IDbConnection cnxn)
        {
            DynamicParameters dp = new();
            dp.Add("@ToolId", tool.Id);
            dp.Add("@PSuitability", tool.Suitability.PSuitability);
            dp.Add("@MSuitability", tool.Suitability.MSuitability);
            dp.Add("@KSuitability", tool.Suitability.KSuitability);
            dp.Add("@NSuitability", tool.Suitability.NSuitability);
            dp.Add("@SSuitability", tool.Suitability.SSuitability);
            dp.Add("@HSuitability", tool.Suitability.HSuitability);
            cnxn.Execute("dbo.spToolSuitability_Insert", dp, commandType: CommandType.StoredProcedure);
        }

        private static void InsertPrimaryToolData(ToolModel tool, IDbConnection cnxn)
        {
            DynamicParameters dp = new();
            dp.Add("@Id", tool.Id);
            dp.Add("@Description1", tool.Description1);
            dp.Add("@Description2", string.IsNullOrWhiteSpace(tool.Description2) ? null : tool.Description2);
            dp.Add("@ToolClassId", tool.ToolClassId);
            dp.Add("@ToolGroupId", tool.ToolGroupId);
            dp.Add("@MachineInterfaceName", string.IsNullOrWhiteSpace(tool.MachineInterfaceName) ? null : tool.MachineInterfaceName);
            dp.Add("@DataStatus", string.IsNullOrWhiteSpace(tool.DataStatus) ? null : tool.DataStatus);
            cnxn.Execute("dbo.spTools_Insert", dp, commandType: CommandType.StoredProcedure);
        }

        public void CreateToolClass(ToolClassModel model)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            InsertPrimaryToolClassData(model, cnxn);
        }

        private static void InsertPrimaryToolClassData(ToolClassModel model, IDbConnection cnxn)
        {
            DynamicParameters dp = new();
            dp.Add("@Id", model.Id);
            dp.Add("@Name", model.Name);
            dp.Add("@MainClassId", model.MainClassId);
            cnxn.Execute("dbo.spToolClasses_Insert", dp, commandType: CommandType.StoredProcedure);
        }

        public void CreateToolGroup(ToolGroupModel model)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            InsertPrimaryToolGroupData(model, cnxn);
        }

        private static void InsertPrimaryToolGroupData(ToolGroupModel model, IDbConnection cnxn)
        {
            DynamicParameters dp = new();
            dp.Add("@Id", model.Id);
            dp.Add("@Name", model.Name);
            dp.Add("@ToolClassId", model.ToolClassId);
            dp.Add("@SuitabilityEnabled", GetBitValueFromBool(model.SuitabilityEnabled));
            dp.Add("@MachineInterfaceEnabled", GetBitValueFromBool(model.MachineInterfaceEnabled));
            dp.Add("@InsertsEnabled", GetBitValueFromBool(model.InsertsEnabled));
            dp.Add("@HoldingOtherComponentsEnabled", GetBitValueFromBool(model.HoldingOtherComponentsEnabled));
            dp.Add("@EnabledInComps", GetBitValueFromBool(model.EnabledInComps));
            dp.Add("@EnabledInTools", GetBitValueFromBool(model.EnabledInTools));
            cnxn.Execute("dbo.spToolGroups_Insert", dp, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCompById(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            DeleteCompParametersById(id, cnxn);
            DeleteCompSuitabilityById(id, cnxn);
            DeletePrimaryCompDataById(id, cnxn);
        }

        private static void DeletePrimaryCompDataById(string id, IDbConnection cnxn)
            => cnxn.Execute("dbo.spComps_DeleteById", new { @Id = id }, commandType: CommandType.StoredProcedure);
        private static void DeleteCompSuitabilityById(string id, IDbConnection cnxn)
            => cnxn.Execute("dbo.spCompSuitability_DeleteByCompId", new { @CompId = id }, commandType: CommandType.StoredProcedure);
        private static void DeleteCompParametersById(string id, IDbConnection cnxn)
            => cnxn.Execute("dbo.spCompParameters_DeleteByCompId", new { @CompId = id }, commandType: CommandType.StoredProcedure);
        public void DeleteListById(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            DeleteListPositionsById(id, cnxn);
            DeletePrimaryListDataById(id, cnxn);
        }

        private static void DeletePrimaryListDataById(string id, IDbConnection cnxn)
            => cnxn.Execute("dbo.spLists_DeleteById", new { @Id = id }, commandType: CommandType.StoredProcedure);
        private static void DeleteListPositionsById(string id, IDbConnection cnxn)
            => cnxn.Execute("dbo.spListPositions_DeleteByListId", new { @ListId = id }, commandType: CommandType.StoredProcedure);
        public void DeleteToolById(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            DeleteToolSuitabilityById(id, cnxn);
            DeleteToolParametersById(id, cnxn);
            DeleteToolComponentsById(id, cnxn);
            DeletePrimaryToolDataById(id, cnxn);
        }

        private static void DeletePrimaryToolDataById(string id, IDbConnection cnxn)
            => cnxn.Execute("dbo.spTools_DeleteById", new { @Id = id }, commandType: CommandType.StoredProcedure);
        private static void DeleteToolComponentsById(string id, IDbConnection cnxn)
            => cnxn.Execute("dbo.spToolComponents_DeleteByToolId", new { @ToolId = id }, commandType: CommandType.StoredProcedure);
        private static void DeleteToolParametersById(string id, IDbConnection cnxn)
            => cnxn.Execute("dbo.spToolParameters_DeleteByToolId", new { @ToolId = id }, commandType: CommandType.StoredProcedure);
        private static void DeleteToolSuitabilityById(string id, IDbConnection cnxn)
            => cnxn.Execute("dbo.spToolSuitability_DeleteByToolId", new { @ToolId = id }, commandType: CommandType.StoredProcedure);
        public BasicCompModel GetBasicCompModelById(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return GetBasicCompModelById(id, cnxn);
        }

        private static BasicCompModel GetBasicCompModelById(string id, IDbConnection cnxn)
            => cnxn.Query<BasicCompModel>("dbo.spComps_GetBasicDataById", new { @Id = id }, commandType: CommandType.StoredProcedure).First();

        public BasicToolModel GetBasicToolModelById(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return GetBasicToolModelById(id, cnxn);
        }

        private static BasicToolModel GetBasicToolModelById(string id, IDbConnection cnxn)
            => cnxn.Query<BasicToolModel>("dbo.spTools_GetBasicDataById", new { @Id = id }, commandType: CommandType.StoredProcedure).First();

        public List<ToolClassModel> GetToolClassesList()
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            List<ToolClassModel> models = GetPrimaryToolClassesData(cnxn);
            foreach (ToolClassModel model in models)
            {
                model.ToolGroups = GetToolGroupModelsByToolClassId(cnxn, model.Id);
                model.ToolClassParameters = GetToolClassParameterModelsByToolClassId(cnxn, model.Id);
            }
            return models;
        }
        private static List<ToolClassParameterModel> GetToolClassParameterModelsByToolClassId(IDbConnection cnxn, string toolClassId)
        {
            List<ToolClassParameterModel> toolClassParameters = cnxn.Query<ToolClassParameterModel>("dbo.spToolClassParameters_GetByToolClassId", new { @ToolClassId = toolClassId }, commandType: CommandType.StoredProcedure).ToList();
            foreach (ToolClassParameterModel tcpm in toolClassParameters)
            {
                tcpm.AssignedToolGroupIds = GetAssignedGroupIdsForToolClassParameterModel(cnxn, toolClassId, tcpm.Id);
            }
            return toolClassParameters;
        }

        private static List<string> GetAssignedGroupIdsForToolClassParameterModel(IDbConnection cnxn, string toolClassId, string parameterId) => cnxn.Query<string>("dbo.spToolClassParameterGroups_GetToolGroupIdsByToolClassIdParameterId", new { @ToolClassId = toolClassId, @ParameterId = parameterId }, commandType: CommandType.StoredProcedure).ToList();
        private static List<ToolGroupModel> GetToolGroupModelsByToolClassId(IDbConnection cnxn, string toolClassId)
            => cnxn.Query<ToolGroupModel>("dbo.spToolGroups_GetByToolClassId", new { @ToolClassId = toolClassId }, commandType: CommandType.StoredProcedure).ToList();
        private static List<ToolClassModel> GetPrimaryToolClassesData(IDbConnection cnxn) => cnxn.Query<ToolClassModel>("dbo.spToolClasses_GetAll", commandType: CommandType.StoredProcedure).ToList();

        public ToolClassModel GetToolClassById(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            ToolClassModel model = GetToolClassModelById(id, cnxn);
            model.ToolGroups = GetToolGroupModelsByToolClassId(cnxn, id);
            model.ToolClassParameters = GetToolClassParameterModelsByToolClassId(cnxn, id);
            return model;
        }

        private static ToolClassModel GetToolClassModelById(string id, IDbConnection cnxn)
            => cnxn.Query<ToolClassModel>("dbo.spToolClasses_GetById", new { @Id = id }, commandType: CommandType.StoredProcedure).First();

        public string GetToolClassNameById(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return GetToolClassNameById(id, cnxn);
        }

        private static string GetToolClassNameById(string id, IDbConnection cnxn)
            => cnxn.Query<string>("dbo.spToolClasses_GetNameById", new { @Id = id }, commandType: CommandType.StoredProcedure).First();

        public CompModel GetCompModelById(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            CompModel model = GetPrimaryCompDataById(id, cnxn);
            model.Suitability = GetCompSuitability(cnxn, id);
            model.Parameters = GetCompParametersByIdToolClassIdToolGroupId(id, cnxn, model.ToolClassId, model.ToolGroupId);
            return model;
        }

        private static List<ParameterModel> GetCompParametersByIdToolClassIdToolGroupId(string compId, IDbConnection cnxn, string toolClassId, string toolGroupId)
        {
            List<ParameterModel> parameters = GetParametersByToolClassIdToolGroupId(toolClassId, toolGroupId, cnxn);
            List<ParameterModel> parameterValues = GetCompParametersByCompIdToolClassId(compId, cnxn, toolClassId);
            foreach (ParameterModel pv in parameterValues)
            {
                parameters.Where(p => p.Id == pv.Id).First().NumericValue = pv.NumericValue;
                parameters.Where(p => p.Id == pv.Id).First().TextValue = pv.TextValue;
            }
            return parameters;
        }

        private static List<ParameterModel> GetCompParametersByCompIdToolClassId(string compId, IDbConnection cnxn, string toolClassId)
        {
            // TODO - Verify if providing ToolClassId is necessary
            return cnxn.Query<ParameterModel>(
                "dbo.spGetCompParameters_ByCompIdToolClassId",
                new { @CompId = compId, @ToolClassId = toolClassId },
                commandType: CommandType.StoredProcedure)
                .ToList();
        }

        private static SuitabilityModel GetCompSuitability(IDbConnection cnxn, string compId)
            => cnxn.Query<SuitabilityModel>("dbo.spCompSuitability_GetByCompId", new { @CompId = compId }, commandType: CommandType.StoredProcedure).First();
        private static CompModel GetPrimaryCompDataById(string id, IDbConnection cnxn)
            => cnxn.Query<CompModel>("dbo.spComps_GetById", new { @Id = id }, commandType: CommandType.StoredProcedure).First();

        public List<string> GetAssignedGroupsIdsByClassIdAndParameterId(string toolClassId, string parameterId)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return GetAssignedGroupIdsForToolClassParameterModel(cnxn, toolClassId, parameterId);
        }

        public string GetToolGroupNameByIdToolClassId(string id, string toolClassId)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return GetToolGroupNameByIdToolClassId(id, toolClassId, cnxn);
        }

        private static string GetToolGroupNameByIdToolClassId(string id, string toolClassId, IDbConnection cnxn)
            => cnxn.Query<string>("dbo.spToolGroups_GetNameById", new { @Id = id, @ToolClassId = toolClassId }, commandType: CommandType.StoredProcedure).First();

        public ListModel GetListModelById(string listId)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            ListModel model = GetPrimaryListDataById(listId, cnxn);
            model.ListPositions = GetListPositionsById(listId, cnxn);
            return model;
        }

        private static ListModel GetPrimaryListDataById(string listId, IDbConnection cnxn)
            => cnxn.Query<ListModel>("dbo.spLists_GetById", new { @Id = listId }, commandType: CommandType.StoredProcedure).First();

        private static List<ListPositionModel> GetListPositionsById(string listId, IDbConnection cnxn)
        {
            List<ListPositionModel> listPostions = GetPrimaryListPositionsDataByListId(listId, cnxn);
            listPostions = GetListPositionsCompAndToolData(listId, listPostions, cnxn);
            return listPostions;
        }

        private static List<ListPositionModel> GetListPositionsCompAndToolData(string listId, List<ListPositionModel> listPostions, IDbConnection cnxn)
        {
            foreach (ListPositionModel lp in listPostions)
            {
                string compId = GetCompIdByListIdPosition(listId, cnxn, lp.Position);
                lp.BasicComp = compId == null ? null : GetBasicCompModelById(compId, cnxn);
                string toolId = GetToolIdByListIdPosition(listId, cnxn, lp.Position);
                lp.BasicTool = toolId == null ? null : GetBasicToolModelById(toolId, cnxn);
            }
            return listPostions;
        }

        private static string GetToolIdByListIdPosition(string listId, IDbConnection cnxn, int position)
            => cnxn.Query<string>("dbo.spListPositions_GetToolIdByListIdPosition", new { @ListId = listId, @Position = position }, commandType: CommandType.StoredProcedure).First();

        private static string GetCompIdByListIdPosition(string listId, IDbConnection cnxn, int position)
            => cnxn.Query<string>("dbo.spListPositions_GetCompIdByListIdPosition", new { @ListId = listId, @Position = position }, commandType: CommandType.StoredProcedure).First();

        private static List<ListPositionModel> GetPrimaryListPositionsDataByListId(string listId, IDbConnection cnxn)
            => cnxn.Query<ListPositionModel>("dbo.spListPositions_GetByListId", new { @ListId = listId }, commandType: CommandType.StoredProcedure).ToList();

        public List<MainClassModel> GetMainClassesList()
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            List<MainClassModel> mainClasses = GetMainClasses(cnxn);
            return mainClasses;
        }

        private List<MainClassModel> GetMainClasses(IDbConnection cnxn)
        {
            List<MainClassModel> mainClasses = GetPrimaryMainClassData(cnxn);
            foreach (MainClassModel mainClass in mainClasses)
            {
                mainClass.ToolClasses = GetMainClassToolClassesData(mainClass.Id, cnxn);
            }
            return mainClasses;
        }

        private List<ToolClassModel> GetMainClassToolClassesData(string mainClassId, IDbConnection cnxn)
        {
            List<string> toolClassIds = GetToolClassIdsByMainClassId(mainClassId, cnxn);
            List<ToolClassModel> toolClasses = new();
            foreach (string id in toolClassIds)
            {
                toolClasses.Add(GetToolClassById(id));
            }
            return toolClasses;
        }

        private static List<string> GetToolClassIdsByMainClassId(string mainClassId, IDbConnection cnxn)
            => cnxn.Query<string>("dbo.spToolClasses_GetIdsByMainClassId", new { @MainClassId = mainClassId }, commandType: CommandType.StoredProcedure).ToList();

        private static List<MainClassModel> GetPrimaryMainClassData(IDbConnection cnxn)
            => cnxn.Query<MainClassModel>("dbo.spMainClasses_GetAll", commandType: CommandType.StoredProcedure).ToList();

        public string GetMainClassNameById(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return GetMainClassNameById(id, cnxn);
        }

        private static string GetMainClassNameById(string id, IDbConnection cnxn)
            => cnxn.Query<string>("dbo.spMainClasses_GetNameById", new { @Id = id }, commandType: CommandType.StoredProcedure).First();

        public string GetManufacturerIdByName(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return GetManufacturerIdByName(id, cnxn);
        }

        private static string GetManufacturerIdByName(string id, IDbConnection cnxn)
            => cnxn.Query<string>("dbo.spManufacturers_GetNameById", new { @Id = id }, commandType: CommandType.StoredProcedure).First();

        public ToolModel GetToolModelById(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            ToolModel model = GetPrimaryToolData(id, cnxn);
            model.Suitability = GetToolSuitability(id, cnxn);
            model.Parameters = GetToolParametersById(id, cnxn, model.ToolClassId, model.ToolGroupId);
            model.Components = GetToolComponentsById(cnxn, id);
            return model;
        }
        private static List<ToolComponentModel> GetToolComponentsById(IDbConnection cnxn, string toolId)
        {
            // get list of comps without compmodel
            List<ToolComponentModel> toolComponents = cnxn.Query<ToolComponentModel>(
                "dbo.spToolComponents_GetByToolId",
                new { @ToolId = toolId },
                commandType: CommandType.StoredProcedure)
                .ToList();
            // get comp model for every component
            foreach (ToolComponentModel tc in toolComponents)
            {
                tc.BasicComp = GetBasicCompModelById(GetCompIdByToolIdPosition(toolId, cnxn, tc.Position), cnxn);
            }
            return toolComponents;
        }
        private static List<ParameterModel> GetToolParametersById(string id, IDbConnection cnxn, string toolClassId, string toolGroupId)
        {
            List<ParameterModel> parameters = GetParametersByToolClassIdToolGroupId(toolClassId, toolGroupId, cnxn);
            List<ParameterModel> parameterValues = GetToolParametersByIdToolClassId(id, cnxn, toolClassId);
            foreach (ParameterModel pv in parameterValues)
            {
                parameters.Where(p => p.Id == pv.Id).First().NumericValue = pv.NumericValue;
                parameters.Where(p => p.Id == pv.Id).First().TextValue = pv.TextValue;
            }
            return parameters;
        }

        private static List<ParameterModel> GetToolParametersByIdToolClassId(string id, IDbConnection cnxn, string toolClassId)
        {
            // TODO - Verify if providing ToolClassId is necessary
            return cnxn.Query<ParameterModel>(
                "dbo.spGetToolParameters_ByToolIdToolClassId",
                new { @ToolId = id, @ToolClassId = toolClassId },
                commandType: CommandType.StoredProcedure)
                .ToList();
        }

        private static SuitabilityModel GetToolSuitability(string id, IDbConnection cnxn)
            => cnxn.Query<SuitabilityModel>("dbo.spToolSuitability_GetByToolId", new { @ToolId = id }, commandType: CommandType.StoredProcedure).First();

        private static ToolModel GetPrimaryToolData(string toolId, IDbConnection cnxn)
            => cnxn.Query<ToolModel>("dbo.spTools_GetById", new { @Id = toolId }, commandType: CommandType.StoredProcedure).First();

        private static string GetCompIdByToolIdPosition(string toolId, IDbConnection cnxn, int position)
        {
            DynamicParameters dp = new();
            dp.Add("@ToolId", toolId);
            dp.Add("@Position", position);
            return cnxn.Query<string>("dbo.spToolComponents_GetCompIdByToolIdPosition",
                            dp,
                            commandType: CommandType.StoredProcedure)
                            .First();
        }

        public List<ToolClassModel> GetUnallocatedToolClasses() =>
            GetToolClassesList().Where(tc => string.IsNullOrWhiteSpace(tc.MainClassId)).ToList();

        public List<string> GetDataValueTypes()
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return GetDataValueTypes(cnxn);
        }

        private static List<string> GetDataValueTypes(IDbConnection cnxn)
            => cnxn.Query<string>("dbo.spDataValueTypes_GetAll", commandType: CommandType.StoredProcedure).ToList();

        public void SetMainClassIdById(string mainClassId, string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            UpdateToolClassMainClassId(mainClassId, id, cnxn);
        }

        private static void UpdateToolClassMainClassId(string mainClassId, string id, IDbConnection cnxn)
            => cnxn.Execute("dbo.spToolClasses_UpdateMainClassIdById", new { @MainClassId = mainClassId, @Id = id }, commandType: CommandType.StoredProcedure);

        public void UpdateToolClassParameter(ToolClassParameterModel model)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            UpdatePrimaryToolClassData(model, cnxn);
            UpdateToolClassAssignedGroups(model, cnxn);
        }

        private void UpdateToolClassAssignedGroups(ToolClassParameterModel model, IDbConnection cnxn)
        {
            List<string> currentToolGroupIds = GetAssignedGroupsIdsByClassIdAndParameterId(model.ToolClassId, model.Id);
            List<string> missingToolGroupIds = model.AssignedToolGroupIds.Except(currentToolGroupIds).ToList();
            AssignToolGroupsToParameter(cnxn, missingToolGroupIds, model.ToolClassId, model.Id);
            List<string> obsoleteToolGroupIds = currentToolGroupIds.Except(model.AssignedToolGroupIds).ToList();
            DeleteParameterToolGroupsData(model.ToolClassId, model.Id, cnxn, obsoleteToolGroupIds);
        }

        private static void DeleteParameterToolGroupsData(string toolClassId, string parameterId, IDbConnection cnxn, List<string> toolGroupIds)
        {
            DeleteCompParametersDataByToolClassIdParameterIdToolGroupIds(cnxn, toolClassId, parameterId, toolGroupIds);
            DeleteToolParametersDataByToolClassIdParameterIdToolGroupIds(cnxn, toolClassId, parameterId, toolGroupIds);
            UnassignToolGroupsFromParameter(cnxn, toolClassId, parameterId, toolGroupIds);
        }

        private static void UnassignToolGroupsFromParameter(IDbConnection cnxn, string toolClassId, string parameterId, List<string> toolGroupIds)
        {
            foreach (string toolGroupId in toolGroupIds)
            {
                DynamicParameters dp = new();
                dp.Add("@ToolClassId", toolClassId);
                dp.Add("@ParameterId", parameterId);
                dp.Add("@ToolGroupId", toolGroupId);
                cnxn.Execute("dbo.spToolClassParameterGroups_DeleteByToolClassIdParameterIdToolGroupId", dp, commandType: CommandType.StoredProcedure);
            }
        }

        private static void DeleteToolParametersDataByToolClassIdParameterIdToolGroupIds(IDbConnection cnxn, string toolClassId, string parameterId, List<string> toolGroupIds)
        {
            foreach (string toolGroupId in toolGroupIds)
            {
                DynamicParameters dp = new();
                dp.Add("@ToolClassId", toolClassId);
                dp.Add("@ParameterId", parameterId);
                dp.Add("@ToolGroupId", toolGroupId);
                cnxn.Execute("dbo.spToolParameters_DeleteByToolClassIdParameterIdToolGroupId", dp, commandType: CommandType.StoredProcedure);
            }
        }

        private static void DeleteCompParametersDataByToolClassIdParameterIdToolGroupIds(IDbConnection cnxn, string toolClassId, string parameterId, List<string> toolGroupIds)
        {
            foreach (string toolGroupId in toolGroupIds)
            {
                DynamicParameters dp = new();
                dp.Add("@ToolClassId", toolClassId);
                dp.Add("@ParameterId", parameterId);
                dp.Add("@ToolGroupId", toolGroupId);
                cnxn.Execute("dbo.spCompParameters_DeleteByToolClassIdParameterIdToolGroupId", dp, commandType: CommandType.StoredProcedure);
            }
        }

        private static void UpdatePrimaryToolClassData(ToolClassParameterModel model, IDbConnection cnxn)
        {
            DynamicParameters dp = new();
            dp.Add("@Id", model.Id);
            dp.Add("@ToolClassId", model.ToolClassId);
            dp.Add("@Position", model.Position);
            dp.Add("@Name", model.Name);
            dp.Add("@Description", model.Description);
            dp.Add("@DataValueType", model.DataValueType);
            cnxn.Execute("dbo.spToolClassParameters_UpdateById", dp, commandType: CommandType.StoredProcedure);
        }

        public void UpdateComp(CompModel model)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            UpdatePrimaryCompData(model, cnxn);
            UpdateCompSuitability(model.Id, model.Suitability, cnxn);
            UpdateCompParameters(model.Id, model.ToolClassId, model.Parameters, cnxn);
        }

        private static void UpdateCompParameters(string compId, string toolClassId, List<ParameterModel> parameters, IDbConnection cnxn)
        {
            if (parameters != null)
            {
                List<ParameterModel> existingParameters = GetCompParametersByCompIdToolClassId(compId, cnxn, toolClassId);
                List<ParameterModel> missingParameters = parameters.Except(existingParameters, new ParameterModelIdComparer()).ToList();
                InsertCompParameters(cnxn, missingParameters, compId);
                // Delete unassigned parameters and parameters no longer available to comp
                List<ParameterModel> obsoleteParameters = parameters
                    .Where(p => p.NumericValue == null && p.TextValue == null)
                    .Concat(existingParameters.Except(parameters, new ParameterModelIdComparer()))
                    .ToList();
                DeleteCompParameters(compId, cnxn, obsoleteParameters);
                List<ParameterModel> updatedParameters = parameters.Except(obsoleteParameters).Except(missingParameters).ToList();
                UpdateModifiedCompParameters(compId, cnxn, updatedParameters);
            }
            else
            {
                DeleteCompParametersById(compId, cnxn);
            }
        }

        private static void UpdateModifiedCompParameters(string compId, IDbConnection cnxn, List<ParameterModel> updatedParameters)
        {
            foreach (ParameterModel p in updatedParameters)
            {
                DynamicParameters dp = new();
                dp.Add("@CompId", compId);
                dp.Add("@ParameterId", p.Id);
                dp.Add("@NumericValue", p.NumericValue);
                dp.Add("@TextValue", p.TextValue);
                cnxn.Execute("dbo.spCompParameters_UpdateById", dp, commandType: CommandType.StoredProcedure);
            }
        }

        private static void DeleteCompParameters(string compId, IDbConnection cnxn, List<ParameterModel> obsoleteParameters)
        {
            foreach (ParameterModel p in obsoleteParameters)
            {
                DynamicParameters dp = new();
                dp.Add("@CompId", compId);
                dp.Add("@ParameterId", p.Id);
                cnxn.Execute("dbo.spCompParameters_DeleteByCompIdParameterId", dp, commandType: CommandType.StoredProcedure);
            }
        }

        private static void UpdateCompSuitability(string compId, SuitabilityModel suitability, IDbConnection cnxn)
        {
            if (suitability != null)
            {
                DynamicParameters dp = new();
                dp.Add("@CompId", compId);
                dp.Add("@PSuitability", suitability.PSuitability);
                dp.Add("@MSuitability", suitability.MSuitability);
                dp.Add("@KSuitability", suitability.KSuitability);
                dp.Add("@NSuitability", suitability.NSuitability);
                dp.Add("@SSuitability", suitability.SSuitability);
                dp.Add("@HSuitability", suitability.HSuitability);
                cnxn.Execute("dbo.spCompSuitability_UpdateById", dp, commandType: CommandType.StoredProcedure);
            }
            else
            {
                cnxn.Execute("dbo.spCompSuitability_DeleteByCompId", new { @CompId = compId }, commandType: CommandType.StoredProcedure);
            }
        }

        private static void UpdatePrimaryCompData(CompModel model, IDbConnection cnxn)
        {
            DynamicParameters dp = new();
            dp.Add("@Id", model.Id);
            dp.Add("@Description1", model.Description1);
            dp.Add("@Description2", string.IsNullOrWhiteSpace(model.Description2) ? null : model.Description2);
            dp.Add("@ToolClassId", model.ToolClassId);
            dp.Add("@ToolGroupId", model.ToolGroupId);
            dp.Add("@ManufacturerName", string.IsNullOrWhiteSpace(model.ManufacturerName) ? null : model.ManufacturerName);
            dp.Add("@MachineInterfaceName", string.IsNullOrWhiteSpace(model.MachineInterfaceName) ? null : model.MachineInterfaceName);
            dp.Add("@DataStatus", string.IsNullOrWhiteSpace(model.DataStatus) ? null : model.DataStatus);
            cnxn.Execute("dbo.spComps_UpdateById", dp, commandType: CommandType.StoredProcedure);
        }

        public void UpdateList(ListModel model)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            UpdatePrimaryListData(model, cnxn);
            UpdateListPositions(model.Id, model.ListPositions, cnxn);

        }

        private static void UpdateListPositions(string listId, List<ListPositionModel> listPositions, IDbConnection cnxn)
        {
            List<ListPositionModel> currentPositions = GetListPositionsById(listId, cnxn);
            List<ListPositionModel> newPositions = listPositions.Except(currentPositions, new ListPositionModelPositionComparer()).ToList();
            InsertListPositions(listId, newPositions, cnxn);
            List<ListPositionModel> modifiedPositions = listPositions.Except(currentPositions, new ListPositionModelComparer())
                .Except(newPositions)
                .ToList();
            UpdateModifiedListPositions(listId, modifiedPositions, cnxn);
            List<ListPositionModel> obsoletePositions = currentPositions.Except(listPositions, new ListPositionModelPositionComparer()).ToList();
            DeleteListPositionsByIdPositions(listId, obsoletePositions, cnxn);
        }

        private static void DeleteListPositionsByIdPositions(string listId, List<ListPositionModel> obsoletePositions, IDbConnection cnxn)
        {
            foreach (ListPositionModel lp in obsoletePositions)
            {
                DynamicParameters dp = new();
                dp.Add("@ListId", listId);
                dp.Add("@Position", lp.Position);
                cnxn.Execute("dbo.spListPositions_Delete", dp, commandType: CommandType.StoredProcedure);
            }
        }

        private static void UpdateModifiedListPositions(string listId, List<ListPositionModel> modifiedPositions, IDbConnection cnxn)
        {
            foreach (ListPositionModel lp in modifiedPositions)
            {
                DynamicParameters dp = new();
                dp.Add("@ListId", listId);
                dp.Add("@Position", lp.Position);
                dp.Add("@CompId", lp.BasicComp?.Id);
                dp.Add("@ToolId", lp.BasicTool?.Id);
                dp.Add("@Quantity", lp.Quantity);
                cnxn.Execute("dbo.spListPositions_Update", dp, commandType: CommandType.StoredProcedure);
            }
        }

        private static void UpdatePrimaryListData(ListModel model, IDbConnection cnxn)
        {
            DynamicParameters dp = new();
            dp.Add("@Id", model.Id);
            dp.Add("@Description1", model.Description1);
            dp.Add("@Description2", string.IsNullOrWhiteSpace(model.Description2) ? null : model.Description2);
            dp.Add("@MachineId", string.IsNullOrWhiteSpace(model.MachineId) ? null : model.MachineId);
            dp.Add("@MachineGroupId", string.IsNullOrWhiteSpace(model.MachineGroupId) ? null : model.MachineGroupId);
            dp.Add("@MaterialId", string.IsNullOrWhiteSpace(model.MaterialId) ? null : model.MaterialId);
            dp.Add("@DataStatus", string.IsNullOrWhiteSpace(model.DataStatus) ? null : model.DataStatus);
            dp.Add("@CreatorName", string.IsNullOrWhiteSpace(model.CreatorName) ? null : model.CreatorName);
            dp.Add("@LastModifiedName", string.IsNullOrWhiteSpace(model.LastModifiedName) ? null : model.LastModifiedName);
            dp.Add("@OwnerName", string.IsNullOrWhiteSpace(model.OwnerName) ? null : model.OwnerName);
            cnxn.Execute("dbo.spLists_UpdateById", dp, commandType: CommandType.StoredProcedure);
        }

        public void UpdateBasicMainClass(BasicMainClassModel model)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            UpdateBasicMainClassModel(model, cnxn);
        }

        private static void UpdateBasicMainClassModel(BasicMainClassModel model, IDbConnection cnxn)
        {
            DynamicParameters dp = new();
            dp.Add("@Id", model.Id);
            dp.Add("@Name", model.Name);
            cnxn.Execute("dbo.spMainClasses_Update", dp, commandType: CommandType.StoredProcedure);
        }

        public void UpdateTool(ToolModel model)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            UpdatePrimaryToolData(model, cnxn);
            UpdateToolSuitability(model.Id, model.Suitability, cnxn);
            UpdateToolParameters(model.Id, model.ToolClassId, model.Parameters, cnxn);
            UpdateToolComponents(model.Id, model.Components, cnxn);
        }

        private static void UpdateToolComponents(string toolId, List<ToolComponentModel> components, IDbConnection cnxn)
        {
            List<ToolComponentModel> currentComponents = GetToolComponentsByToolId(toolId, cnxn);
            foreach (ToolComponentModel tc in currentComponents)
            {
                tc.BasicComp = GetBasicCompModelById(GetCompIdByToolIdPosition(toolId, cnxn, tc.Position), cnxn);
            }
            List<ToolComponentModel> newComponents = components.Except(currentComponents, new ToolComponentModelPositionComparer()).ToList();
            InsertToolComponents(toolId, newComponents, cnxn);
            List<ToolComponentModel> modifiedComponents = components.Except(currentComponents, new ToolComponentModelComparer()).Except(newComponents).ToList();
            UpdateModifiedToolComponents(toolId, modifiedComponents, cnxn);
            List<ToolComponentModel> obsoleteComponents = currentComponents.Except(components, new ToolComponentModelPositionComparer()).ToList();
            DeleteToolComponents(toolId, obsoleteComponents, cnxn);
        }

        private static void DeleteToolComponents(string toolId, List<ToolComponentModel> obsoleteComponents, IDbConnection cnxn)
        {
            foreach (ToolComponentModel tc in obsoleteComponents)
            {
                DynamicParameters dp = new();
                dp.Add("@ToolId", toolId);
                dp.Add("@Position", tc.Position);
                cnxn.Execute("dbo.spToolComponents_Delete", dp, commandType: CommandType.StoredProcedure);
            }
        }

        private static void UpdateModifiedToolComponents(string toolId, List<ToolComponentModel> modifiedComponents, IDbConnection cnxn)
        {
            foreach (ToolComponentModel tc in modifiedComponents)
            {
                DynamicParameters dp = new();
                dp.Add("@ToolId", toolId);
                dp.Add("@CompId", tc.BasicComp.Id);
                dp.Add("@Quantity", tc.Quantity);
                dp.Add("@Position", tc.Position);
                dp.Add("@IsKey", GetBitValueFromBool(tc.IsKey));
                cnxn.Execute("dbo.spToolComponents_Update", dp, commandType: CommandType.StoredProcedure);
            }
        }

        private static void UpdateToolParameters(string toolId, string toolClassId, List<ParameterModel> parameters, IDbConnection cnxn)
        {

            if (parameters != null)
            {
                List<ParameterModel> existingParameters = cnxn.Query<ParameterModel>("dbo.spGetToolParameters_ByToolIdToolClassId", new { @ToolId = toolId, @ToolClassId = toolClassId }, commandType: CommandType.StoredProcedure).ToList();
                List<ParameterModel> missingParameters = parameters.Except(existingParameters, new ParameterModelIdComparer()).ToList();
                InsertToolParameters(toolId, missingParameters, cnxn);
                List<ParameterModel> obsoleteParameters = parameters.Where(p => p.NumericValue == null && p.TextValue == null)
                    .Concat(existingParameters.Except(parameters, new ParameterModelIdComparer()))
                    .ToList();
                DeleteToolParameters(toolId, obsoleteParameters, cnxn);
                List<ParameterModel> modifiedParameters = parameters.Except(obsoleteParameters).Except(missingParameters).ToList();
                UpdateModifiedToolParameters(toolId, modifiedParameters, cnxn);
            }
            else
            {
                DeleteToolParametersById(toolId, cnxn);
            }
        }

        private static void UpdateModifiedToolParameters(string toolId, List<ParameterModel> modifiedParameters, IDbConnection cnxn)
        {
            foreach (ParameterModel p in modifiedParameters)
            {
                DynamicParameters dp = new();
                dp.Add("@ToolId", toolId);
                dp.Add("@ParameterId", p.Id);
                dp.Add("@TextValue", p.TextValue);
                dp.Add("@NumericValue", p.NumericValue);
                cnxn.Execute("dbo.spToolParameters_Update", dp, commandType: CommandType.StoredProcedure);
            }
        }

        private static void DeleteToolParameters(string toolId, List<ParameterModel> obsoleteParameters, IDbConnection cnxn)
        {
            foreach (ParameterModel p in obsoleteParameters)
            {
                DynamicParameters dp = new();
                dp.Add("@ToolId", toolId);
                dp.Add("@ParameterId", p.Id);
                cnxn.Execute("dbo.spToolParameters_DeleteByToolIdParameterId", dp, commandType: CommandType.StoredProcedure);
            }
        }

        private static void UpdateToolSuitability(string toolId, SuitabilityModel suitability, IDbConnection cnxn)
        {
            if (suitability != null)
            {
                DynamicParameters dp = new();
                dp.Add("@ToolId", toolId);
                dp.Add("@PSuitability", suitability.PSuitability);
                dp.Add("@MSuitability", suitability.MSuitability);
                dp.Add("@KSuitability", suitability.KSuitability);
                dp.Add("@NSuitability", suitability.NSuitability);
                dp.Add("@SSuitability", suitability.SSuitability);
                dp.Add("@HSuitability", suitability.HSuitability);
                cnxn.Execute("dbo.spToolSuitability_Update", dp, commandType: CommandType.StoredProcedure);
            }
            else
            {
                cnxn.Execute("dbo.spToolSuitability_DeleteByToolId", new { @ToolId = toolId }, commandType: CommandType.StoredProcedure);
            }
        }

        private static void UpdatePrimaryToolData(ToolModel model, IDbConnection cnxn)
        {
            DynamicParameters dp = new();
            dp.Add("@Id", model.Id);
            dp.Add("@Description1", model.Description1);
            dp.Add("@Description2", string.IsNullOrWhiteSpace(model.Description2) ? null : model.Description2);
            dp.Add("@ToolClassId", model.ToolClassId);
            dp.Add("@ToolGroupId", model.ToolGroupId);
            dp.Add("@MachineInterfaceName", string.IsNullOrWhiteSpace(model.MachineInterfaceName) ? null : model.MachineInterfaceName);
            dp.Add("@DataStatus", string.IsNullOrWhiteSpace(model.DataStatus) ? null : model.DataStatus);
            cnxn.Execute("dbo.spTools_Update", dp, commandType: CommandType.StoredProcedure);
        }

        private static List<ToolComponentModel> GetToolComponentsByToolId(string id, IDbConnection cnxn) =>
            cnxn.Query<ToolComponentModel>("dbo.spToolComponents_GetByToolId", new { @ToolId = id }, commandType: CommandType.StoredProcedure).ToList();

        public void UpdateToolClass(ToolClassModel model)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            UpdatePrimaryToolClassData(model, cnxn);
        }

        private static void UpdatePrimaryToolClassData(ToolClassModel model, IDbConnection cnxn)
        {
            DynamicParameters dp = new();
            dp.Add("@Id", model.Id);
            dp.Add("@Name", model.Name);
            dp.Add("@MainClassId", model.MainClassId);
            cnxn.Execute("dbo.spToolClasses_Update", dp, commandType: CommandType.StoredProcedure);
        }

        public void UpdateToolGroup(ToolGroupModel model)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            UpdatePrimaryToolGroupData(model, cnxn);
        }

        private static void UpdatePrimaryToolGroupData(ToolGroupModel model, IDbConnection cnxn)
        {
            DynamicParameters dp = new();
            dp.Add("@Id", model.Id);
            dp.Add("@Name", model.Name);
            dp.Add("@ToolClassId", model.ToolClassId);
            dp.Add("@SuitabilityEnabled", GetBitValueFromBool(model.SuitabilityEnabled));
            dp.Add("@MachineInterfaceEnabled", GetBitValueFromBool(model.MachineInterfaceEnabled));
            dp.Add("@InsertsEnabled", GetBitValueFromBool(model.InsertsEnabled));
            dp.Add("@HoldingOtherComponentsEnabled", GetBitValueFromBool(model.HoldingOtherComponentsEnabled));
            dp.Add("@EnabledInComps", GetBitValueFromBool(model.EnabledInComps));
            dp.Add("@EnabledInTools", GetBitValueFromBool(model.EnabledInTools));
            cnxn.Execute("dbo.spToolGroups_Update", dp, commandType: CommandType.StoredProcedure);
        }

        public string ValidateToolClassIdToolGroupId(string toolClassId, string toolGroupId)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            DynamicParameters dp = new();
            dp.Add("@ToolClassId", toolClassId);
            dp.Add("@Id", toolGroupId);
            if (!cnxn.ExecuteScalar<bool>("dbo.spToolGroups_ValidateIdToolClassId",
                dp,
                commandType: CommandType.StoredProcedure))
            {
                return "Invalid Tool Class/Group\n";
            }
            return "";
        }
        public bool ValidateCompId(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return cnxn.ExecuteScalar<bool>("dbo.spComps_ValidateId",
                new { @Id = id },
                commandType: CommandType.StoredProcedure);
        }
        public bool ValidateListId(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return cnxn.ExecuteScalar<bool>("dbo.spLists_ValidateId",
                new { @Id = id },
                commandType: CommandType.StoredProcedure);
        }
        public string ValidateListPositions(List<ListPositionModel> tools)
        {
            string errorMessage = "";
            foreach (ListPositionModel lp in tools)
            {
                if (lp.BasicComp != null)
                {
                    if (!ValidateCompId(lp.BasicComp.Id))
                    {
                        errorMessage += $"Position nr:{lp.Position} is invalid. {lp.BasicComp.Id} is not a valid Id number!\n";
                    }
                }
                if (lp.BasicTool != null)
                {
                    if (!ValidateToolId(lp.BasicTool.Id))
                    {
                        errorMessage += $"Position nr: {lp.Position} is invalid. {lp.BasicTool.Id} is not a valid Id number!\n";
                    }
                }
                if (lp.BasicComp == null && lp.BasicTool == null)
                {
                    errorMessage += $"Position nr:{lp.Position} is empty!";
                }
            }
            return errorMessage;
        }

        public string ValidateMachine(string machineId, string machineGroupId)
        {
            string errorMessage = "";
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            if (!cnxn.ExecuteScalar<bool>("dbo.spMachines_ValidateId", new { @Id = machineId }, commandType: CommandType.StoredProcedure))
            {
                errorMessage += $"Machine with Id: {machineId} doesn't exist\n";
            }
            if (!cnxn.ExecuteScalar<bool>("dbo.spMachineGroups_ValidateId", new { @Id = machineGroupId }, commandType: CommandType.StoredProcedure))
            {
                errorMessage += $"Machine Group with Id: {machineGroupId} doesn't exist\n";
            }
            DynamicParameters dp = new();
            dp.Add("@MachineId", machineId);
            dp.Add("@MachineGroupId", machineGroupId);
            if (!cnxn.ExecuteScalar<bool>("dbo.spMachineMachineGroups_ValidateMachineIdMachineGroupId",
                                            dp,
                                            commandType: CommandType.StoredProcedure))
            {
                errorMessage += $"Machine with Id: {machineId} is not allocated to Machine group with Id: {machineGroupId}\n";
            }
            return errorMessage;
        }
        public string ValidateMachineInterfaceName(string name)
        {
            string errorMessage = "";
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            if (!cnxn.ExecuteScalar<bool>("dbo.spMachineInterfaces_ValidateName",
                new { @Name = name },
                commandType: CommandType.StoredProcedure))
            {
                errorMessage += $"Machine interface with Id: {name} doesn't exists\n";
            }
            return errorMessage;
        }
        public bool ValidateMainClassId(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return cnxn.ExecuteScalar<bool>("dbo.spMainClasses_ValidateId",
                new { @Id = id },
                commandType: CommandType.StoredProcedure);
        }

        public string ValidateManufacturerName(string name)
        {
            string errorMessage = "";
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            if (!cnxn.ExecuteScalar<bool>("dbo.spManufacturers_ValidateName",
                new { @Name = name },
                commandType: CommandType.StoredProcedure))
            {
                errorMessage += $"Manufacturer with Name: {name} doesn't exists\n";
            }
            return errorMessage;
        }

        public string ValidateMaterial(string id)
        {
            string errorMessage = "";
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            if (!cnxn.ExecuteScalar<bool>("dbo.spMaterials_ValidateId",
                new { @Id = id },
                commandType: CommandType.StoredProcedure))
            {
                errorMessage += $"Manufacturer with Id: {id} doesn't exists\n";
            }
            return errorMessage;
        }

        public bool ValidateToolClassId(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return cnxn.ExecuteScalar<bool>("dbo.spToolClasses_ValidateId",
                new { @Id = id },
                commandType: CommandType.StoredProcedure);
        }

        public string ValidateToolComponents(List<ToolComponentModel> components)
        {
            string errorMessage = string.Empty;
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            foreach (ToolComponentModel c in components)
            {
                if (!ValidateCompId(c.BasicComp.Id))
                {
                    errorMessage += $"Component {c.BasicComp.Id} doesn't exist!\n";
                }
            }
            return errorMessage;
        }

        public bool ValidateToolGroupIdInClass(string id, string toolClassId)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            DynamicParameters dp = new();
            dp.Add("@Id", id);
            dp.Add("@ToolClassId", toolClassId);
            return cnxn.ExecuteScalar<bool>("dbo.spToolGroups_ValidateIdToolClassId",
                dp,
                commandType: CommandType.StoredProcedure);
        }

        public bool ValidateToolId(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return cnxn.ExecuteScalar<bool>("dbo.spTools_ValidateId",
                new { @Id = id },
                commandType: CommandType.StoredProcedure);
        }

        public void DeleteMainClassById(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            cnxn.Execute("dbo.spMainClasses_DeleteById", new { @Id = id }, commandType: CommandType.StoredProcedure);
        }

        public ToolGroupModel GetToolGroupByIdToolClassId(string id, string toolClassId)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return cnxn.Query<ToolGroupModel>("dbo.spToolGroups_GetById", new { @Id = id, @ToolClassId = toolClassId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public int GetToolClassParameterNextPositionByToolClassId(string toolClassId)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return cnxn.Query<int>("dbo.spToolClassParameters_GetNextPositionByToolClassId", new { @ToolClassId = toolClassId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public void UnallocateToolClasses(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            cnxn.Execute("dbo.spToolClasses_DeleteMainClassByMainClassId", new { @MainClassId = id }, commandType: CommandType.StoredProcedure);
        }

        public List<BasicCompModel> GetBasicCompModels()
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return cnxn.Query<BasicCompModel>("dbo.spComps_GetBasicData", commandType: CommandType.StoredProcedure).ToList();
        }

        public List<BasicToolModel> GetBasicToolModels()
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return cnxn.Query<BasicToolModel>("dbo.spTools_GetBasicData", commandType: CommandType.StoredProcedure).ToList();
        }

        public List<BasicListModel> GetBasicListModels()
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return cnxn.Query<BasicListModel>("dbo.spLists_GetBasicData", commandType: CommandType.StoredProcedure).ToList();
        }

        public List<BasicToolClassModel> GetBasicToolClassModels()
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return cnxn.Query<BasicToolClassModel>("dbo.spToolClasses_GetBasicData", commandType: CommandType.StoredProcedure).ToList();
        }
        public List<BasicToolGroupModel> GetBasicToolGroupsModels()
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return cnxn.Query<BasicToolGroupModel>("dbo.spToolGroups_GetBasicData", commandType: CommandType.StoredProcedure).ToList();
        }
        public List<BasicMainClassModel> GetBasicMainClassModels()
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return cnxn.Query<BasicMainClassModel>("dbo.spMainClasses_GetBasicData", commandType: CommandType.StoredProcedure).ToList();
        }

        public void DeleteToolGroupsByToolClassId(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            cnxn.Execute("dbo.spToolGroups_DeleteByToolClassId", new { @ToolClassId = id }, commandType: CommandType.StoredProcedure);
        }

        public void DeleteToolClassParametersByToolClassId(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            cnxn.Execute("dbo.spToolClassParameters_DeleteByToolClassId", new { @ToolClassId = id }, commandType: CommandType.StoredProcedure);
        }

        public void DeleteToolClassById(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            cnxn.Execute("dbo.spToolClasses_DeleteById", new { @Id = id }, commandType: CommandType.StoredProcedure);
        }

        public void DeleteToolGroupByIdToolClassId(string id, string toolClassId)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            cnxn.Execute("dbo.spToolGroups_DeleteById", new { @Id = id, @ToolClassId = toolClassId }, commandType: CommandType.StoredProcedure);
        }

        public List<ParameterModel> GetCompParametersById(string id)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return cnxn.Query<ParameterModel>("dbo.spGetCompParametersById",
                new { @CompId = id },
                commandType: CommandType.StoredProcedure)
                .ToList();
        }

        public List<ParameterModel> GetParametersByToolClassIdToolGroupId(string toolClassId, string toolGroupId)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return GetParametersByToolClassIdToolGroupId(toolClassId, toolGroupId, cnxn);
        }

        private static List<ParameterModel> GetParametersByToolClassIdToolGroupId(string toolClassId, string toolGroupId, IDbConnection cnxn)
        {
            DynamicParameters dp = new();
            dp.Add("@ToolClassId", toolClassId);
            dp.Add("@ToolGroupId", toolGroupId);
            return cnxn.Query<ParameterModel>("dbo.spGetParametersByToolClassIdToolGroupId",
                dp,
                commandType: CommandType.StoredProcedure)
                .ToList();
        }

        public void DeleteToolClassParameterByParameterIdToolClassId(string parameterId, string toolClassId)
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            DynamicParameters dp = new();
            dp.Add("@ParameterId", parameterId);
            dp.Add("@ToolClassId", toolClassId);
            // Delete all parameter values in comps and tools
            cnxn.Execute("dbo.spCompParameters_DeleteByToolClassIdParameterId", dp, commandType: CommandType.StoredProcedure);
            cnxn.Execute("dbo.spToolParameters_DeleteByToolClassIdParameterId", dp, commandType: CommandType.StoredProcedure);
            // Delete group allocation
            cnxn.Execute("dbo.ToolClassParameterGroups_DeleteByToolClassIdParameterId", dp, commandType: CommandType.StoredProcedure);
            // Delete parameter itself
            cnxn.Execute("dbo.ToolClassParameters_DeleteByParameterIdToolClassId", dp, commandType: CommandType.StoredProcedure);
        }

        public List<string> GetUsers()
        {
            using IDbConnection cnxn = new SqlConnection(GetConnectionString());
            return cnxn.Query<string>("dbo.spList_GetAllUsers", commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
