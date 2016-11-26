using Typing_Tester.Common;
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
using System.Threading;
using Windows.UI.Popups;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.ApplicationModel;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Typing_Tester
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Training4 : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public Training4()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void txtWrite_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtWrite.PlaceholderText = "";
        }

        static List<string> words = new List<string>();
        static List<int> wrongwords = new List<int>();

         int counter = 0;

        //private DispatcherTimer timer;
        //private int i, j;
        //void timer_Tick(object sender, object e)
        //{

        //    txt_timer.Text = "Time Consumed: " + (i) + " second(s)";
        //    i = i + j;
        //}
        //private void StartButton_Click(object sender, RoutedEventArgs e)
        //{
        //    timer.Start();
        //    //StartButton.IsEnabled = false;
        //    //StopButton.IsEnabled = true;
        //}

        //private void StopButton_Click(object sender, RoutedEventArgs e)
        //{
        //    timer.Stop();
        //    //StopButton.IsEnabled = false;
        //    //StartButton.IsEnabled = true;
        //}

        //private void SetTimeButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Init();
        //}

        //public void Init()
        //{
        //    j = i = Convert.ToInt32(txt_timer.Text);
        //    timer.Interval = TimeSpan.FromSeconds(i);
        //}

        DispatcherTimer timer;
        private int ticks = 60;
        async void timer_Tick(object sender, object e)
        {

            txt_timer.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Low, () => { txt_timer.Text = ticks.ToString(); ; });
            if (ticks <= 0)
            {



                timer.Stop();

                txt_timer.UpdateLayout();//txt_timer.Text=
                //nafez al fun bta3et al rate

                /*
                
                

                await md.ShowAsync();
                if (result == true)
                {
                    // do something   
                }
                Button1.Content = result.ToString();
                 * */



                MessageDialog msgDialog = new MessageDialog("your rate is = " + correct + " words per minute\nwrong words = " + nocorrect);
                int result = 0;
                msgDialog.Commands.Add(
                  new UICommand("main page", new UICommandInvokedHandler((cmd) => result = 1)));
                msgDialog.Commands.Add(
                   new UICommand("challenge", new UICommandInvokedHandler((cmd) => result = 2)));
                

                await msgDialog.ShowAsync();
                if (result == 1)
                {
                    this.Frame.Navigate(typeof(MainPage));
                }
                else if (result == 2)
                {
                    this.Frame.Navigate(typeof(challenge));
                }

               



                //var dialog = new MessageDialog("some sample text");
                //OK Button
                //UICommand retest = new UICommand("another speed test");
                //msgDialog.Commands.Add(retest);

                ////Cancel Button

                //UICommand mainpage1 = new UICommand("main page");
                //msgDialog.Commands.Add(mainpage1);





                //msgDialog.ShowAsync();
            }
            else
            {
                ticks--;
            }
        }


        private void ShareTextHandler(DataTransferManager sender, DataRequestedEventArgs e)
        {

            DataRequest request = e.Request;

            request.Data.Properties.Title = "social media ";

            request.Data.Properties.Description = "";

            request.Data.SetText(("your rate is = " + correct + " words per minute\nwrong words = " + nocorrect));

        }


        private void pageRoot_Loaded(object sender, RoutedEventArgs e)
        {
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();

            dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager,

                DataRequestedEventArgs>(this.ShareTextHandler);

            string text = "There is no doubt that the Internet is one of the greatest humankind's inventions of the last century. It is fast and easy way to get a lot of valuable information. However, some people believe that the Internet creates many problems. From my point of view I think that the Internet brings us advantages as well as disadvantages. First of all, I think that the Internet brings us many benefits. People can have access to the latest news, weather, traffic, bid-and-asked quotations, etc. Another important benefit is that the Internet is a great means of communication. A few years ago it was rather difficult to imagine that it would be possible to communicate with people from all around the world. Students have the opportunity to speak to the professors from prestigious universities, ask their opinions and extend their range of interests. People have the opportunity to communicate with the people from other countries, find out their customs, traditions and even visit each other. I think that the Internet makes our world smaller and friendlier. We' ve got the chance to learn more about the world's history, our forefathers and gain more knowledge. From the other hand, many questions and difficulties arose with the appearance of the Internet. For example, children got the easy access to the information they are not supposed to read. Also, people's security and privacy are often violated through steeling and gathering information about people and then selling it. Many banks had to increase their Internet security because of hacking. During his evolution journey from Neanderthals to Homo erectus and then to Homo sapiens, man has come long way. Because of his continuous quest for more and more amenities and facilities, the nineties have seen a major turn around with the invention of computers. 10 years ago, the term internet was practically anonymous to most of the people. And today internet has become the most ever powerful tool for man throughout the world. The internet is a collection of various services and resources. ";


            //string text = "Money is the most important and essential tool of modern economic life. One cannot imagine modern economic life without money. Barter economies or self-sufficient economies are the thing of past and historical significance. Money is the foundation stone of modern economic life. Money is the pivot around which all economic activities revolve. Money is important in all economies whether it is a socialist economy or a capitalist economy; or a backward economy or a rich economy. In the initial stages of exchange economy, commodities were exchanged with commodities. Such transactions were known as barter transactions. In this stage commodity was the form of money. How­ever, under barter transactions there were difficulties relating to common measure of value, store of value, divisibility of goods etc. Therefore, in place of commodities gold and silver were used as money. But even this system could not continue for long because the available stock of gold and silver was not adequate to meet the demand for the quantity of money. Therefore , it was replaced by paper money where promissory notes arc used as money. Now, besides paper money, credit money is being used exten­sively such as credit cards etc. There are many functions of money such as medium of exchange, basis of store of value, common measure of value, standard of deferred payments etc. However, money as a medium of exchange is the most important function. Therefore, in general, by money we mean such commodities which are ac­cepted as medium of exchange and which have legal sanction and general acceptability.";
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;


            for (int i = 0; i < text.Split(' ').ToList().Count; i++)
            {

                TextBox tb = new TextBox();
                tb.Background = new SolidColorBrush(Windows.UI.Colors.LightBlue);
                tb.BorderBrush = new SolidColorBrush(Windows.UI.Colors.LightBlue);
                tb.Width = 150;
                tb.IsHoldingEnabled = false;
                tb.IsReadOnly = true;
                tb.IsTapEnabled = false;


                //tb.FontSize = 60;

                tb.Text = (text.Split(' ').ToList())[i];
                tb.HorizontalAlignment = HorizontalAlignment.Stretch;

                tb.Name = (text.Split(' ').ToList())[i] + i;
                words.Add((text.Split(' ').ToList())[i]);

                //stckpnl.Children.Add(tb);
                lv.Items.Add(tb);
            }
            //stckpnl.FlowDirection = FlowDirection.LeftToRight;


        }


        static int correct = 0;
        static int nocorrect = 0;
        private void txtWrite_KeyDown(object sender, KeyRoutedEventArgs e)
        {

            if (e.Key == Windows.System.VirtualKey.Space)
            {
                if (txtWrite.Text.Length == 0)
                { }
                else
                {
                    if (txtWrite.Text == words[counter].ToString())
                    {

                        SolidColorBrush blueBrush = new SolidColorBrush(Windows.UI.Colors.Blue);
                        //(stckpnl.Children[counter] as TextBox).Background = blueBrush;
                        (lv.Items[counter] as TextBox).Background = blueBrush;

                        counter++;
                        correct++;
                        txtWrite.Text = string.Empty;
                    }
                    else
                    {
                        SolidColorBrush redBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                        //(stckpnl.Children[counter] as TextBox).Background = redBrush;
                        (lv.Items[counter] as TextBox).Background = redBrush;

                        counter++;
                        nocorrect++;
                        txtWrite.Text = string.Empty;


                    }
                }
            }
        }

        private void txtWrite_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Space)
            {
                txtWrite.Text = string.Empty;

            }
        }

        

        private void pageRoot_GotFocus_1(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        

        

        

        
    }
}
