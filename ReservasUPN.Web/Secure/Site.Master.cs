using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReservasUPN.BE.Adapters;

namespace ReservasUPN.Web.Secure
{
    public partial class Site : System.Web.UI.MasterPage
    {
        private Usuario usuario = new Usuario();
        private List<string> paginasPermitidas = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] == null)
            {
                Response.Redirect("../LogOut.aspx");
            }

            if (!Page.IsPostBack)
            {

                usuario = (BE.Adapters.Usuario)Session["usuario"];
                lblUsuario.Text = usuario.NombreCompleto;
                lblTipo.Text = " - [" + usuario.Tipo.nombre + "]";

                paginasPermitidas.Add("Default.aspx");

                List<Menu> menus = Menus(usuario.tipoUsuario);
                RepeaterMenu.DataSource = menus;
                RepeaterMenu.DataBind();

                string nombrePagina = Request.Url.Segments[Request.Url.Segments.Length - 1];
                if (!paginasPermitidas.Contains(nombrePagina)) {
                    Response.Redirect("Default.aspx");
                }

            }
        }

        private List<Menu> Menus(int perfil) {
            List<Menu> rpta = new List<Menu>();
            switch (perfil) { 
                case (int)BE.Enumeraciones.TipoUsuario.ALUMNO:
                    rpta.Add(new Menu{Nombre = Menu.MENU_RESERVAS, Class=Menu.CLASS_RESERVAS });
                    break;
                case (int)BE.Enumeraciones.TipoUsuario.DOCENTE:
                    rpta.Add(new Menu{Nombre = Menu.MENU_RESERVAS, Class=Menu.CLASS_RESERVAS });
                    break;
                case (int)BE.Enumeraciones.TipoUsuario.EGRESADO:
                    rpta.Add(new Menu{Nombre = Menu.MENU_RESERVAS, Class=Menu.CLASS_RESERVAS });
                    break;
                case 100: //Administrador
                    rpta.Add(new Menu{Nombre = Menu.MENU_RECURSOS, Class=Menu.CLASS_RECURSOS });
                    rpta.Add(new Menu{Nombre = Menu.MENU_USUARIOS, Class=Menu.CLASS_USUARIOS });
                    rpta.Add(new Menu{Nombre = Menu.MENU_RESERVAS, Class=Menu.CLASS_RESERVAS });
                    rpta.Add(new Menu{Nombre = Menu.MENU_REPORTES, Class=Menu.CLASS_REPORTES });
                    break;
                case 101: //Supervisor
                    rpta.Add(new Menu{Nombre = Menu.MENU_RECURSOS, Class=Menu.CLASS_RECURSOS });
                    rpta.Add(new Menu{Nombre = Menu.MENU_USUARIOS, Class=Menu.CLASS_USUARIOS });
                    rpta.Add(new Menu{Nombre = Menu.MENU_RESERVAS, Class=Menu.CLASS_RESERVAS });
                    rpta.Add(new Menu{Nombre = Menu.MENU_REPORTES, Class=Menu.CLASS_REPORTES });
                    break;
                case 102: //Bibliotecario
                    rpta.Add(new Menu{Nombre = Menu.MENU_USUARIOS, Class=Menu.CLASS_USUARIOS });
                    rpta.Add(new Menu{Nombre = Menu.MENU_RESERVAS, Class=Menu.CLASS_RESERVAS });
                    break;
            }
            return rpta;
        }

        private List<Pagina> Paginas(int perfil, string menu) {
            List<Pagina> paginas = new List<Pagina>();
            if (menu == Menu.MENU_RECURSOS) {
                switch (perfil)
                {
                    case 100: //Administrador
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_RECURSOS  , URL=Pagina.URL_RECURSOS  });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_TIPOSRECURSO, URL = Pagina.URL_TIPOSRECURSO });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_HORASDISPONIBLES, URL = Pagina.URL_HORASDISPONIBLES });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_HORARIO, URL = Pagina.URL_HORARIO });
                        break;
                    case 101: //Supervisor
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_RECURSOS  , URL=Pagina.URL_RECURSOS  });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_TIPOSRECURSO, URL = Pagina.URL_TIPOSRECURSO });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_HORASDISPONIBLES, URL = Pagina.URL_HORASDISPONIBLES });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_HORARIO, URL = Pagina.URL_HORARIO });
                        break;
                }
            }
            else if (menu == Menu.MENU_USUARIOS)
            {
                switch (perfil)
                {
                    case 100: //Administrador
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_TIPOSUSUARIO, URL = Pagina.URL_TIPOSUSUARIO });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_USUARIOS, URL = Pagina.URL_USUARIOS });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_SANCIONES, URL = Pagina.URL_SANCIONES });
                        break;
                    case 101: //Supervisor
                       // paginas.Add(new Pagina { Nombre = Pagina.PAG_TIPOSUSUARIO, URL = Pagina.URL_TIPOSUSUARIO });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_USUARIOS, URL = Pagina.URL_USUARIOS });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_SANCIONES, URL = Pagina.URL_SANCIONES });
                        break;
                    case 102: //Bibliotecario
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_SANCIONES, URL = Pagina.URL_SANCIONES });
                        break;
                }
            }
            else if (menu == Menu.MENU_RESERVAS) {
                switch (perfil)
                {
                    case (int)BE.Enumeraciones.TipoUsuario.ALUMNO:
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_RESERVAR, URL = Pagina.URL_RESERVAR });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_MISRESERVAS, URL = Pagina.URL_MISRESERVAS });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_VERRESERVAS, URL = Pagina.URL_VERRESERVAS });
                        break;
                    case (int)BE.Enumeraciones.TipoUsuario.DOCENTE:
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_RESERVAR, URL = Pagina.URL_RESERVAR });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_MISRESERVAS, URL = Pagina.URL_MISRESERVAS });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_VERRESERVAS, URL = Pagina.URL_VERRESERVAS });
                        break;
                    case (int)BE.Enumeraciones.TipoUsuario.EGRESADO:
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_RESERVAR, URL = Pagina.URL_RESERVAR });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_MISRESERVAS, URL = Pagina.URL_MISRESERVAS });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_VERRESERVAS, URL = Pagina.URL_VERRESERVAS });
                        break;
                    case 100: //Administrador
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_RESERVAR, URL = Pagina.URL_RESERVAR });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_MISRESERVAS, URL = Pagina.URL_MISRESERVAS });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_VERRESERVAS, URL = Pagina.URL_VERRESERVAS });
                        paginas.Add(new Pagina { Nombre = "Reservar a otro", URL = Pagina.URL_RESERVAROTRO });
                        paginas.Add(new Pagina { Nombre = "Ver reservas de otro", URL = Pagina.URL_VERRESERVASOTRO });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_SEGUIMIENTO, URL = Pagina.URL_SEGUIMIENTO });
                        
                        break;
                    case 101: //Supervisor
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_RESERVAR, URL = Pagina.URL_RESERVAROTRO });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_MISRESERVAS, URL = Pagina.URL_MISRESERVAS });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_VERRESERVAS, URL = Pagina.URL_VERRESERVASOTRO });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_SEGUIMIENTO, URL = Pagina.URL_SEGUIMIENTO });
                        break;
                    case 102: //Bibliotecario
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_RESERVAR, URL = Pagina.URL_RESERVAROTRO });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_MISRESERVAS, URL = Pagina.URL_MISRESERVAS });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_VERRESERVAS, URL = Pagina.URL_VERRESERVASOTRO });
                        paginas.Add(new Pagina { Nombre = Pagina.PAG_SEGUIMIENTO, URL = Pagina.URL_SEGUIMIENTO });
                        break;
                }
            }
            else if (menu == Menu.MENU_REPORTES)
            {
                switch (perfil)
                {
                    default:
                        break;
                }
            }
            return paginas;
        }

        class Pagina{
            public string URL { get; set; }
            public string Nombre { get; set; }

            public static readonly string PAG_RECURSOS = "Recursos";
            public static readonly string PAG_TIPOSRECURSO = "Tipos de Recurso";
            public static readonly string PAG_HORASDISPONIBLES = "Horas Disponibles";
            public static readonly string PAG_HORARIO = "Horario";

            public static readonly string PAG_USUARIOS = "Usuarios";
            public static readonly string PAG_TIPOSUSUARIO = "Tipos de Usuario";
            public static readonly string PAG_SANCIONES = "Sanciones";

            public static readonly string PAG_RESERVAR = "Reservar";
            public static readonly string PAG_VERRESERVAS = "Ver Reservas";
            public static readonly string PAG_MISRESERVAS = "Mis Reservas";
            public static readonly string PAG_SEGUIMIENTO = "Seguimiento";

            public static readonly string PAG_RPTRESERVAS = "Reportede Reservas";


            public static readonly string URL_RECURSOS = "Recursos.aspx";
            public static readonly string URL_TIPOSRECURSO = "RecursoTipos.aspx";
            public static readonly string URL_HORASDISPONIBLES = "HorasDisponibles.aspx";
            public static readonly string URL_HORARIO = "RecursosHorario.aspx";

            public static readonly string URL_USUARIOS = "Usuarios.aspx";
            public static readonly string URL_TIPOSUSUARIO = "UsuarioTipos.aspx";
            public static readonly string URL_SANCIONES = "Sanciones.aspx";

            public static readonly string URL_RESERVAR = "Reservar.aspx";
            public static readonly string URL_RESERVAROTRO = "ReservarUsuario.aspx";
            public static readonly string URL_VERRESERVAS = "Historial.aspx";
            public static readonly string URL_VERRESERVASOTRO = "HistorialUsuario.aspx";
            public static readonly string URL_MISRESERVAS = "MisReservas.aspx";
            public static readonly string URL_SEGUIMIENTO = "Seguimiento.aspx";

            public static readonly string URL_RPTRESERVAS = "RptReservas.aspx";

        }

        class Menu{
            public string Class { get; set; }
            public string Nombre { get; set; }

            public static readonly string MENU_RECURSOS = "Recursos";
            public static readonly string MENU_RESERVAS = "Reservas";
            public static readonly string MENU_USUARIOS = "Usuarios";
            public static readonly string MENU_REPORTES = "Reportes";

            public static readonly string CLASS_RECURSOS = "fa fa-dashboard fa-fw";
            public static readonly string CLASS_RESERVAS = "fa fa-files-o fa-fw";
            public static readonly string CLASS_USUARIOS = "fa fa-users fa-fw";
            public static readonly string CLASS_REPORTES = "fa fa-edit fa-fw";

        }

        protected void RepeaterMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            usuario = (BE.Adapters.Usuario)Session["usuario"];
            Repeater RepeaterPage = (Repeater)e.Item.FindControl("RepeaterPage");
            HiddenField HfNombre = (HiddenField)e.Item.FindControl("HfNombre");
            List<Pagina> paginas = Paginas(usuario.tipoUsuario, HfNombre.Value);
            paginas.ForEach(p => paginasPermitidas.Add(p.URL));
            RepeaterPage.DataSource = paginas;
            RepeaterPage.DataBind();
        }

    }
}