using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1.DTO
{
    class ProductoDTO
    {
        string IdProducto;
        string Nombre;
        string Unidad;
        double CantActual;
        double CantCrit;

        public ProductoDTO(string idProducto, string nombre, string unidad, double cantActual, double cantCrit)
        {
            IdProducto1 = idProducto;
            Nombre1 = nombre;
            Unidad1 = unidad;
            CantActual1 = cantActual;
            CantCrit1 = cantCrit;
        }

        public string IdProducto1 { get => IdProducto; set => IdProducto = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Unidad1 { get => Unidad; set => Unidad = value; }
        public double CantActual1 { get => CantActual; set => CantActual = value; }
        public double CantCrit1 { get => CantCrit; set => CantCrit = value; }
    }
}
