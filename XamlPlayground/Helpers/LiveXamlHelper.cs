using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground.Helpers
{
	public static class LiveXamlHelper
	{
		public static async Task PreviewXaml(string xaml, ContentPage contentPage)
		{

			try
			{
				if (string.IsNullOrEmpty(xaml))
					return;

				await LiveXaml.UpdatePageFromXamlAsync(contentPage, xaml);
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
