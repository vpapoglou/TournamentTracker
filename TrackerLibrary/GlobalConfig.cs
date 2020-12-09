using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }

        public static void InitializeConnection(DatabaseType db)
        {
            switch (db)
            {
                case DatabaseType.Sql:
                    SqlConnector sql = new SqlConnector();
                    Connection = sql;
                    break;
                case DatabaseType.TextFile:
                    TextConnector text = new TextConnector();
                    Connection = text;
                    break;
                default:
                    break;
            }
            //if (db == DatabaseType.Sql)
            //{
            //    //TODO - Create the SQL Connector properly
            //    SqlConnector sql = new SqlConnector();
            //    Connections = sql;
            //}
            //else if(db == DatabaseType.TextFile)
            //{
            //    //TODO - Create the Text Connection
            //    TextConnector text = new TextConnector();
            //    Connections = text;
            //}
        }

        /// <summary>
        /// Whenever someone uses GlobalConfig.CnnString() he will get the connection string he passes
        /// from the AppConfig --> <ConnectionStrings></ConnectionStrings>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
