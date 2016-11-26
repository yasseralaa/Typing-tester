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
    public sealed partial class advancedtest4 : Page
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


        public advancedtest4()
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(advancedtest5));
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
                  new UICommand("level 5", new UICommandInvokedHandler((cmd) => result = 1)));
                msgDialog.Commands.Add(
                   new UICommand("main page", new UICommandInvokedHandler((cmd) => result = 2)));
                msgDialog.Commands.Add(
                   new UICommand("share", new UICommandInvokedHandler((cmd) => result = 3)));

                await msgDialog.ShowAsync();
                if (result == 1)
                {
                    this.Frame.Navigate(typeof(advancedtest5));
                }
                else if (result == 2)
                {
                    this.Frame.Navigate(typeof(MainPage));
                }

                else if (result == 3)
                {

                    DataTransferManager.ShowShareUI();

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

            string text = "Generally, it is the student-community alone leads the fast-changing fashions. Once a thing or style gets in vogue, it is blindly followed by the students, notwithstanding how much inconvenience it entails. These days, boys, who by birth, are expected to be hardy and rough, look pale, tender and delicate.  They apply all sorts of cosmetics which were formerly used by the fair-sex alone. The way they dress their hair or the way they get their tight trousers or gaudy shirts stitched, or the way they walk with their necks craned forward appears ridiculous. But they are indifferent to all sense of decency. They must follow the fashions of film actors whether they can afford them or not.In the race of fashions, girls have not lagged behind. Rather they have gone a step ahead of the boys. They wear ‘sack shirts’  and their trousers do not let them sit properly. Their hair-styles give them an untidy and shabby look. Blindly they indulge in the foot-steps of the film actresses. Every fashion within limits is praise-worthy but when all limits are crossed, it results in many evils. Students should stop such recklessness in imitating fashions. Modesty and simplicity in their dress and habits should be the fashion trend.Going to movie theater indiscriminately has also become a fashion among the students. The theme of a movie may be worthless but they must go to see it even if they have to play truant from college. English movies may be beyond their comprehension but these have become a craze with the student-community. Our society does not allow us to follow certain scenes which are exhibited in these films. As a result, students, in the formative years of their lives, go astray. They while away their own precious time and squander away the money of their parents.Another fashion rampant among students is to go on strike over trifles. They have forgotten that, as students, they should not clamor for ‘rights’ but try to acquire knowledge whole-heartedly and with single minded devotion. Their duty is to amass the wealth of learning and not to flatter themselves about false sense of self-respect.It is a pity that modern students are caught deliberately in the whirl-pool of fashions. To make a noise in functions, to pass remarks on others, to discuss politics and to raise parties are, in a way, their fashionable pastimes. They forget everything else but always remember ‘misleading fashions.’ The sooner they extricate themselves out of these, the better for them and the nation it will be.";


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

        private void pageRoot_GotFocus(object sender, RoutedEventArgs e)
        {
            timer.Start();

        }
    }
}
