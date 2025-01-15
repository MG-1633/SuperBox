namespace SuperBox_manager
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly FileService _fileService;
        public List<Comanda> Comenzi = new List<Comanda>();
        public User Uuser { get; set; }
        public MainPage(User user, List<Comanda> comenzi)
        {
            InitializeComponent();
            Uuser = user;
            Comenzi = comenzi;
            userName.Text = Uuser.Username;
            
            viewComenzi.ItemsSource = GetComandas();
        }
        
        
        private List<Comanda> GetComandas()
        {
            List<Comanda> comandas = new List<Comanda>();
            
            comandas = Comenzi;
            return comandas;
        }
        
        
        
        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
            
        }


      




       

        private async void ButtonBackToLogIn_OnClicked(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
            _fileService.DeleteFile("Delivery3.txt");
            _fileService.DeleteFile("credentialsTest.txt");
            _fileService.DeleteFile("AdminList1.txt");
            foreach (Comanda comanda in Comenzi)
            {
                await _fileService.SaveDelivery("Delivery3.txt", comanda);
            }
        }

        private async void ButtonMakeNewDelivery_OnClicked(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewDelivery(Uuser));
        }

        private async void ButtonMakeMeAdmin_OnClicked(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new MakeMeAdminPage(Uuser));
        }

        private async void ButtonShowPlacedOrders_OnClicked(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlacedOrders(Uuser, Comenzi));

        }

        private async void ButtonShowIncomingOrders_OnClicked(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new IncomingPage(Comenzi));

        }

        private void ButtonAddSuperBox_OnClicked(object? sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }

}
