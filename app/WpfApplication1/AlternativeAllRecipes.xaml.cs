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
    /// Interaction logic for AlternativeAllRecipes.xaml
    /// </summary>
    public partial class AlternativeAllRecipes : Window
    {
        public AlternativeAllRecipes()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            WpfApplication1.FoodProjectDataSet foodProjectDataSet = ((WpfApplication1.FoodProjectDataSet)(this.FindResource("foodProjectDataSet")));
            foodProjectDataSet.EnforceConstraints = false;
            // Load data into the table Recipe. You can modify this code as needed.
            WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter foodProjectDataSetRecipeTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter();
            foodProjectDataSetRecipeTableAdapter.Fill(foodProjectDataSet.Recipe);
            System.Windows.Data.CollectionViewSource recipeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("recipeViewSource")));
            recipeViewSource.View.MoveCurrentToFirst();


        }

        private void recipeNameGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }
    }
}
