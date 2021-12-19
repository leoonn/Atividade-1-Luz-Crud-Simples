using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Atividade_1_Luz
{
    class CreateViewVM
    {
        //For Bindings
        public ICommand Command { get; private set; }
        public ICommand CommandCreate { get; private set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public CreateViewVM()
        {
           
            Command = new RelayCommand((object obj) => {
                ButtonBack();
            });
            CommandCreate = new RelayCommand((object obj) => {
                CreateButton();
            });
        }

        void ButtonBack()
        {
            MainWindowVM.create.Close();
        }

        void CreateButton()
        {
            Product creatingProduct;
            if (MainWindowVM.ProductList.Count >= 0 )
            {
                // int id= MainWindowVM.ProductList.Last().Id;
                int id = MainWindowVM.ProductList.Count + 1;
                foreach (Product item in MainWindowVM.ProductList)
                {
                    while(item.Id == id)
                    {
                        id++;
                    }
                }
                creatingProduct = new Product(id, Name, Category, Description, Price);    
            }
            else
            {
                 creatingProduct = new Product(1, Name, Category, Description, Price);
            }
            MainWindowVM.ProductList.Add(creatingProduct); 
            MainWindowVM.create.Close();

        }
    }
}
