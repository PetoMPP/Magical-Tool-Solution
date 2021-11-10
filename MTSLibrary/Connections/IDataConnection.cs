using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTSLibrary.Connections
{
    public interface IDataConnection
    {
        /// <summary>
        /// Gets <see cref="CompModel"/> List with ID, Desc1, Desc2 and CLGR.
        /// </summary>
        /// <returns></returns>
        public List<CompModel> GetCompModelsBasic();
        public List<CompModel> GetCompModelsSupplier(List<CompModel> comps);
        public List<ToolModel> GetToolModelsFull();
    }
}
