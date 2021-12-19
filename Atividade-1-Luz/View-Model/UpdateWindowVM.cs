using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Atividade_1_Luz
{
    public class UpdateWindowVM
    {
        public ICommand Command { get; private set; }
        public ICommand CommandUpdate { get; private set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public UpdateWindowVM()
        {
            foreach (Product item in MainWindowVM.ProductList)
            {
                if (item.Id == MainWindowVM.IdPassToUpdate)
                {
                    Id = MainWindowVM.ProductList.IndexOf(item);
                    Console.WriteLine(Id);
                    Name = item.Name;
                    Category = item.Category;
                    Description = item.Description;
                    Price = item.Price;
                }
            }

            Command = new RelayCommand((object obj) =>
            {
                BackMainView();
            });
            CommandUpdate = new RelayCommand((object obj) =>
            {
                UpdateProduct();
            });
        }

        void BackMainView()
        {
            MainWindowVM.Update.Close();
        }
        void UpdateProduct()
        {
            Console.WriteLine(Id);
            MainWindowVM.ProductList[Id].Name = Name;
            MainWindowVM.ProductList[Id].Category = Category;
            MainWindowVM.ProductList[Id].Description = Description;
            MainWindowVM.ProductList[Id].Price = Price;
            MainWindowVM.Data.Items.Refresh();
            MainWindowVM.Update.Close();
        }
    }
}
