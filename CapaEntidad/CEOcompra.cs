namespace CapaEntidad
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;

    public class CEOcompra
    {
        private int baseov;
        private int baseovlin;
        private string codcli;
        private string descli;
        private DateTime docdate;
        private int docent;
        private int docnu;
        private string docto;
        private string dscrip;
        private string igv;
        private string itemc;
        private int linenu;
        private string linestat;
        private double lineto;
        private string moneda;
        private string ordcomp;
        private string prec;
        private string quant;
        private string ru;

        public int baseentry
        {
            get
            {
                return this.baseov;
            }
            set
            {
                this.baseov = value;
            }
        }

        public int baseline
        {
            get
            {
                return this.baseovlin;
            }
            set
            {
                this.baseovlin = value;
            }
        }

        public string cliente
        {
            get
            {
                return this.descli;
            }
            set
            {
                this.descli = value;
            }
        }

        public string Codigo
        {
            get
            {
                return this.codcli;
            }
            set
            {
                this.codcli = value;
            }
        }

        public string currency
        {
            get
            {
                return this.moneda;
            }
            set
            {
                this.moneda = value;
            }
        }

        public int docentry
        {
            get
            {
                return this.docent;
            }
            set
            {
                this.docent = value;
            }
        }

        public int docnum
        {
            get
            {
                return this.docnu;
            }
            set
            {
                this.docnu = value;
            }
        }

        public decimal doctotal
        {
            get
            {
                return Conversions.ToDecimal(this.docto);
            }
            set
            {
                this.docto = Conversions.ToString(value);
            }
        }

        public string dscription
        {
            get
            {
                return this.dscrip;
            }
            set
            {
                this.dscrip = value;
            }
        }

        public DateTime fechadoc
        {
            get
            {
                return this.docdate;
            }
            set
            {
                this.docdate = value;
            }
        }

        public string itemcode
        {
            get
            {
                return this.itemc;
            }
            set
            {
                this.itemc = value;
            }
        }

        public int linenum
        {
            get
            {
                return this.linenu;
            }
            set
            {
                this.linenu = value;
            }
        }

        public string linestatus
        {
            get
            {
                return this.linestat;
            }
            set
            {
                this.linestat = value;
            }
        }

        public double linetotal
        {
            get
            {
                return this.lineto;
            }
            set
            {
                this.lineto = value;
            }
        }

        public string ordencompra
        {
            get
            {
                return this.ordcomp;
            }
            set
            {
                this.ordcomp = value;
            }
        }

        public decimal price
        {
            get
            {
                return Conversions.ToDecimal(this.prec);
            }
            set
            {
                this.prec = Conversions.ToString(value);
            }
        }

        public decimal quantity
        {
            get
            {
                return Conversions.ToDecimal(this.quant);
            }
            set
            {
                this.quant = Conversions.ToString(value);
            }
        }

        public string ruc
        {
            get
            {
                return this.ru;
            }
            set
            {
                this.ru = value;
            }
        }

        public decimal vatsum
        {
            get
            {
                return Conversions.ToDecimal(this.igv);
            }
            set
            {
                this.igv = Conversions.ToString(value);
            }
        }
    }
}

