using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea1.DTO;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Tarea1.DAO
{
    class ProductoDAO:ConexionMySQL
    {
        MySqlCommand cmd;
        MySqlConnection cn;
        int cont = 0;

        public ProductoDTO GetProducto()
        {
          

            return new ProductoDTO("NULL","NULL","NULL",0,0);
        }


        public List<ProductoDTO> listaProductos()
        {
            List<ProductoDTO> Productos = new List<ProductoDTO>();
            cn = conectar();
            cn.Open();

            string query = "SELECT * FROM producto";
            MySqlCommand adaptador = new MySqlCommand(query, cn);


            using (MySqlDataReader reader = adaptador.ExecuteReader())
            {
                while (reader.Read())
                {
                    Productos.Add(new ProductoDTO(
                    idProducto: reader.GetString("idProducto"),
                    nombre: reader.GetString("Nombre"),
                    unidad: reader.GetString("Unidad"),
                    cantActual: reader.GetDouble("Cantidad_Actual"),
                    cantCrit: reader.GetDouble("Cantidad_Critica")
                    ));
                }
            }

            return Productos;
        }

        public void EliminarProducto(string IdProducto, bool resultado)
        {
            cn = conectar();
            cn.Open();
            if (resultado == true)
            {
                cmd = new MySqlCommand("DELETE FROM producto WHERE idProducto='" + IdProducto + "'", cn);
                cmd.ExecuteNonQuery();
            }
        }

        public List<ProductoDTO> FiltrarProducto(string campo)
        {

            List<ProductoDTO> Productos = new List<ProductoDTO>();
            cn = conectar();
            cn.Open();

            string query = "SELECT * FROM producto WHERE idProducto LIKE '%" + campo + "%' OR Nombre LIKE '%" + campo + "%' OR Unidad LIKE '%" + campo + "%';";
            MySqlCommand adaptador = new MySqlCommand(query, cn);


            using (MySqlDataReader reader = adaptador.ExecuteReader())
            {
                while (reader.Read())
                {
                    Productos.Add(new ProductoDTO(
                    idProducto: reader.GetString("idProducto"),
                    nombre: reader.GetString("Nombre"),
                    unidad: reader.GetString("Unidad"),
                    cantActual: reader.GetDouble("Cantidad_Actual"),
                    cantCrit: reader.GetDouble("Cantidad_Critica")
                    ));
                }
            }

            return Productos;
    
        }
    }
}
