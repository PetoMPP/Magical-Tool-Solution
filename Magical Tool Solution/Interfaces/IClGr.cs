using MTSLibrary.Models;

namespace Magical_Tool_Solution.Interfaces
{
    public interface IClGr
    {
        void AddToolClass(ToolClassModel model);
        void UpdateToolClass(ToolClassModel model);
        void AddToolGroup(ToolGroupModel model);
        void UpdateToolGroup(ToolGroupModel model);
        void AddClGrParameter(ToolClassParameterModel model);
        void UpdateClGrParameter(ToolClassParameterModel model);
        bool ValidateToolClassId(string id);
        bool ValidateToolGroup(ToolGroupModel model);
    }
}