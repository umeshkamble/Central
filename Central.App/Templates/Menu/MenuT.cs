using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.Templates
{
    public class MenuT : PanelV
    {
        public static readonly BindableProperty PnIconProperty = BindableProperty.Create(nameof(PnIcon), typeof(string), typeof(MenuT), string.Empty);
        public string PnIcon
        {
            get => (string)GetValue(PnIconProperty);
            set => SetValue(PnIconProperty, value);
        }

        public static readonly BindableProperty PnViewIconProperty = BindableProperty.Create(nameof(PnViewIcon), typeof(bool), typeof(MenuT), false);
        public bool PnViewIcon
        {
            get => (bool)GetValue(PnViewIconProperty);
            set => SetValue(PnViewIconProperty, value);
        }

        public static readonly BindableProperty PnViewSpaceProperty = BindableProperty.Create(nameof(PnViewSpace), typeof(bool), typeof(MenuT), false);
        public bool PnViewSpace
        {
            get => (bool)GetValue(PnViewSpaceProperty);
            set => SetValue(PnViewSpaceProperty, value);
        }
    }
}
