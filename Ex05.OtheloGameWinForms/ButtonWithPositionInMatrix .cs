using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.OtheloGameWinForms
{
    public class ButtonWithPositionInMatrix : Button
    {
        private static int s_ButtonWidth = 45;
        private static int s_ButtonHeight = 40;
        private int m_RowPosition;
        private int m_ColumnPosition;

        public static int ButtonWidth
        {
            get { return s_ButtonWidth; }
        }

        public static int ButtonHeight
        {
            get { return s_ButtonHeight; }
        }

        public int RowPosition
        {
            get { return m_RowPosition; }

            set { m_RowPosition = value; }
        }

        public int ColumnPosition
        {
            get { return m_ColumnPosition; }

            set { m_ColumnPosition = value; }
        }
 
        protected override void OnPaint(PaintEventArgs i_PaintEventArgs)
        {
            if (Enabled)
            {
                base.OnPaint(i_PaintEventArgs);
            }
            else
            {
                // Calling the base class OnPaint
                base.OnPaint(i_PaintEventArgs);

                if (BackColor == Color.Black)
                {
                    // Draw the text in the button in White
                    i_PaintEventArgs.Graphics.DrawString(Text, Font, new SolidBrush(Color.White), (Width - i_PaintEventArgs.Graphics.MeasureString(Text, Font).Width) / 2, (Height / 2) - (i_PaintEventArgs.Graphics.MeasureString(Text, Font).Height / 2));
                }
                else
                {
                    i_PaintEventArgs.Graphics.DrawString(Text, Font, new SolidBrush(Color.Black), (Width - i_PaintEventArgs.Graphics.MeasureString(Text, Font).Width) / 2, (Height / 2) - (i_PaintEventArgs.Graphics.MeasureString(Text, Font).Height / 2));
                }
            }
        }
    }
}
