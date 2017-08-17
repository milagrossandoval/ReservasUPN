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
#region Metadatos de relaciones en EDM

[assembly: EdmRelationshipAttribute("BD_RESERVASModel", "FK_Usuario_TipoUsuario", "UsuarioTipo", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(ReservasUPN.BE.Modelos.UsuarioTipo), "Usuario", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(ReservasUPN.BE.Modelos.Usuario), true)]

#endregion

namespace ReservasUPN.BE.Modelos
{
    #region Contextos
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    public partial class BD_RESERVASEntities : ObjectContext
    {
        #region Constructores
    
        /// <summary>
        /// Inicializa un nuevo objeto BD_RESERVASEntities usando la cadena de conexión encontrada en la sección 'BD_RESERVASEntities' del archivo de configuración de la aplicación.
        /// </summary>
        public BD_RESERVASEntities() : base("name=BD_RESERVASEntities", "BD_RESERVASEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto BD_RESERVASEntities.
        /// </summary>
        public BD_RESERVASEntities(string connectionString) : base(connectionString, "BD_RESERVASEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto BD_RESERVASEntities.
        /// </summary>
        public BD_RESERVASEntities(EntityConnection connection) : base(connection, "BD_RESERVASEntities")
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
        public ObjectSet<UsuarioTipo> UsuarioTipo
        {
            get
            {
                if ((_UsuarioTipo == null))
                {
                    _UsuarioTipo = base.CreateObjectSet<UsuarioTipo>("UsuarioTipo");
                }
                return _UsuarioTipo;
            }
        }
        private ObjectSet<UsuarioTipo> _UsuarioTipo;
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        public ObjectSet<Usuario> Usuario
        {
            get
            {
                if ((_Usuario == null))
                {
                    _Usuario = base.CreateObjectSet<Usuario>("Usuario");
                }
                return _Usuario;
            }
        }
        private ObjectSet<Usuario> _Usuario;

        #endregion

        #region Métodos AddTo
    
        /// <summary>
        /// Método desusado para agregar un nuevo objeto al EntitySet UsuarioTipo. Considere la posibilidad de usar el método .Add de la propiedad ObjectSet&lt;T&gt; asociada.
        /// </summary>
        public void AddToUsuarioTipo(UsuarioTipo usuarioTipo)
        {
            base.AddObject("UsuarioTipo", usuarioTipo);
        }
    
        /// <summary>
        /// Método desusado para agregar un nuevo objeto al EntitySet Usuario. Considere la posibilidad de usar el método .Add de la propiedad ObjectSet&lt;T&gt; asociada.
        /// </summary>
        public void AddToUsuario(Usuario usuario)
        {
            base.AddObject("Usuario", usuario);
        }

        #endregion

        #region Importaciones de funciones
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        /// <param name="p_CODIGO">No hay documentación de metadatos disponible.</param>
        public ObjectResult<PA_SELECT_USUARIOS_X_CODIGO_Result> PA_SELECT_USUARIOS_X_CODIGO(global::System.String p_CODIGO)
        {
            ObjectParameter p_CODIGOParameter;
            if (p_CODIGO != null)
            {
                p_CODIGOParameter = new ObjectParameter("P_CODIGO", p_CODIGO);
            }
            else
            {
                p_CODIGOParameter = new ObjectParameter("P_CODIGO", typeof(global::System.String));
            }
    
            return base.ExecuteFunction<PA_SELECT_USUARIOS_X_CODIGO_Result>("PA_SELECT_USUARIOS_X_CODIGO", p_CODIGOParameter);
        }

        #endregion

    }

    #endregion

    #region Entidades
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="BD_RESERVASModel", Name="Usuario")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Usuario : EntityObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto Usuario.
        /// </summary>
        /// <param name="id">Valor inicial de la propiedad id.</param>
        /// <param name="tipoUsuario">Valor inicial de la propiedad tipoUsuario.</param>
        /// <param name="codigo">Valor inicial de la propiedad codigo.</param>
        /// <param name="estado">Valor inicial de la propiedad estado.</param>
        public static Usuario CreateUsuario(global::System.Int32 id, global::System.Int32 tipoUsuario, global::System.String codigo, global::System.Boolean estado)
        {
            Usuario usuario = new Usuario();
            usuario.id = id;
            usuario.tipoUsuario = tipoUsuario;
            usuario.codigo = codigo;
            usuario.estado = estado;
            return usuario;
        }

        #endregion

        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int32 _id;
        partial void OnidChanging(global::System.Int32 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 tipoUsuario
        {
            get
            {
                return _tipoUsuario;
            }
            set
            {
                OntipoUsuarioChanging(value);
                ReportPropertyChanging("tipoUsuario");
                _tipoUsuario = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("tipoUsuario");
                OntipoUsuarioChanged();
            }
        }
        private global::System.Int32 _tipoUsuario;
        partial void OntipoUsuarioChanging(global::System.Int32 value);
        partial void OntipoUsuarioChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                OncodigoChanging(value);
                ReportPropertyChanging("codigo");
                _codigo = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("codigo");
                OncodigoChanged();
            }
        }
        private global::System.String _codigo;
        partial void OncodigoChanging(global::System.String value);
        partial void OncodigoChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean estado
        {
            get
            {
                return _estado;
            }
            set
            {
                OnestadoChanging(value);
                ReportPropertyChanging("estado");
                _estado = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("estado");
                OnestadoChanged();
            }
        }
        private global::System.Boolean _estado;
        partial void OnestadoChanging(global::System.Boolean value);
        partial void OnestadoChanged();

        #endregion

    
        #region Propiedades de navegación
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BD_RESERVASModel", "FK_Usuario_TipoUsuario", "UsuarioTipo")]
        public UsuarioTipo UsuarioTipo
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UsuarioTipo>("BD_RESERVASModel.FK_Usuario_TipoUsuario", "UsuarioTipo").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UsuarioTipo>("BD_RESERVASModel.FK_Usuario_TipoUsuario", "UsuarioTipo").Value = value;
            }
        }
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<UsuarioTipo> UsuarioTipoReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UsuarioTipo>("BD_RESERVASModel.FK_Usuario_TipoUsuario", "UsuarioTipo");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<UsuarioTipo>("BD_RESERVASModel.FK_Usuario_TipoUsuario", "UsuarioTipo", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="BD_RESERVASModel", Name="UsuarioTipo")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class UsuarioTipo : EntityObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto UsuarioTipo.
        /// </summary>
        /// <param name="id">Valor inicial de la propiedad id.</param>
        /// <param name="nombre">Valor inicial de la propiedad nombre.</param>
        /// <param name="estado">Valor inicial de la propiedad estado.</param>
        public static UsuarioTipo CreateUsuarioTipo(global::System.Int32 id, global::System.String nombre, global::System.Boolean estado)
        {
            UsuarioTipo usuarioTipo = new UsuarioTipo();
            usuarioTipo.id = id;
            usuarioTipo.nombre = nombre;
            usuarioTipo.estado = estado;
            return usuarioTipo;
        }

        #endregion

        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int32 _id;
        partial void OnidChanging(global::System.Int32 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                OnnombreChanging(value);
                ReportPropertyChanging("nombre");
                _nombre = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("nombre");
                OnnombreChanged();
            }
        }
        private global::System.String _nombre;
        partial void OnnombreChanging(global::System.String value);
        partial void OnnombreChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean estado
        {
            get
            {
                return _estado;
            }
            set
            {
                OnestadoChanging(value);
                ReportPropertyChanging("estado");
                _estado = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("estado");
                OnestadoChanged();
            }
        }
        private global::System.Boolean _estado;
        partial void OnestadoChanging(global::System.Boolean value);
        partial void OnestadoChanged();

        #endregion

    
        #region Propiedades de navegación
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BD_RESERVASModel", "FK_Usuario_TipoUsuario", "Usuario")]
        public EntityCollection<Usuario> Usuario
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Usuario>("BD_RESERVASModel.FK_Usuario_TipoUsuario", "Usuario");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Usuario>("BD_RESERVASModel.FK_Usuario_TipoUsuario", "Usuario", value);
                }
            }
        }

        #endregion

    }

    #endregion

    #region ComplexTypes
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmComplexTypeAttribute(NamespaceName="BD_RESERVASModel", Name="PA_SELECT_USUARIOS_X_CODIGO_Result")]
    [DataContractAttribute(IsReference=true)]
    [Serializable()]
    public partial class PA_SELECT_USUARIOS_X_CODIGO_Result : ComplexObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto PA_SELECT_USUARIOS_X_CODIGO_Result.
        /// </summary>
        /// <param name="id">Valor inicial de la propiedad id.</param>
        /// <param name="codigo">Valor inicial de la propiedad codigo.</param>
        /// <param name="estado">Valor inicial de la propiedad estado.</param>
        /// <param name="tipoUsuario">Valor inicial de la propiedad tipoUsuario.</param>
        /// <param name="nombreTipo">Valor inicial de la propiedad nombreTipo.</param>
        public static PA_SELECT_USUARIOS_X_CODIGO_Result CreatePA_SELECT_USUARIOS_X_CODIGO_Result(global::System.Int32 id, global::System.String codigo, global::System.Boolean estado, global::System.Int32 tipoUsuario, global::System.String nombreTipo)
        {
            PA_SELECT_USUARIOS_X_CODIGO_Result pA_SELECT_USUARIOS_X_CODIGO_Result = new PA_SELECT_USUARIOS_X_CODIGO_Result();
            pA_SELECT_USUARIOS_X_CODIGO_Result.id = id;
            pA_SELECT_USUARIOS_X_CODIGO_Result.codigo = codigo;
            pA_SELECT_USUARIOS_X_CODIGO_Result.estado = estado;
            pA_SELECT_USUARIOS_X_CODIGO_Result.tipoUsuario = tipoUsuario;
            pA_SELECT_USUARIOS_X_CODIGO_Result.nombreTipo = nombreTipo;
            return pA_SELECT_USUARIOS_X_CODIGO_Result;
        }

        #endregion

        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                OnidChanging(value);
                ReportPropertyChanging("id");
                _id = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("id");
                OnidChanged();
            }
        }
        private global::System.Int32 _id;
        partial void OnidChanging(global::System.Int32 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                OncodigoChanging(value);
                ReportPropertyChanging("codigo");
                _codigo = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("codigo");
                OncodigoChanged();
            }
        }
        private global::System.String _codigo;
        partial void OncodigoChanging(global::System.String value);
        partial void OncodigoChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String nombreCompleto
        {
            get
            {
                return _nombreCompleto;
            }
            set
            {
                OnnombreCompletoChanging(value);
                ReportPropertyChanging("nombreCompleto");
                _nombreCompleto = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("nombreCompleto");
                OnnombreCompletoChanged();
            }
        }
        private global::System.String _nombreCompleto;
        partial void OnnombreCompletoChanging(global::System.String value);
        partial void OnnombreCompletoChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String codigoSede
        {
            get
            {
                return _codigoSede;
            }
            set
            {
                OncodigoSedeChanging(value);
                ReportPropertyChanging("codigoSede");
                _codigoSede = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("codigoSede");
                OncodigoSedeChanged();
            }
        }
        private global::System.String _codigoSede;
        partial void OncodigoSedeChanging(global::System.String value);
        partial void OncodigoSedeChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean estado
        {
            get
            {
                return _estado;
            }
            set
            {
                OnestadoChanging(value);
                ReportPropertyChanging("estado");
                _estado = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("estado");
                OnestadoChanged();
            }
        }
        private global::System.Boolean _estado;
        partial void OnestadoChanging(global::System.Boolean value);
        partial void OnestadoChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 tipoUsuario
        {
            get
            {
                return _tipoUsuario;
            }
            set
            {
                OntipoUsuarioChanging(value);
                ReportPropertyChanging("tipoUsuario");
                _tipoUsuario = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("tipoUsuario");
                OntipoUsuarioChanged();
            }
        }
        private global::System.Int32 _tipoUsuario;
        partial void OntipoUsuarioChanging(global::System.Int32 value);
        partial void OntipoUsuarioChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String nombreTipo
        {
            get
            {
                return _nombreTipo;
            }
            set
            {
                OnnombreTipoChanging(value);
                ReportPropertyChanging("nombreTipo");
                _nombreTipo = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("nombreTipo");
                OnnombreTipoChanged();
            }
        }
        private global::System.String _nombreTipo;
        partial void OnnombreTipoChanging(global::System.String value);
        partial void OnnombreTipoChanged();

        #endregion

    }

    #endregion

    
}