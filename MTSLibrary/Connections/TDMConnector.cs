using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTSLibrary.Connections
{
    public class TDMConnector : IDataConnection
    {
        public List<CompModel> GetCompModelsBasic()
        {
            throw new NotImplementedException();
        }

        public List<CompModel> GetCompModelsSupplier(List<CompModel> comps)
        {
            throw new NotImplementedException();
        }

        public List<ToolModel> GetToolModelsFull()
        {
            throw new NotImplementedException();
        }
    }
}
