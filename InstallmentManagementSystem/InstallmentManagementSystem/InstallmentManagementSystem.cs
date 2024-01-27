using InstallmentManagementSystem.installmentManagementClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstallmentManagementSystem
{
    public partial class InstallmentManagementSystem : Form
    {
        public InstallmentManagementSystem()
        {
            InitializeComponent();
        }
        installmentClass c = new installmentClass();

        private void InstallmentManagementSystem_Load(object sender, EventArgs e)
        {
            //Load Data on Data Girdview
            DataTable dt = c.Select();
            dgvCustomerList.DataSource = dt;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Get the value from input fields
            c.CustomerName = txtboxCustomerName.Text;
            c.FatherName = txtboxFatherName.Text;
            c.ContactNo = txtBoxContactNumber.Text;
            c.Address = txtBoxAddress.Text;
            c.OfficialAddress = txtBoxOfficialAddress.Text;
            c.BrandName = cmbBrandName.Text;
            c.ModelName = txtBoxModelName.Text;
            c.TotalAmount = int.Parse(txtBoxTotalAmount.Text);
            c.Advance = int.Parse(txtBoxAdvance.Text);
            c.G1Name = txtBoxG1Name.Text;
            c.G1Address = txtBoxG1Address.Text;
            c.G1PhoneNo = txtBoxG1PhoneNumber.Text;
            c.G2Name = txtBoxG2Name.Text;
            c.G2Address = txtBoxG2Address.Text;
            c.G2PhoneNo = txtBoxG2PhoneNumber.Text;

            //Inserting Data into Database using the method we created in installmentClass

            bool success = c.Insert(c);
            if(success == true)
            {
                //Successfully Inserted
                MessageBox.Show("New Customer Successfully Added");

                //Call the Clear Method here
                Clear();
            }
            else
            {
                //Failed to Add Customer
                MessageBox.Show("Failed to Add New Customer, Try Again...");
            }

            //Load Data on Data Girdview
            DataTable dt = c.Select();
            dgvCustomerList.DataSource = dt;
        }
        public void Clear()
        {
            txtBoxAccountNumber.Text = "";
            txtboxCustomerName.Text = "";
            txtboxFatherName.Text = "";
            txtBoxContactNumber.Text = "";
            txtBoxAddress.Text = "";
            txtBoxOfficialAddress.Text = "";
            cmbBrandName.Text = "";
            txtBoxModelName.Text = "";
            txtBoxTotalAmount.Text = "";
            txtBoxAdvance.Text = "";
            txtBoxG1Name.Text = "";
            txtBoxG1Address.Text = "";
            txtBoxG1PhoneNumber.Text = "";
            txtBoxG2Name.Text = "";
            txtBoxG2Address.Text = "";
            txtBoxG2PhoneNumber.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Get Data from the textBoxes
            c.AccountNo = int.Parse(txtBoxAccountNumber.Text);
            c.CustomerName = txtboxCustomerName.Text;
            c.FatherName = txtboxFatherName.Text;
            c.ContactNo = txtBoxContactNumber.Text;
            c.Address = txtBoxAddress.Text;
            c.OfficialAddress = txtBoxOfficialAddress.Text;
            c.BrandName = cmbBrandName.Text;
            c.ModelName = txtBoxModelName.Text;
            c.TotalAmount = Convert.ToInt32(txtBoxTotalAmount.Text);
            c.Advance = int.Parse(txtBoxAdvance.Text);
            c.G1Name = txtBoxG1Name.Text;
            c.G1Address = txtBoxG1Address.Text;
            c.G1PhoneNo = txtBoxG1PhoneNumber.Text;
            c.G2Name = txtBoxG2Name.Text;
            c.G2Address = txtBoxG2Address.Text;
            c.G2PhoneNo = txtBoxG2PhoneNumber.Text;

            //Update Data in the Database
            bool success = c.Update(c);
            if(success == true)
            {
                //Updated Successfully
                MessageBox.Show("Customer has been successfully Updated");

                //Load Data on Data Girdview
                DataTable dt = c.Select();
                dgvCustomerList.DataSource = dt;

                //Call Clear Method
                Clear();
            }
            else
            {
                //Failed to Update
                MessageBox.Show("Failed to Update Customer, Try Again...");
            }
        }

        private void dgvCustomerList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get Data from Data GridView and Load it to the textboxes respectively
            //Identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            txtBoxAccountNumber.Text = dgvCustomerList.Rows[rowIndex].Cells[0].Value.ToString();
            txtboxCustomerName.Text = dgvCustomerList.Rows[rowIndex].Cells[1].Value.ToString();
            txtboxFatherName.Text = dgvCustomerList.Rows[rowIndex].Cells[2].Value.ToString();
            txtBoxContactNumber.Text = dgvCustomerList.Rows[rowIndex].Cells[3].Value.ToString();
            txtBoxAddress.Text = dgvCustomerList.Rows[rowIndex].Cells[4].Value.ToString();
            txtBoxOfficialAddress.Text = dgvCustomerList.Rows[rowIndex].Cells[5].Value.ToString();
            cmbBrandName.Text = dgvCustomerList.Rows[rowIndex].Cells[6].Value.ToString();
            txtBoxModelName.Text = dgvCustomerList.Rows[rowIndex].Cells[7].Value.ToString();
            txtBoxTotalAmount.Text = dgvCustomerList.Rows[rowIndex].Cells[8].Value.ToString();
            txtBoxAdvance.Text = dgvCustomerList.Rows[rowIndex].Cells[9].Value.ToString();
            txtBoxG1Name.Text = dgvCustomerList.Rows[rowIndex].Cells[10].Value.ToString();
            txtBoxG1Address.Text = dgvCustomerList.Rows[rowIndex].Cells[11].Value.ToString();
            txtBoxG1PhoneNumber.Text = dgvCustomerList.Rows[rowIndex].Cells[12].Value.ToString();
            txtBoxG2Name.Text = dgvCustomerList.Rows[rowIndex].Cells[13].Value.ToString();
            txtBoxG2Address.Text = dgvCustomerList.Rows[rowIndex].Cells[14].Value.ToString();
            txtBoxG2PhoneNumber.Text = dgvCustomerList.Rows[rowIndex].Cells[15].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Call Clear Method
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Get the Account Number from the Application
            c.AccountNo = Convert.ToInt32(txtBoxAccountNumber.Text);
            bool success = c.Delete(c);
            if(success == true)
            {
                //Successfully Deleted
                MessageBox.Show("Account Successfully Deleted");

                //Refresh Data on GridView
                DataTable dt = c.Select();
                dgvCustomerList.DataSource = dt;

                //Call Clear Method
                Clear();
            }
            else
            {
                //Failed to Delete
                MessageBox.Show("Failed to Delete Account, Try Again...");
            }
        }
        static string connectionString = ConfigurationManager.ConnectionStrings["InstallmentManagementSystemDB"].ConnectionString;

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the value from the textbox
            string keyword = txtBoxSearch.Text;
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tbl_customer WHERE CustomerName LIKE '%"+keyword+"%' OR FatherName LIKE '%"+keyword+"%' OR Address LIKE '%"+keyword+"%'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvCustomerList.DataSource = dt;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
