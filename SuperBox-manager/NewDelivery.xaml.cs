using System.Runtime.CompilerServices;

namespace SuperBox_manager
{
    public partial class NewDelivery : ContentPage
    {
        bool isUrgentToggle = false;
        public User Uuser { get; set; }
        private readonly FileService _fileService;
        public NewDelivery(User user)
        {
            
            InitializeComponent();
            _fileService = new FileService();

            Uuser = user;
        }

        private  void IsUrgent_OnClicked(object? sender, EventArgs e)
        {
            isUrgentToggle = !isUrgentToggle;
        }
    Random random = new Random();
        private async void ButtonPlace_OnClicked(object? sender, EventArgs e)
        {
            
            string fileNameForDelivery = "Delivery2.txt";

            try
            {
                string from = fromField.Text;
                string to = toField.Text;
                string reciver = reciverField.Text;
                
                Comanda comanda = new Comanda(from, to, Uuser, isUrgentToggle, reciver,Uuser.Username);
                
                await _fileService.SaveDelivery(fileNameForDelivery,comanda);
                await DisplayAlert("Succes", $"Datele au fost salvate cu succes.", "OK");

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
           
            
            
            
            
        }
    }

}