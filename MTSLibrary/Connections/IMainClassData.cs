using MTSLibrary.Models.MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTSLibrary.Connections
{
    public interface IMainClassData
    {
        void CreateMainClass(BasicMainClassModel model);
        void DeleteMainClassById(string id);
        List<BasicMainClassModel> GetBasicMainClassModels();
        List<MainClassModel> GetMainClassesList();
        string GetMainClassNameById(string mainClassId);
        void UnallocateToolClasses(string mainClassId);
        void UpdateMainClass(BasicMainClassModel model);
        bool ValidateMainClassId(string id);
    }
}
