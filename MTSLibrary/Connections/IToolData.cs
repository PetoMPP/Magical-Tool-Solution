using MTSLibrary.Models.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTSLibrary.Connections
{
    public interface IToolData
    {
        void CreateTool(ToolModel tool);
        void DeleteToolById(string id);
        ToolModel GetToolModelById(string toolId);
        BasicToolModel GetBasicToolModelById(string text);
        List<BasicToolModel> GetBasicToolModels();
        void UpdateTool(ToolModel tool);
        bool ValidateToolId(string id);
        string ValidateToolComponents(IEnumerable<IToolComponentModel> components);
    }
}
