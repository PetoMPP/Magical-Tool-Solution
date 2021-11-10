using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTSLibrary.Connections
{
    public interface IModuleSelector
    {
        public void SelectMode(string mode);
    }
}
