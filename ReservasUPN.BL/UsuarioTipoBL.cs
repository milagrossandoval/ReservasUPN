using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IBL;
using ReservasUPN.IDAO;
using ReservasUPN.DAO;

namespace ReservasUPN.BL
{
    public class UsuarioTipoBL : IUsuarioTipoBL
    {
        private IUsuarioTipoDAO usuariotipodao = UsuarioTipoDAO.Instance;

        public List<BE.Modelos.UsuarioTipo> Listar()
        {
            return usuariotipodao.Listar();
        }
        
        public bool Eliminar(int id)
        {
            return usuariotipodao.Eliminar(id);
        }

        public bool Actualizar(BE.Modelos.UsuarioTipo obj)
        {
            return usuariotipodao.Actualizar(obj);
        }

        public bool Grabar(BE.Modelos.UsuarioTipo obj)
        {
            return usuariotipodao.Grabar(obj);
        }
    }
}
