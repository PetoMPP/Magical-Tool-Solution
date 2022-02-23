using MTSLibrary.Models.Lists;

namespace Magical_Tool_Solution.Interfaces
{
    public interface ISelectPosition
    {
        public void AddListPosition(IListPositionModel model);
        public bool IsListPositionPositionNumberInUse(int position);
        public void DeleteListPosition(IListPositionModel model);
        public void UpdateListPosition(IListPositionModel model);
    }
}
