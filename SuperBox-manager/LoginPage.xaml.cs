namespace SuperBox_manager;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void ButtonClicked_OnClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new MainPage());	
	}
}