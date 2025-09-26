using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad.PArticulos
{
    public class Periodo : Intellisoft.Project.Comun.Entidad.Base
	{
        private int _idPeriodo = 0;
        private string _descripcion = string.Empty;
        private DateTime _fechaInicio = DateTime.MinValue;
        private DateTime _fechaFin = DateTime.MinValue;



        private List<Periodo> _lstPeriodo = null;



        /// <summary>
        /// Lista de datos de la Entidad
        /// </summary>
        public List<Periodo> LstPeriodo
        {
            get { return _lstPeriodo; }
            set { _lstPeriodo = value; }
        }

        public int IdPeriodo
        {
            get { return _idPeriodo; }
            set { _idPeriodo = value; }
        }


        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }


        public DateTime FechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }

        public DateTime FechaFin
        {
            get { return _fechaFin; }
            set { _fechaFin = value; }
        }

               public override void CargarEntidad(System.Data.IDataReader dr)
        {
            base.CargarEntidad(dr);


            CargarVariable(dr, "IdPeriodo", out _idPeriodo);
            CargarVariable(dr, "Descripcion", out _descripcion);
            CargarVariable(dr, "FechaInicio", out _fechaInicio);
            CargarVariable(dr, "FechaFin", out _fechaFin);
            //CargarVariable(dr, "IdUsuario", out _idUsuario);
            //CargarVariable(dr, "Activo", out _activo);

        }


	}
}
