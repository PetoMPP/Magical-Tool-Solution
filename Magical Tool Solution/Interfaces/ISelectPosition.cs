using MTSLibrary.Models;

namespace Magical_Tool_Solution.Interfaces
{
    public interface ISelectPosition
    {
        public void AddListPosition(ListPositionModel model);
        public bool IsListPositionPositionNumberInUse(int position);
        public void DeleteListPosition(ListPositionModel model);
        public void UpdateListPosition(ListPositionModel model);
    }
}
