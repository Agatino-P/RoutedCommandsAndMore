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

namespace RoutedCommandsAndMorePrj
{
    public class MyCC : Control, ICommandSource
    {
        private Ellipse _ellipse;
        static MyCC()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCC), new FrameworkPropertyMetadata(typeof(MyCC)));
        }

        private EventHandler _canExecuteChangedHandler;

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(MyCC), new PropertyMetadata(null));



        public Object CommandParameter
        {
            get { return (Object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(Object), typeof(MyCC), new PropertyMetadata(null));



        public IInputElement CommandTarget
        {
            get { return (IInputElement)GetValue(CommandTargetProperty); }
            set { SetValue(CommandTargetProperty, value); }
        }
        public static readonly DependencyProperty CommandTargetProperty =
            DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(MyCC), new PropertyMetadata(null));

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (_ellipse != null)
            {
                _ellipse.MouseLeftButtonUp -= Ellipse_MouseLeftButtonUp;
            }
            _ellipse = GetTemplateChild("PART_Ellipse") as Ellipse;
            if (_ellipse != null)
            {
                _ellipse.MouseLeftButtonUp += Ellipse_MouseLeftButtonUp;
            }
        }

        private void Ellipse_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        public class 

    }
}
