using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBox_manager;

public partial class MakeMeAdminPage : ContentPage
{
    private readonly FileService _fileService;
    public User UserX { get; set; }
    public MakeMeAdminPage(User user)
    {
        InitializeComponent();
        UserX = user;
        _fileService = new FileService();

    }

    private async void MakeMeAdminSend_OnClicked(object? sender, EventArgs e)
    {
        string fileName = "AdminList1.txt";
        await _fileService.SaveMakeMeAdmin(fileName, UserX);

    }
}