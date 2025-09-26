namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidad;
    using System;
    using System.Data;

    public class CNUsuarios
    {
        private CDUsuarios cdUsu = new CDUsuarios();

        public bool ActualizarUsuario(CEUsuarios entity)
        {
            return CDUsuarios.ActualizarUsuario(entity);
        }

        public CEUsuarios CNobtenerUsuarioxCodigo(string Codigo)
        {
            return this.cdUsu.CDobtenerUsuarioxCodigo(Codigo);
        }

        public string CNvalidaUsuario(CEUsuarios ceUsu)
        {
            return this.cdUsu.CDvalidaUsuario(ceUsu);
        }

        public bool GuardarUsuario(CEUsuarios entity)
        {
            return CDUsuarios.GuardarUsuario(entity);
        }

        public DataTable ListarEmpleado()
        {
            return CDUsuarios.ListarEmpleado();
        }

        public DataTable ListarUsuarioById(int cod)
        {
            return CDUsuarios.ListarUsuarioById(cod);
        }

        public DataTable ListarUsuariosByCriterio(string cod)
        {
            return CDUsuarios.ListarUsuariosByCriterio(cod);
        }
    }
}

