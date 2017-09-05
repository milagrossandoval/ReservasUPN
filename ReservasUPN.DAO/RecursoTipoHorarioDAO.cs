using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IDAO;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.DAO
{
    public class RecursoTipoHorarioDAO : IRecursoTipoHorarioDAO
    {

        #region Singleton
        private RecursoTipoHorarioDAO() { }

        private static readonly RecursoTipoHorarioDAO _instance = new RecursoTipoHorarioDAO();
        public static RecursoTipoHorarioDAO Instance
        { get { return _instance; } }
        #endregion

        public bool Grabar(List<BE.Modelos.RecursoTipoHorario> lista)
        {
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                foreach(RecursoTipoHorario horario in lista){
                    var res = (from rth in reposit.RecursoTipoHorario
                               where rth.hora == horario.hora
                               && rth.tiporecurso == horario.tiporecurso
                               select rth);
                    if (res.Count() == 1)
                    {
                        RecursoTipoHorario upd = res.First();
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
                        reposit.AddToRecursoTipoHorario(horario);
                    }
                }
                reposit.SaveChanges();
            }
            return true;
                
        }


        public List<RecursoTipoHorario> Buscar(int tiporecursoid)
        {
            List<RecursoTipoHorario> rpta;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                rpta = (from rth in reposit.RecursoTipoHorario
                        where rth.tiporecurso == tiporecursoid
                        select rth).ToList();
            }
            return rpta;
        }
    }
}
