using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PicViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PictureList _PicList = null;
        string folderpath;
        public string FolderPath
        {
            get { return folderpath; }
            set { folderpath = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _PicList = new PictureList();
            _PicList.Init(folderpath);

            if (_PicList.Count > 0)
            {
                string str = _PicList.Peek();
                DisplayPicture(str);
            }
            else {
                this.Close();
            }
        }


        private void buttonPrev_Click(object sender, RoutedEventArgs e)
        {
            string str = _PicList.Prev();
            DisplayPicture(str);
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            string str = _PicList.Next();
            DisplayPicture(str);
        }

        private void DisplayPicture(string str)
        {
            BitmapImage bi = new BitmapImage(new Uri(str));
            imagePicture.Source = bi;
            labelPath.Content = str;
        }

        private void Feeds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // todo:  exercise for the user, allow clicking on picture to go to the news story
            string url = ((Feeds.SelectedItem as ComboBoxItem).Tag as string);
            _PicList.LoadFromRss(url);
            buttonNext_Click(null, null);
        }
    }
}