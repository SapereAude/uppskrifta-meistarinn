using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for ViewAllCuisines.xaml
    /// </summary>
    public partial class ViewAllCuisines : MetroWindow
    {
        public ViewAllCuisines()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            UpdateWindow();
        }

        private void UpdateWindow()
        {
            WpfApplication1.FoodProjectDataSet foodProjectDataSet = ((WpfApplication1.FoodProjectDataSet)(this.FindResource("foodProjectDataSet")));
            // Load data into the table Cuisine. You can modify this code as needed.
            WpfApplication1.FoodProjectDataSetTableAdapters.CuisineTableAdapter foodProjectDataSetCuisineTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.CuisineTableAdapter();
            foodProjectDataSetCuisineTableAdapter.FillByAZ(foodProjectDataSet.Cuisine);
            System.Windows.Data.CollectionViewSource cuisineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cuisineViewSource")));
            cuisineViewSource.View.MoveCurrentToFirst();
        }

        private void btnNewCuisine_Click(object sender, RoutedEventArgs e)
        {
            NewCuisine win = new NewCuisine();
            win.ShowDialog();

            UpdateWindow();
        }

        private void DeleteCuisine_Click(object sender, RoutedEventArgs e)
        {
            FoodProjectDataSetTableAdapters.CuisineTableAdapter cta = new FoodProjectDataSetTableAdapters.CuisineTableAdapter();
            DataRowView dv = (DataRowView)nameListBox.SelectedItem;

            if (dv != null)
            {
                MessageBoxResult res = MessageBox.Show("Ertu viss um að þú viljir eyða taggi?", "Eyða Taggi", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);

                if (res == MessageBoxResult.Yes)
                {
                    try
                    {
                        int cuid = (int)dv["cuid"];
                        string name = (string)dv["name"];

                        cta.Delete(cuid, name);
                        UpdateWindow();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ekki er hægt að eyða töggum \nsem þegar eru á uppskriftum.", "Villa!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
        }
    }
}
