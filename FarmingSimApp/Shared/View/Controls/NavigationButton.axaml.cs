using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace FarmingSimApp.Shared.View.Controls;

public class NavigationButton : RadioButton
{
    public static readonly StyledProperty<IBrush> HoverBrushProperty =
        AvaloniaProperty.Register<NavigationButton, IBrush>(
            nameof(HoverBrush), new SolidColorBrush(Colors.Transparent));

    public IBrush HoverBrush
    {
        get => GetValue(HoverBrushProperty);
        set => SetValue(HoverBrushProperty, value);
    }
}