using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground.Helpers
{
    public class LiveXamlHelper
    {
        public LiveXamlHelper()
        {
        }

		void Handle_Clicked(object sender, System.EventArgs e)
        {
            var xaml = "<StackLayout><Label Text=\"I am  modified Xamarin forms!\" HorizontalOptions=\"Center\" VerticalOptions=\"CenterAndExpand\" /></StackLayout>";

            PreviewXaml(xaml,null).Wait();

        }

		async Task PreviewXaml(string xaml,ContentPage contentPage)
        {
 
            try
            {
                if (string.IsNullOrEmpty(xaml))
                    return;

                string contentPageXaml = $"<?xml version='1.0' encoding='utf-8' ?><ContentPage xmlns='http://xamarin.com/schemas/2014/forms' xmlns:x='http://schemas.microsoft.com/winfx/2009/xaml' x:Class ='XamarinFormsStarterKit.XamlPage'>{xaml}</ContentPage>";

				await LiveXaml.UpdatePageFromXamlAsync(contentPage, contentPageXaml);
            }
            catch (Exception exception)
            {
                // Error 
                Debug.WriteLine(exception.Message);
				var xamlException = LiveXaml.GetXamlException(exception);
				await LiveXaml.UpdatePageFromXamlAsync(contentPage, xamlException);
            }

        }



    }
}
