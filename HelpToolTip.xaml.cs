using System.Windows.Controls;
using System.Windows.Input;
namespace SMJ.WPF {
    /// <summary>
    /// Interaction logic for HelpToolTip.xaml
    /// </summary>
    public partial class HelpToolTip : UserControl {
        public new object ToolTip {
            get {
                return image.ToolTip;
            }
            set {
                image.ToolTip = value;
            }
        }

        public HelpToolTip() {
            InitializeComponent();
        }

        private void image_MouseEnter(object sender, MouseEventArgs e) {
        }
    }
}
