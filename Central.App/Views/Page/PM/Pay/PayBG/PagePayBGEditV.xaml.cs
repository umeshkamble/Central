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
    public partial class PagePayBGEditV : PagePayEditV
    {
        public PagePayBGEditV(PagePayBGEditVM vm)
        {
            InitializeComponent();
            this.BindingContext = vm;
        }


        protected override async Task OnLoadAsync()
        {
            await base.OnLoadAsync();
            ((PagePayBGEditVM)this.BindingContext).LoadAsyncCommand.Execute(null);
        }
    }
}