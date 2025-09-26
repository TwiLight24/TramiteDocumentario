using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad.PArticulos
{
    public class Plantilla : Intellisoft.Project.Comun.Entidad.Base
	{

        #region Variables Privadas

        private int _idPlantilla = 0;
        private string _descripcion = string.Empty;
        private int _idArticulo = 0;
        private string _nombreArticulo = string.Empty;
        private string _unidadMedida = string.Empty;
        private decimal _precio = 0;
        private int _cantidadTope = 0;
        private bool _activo = false;



        List<Plantilla> _listPlantilla = null;

        #endregion


        #region Propiedades Públicas

        public int IdPlantilla
        {
            get { return _idPlantilla; }
            set { _idPlantilla = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public string NombreArticulo
        {
            get { return _nombreArticulo; }
            set { _nombreArticulo = value; }
        }


        public string UnidadMedida
        {
            get { return _unidadMedida; }
            set { _unidadMedida = value; }
        }


        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }



        public int IdArticulo
        {
            get { return _idArticulo; }
            set { _idArticulo = value; }
        }

        public int CantidadTope
        {
            get { return _cantidadTope; }
            set { _cantidadTope = value; }
        }

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

        public List<Plantilla> ListPlantilla
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


            CargarVariable(dr, "IdPlantilla", out _idPlantilla);
            CargarVariable(dr, "Descripcion", out _descripcion);
            CargarVariable(dr, "IdArticulo", out _idArticulo);
            CargarVariable(dr, "NombreArticulo", out _nombreArticulo);
            CargarVariable(dr, "UnidadMedida", out _unidadMedida);
            CargarVariable(dr, "Precio", out _precio);
            CargarVariable(dr, "CantidadTope", out _cantidadTope);
            CargarVariable(dr, "Activo", out _activo);

        }
	}
}
