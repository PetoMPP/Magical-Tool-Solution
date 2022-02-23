using MTSLibrary.Models.Tools;

namespace MTSLibrary.Validation
{
    public class ToolValidation
    {
        public static string ValidateModel(ToolModel tool, CreatingType creatingType)
        {
            string errorMessage = "";
            if (tool.Id == "")
            {
                return "Id field cannot be empty!\n";
            }
            if (tool.Description1 == "")
            {
                return "Description 1 field cannot be empty!\n";
            }
            if (creatingType == CreatingType.Creating)
            {
                if (GlobalConfig.Connection.ValidateToolId(tool.Id))
                {
                    errorMessage += $"Id: {tool.Id} exists in the Database!\n";
                }
            }
            else if (creatingType == CreatingType.Updating)
            {
                if (!GlobalConfig.Connection.ValidateToolId(tool.Id))
                {
                    errorMessage += $"Id: {tool.Id} doesn't exists in the Database!\n";
                }
            }
            errorMessage += GlobalConfig.Connection.ValidateToolClassIdToolGroupId(tool.ToolClassId, tool.ToolGroupId);
            if (tool.MachineInterfaceName != "")
            {
                errorMessage += GlobalConfig.Connection.ValidateMachineInterfaceName(tool.MachineInterfaceName);
            }
            // tools and list validate positions (probably obsolete)
            errorMessage += GlobalConfig.Connection.ValidateToolComponents(tool.Components);
            return errorMessage;
        }
    }
}
