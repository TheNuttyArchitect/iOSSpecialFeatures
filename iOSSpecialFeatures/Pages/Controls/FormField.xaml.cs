using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace iOSSpecialFeatures.Pages.Controls
{
    public partial class FormField : ContentView, INotifyPropertyChanged
    {
        public FormField()
        {
            InitializeComponent();
            label.Text = Label;
            isRequired.IsVisible = IsRequired;
            value.Text = Value;
            value.TextChanged += OnValueChanged;
        }


        public static readonly BindableProperty LabelProperty = 
            BindableProperty.Create(nameof(Label), typeof(string), typeof(FormField), default(string), BindingMode.OneWay);

        public static readonly BindableProperty IsRequiredProperty = 
            BindableProperty.Create(nameof(IsRequired), typeof(bool), typeof(FormField), false, BindingMode.OneWay);

        public static readonly BindableProperty ValueProperty = 
            BindableProperty.Create(nameof(Value), typeof(string), typeof(FormField), null, BindingMode.TwoWay);

        public string Label 
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public bool IsRequired
        {
            get => (bool)GetValue(IsRequiredProperty);
            set => SetValue(IsRequiredProperty, value);
        }

        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        private void OnValueChanged(object sender, TextChangedEventArgs args)
        {
            Value = args.NewTextValue;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if(propertyName == LabelProperty.PropertyName)
                label.Text = Label;
            else if (propertyName ==  IsRequiredProperty.PropertyName)
                isRequired.IsVisible = IsRequired;
            else if (propertyName == ValueProperty.PropertyName)
                value.Text = Value;
        }
    }
}
