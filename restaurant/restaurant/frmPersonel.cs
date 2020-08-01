using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using restaurant.DAL;
using restaurant.COMMON;
using System.Collections;
using System.Data.OleDb;
using RKLib.ExportData;

namespace restaurant
{
    public partial class frmPersonel : Form
    {
        PersonDAL dalP = new PersonDAL();
        DetailInfoDAL dalD = new DetailInfoDAL();
        Person person = new Person();
        List<Person> personList = new List<Person>();
        public int id = 0;
        int userID = 0;
        string date = "";
        string Month = "";
        int Months = 0;
        int days = 0;
        int years = 0;
        DateTime d1;
        public string t1 = "";
        int timeout;
        public frmPersonel()
        {
            InitializeComponent();
            d1 = DateTime.Now.Date;
            Months = DateTime.Now.Month;
            days = DateTime.Now.Day;
            years = DateTime.Now.Year;
            string d2 = d1.ToShortDateString();
            int i = 0;
            if (Months.ToString().Length == 1 && days.ToString().Length == 1)
                for (; i <= 7; i++)
                    t1 = t1 + d2[i];
            else if (Months.ToString().Length == 1 || days.ToString().Length == 1)
                for (; i <= 8; i++)
                    t1 = t1 + d2[i];
            else
                for (; i <= 8; i++)
                    t1 = t1 + d2[i];

            txtDate.Text = t1;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            person = new Person();
            person = LoadControls();
            if (person.Name != "" && person.Family != "" && person.PersonCode != "")
            {
                bool Test = dalP.InsertPerson(person);
                if (Test == false)
                    MessageBox.Show("اشکال در ثبت", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (Test == true)
                {
                    MessageBox.Show("ثبت شد", "تایید", MessageBoxButtons.OK);
                    btnEdit.Enabled = false;
                    btnCancel.Enabled = false;
                    btnOK.Enabled = false;
                    Clear();
                    LoadUC();
                }
            }
            else
            {
                MessageBox.Show("لطفاً تمامی فیلدها را کامل نمائید");
            }
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.InitialDirectory = "Pictures";
            filedialog.RestoreDirectory = true;
            filedialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                txtPicture.Text = filedialog.FileName;
                PictureBox.ImageLocation = filedialog.FileName;
            }
        }

       

        private void txtcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnOK.Enabled = true;
        }

        private void gridPerson_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Clear();
            string q = "";
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(gridPerson.CurrentRow.Cells[0].Value.ToString());
                txtDate.Text = gridPerson.CurrentRow.Cells[1].Value.ToString().Trim();
                txtcode.Text = gridPerson.CurrentRow.Cells[2].Value.ToString();
                txtplace.Text = gridPerson.CurrentRow.Cells[3].Value.ToString();
                txtName.Text = gridPerson.CurrentRow.Cells[4].Value.ToString();
                txtFamily.Text = gridPerson.CurrentRow.Cells[5].Value.ToString();
                txtFatherName.Text = gridPerson.CurrentRow.Cells[6].Value.ToString();
                txtNationality.Text=gridPerson.CurrentRow.Cells[7].Value.ToString();
                txtPicture.Text = gridPerson.CurrentRow.Cells[8].Value.ToString();

                PictureBox.ImageLocation = txtPicture.Text.Trim();
                txtPassnumber.Text = gridPerson.CurrentRow.Cells[9].Value.ToString();
                txtDateExpire.Text = gridPerson.CurrentRow.Cells[10].Value.ToString();
                txtjob.Text = gridPerson.CurrentRow.Cells[11].Value.ToString();
                txtDatestart.Text = gridPerson.CurrentRow.Cells[12].Value.ToString();
                txtBirth.Text = gridPerson.CurrentRow.Cells[13].Value.ToString(); 
                txtreligion.Text = gridPerson.CurrentRow.Cells[14].Value.ToString();
                q = gridPerson.CurrentRow.Cells[15].Value.ToString();
                if (q.Trim() == "1")
                {
                    radiodivorced.Checked = false;
                    radiosingle.Checked = true;
                    radiomarried.Checked = false;
                }
                else if (q.Trim() == "2")
                {
                    radiodivorced.Checked = false;
                    radiosingle.Checked = false;
                    radiomarried.Checked = true;
                }
                else
                {
                    radiodivorced.Checked = true;
                    radiosingle.Checked = false;
                    radiomarried.Checked = false;
                }
                // = gridPerson.CurrentRow.Cells[15].Value.ToString();
                txtchildnumber.Value = Convert.ToInt32(gridPerson.CurrentRow.Cells[16].Value.ToString());
                txtEducation.Text = gridPerson.CurrentRow.Cells[17].Value.ToString();
                txtSkills.Text = gridPerson.CurrentRow.Cells[18].Value.ToString();
                txtExperiences.Text = gridPerson.CurrentRow.Cells[19].Value.ToString();
                string w;
                w = gridPerson.CurrentRow.Cells[20].Value.ToString();
                w = w.Trim();
                if (w[0] == '1')
                {
                    checkDiabetes.Checked = true;

                }
                if (w[1] == '1')
                {
                    checkHypertension.Checked = true;

                }
                if (w[2] == '1')
                {
                    checkHeart.Checked = true;
                }
                if (w[3] == '1')
                {
                    checkDermatitis.Checked = true;
                }
                if (w[4] == '1')
                {
                    checkSmoked.Checked = true;
                }
                if (w[5] == '1')
                {
                    checknonSmoked.Checked = true;
                }

                txtotherDiseases.Text = gridPerson.CurrentRow.Cells[21].Value.ToString();
                txtaddress1.Text = gridPerson.CurrentRow.Cells[22].Value.ToString();
                txtaddress2.Text = gridPerson.CurrentRow.Cells[23].Value.ToString();
                txttel1.Text = gridPerson.CurrentRow.Cells[24].Value.ToString();
                txttel2.Text = gridPerson.CurrentRow.Cells[25].Value.ToString();
                txtrelative1.Text = gridPerson.CurrentRow.Cells[26].Value.ToString();
                txtrelative2.Text = gridPerson.CurrentRow.Cells[27].Value.ToString();
                txttelr1.Text = gridPerson.CurrentRow.Cells[28].Value.ToString();
                txttelr2.Text = gridPerson.CurrentRow.Cells[29].Value.ToString();
                txtfirstSalary.Value =  Convert.ToInt32(gridPerson.CurrentRow.Cells[30].Value.ToString());
                userID = Convert.ToInt32(gridPerson.CurrentRow.Cells[31].Value.ToString());
                date = gridPerson.CurrentRow.Cells[1].Value.ToString();
                btnEdit.Enabled = true;
                btnCancel.Enabled = true;
                btnOK.Enabled = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            person = LoadControls();
            if (person != null)
            {
                dalP.EditPerson(person);
                MessageBox.Show("ویرایش شد");
                btnEdit.Enabled = false;
                btnCancel.Enabled = false;
                btnOK.Enabled = false;
                Clear();
                LoadUC();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnOK.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void FillControl(Person person)
        {


            txtDate.Text = person.Date.Trim();
            txtcode.Text = person.PersonCode;
            txtplace.Text = person.Place;
            txtName.Text = person.Name;
            txtFamily.Text = person.Family;
            txtFatherName.Text = person.FatherName;
            txtNationality.Text = person.Nationality;
            txtPicture.Text = person.PicturePath;
            txtPassnumber.Text = person.Passportnumber;
            txtDateExpire.Text = person.Endtime;
            txtjob.Text = person.Job;
            txtDatestart.Text = person.Starttime;
            txtBirth.Text = person.Birthday;
            txtreligion.Text = person.Religion;
            txtchildnumber.Value = Convert.ToDecimal(person.Childrennumber);
            if (person.Married =="1")
            {
                radiodivorced.Checked = false;
                radiosingle.Checked = true;
                radiomarried.Checked = false;
            }
            else if (person.Married == "2")
            {
                radiodivorced.Checked = false;
                radiosingle.Checked = false;
                radiomarried.Checked = true;
            }
            else if (person.Married == "3")
            {
                radiodivorced.Checked = true;
                radiosingle.Checked = false;
                radiomarried.Checked = false;
            }

            string w;
            w=person.Diseases.Trim();
            if (w[0] == '1')
            {
               checkDiabetes.Checked = true;
                
            }
            if (w[1] == '1')
            {
                checkHypertension.Checked =true;
                
            }
            if (w[2] == '1')
            {
                checkHeart.Checked = true;               
            }
            if (w[3] == '1')
            {
                checkDermatitis.Checked = true;
            }
            if (w[4] == '1')
            {
                checkSmoked.Checked = true;
            }
            if (w[5] == '1')
            {
                checknonSmoked.Checked =true;
            }

           
            // = gridPerson.CurrentRow.Cells[15].Value.ToString();
            //txtchildnumber.Text = Convert.ToInt32(gridPerson.CurrentRow.Cells[16].Value.ToString());

            txtEducation.Text = person.Education;
            txtSkills.Text = person.Skills;
            txtExperiences.Text = person.Experiences;
            //xt = gridPerson.CurrentRow.Cells[20].Value.ToString();

            txtotherDiseases.Text = person.otherDiseases;
            txtaddress1.Text = person.Address1;
            txtaddress2.Text = person.Address2;
            txttel1.Text = person.Tel1;
            txttel2.Text = person.Tel2;
            txtrelative1.Text = person.Relative1;
            txtrelative2.Text = person.Relative2;
            txttelr1.Text = person.Telr1;
            txttelr2.Text = person.Telr2;
            txtfirstSalary.Value =Convert.ToDecimal(person.firstSalary);
            userID = person.userID;
            id = person.PersonID;
            date = person.Date;
        }
        private void Clear()
        {
            txtDate.Text = string.Empty;
            txtcode.Text = string.Empty;
            txtplace.Text = string.Empty;
            txtName.Text = string.Empty;
            txtFamily.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            txtNationality.Text = string.Empty;
            txtPicture.Text = string.Empty;
            txtPassnumber.Text = string.Empty;
            txtDateExpire.Text = string.Empty;
            txtjob.Text = string.Empty;
            txtDatestart.Text = string.Empty;
            txtBirth.Text = string.Empty;
            txtreligion.Text = string.Empty;
            radiodivorced.Checked = false;
            radiosingle.Checked = false;
            radiomarried.Checked = false;
            txtEducation.Text = string.Empty;
            txtSkills.Text = string.Empty;
            txtExperiences.Text = string.Empty;
            txtchildnumber.Value = 0;
            checkDiabetes.Checked = false;
            checkHypertension.Checked = false;
            checkHeart.Checked = false;
            checkDermatitis.Checked = false;
            checkSmoked.Checked = false;
            checknonSmoked.Checked = false;
            txtotherDiseases.Text = string.Empty;
            txtaddress1.Text = string.Empty;
            txtaddress2.Text = string.Empty;
            txttel1.Text = string.Empty;
            txttel2.Text = string.Empty;
            txtrelative1.Text = string.Empty;
            txtrelative2.Text = string.Empty;
            txttelr1.Text = string.Empty;
            txttelr2.Text = string.Empty;
            txtfirstSalary.Value = 0;
            userID = person.userID;
            date = string.Empty;                                
        }

        private void gridMaker()
        {
            gridPerson.Columns[0].Visible = false;
            gridPerson.Columns[1].HeaderText = "تاریخ التسجیل";
            gridPerson.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridPerson.Columns[2].Visible = false;
            gridPerson.Columns[3].Visible = false;
            gridPerson.Columns[4].HeaderText = "الاسم";
            gridPerson.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridPerson.Columns[4].Width = 50;
            gridPerson.Columns[5].HeaderText = "اسم العائله";
            gridPerson.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridPerson.Columns[5].Width = 50;
            gridPerson.Columns[6].HeaderText = "اسم الاب";
            gridPerson.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridPerson.Columns[6].Width = 50;
            gridPerson.Columns[7].HeaderText = "جنسیه";
            gridPerson.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridPerson.Columns[7].Width = 50;
            gridPerson.Columns[8].Visible = false;
            gridPerson.Columns[9].Visible = false;
            gridPerson.Columns[10].Visible = false;
            gridPerson.Columns[11].HeaderText = "الوظیفه";
            gridPerson.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridPerson.Columns[11].Width = 50;
            gridPerson.Columns[12].Visible = false;
            gridPerson.Columns[13].Visible = false;
            gridPerson.Columns[14].Visible = false;
            gridPerson.Columns[15].Visible = false;
            gridPerson.Columns[16].Visible = false;
            gridPerson.Columns[17].Visible = false;
            gridPerson.Columns[18].Visible = false;
            gridPerson.Columns[19].Visible = false;
            gridPerson.Columns[20].Visible = false;
            gridPerson.Columns[21].Visible = false;
            gridPerson.Columns[22].Visible = false;
            gridPerson.Columns[23].Visible = false;
            gridPerson.Columns[24].Visible = false;
            gridPerson.Columns[25].Visible = false;
            gridPerson.Columns[26].Visible = false;
            gridPerson.Columns[27].Visible = false;
            gridPerson.Columns[28].Visible = false;
            gridPerson.Columns[29].Visible = false;
            gridPerson.Columns[30].Visible = false;
            gridPerson.Columns[31].Visible = false;
            gridPerson.Columns[32].Visible = false;
        }
        private void LoadUC()
        {
            DataTable dtpersonList = dalP.LoadPersonList(userID);
            gridPerson.DataSource = dtpersonList;
            gridMaker();
            userID = StaticUnitID.UserID1;
        }

        private Person LoadControls()
        {
            if (person == null)
                person = new Person();
            person.Date = txtDate.Text.Trim(); 
            person.PersonCode = txtcode.Text;
            person.Place = txtplace.Text; 
            person.Name = txtName.Text;
            person.Family = txtFamily.Text;
            person.FatherName = txtFatherName.Text;
            person.Nationality = txtNationality.Text; 
            person.PicturePath = txtPicture.Text;
            person.Passportnumber = txtPassnumber.Text;
            person.Endtime = txtDateExpire.Text;
            person.Job = txtjob.Text;
            person.Starttime = txtDatestart.Text; 
            person.Birthday = txtBirth.Text;
            person.Religion = txtreligion.Text;           

            if (radiosingle.Checked == true)
            {
                person.Married = "1";
            }
            if (radiomarried.Checked == true)
            {
                person.Married = "2";
            }
            if (radiodivorced.Checked == true)
            {
                person.Married = "3";
            }
            // = gridPerson.CurrentRow.Cells[15].Value.ToString();

            person.Childrennumber = Convert.ToInt32(txtchildnumber.Value);
            person.Education = txtEducation.Text;
            person.Skills = txtSkills.Text; 
            person.Experiences = txtExperiences.Text; 
            //xt = gridPerson.CurrentRow.Cells[20].Value.ToString();

            if (checkDiabetes.Checked == true)
               person.Diseases = "1";
            else
                person.Diseases = "0";           

            if (checkHypertension.Checked == true)
                person.Diseases = person.Diseases + "1";
            else
               person.Diseases = person.Diseases + "0";

            if (checkHeart.Checked == true)
               person.Diseases = person.Diseases + "1";
            else
                person.Diseases = person.Diseases + "0";

            if (checkDermatitis.Checked == true)
                person.Diseases = person.Diseases + "1";
            else
                person.Diseases = person.Diseases + "0";

            if (checkSmoked.Checked == true)
               person.Diseases = person.Diseases + "1";
            else
                person.Diseases = person.Diseases + "0";

            if (checknonSmoked.Checked == true)
                person.Diseases = person.Diseases + "1";
            else
                person.Diseases = person.Diseases + "0";

            person.Diseases = person.Diseases.Trim();
            person.firstSalary = 1;
            person.otherDiseases = txtotherDiseases.Text; 
            person.Address1 = txtaddress1.Text;
            person.Address2 = txtaddress2.Text;
            person.Tel1 = txttel1.Text; 
            person.Tel2 = txttel2.Text; 
            person.Relative1 = txtrelative1.Text; 
            person.Relative2 = txtrelative2.Text; 
            person.Telr1 = txttelr1.Text; 
            person.Telr2 = txttelr2.Text;
            person.firstSalary = Convert.ToInt32(txtfirstSalary.Value);            
            userID = person.userID;

            date = person.Date;
            if (person == null)
                person = new Person();
          
            person.PersonID = id;
            person.userID = userID;
          //  person.Date = date;
           
            return person;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            person = LoadControls();
            if (person.PersonID == 0)
                MessageBox.Show("رکوردی برای حذف شدن وجود ندارد");
            else
            {
                DialogResult dlr;
                dlr = MessageBox.Show("آیا شخص مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (person != null)
                    {
                        dalP.DeletePerson(person.PersonID, userID);
                        MessageBox.Show("حذف شد");
                        btnEdit.Enabled = false;
                        btnCancel.Enabled = false;
                        btnOK.Enabled = false;
                        Clear();
                        LoadUC();
                    }
                }
            }
        }

        private void frmPersonel_Load(object sender, EventArgs e)
        {
            LoadUC();
        }

        private void btnEncrease_Click(object sender, EventArgs e)
        {

            FrmIncreasesalary Increases = new FrmIncreasesalary();
            Increases.Show();
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label34.Text = "";
            // Export all the details
            try
            {
                DataTable dtpersonListe = dalP.LoadPersonListFORExcel(userID);
                RKLib.ExportData.Export objExport = new RKLib.ExportData.Export("Win");
                objExport.ExportDetails(dtpersonListe, Export.ExportFormat.Excel, "D:\\PersonInfo.xls");
                //txtnumber.Text = "گزارشگيري در مسير D:\\EmployeesInfo.xls با موفقيت انجام شد";
                label34.Text = " با موفقيت انجام شد D:\\PersonInfo.xls گزارشگيري";
            }
            catch (Exception Ex)
            {
                label34.Text = "گزارشگيري انجام نشد";
            }

        }
    }
}
