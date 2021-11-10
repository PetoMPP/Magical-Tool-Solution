using System;
using System.Collections.Generic;
using System.Text;

namespace MTSLibrary.Models
{
    public class ToolModel
    {
        public string ID { get; set; }
        public int QuantityCTX { get; set; }
        public int QuantityDMF { get; set; }
        public int QuantityFMS { get; set; }
        public int QuantityDatron { get; set; }
        public List<CompUsageModel> UsedComps { get; set; }
    }
}
