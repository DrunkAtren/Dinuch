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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadGame(object sender, EventArgs e)
        {
            Apka gameWindow = new Apka();

            gameWindow.Show();
            this.Hide();
        }

        private void LoadOpcje(object sender, EventArgs e)
        {
            JakGrać gameWindow = new JakGrać();

            gameWindow.Show();
            this.Hide();
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
