using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;
namespace SMJ.WPF {
    enum Horiz {
        Left, Middle, Right
    }
    enum Vert {
        Top, Middle, Bottom
    }

    public class CustomWindowBorder : UserControl {
        Window parentWindow;
        public CustomWindowBorder() {
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            this.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            this.Visibility = System.Windows.Visibility.Visible;
            Shadow.Fill = new SolidColorBrush(Colors.Black);
            Shadow.RadiusX = 5;
            Shadow.RadiusY = 5;
            Shadow.Margin = new Thickness(5,5,-5,-5);
        }
        Rectangle Background = new Rectangle();
        Rectangle WhitePart = new Rectangle();
        Grid Maincontent = new Grid();

        public Rectangle Shadow = new Rectangle();

        public UIElementCollection BorderContent {
            get {
                return Maincontent.Children;
            }
            set {
                foreach (UIElement ele in value) {
                    Maincontent.Children.Add(ele);
                }
            }
        }

        private Grid _btmItems = new Grid();
        public UIElementCollection BottomGrid {
            get {
                return _btmItems.Children;
            }
            set {
                foreach (UIElement ele in value) {
                    _btmItems.Children.Add(ele);
                }
            }
        }
        DropShadowEffect shadow = new DropShadowEffect();
        protected override void OnInitialized(EventArgs e) {
            base.OnInitialized(e);
            parentWindow = Window.GetWindow(this);
            if (parentWindow != null) {
                parentWindow.WindowStyle = WindowStyle.None;
                parentWindow.AllowsTransparency = true;
                parentWindow.Background = new SolidColorBrush(Colors.Transparent);
                if(parentWindow.ResizeMode== ResizeMode.CanResize)
                    parentWindow.ResizeMode = ResizeMode.CanResizeWithGrip;
                hwndSource = System.Windows.PresentationSource.FromVisual(parentWindow) as System.Windows.Interop.HwndSource;
                parentWindow.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(superGrid_MouseLeftButtonDown);
            }
            shadow.Direction = 320;
            shadow.Color = Colors.Black;
            shadow.ShadowDepth = 10;
            shadow.Opacity = 0.5;
            shadow.BlurRadius = 9;

//            Background.Effect = shadow;
  //          Background.Margin =                new Thickness(0, 0, 10, 10);
            Grid.SetColumn(Shadow, 0);
            Grid.SetRow(Shadow, 0);
            Grid.SetColumnSpan(Shadow, 3);
            Grid.SetRowSpan(Shadow, 3);

            Color black = Color.FromArgb(255, 0, 0, 0);
            Color semi = Color.FromArgb(200, 0, 0, 0);
            GradientStopCollection stops = new GradientStopCollection();
            stops.Add(new GradientStop(semi, 0));
            stops.Add(new GradientStop(black, 0.5));
            stops.Add(new GradientStop(semi, 1));
            Background.Fill = new LinearGradientBrush(stops, 90.0);
            Background.RadiusX = 3;
            Background.RadiusY = 3;


            stops = new GradientStopCollection();
            stops.Add(new GradientStop(Colors.White, 0));
            stops.Add(new GradientStop(Colors.WhiteSmoke, 0.5));
            stops.Add(new GradientStop(Colors.White, 1));

            WhitePart.Fill = new LinearGradientBrush(stops, 90.0);
            WhitePart.RadiusX = 3;
            WhitePart.RadiusY = 3;


            Grid superGrid = new Grid();

//            superGrid.Children.Add(Shadow);

            superGrid.ClipToBounds = true;
            superGrid.Children.Add(Background);


            Grid.SetColumn(WhitePart, 1);
            Grid.SetRow(WhitePart, 1);
            superGrid.Children.Add(WhitePart);


            superGrid.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            superGrid.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            ColumnDefinition column;

            column = new ColumnDefinition();
            column.Width = new GridLength(1);
            superGrid.ColumnDefinitions.Add(column);

            column = new ColumnDefinition();
            column.Width = new GridLength(1, GridUnitType.Star);
            superGrid.ColumnDefinitions.Add(column);

            column = new ColumnDefinition();
            column.Width = new GridLength(1);
            superGrid.ColumnDefinitions.Add(column);

//            column = new ColumnDefinition();
 //           column.Width = new GridLength(10, GridUnitType.Pixel);
  //          superGrid.ColumnDefinitions.Add(column);

            RowDefinition row;

            row = new RowDefinition();
            row.Height = new GridLength(5);
            row.MinHeight = 5;
            superGrid.RowDefinitions.Add(row);

            row = new RowDefinition();
            row.Height = new GridLength(1, GridUnitType.Star);
            superGrid.RowDefinitions.Add(row);

            row = new RowDefinition();
            row.Height = new GridLength(100, GridUnitType.Auto);
            row.MinHeight = 5;
            superGrid.RowDefinitions.Add(row);

//            row = new RowDefinition();
  //          row.Height = new GridLength(10, GridUnitType.Pixel);
    //        row.MinHeight = 5;
      //      superGrid.RowDefinitions.Add(row);

            Queue<Cursor> cursors = new Queue<Cursor>();
            cursors.Enqueue(Cursors.SizeNWSE);
            cursors.Enqueue(Cursors.SizeNS);
            cursors.Enqueue(Cursors.SizeNESW);
            cursors.Enqueue(Cursors.SizeWE);
            cursors.Enqueue(Cursors.SizeWE);
            cursors.Enqueue(Cursors.SizeNESW);
            cursors.Enqueue(Cursors.SizeNS);
            cursors.Enqueue(Cursors.SizeNWSE);

            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (i == 1 && j == 1)
                        continue;
                    Rectangle rect = new Rectangle();
                    rect.Fill = new SolidColorBrush(Colors.Red);
                    rect.Opacity = 0;
                    rect.MouseLeftButtonDown += new MouseButtonEventHandler(rect_MouseLeftButtonDown);

                    rect.Cursor = cursors.Dequeue();
                    Canvas.SetZIndex(rect, 99);
                    Grid.SetColumn(rect, j);
                    Grid.SetRow(rect, i);

                    //superGrid.Children.Add(rect);
                }
            }

            Grid.SetColumn(Background, 0);
            Grid.SetColumnSpan(Background, 4);
            Grid.SetRow(Background, 0);
            Grid.SetRowSpan(Background, 7);

            Grid.SetRow(_btmItems, 2);
            Grid.SetColumn(_btmItems, 1);
            superGrid.Children.Add(_btmItems);

            if(parentWindow!=null&&parentWindow.ResizeMode == ResizeMode.CanResizeWithGrip)
                _btmItems.Margin = new Thickness(0, 0, 15, 0);

            Grid.SetColumn(Maincontent, 1);
            Grid.SetRow(Maincontent, 1);
            superGrid.Children.Add(Maincontent);

            base.Content = superGrid;


        }

        void rect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            int r = Grid.GetRow(sender as UIElement);
            int c = Grid.GetColumn(sender as UIElement);
            int num = 0;
            switch ((Horiz)c) {
                case Horiz.Left:
                    num += 1;
                    break;
                case Horiz.Right:
                    num += 2;
                    break;
            }
            switch ((Vert)r) {
                case Vert.Top:
                    num += 3;
                    break;
                case Vert.Bottom:
                    num += 8;
                    break;
            }

            if (num == 0)
                return;

//            ResizeWindow((ResizeDirection)num);
        }

        private void InitializeWindowSource(object sender, EventArgs e) {
        }

        public enum ResizeDirection {
            Left = 1,
            Right = 2,
            Top = 3,
            TopLeft = 4,
            TopRight = 5,
            Bottom = 6,
            BottomLeft = 7,
            BottomRight = 8,
        }
        private const int WM_SYSCOMMAND = 274;
        private HwndSource hwndSource;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private void ResizeWindow(ResizeDirection direction) {
            SendMessage(hwndSource.Handle, WM_SYSCOMMAND, (IntPtr)(61440 + direction), IntPtr.Zero);
        }

        void superGrid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            parentWindow.DragMove();
        }

    }
}
