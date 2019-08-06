using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace SensorGenerator.DAL
{
    public class Connection
    {
       public MySqlConnection conn = new MySqlConnection("server=127.0.0.1;user id=mergim;password=mergim;persistsecurityinfo=True;database=ehealth;Max Pool Size=1000;");
    }
}
