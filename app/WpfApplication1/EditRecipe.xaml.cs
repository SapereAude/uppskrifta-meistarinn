using MahApps.Metro.Controls;
using MahApps.Metro.Actions;
using MahApps.Metro.Behaviours;
using MahApps.Metro.Models;
using MahApps.Metro.Converters;
using MahApps.Metro.Native;
using MetroWPF.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for EditRecipe.xaml
    /// </summary>
    public partial class EditRecipe : MetroWindow
    {

        public bool isDeleted = false;
        public bool unsavedChanges;

        public EditRecipe()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int rid = (int)App.Current.Properties["rid"];

            WpfApplication1.FoodProjectDataSet foodProjectDataSet = ((WpfApplication1.FoodProjectDataSet)(this.FindResource("foodProjectDataSet")));
            foodProjectDataSet.EnforceConstraints = false; //Tek af constraints

            // Measure
            WpfApplication1.FoodProjectDataSetTableAdapters.MeasureTableAdapter foodProjectDataSetMeasureTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.MeasureTableAdapter();
            foodProjectDataSetMeasureTableAdapter.Fill(foodProjectDataSet.Measure);
            //System.Windows.Data.CollectionViewSource measureViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("measureViewSource")));
            //measureViewSource.View.MoveCurrentToFirst();

            // Ingredient
            WpfApplication1.FoodProjectDataSetTableAdapters.IngredientTableAdapter foodProjectDataSetIngredientTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.IngredientTableAdapter();
            foodProjectDataSetIngredientTableAdapter.Fill(foodProjectDataSet.Ingredient);
            //System.Windows.Data.CollectionViewSource ingredientViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("ingredientViewSource")));
            //ingredientViewSource.View.MoveCurrentToFirst();

            // Recipe           
            WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter foodProjectDataSetRecipeTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter();
            foodProjectDataSetRecipeTableAdapter.FillByRid(foodProjectDataSet.Recipe, rid);
            System.Windows.Data.CollectionViewSource recipeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("recipeViewSource")));
            recipeViewSource.View.MoveCurrentToFirst();

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

            // Cuisine
            WpfApplication1.FoodProjectDataSetTableAdapters.CuisineTableAdapter foodProjectDataSetCuisineTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.CuisineTableAdapter();
            foodProjectDataSetCuisineTableAdapter.Fill(foodProjectDataSet.Cuisine);
            //System.Windows.Data.CollectionViewSource cuisineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cuisineViewSource")));
            //cuisineViewSource.View.MoveCurrentToFirst();

            string currentImage = foodProjectDataSetRecipeTableAdapter.GetImageUrl(rid);
            App.Current.Properties["image_url"] = currentImage;
            App.Current.Properties["isDeleted"] = isDeleted;

            unsavedChanges = false;
        }

        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WpfApplication1.FoodProjectDataSetTableAdapters.IngredientTableAdapter ita = new WpfApplication1.FoodProjectDataSetTableAdapters.IngredientTableAdapter();
                WpfApplication1.FoodProjectDataSetTableAdapters.Recipe_IngredientTableAdapter rita = new FoodProjectDataSetTableAdapters.Recipe_IngredientTableAdapter();
                WpfApplication1.FoodProjectDataSetTableAdapters.MeasureTableAdapter mta = new FoodProjectDataSetTableAdapters.MeasureTableAdapter();




                // Skilgreini DataRowView til þess að geta náð í measureID úr comboboxi
                DataRowView dv = (DataRowView)cbMeasure.SelectedItem;

                if (dv != null)
                {
                    // Næ í iid, rid og mid fyrir Recipe_Ingredient Insert Query
                    int iid = (int)ita.GetIidByName(txtIngredient.Text);
                    int rid = (int)App.Current.Properties["rid"];
                    int mid = (int)dv["mid"];

                    rita.Insert(rid, iid, double.Parse(txtQuantity.Text), mid);

                    UpdateDataGrid();

                    try
                    {
                        string root = AppDomain.CurrentDomain.BaseDirectory;

                        // Bý til myndina
                        BitmapImage imgC = new BitmapImage();
                        imgC.BeginInit();
                        imgC.UriSource = new Uri(root + @"\check20w.png");
                        imgC.DecodePixelWidth = 20;
                        imgC.EndInit();

                        // Set myndina inn í rétt image í xamlinu og bæti texta í label
                        imgCheck.Source = imgC;
                        lblCheck.Content = "Hráefni hefur verið bætt við uppskrift.";

                        // Kalla á timer sem núllstillir image og label
                        TimerTest();
                    }
                    catch (FileNotFoundException)
                    {
                    }

                }
                else
                {
                    MessageBox.Show("Vinsamlegast veljið Mælieiningu.");
                }

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Vinsamlegast veljið hráefni.");
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Vinsamlegast veljið hráefni.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Vinamlegast sláið inn magn.");
            }
            catch (Exception) // Á að vera SQLException en það virkar ekki.
            {
                MessageBox.Show("Villa kom upp. Ekki tókst að skrá hráefni");
            }

        }

        private void UpdateDataGrid()
        {
            WpfApplication1.FoodProjectDataSet foodProjectDataSet = ((WpfApplication1.FoodProjectDataSet)(this.FindResource("foodProjectDataSet")));
            int rid = (int)App.Current.Properties["rid"];

            WpfApplication1.FoodProjectDataSetTableAdapters.MainRecipeDetailsTableAdapter foodProjectDataSetMainRecipeDetailsTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.MainRecipeDetailsTableAdapter();
            foodProjectDataSetMainRecipeDetailsTableAdapter.FillByRid(foodProjectDataSet.MainRecipeDetails, rid);
        }

        // Hreinsar User Feedback image og label eftir tvær sekúndur
        public async void TimerTest()
        {
            await Task.Delay(2000);

            imgCheck.Source = null;
            lblCheck.Content = "";

            imgCheck2.Source = null;
            lblCheck2.Content = "";
        }


        // Kemur í veg fyrir að hægt sé að skrifa bókstafi í txtQuantity
        private void txtQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            // Finn hvort að OS language noti punkta eða kommur í aukastafi. Virðist eiga að nota CultureInfo.CurrentCulture frekar en CultureInfo.CurrentUICulture
            if (CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToString() == ".")
            {
                Regex regex = new Regex("[^0-9.]+"); // Regex sem leyfir tölur og punkta
                return !regex.IsMatch(text);
            }
            else
            {
                Regex regex = new Regex("[^0-9,]+"); // Regex sem leyfir tölur og kommur
                return !regex.IsMatch(text);
            }
        }

        private void RemoveIngredient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WpfApplication1.FoodProjectDataSetTableAdapters.IngredientTableAdapter ita = new WpfApplication1.FoodProjectDataSetTableAdapters.IngredientTableAdapter();
                WpfApplication1.FoodProjectDataSetTableAdapters.Recipe_IngredientTableAdapter rita = new FoodProjectDataSetTableAdapters.Recipe_IngredientTableAdapter();

                DataRowView dv = (DataRowView)mainRecipeDetailsDataGrid.SelectedItem;

                if (dv != null)
                {
                    int rid = (int)dv["rid"];
                    int iid = (int)ita.GetIidByName(dv["Ingredients"].ToString());

                    rita.RemoveIngredient(rid, iid);

                    UpdateDataGrid();
                    MessageBox.Show("Hráefni fjarlægt úr uppskrift!");
                }
            }
            catch (Exception)
            {
            }


        }

        private void btnNewIngredient_Click(object sender, RoutedEventArgs e)
        {
            NewIngritiant win = new NewIngritiant();
            win.ShowDialog();

            WpfApplication1.FoodProjectDataSet foodProjectDataSet = ((WpfApplication1.FoodProjectDataSet)(this.FindResource("foodProjectDataSet")));
            WpfApplication1.FoodProjectDataSetTableAdapters.IngredientTableAdapter foodProjectDataSetIngredientTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.IngredientTableAdapter();
            foodProjectDataSetIngredientTableAdapter.Fill(foodProjectDataSet.Ingredient);


            //async this.ShowMessageAsync("This is the title", "Some message");//Virkar ekki.
            
        }

        private void btnBrowseImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Image Files (*.bmp, *.jpg, *.jpeg, *.gif, *.png, *.tiff, *.tga, *.svg)|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tiff;*.tga;*.svg";

                Nullable<bool> imageSelection = dlg.ShowDialog();

                if (imageSelection == true)
                {

                    //BitmapImage selectedImage = new BitmapImage();
                    //selectedImage.BeginInit();
                    //selectedImage.UriSource = new Uri(dlg.FileName);
                    //selectedImage.DecodePixelWidth = 210;
                    //selectedImage.DecodePixelHeight = 160;
                    //selectedImage.EndInit();

                    //image_urlImage.Source = selectedImage;
                    image_urlImage.Source = new BitmapImage(new Uri(dlg.FileName));

                    try
                    {
                        string expected = @"\.(jpg|jpeg|gif|png|bmp|tiff|tga|svg)";

                        Match m = Regex.Match(dlg.FileName, expected);

                        string extension = m.Groups[0].ToString();
                        string imageFolder = AppDomain.CurrentDomain.BaseDirectory + @"Images\";
                        string imageName = Guid.NewGuid() + extension;
                        string copiedImage = imageFolder + imageName;

                        File.Copy(dlg.FileName, copiedImage);

                        App.Current.Properties["image_url"] = imageName;
                        unsavedChanges = true;

                    }
                    catch (IOException ioe)
                    {
                        MessageBox.Show(ioe.Message);
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ekki tókst að bæta við mynd.");
            }

        }

        private void btnUpdateRecipe_Click(object sender, RoutedEventArgs e)
        {
            WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter rta = new FoodProjectDataSetTableAdapters.RecipeTableAdapter();

            int rid = (int)App.Current.Properties["rid"];
            string image_url = (string)App.Current.Properties["image_url"];

            int rating = int.Parse(lblRating.Content.ToString());

            rta.UpdateRecipe(txtName.Text, descriptionTextBox.Text, image_url, rating, rid);

            unsavedChanges = false;
            this.Close();
        }

        private void btnAddTag_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                // Skilgreini DataRowView til þess að geta náð í cuisineID úr comboboxi
                DataRowView dv = (DataRowView)cbCuisine.SelectedItem;

                WpfApplication1.FoodProjectDataSetTableAdapters.Recipe_CuisineTableAdapter rcta = new FoodProjectDataSetTableAdapters.Recipe_CuisineTableAdapter();

                int rid = (int)App.Current.Properties["rid"];
                int cuid = (int)dv["cuid"];


                rcta.Insert(rid, cuid);

                UpdateListBox(rid);

                try
                {
                    string root = AppDomain.CurrentDomain.BaseDirectory;

                    // Bý til myndina
                    BitmapImage imgC = new BitmapImage();
                    imgC.BeginInit();
                    imgC.UriSource = new Uri(root + @"\check20w.png");
                    imgC.DecodePixelWidth = 20;
                    imgC.EndInit();

                    // Set myndina inn í rétt image í xamlinu og bæti texta í label
                    imgCheck2.Source = imgC;
                    lblCheck2.Content = "Uppskrift tögguð.";

                    // Kalla á timer sem núllstillir image og label
                    TimerTest();
                }
                catch (FileNotFoundException)
                {
                }
            }
            catch (Exception) // Ekki hægt að bæta sama Cuisine taggi tvisvar við sömu uppskrift.
            {
            }
        }

        private void UpdateListBox(int rid)
        {
            WpfApplication1.FoodProjectDataSet foodProjectDataSet = ((WpfApplication1.FoodProjectDataSet)(this.FindResource("foodProjectDataSet")));
            WpfApplication1.FoodProjectDataSetTableAdapters.CuisineInfoTableAdapter foodProjectDataSetCuisineInfoTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.CuisineInfoTableAdapter();
            foodProjectDataSetCuisineInfoTableAdapter.FillByCuisineInfo(foodProjectDataSet.CuisineInfo, rid);
        }

        private void RemoveTag_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WpfApplication1.FoodProjectDataSetTableAdapters.Recipe_CuisineTableAdapter rcta = new FoodProjectDataSetTableAdapters.Recipe_CuisineTableAdapter();

                DataRowView dv = (DataRowView)lbCuisine.SelectedItem;


                if (dv != null)
                {
                    int rid = (int)App.Current.Properties["rid"];
                    int cuid = (int)dv["cuid"];

                    rcta.Delete(rid, cuid);

                    UpdateListBox(rid);
                    MessageBox.Show("Tagg fjarlægt af uppskrift!");
                }
            }
            catch (Exception)
            {
            }

        }

        private void btnNewCuisine_Click(object sender, RoutedEventArgs e)
        {
            NewCuisine win = new NewCuisine();
            win.ShowDialog();

            WpfApplication1.FoodProjectDataSet foodProjectDataSet = ((WpfApplication1.FoodProjectDataSet)(this.FindResource("foodProjectDataSet")));
            WpfApplication1.FoodProjectDataSetTableAdapters.CuisineTableAdapter foodProjectDataSetCuisineTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.CuisineTableAdapter();
            foodProjectDataSetCuisineTableAdapter.Fill(foodProjectDataSet.Cuisine);
        }
        private void DeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            DeleteRecipe win = new DeleteRecipe();
            win.ShowDialog();
            isDeleted = (bool)App.Current.Properties["isDeleted"];

            if (isDeleted == true)
            {
                unsavedChanges = false;
                this.Close();
            }
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (unsavedChanges)
            {
                MessageBoxResult res = MessageBox.Show("Uppskrift hefur verið breytt. Viltu vista breytingar?", "Vista breytingar", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning, MessageBoxResult.Yes);
                if (res == MessageBoxResult.Yes)
                {
                    WpfApplication1.FoodProjectDataSetTableAdapters.RecipeTableAdapter rta = new FoodProjectDataSetTableAdapters.RecipeTableAdapter();

                    int rid = (int)App.Current.Properties["rid"];
                    string image_url = (string)App.Current.Properties["image_url"];

                    int rating = int.Parse(lblRating.Content.ToString());

                    rta.UpdateRecipe(txtName.Text, descriptionTextBox.Text, image_url, rating, rid);
                }
                if (res == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }
            }

        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            unsavedChanges = true;
        }

        private void sliRating_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            unsavedChanges = true;
        }

        private void descriptionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            unsavedChanges = true;
        }
    }

}
