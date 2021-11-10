using System;
using System.Collections.Generic;
using System.Text;

namespace MTSLibrary.Models
{
    public class ContactPersonModel
    {
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
