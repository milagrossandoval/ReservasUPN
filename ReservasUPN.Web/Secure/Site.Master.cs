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
                    rpta.Add(new Menu{Nombre = "Reservas", Class="fa fa-files-o fa-fw" });
                    break;
                case (int)BE.Enumeraciones.TipoUsuario.DOCENTE:
                    rpta.Add(new Menu{Nombre = "Reservas", Class="fa fa-files-o fa-fw" });
                    break;
                case (int)BE.Enumeraciones.TipoUsuario.EGRESADO:
                    rpta.Add(new Menu{Nombre = "Reservas", Class="fa fa-files-o fa-fw" });
                    break;
                case 100: //Administrador
                    rpta.Add(new Menu{Nombre = "Recursos", Class="fa fa-dashboard fa-fw" });
                    rpta.Add(new Menu{Nombre = "Usuarios", Class="fa fa-users fa-fw" });
                    rpta.Add(new Menu{Nombre = "Reservas", Class="fa fa-files-o fa-fw" });
                    rpta.Add(new Menu{Nombre = "Reportes", Class="fa fa-edit fa-fw" });
                    break;
                case 101: //Supervisor
                    rpta.Add(new Menu{Nombre = "Recursos", Class="fa fa-dashboard fa-fw" });
                    rpta.Add(new Menu{Nombre = "Usuarios", Class="fa fa-users fa-fw" });
                    rpta.Add(new Menu{Nombre = "Reservas", Class="fa fa-files-o fa-fw" });
                    rpta.Add(new Menu{Nombre = "Reportes", Class="fa fa-edit fa-fw" });
                    break;
                case 102: //Bibliotecario
                    rpta.Add(new Menu{Nombre = "Usuarios", Class="fa fa-users fa-fw" });
                    rpta.Add(new Menu{Nombre = "Reservas", Class="fa fa-files-o fa-fw" });
                    break;
            }
            return rpta;
        }

        private List<Pagina> Paginas(int perfil, string menu) {
            List<Pagina> paginas = new List<Pagina>();
            if (menu == "Recursos") {
                switch (perfil)
                {
                    case 100: //Administrador
                        paginas.Add(new Pagina { Nombre = "Gestión Recursos" , URL="Recursos.aspx" });
                        paginas.Add(new Pagina { Nombre = "Gestión Tipos de Recursos", URL = "RecursosTipo.aspx" });
                        paginas.Add(new Pagina { Nombre = "Disponibilidad Recursos", URL = "RecursoTipoHora.aspx" });
                        paginas.Add(new Pagina { Nombre = "Horario Disponible de Recurso", URL = "RecursosHorario.aspx" });
                        break;
                    case 101: //Supervisor
                        paginas.Add(new Pagina { Nombre = "Gestión Recursos" , URL="Recursos.aspx" });
                        paginas.Add(new Pagina { Nombre = "Gestión Tipos de Recursos", URL = "RecursosTipo.aspx" });
                        paginas.Add(new Pagina { Nombre = "Disponibilidad Recursos", URL = "RecursoTipoHora.aspx" });
                        paginas.Add(new Pagina { Nombre = "Horario Disponible de Recurso", URL = "RecursosHorario.aspx" });
                        break;
                }
            }
            else if (menu == "Usuarios")
            {
                switch (perfil)
                {
                    case 100: //Administrador
                        paginas.Add(new Pagina { Nombre = "Gestión Tipos de Usuario", URL = "UsuariosTipo.aspx" });
                        paginas.Add(new Pagina { Nombre = "Gestión Usuarios", URL = "Usuarios.aspx" });
                        paginas.Add(new Pagina { Nombre = "Sanciones", URL = "Sanciones.aspx" });
                        break;
                    case 101: //Supervisor
                        paginas.Add(new Pagina { Nombre = "Gestión Tipos de Usuario", URL = "UsuariosTipo.aspx" });
                        paginas.Add(new Pagina { Nombre = "Gestión Usuarios", URL = "Usuarios.aspx" });
                        paginas.Add(new Pagina { Nombre = "Sanciones", URL = "Sanciones.aspx" });
                        break;
                    case 102: //Bibliotecario
                        paginas.Add(new Pagina { Nombre = "Sanciones", URL = "Sanciones.aspx" });
                        break;
                }
            }
            else if (menu == "Reservas") {
                paginas.Add(new Pagina { Nombre = "Reservas Múltiples", URL = "Reservas.aspx" });
                paginas.Add(new Pagina { Nombre = "Mis Reservas", URL = "MisReservas.aspx" });
                paginas.Add(new Pagina { Nombre = "Historial", URL = "Historial.aspx" });
                switch (perfil)
                {
                    case 100: //Administrador
                        paginas.Add(new Pagina { Nombre = "Seguimiento", URL = "Seguimiento.aspx" });
                        break;
                    case 101: //Supervisor
                        paginas.Add(new Pagina { Nombre = "Seguimiento", URL = "Seguimiento.aspx" });
                        break;
                    case 102: //Bibliotecario
                        paginas.Add(new Pagina { Nombre = "Seguimiento", URL = "Seguimiento.aspx" });
                        break;
                }
            }
            else if (menu == "Reportes")
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
        }

        class Menu{
            public string Class { get; set; }
            public string Nombre { get; set; }
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