using System.Windows.Forms;

namespace Ex05.OtheloGameWinForms
{
    public class OthelloGameGUI
    {
        public void StartOtheloGame() 
        {
            Application.EnableVisualStyles(); // Select WinForms style 

            // Display the settings form to user
            OthelloGameSettingsForm othelloGameSettingsForm  = new OthelloGameSettingsForm();
            othelloGameSettingsForm.ShowDialog();
        }
    }
}
