using MTSLibrary.Models.Suppliers;
using System.Collections.Generic;

namespace MTSLibrary.Models.Manufacturers
{
    public interface IManufacturerModel
    {
        string Id { get; set; }
        string Name { get; set; }
        IEnumerable<ISupplierModel> ToolSuppliers { get; set; }
    }
}