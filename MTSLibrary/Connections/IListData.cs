using MTSLibrary.Models.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTSLibrary.Connections
{
    public interface IListData
    {
        void CreateList(ListModel list);
        void DeleteListById(string id);
        List<BasicListModel> GetBasicListModels();
        ListModel GetListModelById(string listId);
        void UpdateList(ListModel list);
        bool ValidateListId(string id);
        string ValidateListPositions(IEnumerable<IListPositionModel> tools);
    }
}
