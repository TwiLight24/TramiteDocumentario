namespace CapaEntidad
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;

    public class CEUsuarios
    {
        private string apemat;
        private string apepat;
        private string co;
        private string cod;
        private string dir;
        private string emp;
        private string m_dni;
        private string obs;
        private string primnom;
        private string segnom;
        private string tel;

        public string Ape_mat
        {
            get
            {
                return this.apemat;
            }
            set
            {
                this.apemat = value;
            }
        }

        public string Ape_pat
        {
            get
            {
                return this.apepat;
            }
            set
            {
                this.apepat = value;
            }
        }

        public string Correo
        {
            get
            {
                return this.co;
            }
            set
            {
                this.co = value;
            }
        }

        public string Direccion
        {
            get
            {
                return this.dir;
            }
            set
            {
                this.dir = value;
            }
        }

        public string Dni
        {
            get
            {
                return this.m_dni;
            }
            set
            {
                this.m_dni = value;
            }
        }

        public string Empresa
        {
            get
            {
                return this.emp;
            }
            set
            {
                this.emp = value;
            }
        }

        public int id
        {
            get
            {
                return Conversions.ToInteger(this.cod);
            }
            set
            {
                this.cod = Conversions.ToString(value);
            }
        }

        public string Observac
        {
            get
            {
                return this.obs;
            }
            set
            {
                this.obs = value;
            }
        }

        public string prim_nom
        {
            get
            {
                return this.primnom;
            }
            set
            {
                this.primnom = value;
            }
        }

        public string seg_nom
        {
            get
            {
                return this.segnom;
            }
            set
            {
                this.segnom = value;
            }
        }

        public string Telefono
        {
            get
            {
                return this.tel;
            }
            set
            {
                this.tel = value;
            }
        }
    }
}

