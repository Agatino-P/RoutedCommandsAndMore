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
using System.Windows.Shapes;

namespace RoutedCommandsAndMorePrj
{
    /// <summary>
    /// Interaction logic for MyDialog.xaml
    /// </summary>
    public partial class MyDialog : Window
    {


        public static int GetMyAPint(DependencyObject obj)
        { return (int)obj.GetValue(MyAPintProperty); }
        public static void SetMyAPint(DependencyObject obj, int value)
        { obj.SetValue(MyAPintProperty, value); }
        public static readonly DependencyProperty MyAPintProperty =
            DependencyProperty.RegisterAttached("MyAPint", typeof(int), typeof(MyDialog), new PropertyMetadata(0));


        public MyDialog()
        {
            InitializeComponent();
        }

        private void MyCC_Click(object sender, RoutedEventArgs e)
        {
            if (!(e.Source is MyUC myUC))
                return;
            string message = $"{myUC.GetValue(MyAPintProperty) }";
            MessageBox.Show(message);
        }

    }
}
