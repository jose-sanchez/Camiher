using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Camiher.Libs.Common;
using Camiher.Libs.Server.DAL.CamiherDAL;
using Camiher.UI.AdministrationCenter.Models;
using Validation = Camiher.Libs.Common.Validation;

namespace Camiher.UI.AdministrationCenter.Providers
{
    /// <summary>
    /// Interaction logic for Provider.xaml
    /// </summary>
    /// 

    public partial class Provider : Window

    {
        private static CamiherContext _dataDC = ModelSingleton.getDataDC;
        private Boolean _newI = false;
        private ProvidersSet _proveedor;


        private Boolean _cancel=true;
        public Boolean Cancel
        {
            get { return _cancel; }
            set { _cancel = value; }
        }
        public Boolean _new
        {
            get { return _newI; }
            set
            {
                _newI = value;
                if (_newI)
                {
                    tbAddress.IsEnabled = false;
                    tbMovil.IsEnabled = false;
                    tbFijo.IsEnabled = false;
                    tbEmail.IsEnabled = false;
                    btBuscar.Visibility = Visibility.Visible;
                    var r = new Ramdom();
                    _proveedor.Id = r.RandomString(32);
                    _proveedor.Descripcion = "";
                }
                else
                {
                    tbAddress.IsEnabled = true;
                    tbMovil.IsEnabled = true;
                    tbFijo.IsEnabled = true;
                    tbEmail.IsEnabled = true;
                    btBuscar.Visibility = Visibility.Hidden;
                    btSave.IsEnabled = true;
         
                }
                ProductByProviderList.ProvedorID = _proveedor.Id;
            }
        }
       
        public Provider(ProvidersSet proveedor)
        {
            InitializeComponent();
          
            ProductByProviderList.LWidth = 250;
            
            _proveedor = proveedor;
            btSave.IsEnabled = false;
            //else
            //{
            //    tbAddress.IsEnabled = true;
            //    tbMovil.IsEnabled = true;
            //    tbFijo.IsEnabled = true;
            //    tbEmail.IsEnabled = true;
            //    btBuscar.Visibility = System.Windows.Visibility.Hidden;
            //}
 
            this.DataContext = proveedor;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (validateField())
            {
                Cancel = false;
                this.Close();

            }




          
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (validateField())
            {
                List<ProvidersSet> custQuery = _dataDC.Providers.Where(S => S.Nombre == tbNombre.Text && S.Apellido == tbApellido.Text).ToList();

                if (custQuery.Count() >= 1)
                {
                    tbAddress.Text = custQuery.First().Direccion;
                    tbEmail.Text = custQuery.First().Email;
                    tbFijo.Text = custQuery.First().TelefonoF;
                    tbMovil.Text = custQuery.First().TelefonoM;
                    _new = false;


                }
                else
                {
                    tbAddress.IsEnabled = true;
                    tbMovil.IsEnabled = true;
                    tbFijo.IsEnabled = true;
                    tbEmail.IsEnabled = true;
                }
                btSave.IsEnabled = true;
            }
        }
        #region validation
        private Boolean validateField() 
        {
            if (tbNombre.Text == "")
            {
                MessageBox.Show("Rellene el campo Nombre");
                return false;
            }
            if (tbApellido.Text == "")
            {
                MessageBox.Show("Rellene el campo Apellido");
                return false;
            }
            if (tbMovil.Text == "")
            {
                _proveedor.TelefonoM = "";
            }
            if (tbMovil.Text == "")
            {
                _proveedor.TelefonoM = "";
            }
            if (tbFijo.Text == "")
            {
                _proveedor.TelefonoF = "";
            }
            if (tbEmail.Text == "")
            {
                _proveedor.Email = "";
            }
            if (tbAddress.Text == "")
            {
                _proveedor.Direccion = "";
            }
            return true;
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

        private void ProductByProviderList_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this._newI)
            {
                _dataDC.Providers.Add(_proveedor);
                _dataDC.SaveChanges();
                this._newI = false;
            }
        }

  

    }

    public class ObservableProveedor : ObservableCollection<ProvidersSet>
    {
        public ObservableProveedor(CamiherContext dataDc)
        {
            //Open class view to find out what Properties the wizard
            //had created in the DataClasses1DataContext class, otherwise
            //I wouldn't have known about Peoples
            foreach (ProvidersSet thisPerson in dataDc.Providers)
            {
                this.Add(thisPerson);
            }
        }
    }
}
