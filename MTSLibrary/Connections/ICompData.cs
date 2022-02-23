using MTSLibrary.Models;
using MTSLibrary.Models.Comps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTSLibrary.Connections
{
    public interface ICompData
    {
        void CreateComp(CompModel comp);
        void DeleteCompById(string id);
        CompModel GetCompModelById(string compId);
        BasicCompModel GetBasicCompModelById(string text);
        List<BasicCompModel> GetBasicCompModels();
        void UpdateComp(CompModel comp);
        bool ValidateCompId(string id);
    }
}
