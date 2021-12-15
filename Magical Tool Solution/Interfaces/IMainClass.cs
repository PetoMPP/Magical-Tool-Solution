using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magical_Tool_Solution.Interfaces
{
    public interface IMainClass
    {
        public bool ValidateMainClassId(string id);
        public void AddMainClass(MainClassModel model);
        public void UpdateMainClass(MainClassModel model);
    }
}
