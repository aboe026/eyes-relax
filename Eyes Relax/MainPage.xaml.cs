using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Eyes_Relax
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static List<Relax> relaxes = new List<Relax>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RelaxPage), null);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Relax relax = e.Parameter as Relax;
            if (relax != null)
            {
                if (relaxes.Contains(relax)) {

                }
                else
                {
                    relaxes.Add(relax);
                }
            }

            saveRelaxesToFile();

            populateRelaxList();
        }

        public void populateRelaxList()
        {
            StackPanel relaxList = (StackPanel)this.FindName("relaxList");
            for (int i=0; i < relaxes.Count; i++)
            {
                Relax relax = relaxes.ElementAt(i);
                RelaxControl relaxControl = new RelaxControl(relax);
                relaxList.Children.Add(relaxControl);
            }
        }

        public void removeFromStackPanel(RelaxControl relaxControl)
        {
            StackPanel relaxList = (StackPanel)this.FindName("relaxList");
            relaxList.Children.Remove(relaxControl);
            saveRelaxesToFile();
        }

        private async void saveRelaxesToFile()
        {
            // serialize relax object
            MemoryStream mStream = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Relax>));
            serializer.WriteObject(mStream, relaxes);

            mStream.Position = 0;
            StreamReader sReader = new StreamReader(mStream);
            String contents = sReader.ReadToEnd();

            StorageFolder roamingFolder = ApplicationData.Current.RoamingFolder;
            StorageFile dataFile = await roamingFolder.CreateFileAsync("EyesRelax.txt", CreationCollisionOption.ReplaceExisting);
            try
            {
                await FileIO.WriteTextAsync(dataFile, contents);
            }
            catch (Exception ex) { }
        }
    }
}
