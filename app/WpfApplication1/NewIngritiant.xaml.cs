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
    /// Interaction logic for NewIngritiant.xaml
    /// </summary>
    public partial class NewIngritiant : MetroWindow
    {
        int CategoryIndex = 0;

        public NewIngritiant()
        {
            InitializeComponent();
        }

        public NewIngritiant(int _categoryIndex)
        {
            InitializeComponent();
            CategoryIndex = _categoryIndex;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

            WpfApplication1.FoodProjectDataSet foodProjectDataSet = ((WpfApplication1.FoodProjectDataSet)(this.FindResource("foodProjectDataSet")));
            // Load data into the table Category. You can modify this code as needed.
            WpfApplication1.FoodProjectDataSetTableAdapters.CategoryTableAdapter foodProjectDataSetCategoryTableAdapter = new WpfApplication1.FoodProjectDataSetTableAdapters.CategoryTableAdapter();
            foodProjectDataSetCategoryTableAdapter.Fill(foodProjectDataSet.Category);
            System.Windows.Data.CollectionViewSource categoryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("categoryViewSource")));
            categoryViewSource.View.MoveCurrentToFirst();

            nameComboBox.SelectedIndex = CategoryIndex;
            //txtName.Focus();//Omitted because of watermark inside textbox
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            FoodProjectDataSetTableAdapters.IngredientTableAdapter ing = new FoodProjectDataSetTableAdapters.IngredientTableAdapter();

            // Whitespace tekið af báðum endum ef þarf
            if (String.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Þú átt eftir að slá inn nafn á hráefninu.");
            }
            else
            {
                string alternatedTxtName = txtName.Text.Trim();
                ing.Insert(alternatedTxtName, (int)cidLabel.Content);
                string showMessage = "Hráefninu " + txtName.Text.Trim() + " var bætt við";
                MessageBox.Show(showMessage);
            this.Close();
        }
    }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnAdd_Click(sender, e);
            }
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void btnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

}
}
