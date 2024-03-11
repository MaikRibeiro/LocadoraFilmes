using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjLocadora
{
    public partial class Produtoras : Form
    {
        String connectionString = @"Server=;Database=;User Id=;Password=;";
        bool novo;

        public Produtoras()
        {
            InitializeComponent();
        }

        private void Produtoras_Load(object sender, EventArgs e)
        {
            btnSalvar.Enabled = false;
            txtCodProd.Enabled = false;
            txtEmailProd.Enabled = false;
            txtProd.Enabled = false;
            txtTelProd.Enabled = false;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            txtProd.Enabled = true;
            txtEmailProd.Enabled = true;
            txtTelProd.Enabled = true;
            btnExcluir.Enabled = false;
            btnPrimeiro.Enabled = false;
            btnProximo.Enabled = false;
            btnUltimo.Enabled = false;
            btnAlterar.Enabled = false;
            novo = true;
            txtProd.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (novo)
            {
                string sql = "INSERT INTO tblProdutora (nomeProd, telProd, emailProd) " +
                             "VALUES " +
                             "('" + txtProd.Text + "', '" +
                             txtTelProd.Text + "', '" +
                             txtEmailProd.Text + "')";

                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Produtora cadastrada com sucesso");
                    }

                } catch(SqlException ex)
                {
                    MessageBox.Show("Erro ao cadastrar produtora: " + ex) ;

                } finally
                {
                    conn.Close();
                }

            }
        }
    }
}
