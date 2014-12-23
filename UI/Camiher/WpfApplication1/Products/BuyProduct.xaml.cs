using System;
using System.Windows;
using Camiher.Libs.Server.DAL.CamiherDAL;

namespace Camiher.UI.AdministrationCenter.Products
{
    /// <summary>
    /// Interaction logic for BuyProduct.xaml
    /// </summary>
    public partial class BuyProduct : Window
    {
        SaleSet _sale;
        private Boolean _cancel = false;
        public Boolean Cancel
        {
            get { return _cancel; }
            set { _cancel = value; }
        }

        
        public BuyProduct(SaleSet sale)
        {
            InitializeComponent();
            _sale = sale;
            tbPrecioCliente.Text = sale.PriceforClient.ToString();

        }

        private void btBuy_Click(object sender, RoutedEventArgs e)
        {
            if (tbPrecioFinal.Text != "" && tbPrecioFinal.Text != null && tbPrecioFinal.Text != "0")
            {
                _sale.FinalPrice = Convert.ToInt32(tbPrecioFinal.Text);
                _cancel = false;
                Close();
            }
            else { 
                MessageBox.Show("Rellene el campo Precio Final");
                _cancel = true;
            }
        }

    }
}
