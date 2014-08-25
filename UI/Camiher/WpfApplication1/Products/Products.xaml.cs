using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Camiher.Libs.Server.DAL.CamiherLocalDAL;
using Camiher.UI.AdministrationCenter.Models;
using Camiher.UI.AdministrationCenter.Providers;

namespace Camiher.UI.AdministrationCenter.Products
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        ObservableProduct lp;
        ObservableProveedor lpr;
        private  Model1Container _dataDC ;
        public Products()
        {
            InitializeComponent();
            _dataDC =  ModelSingleton.getDataDC;
            lpr = new ObservableProveedor(_dataDC);
            lp = new ObservableProduct(_dataDC);
            this.DataContext = lp;
            ProductsSetListView.ItemsSource = lp;
        }

        private void ProductsSetListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void proveedorSetListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            String file = ProductsSetListView.SelectedItem.ToString();
            ProductsSet p = (ProductsSet)ProductsSetListView.SelectedItem;
            //Provider providerdetails = new Provider(p);
            //providerdetails._new = false;
            //providerdetails.ShowDialog();
            //_dataDC.SaveChanges();
        }

        private void MenuItem_MouseDown(object sender, RoutedEventArgs e)
        {
            //provmenu.PlacementTarget = this;
            //provmenu.IsOpen = true;

            ProductsSet p = new ProductsSet();
            p.Enbusca = false.ToString();
            p.Enventa = true.ToString();
            Machine productdetails = new Machine(p);
            productdetails._new = true;
            
            productdetails.ShowDialog();
            
            if (productdetails._new)
            {
                lp.Add(p);
                _dataDC.ProductsSet.AddObject(p);
                _dataDC.SaveChanges();
            }
            _dataDC.Dispose();
        }

    }

    public class ObservableProductSearch : System.Collections.ObjectModel.ObservableCollection<ProductsSet>
    {
        public ObservableProductSearch(Model1Container dataDc)
        {
            //Open class view to find out what Properties the wizard
            //had created in the DataClasses1DataContext class, otherwise
            //I wouldn't have known about Peoples
            foreach (ProductsSet thisPerson in dataDc.ProductsSet.Where(S =>  S.Enbusca == "True" ))
            {
                this.Add(thisPerson);
            }
        }
    }
    public class ObservableProduct : System.Collections.ObjectModel.ObservableCollection<ProductsSet>
    {
        public ObservableProduct(Model1Container dataDc)
        {
            //Open class view to find out what Properties the wizard
            //had created in the DataClasses1DataContext class, otherwise
            //I wouldn't have known about Peoples
            foreach (ProductsSet thisPerson in dataDc.ProductsSet.Where(s =>s.Enventa == "True" ))
            {
                this.Add(thisPerson);
            }
        }
    }
    public class ObservableProductSold : System.Collections.ObjectModel.ObservableCollection<ProductsSet>
    {
        public ObservableProductSold(Model1Container dataDc)
        {
            //Open class view to find out what Properties the wizard
            //had created in the DataClasses1DataContext class, otherwise
            //I wouldn't have known about Peoples
            foreach (ProductsSet thisPerson in dataDc.ProductsSet.Where(s => s.Enventa == "False" && s.Enbusca == "False" && s.Proveedor_ID != "Borrado"))
            {
                this.Add(thisPerson);
            }
        }
    }
      public class ObservableClient : System.Collections.ObjectModel.ObservableCollection<ClientSet>
    {
          public ObservableClient(Model1Container dataDc)
        {
            //Open class view to find out what Properties the wizard
            //had created in the DataClasses1DataContext class, otherwise
            //I wouldn't have known about Peoples
            foreach (ClientSet thisPerson in dataDc.ClientSet)
            {
                this.Add(thisPerson);
            }
        }
    }
      public class ObservableProductImage : System.Collections.ObjectModel.ObservableCollection<ProductImageSet>
      {
          public ObservableProductImage(Model1Container dataDc, String ProductID)
          {
              //Open class view to find out what Properties the wizard
              //had created in the DataClasses1DataContext class, otherwise
              //I wouldn't have known about Peoples
              foreach (ProductImageSet thisPerson in dataDc.ProductImageSet.Where(S => S.ProducID == ProductID))
              {
                  this.Add(thisPerson);
              }
          }
      }
      public class ObservableSale : System.Collections.ObjectModel.ObservableCollection<SaleSet>
      {
          public ObservableSale(Model1Container dataDc)
          {
              //Open class view to find out what Properties the wizard
              //had created in the DataClasses1DataContext class, otherwise
              //I wouldn't have known about Peoples
              foreach (SaleSet thisPerson in dataDc.SaleSet)
              {
                  this.Add(thisPerson);
              }
          }
      }
}
