using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Atividade_1_Luz
{
    public class MainWindowVM
    {
        public ICommand Command { get; private set; }
        public ICommand CommandUpdate { get; private set; }
        public ICommand CommandDelete { get; private set; }
        public static ObservableCollection<Product> ProductList { get; set; }
        public static CreateView create;
        public static UpdateView Update;
        public static DataGrid Data { get; set; }
        public static int IdPassToUpdate {get; set;}
        public MainWindowVM()
        {
            ProductList = new ObservableCollection<Product>();
            //Product teste = new Product(1, "Iphone", "SmartPhone", "teste", 1000);
            //ProductList.Add(teste);           
            Command = new RelayCommand((object obj) =>
            {
                ShowViewCreate();
            });
            CommandUpdate = new RelayCommand((object obj) =>
            {
                ShowViewUpdate();
            });
            CommandDelete = new RelayCommand((object obj) =>
            {
                Delete();
            });
        }
        private void ShowViewCreate()
        {
            create = new CreateView();
            create.Show();
        }
       private void ShowViewUpdate()
        {
            Update = new UpdateView();
            Update.Show();
        }
       private void Delete()
        { 
            foreach (Product item in ProductList.ToList())
            {
                if (item.Id == IdPassToUpdate)
                {
                   int Id = ProductList.IndexOf(item);
                    Console.WriteLine("IdPassToUpdate"+IdPassToUpdate + Id);
                    ProductList.RemoveAt(Id);
                    Data.UnselectAllCells();
                    Data.Items.Refresh();
                }
            }
        }
    }
}
