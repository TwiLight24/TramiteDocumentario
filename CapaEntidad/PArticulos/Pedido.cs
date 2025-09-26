using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad.PArticulos
{
    public class Pedido : Intellisoft.Project.Comun.Entidad.Base
	{
        private int _idPedido = 0;
        private int _idArticulo = 0;
        private string _nombreArticulo = string.Empty;
        private string _unidadMedida = string.Empty;
        private decimal _precio = 0;
        private decimal _total = 0;
        private int _cantidad = 0;
        private decimal _totalPedido = 0;
        private string _estado;


        private List<Pedido> _lstPedido = null;



        /// <summary>
        /// Lista de datos de la Entidad
        /// </summary>
        public List<Pedido> LstPedido
        {
            get { return _lstPedido; }
            set { _lstPedido = value; }
        }

        public string NombreArticulo
        {
            get { return _nombreArticulo; }
            set { _nombreArticulo = value; }
        }

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
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


        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }



        public int IdArticulo
        {
            get { return _idArticulo; }
            set { _idArticulo = value; }
        }

        public int IdPedido
        {
            get { return _idPedido; }
            set { _idPedido = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public decimal TotalPedido
        {
            get { return _totalPedido; }
            set { _totalPedido = value; }
        }


        public override void CargarEntidad(System.Data.IDataReader dr)
        {
            base.CargarEntidad(dr);

            CargarVariable(dr, "IdArticulo", out _idArticulo);
            CargarVariable(dr, "IdPedido", out _idPedido);
            CargarVariable(dr, "NombreArticulo", out _nombreArticulo);
            CargarVariable(dr, "UnidadMedida", out _unidadMedida);
            CargarVariable(dr, "Precio", out _precio);
            CargarVariable(dr, "Cantidad", out _cantidad);
            CargarVariable(dr, "Total", out _total);
            CargarVariable(dr, "TotalPedido", out _totalPedido);
            CargarVariable(dr, "Estado", out _estado);

            

        }


	}
}
