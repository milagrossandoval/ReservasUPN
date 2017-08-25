﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IDAO;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.DAO
{
    public class RecursoDAO : IRecursoDAO
    {
        #region Singleton
        private RecursoDAO() { }

        private static readonly RecursoDAO _instance = new RecursoDAO();
        public static RecursoDAO Instance
        { get { return _instance; } }
        #endregion

        public bool Grabar(BE.Modelos.Recurso obj)
        {
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                reposit.AddToRecurso(obj);
                return reposit.SaveChanges() == 1;
            }
        }

        public bool Actualizar(BE.Modelos.Recurso obj)
        {
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                var recurso = (from x in reposit.Recurso
                               where x.id == obj.id
                               select x).First();
                recurso.codigo = obj.codigo;
                recurso.descripcion = obj.descripcion;
                recurso.tipoRecurso = obj.tipoRecurso;
                recurso.caracteristicas = obj.caracteristicas;
                recurso.estado = obj.estado;
                return reposit.SaveChanges() == 1;
            }
        }

        public List<BE.Adapters.Recurso> Listar(int idSede)
        {
            List<BE.Adapters.Recurso> rpta;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                rpta = (from recurso in reposit.Recurso
                        join tipo in reposit.RecursoTipo on recurso.tipoRecurso equals tipo.id
                        where tipo.sede == idSede
                        select new BE.Adapters.Recurso
                           {
                               id = recurso.id,
                               codigo = recurso.codigo,
                               descripcion = recurso.descripcion,
                               tipoRecurso = tipo.id,
                               NombreTipoRecurso = tipo.descripcion,
                               caracteristicas = recurso.caracteristicas,
                               estado = recurso.estado
                           }).ToList();

            }
            return rpta;
        }
    }
}
