using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SuperBox_manager.View_Model
{
    public partial class ViewModelLoginPage : BaseViewModel
    {
        [ObservableProperty]
        private string _userName;
        [ObservableProperty]
        private string _password;
    }
}
