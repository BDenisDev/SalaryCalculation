using SalaryApplication.DataBase;
using SalaryApplication.UI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalaryApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DatabaseContext _dbContext;
        public MainWindow()
        {
            InitializeComponent();
            _dbContext = new DatabaseContext();
            //_dbContext.CreateEmployeeTable();
            //_dbContext.CreateCompanyTable();
            //_dbContext.InitializeDatabase();
        }

        private void btAddCompany_Click(object sender, RoutedEventArgs e)
        {
            NewComp nc = new NewComp();
            nc.Show();
        }

        private void btAddNewEmp_Click(object sender, RoutedEventArgs e)
        {
            NewEmp newemp = new NewEmp();
            newemp.Show();
        }

        private void btCalculateSalary_Click(object sender, RoutedEventArgs e)
        {
            WinCalculateSalary wcs = new WinCalculateSalary();
            wcs.Show();
        }
    }
}
