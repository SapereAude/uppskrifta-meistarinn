using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Random r = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter foodProjectDataSetRecipeTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter();
            
            int max = (int)foodProjectDataSetRecipeTableAdapter.GetHighestRid();
            Random r = new Random(DateTime.Now.Day);
            int rid = r.Next(1, max);

            do
            {
                UpdateWindow(foodProjectDataSetRecipeTableAdapter, rid);
                rid++;
            } while (RecipeName.Text == null || RecipeName.Text == "");

            //MessageBox.Show(mainRecipeDetailsViewSource.Source.ToString());
        }

        private void UpdateWindow(WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter foodProjectDataSetRecipeTableAdapter, int rid)
        {
            WpfApplication1.FoodProjectDataSet foodProjectDataSet = ((WpfApplication1.FoodProjectDataSet)(this.FindResource("foodProjectDataSet")));
            foodProjectDataSet.EnforceConstraints = false;

            // MainRecipeDetails
            WpfApplication1.FoodProjectDataSetTableAdapters.MainRecipeDetailsTableAdapter foodProjectDataSetMainRecipeDetailsTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.MainRecipeDetailsTableAdapter();
            foodProjectDataSetMainRecipeDetailsTableAdapter.FillByRid(foodProjectDataSet.MainRecipeDetails, rid);
            System.Windows.Data.CollectionViewSource mainRecipeDetailsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("mainRecipeDetailsViewSource")));
            mainRecipeDetailsViewSource.View.MoveCurrentToFirst();

            // CuisineInfo
            WpfApplication1.FoodProjectDataSetTableAdapters.CuisineInfoTableAdapter foodProjectDataSetCuisineInfoTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.CuisineInfoTableAdapter();
            foodProjectDataSetCuisineInfoTableAdapter.FillByCuisineInfo(foodProjectDataSet.CuisineInfo, rid);
            System.Windows.Data.CollectionViewSource cuisineInfoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cuisineInfoViewSource")));
            cuisineInfoViewSource.View.MoveCurrentToFirst();

            // Recipe            
            foodProjectDataSetRecipeTableAdapter.FillByRid(foodProjectDataSet.Recipe, rid);
            System.Windows.Data.CollectionViewSource recipeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("recipeViewSource")));
            recipeViewSource.View.MoveCurrentToFirst();
        }

        private void btnAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            ViewAllRecipes var = new ViewAllRecipes();
            var.Show();
            this.Close();
        }

        private void btnNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            NewRecipe newRec = new NewRecipe();
            newRec.ShowDialog();
        }
        private void btnNewCuisine_Click(object sender, RoutedEventArgs e)
        {
            NewCuisine newCus = new NewCuisine();
            newCus.ShowDialog();
        }
        private void btnNewIngredient_Click(object sender, RoutedEventArgs e)
        {
            NewIngritiant newIng = new NewIngritiant();
            newIng.ShowDialog();
        }

        private void btnBrowseRecipe_Click(object sender, RoutedEventArgs e)
        {
            BrowseWindow brWin = new BrowseWindow();
            brWin.BrowseTabControl.SelectedIndex = 0;
            //brWin.Owner = this;
            brWin.ShowDialog();
        }

        private void btnBrowseCuisine_Click(object sender, RoutedEventArgs e)
        {
            BrowseWindow brWin = new BrowseWindow();

            brWin.BrowseTabControl.SelectedIndex = 1;
            brWin.ShowDialog();
        }

        private void btnBrowseIngredient_Click(object sender, RoutedEventArgs e)
        {
            BrowseWindow brWin = new BrowseWindow();
            brWin.BrowseTabControl.SelectedIndex = 2;
            brWin.ShowDialog();
        }

        
    }
}
