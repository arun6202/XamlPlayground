using FFImageLoading.Forms;
using FFImageLoading.Forms.WinUWP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            var assembliesToInclude = new List<Assembly>()
{
    typeof(CachedImage).GetTypeInfo().Assembly,
    typeof(CachedImageRenderer).GetTypeInfo().Assembly
};
            CachedImageRenderer.Init();

            LoadApplication(new XamlPlayground.App());
        }
    }
}
