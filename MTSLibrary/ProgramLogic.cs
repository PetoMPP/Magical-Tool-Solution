using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTSLibrary
{
    public class ProgramLogic
    {
        public static List<ProgramSectionModel> GetProgramSections()
        {
            List<ProgramSectionModel> output = new List<ProgramSectionModel>();
            ProgramSectionModel section = new ProgramSectionModel();
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
            moduleNames = new string[] { "Tool Classes and Groups", "Database Configuration" };
            section.AvailableModules = GenerateModulesFromStrings(moduleNames);
            output.Add(section);

            return output;
        }
        private static List<ProgramModuleModel> GenerateModulesFromStrings(string[] strings)
        {
            List<ProgramModuleModel> output = new List<ProgramModuleModel>();
            foreach (string str in strings)
            {
                ProgramModuleModel model = new ProgramModuleModel();
                model.Name = str;
                output.Add(model);
            }
            return output;
        }
    }
}
