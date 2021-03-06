﻿using Typing_Tester.Common;
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
    public sealed partial class advancedtest9 : Page
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


        public advancedtest9()
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
            this.Frame.Navigate(typeof(advancedtest10));
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
                  new UICommand("level 10", new UICommandInvokedHandler((cmd) => result = 1)));
                msgDialog.Commands.Add(
                   new UICommand("main page", new UICommandInvokedHandler((cmd) => result = 2)));
                msgDialog.Commands.Add(
                   new UICommand("share", new UICommandInvokedHandler((cmd) => result = 3)));

                await msgDialog.ShowAsync();
                if (result == 1)
                {
                    this.Frame.Navigate(typeof(advancedtest10));
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

            string text = "Up until recently most computers were serial computers. Such computers had a single processor chip containing a single processor. Parallel computing is based on the idea that if more than one task can be processed simultaneously on multiple processors then a program would be able to run more rapidly than it could on a single processor. The supercomputers of the 1990s, such as the Cray computers, were extremely expensive to purchase (usually over $1,000,000) and often required cooling by liquid helium so they were also very expensive to run. Clusters of networked computers (eg. a Beowulf culster of PCs running Linux) have been, since 1994, a much cheaper solution to the problem of fast processing of complex computing tasks. By 2008, most new desktop and laptop computers contained more than one processor on a single chip (eg. the Intel Core 2 Duo released in 2006 or the Intel Core 2 Quad released in 2007). Having multiple processors does not necessarily mean that parallel computing will work automatically. The operating system must be able to distribute programs between the processors (eg. recent versions of Microsoft Windows and Mac OS X can do this). An individual program will only be able to take advantage of multiple processors if the computer language it's written in is able to distribute tasks within a program between multiple processors. For example, OpenMP supports parallel programming in Fortran and C/C++. Prehistoric man did not have the Internet, but it appears that he needed a way to count and make calculations. The limitations of the human body’s ten fingers and ten toes apparently caused early man to construct a tool to help with those calculations. Scientists now know that humankind invented an early form of computers. Their clue was a bone carved with prime numbers found in 8,500 BC.The abacus was the next leap forward in computing between 1000 BC and 500 BD. This apparatus used a series of moveable beads or rocks. The positions changed to enter a number and again to perform mathematical operations. Leonardo Da Vinci was credited with the invention of the world’s first mechanical calculator in 1500. In 1642, Blaise Pascal’s adding machine upstaged Da Vinci’s marvel and moved computing forward again. In 1690, Gottfried Leibnitz developed a machine that could add, subtract, multiply, divide, and calculate square roots. The instructions were programmed into the machine. Programming was accomplished through the use of gears. The drawback to this machine was that the instructions could not be changed without changing the whole machine. In 1801, Joseph Jacquard developed a loom controlled by punched cards. The cards were made of cardboard which were programmed with instructions. Each card represented a loop, and the machine read the cards as they were passed over a series of rods. The loom was the early ancestor of the IBM punched card. In 1812, Charles Babbage was a genius of a man who saw few of his inventions actually built. He designed and built a model of what was called the difference engine. This invention was designed to perform calculations without human intervention. The ultimate goal of the machine was to have the machine calculate logarithm tables and print the results. Babbage was so far ahead of the times that the technology was not in place to manufacture the parts for his machine so he was only able to build a small model. In 1833, Babbage then designed the analytic engine. This machine had many of the same parts that could be found in modern day computers. It had an arithmetic unit which performed calculations. Another part of the computer was called the store which stored intermediate and final results and instructions. This was completed for each stage of calculation. It was to get its instructions from punched cards and worked through mechanical means. The machine would be able to perform any calculation. Before the machine could be made Babbage died. His son built a small model of the work that still exists today. Babbage became known as the father of the modern day computers. ";
            
            
            


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
