using CommonComponents.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace W8
{
    public class NavigationService : INavigationService
    {
        public Frame RootFrame
        {
            get;
            set;
        }

        public NavigationService(Frame rootFrame)
        {
            RootFrame = rootFrame;
        }

      

        public void Navigate(Uri uri)
        {
            String str =  uri.ToString();
            String typeStr = str.Replace(".xaml", "");
            Type type = Type.GetType(str);
            type = Type.GetType(typeStr);
            RootFrame.Navigate(type);
            // RootFrame.Navigate(uri);
        }

        
        public void GoBack()
        {
            if (RootFrame.CanGoBack)
            {
                RootFrame.GoBack();
            }
        }
        
      
       
        
    }
}
