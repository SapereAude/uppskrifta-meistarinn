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
    /// Interaction logic for ViewSelectedRecipe.xaml
    /// </summary>
    public partial class ViewSelectedRecipe : MetroWindow
    {
        public bool isDouble = false;
        public bool isDeleted = false;

        public ViewSelectedRecipe()
        {
            InitializeComponent();
        }

        public ViewSelectedRecipe(int recipeID)
        {
            InitializeComponent();
            App.Current.Properties["RecipeID"] = recipeID;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWindow();
            App.Current.Properties["isDeleted"] = isDeleted;
        }

        private void UpdateWindow()
        {
            int selectedRecipe = (int)App.Current.Properties["RecipeID"];


            WpfApplication1.FoodProjectDataSet foodProjectDataSet = ((WpfApplication1.FoodProjectDataSet)(this.FindResource("foodProjectDataSet")));
            foodProjectDataSet.EnforceConstraints = false; //Tek af constraints


            // MainRecipeDetails
            WpfApplication1.FoodProjectDataSetTableAdapters.MainRecipeDetailsTableAdapter foodProjectDataSetMainRecipeDetailsTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.MainRecipeDetailsTableAdapter();            
            foodProjectDataSetMainRecipeDetailsTableAdapter.FillByRid(foodProjectDataSet.MainRecipeDetails, selectedRecipe);
            System.Windows.Data.CollectionViewSource mainRecipeDetailsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("mainRecipeDetailsViewSource")));
            mainRecipeDetailsViewSource.View.MoveCurrentToFirst();

            // Recipe
            WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter foodProjectDataSetRecipeTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter();
            foodProjectDataSetRecipeTableAdapter.FillByRid(foodProjectDataSet.Recipe, selectedRecipe);
            System.Windows.Data.CollectionViewSource recipeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("recipeViewSource")));
            recipeViewSource.View.MoveCurrentToFirst();

            // CuisineInfo
            WpfApplication1.FoodProjectDataSetTableAdapters.CuisineInfoTableAdapter foodProjectDataSetCuisineInfoTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.CuisineInfoTableAdapter();
            foodProjectDataSetCuisineInfoTableAdapter.FillByCuisineInfo(foodProjectDataSet.CuisineInfo, selectedRecipe);
            System.Windows.Data.CollectionViewSource cuisineInfoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cuisineInfoViewSource")));
            cuisineInfoViewSource.View.MoveCurrentToFirst();
        }

        public async void closeWindowTimer()
        {
            await Task.Delay(300);
            App.Current.Windows[0].Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            int rid = (int)App.Current.Properties["RecipeID"];
            App.Current.Properties["rid"] = rid;

            EditRecipe win = new EditRecipe();
            win.ShowDialog();
            UpdateWindow();
            isDeleted = (bool)App.Current.Properties["isDeleted"];
            if (isDeleted == true)
            {
                ViewAllRecipes winvar = new ViewAllRecipes();
                closeWindowTimer();
                winvar.Show();
                //this.Close();
            }
        }

        private void btnDouble_Click(object sender, RoutedEventArgs e)
        {
            if (isDouble == false)
            {
                App.Current.Properties["isDouble"] = isDouble;
                isDouble = true;
                btnDouble.Content = "Einfalda";
            }
            else
            {
                App.Current.Properties["isDouble"] = isDouble;
                isDouble = false;
                btnDouble.Content = "Tvöfalda";
            }

            // Overkill?
            UpdateWindow();
        }

        private void btnAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            ViewAllRecipes var = new ViewAllRecipes();
            var.Show();
            this.Close();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void btnNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            //Switcher.Switch(new NewRecipe());
            NewRecipe newRec = new NewRecipe();
            newRec.ShowDialog();
        }
        private void btnNewCuisine_Click(object sender, RoutedEventArgs e)
        {
            //Switcher.Switch(new NewRecipe());
            NewCuisine newRec = new NewCuisine();
            newRec.ShowDialog();
        }
        private void btnNewIngredient_Click(object sender, RoutedEventArgs e)
        {
            //Switcher.Switch(new NewIngritiant());
            NewIngritiant newRec = new NewIngritiant();
            newRec.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            // In case að glugganum sé lokað með tvöfalda uppskrift uppi
            App.Current.Properties["isDouble"] = true;
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
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {

            PrintPage pp = new PrintPage();
            pp.ShowDialog();


        }
    }
}
