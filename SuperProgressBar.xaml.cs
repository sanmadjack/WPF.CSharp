using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Effects;
using System.Windows.Media.Animation;
namespace SMJ.WPF {
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    /// 
    public enum SuperProgressBarState {
        Error, Wait, Normal
    }
    public partial class SuperProgressBar : UserControl {
        public SuperProgressBar() {
            InitializeComponent();
            BlurEffect blur = new BlurEffect();
            blur.Radius = 5;
            //statusBG.Effect = blur;
            NormalBrush = progress.Foreground;
        }

        public double Value {
            get {
                return progress.Value;
            }
            set {
                progress.Value = value;
            }
        }

        public string Message {
            get {
                return status.Content.ToString();
            }
            set {
                status.Content = value;
                //statusBG.Content = value;
            }
        }
        public bool StatusVisible {
            get {
                return status.IsVisible;
            }
            set {
                if (value) {
                    status.Visibility = System.Windows.Visibility.Visible;
                    //statusBG.Visibility = System.Windows.Visibility.Visible;
                } else {
                    status.Visibility = System.Windows.Visibility.Collapsed;
                   // statusBG.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
        }


        public double Max {
            get {
                return progress.Maximum;
            }
            set {
                progress.Maximum = value;
            }
        }
        public bool IsIndeterminate {
            get {
                return progress.IsIndeterminate;
            }
            set {
                progress.IsIndeterminate = value;
                State = State;
            }
        }

        public SolidColorBrush progressBrush = new SolidColorBrush();

        private SuperProgressBarState _state = SuperProgressBarState.Normal;


        private static Brush NormalBrush;
        private static Brush ErrorBrush = new SolidColorBrush(Colors.Red);
        private static Brush WaitBrush = new SolidColorBrush(Colors.Yellow);

        public SuperProgressBarState State {
            get {
                return _state;
            }
            set {
                _state = value;
                Brush to_use;
                switch(value) {
                    case SuperProgressBarState.Wait:
                        to_use = WaitBrush;
                        break;
                    case SuperProgressBarState.Normal:
                        to_use = NormalBrush;
                        break;
                    case SuperProgressBarState.Error:
                        to_use = ErrorBrush;
                        break;
                    default:
                        throw new NotSupportedException(value.ToString());
                }
                progress.Foreground = to_use;

            }
        }

    }


}
