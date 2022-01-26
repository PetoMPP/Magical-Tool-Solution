using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magical_Tool_Solution.Interfaces
{
    public interface ISelectToolGroup
    {
        public void LoadSelectedToolGroup(string id);
        public void LoadSelectedBasicToolGroup(BasicToolGroupModel model);

    }
}
