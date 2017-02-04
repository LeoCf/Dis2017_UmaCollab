using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace umaCollabApp
{
    [ContentProperty("Source")]

    // class derives from IMarkupExtension and fetches the star image for the rate
    public class StarExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }
            var imageSource = ImageSource.FromResource(Source);
            return imageSource;
        }
    }
}
