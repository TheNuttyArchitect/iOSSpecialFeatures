﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using iOSSpecialFeatures.Models;
using iOSSpecialFeatures.ViewModels;

namespace iOSSpecialFeatures.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            viewModel = new ItemDetailViewModel(null);
            BindingContext = viewModel;
        }
    }
}