using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magical_Tool_Solution.Interfaces
{
    public interface ISelectComponent
    {
        public void AddComponent(ToolComponentModel model);
        public bool IsPositionNumberInUse(int position);
    }
}
