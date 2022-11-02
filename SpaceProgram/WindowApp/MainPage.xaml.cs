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

        public static List<Advertisment> advertisments { get; set; }
        public static List<Advertisment> advertismentsAll { get; set; }

        private decimal previousSpaceObjCost = 0;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDataBase();
            Refresh();
        }
        public void RefreshDataBase()
        {
            employees = new List<Employee>();
            employeesAll = new List<Employee>(DBConnection.Connection.Employee.Where(x => true).ToList());

            advertisments = new List<Advertisment>();
            advertismentsAll = new List<Advertisment>(DBConnection.Connection.Advertisment.Where(x => true).ToList());
        }
        public void Refresh()
        {
            cb_cosmodrome.ItemsSource = DBConnection.Connection.Cosmodrome.ToList();
            cb_advertisment.ItemsSource = advertismentsAll.ToList();
            cb_employees.ItemsSource = employeesAll.ToList();
            cb_planet.ItemsSource = DBConnection.Connection.Planet.ToList();
            cb_spaceObject.ItemsSource = DBConnection.Connection.SpaceObject.ToList();
            tb_totalBalance.Text = DBConnection.Connection.Balance.FirstOrDefault().TotalCash.ToString();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cb_employees.Text != "")
            {
                var ChecC = cb_employees.SelectedItem as Employee;
                employeesAll.Remove(ChecC);
                //DBConnection.Connection.SaveChanges();
                cb_employees.Text = "";
                employees.Add(ChecC);
                lb_currentCrew.ItemsSource = employees.ToList();
                Refresh();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (cb_advertisment.Text != "")
            {
                var ChecC = cb_advertisment.SelectedItem as Advertisment;
                advertismentsAll.Remove(ChecC);
                //DBConnection.Connection.SaveChanges();
                tb_PotentialIncome.Text = (decimal.Parse(tb_PotentialIncome.Text) + ChecC.Income).ToString();
                cb_advertisment.Text = "";
                advertisments.Add(ChecC);
                lb_currentAdvertisment.ItemsSource = advertisments.ToList();
                Refresh();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(lb_currentCrew.Items.Count == 0 || cb_cosmodrome.SelectedIndex == -1 || cb_planet.SelectedIndex == -1 || cb_spaceObject.SelectedIndex == -1)
            {
                MessageBox.Show("Not all fields are full!");
                return;
            }

            Crew newCrew = new Crew();

            Route newRoute = new Route()
            {
                DestinationPlanet_ID = (cb_planet.SelectedItem as Planet).Planet_ID,
                StartingCosmodrome_ID = (cb_cosmodrome.SelectedItem as Cosmodrome).Cosmodrome_ID,
            };

            Flight newFlight = new Flight()
            {
                Crew_ID = newCrew.Crew_ID,
                Route_ID = newRoute.Route_ID,
                SpaceObject_ID = (cb_spaceObject.SelectedItem as SpaceObject).SpaceObject_Id,
            };

            foreach(Employee employee in lb_currentCrew.Items)
            {
                Crew_Employee newCrewEmployee = new Crew_Employee()
                {
                    Crew_ID = newCrew.Crew_ID,
                    Employee_ID = employee.Employee_ID
                };

                DBConnection.Connection.Crew_Employee.Add(newCrewEmployee);
            }
            DBConnection.Connection.Crew.Add(newCrew);
            DBConnection.Connection.Route.Add(newRoute);
            DBConnection.Connection.Flight.Add(newFlight);
            DBConnection.Connection.Balance.FirstOrDefault().TotalCash += decimal.Parse(tb_PotentialIncome.Text);
            DBConnection.Connection.SaveChanges();

            MessageBox.Show("Success");

            ClearFields();
        }

        private void cb_spaceObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cb_spaceObject.SelectedIndex == -1)
            {
                return;
            }
            tb_PotentialIncome.Text = (Convert.ToDecimal(tb_PotentialIncome.Text) + previousSpaceObjCost).ToString();

            previousSpaceObjCost = (cb_spaceObject.SelectedItem as SpaceObject).Cost;

            tb_PotentialIncome.Text = (Convert.ToDecimal(tb_PotentialIncome.Text) - previousSpaceObjCost).ToString();


        }

        private void ClearFields()
        {
            cb_advertisment.SelectedIndex = -1;
            cb_cosmodrome.SelectedIndex = -1;
            cb_employees.SelectedIndex = -1;
            cb_planet.SelectedIndex = -1;
            cb_spaceObject.SelectedIndex = -1;
            tb_PotentialIncome.Text = "0";
            RefreshDataBase();
            lb_currentCrew.ItemsSource = employees;
            lb_currentAdvertisment.ItemsSource = advertisments;
            Refresh();
        }
    }
}
