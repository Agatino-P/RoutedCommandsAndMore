using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoutedCommandsAndMorePrj
{
    public class MainWindowViewModel:ViewModelBase
    {
        private RelayCommand _myDialogCmd;
        public RelayCommand MyDialogCmd => _myDialogCmd ?? (_myDialogCmd = new RelayCommand(
            () =>  myDialogCmd(),
            () => { return 1 == 1; },
			keepTargetAlive:true
            ));
        private void myDialogCmd()
        {
            MyDialog myDialog = new MyDialog();
            myDialog.ShowDialog();
        }
    }
}
