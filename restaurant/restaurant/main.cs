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
    public partial class main : Form
    {
        DataTable dtpersonList = new DataTable();
        DataTable dtpersonList2 = new DataTable();
        PersonDAL dalP = new PersonDAL();
        Person person = new Person();
        List<Person> personList = new List<Person>();
        Person p = new Person();

        ResidenceDAL dalr = new ResidenceDAL();
        Residence residence = new Residence();
        List<Residence> residenceList = new List<Residence>();

        RentDAL dalr2 = new RentDAL();
        Rent rent = new Rent();
        List<Rent> rentList = new List<Rent>();
        
        VacationDAL dalv = new VacationDAL();
        Vacation vacation = new Vacation();
        List<Vacation> vacationList = new List<Vacation>();

        CarDAL dalc = new CarDAL();
        Car car = new Car();
        List<Car> carList = new List<Car>();
        Car c = new Car();
        InsuranceDAL dalin = new InsuranceDAL();
        Insurance insurance = new Insurance();
        List<Insurance> insuranceList = new List<Insurance>();
        PlateDAL dalpl = new PlateDAL();
        Plate plate = new Plate();
        List<Plate> plateList = new List<Plate>();

        UtilityDAL dalu = new UtilityDAL();
        Utility utility = new Utility();
        List<Utility> utilityList = new List<Utility>();

        public int id = 0;
        int PersonID = 0;
        int userID = 0;
        string date = "";
        int Months = 0;
        int days = 0;
        int years = 0;
        int timeout;
        DateTime d1;
        public string t1 = "";

        public main()
        {
            InitializeComponent();
            d1 = DateTime.Now.Date;
            Months=DateTime.Now.Month;
            days = DateTime.Now.Day;
            years = DateTime.Now.Year;
            string d2 = d1.ToShortDateString();
            int i = 0;
            if(Months.ToString().Length==1 && days.ToString().Length==1)
                for (; i <= 7; i++)
                    t1 = t1 + d2[i];
            else if (Months.ToString().Length == 1 || days.ToString().Length == 1)
                for (; i <= 8; i++)
                t1 = t1 + d2[i];
            else
                for (; i <= 8; i++)
                    t1 = t1 + d2[i];

            //     txtname.Text = id.ToString();
            label1.Text = "تاریخ :" + t1;
            date = t1;
        }

        private void mnuPersonInfo_Click(object sender, EventArgs e)
        {
            frmPersonel Person = new frmPersonel();
            //Person.MdiParent = this;
            Person.Show();
        }
        public bool GetmaxDate(string a, string b)
        {
            bool r = false;
            int yeara = 0;
            int yearb = 0;
            int montha = 0;
            int monthb = 0;
            int daya = 0;
            int dayb = 0;
            a = a.Trim();
            b = b.Trim();
            if (a.Trim() != "")
            {
                yeara = GetYear(a);
                montha = GetMonth(a);
                daya = GetDayOfMonth(a);

            }
            if (b.Trim() != "")
            {
                yearb = GetYear(b);
                monthb = GetMonth(b);
                dayb = GetDayOfMonth(b);
            }
            if (yeara > yearb)
                r = true;
            else if (yeara == yearb)
                if (montha > monthb)
                    r = true;
                else if (montha == monthb)
                {
                    if (daya > dayb)
                        r = true;
                    else r = false;
                }
                else r = false;
            return r;

        }
        public int GetDayOfMonth(string x)
        {
            //d1 = DateTime.Now.Date;
            string dyear = x;
            int i = 0;
            string t = "";
            for (; i <= 2; i++)
                if (dyear.Length > i)
                    if (dyear[i] != '/')
                        t = t + dyear[i];
                    else
                        break;

            //     txtname.Text = id.ToString();
            int day = 0;
            if (t != "")
                day = Convert.ToInt32(t);

            return day;
        }
        public int GetMonth(string x)
        {
            //d1 = DateTime.Now.Date;
            string dyear = x;
            int i = 3;
            string t = "";
            if (dyear.Length > 1)
                if (dyear[1] == '/')
                    i = 2;
            for (; i <= 4; i++)
                if (dyear.Length > i)
                    if (dyear[i] != '/')
                        t = t + dyear[i];
                    else
                        break;
            //     txtname.Text = id.ToString();
            int Month = 0;
            if (t != "")
                Month = Convert.ToInt32(t);

            return Month;
        }
        public int GetYear(string x)
        {
            //d1 = DateTime.Now.Date;
            x = x.Trim();
            string dyear = x;
            int i = 6;
            string t = "";
            int l = x.Length;
            if (l > 4)
                if (dyear[4] == '/')
                {
                    i = 5;
                    for (; i < l; i++)

                        t = t + dyear[i];
                }
                else if (dyear[5] == '/')
                    for (int i2 = 6; i2 < l; i2++)
                        t = t + dyear[i2];

            //     txtname.Text = id.ToString();
            int year = 0;
            if (t != "")
                year = Convert.ToInt32(t);

            return year;
        }
        private void main_Load(object sender, EventArgs e)
        {
            
        }

        private void یادآورهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //residence
            List<Residence> LH = dalr.LoadResidenceListWithDistinctPersonID(userID);
            Residence hc = new Residence();
            for (int l = 0; LH.Count > l; l++)
            {
                hc.PersonID = LH[l].PersonID;
                List<Residence> lh2 = dalr.LoadResidenceList3(LH[l].PersonID);
                string max = lh2[0].expireDate;
                if (lh2.Count > 1)
                    for (int l2 = 1; lh2.Count > l2; l2++)
                    {
                        //if (lh2[l2].expireDate != "")
                        if (GetmaxDate(lh2[l2].expireDate, max) == true)
                            max = lh2[l2].expireDate;
                        if (GetmaxDate(t1, max) == true)
                        // if (max=<date)
                        {
                            Person p2 = dalP.LoadPerson(LH[l].PersonID, userID);
                            MessageBox.Show("کارت اقامت " + " " + p2.Name.Trim() + " " + p2.Family.Trim() + " " + "منفضی شده است");
                        }
                    }
                else if (lh2.Count == 1)
                    if (GetmaxDate(t1, max) == true)
                    // if (max=<date)
                    {
                        Person p2 = dalP.LoadPerson(LH[l].PersonID, userID);
                        MessageBox.Show("کارت اقامت " + " " + p2.Name.Trim() + " " + p2.Family.Trim() + " " + "منفضی شده است");
                    }
            }
            //healthcard
            HeaithCardDAL dalh = new HeaithCardDAL();
            List<HeaithCard> LHh = dalh.LoadHeaithCardListWithDistinctPersonID(userID);
            HeaithCard hch = new HeaithCard();
            for (int l = 0; LHh.Count > l; l++)
            {
                hch.PersonID = LHh[l].PersonID;
                List<HeaithCard> lh2 = dalh.LoadHeaithCardList3(LHh[l].PersonID);
                string max = lh2[0].expireDate;
                if (lh2.Count > 1)
                    for (int l2 = 1; lh2.Count > l2; l2++)
                    {
                        //if (lh2[l2].expireDate != "")
                        if (GetmaxDate(lh2[l2].expireDate, max) == true)
                            max = lh2[l2].expireDate;
                        if (GetmaxDate(t1, max) == true)
                        // if (max=<date)
                        {
                            Person p2 = dalP.LoadPerson(LHh[l].PersonID, userID);
                            MessageBox.Show("کارت سلامت " + " " + p2.Name.Trim() + " " + p2.Family.Trim() + " " + "منفضی شده است");
                        }
                    }
                else if (lh2.Count == 1)
                    if (GetmaxDate(t1, max) == true)
                    // if (max=<date)
                    {
                        Person p2 = dalP.LoadPerson(LHh[l].PersonID, userID);
                        MessageBox.Show("کارت سلامت " + " " + p2.Name.Trim() + " " + p2.Family.Trim() + " " + "منفضی شده است");
                    }
            }
            //labourcard
            LabourCardDAL dall = new LabourCardDAL();
            List<LabourCard> LHla = dall.LoadLabourCardListWithDistinctPersonID(userID);
            LabourCard hcla = new LabourCard();
            for (int l = 0; LHla.Count > l; l++)
            {
                hcla.PersonID = LHla[l].PersonID;
                List<LabourCard> lh2 = dall.LoadLabourCardList3(LHla[l].PersonID);
                string max = lh2[0].expireDate;
                if (lh2.Count > 1)
                    for (int l2 = 1; lh2.Count > l2; l2++)
                    {
                        //if (lh2[l2].expireDate != "")
                        if (GetmaxDate(lh2[l2].expireDate, max) == true)
                            max = lh2[l2].expireDate;
                        if (GetmaxDate(t1, max) == true)
                        // if (max=<date)
                        {
                            Person p2 = dalP.LoadPerson(LHla[l].PersonID, userID);
                            MessageBox.Show("کارت کارمندی " + " " + p2.Name.Trim() + " " + p2.Family.Trim() + " " + "منفضی شده است");
                        }
                    }
                else if (lh2.Count == 1)
                    if (GetmaxDate(t1, max) == true)
                    // if (max=<date)
                    {
                        Person p2 = dalP.LoadPerson(LHla[l].PersonID, userID);
                        MessageBox.Show("کارت کارمندی " + " " + p2.Name.Trim() + " " + p2.Family.Trim() + " " + "منفضی شده است");
                    }
            }

            //rent
            List<Rent> LHr = dalr2.LoadRentListmax(userID);
            Rent hcr = new Rent();
            // int l2 = 1;
            for (int l2 = 0; LHr.Count > l2; l2++)
            {

                if (GetmaxDate(t1, LHr[l2].expireDate) == true)
                {

                    MessageBox.Show("ایجاری شماره " + " " + LHr[l2].ContractNumber.Trim() + " و در تاریخ" + LHr[l2].Date.Trim() + " " + "و به آدرس  " + LHr[l2].Address.Trim() + " " + "منفضی شده است");
                }

            }

            //utility
            RentDAL dalr3 = new RentDAL();
            Rent rent = new Rent();
            List<Rent> rentList = new List<Rent>();

            List<Utility> LHut = dalu.LoadUtilityListWithDistinctRentID(userID);
            Utility hcu = new Utility();
            for (int l = 0; LHut.Count > l; l++)
            {
                hcu.RentID = LHut[l].RentID;
                List<Utility> lh2 = dalu.LoadUtilityList3(LHut[l].RentID);
                string max = lh2[0].UntilDate;
                if (lh2.Count > 1)
                    for (int l2 = 1; lh2.Count > l2; l2++)
                    {
                        //if (lh2[l2].expireDate != "")
                        if (GetmaxDate(lh2[l2].UntilDate, max) == true)
                            max = lh2[l2].UntilDate;
                        if (GetmaxDate(t1, max) == true)
                        // if (max=<date)                                              
                        {
                            Rent c2 = dalr3.LoadRent(LHut[l].RentID, userID);
                            MessageBox.Show("قبض شماره  " + " " + c2.ContractNumber.Trim() + "  با هزینه " + LHut[l].amount + " " + "منفضی شده است");

                        }
                    }
                else if (lh2.Count == 1)
                    if (GetmaxDate(t1, max) == true)
                    // if (max=<date)
                    {
                        Rent c2 = dalr3.LoadRent(LHut[l].RentID, userID);
                        MessageBox.Show("قبض شماره  " + " " + c2.ContractNumber.Trim() + "  با هزینه " + LHut[l].amount + " " + "منفضی شده است");

                    }
            }
            //vacation
            List<Vacation> LHv = dalv.LoadVacationListWithDistinctPersonID(userID);
            Vacation hcv = new Vacation();
            for (int l = 0; LHv.Count > l; l++)
            {
                hcv.PersonID = LHv[l].PersonID;
                List<Vacation> lh2 = dalv.LoadVacationList3(LHv[l].PersonID);
                string max = lh2[0].ExpireDate;
                if (lh2.Count > 1)
                    for (int l2 = 1; lh2.Count > l2; l2++)
                    {
                        //if (lh2[l2].expireDate != "")
                        if (GetmaxDate(lh2[l2].ExpireDate, max) == true)
                            max = lh2[l2].ExpireDate;
                        if (GetmaxDate(t1, max) == true)
                        // if (max=<date)
                        {
                            Person p2 = dalP.LoadPerson(LHv[l].PersonID, userID);
                            MessageBox.Show("مرخصی " + " " + p2.Name.Trim() + " " + p2.Family.Trim() + " " + "منفضی شده است");
                        }
                    }
                else if (lh2.Count == 1)
                    if (GetmaxDate(t1, max) == true)
                    // if (max=<date)
                    {
                        Person p2 = dalP.LoadPerson(LHv[l].PersonID, userID);
                        MessageBox.Show("مرخصی " + " " + p2.Name.Trim() + " " + p2.Family.Trim() + " " + "منفضی شده است");
                    }
            }

            //plate
            List<Plate> LHpl = dalpl.LoadPlateListWithDistinctCarID(userID);
            Plate hcp = new Plate();
            for (int l = 0; LHpl.Count > l; l++)
            {
                hcp.CarID = LHpl[l].CarID;
                List<Plate> lh2 = dalpl.LoadPlateList3(LHpl[l].CarID);
                string max = lh2[0].ExpireDate;
                if (lh2.Count > 1)
                    for (int l2 = 1; lh2.Count > l2; l2++)
                    {
                        //if (lh2[l2].expireDate != "")
                        if (GetmaxDate(lh2[l2].ExpireDate, max) == true)
                            max = lh2[l2].ExpireDate;
                        if (GetmaxDate(t1, max) == true)
                        // if (max=<date)
                        {
                            Car c2 = dalc.LoadCar(LHpl[l].CarID, userID);
                            MessageBox.Show("تمدید پلاک " + " " + c2.number.Trim() + " " + c2.Type.Trim() + " " + "منفضی شده است");
                        }
                    }
                else if (lh2.Count == 1)
                    if (GetmaxDate(t1, max) == true)
                    // if (max=<date)
                    {
                        Car c2 = dalc.LoadCar(LHpl[l].CarID, userID);
                        MessageBox.Show("تمدید پلاک " + " " + c2.number.Trim() + " " + c2.Type.Trim() + " " + "منفضی شده است");
                    }
            }
            //insurance
            List<Insurance> LHin = dalin.LoadInsuranceListWithDistinctCarID(userID);
            Insurance hci = new Insurance();
            for (int l = 0; LHin.Count > l; l++)
            {
                hci.CarID = LHin[l].CarID;
                List<Insurance> lh2 = dalin.LoadInsuranceList3(LHin[l].CarID);
                string max = lh2[0].ExpireDate;
                if (lh2.Count > 1)
                    for (int l2 = 1; lh2.Count > l2; l2++)
                    {
                        //if (lh2[l2].expireDate != "")
                        if (GetmaxDate(lh2[l2].ExpireDate, max) == true)
                            max = lh2[l2].ExpireDate;
                        if (GetmaxDate(t1, max) == true)
                        // if (max=<date)
                        {
                            Car c2 = dalc.LoadCar(LHin[l].CarID, userID);
                            MessageBox.Show("تمدید بیمه " + " " + c2.number.Trim() + " " + c2.Type.Trim() + " " + "منفضی شده است");
                        }
                    }
                else if (lh2.Count == 1)
                    if (GetmaxDate(t1, max) == true)
                    // if (max=<date)
                    {
                        Car c2 = dalc.LoadCar(LHin[l].CarID, userID);
                        MessageBox.Show("تمدید بیمه " + " " + c2.number.Trim() + " " + c2.Type.Trim() + " " + "منفضی شده است");
                    }
            } 

        }

        private void mnucarinfo_Click(object sender, EventArgs e)
        {
            FrmCar Car = new FrmCar();
            //Person.MdiParent = this;
            Car.Show();
        }

        private void mnuCar_Click(object sender, EventArgs e)
        {

        }

        private void mnurentinfo_Click(object sender, EventArgs e)
        {
            FrmRent Rent = new FrmRent();
            //Person.MdiParent = this;
            Rent.Show();
        }

        private void mnuutility_Click(object sender, EventArgs e)
        {
            FrmUtility Utility = new FrmUtility();
            //Person.MdiParent = this;
            Utility.Show();
        }

        private void mnuidentihycard_Click(object sender, EventArgs e)
        {
            FrmIdentifyCard IdentifyCard = new FrmIdentifyCard();
            //Person.MdiParent = this;
            IdentifyCard.Show();
        }

        private void mnulabourcard_Click(object sender, EventArgs e)
        {
            FrmLabourCard LabourCard = new FrmLabourCard();
            //Person.MdiParent = this;
            LabourCard.Show();
        }

        private void mnuHealthCard_Click(object sender, EventArgs e)
        {
            FrmHeaithCard HeaithCard = new FrmHeaithCard();
            //Person.MdiParent = this;
            HeaithCard.Show();
        }

        private void mnuResidence_Click(object sender, EventArgs e)
        {
            FrmResidence Residence = new FrmResidence();
            //Person.MdiParent = this;
            Residence.Show();
        }

        private void mnuDriverLicense_Click(object sender, EventArgs e)
        {
            FrmDriverLicense DriverLicense = new FrmDriverLicense();
            //Person.MdiParent = this;
            DriverLicense.Show();
        }

        private void mnuIncreasesalary_Click(object sender, EventArgs e)
        {
            FrmIncreasesalary Increasesalary = new FrmIncreasesalary();
            //Person.MdiParent = this;
            Increasesalary.Show();
        }

        private void mnuAdvance_Click(object sender, EventArgs e)
        {
            FrmAdvance Advance = new FrmAdvance();
            //Person.MdiParent = this;
            Advance.Show();
        }

        private void mnuSanctions_Click(object sender, EventArgs e)
        {
            FrmSanctions Sanctions = new FrmSanctions();
            //Person.MdiParent = this;
            Sanctions.Show();
        }

        private void mnuVacation_Click(object sender, EventArgs e)
        {
            FrmVacation Vacation = new FrmVacation();
            //Person.MdiParent = this;
            Vacation.Show();
        }

        private void ثبتمتعلقاتموظفینToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuPlate_Click(object sender, EventArgs e)
        {
            FrmPlate Plate = new FrmPlate();
            //Person.MdiParent = this;
            Plate.Show();
        }

        private void mnuInsurance_Click(object sender, EventArgs e)
        {
            FrmInsurance Insurance = new FrmInsurance();
            //Person.MdiParent = this;
            Insurance.Show();
        }

        private void mnuphonebook_Click(object sender, EventArgs e)
        {
            FrmPhoneBook PhoneBook = new FrmPhoneBook();
            //Person.MdiParent = this;
            PhoneBook.Show();
        }

        private void mnuencouragement_Click(object sender, EventArgs e)
        {
            Frmencouragement encouragement = new Frmencouragement();
            //Person.MdiParent = this;
            encouragement.Show();
        }












    }
}
