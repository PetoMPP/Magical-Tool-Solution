using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magical_Tool_Solution.Interfaces
{
    public interface ISelectPosition
    {
        public void AddPosition(ListPositionModel model);
        public bool IsPositionNumberInUse(int position);
    }
}
