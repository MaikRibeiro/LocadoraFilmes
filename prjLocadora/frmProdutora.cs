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

            string sql = "SELECT * FROM tblProdutora";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtCodProd.Text = reader[0].ToString();
                    txtProd.Text = reader[1].ToString();
                    txtTelProd.Text = reader[2].ToString();
                    txtEmailProd.Text = reader[3].ToString();
                }
            } 
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao listar produtoras: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
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

                } 
                finally
                {
                    conn.Close();
                }
            } 
            else
            {
                string sql = "UPDATE tblProdutora " +
                                "SET nomeProd = '" + txtProd.Text +
                                "', emailProd = '" + txtEmailProd.Text + 
                                "', telProd = '" + txtTelProd.Text +
                                "' WHERE id = " + txtCodProd.Text;

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if(i > 0)
                    {
                        MessageBox.Show("Produtora alterada com sucesso");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro ao alterar produtora: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
            btnSalvar.Enabled = false;
            btnNovo.Enabled = true;
            txtProd.Enabled = false;
            txtEmailProd.Enabled = false;
            txtTelProd.Enabled = false;
            btnExcluir.Enabled = true;
            btnPrimeiro.Enabled = true;
            btnProximo.Enabled = true;
            btnUltimo.Enabled = true;
            btnAlterar.Enabled = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM tblProdutora " +
                            "WHERE id = " + txtCodProd.Text;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if(i > 0)
                {
                    MessageBox.Show("Produtora excluída com sucesso");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            novo = false;
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            txtProd.Enabled = true;
            txtEmailProd.Enabled = true;
            txtTelProd.Enabled = true;
        }
    }
}
