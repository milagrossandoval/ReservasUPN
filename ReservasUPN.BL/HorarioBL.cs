using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IBL;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.BL
{
    public class HorarioBL : IHorarioBL
    {

        IRecursoTipoBL recursotipobl = new RecursoTipoBL();
        IHoraBL horabl = new HoraBL();

        public List<BE.Adapters.Horario> Buscar(int idtiporecurso, int idrecurso, bool defecto)
        {

            List<BE.Adapters.Horario> rpta = new List<BE.Adapters.Horario>();

            if (defecto && idtiporecurso == 0)
            {
                return rpta;
            }

            if (!defecto && idrecurso == 0)
            {
                return rpta;
            }

            
            RecursoTipo recursotipo;
            List<BE.Modelos.Hora> horas;
            if (defecto) // Tipo Recurso Horario
            {
                recursotipo = recursotipobl.Buscar(idtiporecurso);
                IRecursoTipoHorarioBL recursotipohorariobl = new RecursoTipoHorarioBL();
                List<BE.Modelos.RecursoTipoHorario> horario = recursotipohorariobl.Buscar(idtiporecurso);
                horas = horabl.Listar(recursotipo.tipoHora.ToString());
                if (horario.Count() == 0)
                {
                    //Cargar vacio
                    horas.ForEach(h => rpta.Add(new BE.Adapters.Horario
                    {
                        hora = h.n_hor_codigo,
                        DesHora = h.s_hor_descripcion,
                        lunes = false,
                        martes = false,
                        miercoles = false,
                        jueves = false,
                        viernes = false,
                        sabado = false,
                        domingo = false
                    }));
                }
                else
                {
                    //Cargar horario por defecto
                    rpta = (from h in horario
                            join x in horas on h.hora equals x.n_hor_codigo
                            select new BE.Adapters.Horario
                            {
                                Id = h.tiporecurso,
                                hora = h.hora,
                                DesHora = x.s_hor_descripcion,
                                lunes = h.lunes,
                                martes = h.martes,
                                miercoles = h.miercoles,
                                jueves = h.jueves,
                                viernes = h.viernes,
                                sabado = h.sabado,
                                domingo = h.domingo
                            }).ToList();

                }

            }
            else //Recurso Horario
            {
                IRecursoHorarioBL recursohorariobl = new RecursoHorarioBL();
                List<BE.Modelos.RecursoHorario> horario = recursohorariobl.Buscar(idrecurso);
                Recurso recurso = new RecursoBL().Buscar(idrecurso);
                recursotipo = new RecursoTipoBL().Buscar(recurso.tipoRecurso);
                horas = horabl.Listar(recursotipo.tipoHora.ToString());

                if (horario.Count() == 0)
                {
                    //Cargar vacio
                    horas.ForEach(h => rpta.Add(new BE.Adapters.Horario
                    {
                        hora = h.n_hor_codigo,
                        DesHora = h.s_hor_descripcion,
                        lunes = false,
                        martes = false,
                        miercoles = false,
                        jueves = false,
                        viernes = false,
                        sabado = false,
                        domingo = false
                    }));
                }
                else
                {
                    //Cargar horario por defecto
                    rpta = (from h in horario
                            join x in horas on h.hora equals x.n_hor_codigo
                            select new BE.Adapters.Horario
                            {
                                Id = h.recurso,
                                hora = h.hora,
                                DesHora = x.s_hor_descripcion,
                                lunes = h.lunes,
                                martes = h.martes,
                                miercoles = h.miercoles,
                                jueves = h.jueves,
                                viernes = h.viernes,
                                sabado = h.sabado,
                                domingo = h.domingo
                            }).ToList();

                }
            }
            return rpta;
        }

    }
}
