using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Legends_Of_Lahar
{
    class Iostreamer
    {
        public enum Data { Player, Areas, Enemies, Items, Skills }


        public static void SaveToFile(List<object> data)
        {
            // Streamwriter oprettet for at kunne gemme "karateren"
            FileStream fs = new FileStream(Environment.SpecialFolder.MyDocuments.ToString(), FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            try
            {
                foreach (object attribute in data)
                    sw.WriteLine(attribute);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
                fs.Close();
                MessageBox.Show("Files have been saved");
            }

        }

        public List<object[]> LoadData(Data d)
        {
            List<object[]> tempList = new List<object[]>();
            string destination = ""; ;

            switch(d)
            {
                case Data.Player:
                    destination = Environment.SpecialFolder.MyDocuments.ToString() + "Player.sav";
                    break;
                case Data.Areas:
                    destination = Environment.SpecialFolder.MyDocuments.ToString() + "Areas.dat";
                    break;
                case Data.Enemies:
                    destination = Environment.SpecialFolder.MyDocuments.ToString() + "Enemies.dat";
                    break;
                case Data.Items:
                    destination = Environment.SpecialFolder.MyDocuments.ToString() + "Items.dat";
                    break;
                case Data.Skills:
                    destination = Environment.SpecialFolder.MyDocuments.ToString() + "Skills.dat";
                    break;
            }

            try
            {
                // Har oprettet en StreamReader for at kunne læse fra fil.

                using (StreamReader sr = new StreamReader(destination))
                {
                    string line;
                    
                    // Læser og viser samtlige linjer indtil den har gennemgået hele dokumentet.
                    while ((line = sr.ReadLine()) != null)
                    {
                        //object
                        MessageBox.Show(line);
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                // En fejlmeddelse bliver udskrevet, hvis du har fucket noget op
                Console.WriteLine("Something went horribly wrong! Did you select the wrong textfile scrublord");
                Console.WriteLine(e.Message);
            }

            return tempList;
        }

        public static void DeleteData()
        {

        }


    }
}