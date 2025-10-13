using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace AvaloniaApplication3.Controls;

public class iconButton : Button
{
  public static readonly StyledProperty<string> IconTextProperty = AvaloniaProperty.Register<iconButton, string>(nameof(IconText));

  public string IconText
  {
    get => GetValue(IconTextProperty);
    set => SetValue(IconTextProperty, value);
  }
}