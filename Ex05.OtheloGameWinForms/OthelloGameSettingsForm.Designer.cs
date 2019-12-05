namespace Ex05.OtheloGameWinForms
{
    public partial class OthelloGameSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer m_Components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool i_Disposing)
        {
            if (i_Disposing && (m_Components != null))
            {
                m_Components.Dispose();
            }

            base.Dispose(i_Disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_BoardSizeChooseButton = new System.Windows.Forms.Button();
            this.m_PlayAgainstComputerChooseButton = new System.Windows.Forms.Button();
            this.m_PlayAgainstFriendChooseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boardSizeChooseButton
            // 
            this.m_BoardSizeChooseButton.BackColor = System.Drawing.SystemColors.Control;
            this.m_BoardSizeChooseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_BoardSizeChooseButton.Location = new System.Drawing.Point(22, 27);
            this.m_BoardSizeChooseButton.Name = "boardSizeChooseButton";
            this.m_BoardSizeChooseButton.Size = new System.Drawing.Size(493, 64);
            this.m_BoardSizeChooseButton.TabIndex = 0;
            this.m_BoardSizeChooseButton.Text = "Board Size: 6x6 (click to increase)";
            this.m_BoardSizeChooseButton.UseVisualStyleBackColor = false;
            this.m_BoardSizeChooseButton.Click += new System.EventHandler(this.OnClickBoardSizeChooseButton);
            // 
            // m_PlayAgainstComputerChooseButton
            // 
            this.m_PlayAgainstComputerChooseButton.BackColor = System.Drawing.SystemColors.Control;
            this.m_PlayAgainstComputerChooseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_PlayAgainstComputerChooseButton.Location = new System.Drawing.Point(22, 130);
            this.m_PlayAgainstComputerChooseButton.Name = "m_PlayAgainstComputerChooseButton";
            this.m_PlayAgainstComputerChooseButton.Size = new System.Drawing.Size(243, 71);
            this.m_PlayAgainstComputerChooseButton.TabIndex = 2;
            this.m_PlayAgainstComputerChooseButton.Text = "Play against the computer";
            this.m_PlayAgainstComputerChooseButton.UseVisualStyleBackColor = false;
            this.m_PlayAgainstComputerChooseButton.Click += new System.EventHandler(this.OnClickStartPlayNewGameButton);
            // 
            // playAgainstFriendChooseButton
            // 
            this.m_PlayAgainstFriendChooseButton.BackColor = System.Drawing.SystemColors.Control;
            this.m_PlayAgainstFriendChooseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_PlayAgainstFriendChooseButton.Location = new System.Drawing.Point(276, 130);
            this.m_PlayAgainstFriendChooseButton.Name = "playAgainstFriendChooseButton";
            this.m_PlayAgainstFriendChooseButton.Size = new System.Drawing.Size(239, 71);
            this.m_PlayAgainstFriendChooseButton.TabIndex = 3;
            this.m_PlayAgainstFriendChooseButton.Text = "Play against your friend";
            this.m_PlayAgainstFriendChooseButton.UseVisualStyleBackColor = false;
            this.m_PlayAgainstFriendChooseButton.Click += new System.EventHandler(this.OnClickStartPlayNewGameButton);
            // 
            // OthelloGameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(541, 228);
            this.Controls.Add(this.m_PlayAgainstFriendChooseButton);
            this.Controls.Add(this.m_PlayAgainstComputerChooseButton);
            this.Controls.Add(this.m_BoardSizeChooseButton);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OthelloGameSettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Othello - Game Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.OnLoadthelloGameSettingsForm);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_BoardSizeChooseButton;
        private System.Windows.Forms.Button m_PlayAgainstComputerChooseButton;
        private System.Windows.Forms.Button m_PlayAgainstFriendChooseButton;
    }
}
