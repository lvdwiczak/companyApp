using Company.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Company
{
    public partial class Form1 : Form
    {
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jakub\source\repos\CompanyApp\WindowsFormsApp1\company.mdf;Integrated Security=True;Connect Timeout=30";
        static DataContext companyDataContext = new DataContext(connectionString);
        static Table<Employee> empList = companyDataContext.GetTable<Employee>();
        static Table<salesInvoice> salesInvList = companyDataContext.GetTable<salesInvoice>();
        static Table<customer> custList = companyDataContext.GetTable<customer>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void neToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int newID = empList.Max(Employee => Employee.Id) + 1;
            Employee newEmployee = new Employee
            {
                Id = newID,
                Name = textBox1.Text,
                LastName = textBox2.Text,
                Email = textBox3.Text,
                Telefon = textBox4.Text,
            };
            empList.InsertOnSubmit(newEmployee);
            companyDataContext.SubmitChanges();
            listToolStripMenuItem_Click(this, null);
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var eList = from Employee in empList orderby Employee.Id select new
            {
                Employee.Id,
                Employee.Name,
                Employee.LastName,
                Employee.Email,
                Employee.Telefon
            };
            leftDataGridView.DataSource = eList;
            leftDataGridView.Tag = "eList";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void leftDataGridView_Click(object sender, EventArgs e)
        {
            int row = Convert.ToInt32(leftDataGridView.CurrentRow.Index);
            switch(leftDataGridView.Tag.ToString())
            {
                case "eList":
                    textBox1.Text = leftDataGridView.Rows[row].Cells[1].Value.ToString();
                    textBox1.Visible = true;
                    label1.Text = "Name";
                    label1.Visible = true;
                    textBox2.Text = leftDataGridView.Rows[row].Cells[2].Value.ToString();
                    textBox2.Visible = true;
                    label2.Text = "Last Name";
                    label2.Visible = true;
                    textBox3.Text = leftDataGridView.Rows[row].Cells[3].Value.ToString();
                    textBox3.Visible = true;
                    label3.Text = "Email";
                    label3.Visible = true;
                    textBox4.Text = leftDataGridView.Rows[row].Cells[4].Value.ToString();
                    textBox4.Visible = true;
                    label4.Text = "Phone";
                    label4.Visible = true;
                    textBox5.Visible = false;
                    label5.Visible = false;
                    textBox6.Visible = false;
                    label6.Visible = false;
                    textBox7.Visible = false;
                    label7.Visible = false;
                    var siList = from salesInvoice in salesInvList where (salesInvoice.EmployeeID == Convert.ToInt32(leftDataGridView.Rows[row].Cells[0].Value.ToString()))
                                 select new
                                 {
                                     salesInvoice.Id,
                                     salesInvoice.No,
                                     salesInvoice.Net,
                                     salesInvoice.VAT,
                                     salesInvoice.Date,
                                     salesInvoice.Paid
                                 };
                        rightDataGridView.DataSource = siList;
                    break;
                case "cList":
                    textBox1.Text = leftDataGridView.Rows[row].Cells[1].Value.ToString();
                    textBox1.Visible = true;
                    label1.Text = "Name";
                    label1.Visible = true;
                    textBox2.Text = leftDataGridView.Rows[row].Cells[2].Value.ToString();
                    textBox2.Visible = true;
                    label2.Text = "VatNo";
                    label2.Visible = true;
                    textBox3.Text = leftDataGridView.Rows[row].Cells[3].Value.ToString();
                    textBox3.Visible = true;
                    label3.Text = "Street";
                    label3.Visible = true;
                    textBox4.Text = leftDataGridView.Rows[row].Cells[4].Value.ToString();
                    textBox4.Visible = true;
                    label4.Text = "City";
                    label4.Visible = true;
                    textBox5.Visible = false;
                    label5.Visible = false;
                    textBox6.Visible = false;
                    label6.Visible = false;
                    textBox7.Visible = false;
                    label7.Visible = false;
                    var siCList = from salesInvoice in salesInvList
                                 where (salesInvoice.CustomerID == Convert.ToInt32(leftDataGridView.Rows[row].Cells[0].Value.ToString()))
                                 select new
                                 {
                                     salesInvoice.Id,
                                     salesInvoice.No,
                                     salesInvoice.Net,
                                     salesInvoice.VAT,
                                     salesInvoice.Date,
                                     salesInvoice.Paid
                                 };
                    rightDataGridView.DataSource = siCList;
                    break;
                case "siList":
                    textBox1.Text = leftDataGridView.Rows[row].Cells[1].Value.ToString();
                    textBox1.Visible = true;
                    label1.Text = "No";
                    label1.Visible = true;
                    textBox2.Text = leftDataGridView.Rows[row].Cells[2].Value.ToString();
                    textBox2.Visible = true;
                    label2.Text = "Net";
                    label2.Visible = true;
                    textBox3.Text = leftDataGridView.Rows[row].Cells[3].Value.ToString();
                    textBox3.Visible = true;
                    label3.Text = "Vat";
                    label3.Visible = true;
                    textBox4.Text = leftDataGridView.Rows[row].Cells[4].Value.ToString();
                    textBox4.Visible = true;
                    label4.Text = "Date";
                    label4.Visible = true;
                    textBox5.Text = leftDataGridView.Rows[row].Cells[5].Value.ToString();
                    textBox5.Visible = true;
                    label5.Text = "Paid";
                    label5.Visible = true;
                    textBox6.Text = leftDataGridView.Rows[row].Cells[6].Value.ToString();
                    textBox6.Visible = true;
                    label6.Text = "Customer ID";
                    label6.Visible = true;
                    textBox7.Text = leftDataGridView.Rows[row].Cells[7].Value.ToString();
                    textBox7.Visible = true;
                    label7.Text = "Employee ID";
                    label7.Visible = true;
                    break;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = Convert.ToInt32(leftDataGridView.CurrentRow.Index);
            int employeeID = Convert.ToInt32(leftDataGridView.Rows[row].Cells[0].Value.ToString());
            foreach(Employee employee in empList)
            {
                if (employeeID == employee.Id)
                {
                    employee.Name = textBox1.Text;
                    employee.LastName = textBox2.Text;
                    employee.Email = textBox3.Text;
                    employee.Telefon = textBox4.Text;
                }
            }
            companyDataContext.SubmitChanges();
            listToolStripMenuItem_Click(this, null);
        }

        private void listToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var cList = from customer in custList
                        orderby customer.Id
                        select new
                        {
                            customer.Id,
                            customer.Name,
                            customer.VATNo,
                            customer.Street,
                            customer.City
                        };
            leftDataGridView.DataSource = cList;
            leftDataGridView.Tag = "cList";
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int newID = custList.Max(customer => customer.Id) + 1;
            customer newc = new customer
            {
                Id = newID,
                Name = textBox1.Text,
                VATNo = textBox2.Text,
                Street = textBox3.Text,
                City = textBox4.Text,
            };
            custList.InsertOnSubmit(newc);
            companyDataContext.SubmitChanges();
            listToolStripMenuItem2_Click(this, null);
        }

        private void listToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var siCList = from salesInvoice in salesInvList
                          orderby salesInvoice.Id
                          select new
                          {
                              salesInvoice.Id,
                              salesInvoice.No,
                              salesInvoice.Net,
                              salesInvoice.VAT,
                              salesInvoice.Date,
                              salesInvoice.Paid,
                              salesInvoice.CustomerID,
                              salesInvoice.EmployeeID,
                          };
            leftDataGridView.DataSource = siCList;
            leftDataGridView.Tag = "siList";
        }

        private void notPaidInvoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var siCList = from salesInvoice in salesInvList
                          where (salesInvoice.Net + salesInvoice.VAT > salesInvoice.Paid)
                          orderby salesInvoice.Id
                          select new
                          {
                              salesInvoice.Id,
                              salesInvoice.No,
                              salesInvoice.Net,
                              salesInvoice.VAT,
                              salesInvoice.Date,
                              salesInvoice.Paid,
                              salesInvoice.CustomerID,
                              salesInvoice.EmployeeID,
                          };
            leftDataGridView.DataSource = siCList;
            leftDataGridView.Tag = "SiList";
        }

        private void createSalesInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int newID = salesInvList.Max(salesInvoice => salesInvoice.Id) + 1;
            salesInvoice newsi = new salesInvoice
            {
                Id = newID,
                No = textBox1.Text,
                Net = Convert.ToDouble(textBox2.Text),
                VAT = Convert.ToDouble(textBox3.Text),
                Date = Convert.ToDateTime(textBox4.Text),
                Paid = Convert.ToDouble(textBox5.Text),
                CustomerID = Convert.ToInt32(textBox6.Text),
                EmployeeID = Convert.ToInt32(textBox7.Text),
            };
            salesInvList.InsertOnSubmit(newsi);
            companyDataContext.SubmitChanges();
            listToolStripMenuItem1_Click(this, null);
        }
    }
}
