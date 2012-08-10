using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
namespace SMJ.WPF {
   public class CustomWindowBorders: UserControl {
        Window parentWindow;
        public CustomWindowBorders() {
            parentWindow = Window.GetWindow(this);


       }
        Border ContentBorder = new Border();
        public new UIElement Content {
            get {
                return ContentBorder.Child = Content;
            }
            set {
                ContentBorder.Child = Content;
            }
        }


       protected override void OnInitialized(EventArgs e) {
           base.OnInitialized(e);
           Grid superGrid = new Grid();
           superGrid.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(superGrid_MouseLeftButtonDown);
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

           RowDefinition row;

           row = new RowDefinition();
           row.Height = new GridLength(20);
           superGrid.RowDefinitions.Add(row);

           row = new RowDefinition();
           row.Height = new GridLength(1, GridUnitType.Star);
           superGrid.RowDefinitions.Add(row);

           row = new RowDefinition();
           row.Height = new GridLength(5);
           superGrid.RowDefinitions.Add(row);

           superGrid.Children.Add(ContentBorder);

           this.AddChild(superGrid);
        }

       void superGrid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
           parentWindow.DragMove();
       }

    }
}
