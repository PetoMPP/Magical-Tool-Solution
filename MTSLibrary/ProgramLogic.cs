﻿using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace MTSLibrary
{
    public class ProgramLogic
    {
        public static List<ProgramSectionModel> GetProgramSections()
        {
            List<ProgramSectionModel> output = new();
            ProgramSectionModel section = new();
            string[] moduleNames;

            section.Name = "Basic Tool Data";
            moduleNames = new string[] { "Components Data", "Tool Data", "Tool List Data" };
            section.AvailableModules = GenerateModulesFromStrings(moduleNames);
            output.Add(section);

            section = new ProgramSectionModel();

            section.Name = "Stock Management";
            moduleNames = new string[] { "Manage Stock Locations", "Basic Stock Operations", "Ensure List On Machine" };
            section.AvailableModules = GenerateModulesFromStrings(moduleNames);
            output.Add(section);

            section = new ProgramSectionModel();

            section.Name = "Tool Stock Calculations";
            moduleNames = new string[] { "Missing Stock Calculator", "Minimal Stock Calculator" };
            section.AvailableModules = GenerateModulesFromStrings(moduleNames);
            output.Add(section);

            section = new ProgramSectionModel();

            section.Name = "Configuration";
            moduleNames = new string[] { "Tool Classes and Groups", "Main Classes Configuration", "Database Configuration" };
            section.AvailableModules = GenerateModulesFromStrings(moduleNames);
            output.Add(section);

            return output;
        }
        private static List<ProgramModuleModel> GenerateModulesFromStrings(string[] strings)
        {
            List<ProgramModuleModel> output = new();
            foreach (string str in strings)
            {
                ProgramModuleModel model = new();
                model.Name = str;
                output.Add(model);
            }
            return output;
        }
        public static DataTable CreateDataTableFromListOfModels<T>(IEnumerable<T> models)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();

            DataTable table = new(typeof(T).FullName);
            foreach (PropertyInfo info in properties)
            {
                table.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }
            foreach (T entity in models)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }
                table.Rows.Add(values);
            }
            return table;
        }
        #region Data validation
        public static string ValidateListModel(ListModel list, CreatingType creatingType)
        {
            string errorMessage = "";
            if (list.Id == "")
            {
                errorMessage += "Id field cannot be empty!\n";
            }
            if (creatingType == CreatingType.creating)
            {
                if (GlobalConfig.Connection.ValidateListId(list.Id))
                {
                    errorMessage += $"Id: {list.Id} exists in the Database!\n";
                }
            }
            else if (creatingType == CreatingType.updating)
            {
                if (!GlobalConfig.Connection.ValidateListId(list.Id))
                {
                    errorMessage += $"Id: {list.Id} doesn't exists in the Database!\n";
                }
            }
            // Validate machine and machine group
            if (!(list.MachineId == "" && list.MachineGroupId == ""))
            {
                errorMessage += GlobalConfig.Connection.ValidateMachine(list.MachineId, list.MachineGroupId);
            }
            // Validate material
            if (list.MaterialId != "")
            {
                errorMessage += GlobalConfig.Connection.ValidateMaterial(list.MaterialId);
            }
            // Validate Tools
            if (list.ListPositions.Count != 0)
            {
                errorMessage += GlobalConfig.Connection.ValidateListPositions(list.ListPositions);
            }

            return errorMessage;
        }
        public static string ValidateToolModel(ToolModel tool, CreatingType creatingType)
        {
            string errorMessage = "";
            if (tool.Id == "")
            {
                errorMessage += "Id field cannot be empty!\n";
            }
            if (creatingType == CreatingType.creating)
            {
                if (GlobalConfig.Connection.ValidateToolId(tool.Id))
                {
                    errorMessage += $"Id: {tool.Id} exists in the Database!\n";
                }
            }
            else if (creatingType == CreatingType.updating)
            {
                if (!GlobalConfig.Connection.ValidateToolId(tool.Id))
                {
                    errorMessage += $"Id: {tool.Id} doesn't exists in the Database!\n";
                }
            }
            // Validate CLGR in db
            errorMessage += GlobalConfig.Connection.ValidateClassGroupId(tool.ToolClassId, tool.ToolGroupId);
            // Validate machine interface
            if (tool.MachineInterfaceId != "")
            {
                errorMessage += GlobalConfig.Connection.ValidateMachineInterfaceId(tool.MachineInterfaceId);
            }
            // tools and list validate positions (probably obsolete)
            errorMessage += GlobalConfig.Connection.ValidateToolComponents(tool.Components);
            return errorMessage;
        }
        public static string ValidateCompModel(CompModel comp, CreatingType creatingType)
        {
            string errorMessage = "";
            if (comp.Id == "")
            {
                // Without Id all next checks are broken
                return "Id field cannot be empty!\n";
            }
            if (creatingType == CreatingType.creating)
            {
                if (GlobalConfig.Connection.ValidateCompId(comp.Id))
                {
                    errorMessage += $"Id: {comp.Id} already in use!";
                }
            }
            else if (creatingType == CreatingType.updating)
            {
                if (!GlobalConfig.Connection.ValidateCompId(comp.Id))
                {
                    errorMessage += $"Id: {comp.Id} does not exist in database";
                }
            }
            // Validate CLGR in db
            errorMessage += GlobalConfig.Connection.ValidateClassGroupId(comp.ToolClassId, comp.ToolGroupId);
            // Validate Manufacturer
            if (comp.ManufacturerName != "")
            {
                errorMessage += GlobalConfig.Connection.ValidateManufacturerName(comp.ManufacturerName);
            }
            return errorMessage;
        }
        #endregion
    }
}
