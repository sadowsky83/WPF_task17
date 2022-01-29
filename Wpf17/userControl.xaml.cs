using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_task17
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : UserControl
    {
        public static DependencyProperty ColorProperty;
        public static DependencyProperty RedProperty;
        public static DependencyProperty GreenProperty;
        public static DependencyProperty BlueProperty;


        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }
        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }
        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }

        static User()
        {
            ColorProperty = DependencyProperty.Register(nameof(Color),
                typeof(Color), typeof(User),
                new FrameworkPropertyMetadata(Colors.Black,
                new PropertyChangedCallback(OnColorChanged)));
            RedProperty = DependencyProperty.Register(nameof(Red),
                typeof(byte), typeof(User),
                new FrameworkPropertyMetadata
                (new PropertyChangedCallback(OnColorRGBChanged)));
            GreenProperty = DependencyProperty.Register(nameof(Green),
                typeof(byte), typeof(User),
                new FrameworkPropertyMetadata
                (new PropertyChangedCallback(OnColorRGBChanged)));
            BlueProperty = DependencyProperty.Register(nameof(Blue),
                typeof(byte), typeof(User),
                 new FrameworkPropertyMetadata
                 (new PropertyChangedCallback(OnColorRGBChanged)));
        }

        private static void OnColorRGBChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            User colorPicker = (User)d;
            Color color = colorPicker.Color;
            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;

            colorPicker.Color = color;
        }

        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            User colorpicker = (User)d;
            colorpicker.Red = newColor.R;
            colorpicker.Green = newColor.G;
            colorpicker.Blue = newColor.B;

        }
        public static readonly RoutedEvent ColorChangedEvent = EventManager.RegisterRoutedEvent
            ("ColorChanged", RoutingStrategy.Bubble,
             typeof(RoutedPropertyChangedEventHandler<Color>),
             typeof(User));

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }
        public User()
        {
            InitializeComponent();
        }
    }
}
