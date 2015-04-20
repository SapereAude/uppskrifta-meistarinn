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
    /// Interaction logic for PrintPage.xaml
    /// </summary>
    public partial class PrintPage : MetroWindow
    {
        //public int SelectedRecipe; //Nota frekar App.Current.Properties

        int selectedRecipe = (int)App.Current.Properties["RecipeID"];

        public PrintPage()
        {
            InitializeComponent();
        }

        //public PrintPage(int _selectedRecipe)
        //{
        //    SelectedRecipe = _selectedRecipe;
        //}

        private void PrintWindow_Loaded(object sender, RoutedEventArgs e)
        {


            WpfApplication1.FoodProjectDataSet foodProjectDataSet = ((WpfApplication1.FoodProjectDataSet)(this.FindResource("foodProjectDataSet")));
            foodProjectDataSet.EnforceConstraints = false;

            // Load data into the table Recipe. You can modify this code as needed.
            WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter foodProjectDataSetRecipeTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter();
            foodProjectDataSetRecipeTableAdapter.FillByRid(foodProjectDataSet.Recipe, selectedRecipe);
            System.Windows.Data.CollectionViewSource recipeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("recipeViewSource")));
            recipeViewSource.View.MoveCurrentToFirst();


            // Load data into the table MainRecipeDetails. You can modify this code as needed.
            WpfApplication1.FoodProjectDataSetTableAdapters.MainRecipeDetailsTableAdapter foodProjectDataSetMainRecipeDetailsTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.MainRecipeDetailsTableAdapter();
            foodProjectDataSetMainRecipeDetailsTableAdapter.FillByRid(foodProjectDataSet.MainRecipeDetails, selectedRecipe);
            System.Windows.Data.CollectionViewSource mainRecipeDetailsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("mainRecipeDetailsViewSource")));
            mainRecipeDetailsViewSource.View.MoveCurrentToFirst();

            mainRecipeDetailsDataGrid.SelectedIndex = -1;
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            //printDlg.PrintVisual(this, "Window Printing.");
            printDlg.PrintVisual(PrintPanel, "Uppskrift");
        }
    }
}