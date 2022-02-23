using System.Collections.Generic;

namespace MTSLibrary.Models.Lists
{
    public class ListModel
    {
        public string Id { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string MachineId { get; set; }
        public string MachineGroupId { get; set; }
        public string MaterialId { get; set; }
        public string DataStatus { get; set; }
        public string CreatorName { get; set; }
        public string LastModifiedName { get; set; }
        public string OwnerName { get; set; }
        public IEnumerable<IListPositionModel> ListPositions { get; set; }
    }
}
