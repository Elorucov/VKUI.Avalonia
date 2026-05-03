using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace VKUI.Controls
{
    public enum SpinnerSize
    {
        Small,
        Medium,
        Large,
        ExtraLarge
    }

    public sealed class Spinner : TemplatedControl
    {
        public Spinner() { }

        #region Template elements

        VKIcon Icon;

        #endregion

        #region Properties

        public static readonly StyledProperty<SpinnerSize> SizeProperty =
            AvaloniaProperty.Register<VKIcon, SpinnerSize>(nameof(Size));

        public SpinnerSize Size
        {
            get => GetValue(SizeProperty);
            set => SetValue(SizeProperty, value);
        }

        #endregion

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            Icon = e.NameScope.Find<VKIcon>(nameof(Icon));

            SetupSpinner(Size);
            PseudoClasses.Set(":animating", IsVisible);

            PropertyChanged += Spinner_PropertyChanged;
        }

        double oldSize = 0;

        private void Spinner_PropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property == SizeProperty)
            {
                SetupSpinner(Size);
            }
            else if (e.Property == IsVisibleProperty)
            {
                PseudoClasses.Set(":animating", IsVisible);
            }
        }

        private void SetupSpinner(SpinnerSize size)
        {
            Icon.Id = size switch
            {
                SpinnerSize.Small => VKIconNames.Icon16Spinner,
                SpinnerSize.Medium => VKIconNames.Icon24Spinner,
                SpinnerSize.Large => VKIconNames.Icon32Spinner,
                SpinnerSize.ExtraLarge => VKIconNames.Icon44Spinner,
                _ => VKIconNames.Icon16Spinner
            };
        }
    }
}