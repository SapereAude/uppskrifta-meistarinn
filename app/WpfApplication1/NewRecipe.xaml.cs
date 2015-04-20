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
    /// Interaction logic for NewRecipe.xaml
    /// </summary>
    public partial class NewRecipe : MetroWindow
    {
        public NewRecipe()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            FoodProjectDataSetTableAdapters.RecipeTableAdapter rta
                = new FoodProjectDataSetTableAdapters.RecipeTableAdapter();

            if (String.IsNullOrWhiteSpace(txtName.Text) == false)
            {
                int rid = (int)rta.InsertRecipe(txtName.Text);

                App.Current.Properties["rid"] = rid;

                EditRecipe win = new EditRecipe();
                win.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show("Vinsamlegast veljið nafn.");
            }

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

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //txtName.Focus();//Omitted for the use of watermark property
        }
    }
}
