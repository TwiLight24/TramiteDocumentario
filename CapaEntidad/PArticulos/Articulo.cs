using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad.PArticulos
{
    public class Articulo : Intellisoft.Project.Comun.Entidad.Base
    {
        private int _idArticulo = 0;
        private string _nombreArticulo = string.Empty;
        private string _unidadMedida = string.Empty;
        private decimal _precio = 0;
        private int _idUsuario = 0;
        private bool _activo = false;


        private List<Articulo> _lstArticulo = null;



        /// <summary>
        /// Lista de datos de la Entidad
        /// </summary>
        public List<Articulo> LstArticulo
        {
            get { return _lstArticulo; }
            set { _lstArticulo = value; }
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

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }


        public override void CargarEntidad(System.Data.IDataReader dr)
        {
            base.CargarEntidad(dr);

            CargarVariable(dr, "IdArticulo", out _idArticulo);
            CargarVariable(dr, "NombreArticulo", out _nombreArticulo);
            CargarVariable(dr, "UnidadMedida", out _unidadMedida);
            CargarVariable(dr, "Precio", out _precio);
            //CargarVariable(dr, "IdUsuario", out _idUsuario);
            //CargarVariable(dr, "Activo", out _activo);

        }


    }
}
