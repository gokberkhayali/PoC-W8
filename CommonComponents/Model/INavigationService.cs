﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonComponents.Model
{
    public interface INavigationService
    {


        void GoBack();

        void Navigate(Uri type);
       
        


       
    }
}
