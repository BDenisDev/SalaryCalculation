using SalaryApplication.DataBase;
using SalaryApplication.Enums;
using SalaryApplication.Models;
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
    /// Interaction logic for WinCalculateSalary.xaml
    /// </summary>
    public partial class WinCalculateSalary : Window
    {
        public WinCalculateSalary()
        {
            InitializeComponent();
        }

        private void btSearchType_Click(object sender, RoutedEventArgs e)
        {
            if (cbType.Text == string.Empty)
            {
                MessageBox.Show("Пожалуйста выберите должность сотрудника!");
                brdType.BorderBrush = Brushes.Red;
            }

            if (cbType.Text == "Employee")
            {
                try
                {
                    DatabaseContext db = new DatabaseContext();
                    var query =
                        from employe in db.EmployeDb
                        where employe.EmployeeType == "Employee"
                        select new { employe.LastName, employe.FirstName, employe.MiddleName, employe.EnrollmentDate };

                    dgSearchEmpInList.ItemsSource = query.ToList();
                    brdType.BorderBrush = Brushes.Gray;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }

            else if (cbType.Text == "Manager")
            {
                try
                {
                    DatabaseContext db = new DatabaseContext();
                    var query =
                        from employe in db.EmployeDb
                        where employe.EmployeeType == "Manager"
                        select new { employe.LastName, employe.FirstName, employe.MiddleName, employe.EnrollmentDate };

                    dgSearchEmpInList.ItemsSource = query.ToList();
                    brdType.BorderBrush = Brushes.Gray;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }

            else if (cbType.Text == "Salesman")
            {
                try
                {
                    DatabaseContext db = new DatabaseContext();
                    var query =
                        from employe in db.EmployeDb
                        where employe.EmployeeType == "Salesman"
                        select new { employe.LastName, employe.FirstName, employe.MiddleName, employe.EnrollmentDate };

                    dgSearchEmpInList.ItemsSource = query.ToList();
                    brdType.BorderBrush = Brushes.Gray;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }

            lbCountOfEmployees.Content = dgSearchEmpInList.Items.Count;
        }

        private void cbType_MouseEnter(object sender, MouseEventArgs e)
        {
            cbType.ItemsSource = Enum.GetValues(typeof(EmployeeType)).Cast<EmployeeType>();
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgSearchEmpInList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCell cell = GetCell(dgSearchEmpInList.SelectedIndex, 3, dgSearchEmpInList);
            TextBlock tb = cell.Content as TextBlock;
            lblEnrollmentDate.Content = tb.Text;

            if (cbType.Text == "Employee")
            {
                lblType.Content = "Employee";
                EmployeeModel em = new EmployeeModel();
                em.BaseRate = 100;
                lblBaseRate.Content = em.BaseRate;

                var enrollmentDate = DateTime.Parse(tb.Text);

                var countOfYears = DateTime.Now.Year - enrollmentDate.Year;
                lblCountOfYears.Content = countOfYears;

                lblSalary.Content = em.CalculateSalary(enrollmentDate, em.BaseRate);

            }

            if (cbType.Text == "Manager")
            {
                lblType.Content = "Manager";
                ManagerModel mm = new ManagerModel();
                mm.BaseRate = 100;
                lblBaseRate.Content = mm.BaseRate;

                var enrollmentDate = Convert.ToDateTime(tb.Text);

                var countOfYears = DateTime.Now.Year - enrollmentDate.Year;
                lblCountOfYears.Content = countOfYears;

                lblSalary.Content = mm.CalculateSalary(enrollmentDate, mm.BaseRate);
            }

            if (cbType.Text == "Salesman")
            {
                lblType.Content = "Salesman";
                SalesmanModel sm = new SalesmanModel();
                sm.BaseRate = 100;
                lblBaseRate.Content = sm.BaseRate;

                var enrollmentDate = DateTime.Parse(tb.Text);
                var countOfYears = DateTime.Now.Year - enrollmentDate.Year;
                lblCountOfYears.Content = countOfYears;

                lblSalary.Content = sm.CalculateSalary(enrollmentDate, sm.BaseRate);
            }
        }

        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            try
            {
                T child = default(T);
                int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < numVisuals; i++)
                {
                    Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                    child = v as T;
                    if (child == null)
                    {
                        child = GetVisualChild<T>(v);
                    }
                    if (child != null)
                    {
                        break;
                    }
                }
                return child;
            }
            catch (Exception exc)
            {
                //MessageBox.Show(exc.Message);
                return null;
            }

        }

        public DataGridRow GetRow(int index, DataGrid dg)
        {
            try
            {
                DataGridRow row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(index);
                if (row == null)
                {
                    dg.UpdateLayout();
                    dg.ScrollIntoView(dg.Items[index]);
                    row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(index);

                }
                return row;
            }
            catch (Exception exc)
            {
                //MessageBox.Show(exc.Message);
                return null;
            }
        }

        public DataGridCell GetCell(int row, int column, DataGrid dg)
        {
            try
            {
                DataGridRow rowContainer = GetRow(row, dg);

                if (rowContainer != null)
                {
                    System.Windows.Controls.Primitives.DataGridCellsPresenter presenter = GetVisualChild<System.Windows.Controls.Primitives.DataGridCellsPresenter>(rowContainer);

                    DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                    if (cell == null)
                    {
                        dg.ScrollIntoView(rowContainer, dg.Columns[column]);
                        cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                    }
                    return cell;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exc)
            {
                //MessageBox.Show(exc.Message);
                return null;
            }
        }
    }
}
