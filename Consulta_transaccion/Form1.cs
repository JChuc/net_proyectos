using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace Consulta_transaccion
{
    public partial class Form1 : Form
    {
        string SelectCampos = string.Empty;
        //ODBC PIXEL
        OdbcConnection ConexODBC;
        String QryODBC;
        OdbcDataAdapter RstODBC;
        DataTable TableODBC;
        String sCadConexionODBC = "Dsn=PixelSQLbase;uid=reportuser;pwd=pass";


        public Form1()
        {
            InitializeComponent();
        }

        static DataTable GetTableCampos()
        {
            DataTable TableCampos = new DataTable();
            TableCampos.Columns.Add("Campo", typeof(string));
            TableCampos.Columns.Add("Valor", typeof(string));

            TableCampos.Rows.Add("TRANSACT", "Transaccion");
            TableCampos.Rows.Add("TIMEEND", "Fecha");
            TableCampos.Rows.Add("TAX1", "Iva");
            TableCampos.Rows.Add("TAX2", "IEPS");
            TableCampos.Rows.Add("NetTotal", "SubTotal");
            TableCampos.Rows.Add("FinalTotal", "FinalTotal");
            return TableCampos;
        }

        static DataTable GetTableCondiciones()
        {
            DataTable TableCondiciones = new DataTable();
            TableCondiciones.Columns.Add("Campo", typeof(string));
            TableCondiciones.Columns.Add("Valor", typeof(string));

            TableCondiciones.Rows.Add("Igual", "Igual");
            TableCondiciones.Rows.Add("MayoroIgual", "MayoroIgual");
            TableCondiciones.Rows.Add("MenoroIgual", "MenoroIgual");
            TableCondiciones.Rows.Add("Contiene", "Contiene");
            return TableCondiciones;
        }

        private void CargaConsulta()
        {
            try
            {
                RstODBC = new OdbcDataAdapter();
                TableODBC = new DataTable();
                ConexODBC = new OdbcConnection();

                QryODBC = "Select CONVERT(VARCHAR(10), TIMEEND, 20)  AS FECHA,transact AS TRANSACCION, (Tax1able-Tax1) AS BASE_IVA, (Tax2able -Tax2) as BASE_IEPS, NetTotal AS SUBTOTAL, FinalTotal From dba.posheader where transact = " + this.TxtTransaccion.Text.Trim();
                ConexODBC.ConnectionString = sCadConexionODBC;
                RstODBC.SelectCommand = new OdbcCommand(QryODBC, ConexODBC);
                RstODBC.Fill(TableODBC);
                this.dgViewConsulta.DataSource = TableODBC;
                this.dgViewConsulta.AutoResizeColumns();
                this.dgViewConsulta.AutoResizeRows();
                this.TxtTransaccion.Clear();
                this.TxtTransaccion.Select();

            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error al Intentar consultar la Información:\n" + ex.Message.ToString(), "Pixel Reader", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            finally
            {
                RstODBC.Dispose();
                TableODBC.Dispose();
                ConexODBC.Close();
                ConexODBC.Dispose();
            }
        }

        private void BtnNuevaConsulta_Click(object sender, EventArgs e)
        {
            this.TxtTransaccion.Clear();
            this.dgViewConsulta.DataSource = null;
            this.TxtTransaccion.Select();
        }

        private void SalirbuttonCte_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            if (this.TxtTransaccion.Text.Trim() != string.Empty)
            {
                this.dgViewConsulta.DataSource = null;
                CargaConsulta();
            }
            else
            {
                MessageBox.Show("Capture el Número de Transacción", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                this.TxtTransaccion.Select();
            }
        }

    }
}
