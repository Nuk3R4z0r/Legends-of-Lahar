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

namespace Legends_Of_Lahar
    
{
    public partial class ConfirmCharacterName : Form
    {
        public ConfirmCharacterName()
        {
            InitializeComponent();
        }

        private void btnCreateCharacter_click(object sender, EventArgs ee)
        {
         
            if (txtCharacterNameField.Text != "")
            {
                
                List<object> Character = new List<object>();
                Character.Add(txtCharacterNameField.Text);
                Character.Add(100); // Gold
                Character.Add(1); // Level

                Iostreamer.SaveToFile(Character);
                MainForm game = new MainForm();
                game.Show();
                this.Close();
            }

        }

    }
}
