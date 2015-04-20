using MahApps.Metro.Controls;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for DeleteRecipe.xaml
    /// </summary>
    public partial class DeleteRecipe : MetroWindow
    {
        public DeleteRecipe()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtConfirm.Text == "Eyða" || txtConfirm.Text == "eyða")
            {
                FoodProjectDataSetTableAdapters.RecipeTableAdapter rta = new FoodProjectDataSetTableAdapters.RecipeTableAdapter();
                FoodProjectDataSetTableAdapters.Recipe_CuisineTableAdapter rcta = new FoodProjectDataSetTableAdapters.Recipe_CuisineTableAdapter();
                FoodProjectDataSetTableAdapters.Recipe_IngredientTableAdapter rita = new FoodProjectDataSetTableAdapters.Recipe_IngredientTableAdapter();

                int rid = (int)App.Current.Properties["rid"];


                rcta.ClearByRecipe(rid);
                rita.ClearByRecipe(rid);
                rta.DeleteRecipe(rid);

                bool isDeleted = true;
                App.Current.Properties["isDeleted"] = isDeleted;

                this.Close();
            }
            else
            {
                txtConfirm.Text = "";
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtConfirm.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
