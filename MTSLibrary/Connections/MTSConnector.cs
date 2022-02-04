using Dapper;
using Dapper.FluentMap;
using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace MTSLibrary.Connections
{
    public class MTSConnector : IDataConnection
    {
        // TODO - Move error strings to Program Logic Class
        private static string GetConnectionString() =>
            ConfigurationManager.ConnectionStrings["MTSDatabase"].ConnectionString;
        private static int GetBitValueFromBool(bool boolean) => boolean == true ? 1 : 0;
        
        public void CreateClGrParameter(ToolClassParameterModel model)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // insert basic data
            DynamicParameters dp = new();
            dp.Add("@Id", model.Id);
            dp.Add("@ToolClassId", model.ToolClassId);
            dp.Add("@Position", model.Position);
            dp.Add("@Name", model.Name);
            dp.Add("@Description", model.Description);
            dp.Add("@DataValueType", model.DataValueType);
            cnxn.Execute("dbo.spToolClassParameters_Insert", dp, commandType: CommandType.StoredProcedure);
            // insert allocated groups
            if (model.AssignedGroupsIds != null)
            {
                foreach (string groupId in model.AssignedGroupsIds)
                {
                    dp = new();
                    dp.Add("@ToolClassId", model.ToolClassId);
                    dp.Add("@ParameterId", model.Id);
                    dp.Add("@ToolGroupId", groupId);
                    cnxn.Execute("dbo.spToolClassParameterGroups_Insert", dp, commandType: CommandType.StoredProcedure);
                } 
            }
        }

        public void CreateComp(CompModel comp)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // insert basic data
            DynamicParameters dp = new();
            dp.Add("@Id", comp.Id);
            dp.Add("@Description1", comp.Description1);
            if (!string.IsNullOrWhiteSpace(comp.Description2))
            {
                dp.Add("@Description2", comp.Description2); 
            }
            dp.Add("@ToolClassId", comp.ToolClassId);
            dp.Add("@ToolGroupId", comp.ToolGroupId);
            if (!string.IsNullOrWhiteSpace(comp.ManufacturerName))
            {
                dp.Add("@ManufacturerName", comp.ManufacturerName); 
            }
            if (!string.IsNullOrWhiteSpace(comp.DataStatus))
            {
                dp.Add("@DataStatus", comp.DataStatus); 
            }
            cnxn.Execute("dbo.spComps_Insert", dp, commandType: CommandType.StoredProcedure);
            // insert suitability
            if (comp.Suitability != null)
            {
                dp = new();
                dp.Add("@CompId", comp.Id);
                dp.Add("@PSuitability", comp.Suitability.PSuitability);
                dp.Add("@MSuitability", comp.Suitability.MSuitability);
                dp.Add("@KSuitability", comp.Suitability.KSuitability);
                dp.Add("@NSuitability", comp.Suitability.NSuitability);
                dp.Add("@SSuitability", comp.Suitability.SSuitability);
                dp.Add("@HSuitability", comp.Suitability.HSuitability);
                cnxn.Execute("dbo.spCompSuitability_Insert", dp, commandType: CommandType.StoredProcedure); 
            }
            // insert parameters
            if (comp.Parameters != null)
            {
                foreach (ParameterModel pm in comp.Parameters)
                {
                    dp = new();
                    dp.Add("@CompId", comp.Id);
                    dp.Add("@ParameterId", pm.ParameterId);
                    // determine type
                    if (pm.DataValueType == DataValueType.Text)
                    {
                        dp.Add("@TextValue", pm.TextValue);
                        dp.Add("@NumericValue", null);
                    }
                    else
                    {
                        dp.Add("@TextValue", null);
                        dp.Add("@NumericValue", pm.NumericValue);
                    }
                    cnxn.Execute("dbo.spCompParameters_Insert", dp, commandType: CommandType.StoredProcedure);
                } 
            }
        }

        public void CreateList(ListModel list)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // insert basic data
            DynamicParameters dp = new();
            dp.Add("@Id", list.Id);
            dp.Add("@Description1", list.Description1);
            if (!string.IsNullOrWhiteSpace(list.Description2))
            {
                dp.Add("@Description2", list.Description2); 
            }
            if (!string.IsNullOrWhiteSpace(list.MachineId))
            {
                dp.Add("@MachineId", list.MachineId); 
            }
            if (!string.IsNullOrWhiteSpace(list.MachineGroupId))
            {
                dp.Add("@MachineGroupId", list.MachineGroupId);
            }
            if (!string.IsNullOrWhiteSpace(list.MaterialId))
            {
                dp.Add("@MaterialId", list.MaterialId);
            }
            if (!string.IsNullOrWhiteSpace(list.DataStatus))
            {
                dp.Add("@DataStatus", list.DataStatus);
            }
            if (!string.IsNullOrWhiteSpace(list.CreatorName))
            {
                dp.Add("@CreatorName", list.CreatorName);
            }
            if (!string.IsNullOrWhiteSpace(list.LastModifiedName))
            {
                dp.Add("@LastModifiedName", list.LastModifiedName);
            }
            if (!string.IsNullOrWhiteSpace(list.OwnerName))
            {
                dp.Add("@OwnerName", list.OwnerName);
            }
            cnxn.Execute("dbo.spLists_Insert", dp, commandType: CommandType.StoredProcedure);
            // insert list positions
            if (list.ListPositions != null)
            {
                foreach (ListPositionModel lp in list.ListPositions)
                {
                    dp = new();
                    dp.Add("@ListId", list.Id);
                    dp.Add("@Position", lp.Position);
                    // determine position type
                    if (lp.BasicComp != null)
                    {
                        dp.Add("@CompId", lp.BasicComp.Id);
                        dp.Add("@ToolId", null);
                    }
                    else
                    {
                        dp.Add("@CompId", null);
                        dp.Add("@ToolId", lp.BasicTool.Id);
                    }
                    dp.Add("@Quantity", lp.Quantity);
                    cnxn.Execute("dbo.spListPositions_Insert", dp, commandType: CommandType.StoredProcedure);
                } 
            }
        }

        public void CreateMainClass(MainClassModel model)
        {
            // TODO - Make basic main class model class for this sp
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // insert basic data
            DynamicParameters dp = new();
            dp.Add("@Id", model.Id);
            dp.Add("@Name", model.Name);
            cnxn.Execute("dbo.spMainClasses_Insert", dp, commandType: CommandType.StoredProcedure);
            // UI doesnt provide ToolClasses for this command
        }

        public void CreateTool(ToolModel tool)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // insert basic data
            DynamicParameters dp = new();
            dp.Add("@Id", tool.Id);
            dp.Add("@Description1", tool.Description1);
            if (!string.IsNullOrWhiteSpace(tool.Description2))
            {
                dp.Add("@Description2", tool.Description2); 
            }
            dp.Add("@ToolClassId", tool.ToolClassId);
            dp.Add("@ToolGroupId", tool.ToolGroupId);
            if (!string.IsNullOrWhiteSpace(tool.MachineInterfaceId))
            {
                dp.Add("@MachineInterfaceId", tool.MachineInterfaceId); 
            }
            if (!string.IsNullOrWhiteSpace(tool.DataStatus))
            {
                dp.Add("@DataStatus", tool.DataStatus);
            }
            cnxn.Execute("dbo.spTools_Insert", dp, commandType: CommandType.StoredProcedure);
            // insert suitability
            if (tool.Suitability != null)
            {
                dp = new();
                dp.Add("@ToolId", tool.Id);
                dp.Add("@PSuitability", tool.Suitability.PSuitability);
                dp.Add("@MSuitability", tool.Suitability.MSuitability);
                dp.Add("@KSuitability", tool.Suitability.KSuitability);
                dp.Add("@NSuitability", tool.Suitability.NSuitability);
                dp.Add("@SSuitability", tool.Suitability.SSuitability);
                dp.Add("@HSuitability", tool.Suitability.HSuitability);
                cnxn.Execute("dbo.spToolSuitability_Insert", dp, commandType: CommandType.StoredProcedure); 
            }
            // insert parameters
            foreach (ParameterModel pm in tool.Parameters)
            {

                dp = new();
                dp.Add("@ToolId", tool.Id);
                dp.Add("@ParameterId", pm.ParameterId);
                // determine type
                if (pm.DataValueType == DataValueType.Text)
                {
                    dp.Add("@TextValue", pm.TextValue);
                    dp.Add("@NumericValue", null);
                }
                else
                {
                    dp.Add("@TextValue", null);
                    dp.Add("@NumericValue", pm.NumericValue);
                }
                cnxn.Execute("dbo.spToolParameters_Insert", dp, commandType: CommandType.StoredProcedure);
            }
            // insert components
            if (tool.Components != null)
            {
                foreach (ToolComponentModel tc in tool.Components)
                {
                    dp = new();
                    dp.Add("@ToolId", tool.Id);
                    dp.Add("@CompId", tc.BasicComp.Id);
                    dp.Add("@Quantity", tc.Quantity);
                    dp.Add("@Position", tc.Position);
                    dp.Add("@IsKey", GetBitValueFromBool(tc.IsKey));
                    cnxn.Execute("dbo.spToolComponents_Insert", dp, commandType: CommandType.StoredProcedure);
                }
            }
        }

        public void CreateToolClass(ToolClassModel model)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // insert basic data
            DynamicParameters dp = new();
            dp.Add("@Id", model.Id);
            dp.Add("@Name", model.Name);
            dp.Add("@MainClassId", model.MainClassId);
            cnxn.Execute("dbo.spToolClasses_Insert", dp, commandType: CommandType.StoredProcedure);
        }

        public void CreateToolGroup(ToolGroupModel model)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // insert basic data
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
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // delete parameters
            cnxn.Execute("dbo.spCompParameters_DeleteByCompId", new { @CompId = id }, commandType: CommandType.StoredProcedure);
            // delete suitability
            cnxn.Execute("dbo.spCompSuitability_DeleteByCompId", new { @CompId = id }, commandType: CommandType.StoredProcedure);
            // delete basic data
            cnxn.Execute("dbo.spComps_DeleteById", new { @Id = id }, commandType: CommandType.StoredProcedure);
        }

        public void DeleteListById(string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // delete positions
            cnxn.Execute("dbo.spListPositions_DeleteByListId", new { @ListId = id }, commandType: CommandType.StoredProcedure);
            // delete basic data
            cnxn.Execute("dbo.spLists_DeleteById", new { @Id = id }, commandType: CommandType.StoredProcedure);
        }

        public void DeleteToolById(string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // delete suitability
            cnxn.Execute("dbo.spToolSuitability_DeleteByToolId", new { @ToolId = id }, commandType: CommandType.StoredProcedure);
            // delete parameters
            cnxn.Execute("dbo.spToolParameters_DeleteByToolId", new { @ToolId = id }, commandType: CommandType.StoredProcedure);
            // delete components
            cnxn.Execute("dbo.spToolComponents_DeleteByToolId", new { @ToolId = id }, commandType: CommandType.StoredProcedure);
            // delete basic data
            cnxn.Execute("dbo.spTools_DeleteById", new { @Id = id }, commandType: CommandType.StoredProcedure);
        }

        public BasicCompModel GetBasicCompModelById(string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.Query<BasicCompModel>("dbo.spComps_GetBasicDataById", new { @Id = id }, commandType: CommandType.StoredProcedure).First();
        }

        public BasicToolModel GetBasicToolModelById(string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.Query<BasicToolModel>("dbo.spTools_GetBasicDataById", new { @Id = id }, commandType: CommandType.StoredProcedure).First();
        }

        public List<ToolClassModel> GetToolClassesList()
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // TODO - 2 stored procedures for tool classes
            // 1 - id name main class id
            List<ToolClassModel> models = cnxn.Query<ToolClassModel>("dbo.spToolClasses_GetAll", commandType: CommandType.StoredProcedure).ToList();
            List<ToolClassParameterModel> clgrParameters = new();
            foreach (ToolClassModel model in models)
            {
                model.ToolGroups = cnxn.Query<ToolGroupModel>
                    ("dbo.spToolGroups_GetByToolClassId",
                    new { @ToolClassId = model.Id },
                    commandType: CommandType.StoredProcedure)
                    .ToList();
                model.ToolClassParameters = cnxn.Query<ToolClassParameterModel>
                    ("dbo.spToolClassParameters_GetByToolClassId",
                    new { @ToolClassId = model.Id },
                    commandType: CommandType.StoredProcedure)
                    .ToList();
                foreach (ToolClassParameterModel tcpm in model.ToolClassParameters)
                {
                    tcpm.AssignedGroupsIds = cnxn.Query<string>
                        ("dbo.spToolClassParameterGroups_GetToolGroupIdsByToolClassIdParameterId",
                        new { @ToolClassId = model.Id, @ParameterId = tcpm.Id },
                        commandType: CommandType.StoredProcedure)
                        .ToList();
                }
            }
            return models;
        }
        public ToolClassModel GetToolClassById(string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // TODO - 2 stored procedures for tool classes
            // 1 - id name main class id
            ToolClassModel model = cnxn.Query<ToolClassModel>("dbo.spToolClasses_GetById", new { @Id = id }, commandType: CommandType.StoredProcedure).First();
            List<ToolClassParameterModel> clgrParameters = new();
            model.ToolGroups = cnxn.Query<ToolGroupModel>
                    ("dbo.spToolGroups_GetByToolClassId",
                    new { @ToolClassId = model.Id },
                    commandType: CommandType.StoredProcedure)
                    .ToList();
            model.ToolClassParameters = cnxn.Query<ToolClassParameterModel>
                ("dbo.spToolClassParameters_GetByToolClassId",
                new { @ToolClassId = model.Id },
                commandType: CommandType.StoredProcedure)
                .ToList();
            foreach (ToolClassParameterModel tcpm in model.ToolClassParameters)
            {
                tcpm.AssignedGroupsIds = cnxn.Query<string>
                    ("dbo.spToolClassParameterGroups_GetToolGroupIdsByToolClassIdParameterId",
                    new { @ToolClassId = model.Id, @ParameterId = tcpm.Id },
                    commandType: CommandType.StoredProcedure)
                    .ToList();
            }
            return model;
        }

        public string GetClassNameById(string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.Query<string>("dbo.spToolClasses_GetNameById", new { @Id = id }, commandType: CommandType.StoredProcedure).First();
        }

        public CompModel GetCompModelById(string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // get basic data
            CompModel model = cnxn.Query<CompModel>("dbo.spComps_GetById", new { @Id = id }, commandType: CommandType.StoredProcedure).First();
            // get suitability
            model.Suitability = cnxn.Query<SuitabilityModel>(
                "dbo.spCompSuitability_GetByCompId",
                new { @CompId = id },
                commandType: CommandType.StoredProcedure)
                .First();
            // TODO - Figure out joined tables for this query!
            // get parameters data from class
            // get parameters value from comps all in one stored procedure
            model.Parameters = cnxn.Query<ParameterModel>(
                "dbo.spGetCompParameters_ByCompIdToolClassId",
                new { @CompId = id, @ToolClassId = model.ToolClassId },
                commandType: CommandType.StoredProcedure)
                .ToList();

            return model;
        }

        public List<string> GetEnabledGroupsIdsByClassIdAndParameterId(string toolClassId, string parameterId)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.Query<string>("dbo.spToolClassParameterGroups_GetToolGroupIdsByToolClassIdParameterId",
                new { @ToolClassId = toolClassId, @ParameterId = parameterId },
                commandType: CommandType.StoredProcedure)
                .ToList();
        }

        public string GetToolGroupNameByIdToolClassId(string id, string toolClassId)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.Query<string>
                ("dbo.spToolGroups_GetNameById",
                new { @Id = id, @ToolClassId = toolClassId },
                commandType: CommandType.StoredProcedure)
                .First();
        }

        public ListModel GetListModelById(string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // get basic data
            ListModel model = cnxn.Query<ListModel>("dbo.spLists_GetById", new { @Id = id }, commandType: CommandType.StoredProcedure).First();
            // get list positions
            model.ListPositions = GetListPositionsByListId(id, cnxn);
            return model;
        }

        private List<ListPositionModel> GetListPositionsByListId(string id, IDbConnection cnxn)
        {
            // List of ListPositions with ListId, Position and Quantity
            List<ListPositionModel> output = cnxn.Query<ListPositionModel>
                ("dbo.spListPositions_GetByListId",
                new { @ListId = id },
                commandType: CommandType.StoredProcedure)
                .ToList();
            string compId;
            string toolId;
            // Add Basic Comps/Tools to models
            foreach (ListPositionModel lp in output)
            {
                compId = cnxn.Query<string>("dbo.spListPositions_GetCompIdByListIdPosition",
                new { @ListId = id , @Position = lp.Position},
                commandType: CommandType.StoredProcedure)
                .First();
                toolId = cnxn.Query<string>("dbo.spListPositions_GetToolIdByListIdPosition",
                new { @ListId = id, @Position = lp.Position },
                commandType: CommandType.StoredProcedure)
                .First();
                if (compId != null)
                {
                    lp.BasicComp = GetBasicCompModelById(compId);
                }
                else
                {
                    lp.BasicTool = GetBasicToolModelById(toolId);
                }
            }
            return output;
        }

        public List<MainClassModel> GetMainClassesList()
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            List<MainClassModel> models = cnxn.Query<MainClassModel>
                ("dbo.spMainClasses_GetAll",
                commandType: CommandType.StoredProcedure)
                .ToList();
            foreach (MainClassModel model in models)
            {
                List<string> tcIds = cnxn.Query<string>
                    ("dbo.spToolClasses_GetIdsByMainClassId",
                    new { @MainClassId = model.Id },
                    commandType: CommandType.StoredProcedure)
                    .ToList();
                model.ToolClasses = new();
                foreach (string id in tcIds)
                {
                    model.ToolClasses.Add(GetToolClassById(id));
                }
            }
            return models;
        }

        public string GetMainClassNameById(string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.Query<string>("dbo.spMainClasses_GetNameById", new { @Id = id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public string GetManufacturerIdByName(string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.Query<string>("dbo.spManufacturers_GetNameById", new { @Id = id }, commandType: CommandType.StoredProcedure).First();
        }

        public ToolModel GetToolModelById(string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // get basic data
            ToolModel model = cnxn.Query<ToolModel>("dbo.spTools_GetById", new { @Id = id }, commandType: CommandType.StoredProcedure).First();
            // get suitability
            model.Suitability = cnxn.Query<SuitabilityModel>(
                "dbo.spToolSuitability_GetByToolId",
                new { @ToolId = id },
                commandType: CommandType.StoredProcedure)
                .First();
            // TODO - Figure out joined tables for this query!
            // get parameters data from class
            // get parameters value from comps all in one stored procedure
            model.Parameters = cnxn.Query<ParameterModel>(
                "dbo.spGetToolParameters_ByCompIdToolClassId",
                new { @ToolId = id, @ToolClassId = model.ToolClassId },
                commandType: CommandType.StoredProcedure)
                .ToList();
            // get list of comps without compmodel
            List<ToolComponentModel> tcs = cnxn.Query<ToolComponentModel>(
                "dbo.spToolComponents_GetByToolId",
                new { @ToolId = id },
                commandType: CommandType.StoredProcedure)
                .ToList();
            // get comp model for every component
            foreach (ToolComponentModel tc in tcs)
            {
                tc.BasicComp = GetBasicCompModelById(GetCompIdByToolIdPosition(id, cnxn, tc));
            }
            model.Components = tcs;
            return model;
        }

        private static string GetCompIdByToolIdPosition(string toolId, IDbConnection cnxn, ToolComponentModel toolComponent)
        {
            return cnxn.Query<string>("dbo.spToolComponents_GetCompIdByToolIdPosition",
                            new { @ToolId = toolId, @Position = toolComponent.Position },
                            commandType: CommandType.StoredProcedure)
                            .First();
        }

        public List<ToolClassModel> GetUnallocatedToolClasses() =>
            GetToolClassesList().Where(tc => string.IsNullOrWhiteSpace(tc.MainClassId)).ToList();

        public List<string> GetDataValueTypes()
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.Query<string>("dbo.spDataValueTypes_GetAll",
                commandType: CommandType.StoredProcedure)
                .ToList();
        }

        public void SetMainClassIdById(string mainClassId, string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            cnxn.Execute("dbo.spToolClasses_UpdateMainClassIdById",
                new { @MainClassId = mainClassId, @Id = id },
                commandType: CommandType.StoredProcedure);
        }

        public void UpdateToolClassParameter(ToolClassParameterModel model)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // update basic data
            DynamicParameters dp = new();
            dp.Add("@Id", model.Id);
            dp.Add("@ToolClassId", model.ToolClassId);
            dp.Add("@Position", model.Position);
            dp.Add("@Name", model.Name);
            dp.Add("@Description", model.Description);
            dp.Add("@DataValueType", model.DataValueType);
            cnxn.Execute("dbo.spToolClassParameters_UpdateById", dp, commandType: CommandType.StoredProcedure);
            // get assigned groups from db
            
            List<string> currentGroupIds = GetEnabledGroupsIdsByClassIdAndParameterId(model.ToolClassId, model.Id);
            // insert new
            List<string> missingGroupIds = model.AssignedGroupsIds.Except(currentGroupIds).ToList();
            foreach (string groupId in missingGroupIds)
            {
                dp = new();
                dp.Add("@ToolClassId", model.ToolClassId);
                dp.Add("@ParameterId", model.Id);
                dp.Add("@ToolGroupId", groupId);
                cnxn.Execute("dbo.spToolClassParameterGroups_Insert",
                    dp,
                    commandType: CommandType.StoredProcedure);
            }
            // delete unused
            List<string> obsoleteGroupIds = currentGroupIds.Except(model.AssignedGroupsIds).ToList();
            foreach (string groupId in obsoleteGroupIds)
            {
                dp = new();
                dp.Add("@ToolClassId", model.ToolClassId);
                dp.Add("@ParameterId", model.Id);
                dp.Add("@ToolGroupId", groupId);
                cnxn.Execute("dbo.spToolClassParameterGroups_DeleteByToolClassIdParameterIdToolGroupId",
                    dp,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateComp(CompModel model)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // update basic data
            DynamicParameters dp = new();
            dp.Add("@Id", model.Id);
            dp.Add("@Description1", model.Description1);
            if (!string.IsNullOrWhiteSpace(model.Description2))
            {
                dp.Add("@Description2", model.Description2); 
            }
            dp.Add("@ToolClassId", model.ToolClassId);
            dp.Add("@ToolGroupId", model.ToolGroupId);
            if (!string.IsNullOrWhiteSpace(model.ManufacturerName))
            {
                dp.Add("@ManufacturerName", model.ManufacturerName); 
            }
            if (!string.IsNullOrWhiteSpace(model.DataStatus))
            {
                dp.Add("@DataStatus", model.DataStatus);
            }
            cnxn.Execute("dbo.spComps_UpdateById", dp, commandType: CommandType.StoredProcedure);
            // update suitability
            dp = new();
            dp.Add("@CompId", model.Id);
            dp.Add("@PSuitability", model.Suitability.PSuitability);
            dp.Add("@MSuitability", model.Suitability.MSuitability);
            dp.Add("@KSuitability", model.Suitability.KSuitability);
            dp.Add("@NSuitability", model.Suitability.NSuitability);
            dp.Add("@SSuitability", model.Suitability.SSuitability);
            dp.Add("@HSuitability", model.Suitability.HSuitability);
            cnxn.Execute("dbo.spCompSuitability_UpdateById", dp, commandType: CommandType.StoredProcedure);
            // update parameter values
            if (model.Parameters != null)
            {
                foreach (ParameterModel p in model.Parameters)
                {
                    dp = new();
                    dp.Add("@Id", model.Id);
                    dp.Add("@ParameterId", p.ParameterId);
                    dp.Add("@NumericValue", p.NumericValue);
                    dp.Add("@TextValue", p.TextValue);
                    cnxn.Execute("dbo.spCompParameters_UpdateById", dp, commandType: CommandType.StoredProcedure);
                } 
            }

        }

        public void UpdateList(ListModel model)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // update basic data
            DynamicParameters dp = new();
            dp.Add("@Id", model.Id);
            dp.Add("@Description1", model.Description1);
            if (!string.IsNullOrWhiteSpace(model.Description2))
            {
                dp.Add("@Description2", model.Description2); 
            }
            if (!string.IsNullOrWhiteSpace(model.MachineId))
            {
                dp.Add("@MachineId", model.MachineId);
            }
            if (!string.IsNullOrWhiteSpace(model.MachineGroupId))
            {
                dp.Add("@MachineGroupId", model.MachineGroupId); 
            }
            if (!string.IsNullOrWhiteSpace(model.MaterialId))
            {
                dp.Add("@MaterialId", model.MaterialId);
            }
            if (!string.IsNullOrWhiteSpace(model.DataStatus))
            {
                dp.Add("@DataStatus", model.DataStatus); 
            }
            if (!string.IsNullOrWhiteSpace(model.CreatorName))
            {
                dp.Add("@CreatorName", model.CreatorName);
            }
            if (!string.IsNullOrWhiteSpace(model.LastModifiedName))
            {
                dp.Add("@LastModifiedName", model.LastModifiedName);
            }
            if (!string.IsNullOrWhiteSpace(model.OwnerName))
            {
                dp.Add("@OwnerName", model.OwnerName); 
            }
            cnxn.Execute("dbo.spLists_UpdateById", dp, commandType: CommandType.StoredProcedure);
            // update positions
            // get current positions
            List<ListPositionModel> currentPositions = GetListPositionsByListId(model.Id, cnxn);
            // insert new
            List<ListPositionModel> newPositions = model.ListPositions.Except(currentPositions,
                new ListPositionModelPositionComparer())
                .ToList();
            foreach (ListPositionModel lp in newPositions)
            {
                dp = new();
                dp.Add("@ListId", model.Id);
                dp.Add("@Position", lp.Position);
                dp.Add("Quantity", lp.Quantity);
                if (lp.BasicComp != null)
                {
                    dp.Add("@CompId", lp.BasicComp.Id);
                }
                if (lp.BasicTool != null)
                {
                    dp.Add("@ToolId", lp.BasicTool.Id);
                }
                cnxn.Execute("dbo.spListPositions_Insert", dp, commandType: CommandType.StoredProcedure);
            }
            // update changed
            List<ListPositionModel> modifiedPositions = model.ListPositions.Except(currentPositions,
                new ListPositionModelComparer())
                .Except(newPositions)
                .ToList();
            foreach (ListPositionModel lp in modifiedPositions)
            {
                dp = new();
                dp.Add("@ListId", model.Id);
                dp.Add("@Position", lp.Position);
                if (lp.BasicComp != null)
                {
                    dp.Add("@CompId", lp.BasicComp.Id);
                }
                if (lp.BasicTool != null)
                {
                    dp.Add("@ToolId", lp.BasicTool.Id);
                }
                dp.Add("@Quantity", lp.Quantity);
                cnxn.Execute("dbo.spListPositions_Update", dp, commandType: CommandType.StoredProcedure);
            }
            // delete obsolete
            List<ListPositionModel> obsoletePositions = currentPositions.Except(model.ListPositions,
                new ListPositionModelPositionComparer()).ToList();
            foreach (ListPositionModel lp in obsoletePositions)
            {
                dp = new();
                dp.Add("@ListId", model.Id);
                dp.Add("@Position", lp.Position);
                cnxn.Execute("dbo.spListPositions_Delete", dp, commandType: CommandType.StoredProcedure);
            }

        }

        public void UpdateMainClass(MainClassModel model)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // this method is used only with model containing name and id
            // insert basic data
            cnxn.Execute("dbo.spMainClasses_Update", 
                new { @Id = model.Id, @Name = model.Name },
                commandType: CommandType.StoredProcedure);
        }

        public void UpdateTool(ToolModel model)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // update basic data
            DynamicParameters dp = new();
            dp.Add("@Id", model.Id);
            dp.Add("@Description1", model.Description1);
            if (!string.IsNullOrWhiteSpace(model.Description2))
            {
                dp.Add("@Description2", model.Description2); 
            }
            dp.Add("@ToolClassId", model.ToolClassId);
            dp.Add("@ToolGroupId", model.ToolGroupId);
            if (!string.IsNullOrWhiteSpace(model.MachineInterfaceId))
            {
                dp.Add("@MachineInterfaceId", model.MachineInterfaceId); 
            }
            if (!string.IsNullOrWhiteSpace(model.DataStatus))
            {
                dp.Add("@DataStatus", model.DataStatus);
            }
            cnxn.Execute("dbo.spTools_Update", dp, commandType: CommandType.StoredProcedure);
            // update suitability
            if (model.Suitability != null)
            {
                dp = new();
                dp.Add("@ToolId", model.Id);
                dp.Add("@PSuitability", model.Suitability.PSuitability);
                dp.Add("@MSuitability", model.Suitability.MSuitability);
                dp.Add("@KSuitability", model.Suitability.KSuitability);
                dp.Add("@NSuitability", model.Suitability.NSuitability);
                dp.Add("@SSuitability", model.Suitability.SSuitability);
                dp.Add("@HSuitability", model.Suitability.HSuitability);
                cnxn.Execute("dbo.spToolSuitability_Update", dp, commandType: CommandType.StoredProcedure);
            }
            else
            {
                cnxn.Execute("dbo.spToolSuitability_Delete", new { @ToolId = model.Id}, commandType: CommandType.StoredProcedure);
            }
            // update parameter values
            foreach (ParameterModel p in model.Parameters)
            {
                dp = new();
                dp.Add("@ToolId", model.Id);
                dp.Add("@ParameterId", p.ParameterId);
                dp.Add("@TextValue", p.TextValue);
                dp.Add("@NumericValue", p.NumericValue);
                cnxn.Execute("dbo.spToolParameters_Update", dp, commandType: CommandType.StoredProcedure);
            }
            List<ToolComponentModel> currentComponents = GetToolComponentsByToolId(model.Id, cnxn);
            foreach (ToolComponentModel tc in currentComponents)
            {
                tc.BasicComp = GetBasicCompModelById(GetCompIdByToolIdPosition(model.Id, cnxn, tc));
            }
            // insert new components
            List<ToolComponentModel> newComponents = model.Components.Except(currentComponents,
                new ToolComponentModelPositionComparer()).ToList();
            foreach (ToolComponentModel tc in newComponents)
            {
                dp = new();
                dp.Add("@ToolId", model.Id);
                dp.Add("@CompId", tc.BasicComp.Id);
                dp.Add("@Quantity", tc.Quantity);
                dp.Add("@Position", tc.Position);
                dp.Add("@IsKey", GetBitValueFromBool(tc.IsKey));
                cnxn.Execute("dbo.spToolComponents_Insert", dp, commandType: CommandType.StoredProcedure);
            }
            // update modified
            List<ToolComponentModel> modifiedComponents = model.Components.Except(currentComponents,
                new ToolComponentModelComparer())
                .Except(newComponents)
                .ToList();
            foreach (ToolComponentModel tc in modifiedComponents)
            {
                dp = new();
                dp.Add("@ToolId", model.Id);
                dp.Add("@CompId", tc.BasicComp.Id);
                dp.Add("@Quantity", tc.Quantity);
                dp.Add("@Position", tc.Position);
                dp.Add("@IsKey", GetBitValueFromBool(tc.IsKey));
                cnxn.Execute("dbo.spToolComponents_Update", dp, commandType: CommandType.StoredProcedure);
            }
            // delete obsolete
            List<ToolComponentModel> obsoleteComponents = currentComponents.Except(model.Components,
                new ToolComponentModelPositionComparer())
                .ToList();
            foreach (ToolComponentModel tc in obsoleteComponents)
            {
                dp = new();
                dp.Add("@ToolId", model.Id);
                dp.Add("@Position", tc.Position);
                cnxn.Execute("dbo.spToolComponents_Delete", dp, commandType: CommandType.StoredProcedure);
            }
        }

        private static List<ToolComponentModel> GetToolComponentsByToolId(string id, IDbConnection cnxn) =>
            cnxn.Query<ToolComponentModel>("dbo.spToolComponents_GetByToolId", new { @ToolId = id }, commandType: CommandType.StoredProcedure).ToList();

        public void UpdateToolClass(ToolClassModel model)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // update tool class basic data
            DynamicParameters dp = new();
            dp.Add("@Id", model.Id);
            dp.Add("@Name", model.Name);
            dp.Add("@MainClassId", model.MainClassId);
            cnxn.Execute("dbo.spToolClasses_Update", dp, commandType: CommandType.StoredProcedure);
        }

        public void UpdateToolGroup(ToolGroupModel model)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            // insert basic data
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
        public string ValidateClassGroupId(string toolClassId, string toolGroupId)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
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
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.ExecuteScalar<bool>("dbo.spComps_ValidateId",
                new { @Id = id},
                commandType: CommandType.StoredProcedure);
        }
        public bool ValidateListId(string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.ExecuteScalar<bool>("dbo.spLists_ValidateId",
                new { @Id = id},
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
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            if (!cnxn.ExecuteScalar<bool>("dbo.spMachines_ValidateId", new { @Id = machineId }, commandType: CommandType.StoredProcedure))
            {
                errorMessage += $"Machine with Id: {machineId} doesn't exist\n";
            }
            if (!cnxn.ExecuteScalar<bool>("dbo.spMachineGroups_ValidateId", new { @Id = machineGroupId}, commandType: CommandType.StoredProcedure))
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
        public string ValidateMachineInterfaceId(string id)
        {
            string errorMessage = "";
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            if (!cnxn.ExecuteScalar<bool>("dbo.spMachineInterfaces_ValidateId",
                new { @Id = id },
                commandType: CommandType.StoredProcedure))
            {
                errorMessage += $"Machine interface with Id: {id} doesn't exists\n";
            }
            return errorMessage;
        }
        public bool ValidateMainClassId(string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.ExecuteScalar<bool>("dbo.spMainClasses_ValidateId",
                new { @Id = id},
                commandType: CommandType.StoredProcedure);
        }

        public string ValidateManufacturerName(string name)
        {
            string errorMessage = "";
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
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
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
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
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.ExecuteScalar<bool>("dbo.spToolClasses_ValidateId",
                new { @Id = id},
                commandType: CommandType.StoredProcedure);
        }

        public string ValidateToolComponents(List<ToolComponentModel> components)
        {
            string errorMessage = string.Empty;
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
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
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            DynamicParameters dp = new();
            dp.Add("@Id", id);
            dp.Add("@ToolClassId", toolClassId);
            return cnxn.ExecuteScalar<bool>("dbo.spToolGroups_ValidateIdToolClassId",
                dp,
                commandType: CommandType.StoredProcedure);
        }

        public bool ValidateToolId(string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.ExecuteScalar<bool>("dbo.spTools_ValidateId",
                new { @Id = id },
                commandType: CommandType.StoredProcedure);
        }

        public void DeleteMainClassById(string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            cnxn.Execute("dbo.spMainClasses_DeleteById", new { @Id = id }, commandType: CommandType.StoredProcedure);
        }

        public ToolGroupModel GetToolGroupByIdToolClassId(string id, string toolClassId)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.Query<ToolGroupModel>("dbo.spToolGroups_GetById", new { @Id = id, @ToolClassId = toolClassId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public int GetToolClassParameterNextPositionByToolClassId(string toolClassId)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.Query<int>("dbo.spToolClassParameters_GetNextPositionByToolClassId", new { @ToolClassId = toolClassId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public void UnallocateToolClasses(string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            cnxn.Execute("dbo.spToolClasses_DeleteMainClassByMainClassId", new { @MainClassId = id }, commandType: CommandType.StoredProcedure);
        }

        public List<BasicCompModel> GetBasicCompModels()
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.Query<BasicCompModel>("dbo.spComps_GetBasicData", commandType: CommandType.StoredProcedure).ToList();
        }

        public List<BasicToolModel> GetBasicToolModels()
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.Query<BasicToolModel>("dbo.spTools_GetBasicData", commandType: CommandType.StoredProcedure).ToList();
        }

        public List<BasicListModel> GetBasicListModels()
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.Query<BasicListModel>("dbo.spLists_GetBasicData", commandType: CommandType.StoredProcedure).ToList();
        }

        public List<BasicToolClassModel> GetBasicToolClassModels() {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.Query<BasicToolClassModel>("dbo.spToolClasses_GetBasicData", commandType: CommandType.StoredProcedure).ToList();
        }
        public List<BasicToolGroupModel> GetBasicToolGroupsModels() {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.Query<BasicToolGroupModel>("dbo.spToolGroups_GetBasicData", commandType: CommandType.StoredProcedure).ToList();
        }
        public List<BasicMainClassModel> GetBasicMainClassModels() {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.Query<BasicMainClassModel>("dbo.spMainClasses_GetBasicData", commandType: CommandType.StoredProcedure).ToList();
        }

        public void DeleteToolGroupsByToolClassId(string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            cnxn.Execute("dbo.spToolGroups_DeleteByToolClassId", new { @ToolClassId = id }, commandType: CommandType.StoredProcedure);
        }

        public void DeleteToolClassParametersByToolClassId(string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            cnxn.Execute("dbo.spToolClassParameters_DeleteByToolClassId", new { @ToolClassId = id }, commandType: CommandType.StoredProcedure);
        }

        public void DeleteToolClassById(string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            cnxn.Execute("dbo.spToolClasses_DeleteById", new { @Id = id }, commandType: CommandType.StoredProcedure);
        }

        public void DeleteToolGroupByIdToolClassId(string id, string toolClassId)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            cnxn.Execute("dbo.spToolGroups_DeleteById", new { @Id = id , @ToolClassId = toolClassId }, commandType: CommandType.StoredProcedure);
        }

        public List<ParameterModel> GetCompParametersById(string id)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            return cnxn.Query<ParameterModel>("dbo.spGetCompParametersById",
                new { @CompId = id},
                commandType: CommandType.StoredProcedure)
                .ToList();
        }

        public List<ParameterModel> GetParametersByToolClassIdToolGroupId(string toolClassId, string toolGroupId)
        {
            using IDbConnection cnxn = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString());
            DynamicParameters dp = new();
            dp.Add("@ToolClassId", toolClassId);
            dp.Add("@ToolGroupId", toolGroupId);
            return cnxn.Query<ParameterModel>("dbo.spGetParametersByToolClassIdToolGroupId",
                dp,
                commandType: CommandType.StoredProcedure)
                .ToList();
        }
    }
}
