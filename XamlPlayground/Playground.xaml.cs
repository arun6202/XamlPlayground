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

namespace XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground
{
    public partial class Playground : ContentPage
	{
        public Playground()
		{
			InitializeComponent();
            ComponentBuilder.GenerateUIAttributes( new ComponentBuilderOptions{Content = (Layout)Content } );

 
            var preserveUIAttributes = ComponentBuilder.PreserveUIAttributes;


             preserveUIAttributes = new Preserve
            {
                Image = new List<Preserver.Image> { new Preserver.Image { Height = 5.6 } }
            };

            var mySerializer = new XmlSerializer(typeof(Preserve));

            mySerializer.Serialize(preserveUIAttributes,);



            XmlSerializer xsSubmit = new XmlSerializer(typeof(Preserve));
            var xml = "";

            using (var sww = new System.IO.StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, preserveUIAttributes);
                    xml = sww.ToString(); // Your XML
                }
            }
		}
	}
}
 