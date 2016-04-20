﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TicTactToe
{
    public class GameFactory
    {
        private int turn = 0;
        public int XWins = 0;
        public int OWins = 0;
        public State[][] Board;

        public string GetTurn()
        {
            // Returns whose turn it is.
            if (turn == 0)
                return "X";
            else
                return "O";
        }

        public string ResetTurn()
        {
            // Resets the turn.
            turn = 0;
            return GetTurn();
        }

        public string PlayTurn(Button b)
        {
            // Gives the turn to the other player, and populizes the button with the correct icon and then disables it.

            switch (b.Name)
            {
                case "A1":
                    Board[0][0] = (State) turn + 1;
                    break;
                case "A2":
                    Board[0][1] = (State) turn + 1;
                    break;
                case "A3":
                    Board[0][2] = (State) turn + 1;
                    break;
                case "B1":
                    Board[1][0] = (State) turn + 1;
                    break;
                case "B2":
                    Board[1][1] = (State) turn + 1;
                    break;
                case "B3":
                    Board[1][2] = (State) turn + 1;
                    break;
                case "C1":
                    Board[2][0] = (State) turn + 1;
                    break;
                case "C2":
                    Board[2][1] = (State) turn + 1;
                    break;
                case "C3":
                    Board[2][2] = (State) turn + 1;
                    break;
            }

            if (turn == 0)
            {
                b.Text = "X";
                turn++;
            }
            else
            {
                b.Text = "O";
                turn--;
            }

            b.Enabled = false;
            
            return GetTurn();
        }

        private void DisableButtons(List<Button> buttonList)
        {
            // Disables the buttons in the list.
            foreach(Button b in buttonList)
            {
                b.Enabled = false;
            }

            Board = new State[3][];

            for (int i = 0; i < 3; i++)
            {
                Board[i] = new State[3];
            }
        }

        private bool CheckTie(List<Button> buttonList)
        {
            // Checks if there is still a button left that isn't disabled and returns result.
            bool isTie = true;
            
            foreach(Button b in buttonList)
            {
                if(b.Enabled == true)
                {
                    isTie = false;
                    break;
                }
            }

            return isTie;
        }

        public string CheckWinner(IEnumerable<Button> buttonList)
        {
            // TicTacToe logic and returns who won.
            List<Button> list = buttonList.ToList();
            list.RemoveAt(0);
            list.Reverse();
            string winner = "";

            // Horizontal checks
            // X
            if (list[0].Text == "X" && list[1].Text == "X" && list[2].Text == "X")
                winner = "X wins!";
            else if (list[3].Text == "X" && list[4].Text == "X" && list[5].Text == "X")
                winner = "X wins!";
            else if (list[6].Text == "X" && list[7].Text == "X" && list[8].Text == "X")
                winner = "X wins!";
            // O
            else if (list[0].Text == "O" && list[1].Text == "O" && list[2].Text == "O")
                winner = "O wins!";
            else if (list[3].Text == "O" && list[4].Text == "O" && list[5].Text == "O")
                winner = "O wins!";
            else if (list[6].Text == "O" && list[7].Text == "O" && list[8].Text == "O")
                winner = "O wins!";

            //Vertical checks
            // X
            if (list[0].Text == "X" && list[3].Text == "X" && list[6].Text == "X")
                winner = "X wins!";
            else if (list[1].Text == "X" && list[4].Text == "X" && list[7].Text == "X")
                winner = "X wins!";
            else if (list[2].Text == "X" && list[5].Text == "X" && list[8].Text == "X")
                winner = "X wins!";
            // O
            else if (list[0].Text == "O" && list[3].Text == "O" && list[6].Text == "O")
                winner = "O wins!";
            else if (list[1].Text == "O" && list[4].Text == "O" && list[7].Text == "O")
                winner = "O wins!";
            else if (list[2].Text == "O" && list[5].Text == "O" && list[8].Text == "O")
                winner = "O wins!";

            //Diagonal checks
            // X
            if (list[0].Text == "X" && list[4].Text == "X" && list[8].Text == "X")
                winner = "X wins!";
            else if (list[2].Text == "X" && list[4].Text == "X" && list[6].Text == "X")
                winner = "X wins!";
            // O
            else if (list[0].Text == "O" && list[4].Text == "O" && list[8].Text == "O")
                winner = "O wins!";
            else if (list[2].Text == "O" && list[4].Text == "O" && list[6].Text == "O")
                winner = "O wins!";

            if (CheckTie(list))
                winner = "Tie!";

            if (winner == "X wins!")
                XWins++;
            else if (winner == "O wins!")
                OWins++;

            if (winner != string.Empty)
                DisableButtons(list);

            return winner;
        }
    }
}