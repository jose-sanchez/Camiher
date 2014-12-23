using System;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Camiher.Libs.Common;
using Camiher.Libs.DataProviders;
using Camiher.Libs.DataProviders.Interfaces;
using Camiher.Libs.Server.DAL.CamiherDAL;
using Camiher.Libs.Server.WebServicesObjects;
using Image = System.Drawing.Image;

namespace Camiher.UI.AdministrationCenter.Products

{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DragDropImage : Window
    {
        CamiherContext _dataDC;
        string _productID;

        public string ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }
        ObservableProductImage imagelist;
        private IBusinessOperationProvider operationProvider;
        public DragDropImage(string Product)
        {
            InitializeComponent();
            _productID = Product;
            operationProvider = DataProvidersFactory.GetBusinessOperationProvider();
            ProductsImagesResponse response = operationProvider.GetProductImages(_productID);
            if (response.IsCorrect)
            {
               imagelist = new ObservableProductImage(response.ProductsImages);
            }
            else
            {
                MessageBox.Show(String.Format("Couldnt recover Images for product {0}",Product));
                //Addlog
            }


            ImageList.ItemsSource = imagelist;
            
        }


        private BitmapImage LoadImageFromFile(string filename)
        {
            using (var fs = File.OpenRead(filename))
            {
                var img = new BitmapImage();
                img.BeginInit();
                img.CacheOption = BitmapCacheOption.OnLoad;
                // Downscaling to keep the memory footprint low
                img.DecodePixelWidth = (int)SystemParameters.PrimaryScreenWidth;
                img.StreamSource = fs;
                img.EndInit();
                return img;
            }
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            var data = e.Data as DataObject;
            if (data.ContainsFileDropList())
            {
                var files = data.GetFileDropList();
                foreach (string file in files)
                {
                    string filename = System.IO.Path.GetFileName(file);
                    if (imagelist.Where(S => S.Name == filename).Count() == 0)
                    {
                        ProductImageSet newImage = new ProductImageSet();
                        newImage.ProductID = _productID;
                        newImage.Path = file;
                        newImage.Name = filename;
                        Ramdom r = new Ramdom();
                        newImage.ImageID = r.RandomString(32);
                        newImage.Order = 0;
                        imagelist.Add(newImage);
                        if (!Properties.Settings.Default.OnlineMode)
                        {
                            _dataDC.ProductImages.Add(newImage);
                            _dataDC.SaveChanges();
                        }
                        string destinationFile = Properties.Settings.Default.ImagePath + "\\" + ProductID + "\\" + filename;
                        if(!System.IO.Directory.Exists(Properties.Settings.Default.ImagePath + "\\" + ProductID ))
                        {
                        System.IO.Directory.CreateDirectory(Properties.Settings.Default.ImagePath + "\\" + ProductID);
                        }
                        System.IO.File.Copy(file, destinationFile);
                        imageViewer.Source = LoadImageFromFile(destinationFile);
                        ImageList.ItemsSource = imagelist.Where(S => S.ProductID == _productID).ToList();

                        //Upload to internet


                        Image image = Image.FromFile(file);
                        image.imageToByteArray().CreateThumbnail(400).byteArrayToImage().Save(destinationFile);
                        newImage.Data = System.Text.Encoding.Default.GetString(image.imageToByteArray().CreateThumbnail(400));

                        DataProvidersFactory.GetBusinessOperationProvider().AddProductImage(newImage);


                        //using (System.Drawing.Image thumbnail = image.GetThumbnailImage(100, 100, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero))
                        //{
                        //    using (MemoryStream memoryStream = new MemoryStream())
                        //    {
                        //        thumbnail.Save(memoryStream, ImageFormat.Png);
                        //        Byte[] bytes = new Byte[memoryStream.Length];
                        //        memoryStream.Position = 0;
                        //        memoryStream.Read(bytes, 0, (int)bytes.Length);
                        //        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        //    }
                        //}
                    }
                    else
                    {
                        MessageBox.Show("La imagen" + filename + " ya ha sido añadida anteriormente");
                    }
                }
            }

        }

        private void BorrarMouseDown(object sender, RoutedEventArgs e)
        {
            ProductImageSet Image = new ProductImageSet();
            if(ImageList.SelectedItem!= null){
                try
                {
                    Image = ImageList.SelectedItem as ProductImageSet;
                    if (!Properties.Settings.Default.OnlineMode)
                    {
                        operationProvider.DeleteProductImage(Image.ImageID);
                    }
                    else
                    {
                        _dataDC.ProductImages.Remove(Image);
                        _dataDC.SaveChanges();                    
                    }
                    ImageList.Items.Remove(Image);
                    System.IO.File.Delete(Image.Path);
                }
                catch(Exception ex) {
                    System.Windows.MessageBox.Show("Error Borrando la imagen " + Image.Name + ": " + ex.ToString()); 
                }
            }
        }

        private void ImageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductImageSet image = ImageList.SelectedItem as ProductImageSet;
            imageViewer.Source = LoadImageFromFile(image.Path);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }
}

