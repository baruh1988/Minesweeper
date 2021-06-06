using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace minesweeper
{
    class Game
    {
        public static int Rows { get; set; }
        public static int Cols { get; set; }
        public static int Mines { get; set; }
        private static int flagged;
        public static bool GameOver;
        public static bool Victory;
        public static Cell[,] board;
        public Game()
        {
            Rows = 9;
            Cols = 9;
            Mines = 10;
        }
        public Game(int rows, int cols, int mines)
        {
            Rows = rows;
            Cols = cols;
            Mines = mines;
        }
        public static void GenerateBoard()
        {
            flagged = 0;
            GameOver = false;
            Victory = false;
            board = new Cell[Rows, Cols];
            for(int row = 0; row < Rows; row++)
                for(int col = 0; col < Cols; col++)
                    board[row, col] = new Cell();
            PlantMines();
            GenerateNumbers();
        }
        private static void PlantMines()
        {
            int count = 0, row, col;
            Random rnd = new Random();
            while (count < Mines)
            {
                int n = rnd.Next(Rows * Cols - 1);
                row = n / Cols;
                col = n % Cols;
                if (board[row, col].IsMine)
                    continue;
                else
                {
                    board[row, col].IsMine = true;
                    count++;
                }
            }
        }
        private static void GenerateNumbers()
        {
            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Cols; col++)
                {
                    int count = 0;
                    if (ValidCell(row - 1, col - 1))
                        if (board[row - 1, col - 1].IsMine)
                            count++;
                    if (ValidCell(row - 1, col))
                        if (board[row - 1, col].IsMine)
                            count++;
                    if (ValidCell(row - 1, col + 1))
                        if (board[row - 1, col + 1].IsMine)
                            count++;
                    if (ValidCell(row, col - 1))
                        if (board[row, col - 1].IsMine)
                            count++;
                    if (ValidCell(row, col + 1))
                        if (board[row, col + 1].IsMine)
                            count++;
                    if (ValidCell(row + 1, col - 1))
                        if (board[row + 1, col - 1].IsMine)
                            count++;
                    if (ValidCell(row + 1, col))
                        if (board[row + 1, col].IsMine)
                            count++;
                    if (ValidCell(row + 1, col + 1))
                        if (board[row + 1, col + 1].IsMine)
                            count++;
                    board[row, col].NearbyMines = count;
                }
        }
        public static void RevealeCell(int row, int col)
        {
            if (ValidCell(row, col))
                if (!board[row, col].IsRevealed && !board[row, col].IsFlagged)
                {
                    board[row, col].IsRevealed = true;
                    if (board[row, col].NearbyMines == 0 && !board[row, col].IsMine)
                    {
                        RevealeCell(row - 1, col - 1);
                        RevealeCell(row - 1, col);
                        RevealeCell(row - 1, col + 1);
                        RevealeCell(row, col - 1);
                        RevealeCell(row, col + 1);
                        RevealeCell(row + 1, col - 1);
                        RevealeCell(row + 1, col);
                        RevealeCell(row + 1, col + 1);
                    }
                    else if (board[row, col].IsMine)
                        RevealMines();
                }
        }
        public static void RevealMines()
        {
            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Cols; col++)
                    if (board[row, col].IsMine)
                        board[row, col].IsRevealed = true;
            GameOver = true;
        }
        public static void FlagCell(int row, int col)
        {
            if (!board[row, col].IsRevealed)
                if (board[row, col].IsFlagged)
                {
                    board[row, col].IsFlagged = false;
                    flagged--;
                }
                else
                    if (flagged < Mines)
                    {
                        board[row, col].IsFlagged = true;
                        flagged++;
                    }
        }
        public static int CorrectFlags()
        {
            int count = 0;
            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Cols; col++)
                    if (board[row, col].IsMine && board[row, col].IsFlagged)
                        count++;
            return count;
        }
        public static int RevealedCells()
        {
            int count = 0;
            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Cols; col++)
                    if (board[row, col].IsRevealed && !board[row, col].IsMine)
                        count++;
            return count;
        }
        private static bool ValidCell(int row, int col)
        {
            return row >= 0 && row < Rows && col >= 0 && col < Cols;
        }
    }
}