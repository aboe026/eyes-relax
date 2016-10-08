using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Eyes_Relax
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RelaxPage : Page
    {
        public Relax relax { get; set; }
        public RelaxPage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Relax relax = e.Parameter as Relax;
            this.relax = relax;
            populatePage();
        }

        private void App_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
                return;

            // Navigate back if possible, and if the event has not 
            // already been handled .
            if (rootFrame.CanGoBack && e.Handled == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }


        public void populatePage()
        {
            if (this.relax == null) {
                ((Button)this.FindName("relaxChange")).Content = "Add";
            }
        }

        private void makeNumber(object sender, TextChangedEventArgs e)
        {
            TextBox box = (TextBox)sender;
            String text = box.Text;
            StringBuilder builder = new StringBuilder();
            foreach (char c in text)
            {
                if (Char.IsNumber(c) && !(c.ToString() == "0" && builder.Length == 0))
                {
                    builder.Append(c);
                }
            }
            box.Text = builder.ToString();
        }
        
        private async void changeButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Content.ToString() == "Add")
            {
                // null value checks
                TextBox relaxName = (TextBox)this.FindName("relaxName");
                TextBox relaxWaitDuration = (TextBox)this.FindName("relaxWaitDuration");
                ComboBox relaxWaitUnits = (ComboBox)this.FindName("relaxWaitUnits");
                TextBox relaxRelaxDuration = (TextBox)this.FindName("relaxRelaxDuration");
                ComboBox relaxRelaxUnits = (ComboBox)this.FindName("relaxRelaxUnits");
                if (relaxName.Text == null || relaxName.Text == "")
                {
                    var dialog = new MessageDialog("You must specify a Name.");
                    dialog.Title = "Missing Information";
                    await dialog.ShowAsync();
                }
                else if (relaxWaitDuration == null || relaxWaitDuration.Text == "")
                {
                    var dialog = new MessageDialog("You must specify a Wait Duration.");
                    dialog.Title = "Missing Information";
                    await dialog.ShowAsync();
                }
                else if (relaxWaitUnits == null || relaxWaitUnits.SelectedValue == null)
                {
                    var dialog = new MessageDialog("You must specify Wait Units.");
                    dialog.Title = "Missing Information";
                    await dialog.ShowAsync();
                }
                else if (relaxRelaxDuration == null || relaxRelaxDuration.Text == "")
                {
                    var dialog = new MessageDialog("You must specify a Relax Duration.");
                    dialog.Title = "Missing Information";
                    await dialog.ShowAsync();
                }
                else if (relaxRelaxUnits == null || relaxRelaxUnits.SelectedValue == null)
                {
                    var dialog = new MessageDialog("You must specify Relax Units.");
                    dialog.Title = "Missing Information";
                    await dialog.ShowAsync();
                }
            }
        }
    }
}
