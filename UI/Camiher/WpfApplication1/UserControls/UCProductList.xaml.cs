﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Camiher.Libs.Common;
using Camiher.Libs.DataProviders;
using Camiher.Libs.DataProviders.Interfaces;
using Camiher.Libs.Server.DAL.CamiherDAL;
using Camiher.UI.AdministrationCenter.Models;
using Camiher.UI.AdministrationCenter.Products;
using RavSoft.GoogleTranslator;

namespace Camiher.UI.AdministrationCenter.UserControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UCProductList : UserControl
    {
        private IBusinessOperationProvider operationProvider;
        ObservableProduct lp;
        private  CamiherContext _dataDC;
        private string marca="";
        private Boolean _IsfilterMode = true;
       

        public double LWidth
        {
            get { return ProductsSetListView.Width; }
            set { 
            ProductsSetListView.Width = value;
            }
        }
        public double LHeight
        {
            get { return ProductsSetListView.Height; }
            set
            {
                ProductsSetListView.Height = value;
            }
        }
        public Boolean IsfilterMode
        {
            get { return _IsfilterMode; }
            set { _IsfilterMode = value;
            if (value == true)
            {
                productmenu.IsEnabled = true;
            }
            else {
                productmenu.IsEnabled = false;
                productmenu.Visibility = Visibility.Hidden;
            }
            }
        }
        public string Marca
        {
            get { return marca; }
            set {
                if (value == null)
                {
                    marca = "";
                }
                else
                {
                    marca = value;
                } filter();
            }
        }
        private string modelo="";

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; filter(); }
        }
        private string año="0";

        public string Año
        {
            get { return año; }
            set { año = value; filter(); }
        }
        private string producto="";

        public string Producto
        {
            get { return producto; }
            set { producto = value; filter(); }
        }
        private string preciomaximo="";

        public string Preciomaximo
        {
            get { return preciomaximo; }
            set { preciomaximo = value;
            filter();
            }
        }
        private string preciominimo = "0";

        public string Preciominimo
        {
            get { return preciominimo; }
            set { preciominimo = value;
            if (value == "") preciominimo = "0";
            filter();
            }
        }
        private string provedorID= "";

        public string ProvedorID
        {
            get { return provedorID; }
            set { provedorID = value; filter(); }
        }



        public UCProductList()
        {
             

            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                InitializeComponent();
                if (Properties.Settings.Default.OnlineMode)
                {
                    operationProvider = DataProvidersFactory.GetBusinessOperationProvider();
                    lp = new ObservableProduct(operationProvider.GetProductsToSale());
                }
                else
                {
                    _dataDC = ModelSingleton.getDataDC;                   
                    lp = new ObservableProduct(_dataDC);
                }

                this.DataContext = lp;
                ProductsSetListView.Width = this.Width;

                ProductsSetListView.ItemsSource = lp;  

            }
        }
    



        private void ProductsSetListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void proveedorSetListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Editar();
        }

        private void Editar()
        {
            try
            {
                if (_IsfilterMode)
                {
                    if (ProductsSetListView.Items.Count > 0 && ProductsSetListView.SelectedItem != null)
                    {
                        String file = ProductsSetListView.SelectedItem.ToString();
                        ProductsSet p = (ProductsSet)ProductsSetListView.SelectedItem;
                        string predescription = p.Descripcion;
                        Machine productdetails = new Machine(p);
                        productdetails._new = false;
                        
                        productdetails.ShowDialog();
                       
                        if (!productdetails.Cancel)
                        {
                            if (Properties.Settings.Default.OnlineMode)
                            {
                                ProductTranslations[] translations = null;
                                if (predescription != p.Descripcion)
                                {
                                    translations = GetProductTranslation(p).ToArray();
                                }

                                if(!operationProvider.UpdateProduct(p,translations).IsCorrect)
                                {
                                    MessageBox.Show("Error updating product in server");
                                }
                            }
                            else
                            {
                                _dataDC.SaveChanges(); 
                            }
                            
                            //Activate in future
                            //checkNotifications(p);
                        }
                        
                    }
                }
                
            }
            catch {

                
            }
        }

        static public void checkNotifications(ProductsSet p)
        {
            CamiherContext _dataDC = ModelSingleton.getDataDC;
            Boolean newinserted = false;                   
            foreach (ProductsSet Product in _dataDC.Products.Where(S=>S.Enbusca == "True"
                                                                        && p.Producto.ToLower().Contains(S.Producto.ToLower())
                                                                        && (p.Marca.ToLower().Contains(S.Marca) || S.Marca == "")
                                                                        && (p.Modelo.ToLower().Contains(S.Modelo.ToLower()) || S.Modelo == "")
                                       
                                                                        && p.Precio <= S.Precio
                                                                        && p.Año >= S.Año
                                                                        )
                                                                       )
            {
                if (_dataDC.Sales.Where(S => S.Client_ID == Product.Proveedor_ID && S.Product_ID == p.Id).Count() == 0)
                {
                    if (_dataDC.Notifications.Where(S => S.ProductID == p.Id && S.Search_ID == Product.Id).Count() == 0)
                    {
                        NotificationSet newNotification = new NotificationSet();
                        Ramdom r = new Ramdom();
                        newNotification.ID = r.RandomString(32);

                        newNotification.ProductID = p.Id;
                        newNotification.Search_ID = Product.Id;
                        _dataDC.Notifications.Add(newNotification);
                        newinserted = true;
                    }
                }
            
            }
            if (newinserted) _dataDC.SaveChanges();
        }

        private void MenuItem_MouseDown(object sender, RoutedEventArgs e)
        {
            //provmenu.PlacementTarget = this;
            //provmenu.IsOpen = true;

            ProductsSet p = new ProductsSet();
            p.Enbusca = false.ToString();
            p.Enventa = true.ToString();
            if (ProvedorID != null && ProvedorID != "")
            {
                p.Proveedor_ID = ProvedorID;
            }
            Machine productdetails = new Machine(p);
            productdetails._new = true;
           
            productdetails.ShowDialog();
           
            if (productdetails._new && !productdetails.Cancel)
            {
                var translations = GetProductTranslation(p);

                if (Properties.Settings.Default.OnlineMode)
                {
                    if (!operationProvider.AddProduct(p,translations.ToArray()).IsCorrect)
                    {
                        MessageBox.Show("Error adding product in server");
                    }
                }
                else
                {
                    _dataDC.Products.Add(p);
                    _dataDC.SaveChanges();
                }
                lp.Add(p);
                filter();
                //Activate in future
                //checkNotifications(p);
            }
           

        }

        private List<ProductTranslations> GetProductTranslation(ProductsSet p)
        {
            String[] Languages = new[] {"English", "German"};
            string originalLanguage = "Spanish";
            Translator t = new Translator();
            t.SourceLanguage = originalLanguage;
            t.SourceText = p.Descripcion;
            var translations = new List<ProductTranslations>();
            foreach (string language in Languages)
            {
                t.TargetLanguage = language;
                t.Translate();
                var translation = new ProductTranslations();
                translation.Description = t.Translation;
                translation.Id = new Ramdom().RandomString(8);
                translation.Language = LanguageMapping(language);
                translation.Product = p.Id;
                translations.Add(translation);
            }
            return translations;
        }

        public string LanguageMapping(string language)
        {
            switch (language)
            {
                case "Spanish":
                    return "es";
                case "English":
                    return "en";
                case "German":
                    return "de";
                default:
                    return "es";
            }
        }


        private void filter(){
            decimal Maxprice;
            string fProducto = producto.ToLower();
            string fMarca = marca.ToLower();
            string fModelo = modelo.ToLower();
            if (preciomaximo != "") { 
            Maxprice =  Convert.ToDecimal(preciomaximo) ;              
            }
            else { Maxprice = Decimal.MaxValue; }
            
            if (producto == "Todos") fProducto = "";
            if (modelo == "Todos" || modelo == null) fModelo = "";
            if (marca == "Todos" || marca == null) fMarca = "";

       ProductsSetListView.ItemsSource = lp.Where(S => Convert.ToDecimal(S.Precio) >= Convert.ToDecimal(preciominimo) &&
       Convert.ToDecimal(S.Precio) <= Maxprice
       && Convert.ToDecimal(S.Año) >= Convert.ToDecimal(Año)
       && S.Modelo.ToLower().Contains(fModelo)
       && S.Marca.ToLower().Contains(fMarca)
       && S.Producto.ToLower().Contains(fProducto)
       && S.Proveedor_ID.Contains(provedorID)
       );
        }

  

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            //redo in future
            //if (ProductsSetListView.SelectedItem!= null)
            //{
            //string productID = (ProductsSetListView.SelectedItem as ProductsSet).Id;
            ////If there are clients who requested the product ask the user if he is sure
            //if (_dataDC.Sales.Where(S => S.Product_ID == productID && S.FinalPrice == 0).Count() > 0)
            //{
            //    if (MessageBox.Show("Algunos clientes han solicitado este producto, si borra el producto se borraran las solicitudes de los clientes para este producto¿Desea Continuar?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            //    {
            //        //do no stuff
            //    }
            //    else
            //    {
            //        DeleteProduct(productID);
            //    }
            //}
            //else
            //{
            //    DeleteProduct(productID);
            //}
            //}
            if (ProductsSetListView.SelectedItem != null)
            {
                string productID = (ProductsSetListView.SelectedItem as ProductsSet).Id;
                DeleteProduct(productID);
            }
        }

        public void refresh()
        {
            lp = new ObservableProduct(_dataDC);
            this.DataContext = lp;


            ProductsSetListView.ItemsSource = lp;
        }

        private void DeleteProduct(string productID)
        {

            //Change the state to Delete
            ProductsSet product = lp.First(S => S.Id == productID);
            product.Enbusca = "false";
            product.Enventa = "false";
            product.Proveedor_ID = "Borrado";
            //foreach (SaleSet item in _dataDC.Sales.Where(S => S.Product_ID == productID && S.FinalPrice==0)) 
            //{
            //    _dataDC.Sales.Remove(item);
            //}
            //foreach (NotificationSet item in _dataDC.Notifications.Where(S => S.ProductID == productID))
            //{
            //    _dataDC.Notifications.Remove(item);
            //}
            if (Properties.Settings.Default.OnlineMode)
            {
                if (!operationProvider.DeleteProduct(product.Id).IsCorrect)
                {
                    MessageBox.Show("Error deleting product in server");
                }
                lp.Remove(product);
                
            }
            else
            {
                _dataDC.SaveChanges();
                lp = new ObservableProduct(_dataDC);
            }
            
            ProductsSetListView.ItemsSource = lp;
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            Editar();
        }

    }
    
}
