using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using PokemonWiki.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PokemonWiki.Views
{
    public sealed partial class PokemonDetailControl : UserControl
    {
        public PokemonDetailViewModel ListDetailsMenuItem
        {
            get { return GetValue(ListDetailsMenuItemProperty) as PokemonDetailViewModel; }
            set { SetValue(ListDetailsMenuItemProperty, value); }
        }

        public static readonly DependencyProperty ListDetailsMenuItemProperty = DependencyProperty.Register("ListDetailsMenuItem", typeof(PokemonDetailViewModel), typeof(PokemonDetailControl), new PropertyMetadata(null, OnListDetailsMenuItemPropertyChanged));
        public PokemonDetailControl()
        {
            InitializeComponent();
        }
        private static void OnListDetailsMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as PokemonDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
