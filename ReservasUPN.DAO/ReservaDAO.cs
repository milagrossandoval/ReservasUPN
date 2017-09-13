using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IDAO;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.DAO
{
    public class ReservaDAO : IReservaDAO
    {

        #region Singleton
        private ReservaDAO() { }

        private static readonly ReservaDAO _instance = new ReservaDAO();
        public static ReservaDAO Instance
        { get { return _instance; } }
        #endregion

        public int HorasUtilizadas(string usuario, int idtiporecurso, DateTime fecha)
        {
            int horas;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                horas = (from r in reposit.Reserva
                           join t in reposit.Recurso on r.recurso equals t.id
                           where r.usuario == usuario && t.tipoRecurso == idtiporecurso 
                           && r.fecha.Month == fecha.Month && r.fecha.Year == fecha.Year
                           && r.estado
                           select r.hora).Count();
            }
            return horas;
        }
    
        public bool  Grabar(List<Reserva> reservas)
        {
            bool rpta;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                foreach (Reserva r in reservas) {
                    reposit.AddToReserva(r);
                }
                rpta = reposit.SaveChanges() > 0;
            }
            return rpta;
        }

        public bool Cancelar(int id)
        {
            bool rpta;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                var res =(from x in reposit.Reserva where x.id == id select x);
                Reserva r = res.First();
                r.estado = false;
                rpta = reposit.SaveChanges() == 1;
            }
            return rpta;
        }

        public List<Reserva> Listar(string usuario, bool mostrarPasadas)
        {
            List<Reserva> rpta;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                rpta = (from x in reposit.Reserva
                        where x.usuario == usuario && 
                        (mostrarPasadas ? x.fecha<DateTime.Today : true)
                        select x).ToList();

            }
            return rpta;
        }


        public List<Reserva> Listar(int recurso, DateTime inicio, DateTime fin)
        {
            List<Reserva> rpta;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                rpta = (from x in reposit.Reserva
                        where x.estado 
                            && x.fecha >= inicio && x.fecha <= fin 
                            && x.recurso == recurso
                        select x).ToList();

            }
            return rpta;
        }


        public Reserva Buscar(int recurso, DateTime fecha, int hora)
        {
            Reserva rpta = null;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                var res = (from x in reposit.Reserva
                            where x.estado
                            && x.fecha == fecha
                            && x.recurso == recurso
                            && x.hora == hora
                            select x);
                if (res.Count() == 1) {
                    rpta = res.First();
                }
            }
            return rpta;
        }
    }
}
