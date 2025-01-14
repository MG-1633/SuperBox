namespace SuperBox_manager;

public partial class AddSuperBox : ContentPage
{
    public SuperBox superbox { get; set; }
    private readonly FileService _fileService;
    public AddSuperBox(SuperBox superbox)
    {

        InitializeComponent();
        _fileService = new FileService();
        SuperBox = superBox;
    }
    public AddSuperBox()
    {

    }
    public AddSuperBox()
    {

        InitializeComponent();
        _fileService = new FileService();

    }


    int i = 0;
    private async void ButtonPlace_OnClicked(object? sender, EventArgs e)
    {


        try
        {
            i++;

            string locatie = Field.Text;

           SuperBox superbox = new SuperBox(i,locatie);

            // await _fileService.SaveMyDeliverysId(fileNameForId, comanda.IdComanda);
            await _fileService.SaveSuperBox(fileNameForSuperBox, superbox);
            await DisplayAlert("Succes", $"Datele au fost salvate cu succes.", "OK");

        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }





    }
}