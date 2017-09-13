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

namespace ReservasUPN.Web.Secure
{
    public partial class Reservar : PageAdapter
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
            int horasUtilizadas = reservabl.HorasUtilizadas(Usuario.codigo, Convert.ToInt32(CmbTiposRecurso.SelectedValue), DpFecha.SelectedDate.Value);
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
                BE.Modelos.RecursoTipoHora recursotipohora = new RecursoTipoHoraBL().Buscar(idtiporecurso, Usuario.tipoUsuario);
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

        private String Columna(int i)
        {
            switch (i)
            {
                case 1:
                    return "Lunes";
                case 2:
                    return "Martes";
                case 3:
                    return "Miercoles";
                case 4:
                    return "Jueves";
                case 5:
                    return "Viernes";
                case 6:
                    return "Sabado";
                case 7:
                    return "Domingo";
            }
            return "";
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
                        chk = (CheckBox)item.FindControl("Chk" + Columna(i));

                        if (fechaDia.Month != fechaSeleccionada.Month) { chk.Visible = false; }
                        else if (fechaDia < DateTime.Today) { chk.Visible = false; }
                        else if (fechaDia == DateTime.Today && DateTime.Now.TimeOfDay > horafinal) { chk.Visible = false; }

                        var res = (from x in reservasSemana
                                   where x.fecha == fechaDia && x.hora == hora
                                   select x);

                        if (res.Count() == 1)
                        {
                            lbl = (Label)item.FindControl("Lbl" + Columna(i));
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
            RgHorario.Rebind();
        }

        private Reserva VerificarReserva(GridDataItem item, int hora, string deshora, int diaSemana, DateTime fecha)
        {
            CheckBox Chk = (CheckBox)item.FindControl("Chk" + Columna(diaSemana));
            Reserva reserva = null;
            if (Chk.Checked && Chk.Visible)
            {
                reserva = new Reserva
                {
                    usuario = Usuario.codigo,
                    recurso = int.Parse(CmbRecursos.SelectedValue),
                    fecha = fecha,
                    hora = hora,
                    asistencia = null,
                    estado = true,
                    nombreUsuario = Usuario.NombreCompleto,
                    diaSemana = (int)fecha.DayOfWeek,
                    descripcionHora = deshora
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
                alerta("No se ha seleccionado ningún horario.");
                return;
            }

            CalcularHorasDisponibles();

            int horasUsadas = Convert.ToInt32(HfUsadas.Value);
            int horasMesActual = Convert.ToInt32(HfMesActual.Value);

            if (horasUsadas + reservas.Count > horasMesActual)
            {
                alerta("No tiene horas disponibles suficientes para realizar esa reserva.");
                return;
            }

            try
            {
                bool rpta = reservabl.Grabar(reservas);
                if (rpta)
                {
                    CalcularHorasDisponibles();
                    RgHorario.Rebind();
                    alerta("Se registró correctamente la reserva, se enviará un correo con su reserva.");
                }
            }
            catch (Exception ex)
            {
                alerta(ex.Message);
            }

        }
    }
}