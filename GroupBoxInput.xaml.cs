using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace SMJ.WPF {
    /// <summary>
    /// Interaction logic for GroupBoxInput.xaml
    /// </summary>
    public partial class GroupBoxInput : UserControl {
        public GroupBoxInput() {
            InitializeComponent();
        }

        public bool IsReadOnly {
            get {
                return input.IsReadOnly;
            }
            set {
                input.IsReadOnly = value;
            }
        }

        public bool HasButton {
            get {
                return button.Visibility == System.Windows.Visibility.Visible;
            }
            set {
                if (value) {
                    button.Visibility = System.Windows.Visibility.Visible;
                } else {
                    button.Visibility = System.Windows.Visibility.Collapsed;

                }
            }
        }

        public SuperButton Button {
            get {
                return button;
            }
        }
        public string ButtonText {
            get {
                return button.Text;
            }
            set {
                button.Text = value;
            }
        }
        public ImageSource ButtonImageSource {
            get {
                return button.ImageSource;
            }
            set {
                button.ImageSource = value;
            }
        }
        public Thickness ButtonImageMargin {
            get {
                return button.ImageMargin;
            }
            set {
                button.ImageMargin = value;
            }
        }

        public event TextChangedEventHandler TextChanged {
            add { input.TextChanged += value; }
            remove { input.TextChanged -= value; }
        }

        public event RoutedEventHandler ButtonClick {
            add { button.Click += value; }
            remove { button.Click -= value; }
        }

        public string Value {
            get {
                return input.Text;
            }
            set {
                input.Text = value;
            }
        }

        public object Header {
            get {
                return box.Header;
            }
            set {
                box.Header = value;
            }
        }

    }
}
