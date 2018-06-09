using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using XamarinFormsStarterKit.UserInterfaceBuilder.Models;

namespace XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground.Helpers
{
	public static class XamlPlaygroundSyncConsume
	{
		private const string Url = "http://localhost:6202/XamlPlaygroundSync";
		private static HubConnection _connection;

		static XamlPayload XamlPayload = new XamlPayload();

		internal static async Task Sync()
		{
			await StartConnectionAsync();

			_connection.On<string, XamlPayload>("XamlPlaygroundSync", async (name, message) =>
			{

				if (XamlPayload.XAML == null)
				{
					await LiveXamlHelper.PreviewXaml(message.XAML,App.ContentPageSync);
				}

				bool areXamlSame = XamlPayload.CompareTo(message) == 0;
				if (!areXamlSame)
				{
					XamlPayload = message;
					await LiveXamlHelper.PreviewXaml(message.XAML, App.ContentPageSync);
				}
			});

		}


		public static async Task StartConnectionAsync()
		{
			_connection = new HubConnectionBuilder()
				.WithUrl(Url)
				.Build();

			await _connection.StartAsync();
		}

		public static async Task DisposeAsync()
		{
			await _connection.DisposeAsync();
		}
	}
}
