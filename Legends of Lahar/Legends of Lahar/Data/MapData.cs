using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Legends_Of_Lahar
{
    class MapData
    {
        public static List<Button[]> Maps;
        
        public static void GenerateMaps(MainForm currentForm)
        {
            Maps = new List<Button[]>();

            ///////////////////////AREAS FOR DESERTS///////////////////////////

            //Crater is Area 0
            Button btnDesertsCrater = new Button(); //Ny Knap
            btnDesertsCrater.Name = "btnArea" + Area.AREA_CRATER; //Area.AREA_CRATER is areaId 0, name of the button will be btnArea0
            btnDesertsCrater.Text = "Crater"; //Button Text
            btnDesertsCrater.Location = new Point(40, 20); //button location
            btnDesertsCrater.Click += new EventHandler(currentForm.btnArea_Click); //Same handler for all buttons

            //Dry steppes is Area 1
            Button btnDrySteppes = new Button();
            btnDrySteppes.Name = "btnArea" + Area.AREA_DRYSTEPPES;
            btnDrySteppes.Text = "Dry steppes";
            btnDrySteppes.Location = new Point(80, 65);
            btnDrySteppes.Click += new EventHandler(currentForm.btnArea_Click);

            //Adding Deserts map to the list, will be position 0
            Maps.Add(new Button[] { btnDesertsCrater, btnDrySteppes }); 

            ///////////////////////AREAS FOR FOREST///////////////////////////

            //Adder Forest maps
            Maps.Add(new Button[] { });
        }
    }
}
