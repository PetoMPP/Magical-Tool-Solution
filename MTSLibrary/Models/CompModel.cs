using System;
using System.Collections.Generic;
using System.Text;

namespace MTSLibrary.Models
{
    public class CompModel
    {
        public string ID { get; set; }
        public string Desc1 { get; set; }
        public string Desc2 { get; set; }
        public string CLGR { get; set; }
        public List<ToolModel> ToolsUsingItem { get; set; }
        public int MaxQuantityInTool { get; set; }
        public int TotalListsWithComp { get; set; }
        public int TotalQuantityInStandards { get; set; }
        public int MinimalStock { get; set; }
        public int ActualStock { get; set; }
        public int MissingStock { get; set; }
        public SupplierModel Supplier { get; set; }
        public string DisplayName { get
            {
                string output = $"ID: {ID}";
                if (MinimalStock != -1)
                {
                    output += $", Min: { MinimalStock}";
                }
                if (ActualStock != -1)
                {
                    output += $", Act: {ActualStock}";
                }
                if (MinimalStock != -1)
                {
                    output += $", Miss: {MissingStock}";
                }
                return output;
            }
        }
        public CompModel()
        {
            MaxQuantityInTool = -1;
            TotalListsWithComp = -1;
            TotalQuantityInStandards = -1;
            MinimalStock = -1;
            ActualStock = -1;
            MinimalStock = -1;
        }
    }
}
