using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using XamarinFormsStarterKit.UserInterfaceBuilder.Preserver;
using XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground.DependencyService;
using XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground.iOS.DependencyService;

[assembly: Xamarin.Forms.Dependency(typeof(SaveAndLoadUIAttributes_iOS))]
namespace XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground.iOS.DependencyService
{
	public class SaveAndLoadUIAttributes_iOS : ISaveAndLoadUIAttributes
    {
        public bool OverrideFile
		{
			get;
			set;
		}

		public SaveAndLoadUIAttributes_iOS()
		{
			OverrideFile = true;
		}

		public async Task LoadXMLAsync(string filename)
		{
			string path = CreatePathToFile(filename);

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Preserve));
            
			using (StreamWriter sw = File.CreateText(path))
			{
				using (var sww = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sww))
                    {
						xmlSerializer.Serialize(writer, ComponentBuilder.PreserveUIAttributes);
						await sw.WriteAsync(sww.ToString()); 
                    }
                }

			}
		}

		public void SaveXMLAsync(string filename)
		{
			ComponentBuilder.PreserveUIAttributes  = null;

			var path = CreatePathToFile( filename);

			XmlSerializer deserializer = new XmlSerializer(typeof(Preserve));
			TextReader reader = new StreamReader(path);
			var preserve = (Preserve)deserializer.Deserialize(reader);
			ComponentBuilder.PreserveUIAttributes = preserve;
            reader.Close();

            
		}

		string CreatePathToFile(string filename)
        {
            var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(docsPath, filename);
        }
    }
}
