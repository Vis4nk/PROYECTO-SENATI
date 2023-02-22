using PDatos;
using PEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNegocio
{
    public class NUsuario
    {
        public static DataTable Listar()
        {
            DUsuario Datos = new DUsuario();
            return Datos.Listar();
        }

        public static string Insertar(string Nombres, string Apellidos, string Dni, DateTime FechaNacimiento)
        {
            DUsuario Datos = new DUsuario();
            Usuario Obj = new Usuario();
            Obj.Nombres = Nombres;
            Obj.Apellidos = Apellidos;
            Obj.Dni = Dni;
            Obj.FechaNacimiento = FechaNacimiento;
           
            return Datos.Insertar(Obj);
            

        }

        public static string Actualizar(int Id, string NombreAnt, string Nombres,string Apellidos, string Dni, DateTime FechaNacimiento)
        {
            DUsuario Datos = new DUsuario();
            Usuario Obj = new Usuario();
            if (NombreAnt.Equals(Nombres))
            {
                Obj.IdUsuario = Id;
                Obj.Nombres = Nombres;
                Obj.Apellidos = Apellidos;
                Obj.Dni = Dni;
                Obj.FechaNacimiento = FechaNacimiento;
                
                return Datos.Actualizar(Obj);
            }
            else
            {
                Obj.IdUsuario = Id;
                Obj.Nombres = Nombres;
                Obj.Apellidos = Apellidos;
                Obj.Dni = Dni;
                Obj.FechaNacimiento = FechaNacimiento;
               
                return Datos.Actualizar(Obj);
                
            }


        }

        public static string Eliminar(int Id)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Eliminar(Id);
        }
    }
}
