using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace minesweeper
{
    public partial class Times : Form
    {
        Score[] Easy;
        Score[] Normal;
        Score[] Hard;
        public Times()
        {
            Easy = new Score[10];
            Normal = new Score[10];
            Hard = new Score[10];
            CheckScoreFile();
            InitializeComponent();
        }
        public Times(string name, TimeSpan time) : base()
        {
            Easy = new Score[10];
            Normal = new Score[10];
            Hard = new Score[10];
            CheckScoreFile();
            InitializeComponent();
            Score newScore = new Score(name, time);
            AddScore(newScore);
        }
        private void AddScore(Score newScore)
        {
            SortScores();
            switch (newScore.Difficulty)
            {
                case "Easy":
                    AddScore(Easy, newScore);
                    break;
                case "Normal":
                    AddScore(Normal, newScore);
                    break;
                case "Hard":
                    AddScore(Hard, newScore);
                    break;
                default:
                    break;
            }
        }
        private void AddScore(Score[] arr, Score newScore)
        {
            int i;
            Score[] temp = new Score[11];
            for (i = 0; i < arr.Length; i++)
                temp[i] = arr[i];
            temp[i] = newScore;
            SortScores(temp);
            for (i = 0; i < arr.Length; i++)
                arr[i] = temp[i];
        }
        public void  CheckScoreFile()
        {
            if (!File.Exists("scores.bin"))
            {
                for (int i = 0; i < Easy.Length; i++)
                {
                    Easy[i] = new Score("PH", "99:99:99", "Easy");
                    Normal[i] = new Score("PH", "99:99:99", "Normal");
                    Hard[i] = new Score("PH", "99:99:99", "Hard");
                }
                SaveScores();
            }
            else
                GetScores();
        }
        private void SortScores()
        {
            Score temp;
            for (int i = 0; i < Easy.Length - 1; i++)
                for (int j = i + 1; j < Easy.Length; j++)
                {
                    if (string.Compare(Easy[i].Time, Easy[j].Time) == 1)
                    {
                        temp = Easy[j];
                        Easy[j] = Easy[i];
                        Easy[i] = temp;
                    }
                    if (string.Compare(Normal[i].Time, Normal[j].Time) == 1)
                    {
                        temp = Normal[j];
                        Normal[j] = Normal[i];
                        Normal[i] = temp;
                    }
                    if (string.Compare(Hard[i].Time, Hard[j].Time) == 1)
                    {
                        temp = Hard[j];
                        Hard[j] = Hard[i];
                        Hard[i] = temp;
                    }
                }
        }
        private void SortScores(Score[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    if (string.Compare(arr[i].Time, arr[j].Time) == 1)
                    {
                        Score temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
        }
        public void GetScores()
        {
            string name;
            string time;
            string diff;
            int count = 0;
            try
            {
                FileStream file = new FileStream("scores.bin", FileMode.Open);
                BinaryReader bin_reader = new BinaryReader(file);
                while (bin_reader.PeekChar() > 0)
                {
                    name = bin_reader.ReadString();
                    time = bin_reader.ReadString();
                    diff = bin_reader.ReadString();
                    if (count >= 0 && count <= 9)
                        Easy[count] = new Score(name, time, diff);
                    else if (count >= 10 && count <= 19)
                        Normal[count - 10] = new Score(name, time, diff);
                    else
                        Hard[count - 20] = new Score(name, time, diff);
                    count++;
                }
                bin_reader.Close();
                file.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SaveScores()
        {
            SortScores();
            try
            {
                FileStream file = new FileStream("scores.bin", FileMode.Create);
                BinaryWriter bin_writer = new BinaryWriter(file);
                for (int i = 0; i < 30; i++)
                {
                    if (i >= 0 && i <= 9)
                    {
                        bin_writer.Write(Easy[i].Name);
                        bin_writer.Write(Easy[i].Time);
                        bin_writer.Write(Easy[i].Difficulty);
                    }
                    else if (i >= 10 && i <= 19)
                    {
                        bin_writer.Write(Normal[i - 10].Name);
                        bin_writer.Write(Normal[i - 10].Time);
                        bin_writer.Write(Normal[i - 10].Difficulty);
                    }
                    else
                    {
                        bin_writer.Write(Hard[i - 20].Name);
                        bin_writer.Write(Hard[i - 20].Time);
                        bin_writer.Write(Hard[i - 20].Difficulty);
                    }
                }
                bin_writer.Close();
                file.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AddScoreLabel(int i, string type)
        {
            Label name = new Label();
            Label time = new Label();
            Label diff = new Label();
            switch (type)
            {
                case "Easy":
                    name.Text = Easy[i].Name;
                    time.Text = Easy[i].Time;
                    diff.Text = Easy[i].Difficulty;
                    break;
                case "Normal":
                    name.Text = Normal[i].Name;
                    time.Text = Normal[i].Time;
                    diff.Text = Normal[i].Difficulty;
                    break;
                case "Hard":
                    name.Text = Hard[i].Name;
                    time.Text = Hard[i].Time;
                    diff.Text = Hard[i].Difficulty;
                    break;
                default:
                    break;
            }
            name.Location = new Point(10, 10);
            time.Location = new Point(10, 10);
            diff.Location = new Point(10, 10);
            name.Size = new Size(50, 20);
            time.Size = new Size(50, 20);
            diff.Size = new Size(50, 20);
            leaders.Controls.Add(name, 0, i);
            leaders.Controls.Add(time, 1, i);
            leaders.Controls.Add(diff, 2, i);
        }
        public void ShowScore()
        {
            SortScores();
            leaders.Controls.Clear();
            for (int i = 0; i < Easy.Length; i++)
            {
                if (btnEasy.Checked)
                {
                    AddScoreLabel(i, "Easy");
                }
                else if (btnNormal.Checked)
                {
                    AddScoreLabel(i, "Normal");
                }
                else
                {
                    AddScoreLabel(i, "Hard");
                }
            }
        }
        private void btnEasy_CheckedChanged(object sender, EventArgs e)
        {
            ShowScore();
        }

        private void btnNormal_CheckedChanged(object sender, EventArgs e)
        {
            ShowScore();
        }

        private void btnHard_CheckedChanged(object sender, EventArgs e)
        {
            ShowScore();
        }

        private void Times_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveScores();
        }

        private void Times_Load(object sender, EventArgs e)
        {
            ShowScore();
        }
    }
}