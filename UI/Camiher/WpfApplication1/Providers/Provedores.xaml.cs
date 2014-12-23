using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Camiher.Libs.Common;
using Camiher.Libs.Server.DAL.CamiherDAL;
using Camiher.UI.AdministrationCenter.Models;

namespace Camiher.UI.AdministrationCenter.Providers
{
    /// <summary>
    /// Interaction logic for Provedores.xaml
    /// </summary>
    public partial class Provedores : Page
    {
        ObservableProveedor lp;
        private  CamiherContext _dataDC =  ModelSingleton.getDataDC;
        public Provedores()
        {
            InitializeComponent();

            lp = new ObservableProveedor(_dataDC);
            this.DataContext =lp;
            proveedorSetListView.ItemsSource = lp;
            //this.DataContext = _dataDC.ProveedorSet.ToList();
            //List<ProveedorSet> pl = _dataDC.ProveedorSet.ToList();
            //proveedorSetListView.ItemsSource = _dataDC.ProveedorSet.ToList();

            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {


            ProvidersSet pro = new ProvidersSet();
            List<ProvidersSet> lp = _dataDC.Providers.ToList();
            Ramdom r = new Ramdom();
           pro.Id  = r.RandomString(32);
            
           //pro.Apellido = direccionTextBox.Text;
           //pro.Descripcion = descripcionTextBox.Text;
           //pro.Direccion = direccionTextBox.Text;
           //pro.Email = emailTextBox.Text;
           //pro.Nombre = nombreTextBox.Text;
           //pro.TelefonoF = telefonoFTextBox.Text;
           //pro.TelefonoM = telefonoMTextBox.Text;
           //_dataDC.ProveedorSet.AddObject(pro);

           //_dataDC.SaveChanges();
        }



        private void proveedorSetListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (proveedorSetListView.SelectedItem != null)
            {
            String file = proveedorSetListView.SelectedItem.ToString();
            ProvidersSet p = (ProvidersSet)proveedorSetListView.SelectedItem;
            Provider providerdetails = new Provider(p);
            providerdetails._new = false;
          
            providerdetails.ShowDialog();
       
            _dataDC.SaveChanges();
            }
        }



        private void MenuItem_MouseDown(object sender, RoutedEventArgs e)
        {
            //provmenu.PlacementTarget = this;
            //provmenu.IsOpen = true;

            ProvidersSet p = new ProvidersSet();
            Provider providerdetails = new Provider(p);
            providerdetails._new = true;
         
            providerdetails.ShowDialog();
           
            if (providerdetails._new)
            {
                lp.Add(p);
                _dataDC.Providers.Add(p);
                _dataDC.SaveChanges();
            }
        }
    }
}
