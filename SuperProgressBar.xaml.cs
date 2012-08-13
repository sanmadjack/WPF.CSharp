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
            statusBG.Effect = blur;
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
                statusBG.Content = value;
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
            }
        }

        public SolidColorBrush progressBrush = new SolidColorBrush();

        private SuperProgressBarState _state = SuperProgressBarState.Normal;

        private Color ErrorColor = Color.FromRgb(0xEF, 0x29, 0x29);
        private Color WaitColor = Color.FromRgb(0xFC, 0xE9, 0x4F);
        private Color NormalColor = Color.FromRgb(0x20, 0x4A, 0x87);

        public SuperProgressBarState State {
            get {
                return _state;
            }
            set {
                _state = value;
                switch(value) {
                    case SuperProgressBarState.Wait:
                        Resources["ProgressColor"] = new SolidColorBrush(WaitColor);
                        break;
                    case SuperProgressBarState.Normal:
                        Resources["ProgressColor"] = new SolidColorBrush(NormalColor);
                        break;
                    case SuperProgressBarState.Error:
                        Resources["ProgressColor"] = new SolidColorBrush(ErrorColor);
                        break;
                    default:
                        throw new NotSupportedException(value.ToString());
                }
            }
        }

    }


}
