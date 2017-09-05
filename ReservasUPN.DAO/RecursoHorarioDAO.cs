using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IDAO;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.DAO
{
    public class RecursoHorarioDAO : IRecursoHorarioDAO
    {

        #region Singleton
        private RecursoHorarioDAO() { }

        private static readonly RecursoHorarioDAO _instance = new RecursoHorarioDAO();
        public static RecursoHorarioDAO Instance
        { get { return _instance; } }
        #endregion

        public bool Grabar(List<BE.Modelos.RecursoHorario> lista)
        {
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                foreach (RecursoHorario horario in lista)
                {
                    var res = (from rh in reposit.RecursoHorario
                               where rh.hora == horario.hora
                               && rh.recurso == horario.recurso
                               select rh);
                    if (res.Count() == 1)
                    {
                        RecursoHorario upd = res.First();
                        upd.lunes = horario.lunes;
                        upd.martes = horario.martes;
                        upd.miercoles = horario.miercoles;
                        upd.jueves = horario.jueves;
                        upd.viernes = horario.viernes;
                        upd.sabado = horario.sabado;
                        upd.domingo = horario.domingo;
                    }
                    else
                    {
                        reposit.AddToRecursoHorario(horario);
                    }
                }
                reposit.SaveChanges();
            }
            return true;
        }

        public List<BE.Modelos.RecursoHorario> Buscar(int recursoid)
        {
            List<RecursoHorario> rpta;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                rpta = (from rh in reposit.RecursoHorario
                        where rh.recurso == recursoid
                        select rh).ToList();
            }
            return rpta;
        }
    }
}
