namespace Ex05.OtheloGameLogic
{
    public class OthelloGameBoard
    {
        private static int s_DefaultOthelloGameBoardSize = 6;
        private static int s_MaxOthelloGameBoardSize = 12;
        private OthelloGamePlayer.ePlayerColorTypes[,] m_OtheloGameBoardMatrix;
        private int m_OtheloGameBoardMatrixDimension;
        private int m_NumOfFirstPlayerSignalsOnBoard;
        private int m_NumOfSecondPlayerSignalsOnBoard;
        
        public enum eGameTypes
        {
            Player,
            Computer,
        }
        
        public OthelloGameBoard(int i_OtheloGameBoardMatrixDimension)
        {
            m_OtheloGameBoardMatrixDimension = i_OtheloGameBoardMatrixDimension;
            m_OtheloGameBoardMatrix = new OthelloGamePlayer.ePlayerColorTypes[m_OtheloGameBoardMatrixDimension, m_OtheloGameBoardMatrixDimension];

            InitializeOtheloGameBoard();
        }

        public void InitializeOtheloGameBoard()
        {
            zeroAllTheBoardCells();

            initializationTheCenterCellsOfTheBoard();
        }

        private void initializationTheCenterCellsOfTheBoard()
        {
            this.NumOfFirstPlayerSignalsOnBoard = 0;
            this.NumOfSecondPlayerSignalsOnBoard = 0;

            m_OtheloGameBoardMatrix[m_OtheloGameBoardMatrixDimension / 2, m_OtheloGameBoardMatrixDimension / 2] = OthelloGamePlayer.ePlayerColorTypes.White;
            m_OtheloGameBoardMatrix[(m_OtheloGameBoardMatrixDimension / 2) - 1, (m_OtheloGameBoardMatrixDimension / 2) - 1] = OthelloGamePlayer.ePlayerColorTypes.White;
            m_OtheloGameBoardMatrix[(m_OtheloGameBoardMatrixDimension / 2) - 1, m_OtheloGameBoardMatrixDimension / 2] = OthelloGamePlayer.ePlayerColorTypes.Black;
            m_OtheloGameBoardMatrix[m_OtheloGameBoardMatrixDimension / 2, (m_OtheloGameBoardMatrixDimension / 2) - 1] = OthelloGamePlayer.ePlayerColorTypes.Black;
        }

        private void zeroAllTheBoardCells()
        {
            for (int i = 0; i < this.m_OtheloGameBoardMatrixDimension; i++)
            {
                for (int j = 0; j < this.m_OtheloGameBoardMatrixDimension; j++)
                {
                    this.m_OtheloGameBoardMatrix[i, j] = OthelloGamePlayer.ePlayerColorTypes.Empty;
                }
            }
        }

        public OthelloGamePlayer.ePlayerColorTypes[,] OtheloGameBoardMatrix
        {
            get
            {
                return m_OtheloGameBoardMatrix;
            }

            set
            {
                this.m_OtheloGameBoardMatrix = value;
            }
        }

        public int OtheloGameBoardMatrixDimension
        {
            get
            {
                return m_OtheloGameBoardMatrixDimension;
            }

            set
            {
                this.m_OtheloGameBoardMatrixDimension = value;
            }
        }

        public int NumOfFirstPlayerSignalsOnBoard
        {
            get
            {
                return m_NumOfFirstPlayerSignalsOnBoard;
            }

            set
            {
                this.m_NumOfFirstPlayerSignalsOnBoard = value;
            }
        }

        public int NumOfSecondPlayerSignalsOnBoard
        {
            get
            {
                return m_NumOfSecondPlayerSignalsOnBoard;
            }

            set
            {
                this.m_NumOfSecondPlayerSignalsOnBoard = value;
            }
        }

        public static int DefaultOthelloGameBoardSize
        {
            get
            {
                return s_DefaultOthelloGameBoardSize;
            }
        }

        public static int MaxOthelloGameBoardSize
        {
            get
            {
                return s_MaxOthelloGameBoardSize;
            }
        }

        private void zeroTheSignalCountersOfTheBoard()
        {
            this.m_NumOfFirstPlayerSignalsOnBoard = 0;
            this.m_NumOfSecondPlayerSignalsOnBoard = 0;
        }

        public void CountAndUpdateHowManySignalsOnBoardFromAnyKind()
        {
            for (int i = 0; i < this.m_OtheloGameBoardMatrixDimension; i++)
            {
                for (int j = 0; j < this.m_OtheloGameBoardMatrixDimension; j++)
                {
                    if (this.m_OtheloGameBoardMatrix[i, j] == OthelloGamePlayer.ePlayerColorTypes.White)
                    {
                        this.m_NumOfSecondPlayerSignalsOnBoard++;
                    }
                    else if (this.m_OtheloGameBoardMatrix[i, j] == OthelloGamePlayer.ePlayerColorTypes.Black)
                    {
                        this.m_NumOfFirstPlayerSignalsOnBoard++;
                    }
                }
            }
        }

        public OthelloGamePlayer.ePlayerColorTypes GetTheOppositeSignal(OthelloGamePlayer.ePlayerColorTypes i_MySignalType)
        {
            OthelloGamePlayer.ePlayerColorTypes playerSignalToReturn;

            if (i_MySignalType == OthelloGamePlayer.ePlayerColorTypes.Black)
            {
                playerSignalToReturn = OthelloGamePlayer.ePlayerColorTypes.White;
            }
            else
            {
                playerSignalToReturn = OthelloGamePlayer.ePlayerColorTypes.Black;
            }

            return playerSignalToReturn;
        }
        
        public bool CheckTheOtheloBoardGameHasFreePlace()
        {
            bool hasFreePlaceOnBoardGame = true;
            int BoardGameIsFull = 1;

            for (int i = 0; i < this.m_OtheloGameBoardMatrixDimension; i++)
            {
                for (int j = 0; j < this.m_OtheloGameBoardMatrixDimension; j++)
                {
                    if (this.m_OtheloGameBoardMatrix[i, j] == OthelloGamePlayer.ePlayerColorTypes.Empty)
                    {
                        i = this.m_OtheloGameBoardMatrixDimension;
                        BoardGameIsFull = 0;
                        break; // Finish the loops cause you know there is atleast one free cell on board
                    }
                }
            }

            if (BoardGameIsFull == 1)
            {
                hasFreePlaceOnBoardGame = !hasFreePlaceOnBoardGame;
            }

            return hasFreePlaceOnBoardGame;
        }

        public bool CheckTheRequiredPositionOnBoardIsEmpty(int i_RowIndex, int i_ColIndex)
        {
            bool requiredCellIsEmpty = true;

            if (this.m_OtheloGameBoardMatrix[i_RowIndex, i_ColIndex] == OthelloGamePlayer.ePlayerColorTypes.Black || this.m_OtheloGameBoardMatrix[i_RowIndex, i_ColIndex] == OthelloGamePlayer.ePlayerColorTypes.White)
            {
                requiredCellIsEmpty = !requiredCellIsEmpty;
            }

            return requiredCellIsEmpty;
        }

        public void GetTheNumOfPointsPlayersInThisGame(OthelloGamePlayer.ePlayerColorTypes i_TheWinnerOfTheCurrentGame, out int o_PointsToWinnerInCurrentGame, out int o_PointsToLosserInCurrentGame, OthelloGamePlayer i_FirstPlayer, OthelloGamePlayer i_SecondPlayer)
        {
            if (i_TheWinnerOfTheCurrentGame == OthelloGamePlayer.ePlayerColorTypes.Black)
            {
                i_FirstPlayer.PlayerTotalPoints++;
                o_PointsToWinnerInCurrentGame = this.NumOfFirstPlayerSignalsOnBoard;
                o_PointsToLosserInCurrentGame = this.NumOfSecondPlayerSignalsOnBoard;
            }
            else if (i_TheWinnerOfTheCurrentGame == OthelloGamePlayer.ePlayerColorTypes.White)
            {
                i_SecondPlayer.PlayerTotalPoints++;
                o_PointsToWinnerInCurrentGame = this.NumOfSecondPlayerSignalsOnBoard;
                o_PointsToLosserInCurrentGame = this.NumOfFirstPlayerSignalsOnBoard;
            }
            else
            {
                o_PointsToWinnerInCurrentGame = (m_OtheloGameBoardMatrixDimension * m_OtheloGameBoardMatrixDimension) / 2;
                o_PointsToLosserInCurrentGame = o_PointsToWinnerInCurrentGame;
            }
        }      
    }
}
