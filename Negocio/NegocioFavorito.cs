﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class NegocioFavorito
    {
        public DataTable getTabla()
        {
            DaoFavoritos dao = new DaoFavoritos();
            return dao.getTablaFavorito();
        }

        public Favoritos Get(string id)
        {
            DaoFavoritos dao = new DaoFavoritos();
            Favoritos favorito = new Favoritos();
            Catalogo cat = new Catalogo();

            cat.IDContenido_Cat1 = id;

            favorito.IDContenido_F1 = cat;
            favorito.IDContenido_F1.IDContenido_Cat1 = id;
            return dao.GetFavorito(favorito);
        }
        public bool EliminarFavorito(string idContenido, int idCuenta)
        {
            DaoFavoritos dao = new DaoFavoritos();
            Favoritos favorito = new Favoritos();
            Catalogo cat = new Catalogo();
            Cuenta cue = new Cuenta();

            cue.SetIDCuenta(idCuenta);
            cat.IDContenido_Cat1 = idContenido;

            favorito.IDContenido_F1 = cat;
            favorito.IDCuenta_F1 = cue;

            int op = dao.EliminarFavorito(favorito);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool ExisteFavorito(string idContenido, int idCuenta)
        {
            Favoritos favorito = new Favoritos();
            DaoFavoritos dao = new DaoFavoritos();

            Catalogo cat = new Catalogo();
            Cuenta cue = new Cuenta();

            cue.SetIDCuenta(idCuenta);
            cat.IDContenido_Cat1 = idContenido;
            
            favorito.IDContenido_F1 = cat;
            favorito.IDCuenta_F1 = cue;
            return dao.ExisteFavorito(favorito);
        }

        public bool MarcarFavorito(string idContenido, int idCuenta)
        {
            bool favMarcado = false;
            Favoritos favorito = new Favoritos();
            Catalogo cat = new Catalogo();
            Cuenta cue = new Cuenta();

            cue.SetIDCuenta(idCuenta);
            cat.IDContenido_Cat1 = idContenido;

            favorito.IDContenido_F1 = cat;
            favorito.IDCuenta_F1 = cue;
            DaoFavoritos dao = new DaoFavoritos();
            var eliminar = dao.ExisteFavorito(favorito);
            favMarcado = dao.MarcarFavorito(favorito, eliminar);

            // devuelve true solo si lo marcó como favorito y no era eliminar favorito
            // y devuelve false si lo desmarcó como favorito o si no aplicó el cambio
            return favMarcado && !eliminar;
        }
    }
}