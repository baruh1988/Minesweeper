using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minesweeper
{
    public partial class RegisterScore : Form
    {
        TimeSpan time;
        public RegisterScore(TimeSpan t)
        {
            time = t;
            InitializeComponent();
        }
        public void RegisterTime()
        {
            string name = txtName.Text;
            Times times = new Times(name, time);
            times.ShowDialog();
            Close();
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            RegisterTime();
        }
    }
}