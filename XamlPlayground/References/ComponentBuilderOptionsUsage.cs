using System;
namespace XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground.References
{
    public class ComponentBuilderOptionsUsage
    {
        public ComponentBuilderOptionsUsage()
        {
			ComponentBuilder.Init(new ComponentBuilderOptions
            {
                // Content = Content,
                PreserveSession = false,
                SuppressAllBackGroundColor = false,
                EnableRepeater = false,
                EnableRestorationOfUIAttributes = false,
                EnableTapGestureRecognizers = false,
                EnableUIAttributesGeneration = false

            });
        }
    }
}
