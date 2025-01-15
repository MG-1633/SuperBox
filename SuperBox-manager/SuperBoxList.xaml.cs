using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBox_manager;

public partial class SuperBoxList : ContentPage
{
    private readonly FileService _fileService;
    public List<SuperBox> SuperBoxes { get; set; }
    public SuperBoxList()
    {
        InitializeComponent();
        _fileService = new FileService();
        _ = InitializeAsync(); // Lansăm metoda asincronă fără să blocăm constructorul
    }

    private async Task InitializeAsync()
    {
        try
        {



            string fileNameForDelivery = "AllSuperBoxes.txt";
            SuperBoxes = await _fileService.ReadSuperBox(fileNameForDelivery);
            foreach (var VARIABLE in SuperBoxes)
            {
                SuperBoxListText.Text += VARIABLE.Id.ToString() + " " + VARIABLE.Location + "\n";

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }


    }
}