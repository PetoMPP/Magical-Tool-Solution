using System;
using System.Collections.Generic;
using System.Text;

namespace MTSLibrary.Models
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
        public List<ListPositionModel> ListPositions { get; set; }
    }
}
