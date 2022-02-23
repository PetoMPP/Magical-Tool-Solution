namespace MTSLibrary.Models.Suppliers
{
    public class ContactPersonModel : IContactPersonModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public static string GetFullName(ContactPersonModel model)
        {
            string fullName = model.FirstName + " " + model.LastName;
            return fullName;
        }
    }
}