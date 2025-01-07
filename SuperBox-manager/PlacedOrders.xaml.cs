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
    public PlacedOrders(User user)
    {
        InitializeComponent();
        UserX = user;
        _fileService = new FileService();
        _ = InitializeAsync(); // Lansăm metoda asincronă fără să blocăm constructorul
    }

    private async Task InitializeAsync()
    {
        
        string fileNameForId = "MyOrdersId2" + UserX.Uuid + ".txt";
        string fileNameForDelivery = "Delivery2.txt";

        String[] MyDeliveryIds = await _fileService.ReadMyDeliveryId(fileNameForId);
        foreach (var VARIABLE in MyDeliveryIds)
        {
            Comanda comanda = await _fileService.ReadDeliveryById(fileNameForDelivery, VARIABLE, UserX);
            Console.WriteLine("----" + VARIABLE);
            OrderText.Text += comanda.IdComanda + " " + comanda.From + " " + comanda.To + " \n";
        }
        foreach (var VARIABLE in MyDeliveryIds)
        {
            Console.WriteLine("----" + VARIABLE);
        }
        
        
        
    }
}