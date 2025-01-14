using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBox_manager;


public partial class PlacedOrders : ContentPage
{
    private readonly FileService _fileService;
    public User UserX;
    public List<Comanda> Comenzi = new List<Comanda>();
    public PlacedOrders(User user)
    {
        InitializeComponent();
        UserX = user;
        _fileService = new FileService();
        _ = InitializeAsync(); // Lansăm metoda asincronă fără să blocăm constructorul
    }

    private async Task InitializeAsync()
    {
        
        string fileNameForDelivery = "Delivery3.txt";
        Comenzi = await _fileService.ReadDelivery(fileNameForDelivery, UserX);
        foreach (var VARIABLE in Comenzi)
        {
            
            Console.WriteLine("----" + VARIABLE);
            if (VARIABLE.From != "")
            {
                OrderText.Text += VARIABLE.UserX.Username + " " + VARIABLE.To + " " + VARIABLE.To + " \n";
            }
        }
       
        
        
        
    }
}