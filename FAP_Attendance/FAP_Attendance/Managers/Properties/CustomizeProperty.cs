using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace FAP_Attendance.Managers.Properties
{
    public static class CustomizeProperty
    {
        #region Color Hover

        public static SolidColorBrush GetColorHover(DependencyObject obj)
        {
            return (SolidColorBrush)obj.GetValue(ColorHoverProperty);
        }

        public static void SetColorHover(DependencyObject obj, SolidColorBrush value)
        {
            obj.SetValue(ColorHoverProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorHoverProperty =
            DependencyProperty.RegisterAttached("ColorHover", typeof(SolidColorBrush), typeof(CustomizeProperty), new PropertyMetadata(default(SolidColorBrush)));

        #endregion Color Hover

        #region Color Press

        public static SolidColorBrush GetColorPress(DependencyObject obj)
        {
            return (SolidColorBrush)obj.GetValue(ColorPressProperty);
        }

        public static void SetColorPress(DependencyObject obj, SolidColorBrush value)
        {
            obj.SetValue(ColorPressProperty, value);
        }

        // Using a DependencyProperty as the backing store for ColorPress.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorPressProperty =
            DependencyProperty.RegisterAttached("ColorPress", typeof(SolidColorBrush), typeof(CustomizeProperty), new PropertyMetadata(default(SolidColorBrush)));

        #endregion Color Press

        #region Color Disable

        public static SolidColorBrush GetColorDisable(DependencyObject obj)
        {
            return (SolidColorBrush)obj.GetValue(ColorDisableProperty);
        }

        public static void SetColorDisable(DependencyObject obj, SolidColorBrush value)
        {
            obj.SetValue(ColorDisableProperty, value);
        }

        // Using a DependencyProperty as the backing store for ColorDisable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorDisableProperty =
            DependencyProperty.RegisterAttached("ColorDisable", typeof(SolidColorBrush), typeof(CustomizeProperty), new PropertyMetadata(default(SolidColorBrush)));

        #endregion Color Disable

        #region BorderBrush

        public static SolidColorBrush GetBorderBrushDisable(DependencyObject obj)
        {
            return (SolidColorBrush)obj.GetValue(BorderBrushDisableProperty);
        }

        public static void SetBorderBrushDisable(DependencyObject obj, SolidColorBrush value)
        {
            obj.SetValue(BorderBrushDisableProperty, value);
        }

        // Using a DependencyProperty as the backing store for ColorDisable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderBrushDisableProperty =
            DependencyProperty.RegisterAttached("BorderBrushDisable", typeof(SolidColorBrush), typeof(CustomizeProperty), new PropertyMetadata(default(SolidColorBrush)));

        #endregion BorderBrush

        #region Icon

        public static ImageSource GetIcon(DependencyObject obj)
        {
            return (ImageSource)obj.GetValue(IconProperty);
        }

        public static void SetIcon(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(IconProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(ImageSource), typeof(CustomizeProperty));

        #endregion Icon

        #region icon height

        public static int GetIconHeight(DependencyObject obj)
        {
            return (int)obj.GetValue(IconHeightProperty);
        }

        public static void SetIconHeight(DependencyObject obj, int value)
        {
            obj.SetValue(IconHeightProperty, value);
        }

        // Using a DependencyProperty as the backing store for I.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconHeightProperty =
            DependencyProperty.RegisterAttached("IconHeight", typeof(int), typeof(CustomizeProperty), new PropertyMetadata(0));

        #endregion icon height

        #region icon width

        public static int GetIconWidth(DependencyObject obj)
        {
            return (int)obj.GetValue(IconWidthProperty);
        }

        public static void SetIconWidth(DependencyObject obj, int value)
        {
            obj.SetValue(IconWidthProperty, value);
        }

        // Using a DependencyProperty as the backing store for IconWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconWidthProperty =
            DependencyProperty.RegisterAttached("IconWidth", typeof(int), typeof(CustomizeProperty), new PropertyMetadata(0));

        #endregion icon width
    }
}
