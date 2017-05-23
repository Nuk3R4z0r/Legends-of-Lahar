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
        private bool _formReady;
        private GameManager gm;

        public MainForm()
        {
            InitializeComponent();

            //GameManager isn't allowed to update the UI if the UI isn't ready
            _formReady = false;
            HandleCreated += MainForm_HandleCreated;

            //Laver map behind the scenes
            map = new MapControl();
            map.Visible = false;
            map.Location = new Point(204, 208);
            tabControl1.TabPages[0].Controls.Add(map);
            map.BringToFront();

            //Load Game Resources, needs to be in order at this time
            SkillData.GenerateSkillList();
            EffectData.GenerateScriptList();
            ItemData.GenerateItems();
            MonsterData.GenerateMonsters();
            MapData.GenerateMaps(this);

            //starting gamemanager der updates entities and UI
            gm = new GameManager(this);
            gm.Start();
        }

        private void MainForm_HandleCreated(object sender, EventArgs e)
        {
            btnWander.Enabled = false;

            //Transparency fix
            pBoxPlayer.Parent = pBoxEnvironment;
            pBoxEnemy.Parent = pBoxEnvironment;
            lblEnvironment.Parent = pBoxEnvironment;

            //To make the skills show up with their given name
            cBoxSkill.DisplayMember = "Name";

            //player name
            gBoxPlayer.Text = GameManager._GM.CurrentPlayer.GetName();

            _formReady = true;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        public void SendToBox(string msg)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtBattleLog.AppendText(msg + "\r\n");
                txtBattleLog.ScrollToCaret();
            });
        }

        //Button for the lands
        private void btnLand_Click(object sender, EventArgs e)
        {
            map.GenerateMap(Convert.ToInt16(((Button)sender).Name.Substring(7, 1)));
            map.Visible = true;
        }

        //Button for the areas within the lands
        public void btnArea_Click(object sender, EventArgs e)
        {
            int areaId = Convert.ToInt16(((Button)sender).Name.Substring(7, 1));
            gm.CurrentPlayer.CurrentArea = new Area(areaId);
            pBoxEnvironment.Image = gm.CurrentPlayer.CurrentArea._areaPic;
            lblEnvironment.Text = gm.CurrentPlayer.CurrentArea._name;
            btnWander.Enabled = true;
            map.Visible = false;
        }

        private void btnWander_Click(object sender, EventArgs e)
        {
            //Random Event or battle
            gm.BS = new BattleSystem(gm.CurrentPlayer.CurrentArea, this);
            map.Visible = false;
            btnWander.Enabled = false;
            ToggleButtons();
        }

        public void ToggleButtons()
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

        //updates the UI for the player
        public void UpdatelblPlayer(string[] stats)
        {
            if (_formReady)
                this.Invoke((MethodInvoker)delegate
                {
                    lblPlayerLVL.Text = stats[0];
                    lblPlayerHealth.Text = stats[1];
                    lblPlayerMana.Text = stats[2];
                    lblPlayerPhysicalBonus.Text = stats[3];
                    lblPlayerMagicBonus.Text = stats[4];
                    var test = GameManager._GM.CurrentPlayer.GetSkills().Except(cBoxSkill.Items.Cast<Skill>().ToList());

                    if (test.Any()) //REFACTOR ME
                    {
                        cBoxSkill.Items.Clear();
                        cBoxSkill.Items.AddRange(GameManager._GM.CurrentPlayer.GetSkills().ToArray());
                    }
                });
        }

        //image for enemy
        public void RenderEnemy(string src)
        {
            try
            {
                pBoxEnemy.Image = Image.FromFile(GameManager._GM.WorkingDirectory + src);
            }
            catch { }
        }

        //image for player
        public void RenderPlayer()
        {
            try
            {
                pBoxPlayer.Image = Image.FromFile(GameManager._GM.WorkingDirectory + GameManager._GM.CurrentPlayer.GetPic());
            }
            catch { }
        }

        //updates the UI for the enemy
        public void UpdatelblEnemy(string[] stats)
        {
            if (_formReady)
                this.Invoke((MethodInvoker)delegate
            {
                lblEnemyLVL.Text = stats[0];
                lblEnemyStatus.Text = stats[1];
                lblEnemyDistance.Text = stats[2];
                gBoxEnemy.Text = stats[5];
            });

        }

        //after each enemy is dead
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
                    btnWander.Enabled = true;
                    ToggleButtons();
                });
            }
        }

        //when player dies
        public void ClearPlayer()
        {
            if (_formReady)
                this.Invoke((MethodInvoker)delegate
                {
                    gBoxPlayer.Text = "";
                    lblPlayerLVL.Text = "";
                    lblPlayerHealth.Text = "";
                    lblPlayerMana.Text = "";
                    lblPlayerPhysicalBonus.Text = "";
                    lblPlayerMagicBonus.Text = "";
                    GameManager._GM.CurrentPlayer = null;
                    txtBattleLog.AppendText("Player Died."); // refactor
                    gm.Start();
                });
        }

        //button for basic attack
        private void btnBasicAttack_Click(object sender, EventArgs e)
        {
            if (gm.BS != null && gm.BS.GetBattleStatus())
                gm.BS.SetAction(1, 0);
        }

        //button for use skill
        private void btnUseSkill_Click(object sender, EventArgs e)
        {
            if (gm.BS != null && gm.BS.GetBattleStatus())
                gm.BS.SetAction(3, ((Skill)cBoxSkill.SelectedItem).ID);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GameManager._GM.StopWatching();
        }

    }
}
