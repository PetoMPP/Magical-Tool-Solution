using MTSLibrary.Models;

namespace Magical_Tool_Solution.Interfaces
{
    public interface ISelectToolClass
    {
        public void LoadSelectedToolClass(string id);
        public void LoadSelectedBasicToolClass(BasicToolClassModel model);

    }
}
