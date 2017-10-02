using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReservasUPN.Web.App_Code;
using ReservasUPN.BL;
using Telerik.Web.UI;
using ReservasUPN.BE.Modelos;
using ReservasUPN.IBL;
using ReservasUPN.Util;
using System.Text;

namespace ReservasUPN.Web.Secure
{
    public partial class ReservarUsuario : PageAdapter
    {

        IReservaBL reservabl = new ReservaBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CmbSedes.DataSource = new SedeBL().ListarxUsuario(Usuario);
                CmbSedes.DataBind();
                DpFecha.SelectedDate = DateTime.Today;
            }
            EstiloSubmit(BtnGuardar.ClientID);
        }

        protected void CmbSedes_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            CmbTiposRecurso.DataBind();
            HfTipoHora.Value = string.Empty;
            CmbRecursos.DataBind();
            TxtCaracteristicas.Text = string.Empty;
            LblDisponibles.Text = string.Empty;
            LblMesActual.Text = string.Empty;
            LblUsadas.Text = string.Empty;
            HfDisponibles.Value = string.Empty;
            HfMesActual.Value = string.Empty;
            HfUsadas.Value = string.Empty;
            RgHorario.Rebind();
        }

        private void CalcularHorasDisponibles() {
            
            int horasUtilizadas = reservabl.HorasUtilizadas(HfUsuario.Value, Convert.ToInt32(CmbTiposRecurso.SelectedValue), DpFecha.SelectedDate.Value);
            LblUsadas.Text = "Horas Usadas: " + horasUtilizadas.ToString();
            HfUsadas.Value = horasUtilizadas.ToString();
            int horasMes = int.Parse(HfMesActual.Value);
            int horasDisponibles = horasMes - horasUtilizadas;
            LblDisponibles.Text = "Horas Disponibles: " + horasDisponibles.ToString();
            HfDisponibles.Value = horasDisponibles.ToString();
            
        }


        protected void CmbTiposRecurso_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (e.Value != "0")
            {
                int idtiporecurso = Convert.ToInt32(e.Value);
                RecursoTipo recursotipo = new RecursoTipoBL().Buscar(idtiporecurso);
                HfTipoHora.Value = recursotipo.tipoHora.ToString();
                BE.Modelos.RecursoTipoHora recursotipohora = new RecursoTipoHoraBL().Buscar(idtiporecurso, int.Parse(HfTipoUsuario.Value));
                int horasMes = recursotipohora == null ? 0 : recursotipohora.nroHoras.Value;
                LblMesActual.Text = "Horas del Mes Actual: " + horasMes.ToString();
                HfMesActual.Value = horasMes.ToString();
                if (DpFecha.SelectedDate.HasValue)
                {
                    CalcularHorasDisponibles();
                }
            }
            else
            {
                HfTipoHora.Value = string.Empty;
                TxtCaracteristicas.Text = string.Empty;
                LblDisponibles.Text = string.Empty;
                LblMesActual.Text = string.Empty;
                LblUsadas.Text = string.Empty;
                HfDisponibles.Value = string.Empty;
                HfMesActual.Value = string.Empty;
                HfUsadas.Value = string.Empty;
            }
            CmbRecursos.DataBind();
            RgHorario.Rebind();
        }

        protected void CmbRecursos_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (e.Value != "0")
            {
                int idrecurso = Convert.ToInt32(e.Value);
                BE.Modelos.Recurso recurso = new RecursoBL().Buscar(idrecurso);
                TxtCaracteristicas.Text = recurso.caracteristicas;
            }
            else
            {
                TxtCaracteristicas.Text = string.Empty;
            }
            RgHorario.Rebind();
        }

        protected void CmbTiposRecurso_DataBound(object sender, EventArgs e)
        {
            CmbTiposRecurso.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("-- Seleccione ---", "0"));
        }

        protected void CmbRecursos_DataBound(object sender, EventArgs e)
        {
            CmbRecursos.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("-- Seleccione ---", "0"));
        }

        protected void RgHorario_DataBound(object sender, EventArgs e)
        {
            if (RgHorario.MasterTableView.Items.Count > 0)
            {
                
                DateTime fechaSeleccionada = DpFecha.SelectedDate.Value;
                int tiporecursoid = Convert.ToInt32(CmbTiposRecurso.SelectedValue);

                Sancion sancion = new SancionBL().Buscar(HfUsuario.Value, fechaSeleccionada, tiporecursoid);
                RgHorario.Enabled = (sancion == null);
                if (sancion != null) { 
                    string mensaje = "No puede reservar este tipo de recurso " + CmbTiposRecurso.Text + 
                        " hasta el " + sancion.fechafin.ToString("dd/MM/yyyy") + ". "
                        + "Motivo: " + sancion.motivo + ".";
                    Alerta(mensaje);
                    return;
                }

                int diaSemana = (int)fechaSeleccionada.DayOfWeek;
                int hora;
                CheckBox chk;
                Label lbl;
                TimeSpan horafinal;
                DateTime fechaDia, fechaLunes, fechaDomingo;
                fechaLunes = DateTime.MinValue;
                fechaDomingo = DateTime.MaxValue;
                List<DateTime> fechasSemana = new List<DateTime>();
                for (int i = 1; i <= 7; i++)
                {
                    fechaDia = fechaSeleccionada.AddDays(i - diaSemana);
                    fechasSemana.Add(fechaDia);
                    if (i == 1) { fechaLunes = fechaDia; }
                    if (i == 7) { fechaDomingo = fechaDia; }
                }

                List<BE.Modelos.Reserva> reservasSemana = reservabl.Listar(Convert.ToInt32(CmbRecursos.SelectedValue), fechaLunes, fechaDomingo);

                foreach (GridDataItem item in RgHorario.MasterTableView.Items)
                {
                    hora = (int)item.GetDataKeyValue("hora");
                    horafinal = (TimeSpan)item.GetDataKeyValue("HoraFinal");
                    for (int i = 1; i <= 7; i++)
                    {
                        fechaDia = fechasSemana[i - 1];
                        chk = (CheckBox)item.FindControl("Chk" + FechaUtil.DiaSemana(i));

                        if (fechaDia.Month != fechaSeleccionada.Month) { chk.Visible = false; }
                        else if (fechaDia < DateTime.Today) { chk.Visible = false; }
                        else if (fechaDia == DateTime.Today && DateTime.Now.TimeOfDay > horafinal) { chk.Visible = false; }

                        var res = (from x in reservasSemana
                                   where x.fecha == fechaDia && x.hora == hora
                                   select x);

                        if (res.Count() == 1)
                        {
                            lbl = (Label)item.FindControl("Lbl" + FechaUtil.DiaSemana(i));
                            lbl.Text = res.First().nombreUsuario;
                            lbl.Visible = true;
                            chk.Visible = false;
                        }

                    }
                }
                BtnGuardar.Enabled = true;
            }
            else
            {
                BtnGuardar.Enabled = false;
            }
        }

        protected void DpFecha_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (e.NewDate < DateTime.Today) {
                Alerta("No se puede registrar una fecha anterior a la fecha actual");
                DpFecha.SelectedDate = e.OldDate;
                return;
            }
            RgHorario.Rebind();
        }

        private Reserva VerificarReserva(GridDataItem item, int hora, string deshora, int diaSemana, DateTime fecha)
        {
            CheckBox Chk = (CheckBox)item.FindControl("Chk" + FechaUtil.DiaSemana(diaSemana));
            TimeSpan horainicial = (TimeSpan)item.GetDataKeyValue("HoraInicio");
            TimeSpan horafinal = (TimeSpan)item.GetDataKeyValue("HoraFinal");
            Reserva reserva = null;
            if (Chk.Checked && Chk.Visible)
            {
                reserva = new Reserva
                {
                    usuario = HfUsuario.Value,
                    recurso = int.Parse(CmbRecursos.SelectedValue),
                    fecha = fecha,
                    hora = hora,
                    asistencia = null,
                    estado = true,
                    nombreUsuario = LblUsuario.Text,
                    diaSemana = (int)fecha.DayOfWeek,
                    descripcionHora = deshora,
                    inicio = fecha.Add(horainicial),
                    final = fecha.Add(horafinal),
                    usuarioReserva = Usuario.codigo,
                    nombreUsuarioReserva = Usuario.NombreCompleto
                };
            }
            return reserva;
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            bool reservar = false;
            List<Reserva> reservas = new List<Reserva>();
            int hora;
            string deshora;
            DateTime fechaSeleccionada = DpFecha.SelectedDate.Value;
            int diaSemana = (int)fechaSeleccionada.DayOfWeek;
            List<DateTime> fechaSemana = new List<DateTime>();
            for (int i = 1; i <= 7; i++)
            {
                DateTime fechaDia = fechaSeleccionada.AddDays(i - diaSemana);
                fechaSemana.Add(fechaDia);
            }
            BE.Modelos.Reserva reserva;
            foreach (GridDataItem item in RgHorario.MasterTableView.Items)
            {
                hora = (int)item.GetDataKeyValue("hora");
                deshora = (string)item.GetDataKeyValue("DesHora");
                for (int i = 1; i <= 7; i++)
                {
                    reserva = VerificarReserva(item, hora, deshora, i, fechaSemana[i - 1]);
                    if (reserva != null)
                    {
                        reservas.Add(reserva);
                        reservar |= true;
                    }
                }
            }

            if (!reservar)
            {
                Alerta("No se ha seleccionado ningún horario.");
                return;
            }

            CalcularHorasDisponibles();

            int horasUsadas = Convert.ToInt32(HfUsadas.Value);
            int horasMesActual = Convert.ToInt32(HfMesActual.Value);

            if (horasUsadas + reservas.Count > horasMesActual)
            {
                Alerta("No tiene horas disponibles suficientes para realizar esa reserva.");
                return;
            }
            
            try
            {
                bool rpta = reservabl.Grabar(reservas);
                if (rpta)
                {
                    CalcularHorasDisponibles();
                    RgHorario.Rebind();
                    Alerta("Se registró correctamente la reserva, se enviará un correo con su reserva.");
                }
            }
            catch (Exception ex)
            {
                Alerta(ex.Message);
            }

        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            var rpta = new UsuarioBL().Buscar(TxtUsuario.Text);
            if (rpta != null)
            {
                if (rpta.IdSede == int.Parse(CmbSedes.SelectedValue))
                {
                    HfUsuario.Value = rpta.codigo;
                    HfTipoUsuario.Value = rpta.tipoUsuario.ToString();
                    LblUsuario.Text = rpta.NombreCompleto;
                    PnlReserva.Visible = true;
                    ImgFoto.Visible = true;
                    BE.Modelos.Sede sede = new SedeBL().Buscar(int.Parse(CmbSedes.SelectedValue));
                    ImgFoto.ImageUrl = Util.ImagenUtil.RutaFoto(sede.nombre, rpta.codigo);
                }
            }
            else
            {
                HfUsuario.Value = string.Empty;
                LblUsuario.Text = string.Empty;
                PnlReserva.Visible = false;
                ImgFoto.Visible = false;
                Alerta("No se encontró el usuario");

            }
        }
    }
}