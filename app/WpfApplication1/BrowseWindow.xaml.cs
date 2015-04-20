using MahApps.Metro.Controls;
using MahApps.Metro.Models;
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
    /// Interaction logic for BrowseWindow.xaml
    /// </summary>
    public partial class BrowseWindow : MetroWindow
    {
        public BrowseWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

            UpdateWindow();
        }

        private void UpdateWindow()
        {
            try
            {
                WpfApplication1.FoodProjectDataSet foodProjectDataSet = ((WpfApplication1.FoodProjectDataSet)(this.FindResource("foodProjectDataSet")));

                foodProjectDataSet.EnforceConstraints = false;
                // Load data into the table Recipe. You can modify this code as needed.
                WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter foodProjectDataSetRecipeTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter();
                foodProjectDataSetRecipeTableAdapter.Fill(foodProjectDataSet.Recipe);
                System.Windows.Data.CollectionViewSource recipeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("recipeViewSource")));
                recipeViewSource.View.MoveCurrentToFirst();


                // Load data into the table Cuisine. You can modify this code as needed.
                WpfApplication1.FoodProjectDataSetTableAdapters.CuisineTableAdapter foodProjectDataSetCuisineTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.CuisineTableAdapter();
                foodProjectDataSetCuisineTableAdapter.Fill(foodProjectDataSet.Cuisine);
                System.Windows.Data.CollectionViewSource cuisineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cuisineViewSource")));
                cuisineViewSource.View.MoveCurrentToFirst();

                // Load data into the table Category. You can modify this code as needed.
                WpfApplication1.FoodProjectDataSetTableAdapters.CategoryTableAdapter foodProjectDataSetCategoryTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.CategoryTableAdapter();
                foodProjectDataSetCategoryTableAdapter.Fill(foodProjectDataSet.Category);
                System.Windows.Data.CollectionViewSource categoryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("categoryViewSource")));
                categoryViewSource.View.MoveCurrentToFirst();

                // Load data into the table Ingredient. You can modify this code as needed.
                WpfApplication1.FoodProjectDataSetTableAdapters.IngredientTableAdapter foodProjectDataSetIngredientTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.IngredientTableAdapter();
                foodProjectDataSetIngredientTableAdapter.Fill(foodProjectDataSet.Ingredient);
                System.Windows.Data.CollectionViewSource categoryIngredientViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("categoryIngredientViewSource")));
                categoryIngredientViewSource.View.MoveCurrentToFirst();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Villa í Update");
            }
        }

        private void DeleteCuisine_Click(object sender, RoutedEventArgs e)
        {
            FoodProjectDataSetTableAdapters.CuisineTableAdapter cta = new FoodProjectDataSetTableAdapters.CuisineTableAdapter();
            DataRowView dv = (DataRowView)nameListBox.SelectedItem;

            if (dv != null)
            {
                string cuisineName = (string)dv["name"];

                MessageBoxResult res = MessageBox.Show("Ertu viss um að þú viljir eyða flokknum " + cuisineName + "?", "Eyða Flokk", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);

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
                        MessageBox.Show("Ekki er hægt að eyða flokkum \nsem þegar eru á uppskriftum.", "Villa!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
        }

        private void DeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            FoodProjectDataSetTableAdapters.IngredientTableAdapter ita = new FoodProjectDataSetTableAdapters.IngredientTableAdapter();
            DataRowView dv = (DataRowView)ingredientListBox.SelectedItem;

            
            //MessageBox.Show("cid = " + cid.ToString() + ",iid = " + iid.ToString() + ",name = " + name);

            if (dv != null)
            {
                string ingredientName = (string)dv["name"];

                MessageBoxResult res = MessageBox.Show("Ertu viss um að þú viljir eyða " + ingredientName, "Eyða Hráefni", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);

                if (res == MessageBoxResult.Yes)
                {
                    try
                    {
                        dv = (DataRowView)nameComboBox.SelectedItem;
                        int cid = (int)dv["cid"];

                        dv = (DataRowView)ingredientListBox.SelectedItem;
                        int iid = (int)dv["iid"];

                        string name = (string)dv["name"];
                        ita.Delete(iid, name, cid);
                        UpdateWindow();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Ekki er hægt að eyða hráefnum \nsem þegar eru á uppskriftum.", "Villa!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
        }

        public void NewRecipe_Click(object sender, RoutedEventArgs e)
        {
            NewRecipe newRec = new NewRecipe();
            newRec.ShowDialog();
            this.Close();
        }

        private void NewCuisine_Click(object sender, RoutedEventArgs e)
        {
            NewCuisine newCui = new NewCuisine();
            newCui.Show();
            this.Close();
        }

        private void NewIngredient_Click(object sender, RoutedEventArgs e)
        {
            int categoryIndex = nameComboBox.SelectedIndex;

            NewIngritiant newIng = new NewIngritiant(categoryIndex);
            newIng.Show();
            this.Close();
        }

        public async void closeWindowTimer()
        {
            await Task.Delay(300);
            App.Current.Windows[0].Close();
        }

        private void recipeListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataRowView dv = (DataRowView)recipeListView.SelectedItem;
                int recipeID = (int)dv["rid"];

                ViewSelectedRecipe viewRec = new ViewSelectedRecipe(recipeID);

                this.Close();
                closeWindowTimer();
                viewRec.ShowDialog();
                //Owner.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Villa í recipeTab\n" + ex.ToString());
            }
        }

        
    }
}
