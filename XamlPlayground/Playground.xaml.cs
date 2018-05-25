using Plugin.Toasts;
using Xamarin.Forms;

namespace XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground
{
	public partial class Playground : ContentPage
	{
		void Handle_Clicked(object sender, System.EventArgs e)
		{
             

 		}
         
		public Playground()
		{
			InitializeComponent();
            
			ComponentBuilder.Init(new ComponentBuilderOptions
			{
				Content = Content,
				PreserveSession = false,
				SuppressAllBackGroundColor = true

			});


		}

	}
}