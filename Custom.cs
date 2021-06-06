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
    public partial class Custom : Form
    {
        public static DialogResult result { get; set; }
        public Custom()
        {
            InitializeComponent();
        }
        private void SetCustomGame(int rows, int cols, int mines)
        {
            Game.Rows = rows;
            Game.Cols = cols;
            Game.Mines = mines;
        }
        private void Custom_Load(object sender, EventArgs e)
        {
            result = DialogResult.Cancel;
            int maxMines = (Game.Rows * Game.Cols) / 3;
            txtCols.Text = Game.Cols.ToString();
            txtMines.Text = Game.Mines.ToString();
            txtRows.Text = Game.Rows.ToString();
        }
        private bool CheckRows(int rows)
        {
            return rows >= 9;
        }
        private bool CheckCols(int cols)
        {
            return cols >= 9;
        }
        private bool CheckMines(int mines)
        {
            int rows = int.Parse(txtRows.Text);
            int cols = int.Parse(txtCols.Text);
            int maxMines = (rows * cols) / 3;
            return mines >= 10 && mines <= maxMines;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            int rows = int.Parse(txtRows.Text);
            int cols = int.Parse(txtCols.Text);
            int mines = int.Parse(txtMines.Text);
            if (CheckRows(rows) && CheckCols(cols) && CheckMines(mines))
            {
                SetCustomGame(rows, cols, mines);
                result = DialogResult.OK;
            }
            else
            {
                if (!CheckMines(mines))
                {
                    txtMines.BackColor = Color.Red;
                    MessageBox.Show("Incorrect amount of mines", "Error");
                }
                if (!CheckRows(rows))
                {
                    txtRows.BackColor = Color.Red;
                    MessageBox.Show("Incorrect amount of rows", "Error");
                }
                if (!CheckCols(cols))
                {
                    txtCols.BackColor = Color.Red;
                    MessageBox.Show("Incorrect amount of columns", "Error");
                }
            }
            if (result == DialogResult.OK)
            {
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            result = DialogResult.Cancel;
            Close();
        }

        private void txtRows_TextChanged(object sender, EventArgs e)
        {
            if (txtCols.Text != "" && txtRows.Text != "")
            {
                txtRows.BackColor = Color.White;
                int rows = int.Parse(txtRows.Text);
                int cols = int.Parse(txtCols.Text);
                int maxMines = (rows * cols) / 3;
                label3.Text = "Mines (min 10, max " + maxMines.ToString() + ")";
            }
        }

        private void txtCols_TextChanged(object sender, EventArgs e)
        {
            if (txtCols.Text != "" && txtRows.Text != "")
            {
                txtCols.BackColor = Color.White;
                int rows = int.Parse(txtRows.Text);
                int cols = int.Parse(txtCols.Text);
                int maxMines = (rows * cols) / 3;
                label3.Text = "Mines (min 10, max " + maxMines.ToString() + ")";
            }
        }

        private void txtMines_TextChanged(object sender, EventArgs e)
        {
            txtMines.BackColor = Color.White;
        }
    }
}