using AventStack.ExtentReports.Gherkin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.Drawing.Design;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Accord.Vision.Detection;
using Accord.Statistics.Kernels;
using Controller;
using DTO;
namespace App
{
    public partial class welcome : Form
    {               
        accountController acc = new accountController();
        Apartment apartment = new Apartment();
        Owner owner = new Owner();
        Mainform main = new Mainform();
        public bool exit;
        public bool logout;
        public welcome()
        {
            InitializeComponent();
            btapartment.Hide();
            btowner.Hide();
            pnSlide.Height = this.Height;
            btslidesigin.Hide();
            panelsignup.Hide();
            panelwork.Hide();
            CallToChildForm(main);
            
        }
        private void Work_Resize(object sender, EventArgs e)
        {
            
            panelwork.Height = Convert.ToInt32(0.85 * this.Height);
            panelwork.Width = Convert.ToInt32(0.85 * this.Width);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pnSlide.Location.X > -1)
            {
                pnSlide.Location = new Point(pnSlide.Location.X - 10, pnSlide.Location.Y);                
            }
            else
            {
                timer1.Stop();
                panelsignup.Show();
                PNsignin.Hide();
                btslidesignup.Hide();              
                btslidesigin.Show();
            }                  
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (pnSlide.Location.X <920)
            {
                pnSlide.Location = new Point(pnSlide.Location.X + 10, pnSlide.Location.Y);
            }
            else
            {
                timer2.Stop();
                PNsignin.Show();
                panelsignup.Hide();
                btslidesigin.Hide();
                btslidesignup.Show();
            }
        }    
       private void CallToChildForm(Form childForm)
        {
            //kiểm tra còn controls thì remove
            if (this.panelwork.Controls.Count > 0)
            {
                this.panelwork.Controls.RemoveAt(0);
            }
            //cài đặt thuộc tính cho form fr
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;

            //đưa fr vào làm control của pnwork
            this.panelwork.Controls.Add(childForm);
            this.panelwork.Tag = childForm;

            //hiển thị form fr
            childForm.Show();
        }

        private void btapartment_Click_1(object sender, EventArgs e)
        {
            CallToChildForm(apartment);
        }
        private void btowner_Click_1(object sender, EventArgs e)
        {
            owner.ChangeInfoForm(apartment.a);
            CallToChildForm(owner);           
        }

        private void btexit_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo);
            if (dlr == DialogResult.Yes)
            {
                this.Close();
                exit = true;
            }
            else
            {

            }
        }
        private void btlogout_Click(object sender, EventArgs e)
        {
            logout = true;
            this.Close();
        }
        private void btSignIn_Click(object sender, EventArgs e)
        {
            CallToChildForm(main);
        }    
        private void welcome_Resize(object sender, EventArgs e)
        {
            pnSlide.Height = Convert.ToInt32( this.Height);
           
            PNsignin.Height = Convert.ToInt32(0.85 * this.Height);
            PNsignin.Width = Convert.ToInt32(0.75 * this.Width);
        }

        private void btsingin_Click(object sender, EventArgs e)
        {
            if (acc.checkAccount(new DTO.accountDTO { UserName = txtusename.Text, Password =  txtpass.Text}))
            {
               
                MessageBox.Show("Đăng nhập thành công !!! ");
                timer3.Start();
                btSignIn.Show();
                PNsignin.Hide();
                
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại !!! ");
            }
        }

        // đăng kí account
        private void btSignup_Click(object sender, EventArgs e)
        {
            // dùng vòng lặp if else để kiểm tra từng thông tin 
            // nếu có sót thông báo
            if (txtsigupname.Text == "") //kiem tra ho ten
            {
                MessageBox.Show("Họ tên trống !!! ");
                txtsigupname.Focus(); // dua chuot ve lai o hoten                
            }
            else
            {
                if (txtsignupass.Text == "")// kiem tra so cmnd
                {
                    MessageBox.Show(" Số Chứng minh trống !!! ");
                    txtsignupass.Focus();
                }
                else
                {
                    if (txtfullname.Text == "")// kiem tra email
                    {
                        MessageBox.Show("Email trống !!! ");
                        txtfullname.Focus();
                    }
                    else
                    {
                        if (txtphone.Text == "") // kiem tra id phong
                        {
                            MessageBox.Show("ID phòng trống  !!! ");
                            txtphone.Focus();
                        }
                        else
                        {
                            if (acc.dkkAccount(new DTO.accountDTO { UserName = txtsigupname.Text, Password = txtsignupass.Text, FullName = txtfullname.Text, PhoneNumber = txtphone.Text, BirthDay = dtpbrith.Value.ToString() }))
                            {
                                // neu du lieu duoc dua vao csdl thi thong bao thanh cong
                                MessageBox.Show("Đăng kí thành công !!! ");
                                txtsigupname.Text = null;
                                txtsignupass.Text = null;
                                txtfullname.Text = null;
                                txtphone.Text = null;                              
                            }
                            else
                            {
                                // neu du lieu loi thi hien thong bao kh thanh cong
                                MessageBox.Show("ĐĂng kí khong thành công !!! ");
                            }

                        }
                    }
                }
            }
        }

        private void btslidesignup_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btslidesigin_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (pnSlide.Location.X > -1)
            {
                pnSlide.Location = new Point(pnSlide.Location.X - 10, pnSlide.Location.Y);
            }
            else
            {
                timer3.Stop();
                PNsignin.Hide();
                panelsignup.Hide();
                btslidesigin.Hide();
                btslidesignup.Hide();
                btowner.Show();
                btapartment.Show();
                panelwork.Show();
                btlogout.Show();
            }
        }
    }
   
}
