﻿using System.Data;
using System.Data.OleDb;
using System.Net;

namespace DAL
{
    public class InfraccionesDAL : BaseDAL
    {
        public InfraccionesDAL() : base("Infracciones")
        {
        }

        public DataTable GetAllInfracciones()
        {
            return GetAll();
        }

        public void Insert(int codigo, string descripcion, decimal importe, int tipo)
        {

            if (Exists(new OleDbParameter("Codigo", codigo)))
            {
                throw new DuplicateNameException("Ya existe una infracción con ese código");
            }

            Insert(new OleDbParameter("Codigo", codigo),
                               new OleDbParameter("Descripcion", descripcion),
                                              new OleDbParameter("Importe", importe),
                                                             new OleDbParameter("Tipo", tipo));
        }

        public void Delete(int id)
        {
            OleDbParameter[] parameters = new OleDbParameter[]
            {
                new OleDbParameter("ID", id)
            };

            Delete("ID = ?", parameters);
        }

        public void Update(int id, int codigo, string descripcion, decimal importe, int tipo)
        {
            if (Exists(new OleDbParameter("Codigo", codigo)))
            {
                throw new DuplicateNameException("Ya existe una infracción con ese código");
            }

            var setParameters = new OleDbParameter[]
            {
                new OleDbParameter("Codigo", codigo),
                new OleDbParameter("Descripcion", descripcion),
                new OleDbParameter("Importe", importe),
                new OleDbParameter("Tipo", tipo)
            };

            var whereClause = "ID = ?";

            var whereParameters = new OleDbParameter[]
            {
                new OleDbParameter("ID", id)
            };

            Update(setParameters, whereClause, whereParameters);
        }
    }
}