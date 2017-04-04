using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Legends_Of_Lahar
{
    public partial class MapControl : UserControl
    {
        public MapControl()
        {
            InitializeComponent();
        }

        //Genererer map og adder areas til mappet efter maId
        public void GenerateMap(int mapId)
        {
            switch(mapId)
            {
                case 0:
                    BackgroundImage = Properties.Resources.TheDesertsMap;
                    lblMap.Text = "The Deserts";
                    break;
                case 1:
                    lblMap.Text = "The Forgotten Forest";
                    break;
                case 2:
                    lblMap.Text = "The Caves";
                    break;
                case 3:
                    lblMap.Text = "Necropolis";
                    break;
                case 4:
                    lblMap.Text = "Eternal Depths";
                    break;
                case 5:
                    lblMap.Text = "The Frozen Hills";
                    break;
                case 6:
                    lblMap.Text = "World of the Void";
                    break;
            }

            AddAreas(mapId);
        }

        //Adder alle buttons der findes i Maps arrayet inden for mapId'et
        private void AddAreas(int mapId)
        {
            foreach(Button btn in MapData.Maps[mapId])
            {
                Controls.Add(btn);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
