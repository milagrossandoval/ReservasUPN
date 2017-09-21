using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IBL;
using ReservasUPN.IDAO;
using ReservasUPN.DAO;
using System.IO;
using System.Net;

namespace ReservasUPN.BL
{
    public class ReservaBL : IReservaBL
    {

        IReservaDAO reservadao = ReservaDAO.Instance;

        public int HorasUtilizadas(string usuario, int idtiporecurso, DateTime fecha)
        {
            return reservadao.HorasUtilizadas(usuario, idtiporecurso, fecha);
        }

        public List<BE.Adapters.Reserva> ListarActivas(string usuario, int tiporecurso, DateTime fechaInicio, DateTime fechaFin)
        {
            return reservadao.ListarActivas(usuario, tiporecurso, fechaInicio, fechaFin);
        }

        public List<BE.Modelos.Reserva> Listar(int recurso, DateTime inicio, DateTime fin)
        {
            return reservadao.Listar(recurso, inicio, fin);
        }

        public bool Grabar(List<BE.Modelos.Reserva> reservas)
        {
            foreach (BE.Modelos.Reserva r in reservas)
            {
                if (reservadao.Buscar(r.recurso, r.fecha, r.hora) != null) {
                    throw new Exception("Ya se realizó una reserva en el horario seleccionado");
                }
            }
            return reservadao.Grabar(reservas);
        }

        public bool Cancelar(int id)
        {
            return reservadao.Cancelar(id);
        }


        public List<BE.Adapters.Reserva> Listar(string usuario, int sede)
        {
            return reservadao.Listar(usuario, sede);
        }


        public List<BE.Adapters.Reserva> Listar(DateTime fecha, int hora, int idtiporecurso)
        {
            return reservadao.Listar(fecha, hora, idtiporecurso);
        }

        public bool URLExists(string url)
        {
            bool result = true;

            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Timeout = 1200; // miliseconds
            webRequest.Method = "HEAD";

            try
            {
                webRequest.GetResponse();
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public List<BE.Adapters.Reserva> ListarHoy(int hora, int idtiporecurso)
        {

            List<BE.Adapters.Reserva> rpta = new List<BE.Adapters.Reserva>();

            if (idtiporecurso == 0)
                return rpta;

            BE.Modelos.RecursoTipo recursoTipo = new RecursoTipoBL().Buscar(idtiporecurso);
            string horaTipo = recursoTipo.tipoHora.ToString();
            BE.Modelos.Hora horaSgt = new HoraBL().HoraSiguiente(horaTipo);
            
            rpta = reservadao.Listar(DateTime.Today, hora, idtiporecurso);
            //rpta.ForEach(r=> r.Continuar = (Buscar(r.usuario,r.fecha,horaSgt.n_hor_codigo,r.recurso) != null));

            string fotoDefecto = "../assets/images/sinfoto.jpg";
            string foto_path = "https://intranet.upn.edu.pe/reservasonline/Secure/fotos/";

            for (int i = 0; i < rpta.Count; i++)
            {
                if (horaSgt == null)
                    rpta[i].Continuar = false;
                else
                    rpta[i].Continuar = Buscar(rpta[i].usuario, rpta[i].fecha, horaSgt.n_hor_codigo, rpta[i].recurso) != null;
                
                string foto = foto_path + "UT0" + rpta[i].usuario + ".jpg";
                
                //if (File.Exists(foto))
                if(URLExists(foto))
                    rpta[i].Foto = foto;
                else
                    rpta[i].Foto = fotoDefecto;
            }

            return rpta;
        }

        public BE.Adapters.Reserva Buscar(string usuario, DateTime fecha, int hora, int idrecurso)
        {
            return reservadao.Buscar(usuario, fecha, hora, idrecurso);
        }


        public bool CambiarAsistencia(int id)
        {
            return reservadao.CambiarAsistencia(id);
        }
    }
}
