using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using System;

namespace VKUI.Extensions
{
    public sealed class PaddingEx
    {

        public static readonly AttachedProperty<double?> LeftProperty
            = AvaloniaProperty.RegisterAttached<Decorator, double?>("Left", typeof(PaddingEx), defaultBindingMode: BindingMode.OneWay);

        public static readonly AttachedProperty<double?> TopProperty
            = AvaloniaProperty.RegisterAttached<Decorator, double?>("Top", typeof(PaddingEx), defaultBindingMode: BindingMode.OneWay);

        public static readonly AttachedProperty<double?> RightProperty
            = AvaloniaProperty.RegisterAttached<Decorator, double?>("Right", typeof(PaddingEx), defaultBindingMode: BindingMode.OneWay);

        public static readonly AttachedProperty<double?> BottomProperty
            = AvaloniaProperty.RegisterAttached<Decorator, double?>("Bottom", typeof(PaddingEx), defaultBindingMode: BindingMode.OneWay);

        static PaddingEx()
        {
            LeftProperty.Changed.Subscribe(OnLeftChanged);
            TopProperty.Changed.Subscribe(OnTopChanged);
            RightProperty.Changed.Subscribe(OnRightChanged);
            BottomProperty.Changed.Subscribe(OnBottomChanged);
        }

        public static void SetLeft(Decorator element, double? value)
        {
            element.SetValue(LeftProperty, value);
        }

        public static double? GetLeft(Decorator element)
        {
            return element.GetValue(LeftProperty);
        }

        public static void SetTop(Decorator element, double? value)
        {
            element.SetValue(TopProperty, value);
        }

        public static double? GetTop(Decorator element)
        {
            return element.GetValue(TopProperty);
        }

        public static void SetRight(Decorator element, double? value)
        {
            element.SetValue(RightProperty, value);
        }

        public static double? GetRight(Decorator element)
        {
            return element.GetValue(RightProperty);
        }

        public static void SetBottom(Decorator element, double? value)
        {
            element.SetValue(BottomProperty, value);
        }

        public static double? GetBottom(Decorator element)
        {
            return element.GetValue(BottomProperty);
        }

        private static void OnLeftChanged(AvaloniaPropertyChangedEventArgs<double?> e)
        {
            if (e.Sender is TemplatedControl tc) ChangeLeft(tc, e.NewValue.Value);
            else if (e.Sender is Decorator dc) ChangeLeft(dc, e.NewValue.Value);
            else throw new ArgumentException();
        }

        private static void ChangeLeft(TemplatedControl element, double? newValue)
        {
            Thickness padding = element.Padding;
            double value = newValue ?? padding.Left;
            element.Padding = new Thickness(value, padding.Top, padding.Right, padding.Bottom);
        }

        private static void ChangeLeft(Decorator element, double? newValue)
        {
            Thickness padding = element.Padding;
            double value = newValue ?? padding.Left;
            element.Padding = new Thickness(value, padding.Top, padding.Right, padding.Bottom);
        }

        private static void OnTopChanged(AvaloniaPropertyChangedEventArgs<double?> e)
        {
            if (e.Sender is TemplatedControl tc) ChangeTop(tc, e.NewValue.Value);
            else if (e.Sender is Decorator dc) ChangeTop(dc, e.NewValue.Value);
            else throw new ArgumentException();
        }

        private static void ChangeTop(TemplatedControl element, double? newValue)
        {
            Thickness padding = element.Padding;
            double value = newValue ?? padding.Top;
            element.Padding = new Thickness(padding.Left, value, padding.Right, padding.Bottom);
        }

        private static void ChangeTop(Decorator element, double? newValue)
        {
            Thickness padding = element.Padding;
            double value = newValue ?? padding.Top;
            element.Padding = new Thickness(padding.Left, value, padding.Right, padding.Bottom);
        }

        private static void OnRightChanged(AvaloniaPropertyChangedEventArgs<double?> e)
        {
            if (e.Sender is TemplatedControl tc) ChangeRight(tc, e.NewValue.Value);
            else if (e.Sender is Decorator dc) ChangeRight(dc, e.NewValue.Value);
            else throw new ArgumentException();
        }

        private static void ChangeRight(TemplatedControl element, double? newValue)
        {
            Thickness padding = element.Padding;
            double value = newValue ?? padding.Right;
            element.Padding = new Thickness(padding.Left, padding.Top, value, padding.Bottom);
        }

        private static void ChangeRight(Decorator element, double? newValue)
        {
            Thickness padding = element.Padding;
            double value = newValue ?? padding.Right;
            element.Padding = new Thickness(padding.Left, padding.Top, value, padding.Bottom);
        }

        private static void OnBottomChanged(AvaloniaPropertyChangedEventArgs<double?> e)
        {
            if (e.Sender is TemplatedControl tc) ChangeBottom(tc, e.NewValue.Value);
            else if (e.Sender is Decorator dc) ChangeBottom(dc, e.NewValue.Value);
            else throw new ArgumentException();
        }

        private static void ChangeBottom(TemplatedControl element, double? newValue)
        {
            Thickness padding = element.Padding;
            double value = newValue ?? padding.Bottom;
            element.Padding = new Thickness(padding.Left, padding.Top, padding.Right, value);
        }

        private static void ChangeBottom(Decorator element, double? newValue)
        {
            Thickness padding = element.Padding;
            double value = newValue ?? padding.Bottom;
            element.Padding = new Thickness(padding.Left, padding.Top, padding.Right, value);
        }
    }
}
