using MTSLibrary.Models.Lists;
using System.Linq;

namespace MTSLibrary.Validation
{
    public class ListValidation
    {
        public static string ValidateModel(ListModel list, CreatingType creatingType)
        {
            string errorMessage = "";
            if (list.Id == "")
            {
                return "Id field cannot be empty!\n";
            }
            if (list.Description1 == "")
            {
                return "Description 1 field cannot be empty!\n";
            }
            if (creatingType == CreatingType.Creating)
            {
                if (GlobalConfig.Connection.ValidateListId(list.Id))
                {
                    errorMessage += $"Id: {list.Id} exists in the Database!\n";
                }
            }
            else if (creatingType == CreatingType.Updating)
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
            if (list.ListPositions.ToList().Count != 0)
            {
                errorMessage += GlobalConfig.Connection.ValidateListPositions(list.ListPositions);
            }

            return errorMessage;
        }
    }
}
