namespace SuperBox_manager
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly FileService _fileService;
        public List<Comanda> Comenzi = new List<Comanda>();
        public List<User> Users = new List<User>();

        public User Uuser { get; set; }
        public MainPage(User user, List<Comanda> comenzi, List<User> users)
        {
            InitializeComponent();
            Uuser = user;
            Comenzi = comenzi;
            Users = users;
            userName.Text = Uuser.Username;
            
            //viewComenzi.ItemsSource = GetComandas();
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
            try
            {
                await Navigation.PushAsync(new LoginPage());
                _fileService.DeleteFile("Delivery3.txt");
                _fileService.DeleteFile("credentialsTest.txt");
                foreach (Comanda comanda in Comenzi)
                {
                    await _fileService.SaveDelivery("Delivery4.txt", comanda);
                }

                foreach (User varUser in Users)
                {
                    await _fileService.SaveUser("credentialsTest.txt", varUser.Uuid, varUser.Username, varUser.Password,
                        varUser.Admin, varUser.Phone, varUser.Email);
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
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
            await Navigation.PushAsync(new IncomingPage(Comenzi, Uuser));

        }

        private void ButtonAddSuperBox_OnClicked(object? sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }

}
