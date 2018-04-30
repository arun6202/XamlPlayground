using System;
using System.Threading.Tasks;

namespace XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground.DependencyService
{
    public interface ISaveAndLoadUIAttributes
    {
		
		 Task LoadXMLAsync(string filename);
		void SaveXMLAsync(string filename);
       
    }
}
