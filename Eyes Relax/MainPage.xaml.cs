using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        public List<Relax> relaxes { get; private set; }

        public MainPage()
        {
            this.InitializeComponent();
            this.relaxes = new List<Relax>();
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
                    addRelaxToPage(relax);
                }
            }
        }

        private void addRelaxToPage(Relax relax)
        {
            StackPanel relaxList = (StackPanel)this.FindName("relaxList");
            RelaxControl relaxControl = new RelaxControl(relax);
            relaxList.Children.Add(relaxControl);
        }
    }
}
