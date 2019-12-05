using System;
using System.Drawing;
using System.Windows.Forms;
using Ex05.OtheloGameLogic;

namespace Ex05.OtheloGameWinForms
{
    public partial class OthelloGameBoardForm : Form
    {
        private const string k_TitleToMessageBox = "Othello";
        // $G$ DSN-999 (-3) This kind of field should be readonly.
        private int m_GameBoardSize;
        private OthelloGamePlayer m_FirstPlayer;
        private OthelloGamePlayer m_SecondPlayer;
        private OthelloGameBoard m_OthelloGameBoard;
        private OthelloGamePlayer.ePlayerColorTypes m_CurrentSignalTurn;
        private ButtonWithPositionInMatrix[,] m_ButtonsMatrix;
        private OthelloGameRules m_OthelloGameRules;

        public OthelloGameBoardForm(OthelloGameBoard i_OthelloGameBoard, OthelloGamePlayer i_FirstPlayer, OthelloGamePlayer i_SecondPlayer)
        {
            InitializeComponent();

            m_GameBoardSize = i_OthelloGameBoard.OtheloGameBoardMatrixDimension;
            m_OthelloGameRules = new OthelloGameRules(m_GameBoardSize, i_SecondPlayer);
            m_OthelloGameBoard = i_OthelloGameBoard;
            m_FirstPlayer = i_FirstPlayer;
            m_SecondPlayer = i_SecondPlayer;
            m_CurrentSignalTurn = OthelloGamePlayer.ePlayerColorTypes.Black;
            m_ButtonsMatrix = new ButtonWithPositionInMatrix[m_GameBoardSize, m_GameBoardSize];
        }

        public void OnLoadthelloGameBoardForm(object i_Sender, EventArgs i_EventArgs)
        {
            changeTheWindowSizeAccordingToSizeChoise();

            printInTheTopOfWindowWhoIsTheCurrentPlayerToPlayNow();

            printOthelloBoardGame();

            displayTheCurrentOptionsCellsToChooseInBoard();
        }

        private void printOthelloBoardGame()
        {
            const int k_SideSpaceBettwenButtons = 8;
            const int k_TopSpace = 16;

            for (int i = 0; i < m_ButtonsMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < m_ButtonsMatrix.GetLength(1); j++)
                {
                    printTheButtonsOfTheMatrixBoard(i, j, k_SideSpaceBettwenButtons, k_TopSpace);

                    printTheValuesOfSignalsInMatrixBoard(i, j);
                }
            }
        }

        private void printTheButtonsOfTheMatrixBoard(int i_RowIndex, int i_ColumnIndex, int i_SideSpaceBettwenButtons, int i_TopSpace)
        {
            ButtonWithPositionInMatrix button = new ButtonWithPositionInMatrix();

            // Add the button to the click event
            button.Click += new EventHandler(this.OnClickGameBoardButton);

            // Set button location in the form
            button.Location = new Point((i_ColumnIndex * 44) + i_SideSpaceBettwenButtons + m_GameBoardSize, (i_RowIndex * 39) + i_TopSpace);
            
            // Set the button size
            button.Size = new Size(ButtonWithPositionInMatrix.ButtonWidth, ButtonWithPositionInMatrix.ButtonHeight);

            button.Enabled = false;

            // Store the defined button to the buttons matrix
            m_ButtonsMatrix[i_RowIndex, i_ColumnIndex] = button;

            // Add the current button to the controls list
            this.Controls.Add(button);

            // Update the number of row and column of the button according to the matrix
            button.ColumnPosition = i_ColumnIndex;
            button.RowPosition = i_RowIndex;
        }

        private void initTheButtonsMatrix()
        {
            for (int i = 0; i < m_ButtonsMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < m_ButtonsMatrix.GetLength(1); j++)
                {
                    changeButtonColor(i, j);

                    if (m_OthelloGameBoard.OtheloGameBoardMatrix[i, j] != OthelloGamePlayer.ePlayerColorTypes.Empty)
                    {
                        m_ButtonsMatrix[i, j].Text = OthelloGamePlayer.PlayerSignalKind;
                    }
                    else
                    {
                        m_ButtonsMatrix[i, j].Text = string.Empty;
                    }
                }
            }

            displayTheCurrentOptionsCellsToChooseInBoard();
        }

        private void printTheValuesOfSignalsInMatrixBoard(int i_RowIndex, int i_ColumnIndex)
        {
            m_ButtonsMatrix[i_RowIndex, i_ColumnIndex].Enabled = false;

            if (m_ButtonsMatrix[i_RowIndex, i_ColumnIndex].BackColor == Color.LimeGreen && m_OthelloGameBoard.OtheloGameBoardMatrix[i_RowIndex, i_ColumnIndex] == OthelloGamePlayer.ePlayerColorTypes.Empty)
            {
                m_ButtonsMatrix[i_RowIndex, i_ColumnIndex].BackColor = Color.Transparent;
            }
            else if (m_OthelloGameBoard.OtheloGameBoardMatrix[i_RowIndex, i_ColumnIndex] != OthelloGamePlayer.ePlayerColorTypes.Empty)
            {
                // Display the signal on specific cell in the game board
                m_ButtonsMatrix[i_RowIndex, i_ColumnIndex].Text = OthelloGamePlayer.PlayerSignalKind;
                changeButtonColor(i_RowIndex, i_ColumnIndex);
            }
        }

        private void changeButtonColor(int i_RowIndex, int i_ColumnIndex)
        {
            if (m_OthelloGameBoard.OtheloGameBoardMatrix[i_RowIndex, i_ColumnIndex] == OthelloGamePlayer.ePlayerColorTypes.Black)
            {
                m_ButtonsMatrix[i_RowIndex, i_ColumnIndex].BackColor = Color.Black;
                m_ButtonsMatrix[i_RowIndex, i_ColumnIndex].ForeColor = Color.White;
            }
            else if (m_OthelloGameBoard.OtheloGameBoardMatrix[i_RowIndex, i_ColumnIndex] == OthelloGamePlayer.ePlayerColorTypes.White)
            {
                m_ButtonsMatrix[i_RowIndex, i_ColumnIndex].BackColor = Color.White;
            }
            else
            {  // Green background with a signal value
                m_ButtonsMatrix[i_RowIndex, i_ColumnIndex].BackColor = Color.Transparent;
            }
        }

        private void displayTheCurrentOptionsCellsToChooseInBoard()
        {
            m_OthelloGameRules.ZeroTheLegalMovesMatrix(m_OthelloGameBoard);
            m_OthelloGameRules.FillCurrentLegalMovesMatrix(m_OthelloGameBoard, m_CurrentSignalTurn, m_SecondPlayer);
            
            if (m_CurrentSignalTurn != OthelloGamePlayer.ePlayerColorTypes.White || m_SecondPlayer.StateGame != OthelloGameBoard.eGameTypes.Computer)
            {
                changeCellColorIfLegalMove();
            }
        }

        private void changeTheWindowSizeAccordingToSizeChoise()
        {
            const int k_RightMarginSize = 40;
            const int k_DownMarginSize = 60;

            // Change the size of the windows form according the amount of controls on it
            this.Size = new Size((m_GameBoardSize * ButtonWithPositionInMatrix.ButtonWidth) + k_RightMarginSize, (m_GameBoardSize * ButtonWithPositionInMatrix.ButtonHeight) + k_DownMarginSize);
        }

        private void printInTheTopOfWindowWhoIsTheCurrentPlayerToPlayNow()
        {
            string messageAboutTheCurrentTurn = string.Format("Othello - {0}'s Turn", this.m_CurrentSignalTurn);
            this.Text = messageAboutTheCurrentTurn;
            this.ShowIcon = true;
        }

        private void changeCellColorIfLegalMove()
        {
            for (int i = 0; i < m_OthelloGameRules.AllCurrentLegalMovesMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < m_OthelloGameRules.AllCurrentLegalMovesMatrix.GetLength(1); j++)
                {
                    if (m_OthelloGameRules.AllCurrentLegalMovesMatrix[i, j] == m_CurrentSignalTurn)
                    {
                        m_ButtonsMatrix[i, j].BackColor = Color.LimeGreen;
                        m_ButtonsMatrix[i, j].Enabled = true;
                    }
                }
            }
        }

        public void OnClickGameBoardButton(object i_Sender, EventArgs i_EventArgs)
        {
            if (i_Sender is ButtonWithPositionInMatrix button)
            {
                m_OthelloGameRules.PutSignalInTheRequiredUserPositionOnBoard(m_OthelloGameBoard, m_CurrentSignalTurn, button.RowPosition, button.ColumnPosition);
                
                updateTheGameBoardAfterTheLastMove();

                checkTheNextStatusInTheGame();
                
                checkIfTheOtherPlayerIsComputerAndPlay();
            }
        }


        // $G$ DSN-002 (-20) No UI seperation! This class merge the Logic board with the Visual board (UserControl) of the game...
        private void checkTheNextStatusInTheGame()
        {
            const bool v_HasFreePlaceOnBoardGame = true;
            const bool v_NextPlayerCanContinueToPlay = true;
            const bool v_CurrentPlayerCanContinueToPlay = true;

            if (m_OthelloGameBoard.CheckTheOtheloBoardGameHasFreePlace() == v_HasFreePlaceOnBoardGame)
            { // There is still empty place in board
                if (m_OthelloGameRules.CheckIfPlayerHasOptionContinueToPlay(OthelloGamePlayer.GetTheOppositeColor(m_CurrentSignalTurn), m_OthelloGameBoard, m_SecondPlayer) == v_NextPlayerCanContinueToPlay)
                { // The next player can play - change turn and let him play
                    nextPlayerCanPlayInTheNextTurn();
                }
                else
                { // The next player can't play - so check if the current player can play now another turn
                    if (m_OthelloGameRules.CheckIfPlayerHasOptionContinueToPlay(m_CurrentSignalTurn, m_OthelloGameBoard, m_SecondPlayer) == v_CurrentPlayerCanContinueToPlay)
                    { // Let the current player to play another game
                        currentPlayerCanPlayThisTurn();
                    }
                    else
                    { // No one from players can play - GAME OVER
                        announceGameOver();
                    }
                }
            }
            else
            { // No empty place in board = GAME OVER
                announceGameOver();
            }
        }
        
        private void checkIfTheOtherPlayerIsComputerAndPlay()
        {
            if (m_CurrentSignalTurn == OthelloGamePlayer.ePlayerColorTypes.White)
            {
                if (m_SecondPlayer.StateGame == OthelloGameBoard.eGameTypes.Computer)
                {
                    m_OthelloGameRules.ZeroTheLegalMovesMatrix(m_OthelloGameBoard);
                    m_OthelloGameRules.FillCurrentLegalMovesMatrix(m_OthelloGameBoard, m_CurrentSignalTurn, m_SecondPlayer);
                    m_OthelloGameRules.PutAutomaticSignalOfCompuerOnBoard(m_OthelloGameBoard, m_CurrentSignalTurn);
                    updateTheGameBoardAfterTheLastMove();
                    checkTheNextStatusInTheGame();
                }
            }
        }
        
        private void currentPlayerCanPlayThisTurn()
        {
            OthelloGamePlayer.ePlayerColorTypes opponentPlayerName = m_OthelloGameBoard.GetTheOppositeSignal(m_CurrentSignalTurn);

            if ((m_SecondPlayer.StateGame != OthelloGameBoard.eGameTypes.Computer) || (m_SecondPlayer.StateGame == OthelloGameBoard.eGameTypes.Computer && opponentPlayerName == OthelloGamePlayer.ePlayerColorTypes.White))
            {   // Game against another player - display messages or Game against the computer and now it's my turn and the computer after me have nothing to do - so display a message about it only
                // Convert from Enum to string
                string strTheOpponentPlayerName = Enum.GetName(typeof(OthelloGamePlayer.ePlayerColorTypes), opponentPlayerName);

                MessageBox.Show(string.Format("You have another turn! cause your opponent({0}) has nothing to do", strTheOpponentPlayerName), k_TitleToMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);

                displayTheCurrentOptionsCellsToChooseInBoard();
            } 
            else if (m_SecondPlayer.StateGame == OthelloGameBoard.eGameTypes.Computer && opponentPlayerName == OthelloGamePlayer.ePlayerColorTypes.Black)
            {
                // Game against the computer and now it's the computer turn and I need play after him and have nothing to do - don't display a message about it and give another turn to computer
                checkIfTheOtherPlayerIsComputerAndPlay(); 
            }
        }

        private void nextPlayerCanPlayInTheNextTurn()
        {
            changeTurnToTheOtherPlayer();

            printInTheTopOfWindowWhoIsTheCurrentPlayerToPlayNow();

            displayTheCurrentOptionsCellsToChooseInBoard();
        }

        private void announceGameOver()
        {
            string newLine = Environment.NewLine;
            string strTheWinnerOfTheCurrentGame;
            string messageAboutGameOver;
            int pointsToWinnerInCurrentGame, pointsToLosserInCurrentGame, generalPointsOfTheWinner, generalPointsOfTheLosser;

            calculateNumOfPointsToPlayersAndGetTheWinner(out pointsToWinnerInCurrentGame, out pointsToLosserInCurrentGame, out strTheWinnerOfTheCurrentGame, out generalPointsOfTheWinner, out generalPointsOfTheLosser);

            if (strTheWinnerOfTheCurrentGame.Equals("No Winner")) 
            {
                messageAboutGameOver = string.Format(@"No Winner in this game !!! ({1}/{2}) ({4}/{5}){3}Would you like another round?", strTheWinnerOfTheCurrentGame, pointsToWinnerInCurrentGame, pointsToLosserInCurrentGame, newLine, generalPointsOfTheWinner, generalPointsOfTheLosser);
            }
            else
            {
                messageAboutGameOver = string.Format(@"{0} Won!! ({1}/{2}) ({4}/{5}){3}Would you like another round?", strTheWinnerOfTheCurrentGame, pointsToWinnerInCurrentGame, pointsToLosserInCurrentGame, newLine, generalPointsOfTheWinner, generalPointsOfTheLosser);
            }

            if (MessageBox.Show(messageAboutGameOver, k_TitleToMessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                startNewGame();
            }
            else
            {
                this.Close();
            }
        }

        // $G$ CSS-999 (-3) 5 function parameters
        private void calculateNumOfPointsToPlayersAndGetTheWinner(out int o_PointsToWinnerInCurrentGame, out int o_PointsToLosserInCurrentGame, out string o_StrTheWinnerOfTheCurrentGame, out int o_GeneralPointsOfTheWinner, out int o_GeneralPointsOfTheLosser)
        {
            o_PointsToWinnerInCurrentGame = 0;
            o_PointsToLosserInCurrentGame = 0;
            o_GeneralPointsOfTheWinner = 0;
            o_GeneralPointsOfTheLosser = 0;

            m_OthelloGameBoard.CountAndUpdateHowManySignalsOnBoardFromAnyKind();
            OthelloGamePlayer.ePlayerColorTypes theWinnerOfTheCurrentGame = m_OthelloGameRules.CheckWhoIsTheWinnerOfTheCurrentGame(m_OthelloGameBoard, m_FirstPlayer, m_SecondPlayer);

            m_OthelloGameBoard.GetTheNumOfPointsPlayersInThisGame(theWinnerOfTheCurrentGame, out o_PointsToWinnerInCurrentGame, out o_PointsToLosserInCurrentGame, m_FirstPlayer, m_SecondPlayer);

            if (theWinnerOfTheCurrentGame == OthelloGamePlayer.ePlayerColorTypes.Empty)
            {
                o_StrTheWinnerOfTheCurrentGame = "No Winner";
            }
            else
            {
                // Convert from Enum to string
                o_StrTheWinnerOfTheCurrentGame = Enum.GetName(typeof(OthelloGamePlayer.ePlayerColorTypes), theWinnerOfTheCurrentGame);
            }

            if (theWinnerOfTheCurrentGame == OthelloGamePlayer.ePlayerColorTypes.Black)
            {
                o_GeneralPointsOfTheWinner = m_FirstPlayer.PlayerTotalPoints;
                o_GeneralPointsOfTheLosser = m_SecondPlayer.PlayerTotalPoints;
            }
            else
            {
                o_GeneralPointsOfTheWinner = m_SecondPlayer.PlayerTotalPoints;
                o_GeneralPointsOfTheLosser = m_FirstPlayer.PlayerTotalPoints;
            }
        }

        private void updateTheGameBoardAfterTheLastMove()
        {
            for (int i = 0; i < m_ButtonsMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < m_ButtonsMatrix.GetLength(1); j++)
                {
                    printTheValuesOfSignalsInMatrixBoard(i, j);
                }
            }
        }

        private void initThePlayerScore()
        {
            m_FirstPlayer.PlayerCurrentGamePoints = 0;
            m_SecondPlayer.PlayerCurrentGamePoints = 0;
        }

        private void changeTurnToTheOtherPlayer()
        {
            if (m_CurrentSignalTurn == OthelloGamePlayer.ePlayerColorTypes.Black)
            {
                m_CurrentSignalTurn = OthelloGamePlayer.ePlayerColorTypes.White;
            }
            else
            {
                m_CurrentSignalTurn = OthelloGamePlayer.ePlayerColorTypes.Black;
            }
        }

        private void startNewGame()
        {
            m_CurrentSignalTurn = OthelloGamePlayer.ePlayerColorTypes.Black;
            m_OthelloGameBoard.InitializeOtheloGameBoard();
            initTheButtonsMatrix();
        } 
    }
}