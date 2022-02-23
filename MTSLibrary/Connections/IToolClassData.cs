using MTSLibrary.Models.ToolClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTSLibrary.Connections
{
    public interface IToolClassData
    {
        void CreateToolClass(ToolClassModel model);
        void DeleteToolClassById(string id);
        List<BasicToolClassModel> GetBasicToolClassModels();
        ToolClassModel GetToolClassById(string id);
        List<ToolClassModel> GetToolClassesList();
        string GetToolClassNameById(string parentClassId);
        List<ToolClassModel> GetUnallocatedToolClasses();
        void SetMainClassIdByToolClassId(string mainClassId, string toolClassId);
        void UpdateToolClass(ToolClassModel model);
        bool ValidateToolClassId(string id);
    }
}
