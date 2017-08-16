using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.IDAO
{
    public interface IUsuarioTipoDAO
    {
        List<UsuarioTipo> Listar();
        bool Eliminar(int id);
        bool Actualizar(UsuarioTipo obj);
        bool Grabar(UsuarioTipo obj);
    }
}
