using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Camiher.Libs.Common;
using Camiher.Libs.DataProviders;
using Camiher.Libs.Server.DAL.CamiherLocalDAL;
using Camiher.UI.AdministrationCenter.Helpers;
using Camiher.UI.AdministrationCenter.Models;
using Camiher.UI.AdministrationCenter.Products;
using Camiher.UI.AdministrationCenter.UserControls;
using Validation = Camiher.Libs.Common.Validation;

namespace Camiher.UI.AdministrationCenter.Clients
{
	/// <summary>
	/// Interaction logic for Client.xaml
	/// </summary>
    public partial class Client : Window
    {
        private Boolean _cancel = true;
        public Boolean Cancel
        {
            get { return _cancel; }
            set { _cancel = value; }
        }

        private Boolean isnew;
        Model1Container _dataDC;
        ClientSet _client;
        ObservableProductSearch lps;
        ObservableProduct lrequestedproduct;
        public Boolean _new
        {
            get { return isnew; }
            set
            {
                isnew = value;
                if (this.isnew)
                {
                    Ramdom r = new Ramdom();
                    _client.Id = r.RandomString(32);
                }
            }
        }
        public Client(ClientSet client)
        {
            this.InitializeComponent();
            _dataDC = ModelSingleton.getDataDC;
            lps = new ObservableProductSearch(_dataDC);
            lvProductSearched.ItemsSource = lps.Where(S => S.Enbusca == true.ToString() && S.Proveedor_ID == client.Id).ToList();
            _client = client;
            this.DataContext = client;

            UpdateRequestedProductList();
            Update_ListSoldProducts();
            // Insert code required on object creation below this point.
        }

        private void UpdateRequestedProductList()
        {
            lrequestedproduct = new ObservableProduct(_dataDC);
            var q1 = from c in lrequestedproduct
                     join o in _dataDC.SaleSet on c.Id equals o.Product_ID
                     where o.Client_ID == _client.Id
                     select new ItemRequestedProductList
                     {
                         ProductID = c.Id,
                         Name = c.Producto + " " + c.Marca + " " + c.Modelo,
                         ClientPrice = (int)o.PriceforClient,
                         LastEmailDate = (DateTime)o.LastEmailDate,
                         SaleID = o.Id
                     };
            //select new ProductsSet
            //{
            //    Id = c.Id,
            //    Producto = c.Producto,
            //    Marca = c.Marca,
            //    Modelo = c.Modelo,
            //    Año = c.Año,
            //    Potencia = c.Potencia,
            //    Peso = c.Peso,
            //    Descripcion = c.Descripcion,
            //    Precio = c.Precio,
            //    Cantidad = c.Cantidad,
            //    Enventa = c.Enventa,
            //    Enbusca = c.Enbusca,
            //    Proveedor_ID = c.Proveedor_ID
            //};
            lvProductRequested.ItemsSource = q1.ToList();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (validateFields())
            {
                _cancel = false;
                _client.Name = tbName.Text;
                foreach (ItemRequestedProductList item in lvProductRequested.Items)
                {
                    _dataDC.SaleSet.First(S => S.Id == item.SaleID).PriceforClient = item.ClientPrice;
                }

                this.Close();
            }
        }

        private void btAddSearch_Click(object sender, RoutedEventArgs e)
        {
            ProductsSet newProduct = new ProductsSet();
            newProduct.Proveedor_ID = _client.Id;
            newProduct.Enbusca = true.ToString();
            newProduct.Enventa = false.ToString();
            ProductSearched search = new ProductSearched(newProduct);
            search._new = true;
            
            search.ShowDialog();
          
            if (search._new && !search.Cancel)
            {
                lps.Add(newProduct);
                _dataDC.ProductsSet.AddObject(newProduct);
                _dataDC.SaveChanges();
                lvProductSearched.ItemsSource = lps.Where(S => S.Enbusca == true.ToString() && S.Proveedor_ID == _client.Id).ToList();
            }

        }
        private void lvProductRequested_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvProductRequested.Items.Count > 0 && lvProductRequested.SelectedItem != null)
            {
                ItemRequestedProductList selectedProductitem = (ItemRequestedProductList)lvProductRequested.SelectedItem;
                ProductsSet selectedProduct = lrequestedproduct.Where(S => S.Id == selectedProductitem.ProductID).ToList()[0];

                Machine productdetails = new Machine(selectedProduct);
                productdetails._new = false;
                
                productdetails.ShowDialog();
               
                if (!productdetails.Cancel)
                {
                    _dataDC.SaveChanges();
                    UCProductList.checkNotifications(selectedProduct);
                }

            }
        }

        private void lvProductSearched_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (lvProductSearched.Items.Count > 0 && lvProductSearched.SelectedItem != null)
            {
                ProductSearched search = new ProductSearched((ProductsSet)lvProductSearched.SelectedItem);
               
                search.ShowDialog();
               
                if (!search.Cancel)
                {
                    _dataDC.SaveChanges();
                }

            }
        }

        private void btAddProduct_Click(object sender, RoutedEventArgs e)
        {

            ListSelectProduct search = new ListSelectProduct(_client.Id);
            search._new = true;
           
            search.ShowDialog();
           
            if (search._new)
            {
                UpdateRequestedProductList();
            }
        }

        #region event treatment menu
        private void BorrarMouseDown(object sender, RoutedEventArgs e)
        {
            if (lvProductSearched.SelectedItem != null)
            {
                _dataDC.ProductsSet.DeleteObject((lvProductSearched.SelectedItem as ProductsSet));
                _dataDC.SaveChanges();
                lps = new ObservableProductSearch(_dataDC);
                lvProductSearched.ItemsSource = lps;
            }

        }
        private void BorrarPDMouseDown(object sender, RoutedEventArgs e)
        {
            DeleteProductRequest(_client.Id, (lvProductRequested.SelectedItem as ItemRequestedProductList).ProductID);
            UpdateRequestedProductList();
        }
        static void DeleteProductRequest(string ClientID, string ProductID)
        {
            Model1Container dataDC = ModelSingleton.getDataDC;
            dataDC.SaleSet.DeleteObject(dataDC.SaleSet.First(S => S.Client_ID == ClientID
                                    && S.Product_ID == ProductID));
            MessageBox.Show("La solicitud para este producto ha sido borrada");
            dataDC.SaveChanges();
        }
        #endregion
        #region validation
        private Boolean validateFields()
        {

            if (tbName.Text == "")
            {
                MessageBox.Show("Rellene el campo Nombre");
                return false;
            }
            if (tbSurname.Text == "")
            {
                MessageBox.Show("Rellene el campo Nombre");
                return false;
            }
            if (telefonoMTextBox.Text == "")
            {
                _client.PhoneMain = "";
            }
            if (telefonoFTextBox.Text == "")
            {
                _client.PhoneSecond = "";
            }
            if (tbEmail.Text == "")
            {
                _client.Email = "";
            }
            return true;

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
                        e.Handled = true;
                    }
                    else { e.Handled = false; }
                }
                else
                    e.Handled = true;
            }

            base.OnPreviewTextInput(e);
        }
        #endregion

        private void tabRequestedProduct_GotFocus(object sender, RoutedEventArgs e)
        {
            btBuyProduct.Visibility = Visibility.Visible;
        }

        private void tabRequestedProduct_LostFocus(object sender, RoutedEventArgs e)
        {
            btBuyProduct.Visibility = Visibility.Hidden;
        }

        private void btBuyProduct_Click(object sender, RoutedEventArgs e)
        {

            if (lvProductRequested.SelectedItem != null)
                ClientBuyProduct(_client.Id, (lvProductRequested.SelectedItem as ItemRequestedProductList).ProductID);
        }

        public static void ClientBuyProduct(string clientId, string productId)
        {          
            SaleSet currentsale = DataProvidersFactory.GetBusinessOperationProvider().GetCurrentSale(clientId, productId);
            BuyProduct newBuyProduct = new BuyProduct((SaleSet) currentsale);
            
            newBuyProduct.ShowDialog();
          
            if (!newBuyProduct.Cancel)
            {
                DataProvidersFactory.GetBusinessOperationProvider().ClientBuyProduct(clientId, productId, currentsale.Id);

            }
        }
        public void Update_ListSoldProducts()
        {

            ObservableProductSold soldProduct = new ObservableProductSold(_dataDC);
            ListSoldProducts.ItemsSource = (from c in soldProduct
                                            join sale in _dataDC.SaleSet.Where(S => S.Client_ID == _client.Id)
                                            on c.Id equals sale.Product_ID

                                            select new ItemSoldProductList
                                            {
                                                Name = c.Producto + " " + c.Marca + " " + c.Modelo,
                                                FinalPrice = sale.FinalPrice.ToString() + " Euros",
                                                ProductID = c.Id
                                            });


        }

        private void ListSoldProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ItemSoldProductList item = (ListSoldProducts.SelectedItem as ItemSoldProductList);
            ProductsSet soldProduct = new ObservableProductSold(_dataDC).First(S => S.Id == item.ProductID);
            Machine viewProductDetails = new Machine(soldProduct);
            viewProductDetails.ViewOnly = true;
            
            viewProductDetails.ShowDialog();
           
        }

        private void MenuSendEmail_Click(object sender, RoutedEventArgs e)
        {
            if (lvProductRequested.SelectedItem != null)
            {
                ItemRequestedProductList ItemProduct = lvProductRequested.SelectedItem as ItemRequestedProductList;
                if (!EmailHelper.SendEmail(_client.Id, ItemProduct.ProductID, ItemProduct.ClientPrice))

                    MessageBox.Show("El correo no pudo ser enviado");
                else
                {
                    _dataDC.SaleSet.First(S => S.Id == ItemProduct.SaleID).LastEmailDate = DateTime.Now;
                    _dataDC.SaveChanges();
                }
            }
        }
        class ItemSoldProductList
        {
            public String Name { get; set; }
            public String FinalPrice { get; set; }
            public String ProductID { get; set; }

        }
        class ItemRequestedProductList
        {
            public String Name { get; set; }
            public int ClientPrice { get; set; }
            public DateTime LastEmailDate { get; set; }
            public String ProductID { get; set; }
            public String SaleID { get; set; }
        }
    }
}