using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Legends_Of_Lahar
{
    public partial class MainForm : Form
    {
        private MapControl map;
        public BattleSystem bs;
        private Area _currentArea;
        private string _workingDirectory;

        public MainForm()
        {
            InitializeComponent();

            _workingDirectory = Directory.GetCurrentDirectory();
            
            //Laver map behind the scenes
            map = new MapControl();
            map.Visible = false;
            map.Location = new Point(204, 208);
            tabControl1.TabPages[0].Controls.Add(map);
            map.BringToFront();

            //Transparency fix
            pBoxPlayer.Parent = pBoxEnvironment;
            pBoxEnemy.Parent = pBoxEnvironment;
            lblEnvironment.Parent = pBoxEnvironment;

            //Load Game Resources
            ItemData.GenerateItems();
            MonsterData.GenerateMonsters();
            MapData.GenerateMaps(this);

            SkillData.GenerateSkillList();
            EffectData.GenerateScriptList();

            //starter manager der opdaterer UI
            GameManager gm = new GameManager(this);

            //supposed to load player here         //lvl lif man mbon pbon
            gm._currentPlayer = new Player("Test Player", 1, 100, 110, 10, 5, new Resist(10, 0, 0, 0), 0, new int[] { } , 10, 20, "\\Custom\\Player.jpg");

            
            
            gBoxPlayer.Text = GameManager._GM._currentPlayer.GetName();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void SendToBox(string msg)
        {
            this.Invoke((MethodInvoker) delegate { txtBattleLog.AppendText(msg + "\r\n"); txtBattleLog.ScrollToCaret(); });
        }

        //Lavet en knap til alle maps! :D mapId står i knappens name og bliver hentet via substring
        private void btnLand_Click(object sender, EventArgs e)
        {
            map.GenerateMap(Convert.ToInt16(((Button)sender).Name.Substring(7, 1)));
            map.Visible = true;
        }

        //Knap til alle areas, areaId står i knappens name og bliver hentet via substring
        public void btnArea_Click(object sender, EventArgs e)
        {
            int areaId = Convert.ToInt16(((Button)sender).Name.Substring(7, 1));
            _currentArea = new Area(areaId);
            pBoxEnvironment.Image = _currentArea._areaPic;
            lblEnvironment.Text = _currentArea._name;
            map.Visible = false;
        }

        private void btnWander_Click(object sender, EventArgs e)
        {
            //Random Event or:
            bs = new BattleSystem(_currentArea, this);
            map.Visible = false;
            ToggleButtons();
        }

        private void ToggleButtons()
        {
                btnLand0.Enabled = !btnLand0.Enabled;
                btnLand1.Enabled = !btnLand1.Enabled;
                btnLand2.Enabled = !btnLand2.Enabled;
                btnLand3.Enabled = !btnLand3.Enabled;
                btnLand4.Enabled = !btnLand4.Enabled;
                btnLand5.Enabled = !btnLand5.Enabled;
                btnLand6.Enabled = !btnLand6.Enabled;
        }

        //Needed?
        /*public string GetlblPlayer(string controlName)
        {
            Label label = ((Label)Controls.Find("lblPlayer" + controlName, true)[0]);
            return label.Text;
        }*/

        public void UpdatelblPlayer(string[] stats)
        {
            this.Invoke((MethodInvoker)delegate 
            {
                lblPlayerLVL.Text = stats[0];
                lblPlayerHealth.Text = stats[1];
                lblPlayerMana.Text = stats[2];
                lblPlayerPhysicalBonus.Text = stats[3];
                lblPlayerMagicBonus.Text = stats[4];
            });
        }

        public void RenderEnemy(string src)
        {
            try
            {
                pBoxEnemy.Image = Image.FromFile(_workingDirectory + src);
            }
            catch { }
        }

        public void RenderPlayer()
        {
            try
            {
                pBoxPlayer.Image = Image.FromFile(_workingDirectory + GameManager._GM._currentPlayer.GetPic());
            }
            catch { }
        }

        public void UpdatelblEnemy(string[] stats)
        {
            this.Invoke((MethodInvoker)delegate
            {
                lblEnemyLVL.Text = stats[0];
                lblEnemyStatus.Text = stats[1];
                lblEnemyDistance.Text = stats[2];
                gBoxEnemy.Text = stats[5];
            });

        }

        public void ClearEnemy()
        {
            if (gBoxEnemy.Text != "")
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lblEnemyLVL.Text = "";
                    lblEnemyStatus.Text = "";
                    lblEnemyDistance.Text = "";
                    gBoxEnemy.Text = "";
                    pBoxEnemy.Image = null;
                    ToggleButtons();
                });
            }
            
        }

        public void ClearPlayer()
        {
                this.Invoke((MethodInvoker)delegate
                {
                    gBoxPlayer.Text = "";
                    lblPlayerLVL.Text = "";
                    lblPlayerHealth.Text = "";
                    lblPlayerMana.Text = "";
                    lblPlayerPhysicalBonus.Text = "";
                    lblPlayerMagicBonus.Text = "";
                    txtBattleLog.AppendText("Player Died."); // refactor
                });
        }

        private void btnBasicAttack_Click(object sender, EventArgs e)
        {
            if(bs != null && bs.GetBattleStatus())
            bs.SetAction(1, 0);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GameManager._GM.StopWatching();
        }
    }
}
