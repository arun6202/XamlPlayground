using Plugin.Toasts;
using Xamarin.Forms;

namespace XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground
{
	public partial class Playground : ContentPage
	{
		void Handle_Clicked(object sender, System.EventArgs e)
		{
			ShowToast(new NotificationOptions()
            {
                Title = "The Title Line",
                Description = "The Description Content",
                IsClickable = true,
                WindowsOptions = new WindowsOptions() { LogoUri = "icon.png" },
                ClearFromHistory = false,
                AllowTapInNotificationCenter = false,
                AndroidOptions = new AndroidOptions()
                {
                    HexColor = "#F99D1C",
                    ForceOpenAppOnNotificationTap = true
                }
            });

 		}
		void ShowToast(INotificationOptions options)
        {
            var notificator = DependencyService.Get<IToastNotificator>();

            // await notificator.Notify(options);

            notificator.Notify((INotificationResult result) =>
            {
                System.Diagnostics.Debug.WriteLine("Notification [" + result.Id + "] Result Action: " + result.Action);
            }, options);
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