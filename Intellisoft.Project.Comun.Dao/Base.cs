using System;
using System.Collections.Generic;
using System.Web;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.ComponentModel;

namespace Intellisoft.Project.Comun.Dao
{

    /// <summary>
    /// Objeto que representa los metodos comunes de las Clase de Conexión a Datos
    /// </summary>
    public class Base : IDisposable
    {
        protected int ObtenerOrdinal(IDataReader oReader, string sColumna)
        {
            int nOrdinal = -1;

            for (int iReader = 0; iReader < oReader.FieldCount; iReader++)
            {
                if (string.Compare(oReader.GetName(iReader), sColumna, true) == 0)
                {
                    nOrdinal = oReader.GetOrdinal(sColumna);
                    break;
                }
            }

            return nOrdinal;
        }

        #region Liberacion de Recursos

        /// <summary>
        /// Libera los recursos utilizados por el objeto
        /// </summary>
        /// <param name="disposing">Indica si omite en el proceso la llamada al finalizador</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Libera los recursos utilizados por el objeto
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Finalizador del objeto
        /// </summary>
        ~Base()
        {
            this.Dispose(false);
        }

        #endregion

    }

}
