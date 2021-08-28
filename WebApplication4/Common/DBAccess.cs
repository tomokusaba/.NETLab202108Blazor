using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Data;

namespace WebApplication4.Common
{
    public class DBAccess
    {
        public List<TableData> SelectTable(string param)
        {
            string sql = "select * from yubin where todofuken || CITY || TYO || YUBIN_7 like :kensaku";
            List<TableData> list = new List<TableData>();
            using (DBCommon db = new DBCommon())
            {
                using (OracleCommand command = new OracleCommand(sql, db.Con))
                {
                    command.Parameters.Add(new OracleParameter("kensaku", $"%{param}%"));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TableData table = new TableData();
                            table.Kokyo_cd = DBCommon.GetString(reader, "KOKYO_CD");
                            table.Yubin_5 = DBCommon.GetString(reader, "YUBIN_5");
                            table.Yubin_7 = DBCommon.GetString(reader, "YUBIN_7");
                            table.Todofuke_kana = DBCommon.GetString(reader, "TODOFUKEN_KANA");
                            table.City_kana = DBCommon.GetString(reader, "CITY_KANA");
                            table.Tyo_kana = DBCommon.GetString(reader, "TYO_KANA");
                            table.Todofuken = DBCommon.GetString(reader, "TODOFUKEN");
                            table.City = DBCommon.GetString(reader, "CITY");
                            table.Tyo = DBCommon.GetString(reader, "TYO");

                            list.Add(table);
                        }
                    }
                }
            }
            return list;
        }

    }
}
