using MTSLibrary.Models;

namespace Magical_Tool_Solution.Interfaces
{
    public interface ISelectToolGroup
    {
        public void LoadSelectedToolGroup(string id, string toolClassId);
        public void LoadSelectedBasicToolGroup(BasicToolGroupModel model);

    }
}
