namespace MTSLibrary.Models.Suppliers
{
    public class SupplierModel : ISupplierModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IContactPersonModel ContactPerson { get; set; }
    }
}
