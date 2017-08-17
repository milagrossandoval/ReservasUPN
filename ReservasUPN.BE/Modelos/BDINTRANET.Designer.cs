﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace ReservasUPN.BE.Modelos
{
    #region Contextos
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    public partial class BD_ADMUSERSEntities : ObjectContext
    {
        #region Constructores
    
        /// <summary>
        /// Inicializa un nuevo objeto BD_ADMUSERSEntities usando la cadena de conexión encontrada en la sección 'BD_ADMUSERSEntities' del archivo de configuración de la aplicación.
        /// </summary>
        public BD_ADMUSERSEntities() : base("name=BD_ADMUSERSEntities", "BD_ADMUSERSEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto BD_ADMUSERSEntities.
        /// </summary>
        public BD_ADMUSERSEntities(string connectionString) : base(connectionString, "BD_ADMUSERSEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto BD_ADMUSERSEntities.
        /// </summary>
        public BD_ADMUSERSEntities(EntityConnection connection) : base(connection, "BD_ADMUSERSEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Métodos parciales
    
        partial void OnContextCreated();
    
        #endregion
    
        #region Propiedades de ObjectSet
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        public ObjectSet<USUARIO> USUARIO
        {
            get
            {
                if ((_USUARIO == null))
                {
                    _USUARIO = base.CreateObjectSet<USUARIO>("USUARIO");
                }
                return _USUARIO;
            }
        }
        private ObjectSet<USUARIO> _USUARIO;

        #endregion

        #region Métodos AddTo
    
        /// <summary>
        /// Método desusado para agregar un nuevo objeto al EntitySet USUARIO. Considere la posibilidad de usar el método .Add de la propiedad ObjectSet&lt;T&gt; asociada.
        /// </summary>
        public void AddToUSUARIO(USUARIO uSUARIO)
        {
            base.AddObject("USUARIO", uSUARIO);
        }

        #endregion

        #region Importaciones de funciones
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        /// <param name="s_usu_login">No hay documentación de metadatos disponible.</param>
        public ObjectResult<PA_AU_CONSULTAR_SEDES_DISPONIBLES_X_USUARIO_Result> PA_AU_CONSULTAR_SEDES_DISPONIBLES_X_USUARIO(global::System.String s_usu_login)
        {
            ObjectParameter s_usu_loginParameter;
            if (s_usu_login != null)
            {
                s_usu_loginParameter = new ObjectParameter("s_usu_login", s_usu_login);
            }
            else
            {
                s_usu_loginParameter = new ObjectParameter("s_usu_login", typeof(global::System.String));
            }
    
            return base.ExecuteFunction<PA_AU_CONSULTAR_SEDES_DISPONIBLES_X_USUARIO_Result>("PA_AU_CONSULTAR_SEDES_DISPONIBLES_X_USUARIO", s_usu_loginParameter);
        }

        #endregion

    }

    #endregion

    #region Entidades
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="BD_ADMUSERSModel", Name="USUARIO")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class USUARIO : EntityObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto USUARIO.
        /// </summary>
        /// <param name="login">Valor inicial de la propiedad login.</param>
        public static USUARIO CreateUSUARIO(global::System.String login)
        {
            USUARIO uSUARIO = new USUARIO();
            uSUARIO.login = login;
            return uSUARIO;
        }

        #endregion

        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String login
        {
            get
            {
                return _login;
            }
            set
            {
                if (_login != value)
                {
                    OnloginChanging(value);
                    ReportPropertyChanging("login");
                    _login = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("login");
                    OnloginChanged();
                }
            }
        }
        private global::System.String _login;
        partial void OnloginChanging(global::System.String value);
        partial void OnloginChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String username
        {
            get
            {
                return _username;
            }
            set
            {
                OnusernameChanging(value);
                ReportPropertyChanging("username");
                _username = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("username");
                OnusernameChanged();
            }
        }
        private global::System.String _username;
        partial void OnusernameChanging(global::System.String value);
        partial void OnusernameChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> activo
        {
            get
            {
                return _activo;
            }
            set
            {
                OnactivoChanging(value);
                ReportPropertyChanging("activo");
                _activo = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("activo");
                OnactivoChanged();
            }
        }
        private Nullable<global::System.Boolean> _activo;
        partial void OnactivoChanging(Nullable<global::System.Boolean> value);
        partial void OnactivoChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String sedePredeterminada
        {
            get
            {
                return _sedePredeterminada;
            }
            set
            {
                OnsedePredeterminadaChanging(value);
                ReportPropertyChanging("sedePredeterminada");
                _sedePredeterminada = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("sedePredeterminada");
                OnsedePredeterminadaChanged();
            }
        }
        private global::System.String _sedePredeterminada;
        partial void OnsedePredeterminadaChanging(global::System.String value);
        partial void OnsedePredeterminadaChanged();

        #endregion

    
    }

    #endregion

    #region ComplexTypes
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmComplexTypeAttribute(NamespaceName="BD_ADMUSERSModel", Name="PA_AU_CONSULTAR_SEDES_DISPONIBLES_X_USUARIO_Result")]
    [DataContractAttribute(IsReference=true)]
    [Serializable()]
    public partial class PA_AU_CONSULTAR_SEDES_DISPONIBLES_X_USUARIO_Result : ComplexObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto PA_AU_CONSULTAR_SEDES_DISPONIBLES_X_USUARIO_Result.
        /// </summary>
        /// <param name="n_sede_id">Valor inicial de la propiedad n_sede_id.</param>
        /// <param name="s_sed_codigo">Valor inicial de la propiedad s_sed_codigo.</param>
        public static PA_AU_CONSULTAR_SEDES_DISPONIBLES_X_USUARIO_Result CreatePA_AU_CONSULTAR_SEDES_DISPONIBLES_X_USUARIO_Result(global::System.Int32 n_sede_id, global::System.String s_sed_codigo)
        {
            PA_AU_CONSULTAR_SEDES_DISPONIBLES_X_USUARIO_Result pA_AU_CONSULTAR_SEDES_DISPONIBLES_X_USUARIO_Result = new PA_AU_CONSULTAR_SEDES_DISPONIBLES_X_USUARIO_Result();
            pA_AU_CONSULTAR_SEDES_DISPONIBLES_X_USUARIO_Result.n_sede_id = n_sede_id;
            pA_AU_CONSULTAR_SEDES_DISPONIBLES_X_USUARIO_Result.s_sed_codigo = s_sed_codigo;
            return pA_AU_CONSULTAR_SEDES_DISPONIBLES_X_USUARIO_Result;
        }

        #endregion

        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 n_sede_id
        {
            get
            {
                return _n_sede_id;
            }
            set
            {
                Onn_sede_idChanging(value);
                ReportPropertyChanging("n_sede_id");
                _n_sede_id = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("n_sede_id");
                Onn_sede_idChanged();
            }
        }
        private global::System.Int32 _n_sede_id;
        partial void Onn_sede_idChanging(global::System.Int32 value);
        partial void Onn_sede_idChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String s_sed_codigo
        {
            get
            {
                return _s_sed_codigo;
            }
            set
            {
                Ons_sed_codigoChanging(value);
                ReportPropertyChanging("s_sed_codigo");
                _s_sed_codigo = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("s_sed_codigo");
                Ons_sed_codigoChanged();
            }
        }
        private global::System.String _s_sed_codigo;
        partial void Ons_sed_codigoChanging(global::System.String value);
        partial void Ons_sed_codigoChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String s_sed_nombre
        {
            get
            {
                return _s_sed_nombre;
            }
            set
            {
                Ons_sed_nombreChanging(value);
                ReportPropertyChanging("s_sed_nombre");
                _s_sed_nombre = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("s_sed_nombre");
                Ons_sed_nombreChanged();
            }
        }
        private global::System.String _s_sed_nombre;
        partial void Ons_sed_nombreChanging(global::System.String value);
        partial void Ons_sed_nombreChanged();

        #endregion

    }

    #endregion

    
}