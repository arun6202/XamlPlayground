using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Xamarin.Forms;
using XamarinFormsStarterKit.UserInterfaceBuilder;
using XamarinFormsStarterKit.UserInterfaceBuilder.Preserver;
using XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground.DependencyService;
using static Xamarin.Forms.DependencyService;

namespace XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground
{
    public partial class Playground : ContentPage
	{
        public Playground()
		{
			InitializeComponent();

            ComponentBuilder.GenerateUIAttributes( new ComponentBuilderOptions{Content = Content } );

			var ISaveAndLoadUIAttributesService = Get<ISaveAndLoadUIAttributes>();

			//ISaveAndLoadUIAttributesService.LoadXMLAsync("XamlPlayground").Wait();
			ISaveAndLoadUIAttributesService.LoadXMLAsync("XamlPlayground");
  
		}
	}
}
 