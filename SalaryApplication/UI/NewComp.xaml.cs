using SalaryApplication.DataBase;
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
    /// Interaction logic for NewComp.xaml
    /// </summary>
    public partial class NewComp : Window
    {
        public NewComp()
        {
            InitializeComponent();
            ShowListOfCompanies();
            ShowCountOfCompanies();
        }

        private void btAddNewComp_Click(object sender, RoutedEventArgs e)
        {
            if (tbNameOfNewComp.Text != string.Empty)
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    List<Company> cList = new List<Company>
                {
                    context.CompanyDb.Add(new Company {Name = tbNameOfNewComp.Text })
                };
                    context.SaveChanges();
                    MessageBox.Show("Сохранено успешно!");
                    ShowCountOfCompanies();
                    ClearTextBoxValue();
                    DeleteIlluminationBoxes();
                }
            }
            else
            {
                MessageBox.Show("Для добавления новой компании заполните поле 'название компании'!");
                AddIlluminationBoxes();

            }
            dgListOfCompanies.ItemsSource = null;
            ShowListOfCompanies();
        }

        private void AddIlluminationBoxes()
        {
            tbNameOfNewComp.BorderBrush = Brushes.Red;
        }

        private void DeleteIlluminationBoxes()
        {
            tbNameOfNewComp.BorderBrush = Brushes.Gray;
        }

        private void ShowCountOfCompanies()
        {
            DatabaseContext db = new DatabaseContext();
            var count = db.CompanyDb.Count();

            lblCountOfCompanies.Content = count;
        }

        public void ClearTextBoxValue()
        {
            tbNameOfNewComp.Text = string.Empty;
        }

        private void ShowListOfCompanies()
        {
            DatabaseContext db = new DatabaseContext();
            var query =
                from company in db.CompanyDb
                where company.Name != ""
                select new { company.ID, company.Name };

            dgListOfCompanies.ItemsSource = query.ToList();
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
