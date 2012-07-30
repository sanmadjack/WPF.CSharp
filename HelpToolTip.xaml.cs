﻿using System;
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
