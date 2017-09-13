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
                GameManager._GM.CurrentPlayer = new Player(txtCharacterNameField.Text, 1, 100, 110, 10, 5, new Resist(10, 0, 0, 0), 0, 
                    new Skill[] { SkillData.SkillList[1] },new PlayerAttributes(10, 10, 30, 10), 10, 20, "\\Custom\\Player.jpg");

                this.Close();
            }
        }

    }
}
