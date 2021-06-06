using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace minesweeper
{
    public partial class Form1 : Form
    {
        PictureBox[,] field;
        Stopwatch timer;
        public Form1()
        {
            timer = new Stopwatch();
            InitializeComponent();
        }
        private void GameSettings(int rows, int cols, int mines)
        {
            Game.Rows = rows;
            Game.Cols = cols;
            Game.Mines = mines;
        }
        private void SaveLastSettings(int rows, int cols, int mines)
        {
            try
            {
                FileStream file = new FileStream("config.dat", FileMode.Create);
                BinaryWriter bin_writer = new BinaryWriter(file);
                bin_writer.Write(rows);
                bin_writer.Write(cols);
                bin_writer.Write(mines);
                bin_writer.Close();
                file.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadLastSettings()
        {
            try
            {
                if (!File.Exists("config.dat"))
                    SaveLastSettings(9, 9, 10);
                FileStream file = new FileStream("config.dat", FileMode.Open);
                BinaryReader bin_reader = new BinaryReader(file);
                while (bin_reader.PeekChar() > 0)
                {
                    Game.Rows = bin_reader.ReadInt32();
                    Game.Cols = bin_reader.ReadInt32();
                    Game.Mines = bin_reader.ReadInt32();
                }
                bin_reader.Close();
                file.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PrintField()
        {
            for (int row = 0; row < Game.Rows; row++)
                for (int col = 0; col < Game.Cols; col++)
                    if (Game.board[row, col].IsRevealed)
                    {
                        if (Game.board[row, col].IsMine)
                            field[row, col].Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\assets\\mine.png");
                        else
                            field[row, col].Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\assets\\" + Game.board[row, col].NearbyMines + ".png");
                    }
                    else
                        if (Game.board[row, col].IsFlagged)
                        field[row, col].Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\assets\\flag.png");
                    else if(!Game.board[row, col].IsFlagged)
                        field[row, col].Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\assets\\tile.png");
        }
        private void NewGame()
        {
            timer.Reset();
            this.Height = Cell.Size * (Game.Cols + 2) + 14;
            this.Width = Cell.Size * Game.Rows + 16;
            Game.GenerateBoard();
            field = new PictureBox[Game.Rows, Game.Cols];
            for (int row = 0; row < Game.Rows; row++)
                for (int col = 0; col < Game.Cols; col++)
                {
                    field[row, col] = new PictureBox();
                    field[row, col].Location = new System.Drawing.Point(row * Cell.Size, (col + 1) * Cell.Size);
                    field[row, col].Height = Cell.Size;
                    field[row, col].Width = Cell.Size;
                    field[row, col].Name = "" + (row + col * Game.Rows);
                    field[row, col].MouseDown += new MouseEventHandler(cellMouseDown);
                    field[row, col].Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\assets\\tile.png");
                    this.Controls.Add(field[row, col]);
                }
        }
        private void ResetField()
        {
            for (int row = 0; row < field.GetLength(0); row++)
                for (int col = 0; col < field.GetLength(1); col++)
                    this.Controls.Remove(field[row, col]);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Cell.Size = 25;
            LoadLastSettings();
            NewGame();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetField();
            NewGame();
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetField();
            GameSettings(9, 9, 10);
            NewGame();
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetField();
            GameSettings(16, 16, 40);
            NewGame();
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetField();
            GameSettings(30, 16, 99);
            NewGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CheckWinLose(int row, int col)
        {
            if (Game.GameOver)
            {
                field[row, col].Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\assets\\boom.png");
                GameOver();
            }
            else if (Game.CorrectFlags() == Game.Mines || Game.RevealedCells() == Game.Rows * Game.Cols - Game.Mines)
                Victory();
        }
        private void GameOver()
        {
            timer.Stop();
            if (MessageBox.Show("You blew up! Try again!", "Game Over!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ResetField();
                NewGame();
            }
        }
        private void Victory()
        {
            timer.Stop();
            TimeSpan t = timer.Elapsed;
            RegisterScore regScore = new RegisterScore(t);
            regScore.ShowDialog();
            Game.Victory = true;
            if (MessageBox.Show("Congratulations! You won! Play again?", "Victory!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ResetField();
                NewGame();
            }
        }
        private void cellMouseDown(object sender, MouseEventArgs e)
        {
            if (!timer.IsRunning)
                timer.Start();
            if (!Game.GameOver && !Game.Victory)
            {
                PictureBox cell = (PictureBox)sender;
                int row = int.Parse(cell.Name) % Game.Rows;
                int col = int.Parse(cell.Name) / Game.Rows;
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        Game.RevealeCell(row, col);
                        break;
                    case MouseButtons.Right:
                        Game.FlagCell(row, col);
                        break;
                    default:
                        break;
                }
                PrintField();
                CheckWinLose(row, col);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLastSettings(Game.Rows, Game.Cols, Game.Mines);
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Custom custom = new Custom();
            custom.ShowDialog();
            if (Custom.result == DialogResult.OK)
            {
                ResetField();
                NewGame();
            }
        }

        private void leaderboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Stop();
            Times times = new Times();
            times.ShowDialog();
            timer.Start();
        }

        private void menuStrip1_MouseHover(object sender, EventArgs e)
        {
            if (this.Size.Width < 300)
                menuStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
        }

        private void menuStrip1_MouseLeave(object sender, EventArgs e)
        {
            if (this.Size.Width < 300)
                menuStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
        }
    }
}