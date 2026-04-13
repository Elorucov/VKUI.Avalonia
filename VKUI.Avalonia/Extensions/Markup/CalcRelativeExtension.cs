using Avalonia.Markup.Xaml;
using System;

namespace VKUI.Extensions.Markup
{
    public sealed class CalcRelativeExtension : MarkupExtension
    {
        public double Parent { get; set; }
        public double Child { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return (Parent - Child) / 2;
        }
    }
}
