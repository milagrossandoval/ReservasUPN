using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IDAO;
using ReservasUPN.BE.Modelos;
using ReservasUPN.Util;

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
    
        public bool Grabar(List<Reserva> reservas)
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

        public List<BE.Adapters.Reserva> Listar(string usuario, int sede)
        {
            List<BE.Adapters.Reserva> rpta;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                rpta = (from r in reposit.Reserva
                        join c in reposit.Recurso on r.recurso equals c.id
                        join t in reposit.RecursoTipo on c.tipoRecurso equals t.id
                        where r.usuario == usuario && t.sede == sede
                        select new BE.Adapters.Reserva
                        {
                            id = r.id,
                            asistencia = r.asistencia.HasValue? r.asistencia: false,
                            descripcionHora = r.descripcionHora,
                            diaSemana = r.diaSemana,
                            estado = r.estado,
                            fecha = r.fecha,
                            inicio = r.inicio,
                            final = r.final,
                            hora = r.hora,
                            NombreRecurso = c.descripcion,
                            nombreUsuario = r.nombreUsuario,
                            NombreTipoRecurso = t.descripcion,
                            recurso = r.recurso,
                            usuario = r.usuario
                        }).ToList();

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

        public List<BE.Adapters.Reserva> ListarActivas(string usuario, int tiporecurso, DateTime fechaInicio, DateTime fechaFin)
        {
            List<BE.Adapters.Reserva> rpta;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                rpta = (from r in reposit.Reserva
                        join t in reposit.Recurso on r.recurso equals t.id
                        where r.usuario == usuario && t.tipoRecurso == tiporecurso
                        && r.inicio >= DateTime.Now
                        && r.fecha >= fechaInicio && r.fecha <= fechaFin
                        && r.estado
                        select new BE.Adapters.Reserva { 
                            id = r.id,
                            asistencia = r.asistencia,
                            descripcionHora = r.descripcionHora,
                            diaSemana = r.diaSemana,
                            estado = r.estado,
                            fecha = r.fecha,
                            inicio = r.inicio,
                            final = r.final,
                            hora = r.hora,
                            NombreRecurso = t.descripcion,
                            nombreUsuario = r.nombreUsuario,
                            recurso = r.recurso,
                            usuario = r.usuario
                        }).ToList();
            }

            return rpta;
        }

        public List<BE.Adapters.Reserva> Listar(DateTime fecha, int hora, int idtiporecurso)
        {
            List<BE.Adapters.Reserva> rpta;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                rpta = (from r in reposit.Reserva
                        join t in reposit.Recurso on r.recurso equals t.id
                        where t.tipoRecurso == idtiporecurso
                        && r.fecha == fecha && r.hora == hora
                        && r.estado
                        select new BE.Adapters.Reserva
                        {
                            id = r.id,
                            asistencia = r.asistencia,
                            descripcionHora = r.descripcionHora,
                            diaSemana = r.diaSemana,
                            estado = r.estado,
                            fecha = r.fecha,
                            inicio = r.inicio,
                            final = r.final,
                            hora = r.hora,
                            NombreRecurso = t.descripcion,
                            nombreUsuario = r.nombreUsuario,
                            recurso = r.recurso,
                            usuario = r.usuario
                        }).ToList();
            }

            return rpta;
        }

        public BE.Adapters.Reserva Buscar(string usuario, DateTime fecha, int hora, int idrecurso)
        {
            BE.Adapters.Reserva rpta = null;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                var res = (from r in reposit.Reserva
                            join t in reposit.Recurso on r.recurso equals t.id
                            where r.recurso == idrecurso
                            && r.fecha == fecha && r.hora == hora
                            && r.estado && r.usuario == usuario
                            select new BE.Adapters.Reserva
                            {
                                id = r.id,
                                asistencia = r.asistencia,
                                descripcionHora = r.descripcionHora,
                                diaSemana = r.diaSemana,
                                estado = r.estado,
                                fecha = r.fecha,
                                inicio = r.inicio,
                                final = r.final,
                                hora = r.hora,
                                NombreRecurso = t.descripcion,
                                nombreUsuario = r.nombreUsuario,
                                recurso = r.recurso,
                                usuario = r.usuario
                            });
                if (res.Count() == 1) {
                    rpta = res.First();
                }
            }

            return rpta;
        }

        public bool CambiarAsistencia(int id)
        {
            bool rpta;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                var res = (from x in reposit.Reserva where x.id == id select x);
                Reserva r = res.First();
                r.asistencia = (r.asistencia.HasValue?!r.asistencia:true);
                rpta = reposit.SaveChanges() == 1;
            }
            return rpta;
        }

    }
}
