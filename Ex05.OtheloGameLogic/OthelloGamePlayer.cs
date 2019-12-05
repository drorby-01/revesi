using System;

namespace Ex05.OtheloGameLogic
{
    public class OthelloGamePlayer
    {
        private const int k_DefaultStartingPointsScore = 0;
        private static string s_PlayerSignalKind = "O";
        private int m_PlayerTotalPoints;
        private int m_PlayerCurrentGamePoints;
        private string m_PlayerName;
        private ePlayerColorTypes m_PlayerColor;
        private OthelloGameBoard.eGameTypes m_StateGame;

        public enum ePlayerColorTypes
        {
            Empty = 0,
            White = 1, 
            Black = 2,
        }

        public OthelloGamePlayer()
        {
        }

        public OthelloGamePlayer(ePlayerColorTypes m_PlayerColor, OthelloGameBoard.eGameTypes i_StateGame)
        {
            PlayerName = Enum.GetName(typeof(ePlayerColorTypes), m_PlayerColor);
            PlayerColor = m_PlayerColor;
            StateGame = i_StateGame;
            m_PlayerTotalPoints = k_DefaultStartingPointsScore;
            m_PlayerCurrentGamePoints = 0;
        }

        public static OthelloGamePlayer.ePlayerColorTypes GetTheOppositeColor(OthelloGamePlayer.ePlayerColorTypes i_MySignalColor)
        {
            OthelloGamePlayer.ePlayerColorTypes theOppositeColor;

            if (i_MySignalColor == OthelloGamePlayer.ePlayerColorTypes.White)
            {
                theOppositeColor = OthelloGamePlayer.ePlayerColorTypes.Black;
            }
            else
            {
                theOppositeColor = OthelloGamePlayer.ePlayerColorTypes.White;
            }

            return theOppositeColor;
        }

        public string PlayerName
        {
            get
            {
                return m_PlayerName;
            }

            set
            {
                m_PlayerName = value;
            }
        }

        public ePlayerColorTypes PlayerColor
        {
            get
            {
                return m_PlayerColor;
            }

            set
            {
                m_PlayerColor = value;
            }
        }

        public int PlayerTotalPoints
        {
            get
            {
                return m_PlayerTotalPoints;
            }

            set
            {
                m_PlayerTotalPoints = value;
            }
        }
        
        public int PlayerCurrentGamePoints
        {
            get
            {
                return m_PlayerCurrentGamePoints;
            }

            set
            {
                m_PlayerCurrentGamePoints = value;
            }
        }

        public static string PlayerSignalKind
        {
            get
            {
                return s_PlayerSignalKind;
            }
        }
 
        public OthelloGameBoard.eGameTypes StateGame
        {
            get
            {
                return m_StateGame;
            }

            set
            {
                m_StateGame = value;
            }
        }
    }
}
