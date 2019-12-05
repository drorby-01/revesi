using System;
using System.Windows.Forms;
using Ex05.OtheloGameLogic;

namespace Ex05.OtheloGameWinForms
{

    // $G$ CSS-016 (-3) Bad class name - The name of classes derived from Form should start with Form.
    public partial class OthelloGameSettingsForm : Form
    {
        private int m_BoardSizeChoise = OthelloGameBoard.DefaultOthelloGameBoardSize;
        private OthelloGameBoard.eGameTypes m_GameStatus;

        public OthelloGameSettingsForm()
        {
            InitializeComponent();
        }

        public void OnLoadthelloGameSettingsForm(object i_Sender, EventArgs i_EventArgs)
        {
        }

        public void OnClickBoardSizeChooseButton(object i_Sender, EventArgs i_EventArgs)
        {
            changeTheBoardSizeChoiseByClick();

            string changeMssageOnButton = string.Format("Board Size: {0}x{0} (click to increase)", m_BoardSizeChoise);

            this.m_BoardSizeChooseButton.Text = changeMssageOnButton;
        }

        private void changeTheBoardSizeChoiseByClick()
        {
            if (m_BoardSizeChoise < OthelloGameBoard.MaxOthelloGameBoardSize)
            { 
                m_BoardSizeChoise += 2;
            }
            else if (m_BoardSizeChoise == OthelloGameBoard.MaxOthelloGameBoardSize)
            {
                m_BoardSizeChoise = OthelloGameBoard.DefaultOthelloGameBoardSize;
            }
        }

        public void OnClickStartPlayNewGameButton(object i_Sender, EventArgs i_EventArgs)
        {
            OthelloGamePlayer firstPlayer, secondPlayer;

            // Create the game board according to the user choise in the settings form
            OthelloGameBoard othelloGameBoard = new OthelloGameBoard(BoardSizeChoise);
            
            updateTheRequiredGameType(i_Sender);

            createThePlayers(out firstPlayer, out secondPlayer,  this.GameStatus);
            
            // Display the board game form to user
            OthelloGameBoardForm othelloGameBoardForm = new OthelloGameBoardForm(othelloGameBoard, firstPlayer, secondPlayer);

            // Make setting form Invisible
            this.Visible = false;

            othelloGameBoardForm.ShowDialog();
        }

        private void updateTheRequiredGameType(object i_Sender)
        {
            // Update the require game the user want to play
            if (i_Sender == m_PlayAgainstComputerChooseButton)
            {
                m_GameStatus = OthelloGameBoard.eGameTypes.Computer;
            }
            else
            {
                m_GameStatus = OthelloGameBoard.eGameTypes.Player;
            }
        }

        public int BoardSizeChoise
        {
            get
            {
                return m_BoardSizeChoise;
            }
        }

        public OthelloGameBoard.eGameTypes GameStatus
        {
            get
            {
                return m_GameStatus;
            }
        }

        private void createThePlayers(out OthelloGamePlayer o_FirstPlayer, out OthelloGamePlayer o_SecondPlayer, OthelloGameBoard.eGameTypes i_GameStatus)
        {
            // Create the first player
            o_FirstPlayer = new OthelloGamePlayer(OthelloGamePlayer.ePlayerColorTypes.Black, OthelloGameBoard.eGameTypes.Player);

            // Create the second player to play with
            if (i_GameStatus == OthelloGameBoard.eGameTypes.Computer)
            {
                o_SecondPlayer = new OthelloGamePlayer(OthelloGamePlayer.ePlayerColorTypes.White, OthelloGameBoard.eGameTypes.Computer);
            }
            else
            {
                o_SecondPlayer = new OthelloGamePlayer(OthelloGamePlayer.ePlayerColorTypes.White, OthelloGameBoard.eGameTypes.Player);
            }
        }
    }
}
