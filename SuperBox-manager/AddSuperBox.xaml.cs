namespace SuperBox_manager;

public partial class AddSuperBox : ContentPage
{
    public User Uuser { get; set; }
    private readonly FileService _fileService;
    public SuperBox SuperBox { get; set; }
    
    string fileNameForSuperBox = "NewSuperBox.txt";

    public AddSuperBox(SuperBox superBox)
    {

        InitializeComponent();
        _fileService = new FileService();
        SuperBox = superBox;
    }
    public AddSuperBox()
    {

        InitializeComponent();
        _fileService = new FileService();
    }

   
    private async void ButtonPlace_OnClicked(object? sender, EventArgs e)
    {


        try
        {
            await _fileService.SaveSuperBox(fileNameForSuperBox, SuperBox);
            await DisplayAlert("Succes", $"SuperBoxul au fost salvate cu succes.", "OK");

        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }





    }
}