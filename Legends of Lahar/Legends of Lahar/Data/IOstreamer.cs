using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Legends_Of_Lahar
{
    class IOstreamer
    {
        public static void SavePlayer(string path)
        {
            if (File.Exists(path + "\\Data\\Player.dat"))
                File.Delete(path + "\\Data\\Player.dat");

            using (StreamWriter sw = new StreamWriter(path + "\\Data\\Player.sav"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(sw.BaseStream, GameManager._GM.CurrentPlayer);
                sw.Flush();
            }
        }

        public static void LoadPlayer(string path)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (StreamReader sr = new StreamReader(path + "\\Data\\Player.sav"))
                {
                    GameManager._GM.CurrentPlayer = (Player)bf.Deserialize(sr.BaseStream);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(path + "\\Data\\Player.sav" + " is corrupt!\r\nPlease delete it!");
            }
        }

        public static void DeletePlayer(string path)
        {
            File.Delete(path + "\\Data\\Player.sav");
        }
    }
}