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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for ViewAllRecipes.xaml
    /// </summary>

    public partial class ViewAllRecipes : MetroWindow
    {
        bool NameOrRating = true;

        public ViewAllRecipes()
        {
            InitializeComponent();
        }

        private void ViewAllRecp_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWindow();
            
        }

        private void UpdateWindow()
        {

           

            WpfApplication1.FoodProjectDataSet foodProjectDataSet = ((WpfApplication1.FoodProjectDataSet)(this.FindResource("foodProjectDataSet")));
            foodProjectDataSet.EnforceConstraints = false;
            // Load data into the table Recipe. You can modify this code as needed.
            WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter foodProjectDataSetRecipeTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter();
            foodProjectDataSetRecipeTableAdapter.FillByname(foodProjectDataSet.Recipe);
            System.Windows.Data.CollectionViewSource recipeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("recipeViewSource")));
            recipeViewSource.View.MoveCurrentToFirst();

            // Load data into the table Cuisine. You can modify this code as needed.
            WpfApplication1.FoodProjectDataSetTableAdapters.CuisineTableAdapter foodProjectDataSetCuisineTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.CuisineTableAdapter();
            foodProjectDataSetCuisineTableAdapter.Fill(foodProjectDataSet.Cuisine);
            System.Windows.Data.CollectionViewSource cuisineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cuisineViewSource")));
            cuisineViewSource.View.MoveCurrentToFirst();

            cuisineComboBox.SelectedValue = null;
        }

        /*--Gerir kleift að skruna lárétt --*/
        private void RecipeScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollviewer = sender as ScrollViewer;
            if (e.Delta > 0)
            {
                scrollviewer.LineLeft();
            }
            else
            {
                scrollviewer.LineRight();
            }
            e.Handled = true;
        }

        private void RecipeContents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // 'rid' tekið frá uppskrift sem er valinn með músinni.
                DataRowView dv = (DataRowView)RecipeView.SelectedValue;


                //'rid' pakkað inn sem ["RecipeID"]
                App.Current.Properties["RecipeID"] = dv["rid"];
                // Valin uppskrift sýnd í öðrum glugga með öllum upplýsingum (name, igredients, description, rating, image)
                // Temp ShowDialog fix, UpdateWindow virkar ekki ef aðeins er notað Show
                ViewSelectedRecipe vsr = new ViewSelectedRecipe();
                vsr.Show();
                this.Close();
                
                // Meiningin var sú að þetta myndi breyta nafni og/eða mynd á uppskriftum sem hefur verið breytt frá því þessi gluggi var fyrst opnaður. Gekki ekki -- LAGA!
                //UpdateWindow();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Þarna");
            }

        }

        private void btnAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtNameSEARCH.Clear();
                UpdateWindow();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eitthvað fór úrskeðis.");
            }
        }

        private void cuisineComboBox_DropDownClosed(object sender, EventArgs e)
        {
            txtNameSEARCH.Clear();
            

            try
            {
                if (cuisineComboBox.SelectedIndex == -1)
                {
                    UpdateWindow();
                }
                else
                {
                    var x = cuisineComboBox.SelectedIndex + 1;
                    //MessageBox.Show(x.ToString());
                    WpfApplication1.FoodProjectDataSet foodProjectDataSet = ((WpfApplication1.FoodProjectDataSet)(this.FindResource("foodProjectDataSet")));
                    foodProjectDataSet.EnforceConstraints = false;
                    // Load data into the table Recipe. You can modify this code as needed.
                    WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter foodProjectDataSetRecipeTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter();
                    foodProjectDataSetRecipeTableAdapter.FillByBIGTEST(foodProjectDataSet.Recipe, x);

                    System.Windows.Data.CollectionViewSource recipeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("recipeViewSource")));
                    recipeViewSource.View.MoveCurrentToFirst();

                    //cuisineComboBox.SelectedIndex = -1;
                }
                
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void btnSortAZ_Click(object sender, RoutedEventArgs e)
        {
            txtNameSEARCH.Clear();

            UpdateLayout();
            WpfApplication1.FoodProjectDataSet foodProjectDataSet = ((WpfApplication1.FoodProjectDataSet)(this.FindResource("foodProjectDataSet")));
            foodProjectDataSet.EnforceConstraints = false;

            NameOrRating = true;

            if (cuisineComboBox.SelectedValue != null)
            {
                int x = cuisineComboBox.SelectedIndex + 1;

                
                // Load data into the table Recipe. You can modify this code as needed.
                WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter foodProjectDataSetRecipeTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter();
                foodProjectDataSetRecipeTableAdapter.FillByCusinAndName(foodProjectDataSet.Recipe, x);
                System.Windows.Data.CollectionViewSource recipeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("recipeViewSource")));
                recipeViewSource.View.MoveCurrentToFirst();
            }
            else
            {
                
                // Load data into the table Recipe. You can modify this code as needed.
                WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter foodProjectDataSetRecipeTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter();
                foodProjectDataSetRecipeTableAdapter.FillByname(foodProjectDataSet.Recipe);
                System.Windows.Data.CollectionViewSource recipeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("recipeViewSource")));
                recipeViewSource.View.MoveCurrentToFirst();
            }
        }

        private void btnSortByRating_Click(object sender, RoutedEventArgs e)
        {
            txtNameSEARCH.Clear();

            WpfApplication1.FoodProjectDataSet foodProjectDataSet = ((WpfApplication1.FoodProjectDataSet)(this.FindResource("foodProjectDataSet")));
            foodProjectDataSet.EnforceConstraints = false;

            NameOrRating = false;

            if (cuisineComboBox.SelectedValue != null)
            {
                int x = cuisineComboBox.SelectedIndex + 1;

                WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter foodProjectDataSetRecipeTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter();
                foodProjectDataSetRecipeTableAdapter.FillByCusinAndRating(foodProjectDataSet.Recipe, x);
                System.Windows.Data.CollectionViewSource recipeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("recipeViewSource")));
                recipeViewSource.View.MoveCurrentToFirst();
            }

            else
            {
                WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter foodProjectDataSetRecipeTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter();
                foodProjectDataSetRecipeTableAdapter.FillByRating(foodProjectDataSet.Recipe);
                System.Windows.Data.CollectionViewSource recipeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("recipeViewSource")));
                recipeViewSource.View.MoveCurrentToFirst();
            }
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            UpdateLayout();
            //MessageBox.Show(cuisineComboBox.SelectedIndex.ToString());
            if (cuisineComboBox != null)
            {

                if (NameOrRating == false)
                {
                    string search = '%' + txtNameSEARCH.Text + '%';
                    int x = cuisineComboBox.SelectedIndex + 1;

                    WpfApplication1.FoodProjectDataSet foodProjectDataSet = ((WpfApplication1.FoodProjectDataSet)(this.FindResource("foodProjectDataSet")));
                    foodProjectDataSet.EnforceConstraints = false;
                    // Load data into the table Recipe. You can modify this code as needed.
                    WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter foodProjectDataSetRecipeTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter();
                    foodProjectDataSetRecipeTableAdapter.SearchRating(foodProjectDataSet.Recipe, x, search);
                    System.Windows.Data.CollectionViewSource recipeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("recipeViewSource")));
                    recipeViewSource.View.MoveCurrentToFirst();
                }
                else
                {
                    string search = '%' + txtNameSEARCH.Text + '%';
                    int x = cuisineComboBox.SelectedIndex + 1;

                    WpfApplication1.FoodProjectDataSet foodProjectDataSet = ((WpfApplication1.FoodProjectDataSet)(this.FindResource("foodProjectDataSet")));
                    foodProjectDataSet.EnforceConstraints = false;
                    // Load data into the table Recipe. You can modify this code as needed.
                    WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter foodProjectDataSetRecipeTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter();
                    foodProjectDataSetRecipeTableAdapter.FillBySearchName(foodProjectDataSet.Recipe, x, search);
                    System.Windows.Data.CollectionViewSource recipeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("recipeViewSource")));
                    recipeViewSource.View.MoveCurrentToFirst();
                }

            }
            if (cuisineComboBox.SelectedItem == null)
            {


                if (NameOrRating == false)
                {
                    string search = '%' + txtNameSEARCH.Text + '%';

                    WpfApplication1.FoodProjectDataSet foodProjectDataSet = ((WpfApplication1.FoodProjectDataSet)(this.FindResource("foodProjectDataSet")));
                    foodProjectDataSet.EnforceConstraints = false;
                    // Load data into the table Recipe. You can modify this code as needed.
                    WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter foodProjectDataSetRecipeTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter();
                    foodProjectDataSetRecipeTableAdapter.FillByRatingSearch(foodProjectDataSet.Recipe, search);
                    System.Windows.Data.CollectionViewSource recipeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("recipeViewSource")));
                    recipeViewSource.View.MoveCurrentToFirst();
                }
                else
                {
                    string search = '%' + txtNameSEARCH.Text + '%';

                    WpfApplication1.FoodProjectDataSet foodProjectDataSet = ((WpfApplication1.FoodProjectDataSet)(this.FindResource("foodProjectDataSet")));
                    foodProjectDataSet.EnforceConstraints = false;
                    // Load data into the table Recipe. You can modify this code as needed.
                    WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter foodProjectDataSetRecipeTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter();
                    foodProjectDataSetRecipeTableAdapter.FillByNameSEARCH(foodProjectDataSet.Recipe, search);
                    System.Windows.Data.CollectionViewSource recipeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("recipeViewSource")));
                    recipeViewSource.View.MoveCurrentToFirst();

                }
            }
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
            UpdateWindow();
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
        private void btnBrowseRecipe_Click(object sender, RoutedEventArgs e)
        {
            BrowseWindow brWin = new BrowseWindow();
            brWin.BrowseTabControl.SelectedIndex = 0;
            //brWin.Owner = this;
            brWin.ShowDialog();
            UpdateWindow();
        }

        private void btnBrowseCuisine_Click(object sender, RoutedEventArgs e)
        {
            BrowseWindow brWin = new BrowseWindow();
            brWin.BrowseTabControl.SelectedIndex = 1;
            brWin.ShowDialog();
            UpdateWindow();
        }

        private void btnBrowseIngredient_Click(object sender, RoutedEventArgs e)
        {
            BrowseWindow brWin = new BrowseWindow();
            brWin.BrowseTabControl.SelectedIndex = 2;
            brWin.ShowDialog();
            UpdateWindow();
        }
    }
}
