using Central.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Maui; using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace Central.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageFilterContactV : PageFilterV
    {
        public View BodyFilterContact
        {
            get => BodyFilterContactContent.Content;
            set => BodyFilterContactContent.Content = value;
        }

        public PageFilterContactV()
        {
            InitializeComponent();
        }
    }
}