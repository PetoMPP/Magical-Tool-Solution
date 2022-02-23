using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTSLibrary.Connections
{
    public interface IManufacturerData
    {
        string GetManufacturerIdByName(string name);
        string ValidateManufacturerName(string name);
    }
}
