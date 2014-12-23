using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Camiher.Libs.Server.DAL.CamiherDAL;
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
        private CamiherContext _dataDC;
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
                _dataDC.Products.Add(p);
                _dataDC.SaveChanges();
            }
            _dataDC.Dispose();
        }
    }

    public class ObservableProductSearch : System.Collections.ObjectModel.ObservableCollection<ProductsSet>
    {
        public ObservableProductSearch(CamiherContext dataDc)
        {
            //Open class view to find out what Properties the wizard
            //had created in the DataClasses1DataContext class, otherwise
            //I wouldn't have known about Peoples
            foreach (ProductsSet thisPerson in dataDc.Products.Where(S =>  S.Enbusca == "True" ))
            {
                this.Add(thisPerson);
            }
        }
    }
    public class ObservableProduct : System.Collections.ObjectModel.ObservableCollection<ProductsSet>
    {
        public ObservableProduct(CamiherContext dataDc)
        {
            //Open class view to find out what Properties the wizard
            //had created in the DataClasses1DataContext class, otherwise
            //I wouldn't have known about Peoples

            foreach (ProductsSet thisPerson in dataDc.Products.ToList().Where(s =>s.Enventa == "True" ))
            {
                this.Add(thisPerson);
            }
        }
        public ObservableProduct(IEnumerable<ProductsSet> dataDc)
        {
            //Open class view to find out what Properties the wizard
            //had created in the DataClasses1DataContext class, otherwise
            //I wouldn't have known about Peoples

            foreach (ProductsSet thisPerson in dataDc)
            {
                this.Add(thisPerson);
            }
        }
    }
    public class ObservableProductSold : System.Collections.ObjectModel.ObservableCollection<ProductsSet>
    {
        public ObservableProductSold(IEnumerable<ProductsSet> Products)
        {
            foreach (ProductsSet thisProduct in Products)
            {
                this.Add(thisProduct);
            }
        }
    }
      public class ObservableClient : System.Collections.ObjectModel.ObservableCollection<ClientSet>
    {
          public ObservableClient(CamiherContext dataDc)
        {
            //Open class view to find out what Properties the wizard
            //had created in the DataClasses1DataContext class, otherwise
            //I wouldn't have known about Peoples
            foreach (ClientSet thisPerson in dataDc.Clients)
            {
                this.Add(thisPerson);
            }
        }
    }
      public class ObservableProductImage : System.Collections.ObjectModel.ObservableCollection<ProductImageSet>
      {
          public ObservableProductImage(IEnumerable<ProductImageSet> images)
          {
              //Open class view to find out what Properties the wizard
              //had created in the DataClasses1DataContext class, otherwise
              //I wouldn't have known about Peoples
              foreach (ProductImageSet image in images)
              {
                  this.Add(image);
              }
          }
      }
      public class ObservableSale : System.Collections.ObjectModel.ObservableCollection<SaleSet>
      {
          public ObservableSale(CamiherContext dataDc)
          {
              //Open class view to find out what Properties the wizard
              //had created in the DataClasses1DataContext class, otherwise
              //I wouldn't have known about Peoples
              foreach (SaleSet thisPerson in dataDc.Sales)
              {
                  this.Add(thisPerson);
              }
          }
      }
}
