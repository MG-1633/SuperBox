namespace SuperBox_manager
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly FileService _fileService;
        
        public User Uuser { get; set; }

        public MainPage(User user)
        {
            InitializeComponent();
            Uuser = user;
            userName.Text = Uuser.Username;
            string fileNameForDelivery = "Delivery3.txt";
            viewComenzi.ItemsSource = (System.Collections.IEnumerable)_fileService.ReadDelivery(fileNameForDelivery, Uuser);
            //BindingContext = Uuser;
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
