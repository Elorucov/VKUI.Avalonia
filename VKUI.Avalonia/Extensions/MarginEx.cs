using Avalonia;
using Avalonia.Data;
using Avalonia.Layout;
using System;

namespace VKUI.Extensions
{
    public sealed class MarginEx
    {

        public static readonly AttachedProperty<double?> LeftProperty
            = AvaloniaProperty.RegisterAttached<Layoutable, double?>("Left", typeof(MarginEx), defaultBindingMode: BindingMode.OneWay);

        public static readonly AttachedProperty<double?> TopProperty
            = AvaloniaProperty.RegisterAttached<Layoutable, double?>("Top", typeof(MarginEx), defaultBindingMode: BindingMode.OneWay);

        public static readonly AttachedProperty<double?> RightProperty
            = AvaloniaProperty.RegisterAttached<Layoutable, double?>("Right", typeof(MarginEx), defaultBindingMode: BindingMode.OneWay);

        public static readonly AttachedProperty<double?> BottomProperty
            = AvaloniaProperty.RegisterAttached<Layoutable, double?>("Bottom", typeof(MarginEx), defaultBindingMode: BindingMode.OneWay);

        static MarginEx()
        {
            LeftProperty.Changed.Subscribe(OnLeftChanged);
            TopProperty.Changed.Subscribe(OnTopChanged);
            RightProperty.Changed.Subscribe(OnRightChanged);
            BottomProperty.Changed.Subscribe(OnBottomChanged);
        }

        public static void SetLeft(Layoutable element, double? value)
        {
            element.SetValue(LeftProperty, value);
        }

        public static double? GetLeft(Layoutable element)
        {
            return element.GetValue(LeftProperty);
        }

        public static void SetTop(Layoutable element, double? value)
        {
            element.SetValue(TopProperty, value);
        }

        public static double? GetTop(Layoutable element)
        {
            return element.GetValue(TopProperty);
        }

        public static void SetRight(Layoutable element, double? value)
        {
            element.SetValue(RightProperty, value);
        }

        public static double? GetRight(Layoutable element)
        {
            return element.GetValue(RightProperty);
        }

        public static void SetBottom(Layoutable element, double? value)
        {
            element.SetValue(BottomProperty, value);
        }

        public static double? GetBottom(Layoutable element)
        {
            return element.GetValue(BottomProperty);
        }

        private static void OnLeftChanged(AvaloniaPropertyChangedEventArgs<double?> e)
        {
            if (e.Sender is not Layoutable element) throw new ArgumentException();

            Thickness margin = element.Margin;
            double value = e.NewValue.Value ?? margin.Left;
            element.Margin = new Thickness(value, margin.Top, margin.Right, margin.Bottom);
        }

        private static void OnTopChanged(AvaloniaPropertyChangedEventArgs<double?> e)
        {
            if (e.Sender is not Layoutable element) throw new ArgumentException();

            Thickness margin = element.Margin;
            double value = e.NewValue.Value ?? margin.Top;
            element.Margin = new Thickness(margin.Left, value, margin.Right, margin.Bottom);
        }

        private static void OnRightChanged(AvaloniaPropertyChangedEventArgs<double?> e)
        {
            if (e.Sender is not Layoutable element) throw new ArgumentException();

            Thickness margin = element.Margin;
            double value = e.NewValue.Value ?? margin.Right;
            element.Margin = new Thickness(margin.Left, margin.Top, value, margin.Bottom);
        }

        private static void OnBottomChanged(AvaloniaPropertyChangedEventArgs<double?> e)
        {
            if (e.Sender is not Layoutable element) throw new ArgumentException();

            Thickness margin = element.Margin;
            double value = e.NewValue.Value ?? margin.Bottom;
            element.Margin = new Thickness(margin.Left, margin.Top, margin.Right, value);
        }
    }
}
