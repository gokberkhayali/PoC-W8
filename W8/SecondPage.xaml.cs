using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using W8.Views;
using Windows.UI.Popups;


namespace W8
{
    
    public sealed partial class SecondPage : Page
    {

        List<StackPanel> stackList = new List<StackPanel>();

        int cur = -1;
        int max = -1;
        
        
        public SecondPage()
        {
            this.InitializeComponent();
            cur = max = 0;

            CreateContentPanel();
            SetContentPanel(stackList.ElementAt(cur));
        
        }


        private void CreateContentPanel()
        {
            StackPanel stackPanel = new StackPanel();

            TextBoxUserControl textBox = new TextBoxUserControl();

            stackPanel.Children.Add(textBox);
            stackList.Add(stackPanel);

        }


        public void SetContentPanel(StackPanel stackPanel)
        {
            ContentPanel.Children.Clear();
            ContentPanel.Children.Add(stackPanel);
        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {

            if (cur < max)
            {
                cur++;
                SetContentPanel(stackList.ElementAt(cur));
            }
            else
            {
                cur++;
                max++;
                CreateContentPanel();
                SetContentPanel(stackList.ElementAt(cur));

            }

        }

        private void ButtonPrev_Click(object sender, RoutedEventArgs e)
        {
            if (cur <= 0)
            {

                MessageDialog mesaj = new MessageDialog("This is first page.");
                mesaj.ShowAsync();
                return;

            }
            else
            {
                cur--;

                SetContentPanel(stackList.ElementAt(cur));

            }
        }
    }
}
