﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Maui; using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace Central.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentProductBrandListV : ContentListV
    {
        public ContentProductBrandListV()
        {
            InitializeComponent();
        }
    }
}