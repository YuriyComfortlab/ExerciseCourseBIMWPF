using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DataTemplate
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> products;
        public MainWindow()
        {
            InitializeComponent();
            products = new ObservableCollection<Product>();
            products.Add(new Product()
            {
                ProductName = "Apple",
                ProductPrice = 100,
                ImagePath = "Data/apple.jpg",
                ProductCategory = ProductCategories.Food
            });

            products.Add(new Product()
            {
                ProductName = "Orange",
                ProductPrice = 200,
                ImagePath = "Data/orange.jpg",
                ProductCategory = ProductCategories.Food
            });

            products.Add(new Product()
            {
                ProductName = "Dishwasher",
                ProductPrice = 10000,
                ImagePath = "Data/dishwasher.jpg",
                ProductCategory = ProductCategories.Appliances
            });

            products.Add(new Product()
            {
                ProductName = "Washer",
                ProductPrice = 50000,
                ImagePath = "Data/washer.jpg",
                ProductCategory = ProductCategories.Appliances
            });

            lstBox.ItemsSource = products;
        }
    }
}

