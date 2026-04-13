using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using System;

namespace VKUI.Extensions
{
    public sealed class CornerRadiusEx
    {

        public static readonly AttachedProperty<double?> TopLeftProperty
            = AvaloniaProperty.RegisterAttached<TemplatedControl, double?>("TopLeft", typeof(CornerRadiusEx), defaultBindingMode: BindingMode.OneWay);

        public static readonly AttachedProperty<double?> TopRightProperty
            = AvaloniaProperty.RegisterAttached<TemplatedControl, double?>("TopRight", typeof(CornerRadiusEx), defaultBindingMode: BindingMode.OneWay);

        public static readonly AttachedProperty<double?> BottomRightProperty
            = AvaloniaProperty.RegisterAttached<TemplatedControl, double?>("BottomRight", typeof(CornerRadiusEx), defaultBindingMode: BindingMode.OneWay);

        public static readonly AttachedProperty<double?> BottomLeftProperty
            = AvaloniaProperty.RegisterAttached<TemplatedControl, double?>("BottomLeft", typeof(CornerRadiusEx), defaultBindingMode: BindingMode.OneWay);

        static CornerRadiusEx()
        {
            TopLeftProperty.Changed.Subscribe(OnTopLeftChanged);
            TopRightProperty.Changed.Subscribe(OnTopRightChanged);
            BottomRightProperty.Changed.Subscribe(OnBottomRightChanged);
            BottomLeftProperty.Changed.Subscribe(OnBottomLeftChanged);
        }

        public static void SetTopLeft(TemplatedControl element, double? value)
        {
            element.SetValue(TopLeftProperty, value);
        }

        public static double? GetTopLeft(TemplatedControl element)
        {
            return element.GetValue(TopLeftProperty);
        }

        public static void SetTopRight(TemplatedControl element, double? value)
        {
            element.SetValue(TopRightProperty, value);
        }

        public static double? GetTopRight(TemplatedControl element)
        {
            return element.GetValue(TopRightProperty);
        }

        public static void SetBottomRight(TemplatedControl element, double? value)
        {
            element.SetValue(BottomRightProperty, value);
        }

        public static double? GetBottomRight(TemplatedControl element)
        {
            return element.GetValue(BottomRightProperty);
        }

        public static void SetBottomLeft(TemplatedControl element, double? value)
        {
            element.SetValue(BottomLeftProperty, value);
        }

        public static double? GetBottomLeft(TemplatedControl element)
        {
            return element.GetValue(BottomLeftProperty);
        }

        private static void OnTopLeftChanged(AvaloniaPropertyChangedEventArgs<double?> e)
        {
            if (e.Sender is not TemplatedControl element) throw new ArgumentException();

            CornerRadius cr = element.CornerRadius;
            double value = e.NewValue.Value ?? cr.TopLeft;
            element.CornerRadius = new CornerRadius(value, cr.TopRight, cr.BottomRight, cr.BottomLeft);
        }

        private static void OnTopRightChanged(AvaloniaPropertyChangedEventArgs<double?> e)
        {
            if (e.Sender is not TemplatedControl element) throw new ArgumentException();

            CornerRadius cr = element.CornerRadius;
            double value = e.NewValue.Value ?? cr.TopRight;
            element.CornerRadius = new CornerRadius(cr.TopLeft, value, cr.BottomRight, cr.BottomLeft);
        }

        private static void OnBottomRightChanged(AvaloniaPropertyChangedEventArgs<double?> e)
        {
            if (e.Sender is not TemplatedControl element) throw new ArgumentException();

            CornerRadius cr = element.CornerRadius;
            double value = e.NewValue.Value ?? cr.BottomRight;
            element.CornerRadius = new CornerRadius(cr.TopLeft, cr.TopRight, value, cr.BottomLeft);
        }

        private static void OnBottomLeftChanged(AvaloniaPropertyChangedEventArgs<double?> e)
        {
            if (e.Sender is not TemplatedControl element) throw new ArgumentException();

            CornerRadius cr = element.CornerRadius;
            double value = e.NewValue.Value ?? cr.BottomLeft;
            element.CornerRadius = new CornerRadius(cr.TopLeft, cr.TopRight, cr.BottomRight, value);
        }
    }
}
