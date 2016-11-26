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
using Windows.UI.Notifications;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.Web.Syndication;
using Typing_Tester.Common;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;
using Windows.System;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Typing_Tester
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public string tileType = "";
        public MainPage()
        {
            this.InitializeComponent();
            TileTimer();
            SettingsPane.GetForCurrentView().CommandsRequested += CommandsRequested;
            SettingsPane.GetForCurrentView().CommandsRequested += settingcharmManager_commandsRequested;
            
        }
      
        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
       public void CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            args.Request.ApplicationCommands.Add(new SettingsCommand("s", "Description", (p) => { cfoSettings.IsOpen = true; }));
            args.Request.ApplicationCommands.Add(new SettingsCommand("s", "About", (p) => { cfoAbout.IsOpen = true; }));
            
            
        }

       public void settingcharmManager_commandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
       {
           args.Request.ApplicationCommands.Add(new SettingsCommand("privacypolicy", "privacy policy", openPrivacyPolicy));
       }

       public async void openPrivacyPolicy(IUICommand command)
       {
           Uri uri = new Uri("http://www.freeprivacypolicy.org/generic.php");
           await Launcher.LaunchUriAsync(uri);

       }

     
        public sealed partial class AboutUserControl : UserControl
    {
        public AboutUserControl()
        {
            //this.InitializeComponent();
        }

        public void Image_Tapped_2(object sender, TappedRoutedEventArgs e)
        {
            var uri = new Uri("https://www.facebook.com/EGAppFactory");
            //hena hn7oot el elink ely feh el Privacy policy
            
            
            IAsyncOperation<bool> x = Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private void Image_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            var uri = new Uri("https://www.twitter.com/");
            //hena hn7oot el elink ely feh el Privacy policy
            IAsyncOperation<bool> x = Windows.System.Launcher.LaunchUriAsync(uri);

        }

        private async void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            /// kindly change the email bleow to your email 
            var mailto = new Uri("mailto:eng.sayed.mahmoud@hotmail.com");
            await Windows.System.Launcher.LaunchUriAsync(mailto);
        }
    }


          private void CreateTile(double seconds)
          {

              var updater = TileUpdateManager.CreateTileUpdaterForApplication();
              updater.EnableNotificationQueue(true);
              updater.Clear();



              var tile = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Block);
              tile.GetElementsByTagName("text")[0].InnerText = "Typing";
              tile.GetElementsByTagName("text")[1].InnerText = "Tester";
              TileNotification tileNotification = new TileNotification(tile);
              tileNotification.ExpirationTime = DateTime.Now.AddSeconds(20);
              updater.Update(tileNotification);


              tile.GetElementsByTagName("text")[0].InnerText = "Typing";
              tile.GetElementsByTagName("text")[1].InnerText = "Tester";
               tileNotification = new TileNotification(tile);
              tileNotification.ExpirationTime = DateTime.Now.AddSeconds(20);
              updater.Update(tileNotification);


              var tile1 = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150BlockAndText01);
              tile1.GetElementsByTagName("text")[0].InnerText = "Typing";
              tile1.GetElementsByTagName("text")[1].InnerText = "Tester";
              tile1.GetElementsByTagName("text")[2].InnerText = "";
              tile1.GetElementsByTagName("text")[3].InnerText = "";
              tile1.GetElementsByTagName("text")[4].InnerText = "";
              TileNotification tileNotification1 = new TileNotification(tile1);
              tileNotification1.ExpirationTime = DateTime.Now.AddSeconds(20);
              updater.Update(tileNotification1);


              var tile2 = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare310x310TextList01);
              tile2.GetElementsByTagName("text")[0].InnerText = "Typing Tester";
              tile2.GetElementsByTagName("text")[1].InnerText = "Challenge";
              tile2.GetElementsByTagName("text")[2].InnerText = "Training";
              tile2.GetElementsByTagName("text")[3].InnerText = "Challenge";
              tile2.GetElementsByTagName("text")[4].InnerText = "Speed Test";
              tile2.GetElementsByTagName("text")[5].InnerText = "Advanced Test";
              tile2.GetElementsByTagName("text")[6].InnerText = "Training";
              tile2.GetElementsByTagName("text")[7].InnerText = "Learn";
              tile2.GetElementsByTagName("text")[8].InnerText = "Practice";
             
              TileNotification tileNotification2 = new TileNotification(tile2);
              tileNotification2.ExpirationTime = DateTime.Now.AddSeconds(20);
              updater.Update(tileNotification2);


             





          }
    
          private void TileTimer()
          {
              DispatcherTimer dt = new DispatcherTimer();
              dt.Interval = new TimeSpan(0, 0, 30);
              dt.Tick += (object sender, object e) => CreateTile(5);
              dt.Start();
          }


        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Training1));
        }

        private void Image_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(challenge));
        }

        private void Image_Tapped_2(object sender, TappedRoutedEventArgs e)
        {

        }
    
    }
    }
