using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Atividade_1_Luz
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        #region RelayCommands[...]
        public ICommand CommandCreateView { get; private set; }
        public ICommand CommandUpdateView { get; private set; }
        public ICommand CommandDelete { get; private set; }
        public ICommand CommandCloseUpdate { get; private set; }
        public ICommand CommandUpdateProduct { get; private set; }
        public ICommand CommandCloseCreateView { get; private set; }
        public ICommand CommandCreateProduct { get; private set; }
        #endregion
        public static ObservableCollection<Product> ProductList { get; set; }
        private CreateView create;
        private UpdateView Update;
        public static DataGrid Data { get; set; }
        public static int IdPassToUpdate {get; set;}
       public bool disableButtons { get; set; }

        //public Product productUpdate { get; set; } Nao consegui achar uma forma de vincular os dados da classe ao Binding exemplo {Binding productCreate.Name}
        #region prop productUpdate [...]
        public int IdUpdate { get; set; }
        public string NameUpdate { get; set; }
        public string CategoryUpdate { get; set; }
        public string DescriptionUpdate { get; set; }
        public double PriceUpdate { get; set; }
        #endregion
        //public Product productCreate { get; set; } Nao consegui achar uma forma de vincular os dados da classe ao Binding exemplo {Binding productCreate.Name}
        #region prop productCreate [...]
        public int IdCreate { get; set; }
        public string NameCreate { get; set; }
        public string CategoryCreate { get; set; }
        public string DescriptionCreate { get; set; }
        public double PriceCreate { get; set; }
        #endregion
        public MainWindowVM()
        {
            ProductList = new ObservableCollection<Product>();
            Disable();
            CommandCreateView = new RelayCommand((object obj) =>
            {
                ShowViewCreate();
            });
            CommandUpdateView = new RelayCommand((object obj) =>
            {
                ShowViewUpdate();
            });
            CommandDelete = new RelayCommand((object obj) =>
            {
                DeleteMethod();
            });
        }
       
        #region Updates Methods [...]
        private void ShowViewUpdate()
        {
            
            Update = new UpdateView {
                DataContext = this
            };

            foreach (Product item in ProductList)
            {
                if (item.Id == IdPassToUpdate)
                {
                   IdUpdate = ProductList.IndexOf(item);
                   Console.WriteLine(IdUpdate);
                   NameUpdate = item.Name;
                   CategoryUpdate = item.Category;
                   DescriptionUpdate = item.Description;
                   PriceUpdate = item.Price;
                   //productUpdate = new Product(Id, Name, Category,Description, Price);
                }
            }
            CommandCloseUpdate = new RelayCommand((object obj) =>
            {
                CloseUpdateView();
            });
            CommandUpdateProduct = new RelayCommand((object obj) =>
            {
                UpdateProduct();
            });
            Update.Show();
        }
        private void CloseUpdateView()
        {
            Update.Close();
            
        }
        private void UpdateProduct()
        {
            /* Console.WriteLine(productUpdate.Id);
            ProductList[productUpdate.Id].Name = productUpdate.Name;
            ProductList[productUpdate.Id].Category = productUpdate.Category;
            ProductList[productUpdate.Id].Description = productUpdate.Description;
            ProductList[productUpdate.Id].Price = productUpdate.Price;
            */
            Console.WriteLine(IdUpdate);
            ProductList[IdUpdate].Name = NameUpdate;
            ProductList[IdUpdate].Category = CategoryUpdate;
            ProductList[IdUpdate].Description = DescriptionUpdate;
            ProductList[IdUpdate].Price = PriceUpdate;
            Data.Items.Refresh();
            Disable();
            CloseUpdateView();
        }
        #endregion

        private void ShowViewCreate()
        {
            create = new CreateView
            {
                DataContext = this
            };
            CommandCloseCreateView = new RelayCommand((object obj) => {
                CloseCreateView();
            });
            CommandCreateProduct = new RelayCommand((object obj) => {
                CreateProduct();
            });
            NameCreate = null;
            CategoryCreate = null;
            DescriptionCreate = null;
            PriceCreate = 0;
            create.Show();
        }

      private void CloseCreateView()
        {
            create.Close();
        }

       private void CreateProduct()
        {
           
            Product creatingProduct;
            if (ProductList.Count >= 0)
            {
                // int id= MainWindowVM.ProductList.Last().Id;
                int id = ProductList.Count + 1;
                foreach (Product item in ProductList)
                {
                    while (item.Id == id)
                    {
                        id++;
                    }
                }
                
                //creatingProduct = new Product(id, productCreate.Name, productCreate.Category, productCreate.Description, productCreate.Price);
                //Notify("productCreate");
                creatingProduct = new Product(id, NameCreate, CategoryCreate, DescriptionCreate, PriceCreate);
            }
            else
            {
                //Notify("productCreate");
                //creatingProduct = new Product(1, productCreate.Name, productCreate.Category, productCreate.Description, productCreate.Price);
                creatingProduct = new Product(1, NameCreate, CategoryCreate, DescriptionCreate, PriceCreate);
            }
            ProductList.Add(creatingProduct);
            Disable();
            CloseCreateView();
        }

        private void DeleteMethod()
        { 
            foreach (Product item in ProductList.ToList())
            {
                if (item.Id == IdPassToUpdate)
                {
                   int Id = ProductList.IndexOf(item);
                    Console.WriteLine("IdPassToUpdate"+IdPassToUpdate + Id);
                    ProductList.Remove(item);
                    Data.UnselectAllCells();
                    Data.Items.Refresh();
                    Disable();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Notify(string prop) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop)); 
        }

        public void Disable()
        { 
            if(ProductList.Count > 0)
            {
              
                Console.WriteLine("ok");
                disableButtons=true;
                
            }
            else
            {
                
                Console.WriteLine("NAOok");
                disableButtons = false;
                
            }
            Notify("disableButtons");

        }
        
       
    }
}
