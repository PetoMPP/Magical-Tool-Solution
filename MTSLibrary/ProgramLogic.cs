using MTSLibrary.Models.ProgramDataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace MTSLibrary
{
    public class ProgramLogic
    {
        public static List<ProgramSectionModel> GetProgramSections()
        {
            List<ProgramSectionModel> output = new();
            ProgramSectionModel section = new();
            string[] moduleNames;

            section.Name = "Tool Data";
            moduleNames = new string[] { "Components Data", "Tool Data", "Tool List Data" };
            section.AvailableModules = GenerateModulesFromStrings(moduleNames);
            output.Add(section);

            section = new();

            section.Name = "Environment Configuration";
            moduleNames = new string[] { "Manufacturers and Suppliers", "Data Statuses", "Machines and Machine Groups", "Component Connections", "Machine Interfaces", "Manufactured Materials" };
            section.AvailableModules = GenerateModulesFromStrings(moduleNames);
            output.Add(section);

            section = new();

            section.Name = "Stock Management";
            moduleNames = new string[] { "Manage Stock Locations", "Basic Stock Operations", "Ensure List On Machine" };
            section.AvailableModules = GenerateModulesFromStrings(moduleNames);
            output.Add(section);

            section = new();

            section.Name = "Configuration";
            moduleNames = new string[] { "Tool Classes and Groups", "Main Classes Configuration", "Database Configuration", "Global System Settings" };
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

        public static DataTable CreateSimpleDataTable<T>(List<T> models)
        {
            Type type = typeof(T);
            DataTable table = new("name");
            table.Columns.Add(new DataColumn("Id", Nullable.GetUnderlyingType(type) ?? type));
            foreach (T model in models)
            {
                table.Rows.Add(model);
            }
            return table;
        }
    }
}
