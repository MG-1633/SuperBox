using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBox_manager;
    
public partial class IncomingPage : ContentPage
{
    private readonly FileService _fileService;
    public User UserX;
    public List<Comanda> Comenzi = new List<Comanda>();
    public IncomingPage( List<Comanda> comenzi )
    {
        InitializeComponent();
        Comenzi = comenzi;
        _fileService = new FileService();
        _ = InitializeAsync();
    }
    
    
    private async Task InitializeAsync()
    {
        
        foreach (var VARIABLE in Comenzi)
        {
            if (VARIABLE.To == UserX.Username)
            {
                Console.WriteLine("----" + VARIABLE);
                OrderText.Text += VARIABLE.IdComanda + " " + VARIABLE.From + " " + VARIABLE.Sender + " \n";
            }
        }
       
        
        
        
    }
    
    
}