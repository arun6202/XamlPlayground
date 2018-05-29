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
                PreserveSession = false,
                SuppressAllBackGroundColor = false,
				EnableRepeater = false,
                EnableRestorationOfUIAttributes = false,
                EnableTapGestureRecognizers = true,
                EnableUIAttributesGeneration = false,
				CompressLayout=false

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
