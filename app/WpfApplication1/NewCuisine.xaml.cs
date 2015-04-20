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
using MahApps.Metro.Controls;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for NewCuisine.xaml
    /// </summary>
    public partial class NewCuisine : MetroWindow
    {
        public NewCuisine()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            FoodProjectDataSetTableAdapters.CuisineTableAdapter cta = new FoodProjectDataSetTableAdapters.CuisineTableAdapter();

            if (String.IsNullOrWhiteSpace(txtName.Text) == false)
            {
                cta.Insert(txtName.Text.Trim());
                string showMessage = "Flokknum " + txtName.Text.Trim() +  " var bætt við";
                MessageBox.Show(showMessage);
                this.Close();
            }
            else
            {
                MessageBox.Show("Vinsamlegast sláið inn heiti.");
            }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //txtName.Focus();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnCreate_Click(sender, e);
            }
        }

        private void MetroWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

    }
}
