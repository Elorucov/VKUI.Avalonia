using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;
using System.Diagnostics;

namespace VKUI.Controls
{
    public sealed class Avatar : TemplatedControl
    {
        public Avatar() { }

        #region Properties

        public static readonly StyledProperty<IImage> ImageSourceProperty =
            AvaloniaProperty.Register<Avatar, IImage>(nameof(Image));

        public static readonly StyledProperty<string> InitialsProperty =
            AvaloniaProperty.Register<Avatar, string>(nameof(Initials));

        public IImage ImageSource
        {
            get => GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        public string Initials
        {
            get => GetValue(InitialsProperty);
            set => SetValue(InitialsProperty, value);
        }

        #endregion

        #region Template elements

        Image ImagePresenter;

        #endregion

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            ImagePresenter = e.NameScope.Find<Image>(nameof(ImagePresenter));
            ImagePresenter.SizeChanged += FixClip;
            ImagePresenter.Unloaded += OnUnloaded;

            SetImage();
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            ImagePresenter.SizeChanged -= FixClip;
            ImagePresenter.Unloaded -= OnUnloaded;
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);

            if (change.Property == ImageSourceProperty)
            {
                if (change.OldValue != change.NewValue) SetImage();
            }

            if (change.Property == BoundsProperty) SetImage();
        }

        private void FixClip(object sender, SizeChangedEventArgs e)
        {
            var geometry = (sender as Image).Clip as EllipseGeometry;

            geometry.Center = new Point(e.NewSize.Width / 2, e.NewSize.Height / 2);
            geometry.RadiusX = e.NewSize.Width / 2;
            geometry.RadiusY = e.NewSize.Height / 2;
        }

        private void SetImage()
        {
            if (ImagePresenter == null) return;
            double size = Math.Min(Bounds.Width, Bounds.Height);
            ImagePresenter.Width = size;
            ImagePresenter.Height = size;

            if (ImageSource == null)
            {
                ImagePresenter.Source = null;
                return;
            }

            try
            {
                ImagePresenter.Source = ImageSource;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error while drawing in Avatar! 0x{ex.HResult.ToString("x8")}");
            }
        }
    }
}