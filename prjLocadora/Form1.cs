using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjLocadora
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void produtorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produtoras prod = new Produtoras();
            prod.Show();
        }

        private void filmesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFilmes filmes = new frmFilmes();
            filmes.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
