using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataProviders;
using DataProviders.Interfaces;
using DataProviders.ServiceReference1;
using Logger;

namespace UserViewer
{
    public partial class Form1 : Form
    {
        IUserProviderAsync UserProvider = DataProvidersFactory.GetUserDataProvider();
        public Form1()
        {
            InitializeComponent();
            //handle the event complete
            UserProvider.GetHelloWorldAsyncComplete += callbackwebservice_Click;
            AppLogger.Info("Starting UserViewer");
        }
        /// <summary>
        /// Call to web service provider which will call the Async web service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btcallwebservice_Click(object sender, EventArgs e)
        {
            UserProvider.getHelloWorldAsync();
            textBox1.Text = "Calling Web Service";
            AppLogger.Info("web service called");
        }
        /// <summary>
        /// handle the call back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void callbackwebservice_Click(object sender, HelloWorldCompletedEventArgs e)
        {          
            textBox1.Text = e.Result.ToString();
        }
    }
}
