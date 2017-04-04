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

        //Laver mapsne og assigner områder til knapperne
        public static void GenerateMaps(MainForm currentForm)
        {
            Maps = new List<Button[]>();

            ///////////////////////AREAS TIL DESERTS///////////////////////////

            //Crater er Area 0
            Button btnDesertsCrater = new Button(); //Ny Knap
            btnDesertsCrater.Name = "btnArea" + Area.AREA_CRATER; //Area.AREA_CRATER betegner areaId hvilket er 0 her, knappen kommer til at hedde btnArea0
            btnDesertsCrater.Text = "Crater"; //Text på knappen
            btnDesertsCrater.Location = new Point(40, 20); //hvor knappen skal ligge på kortet
            btnDesertsCrater.Click += new EventHandler(currentForm.btnArea_Click); // ER DET SAMME FOR ALLE KNAPPER

            //Dry steppes er Area 1
            Button btnDrySteppes = new Button();
            btnDrySteppes.Name = "btnArea" + Area.AREA_DRYSTEPPES;
            btnDrySteppes.Text = "Dry steppes";
            btnDrySteppes.Location = new Point(80, 65);
            btnDrySteppes.Click += new EventHandler(currentForm.btnArea_Click);

            //Adder Deserts mapsne, kommer til at ligge i position 0 i Maps listen
            Maps.Add(new Button[] { btnDesertsCrater, btnDrySteppes }); //Da det er første vi adder, ligger det i position 0 som er det samme som mapId på deserts

            ///////////////////////AREAS TIL FOREST///////////////////////////

            //Adder Forest mapsne
            Maps.Add(new Button[] { }); //Da det er andet vi adder, ligger det i position 1 som er det samme som mapId på Forest
        }
    }
}
