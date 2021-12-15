using System.Collections.Generic;

namespace MTSLibrary.Models
{
    public class ManufacturerModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<SupplierModel> ToolSuppliers { get; set; }
    }
}