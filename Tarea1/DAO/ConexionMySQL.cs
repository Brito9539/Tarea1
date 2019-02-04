using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Tarea1.DAO
{
    class ConexionMySQL
    {
        MySqlConnection myConexion;
        string parametrosConexion = "server=127.0.0.1; database=sci_bd; Uid=root; pwd=root;";
        public MySqlConnection conectar()
        {
            myConexion = new MySqlConnection(parametrosConexion);
            return myConexion;
        }

        public ConexionMySQL()
        {
            parametrosConexion = "server=127.0.0.1; database=sci_bd; Uid=root; pwd=root;";
            myConexion = conectar();
        }
    }
}
