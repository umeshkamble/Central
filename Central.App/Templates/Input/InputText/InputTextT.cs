using MongoDB.Driver.Core.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Central.App.Templates
{
    public class InputTextT : InputT
    {
        public static readonly BindableProperty PnTextProperty = BindableProperty.Create(nameof(PnText), typeof(string), typeof(InputTextT), string.Empty);
        public string PnText
        {
            get => (string)GetValue(PnTextProperty);
            set => SetValue(PnTextProperty, value);
        }

        public static readonly BindableProperty PnTextAlignmentProperty = BindableProperty.Create(nameof(PnTextAlignment), typeof(TextAlignment), typeof(InputTextT), TextAlignment.Start);
        public TextAlignment PnTextAlignment
        {
            get => (TextAlignment)GetValue(PnTextAlignmentProperty);
            set => SetValue(PnTextAlignmentProperty, value);
        }

        public static readonly BindableProperty PnKeyboardProperty = BindableProperty.Create(nameof(PnKeyboard), typeof(Keyboard), typeof(InputTextT), Keyboard.Default);
        public Keyboard PnKeyboard
        {
            get => (Keyboard)GetValue(PnKeyboardProperty);
            set => SetValue(PnKeyboardProperty, value);
        }

        public static readonly BindableProperty PnTextLengthProperty = BindableProperty.Create(nameof(PnTextLength), typeof(int), typeof(InputTextT), 1000);
        public int PnTextLength
        {
            get => (int)GetValue(PnTextLengthProperty);
            set => SetValue(PnTextLengthProperty, value);
        }

        public static readonly BindableProperty PnMaxLengthProperty = BindableProperty.Create(nameof(PnMaxLength), typeof(int), typeof(InputTextT), 1000);
        public int PnMaxLength
        {
            get => (int)GetValue(PnMaxLengthProperty);
            set => SetValue(PnMaxLengthProperty, value);
        }

        public static readonly BindableProperty PnPasswordProperty = BindableProperty.Create(nameof(PnPassword), typeof(bool), typeof(InputTextT), false);
        public bool PnPassword
        {
            get => (bool)GetValue(PnPasswordProperty);
            set => SetValue(PnPasswordProperty, value);
        }

        public static readonly BindableProperty PnTextChangedCommandProperty = BindableProperty.Create(nameof(PnTextChangedCommand), typeof(ICommand), typeof(InputTextT), null);
        public ICommand PnTextChangedCommand
        {
            get { return (ICommand)GetValue(PnTextChangedCommandProperty); }
            set { SetValue(PnTextChangedCommandProperty, value); }
        }

        public static readonly BindableProperty PnEnterCommandProperty = BindableProperty.Create(nameof(PnEnterCommand), typeof(ICommand), typeof(InputTextT), null);
        public ICommand PnEnterCommand
        {
            get { return (ICommand)GetValue(PnEnterCommandProperty); }
            set { SetValue(PnEnterCommandProperty, value); }
        }

        public static readonly BindableProperty PnLeaveCommandProperty = BindableProperty.Create(nameof(PnLeaveCommand), typeof(ICommand), typeof(InputTextT), null);
        public ICommand PnLeaveCommand
        {
            get { return (ICommand)GetValue(PnLeaveCommandProperty); }
            set { SetValue(PnLeaveCommandProperty, value); }
        }


    }
}
