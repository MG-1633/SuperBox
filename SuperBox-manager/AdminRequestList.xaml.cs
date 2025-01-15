using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBox_manager;

public partial class AdminRequestList : ContentPage
{
    private readonly FileService _fileService;
    public List<String> AdminsInApproval;
    public AdminRequestList()
    {
        InitializeComponent();
        _fileService = new FileService();
        _ = InitializeAsync();
    }

   
    private async Task InitializeAsync()
    {
        
        string fileNameForDelivery = "AdminList1.txt";
        AdminsInApproval = await _fileService.ReadMakeMeAdmin(fileNameForDelivery);
        foreach (var VARIABLE in AdminsInApproval)
        {
            
              AdminList.Text += VARIABLE +  " \n";
            
        }
       
        
        
        
    }
}