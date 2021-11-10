using System;
using System.Collections.Generic;
using System.Text;

namespace MTSLibrary.Models
{
    public class SupplierModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public ContactPersonModel ContactPerson { get; set; }
    }
}
