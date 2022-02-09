﻿using MTSLibrary.Models;

namespace Magical_Tool_Solution.Interfaces
{
    public interface IMainClass
    {
        public bool ValidateMainClassId(string id);
        public void AddMainClass(BasicMainClassModel model);
        public void UpdateMainClass(BasicMainClassModel model);
    }
}
