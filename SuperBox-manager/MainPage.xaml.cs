namespace SuperBox_manager
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly FileService _fileService;
        public List<Comanda> Comenzi = new List<Comanda>();
        public User Uuser { get; set; }

        public MainPage(User user)
        {
            InitializeComponent();
            
            Uuser = user;
            userName.Text = Uuser.Username;
            string fileNameForDelivery = "Delivery3.txt";
            viewComenzi.ItemsSource = GetComandas();
        }

        private List<Comanda> GetComandas()
        {
            List<Comanda> comandas = new List<Comanda>();
            Comanda com1 = new Comanda("Box2", "Box5", Uuser, false, "Marcus", "Elimi");
            Comanda com2 = new Comanda("Box5", "Box7", Uuser, false, "Andreeas", "Marinescu");
            comandas.Add(com1);
            comandas.Add(com2);
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
            await Navigation.PushAsync(new PlacedOrders(Uuser));

        }

        private void ButtonShowIncomingOrders_OnClicked(object? sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void ButtonAddSuperBox_OnClicked(object? sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }

}
