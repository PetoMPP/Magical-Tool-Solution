using MTSLibrary.Connections;
using System.Configuration;

namespace MTSLibrary
{
    public class GlobalConfig
    {
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
        public static string CnxnValue(string name) => ConfigurationManager.ConnectionStrings[name].ConnectionString;
        public static string AppKeyLookup(string key) => ConfigurationManager.AppSettings[key];
    }
}
