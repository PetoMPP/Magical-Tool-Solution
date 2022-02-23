namespace MTSLibrary.Models.Suppliers
{
    public interface ISupplierModel
    {
        IContactPersonModel ContactPerson { get; set; }
        string Id { get; set; }
        string Name { get; set; }
    }
}