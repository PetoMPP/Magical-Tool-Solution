using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTSLibrary
{
    public static class CalculationLogic
    {
        public static CompModel CalculateMinimalStock(this CompModel comp)
        {
            //TODO - get comp used tools and max quantity


            //TODO - nonstandard tools - count usage with max comp in tool
            //TODO - standards - count usage

            //TODO - clgr multiplier
            return comp;
        }

        public static CompModel CalculateMissingStock(this CompModel comp)
        {
            //TODO - get comp minimal stock
            //TODO - get comp actual stock in warehouse
            //TODO - get comp used in assembled tools
            //TODO - return missing
            return comp;
        }
    }
}
