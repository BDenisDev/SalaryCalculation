using SalaryApplication.DataBase;
using SalaryApplication.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SalaryApplication.UI
{
    /// <summary>
    /// Interaction logic for NewEmp.xaml
    /// </summary>
    public partial class NewEmp : Window
    {
        public NewEmp()
        {
            InitializeComponent();
            ShowListOfEmployees();
            ShowCountOfAllEmployees();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            DatabaseContext db = new DatabaseContext();
            var count = db.EmployeDb.Count();
            lblCountOfEmployees.Content = count;

            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var emp = new Employe()
                    {
                        FirstName = tbName.Text,

                        LastName = tbSurname.Text,
                        MiddleName = tbMiddleName.Text,
                        EmployeeType = comboBox.Text,
                        EnrollmentDate = dpEnrollmentDate.SelectedDate.Value,
                        CompanyId = Convert.ToInt32(cbListOfCompanies.Text)

                    };

                    context.EmployeDb.Add(emp);
                    context.SaveChanges();
                }

                MessageBox.Show("Сохранено успешно!");
                ShowCountOfAllEmployees();
                ClearTextBoxValues();
                DeleteIlluminationBoxes();
            }
            catch
            {
                MessageBox.Show("Пожалуйста заполните поля, обязательные для заполнения!");
                AddIlluminationBoxes();
            }


            dgListOfEmployees.ItemsSource = null;
            ShowListOfEmployees();
        }

        private void AddIlluminationBoxes()
        {
            tbMiddleName.BorderBrush = Brushes.Red;
            tbName.BorderBrush = Brushes.Red;
            tbSurname.BorderBrush = Brushes.Red;
            dpEnrollmentDate.BorderBrush = Brushes.Red;
            brdGroup.BorderBrush = Brushes.Red;
            brdCompId.BorderBrush = Brushes.Red;
        }

        private void DeleteIlluminationBoxes()
        {
            tbMiddleName.BorderBrush = Brushes.Gray;
            tbName.BorderBrush = Brushes.Gray;
            tbSurname.BorderBrush = Brushes.Gray;
            dpEnrollmentDate.BorderBrush = Brushes.Gray;
            brdGroup.BorderBrush = Brushes.Gray;
            brdCompId.BorderBrush = Brushes.Gray;
        }


        private void ShowCountOfAllEmployees()
        {
            DatabaseContext db = new DatabaseContext();
            var count = db.EmployeDb.Count();

            lblCountOfEmployees.Content = count;
        }

        public void ClearTextBoxValues()
        {
            tbMiddleName.Text = string.Empty;
            tbName.Text = string.Empty;
            tbSurname.Text = string.Empty;
            comboBox.Text = string.Empty;
            dpEnrollmentDate.Text = string.Empty;
            cbListOfCompanies.Text = string.Empty;
        }

        private void ShowListOfEmployees()
        {
            DatabaseContext db = new DatabaseContext();
            var query =
                from employee in db.EmployeDb
                where employee.FirstName != ""
                select new { employee.Id, employee.LastName, employee.FirstName, employee.MiddleName, employee.EnrollmentDate, employee.CompanyId };

            dgListOfEmployees.ItemsSource = query.ToList();
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void comboBox_MouseEnter(object sender, MouseEventArgs e)
        {
            comboBox.ItemsSource = Enum.GetValues(typeof(EmployeeType)).Cast<EmployeeType>();
            ChangeType();
        }
        private void ChangeType()
        {
            var type = (EmployeeType)comboBox.SelectedIndex;
            comboBox.Text = type.ToString();
        }

        private void cbListOfCompanies_MouseEnter(object sender, MouseEventArgs e)
        {
            DatabaseContext db = new DatabaseContext();

            var comps = db.CompanyDb.ToList();

            foreach (Company element in comps)
            {
                cbListOfCompanies.Items.Add(element.ID);
            }
        }
    }
}
