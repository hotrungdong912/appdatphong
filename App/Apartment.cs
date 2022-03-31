using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
namespace App
{
    public partial class Apartment : Form
    {
        public Apartment()
        {
            InitializeComponent();
        }
        public string a = "";
        accountController controller = new accountController();
        private void Apartment_Resize(object sender, EventArgs e)
        {
            pnRoom.Width = Convert.ToInt32(0.1 * this.Width);
            pnRoom.Height = Convert.ToInt32(0.1 * this.Height);
        }
          
        private void Apartment_Load_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            controller.DataRoom().Fill(dt);
            dvgroom.DataSource = dt;
            LoadRooms();
        }

        private void dvgroom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtApartID.Enabled = false;
            DataGridViewRow row = dvgroom.Rows[e.RowIndex];
            txtApartID.Text = row.Cells[0].Value.ToString();
            a = row.Cells[0].Value.ToString();
            txtFloor.Text = row.Cells[1].Value.ToString();
            txtPeople.Text = row.Cells[2].Value.ToString();
            txtNo.Text = row.Cells[3].Value.ToString();
        }
        private void LoadRooms()
        {
            LoadRoom(R0101);
            LoadRoom(R0102);
            LoadRoom(R0103);
            LoadRoom(R0104);
            LoadRoom(R0201);
            LoadRoom(R0202);
            LoadRoom(R0203);
            LoadRoom(R0301);
            LoadRoom(R0302);
            LoadRoom(R0303);
            LoadRoom(R0304);
            LoadRoom(R0401);
            LoadRoom(R0402);
            LoadRoom(R0403);
            LoadRoom(R0501);
            LoadRoom(R0502);
            LoadRoom(R0503);
            LoadRoom(R0504);
        }

        private void LoadRoom(Button btn)
        {
            if (controller.LoadRoom(btn.Name) != 0)
            {
                btn.BackColor = Color.LightPink;

            }
            else
            {
                
            }
        }

        private void dvgroom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //controller.FindRoom(cmbFindApart.Text).Fill(dt);
            //dgvRoom.DataSource = dt;
        }

        private void Apartment_Resize_1(object sender, EventArgs e)
        {
           
            this.pnRoom.Height = Convert.ToInt32(0.50 * this.Height);
            dvgroom.Height = Convert.ToInt32(this.Height * 0.5);
            this.panel1.Height = Convert.ToInt32(0.30 * this.Height);
            //panel1.Left = Convert.ToInt32(50 + 0.5 * (pnRoom.Width - panel1.Width));
            //panel1.Width = panel1.Left + 400;
        }

        private void dvgroom_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtApartID.Enabled = false;
            DataGridViewRow row = dvgroom.Rows[e.RowIndex];
            txtApartID.Text = row.Cells[0].Value.ToString();
            a = row.Cells[0].Value.ToString();
            txtFloor.Text = row.Cells[1].Value.ToString();
            txtPeople.Text = row.Cells[2].Value.ToString();
            txtNo.Text = row.Cells[3].Value.ToString();
        }

        private void gunaAdvenceButton4_Click_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            controller.FindRoom(cmbFindApart.Text).Fill(dt);
            dvgroom.DataSource = dt;
        }

        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {
            Apartment_Load_1(sender, e);
        }
        private void Room(string a)
        {
            DataTable dt = new DataTable();
            controller.FindRoom(a).Fill(dt);
            dvgroom.DataSource = dt;
        }                  
        public string b = "";
      

        private void R0101_Click(object sender, EventArgs e)
        {
            b = R0101.Text;
            Room(b);
        }

        private void R0102_Click(object sender, EventArgs e)
        {
            b = R0102.Text;
            Room(b);
        }

        private void R0103_Click(object sender, EventArgs e)
        {
            b = R0103.Text;
            Room(b);
        }

        private void R0104_Click(object sender, EventArgs e)
        {
            b = R0104.Text;
            Room(b);
        }

        private void R0201_Click(object sender, EventArgs e)
        {
            b = R0201.Text;
            Room(b);
        }

        private void R0202_Click(object sender, EventArgs e)
        {
            b = R0202.Text;
            Room(b);
        }

        private void R0203_Click(object sender, EventArgs e)
        {
            b = R0203.Text;
            Room(b);
        }

        private void R0301_Click(object sender, EventArgs e)
        {
            b = R0301.Text;
            Room(b);
        }

        private void R0302_Click(object sender, EventArgs e)
        {
            b = R0302.Text;
            Room(b);
        }

        private void R0303_Click(object sender, EventArgs e)
        {
            b = R0303.Text;
            Room(b);
        }

        private void R0304_Click(object sender, EventArgs e)
        {
            b = R0304.Text;
            Room(b);
        }

        private void R0401_Click(object sender, EventArgs e)
        {
            b = R0401.Text;
            Room(b);
        }

        private void R0402_Click(object sender, EventArgs e)
        {
            b = R0402.Text;
            Room(b);
        }

        private void R0403_Click(object sender, EventArgs e)
        {
            b = R0403.Text;
            Room(b);
        }

        private void R0501_Click(object sender, EventArgs e)
        {
            b = R0501.Text;
            Room(b);
        }

        private void R0502_Click(object sender, EventArgs e)
        {
            b = R0502.Text;
            Room(b);
        }

        private void R0503_Click(object sender, EventArgs e)
        {
            b = R0503.Text;
            Room(b);
        }

        private void R0504_Click(object sender, EventArgs e)
        {
            b = R0504.Text;
            Room(b);
        }
    }
}

