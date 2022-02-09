using MTSLibrary.Models;

namespace MTSLibrary.Validation
{
    public class CompValidation
    {
        public static string ValidateModel(CompModel comp, CreatingType creatingType)
        {
            string errorMessage = "";
            if (comp.Id == "")
            {
                // Without Id all next checks are broken
                return "Id field cannot be empty!\n";
            }
            if (comp.Description1 == "")
            {
                return "Description 1 field cannot be empty!\n";
            }
            if (creatingType == CreatingType.Creating)
            {
                if (GlobalConfig.Connection.ValidateCompId(comp.Id))
                {
                    errorMessage += $"Id: {comp.Id} already in use!";
                }
            }
            else if (creatingType == CreatingType.Updating)
            {
                if (!GlobalConfig.Connection.ValidateCompId(comp.Id))
                {
                    errorMessage += $"Id: {comp.Id} does not exist in database";
                }
            }
            // Validate CLGR in db
            errorMessage += GlobalConfig.Connection.ValidateToolClassIdToolGroupId(comp.ToolClassId, comp.ToolGroupId);
            // Validate Manufacturer
            if (!string.IsNullOrWhiteSpace(comp.ManufacturerName))
            {
                errorMessage += GlobalConfig.Connection.ValidateManufacturerName(comp.ManufacturerName);
            }
            // Validate Machine Interface
            if (!string.IsNullOrWhiteSpace(comp.MachineInterfaceName))
            {
                errorMessage += GlobalConfig.Connection.ValidateMachineInterfaceName(comp.MachineInterfaceName);
            }
            return errorMessage;
        }
    }
}
