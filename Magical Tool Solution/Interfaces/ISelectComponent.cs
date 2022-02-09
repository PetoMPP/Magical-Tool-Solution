using MTSLibrary.Models;

namespace Magical_Tool_Solution.Interfaces
{
    public interface ISelectComponent
    {
        public void AddToolComponent(ToolComponentModel model);
        public bool IsToolComponentPositionNumberInUse(int position);
        public void DeleteToolComponent(int position);
        public void UpdateToolComponent(ToolComponentModel model);
    }
}
