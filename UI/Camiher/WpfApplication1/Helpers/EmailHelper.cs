using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using Common;
using Logger;
using WpfApplication1.Properties;

namespace WpfApplication1.Helpers
{
    class EmailHelper
    {
        private static IEmail _email;
        private static readonly MailAddress FromAddress;
        static EmailHelper()
        {
            FromAddress = new MailAddress(Settings.Default.EmailAddress, Resources.EmailUserDisplayName);
            //Get smtpClienttype
            SmtpClientType smtpClientType = SmtpClientFactory.GetSmtpClientType(ConfigParameters.GetKey("EmailType"));
            //Get the password
            string password = ConfigParameters.GetKey("EmailPassword");
            _email = new Email(Settings.Default.EmailAddress, password, smtpClientType);
        }

        public EmailHelper(IEmail email)
        {
            _email = email;
        }

        public static Boolean SendEmail(string clientId, string productId, int price)
        {
            Model1Container dataDc = ModelSingleton.getDataDC;
            //Recover Client and Product Data
            ClientSet client = dataDc.ClientSet.First(s => s.Id == clientId);
            if (!string.IsNullOrEmpty(client.Email))
            {
                ProductsSet product = dataDc.ProductsSet.First(s => s.Id == productId);
                //Build the destination address
                var toAddress = new MailAddress(client.Email, client.Name + " " + client.Surname);
                //Build the subject
                string subject = product.Producto + " " + product.Marca + " " + product.Modelo;
                //Build the body
                string body = BuildBody(product, client, price);

                //collecting attached
                String[] imagePathList =
                    new ObservableProductImage(dataDc, product.Id).Where(s => s.Email == true).Select(l=>l.Path).ToArray();
                return _email.SendEmail(FromAddress, toAddress, subject, body, imagePathList);
            }
            else
            {
                AppLogger.Error("[EmailHelper][SendEmail]:The client " + client.Name + " does not have set a email so the mail will not be sent");
                System.Windows.MessageBox.Show("El cliente " + client.Name + "no tiene asociado un correo electronico por lo que el correo no le sera enviado");
                return false;
            }
        }

        /// <summary>
        /// Build the body template
        /// </summary>
        /// <param name="product"></param>
        /// <param name="client"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        private static string BuildBody(ProductsSet product, ClientSet client, int price)
        {

            var body = new StringBuilder();
            string introduction = "De acuerdo a conversaciones previas habiendo expresado su interes por un/una "
                + product.Producto;
            body.Append(introduction);
            if (product.Marca != "")
            {
                body.Append(" de la marca " + product.Marca);
            }
            if (product.Modelo != "")
            {

                body.Append(" modelo " + product.Modelo);
            }
            body.AppendLine(" le envio informacion sobre este/esta " + product.Producto + "el cual podria interesarle:");
            body.AppendLine();
            body.AppendLine("Producto: " + product.Producto);
            body.AppendLine("Modelo: " + product.Modelo);
            body.AppendLine("Marca: " + product.Marca);
            body.AppendLine("Año: " + product.Año);
            body.AppendLine("Peso: " + product.Peso + " Kilos");
            body.AppendLine("Potencia: " + product.Potencia + "CV");
            body.AppendLine("Precio: " + price + " Euros");
            return body.ToString();
        }
    }
}
