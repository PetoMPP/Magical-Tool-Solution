namespace MTSLibrary.Models.Suppliers
{
    public interface IContactPersonModel
    {
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string Id { get; set; }
        string LastName { get; set; }
    }
}