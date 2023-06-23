using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Dao;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class NegocioGenero
    {
        public DataTable getTabla()
        {
            DaoGeneros dao = new DaoGeneros();
            return dao.getTablaGeneros();
        }

        public Generos Get(string nombre)
        {
            DaoGeneros dao = new DaoGeneros();
            Generos genero = new Generos();
            genero.NombreGenero_GE1 = nombre;
            return dao.Getgenero(genero);
        }

        public bool EliminarGenero(string nombre)
        {
            DaoGeneros dao = new DaoGeneros();
            Generos genero = new Generos();
            genero.NombreGenero_GE1 = nombre;
            int op = dao.EliminarGenero(genero);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool agregarGenero(Generos genero)
        {
            int cantFilas = 0;
            
            DaoGeneros dao = new DaoGeneros();
            if (dao.existeGenero(genero) == false)
            {
                cantFilas = dao.agregarGenero(genero);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }
    }
}