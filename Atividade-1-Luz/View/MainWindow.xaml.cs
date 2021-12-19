using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Atividade_1_Luz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            DataContext = new MainWindowVM();
            InitializeComponent();

            MainWindowVM.Data = new DataGrid();
            MainWindowVM.Data = DataGrid;
           
            
            if (MainWindowVM.ProductList != null)
            {
                //data.Items.Add( new {id= item.Id, name=item.Name, category=item.Category, description=item.Description, price= "R$" + item.Price});
                MainWindowVM.Data.ItemsSource = MainWindowVM.ProductList;
            }
        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Product prod = (Product)MainWindowVM.Data.SelectedItem;
            if(prod == null)
            {
                return;
            }
            try
            {
                MainWindowVM.IdPassToUpdate = prod.Id;
            }
            catch (Exception)
            {
                Console.WriteLine("Prod is null");
                throw;
            }
                
            
        }
    }
}
