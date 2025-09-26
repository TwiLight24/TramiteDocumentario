using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad.PArticulos
{
    public class UsuarioPlantilla : Intellisoft.Project.Comun.Entidad.Base
	{
        #region Variables Privadas

        private int _idUsuario = 0;
        private int _idPlantilla = 0;
        private string _nombreUsuario = string.Empty;
        private string _empresa = string.Empty;
        private string _area = string.Empty;
        private string _descripcion = string.Empty;



        List<UsuarioPlantilla> _listPlantilla = null;

        #endregion


        #region Propiedades Públicas

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public int IdPlantilla
        {
            get { return _idPlantilla; }
            set { _idPlantilla = value; }
        }
        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }
        public string Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }
        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public List<UsuarioPlantilla> ListPlantilla
        {
            get { return _listPlantilla; }
            set { _listPlantilla = value; }
        }
       #endregion

        /// <summary>
        /// Carga los datos del DataRow en la Entidad
        /// </summary>
        /// <param name="dr">Datos a cargar en la Entidad</param>
        public override void CargarEntidad(System.Data.IDataReader dr)
        {
            base.CargarEntidad(dr);


            CargarVariable(dr, "IdUsuario", out _idUsuario);
            CargarVariable(dr, "IdPlantilla", out _idPlantilla);
            CargarVariable(dr, "NombreUsuario", out _nombreUsuario);
            CargarVariable(dr, "Empresa", out _empresa);
            CargarVariable(dr, "Area", out _area);
            CargarVariable(dr, "Descripcion", out _descripcion);


        }
	}
}
