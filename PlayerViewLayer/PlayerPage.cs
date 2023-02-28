using System;
using System.Data;
using System.Windows.Forms;
using ModelLayer;
using ServiceLayer;

namespace PlayerViewLayer
{
    public partial class PlayerPage : Form
    {
        public PlayerPage()
        {
            InitializeComponent();
        }
        Player player= new Player();
        Operations opr=new Operations();
        DataTable dt=new DataTable();
        string gender;
        int playerId;
        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                player.name = playerName.Text;
                player.country = playerCountry.Text;
                if (rbMale.Checked == true)
                {
                    gender = "Male";
                }
                if (rbFemale.Checked == true)
                {
                    gender = "Female";
                }
                player.gender = gender;
                player.jDate = Convert.ToDateTime(JDate.Value.ToShortDateString());
                player.runs = Convert.ToInt32(NRuns.Value.ToString());
                player.wickets = Convert.ToInt32(Nwickets.Value.ToString());
                player.dob = Convert.ToDateTime(DOB.Value.ToShortDateString());
                player.rank = playerRank.Text.ToString();
                int rows = 0;
                try
                {
                    rows = opr.insertPlayer(player);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (rows > 0)
                {
                    MessageBox.Show("Player Added Successfully!!!!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetAllPlayer();
                    ResetPlayer();
                }
            }
            else
            {
                MessageBox.Show("Please insert the data in the fields ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ResetPlayer()
        {

            playerName.Text="";
            playerCountry.Text="";
            rbMale.Checked = false;
            JDate.Value = DateTime.Now;
           NRuns.Value=0;
            Nwickets.Value = 0;
            DOB.Value = DateTime.Now;
            playerRank.Text = "";
        }
        private bool isValid()
        {
            if(playerName.Text==string.Empty || playerCountry.Text==string.Empty || (rbMale.Checked==true && rbFemale.Checked==true) || JDate.Text==string.Empty || NRuns.Value==0 || Nwickets.Value==0 || DOB.Text==string.Empty || playerRank.Text==string.Empty )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PlayerPage_Load(object sender, EventArgs e)
        {
            GetAllPlayer();
        }

        private void GetAllPlayer()
        {
            dt=opr.getAllPlayers();
            playerRecordView.DataSource = dt;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            ResetPlayer();
        }

        private void playerRecordView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            playerId = Convert.ToInt32(playerRecordView.SelectedRows[0].Cells[0].Value.ToString());
            playerName.Text = playerRecordView.SelectedRows[0].Cells[1].Value.ToString();
            playerCountry.Text = playerRecordView.SelectedRows[0].Cells[8].Value.ToString();
            string gen = playerRecordView.SelectedRows[0].Cells[2].Value.ToString();
            if (gen == "Male")
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }
            JDate.Value =Convert.ToDateTime(playerRecordView.SelectedRows[0].Cells[3].Value.ToString());
            NRuns.Value = Convert.ToInt32(playerRecordView.SelectedRows[0].Cells[4].Value.ToString());
            Nwickets.Value = Convert.ToInt32(playerRecordView.SelectedRows[0].Cells[5].Value.ToString());
            DOB.Value = Convert.ToDateTime(playerRecordView.SelectedRows[0].Cells[6].Value.ToString());
            playerRank.Text = playerRecordView.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (playerId > 0)
            {

                if (isValid())
                {
                    player.id = playerId;
                    player.name = playerName.Text;
                    player.country = playerCountry.Text;
                    if (rbMale.Checked == true)
                    {
                        gender = "Male";
                    }
                    if (rbFemale.Checked == true)
                    {
                        gender = "Female";
                    }
                    player.gender = gender;
                    player.jDate = Convert.ToDateTime(JDate.Value.ToShortDateString());
                    player.runs = Convert.ToInt32(NRuns.Value.ToString());
                    player.wickets = Convert.ToInt32(Nwickets.Value.ToString());
                    player.dob = Convert.ToDateTime(DOB.Value.ToShortDateString());
                    player.rank = playerRank.Text.ToString();
                    int rows = 0;
                    try
                    {
                        rows = opr.updatePlayer(player);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    if (rows > 0)
                    {
                        GetAllPlayer();
                        ResetPlayer();
                        MessageBox.Show("Player Updated Successfully!!!!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                }
                else
                {
                    MessageBox.Show("Please insert the data in the fields ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select the row to update ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (playerId > 0)
            {

                if (isValid())
                {
                    player.id = playerId;
                    player.name = playerName.Text;
                    player.country = playerCountry.Text;
                    if (rbMale.Checked == true)
                    {
                        gender = "Male";
                    }
                    if (rbFemale.Checked == true)
                    {
                        gender = "Female";
                    }
                    player.gender = gender;
                    player.jDate = Convert.ToDateTime(JDate.Value.ToShortDateString());
                    player.runs = Convert.ToInt32(NRuns.Value.ToString());
                    player.wickets = Convert.ToInt32(Nwickets.Value.ToString());
                    player.dob = Convert.ToDateTime(DOB.Value.ToShortDateString());
                    player.rank = playerRank.Text.ToString();
                    int rows = 0;
                    try
                    {
                        rows = opr.deletePlayer(player);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    if (rows > 0)
                    {
                        GetAllPlayer();
                        ResetPlayer();
                        MessageBox.Show("Player deleted Successfully!!!!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please insert the data in the fields ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select the row to delete ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
