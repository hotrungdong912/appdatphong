using AventStack.ExtentReports.Gherkin.Model;
using Controller;
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
using System.Text.RegularExpressions;

namespace App
{
    public partial class Owner : Form
    {
        accountController controller = new accountController();
        
        public Owner()
        {
            InitializeComponent();          
        }
        // khi chon ben phong thi ben day hien
        public void ChangeInfoForm(string a)
        {
            txtIDRoom.Text = a;
        }     
        // load du lieu thi do bang du lieu vao
        private void Owner_Load_1(object sender, EventArgs e)
        {
           //tao bang du lieu datagridview
            DataTable dt = new DataTable();
            // do vao bang du lieu datagridview
            controller.DataOwner().Fill(dt);
            // hien thi bang 
            dvgOwner.DataSource = dt;
            // cho hien cot dau tien la STT
            dvgOwner.Columns[0].HeaderText = "STT";
            // du lieu cua so thu tu tu dong tang
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dvgOwner.Rows[i].Cells[0].Value = (i + 1);
            }
        }
        private void cleardata()
        {
            txtIdentitycard.Enabled = true;
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtFind.Text = "";
            txtIDRoom.Text = "";
            txtPhone.Text = "";
            txtIdentitycard.Text = "";
            dtpBirth.Text = "";
        }
        // khi ấn nút cập nhật
        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {    // dùng vòng lặp if else để kiểm tra từng thông tin 
             // nếu có sót thông báo     
            int a = dvgOwner.SelectedRows.Count;
            
            if (a == 1)
            {

                if (txtFullName.Text == "") //kiem tra ho ten
                {

                    MessageBox.Show("Không thể cập nhật Họ tên trống !!! ");
                    txtFullName.Focus(); // dua chuot ve lai o hoten                
                }
                else
                {
                    if (txtIdentitycard.Text == "")// kiem tra so cmnd
                    {
                        MessageBox.Show("Không thể cập nhật  Số Chứng minh trống !!! ");
                        txtIdentitycard.Focus();
                    }
                    else
                    {
                        if (txtEmail.Text == "")// kiem tra email
                        {
                            MessageBox.Show("Không thể cập nhật Email trống !!! ");
                            txtEmail.Focus();
                        }
                        else
                        {
                            if (txtIDRoom.Text == "") // kiem tra id phong
                            {
                                MessageBox.Show("Không thể cập nhật ID phòng trống  !!! ");
                                txtIDRoom.Focus();
                            }
                            else
                            {
                                if (txtPhone.Text == "")// kiem tra so dien thoai
                                {
                                    MessageBox.Show("Không thể cập nhật Số Điện Thoại Trống !!! ");
                                    txtPhone.Focus();
                                }
                                // neu moi thu on thi cho du lieu vao sql hien thong bap
                                else
                                {
                                    if (controller.UpdateOwner(new DTO.OwnerDTO { FullName = txtFullName.Text, IdentityCard = txtIdentitycard.Text, Email = txtEmail.Text, RoomID = txtIDRoom.Text, Phone = txtPhone.Text, Birthday = dtpBirth.Value.ToString() }))
                                    {

                                        MessageBox.Show("Cập nhật dữ liệu thành công !!! ");
                                        Owner_Load_1(sender, e);
                                        cleardata();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Cập nhật dữ liệu không thành công !!! ");


                                    }

                                }
                            }
                        }
                    }
                }               
               
            }
            else if (a > 1)
            {
                MessageBox.Show("Không thể cập nhật cùng lúc nhiều người !!! vui lòng cập nhật từng người");
            }
            else
            {
                MessageBox.Show("Chưa chọn người cập nhật !!! vui lòng chọn");
            }
        }
        // xoa du lieu 
        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
             // chon yes thi xoa / no thi khong xoa
            DialogResult dlr = MessageBox.Show("Bạn muốn xoá  ?", "Thông báo", MessageBoxButtons.YesNo);
           
            if (dlr == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dvgOwner.SelectedRows)
                {
                    // dat bien de chua so luong chon tren datagridview
                    int chon = row.Index;
                    // neu dong duoc chon  co the xoa
                    if (chon != -1)
                    {// goi ham xoa 
                        // truyen vao du lieu can so sanh khi xoa
                        if (controller.DeleteOwner(dvgOwner.Rows[chon].Cells[2].Value.ToString()))
                        {
                            
                           
                        }
                        else
                        {
                            MessageBox.Show("Xoa không thành công !!! ");                          
                        }
                    }


                }
                // xoa thanh cong thi thong bao xoa thanh cong
                // load lai bang du lieu
                MessageBox.Show("Xoá dữ liệu thành công !!! ");
                Owner_Load_1(sender, e);
                cleardata();

            }
            else
            {

            }
            
        }
        // do du lieu vao datagirdview
        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable(); // tao bang luu tru
            controller.FindOwner(txtFind.Text).Fill(dt); // lay du lieu tu sql dua vao bang du tru
            dvgOwner.DataSource = dt; // hien thi bang
        }


        // clear du lieu
        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {
            Owner_Load_1(sender, e);
            cleardata();

        }  
        // click vao data gridview hien thi thong tin tren cac textbox
        private void dvgOwner_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dvgOwner.Rows[e.RowIndex];           
            txtFullName.Text = row.Cells[1].Value.ToString();
            txtIdentitycard.Text = row.Cells[2].Value.ToString();
            txtPhone.Text = row.Cells[3].Value.ToString();
            txtEmail.Text = row.Cells[4].Value.ToString();
            dtpBirth.Text = row.Cells[5].Value.ToString();
            txtIDRoom.Text = row.Cells[6].Value.ToString();
            txtIdentitycard.Enabled = false;
        }

        // đăng kí dữ liệu
        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {   // dùng vòng lặp if else để kiểm tra từng thông tin 
            // nếu có sót thông báo
            if (txtFullName.Text == "") //kiem tra ho ten
            {
                MessageBox.Show("Họ tên trống !!! ");
                txtFullName.Focus(); // dua chuot ve lai o hoten                
            }
            else
            {
                if (txtIdentitycard.Text == "")// kiem tra so cmnd
                {
                    MessageBox.Show(" Số Chứng minh trống !!! ");
                    txtIdentitycard.Focus();
                }
                else
                {
                    if (txtEmail.Text == "")// kiem tra email
                    {
                        MessageBox.Show("Email trống !!! ");
                        txtEmail.Focus();
                    }
                    else
                    {
                        if (txtIDRoom.Text == "") // kiem tra id phong
                        {
                            MessageBox.Show("ID phòng trống  !!! ");
                            txtIDRoom.Focus();
                        }
                        else
                        {
                             if (txtPhone.Text == "")// kiem tra so dien thoai
                            {
                                MessageBox.Show("Số Điện Thoại Trống !!! ");
                                txtPhone.Focus();
                            }
                            // neu moi thu on thi cho du lieu vao sql hien thong bap
                            else
                            {
                                if (controller.InsertOwner(new DTO.OwnerDTO { FullName = txtFullName.Text, IdentityCard = txtIdentitycard.Text, Email = txtEmail.Text, RoomID = txtIDRoom.Text, Phone = txtPhone.Text, Birthday = dtpBirth.Value.ToString() }))
                                {
                                    // neu du lieu duoc dua vao csdl thi thong bao thanh cong
                                    MessageBox.Show("Thêm dữ liệu thành công !!! ");
                                    Owner_Load_1(sender, e);
                                    cleardata();
                                }
                                else
                                {
                                    // neu du lieu loi thi hien thong bao kh thanh cong
                                    MessageBox.Show("Thêm dữ liệu khong thành công !!! ");
                                }
                            }
                        }
                    }
                }
            }          
        }

       
    }
}
