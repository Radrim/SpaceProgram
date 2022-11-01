using SpaceProgram.ADOApp;
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

namespace SpaceProgram.WindowApp
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public static List<Employee> employees { get; set; }
        public static List<Employee> employeesAll { get; set; }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDataBase();
            Refresh();
        }
        public void RefreshDataBase()
        {
            employees = new List<Employee>();
            employeesAll = new List<Employee>(DBConnection.Connection.Employee.Where(x => x.visiblity != false).ToList());
        }
        public void Refresh()
        {
            cb_cosmodrome.ItemsSource = DBConnection.Connection.Cosmodrome.Select(x => x.Name).ToList();
            cb_advertisment.ItemsSource = DBConnection.Connection.Advertisment.Select(x => x.Name).ToList();
            cb_employees.ItemsSource = employeesAll.ToList();
            cb_planet.ItemsSource = DBConnection.Connection.Planet.Select(x => x.Name).ToList();
            cb_spaceObject.ItemsSource = DBConnection.Connection.SpaceObject.Select(x => x.Name).ToList();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if(cb_employees.SelectedIndex == -1)
            //{
            //  return;
            //}
           //lb_currentCrew.Items.Add(cb_employees.SelectedItem);
            //cb_employees.Items.Remove(cb_employees.SelectedItem);
            if (cb_employees.Text != "")
            {
                var ChecC = cb_employees.SelectedItem as Employee;
                employeesAll.Remove(ChecC);
                //DBConnection.Connection.SaveChanges();
                cb_employees.Text = "";
                employees.Add(ChecC);
                lb_currentCrew.ItemsSource = employees.ToList();
            }
            Refresh();
        }
    }
}
