using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DinuchG
{
    public partial class JakGrać : Form
    {
        public JakGrać()
        {
            InitializeComponent();
        }

        private void Opcje_Load(object sender, EventArgs e)
        {

        }

        private void LoadBack(object sender, EventArgs e)
        {
            Menu gameWindow = new Menu();

            gameWindow.Show();
            this.Hide();
        }
    }
}
