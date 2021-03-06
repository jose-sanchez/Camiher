﻿using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Camiher.Libs.Common;
using Camiher.Libs.DataProviders;
using Camiher.UI.AdministrationCenter.Clients;
using Camiher.UI.AdministrationCenter.Models;
using Camiher.UI.AdministrationCenter.Providers;
using Validation = Camiher.Libs.Common.Validation;
using Camiher.Libs.Server.DAL.CamiherDAL;

namespace Camiher.UI.AdministrationCenter.Products
{
    /// <summary>
    /// Interaction logic for Machine.xaml
    /// </summary>
    public partial class Machine : Window
    {
        Boolean _cancel = true;
        Boolean _viewOnly = false;

        public Boolean ViewOnly
        {
            get { return _viewOnly; }
            set { _viewOnly = value;
            if (value) 
            {
                GridProduct.IsEnabled = false;
            
            }
            }
        }
            
        public Boolean Cancel
        {
            get { return _cancel; }
            set { _cancel = value; }
        }
        Boolean isnew;
        CamiherContext _dataDC;
        ProductsSet _product;
        public Boolean _new
        {
            get { return isnew; }
            set { isnew = value;
            if (this.isnew)
            {
                Ramdom r = new Ramdom();
                _product.Id = r.RandomString(32);
                _product.Descripcion = "";
                _product.PrivateDescription = "";
            }
            }
        }
        

        public Machine(ProductsSet product)
        {
            InitializeComponent();
            
            _product = product;
            _dataDC = ModelSingleton.getDataDC;
            string productPath = Properties.Settings.Default.ImagePath.ToString() + "\\" + _product.Id;
            if (!Directory.Exists(productPath))
            {
                System.IO.Directory.CreateDirectory(productPath);
            }
            ProvidersSet p;
            if (product.Proveedor_ID != null && product.Proveedor_ID !="")
            {
                p = (ProvidersSet)_dataDC.Providers.Where(S => S.Id == product.Proveedor_ID).ToList()[0];
            }
            else {
            p = new ProvidersSet();
            }

            if (product.Descripcion != "" && product.Descripcion != null) { tbdescription.Text = product.Descripcion; }

            var Products = DataProvidersFactory.GetBusinessOperationProvider().GetProductsToSale();
            cbProducto.ItemsSource = Products.Select(S => S.Producto).Distinct().ToList();
            cbModelo.ItemsSource = Products.Select(S => S.Modelo).Distinct().ToList();
            cbMarca.ItemsSource = Products.Select(S => S.Marca).Distinct().ToList();
            this.DataContext = product;
            tbProvider.ItemsSource = Products.Select(S => S).ToList();
            tbProvider.SelectedItem = p ;

            //ClientList.ItemsSource = from c in _dataDC.Clients //Restaurar
            //                         where _dataDC.Sales.Where(S => S.Product_ID == _product.Id).Select(S => S.Client_ID).Contains(c.Id)
            //                         select c;

            for (int añoindex = 1900; añoindex < 2025; añoindex++)
            {

                cbyear.Items.Add(añoindex);
            }
        }



        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if(validateFields()){
            ProvidersSet p;
            _product.Marca = tbMarca.Text;
            _product.Modelo = tbModelo.Text;
            _product.Producto = tbProducto.Text;
            if (tbPotency.Text == null || tbPotency.Text == "") { _product.Potencia = 0; }
            if (tbPeso.Text == null || tbPeso.Text =="") { _product.Peso = 0; }
            if (tbProvider.SelectedIndex >= 0)
            {

                p = (ProvidersSet)tbProvider.SelectedItem;
                _product.Proveedor_ID = p.Id;
            }
            else _product.Proveedor_ID = "";
            _cancel = false;
            this.Close();
            }
        }

        private Boolean validateFields() 
        {
            if (tbProducto.Text=="")
            {
                MessageBox.Show("Rellene el campo Producto");
                return false;
            }
            if (tbMarca.Text == "")
            {
                MessageBox.Show("Rellene el campo Marca");
                return false;
            }
            if (tbModelo.Text == "")
            {
                MessageBox.Show("Rellene el campo Modelo");
                return false;
            }
            if (cbyear.SelectedItem== null)
            {
                MessageBox.Show("Rellene el campo Año");
                return false;
            }
            if (cbprecio.Text == "")
            {
                MessageBox.Show("Rellene el campo Precio");
                return false;
            }
            if (tbCantidad.Text == "")
            {
                MessageBox.Show("Rellene el campo Cantidad");
                return false;
            }
            if (tbHours.Text == "" && tbHours.Text == null)
            {
                _product.Hours = 0;
            }
            if (tbkilometer.Text == "" && tbkilometer.Text == null)
            {
                _product.Kilometer = 0;
            }
            if (tbdescription.Text == "" && tbdescription.Text == null) {
                _product.Descripcion = "";
            }
            return true;
        }

        private void cbMarca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbMarca.Text = cbMarca.SelectedItem.ToString();
        }

        private void cbModelo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbModelo.Text = cbModelo.SelectedItem.ToString();

        }

        private void cbProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbProducto.Text = cbProducto.SelectedItem.ToString();
        }

        private void ImageView_Click(object sender, RoutedEventArgs e)
        {
            string productPath = Properties.Settings.Default.ImagePath.ToString() + "\\" +_product.Id ;

            PicViewer.MainWindow ImageGallery = new PicViewer.MainWindow();
            ImageGallery.FolderPath = productPath;
           
            ImageGallery.ShowDialog();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DragDropImage AddImageWindow = new DragDropImage(_product.Id);
            
            AddImageWindow.ShowDialog();
            


        }
        #region event treatment
        private void ClientList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ClientList.Items.Count > 0 && ClientList.SelectedItem!= null)
            {
                String file = ClientList.SelectedItem.ToString();
                ClientSet p = (ClientSet)ClientList.SelectedItem;
                Client clientdetails = new Client(p);
                clientdetails._new = false;
            
                clientdetails.ShowDialog();
               
                if (!clientdetails.Cancel) _dataDC.SaveChanges();
            }
        }
        #endregion

        #region validation
        private void OnPreviewTextBox(object sender, TextCompositionEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb != null)
            {
                char c = Convert.ToChar(e.Text);

                if (Char.IsNumber(c))
                {
                    if (tb.Text.Count() > 0 && tb.Text[0] == '0')
                    {
                        tb.Text = String.Empty;
                        e.Handled = false;
                    }
                    else { e.Handled = false; }
                }
                else
                    e.Handled = true;
            }

            base.OnPreviewTextInput(e);
        }

        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                if (Validation.IsEmailAllowed(tb.Text.Trim()) == false)
                {
                    e.Handled = true;
                    MessageBox.Show("El correo no es un correo valido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    tb.Focus();
                }
            }
        }
        #endregion

        private void btViewProvider_Click(object sender, RoutedEventArgs e)
        {
            if( tbProvider.SelectedItem!=null){
            ProvidersSet p = tbProvider.SelectedItem as ProvidersSet;
            Provider providerdetails = new Provider(p);
            providerdetails._new = false;
           
            providerdetails.ShowDialog();
            
            if (!providerdetails.Cancel) _dataDC.SaveChanges();
            }
        }



    }
}
