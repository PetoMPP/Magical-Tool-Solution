using MTSLibrary.Connections;
using MTSLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace MTSLibrary
{
    public class GlobalConfig
    {
        //TODO - Connection to DB
        public static IDataConnection Connection { get; private set; }

        public static void InitializeConnections(DatabaseType db)
        {
            if (db == DatabaseType.TDM)
            {
                TDMConnector tdm = new();
                Connection = tdm;
            }
            else if (db == DatabaseType.MTS)
            {
                MTSConnector mts = new();
                Connection = mts;
            }
        }
        public static string CnxnValue(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        public static string AppKeyLookup(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
