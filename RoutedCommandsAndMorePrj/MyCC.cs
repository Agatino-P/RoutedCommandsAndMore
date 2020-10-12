using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

        [TypeConverter(typeof(CommandConverter))]
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command",
                typeof(ICommand),
                typeof(MyCC),
                new PropertyMetadata(null, new PropertyChangedCallback(onCommandChangedCallback))
                );

        private static void onCommandChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is MyCC myCC))
            {
                return;
            }
            ICommand oldCommand = e.OldValue as ICommand;
            ICommand newCommand = e.NewValue as ICommand;

            myCC.commandChangedCallback(oldCommand, newCommand);
        }

        private void commandChangedCallback(ICommand oldCommand, ICommand newCommand)
        {
            unhookupCommand(oldCommand);
            hookupCommand(newCommand);

            canExecuteChanged(null, null);
        }

        private void unhookupCommand(ICommand oldCommand)
        {
            if (oldCommand == null)
            {
                return;
            }
            oldCommand.CanExecuteChanged -= _canExecuteChangedHandler;
        }

        private void hookupCommand(ICommand newCommand)
        {
            if (newCommand == null)
            {
                return;
            }
            _canExecuteChangedHandler = new EventHandler(canExecuteChanged);
            newCommand.CanExecuteChanged += _canExecuteChangedHandler;
        }

        private void canExecuteChanged(object sender, EventArgs e)
        {
            if (Command != null)
            {
                if (Command is RoutedCommand routedCommand)
                {
                    IsEnabled = routedCommand.CanExecute(CommandParameter, CommandTarget);
                }
                else
                {
                    IsEnabled = Command.CanExecute(CommandParameter);
                }
            }
        }

        public Object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
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

    }
}
