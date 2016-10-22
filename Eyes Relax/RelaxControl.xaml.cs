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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Eyes_Relax
{
    public sealed partial class RelaxControl : UserControl
    {
        public Relax relax { get; private set; }
        public RelaxControl(Relax relax)
        {
            this.InitializeComponent();
            this.relax = relax;
            PopulateControls();
        }

        public void PopulateControls()
        {
            TextBox name = (TextBox)this.FindName("name");
            name.Text = this.relax.name;

            TextBox waitDuration = (TextBox)this.FindName("waitDuration");
            TimeSpan waitSpan = this.relax.waitDuration;
            String waitText = "Wait: ";
            waitText += waitSpan.ToString();
            waitDuration.Text = waitText;

            TextBox relaxDuration = (TextBox)this.FindName("relaxDuration");
            TimeSpan relaxSpan = this.relax.relaxDuration;
            String relaxText = "Relax: ";
            relaxText += relaxSpan.ToString();
            relaxDuration.Text = relaxText;
        }

        private void Grid_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout(sender as FrameworkElement);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = getMainPage();
            mainPage.Frame.Navigate(typeof(RelaxPage), relax);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MainPage.relaxes.Remove(relax);
            MainPage mainPage = getMainPage();
            mainPage.removeFromStackPanel(this);
        }

        private MainPage getMainPage()
        {
            StackPanel stackPanel = (StackPanel)this.Parent;
            ScrollViewer scrollViewer = (ScrollViewer)stackPanel.Parent;
            Grid grid = (Grid)scrollViewer.Parent;
            MainPage mainPage = (MainPage)grid.Parent;
            return mainPage;
        }
    }
}
