using System;
using System.Collections.Generic;

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
				SuppressAllBackGroundColor = false,
				EnableRepeater = true,
				EnableRestorationOfUIAttributes = true,
				EnableTapGestureRecognizers = true,
				EnableUIAttributesGeneration = true,
				CompressLayout = false,
				Apply = true

			});


		}

		public Playground(ComponentBuilderOptions options)
		{
			InitializeComponent();

			options.Content = Content;

			ComponentBuilder.Init(options);

		}
	}
}
