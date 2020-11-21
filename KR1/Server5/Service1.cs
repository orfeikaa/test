using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;

namespace Server5
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        public void DoWork()
        {
        }
        string path = @"workstation id = BipitKonrol.mssql.somee.com; packet size = 4096; user id = orfeikaa_SQLLogin_1; pwd=o1fnc3stay;data source = BipitKonrol.mssql.somee.com; persist security info=False;initial catalog = BipitKonrol";
        public DataSet GetData(string d1, string d2)
        {
            string query = "SELECT ID_SHYRNAL as 'Номер', Name_klient as 'ФИО заказчика', Name_yslygi as 'Услуга', format(Data_shyrnal, 'dd.MM.yyyy') as 'Дата' " +
                    "  FROM Klient, Shyrnal, Yslygi " +
                    "  WHERE Shyrnal.ID_klient = Klient.ID_KLIENT AND Shyrnal.ID_yslygi = Yslygi.ID_YSLYGI";

             if (d1 != "" && d2 != "")
             {
                query += $" AND Shyrnal.Data_shyrnal >='{d1}' AND Shyrnal.Data_shyrnal <='{d2}';";
             }

            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(path))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(ds, "Shyrnal");

                return ds;
            }
        }

        public DataSet GetClients(string d1)
        {
            string query = "SELECT ID_KLIENT as 'Код клиента', Name_klient as 'ФИО клиента' FROM Klient ";

              
            if(d1 != "")
            {
                query += $" WHERE  Name_klient LIKE '%{d1}%'";
            }

            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(path))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(ds, "Klient");

                return ds;
            }
        }

        public DataSet GetServices(int d1, int d2)
        {
            string query = "SELECT ID_YSLYGI as 'Номер услуги',  Name_yslygi as 'Услуга', Cost_yslygi as 'Цена' FROM Yslygi";

            if (d1 != 0  && d2 != 0)
            {
                query += $" WHERE Cost_yslygi >='{d1}' AND Cost_yslygi <='{d2}'; ";
            }

            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(path))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(ds, "Yslygi");

                return ds;
            }
        }
    }
}
