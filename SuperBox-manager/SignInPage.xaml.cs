using System.Net.Mime;

namespace SuperBox_manager;

public partial class SignInPage : ContentPage
{
	private readonly FileService _fileService;

	public SignInPage()
	{
		InitializeComponent();
		_fileService = new FileService(); // Instanțierea serviciului
	}

	private async void ButtonClicked_OnClicked(object sender, EventArgs e)
	{
		string username = this.username.Text;
		string password = this.password.Text;
		string email = this.email.Text;
		string phone = this.phone.Text;
		var random = new Random();
		string randomNumber = random.Next(100, 1000).ToString();
		string
			fileName = "credentialsTest.txt"; //<aplicație-sandbox>/Library/Application Support/    - ios				//data/data/<nume-pachet-aplicație>/files/      - android

		// salvam uuid/utilizator/parola/admin/email/phone?  in fisier
		try
		{

			

            // Verificăm dacă utilizatorul există deja
            bool userExists = await _fileService.UserExistsInFile(fileName, username);

            if (userExists)
            {
                await DisplayAlert("Eroare", "Numele de utilizator există deja. Vă rugăm să alegeți alt nume.", "OK");
                return;
            }

            await _fileService.SaveTextToFile(fileName, randomNumber, username, password, "true", phone, email);

            await DisplayAlert("Succes", $"Datele au fost salvate cu succes.", "OK");

			//către LoginPage
			await Navigation.PushAsync(new LoginPage());
		}
		catch (Exception ex)
		{
			await DisplayAlert("Eroare", $"Nu s-a putut salva fișierul: {ex.Message}", "OK");
            
		}

	}




	private async void EnterMethod_OnClicked(object? sender, EventArgs e)
	{

		await Navigation.PushAsync(new LoginPage());


	}

}
