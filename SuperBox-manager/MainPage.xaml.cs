namespace SuperBox_manager
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public User Uuser { get; set; }

        public MainPage(User user)
        {
            InitializeComponent();
            Uuser = user;

            BindingContext = Uuser;
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

        private void ButtonMakeMeAdmin_OnClicked(object? sender, EventArgs e)
        {
           // throw new NotImplementedException();
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
