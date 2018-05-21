using Xamarin.Forms;

namespace XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground
{
	public partial class Playground : ContentPage
	{

		public Playground()
		{
			InitializeComponent();

			ComponentBuilder.Init(new ComponentBuilderOptions
			{
				Content = Content,
				PreserveSession = true,
				SuppressAllBackGroundColor = false

			});


		}

	}
}