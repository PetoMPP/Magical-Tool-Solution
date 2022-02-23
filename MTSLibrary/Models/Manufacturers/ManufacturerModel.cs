using MTSLibrary.Models.Suppliers;
using System.Collections.Generic;

namespace MTSLibrary.Models.Manufacturers
{
    public class ManufacturerModel : IManufacturerModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ISupplierModel> ToolSuppliers { get; set; }
    }
}