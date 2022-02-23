using MTSLibrary.Models.Tools;

namespace Magical_Tool_Solution.Interfaces
{
    public interface ISelectComponent
    {
        public void AddToolComponent(IToolComponentModel model);
        public bool IsToolComponentPositionNumberInUse(int position);
        public void DeleteToolComponent(int position);
        public void UpdateToolComponent(IToolComponentModel model);
    }
}
