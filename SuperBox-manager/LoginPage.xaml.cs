using System.Net.Mime;

namespace SuperBox_manager;

public partial class LoginPage : ContentPage
{
	private readonly FileService _fileService;
	bool userIsSigningIn = false;
	public LoginPage()
	{
		InitializeComponent();
		_fileService = new FileService(); // Instanțierea serviciului
	}

	private async void ButtonClicked_OnClicked(object sender, EventArgs e)
	{
		string username = this.username.Text; // Obținem textul din câmpul "username"
		string password = this.password.Text; // Obținem textul din câmpul "password"
		var random = new Random();
		string randomNumber = random.Next(100,1000).ToString();
		string filename = "credentials.txt";
		
		
		
		
		
	/*	try
		{
			string savedData = await _fileService.ReadTextFromFile(filename,username,password);
			if (!string.IsNullOrWhiteSpace(savedData))
			{
				await DisplayAlert("Date Salvate", savedData, "OK");
			}
			else
				await DisplayAlert("Info", "Nu există date salvate."
					, "ОК");

		}
		catch (Exception ex)
		{
			await DisplayAlert("Erosre", $"Nu s a putut citi mesajul {ex.Message}", "ok");
		}
		
		*/

	if (!userIsSigningIn)
	{

		

		string savedData = await _fileService.ReadTextFromFile(filename, username, password);
		if (savedData == "true")
		{



			if (!string.IsNullOrWhiteSpace(savedData))
			{
				//await DisplayAlert("Date Salvate", savedData, "OK");
			}
			else
				await DisplayAlert("Info", "Nu există date salvate. Inregistreaza-te prima data."
					, "ОК");



			// Salvăm combinația utilizator/parolă într-un fișier
			try
			{
				string fileName = "credentials.txt";
				//<aplicație-sandbox>/Library/Application Support/      - ios

				//data/data/<nume-pachet-aplicație>/files/      - android



				//await _fileService.SaveTextToFile(fileName, randomNumber, username, password, "No" );

				//await DisplayAlert("Succes", $"Datele au fost salvate în {fileName}.", "OK");

				//către MainPage
				await Navigation.PushAsync(new MainPage());
			}
			catch (Exception ex)
			{
				await DisplayAlert("Eroare", $"Nu s-a putut salva fișierul: {ex.Message}", "OK");
			}


		}
		else
		{
			await DisplayAlert("Eșec", "Utilizator sau parolă incorecte.", "OK");
		}

	}
	else
	{




		
		
		
		
	

			// Salvăm combinația uuid/utilizator/parolă/admin?  într-un fișier
			try
			{
				string fileName = "credentials.txt";				//<aplicație-sandbox>/Library/Application Support/    - ios				//data/data/<nume-pachet-aplicație>/files/      - android



				await _fileService.SaveTextToFile(fileName, randomNumber, username, password, "No" );

				await DisplayAlert("Succes", $"Datele au fost salvate cu succes.", "OK");

				//către MainPage
				await Navigation.PushAsync(new MainPage());
			}
			catch (Exception ex)
			{
				await DisplayAlert("Eroare", $"Nu s-a putut salva fișierul: {ex.Message}", "OK");
			}


		

		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
	}

	}
	
	
	

	private void EnterMethod_OnClicked(object? sender, EventArgs e)
	{
		 userIsSigningIn = !userIsSigningIn;
		 if (userIsSigningIn)
		 {
			 signMessage.Text = "already have an account?";
			 enterMethod.Text = "LOG IN";
			 ButtonClicked.Text = "SIGN IN";

		 }
		 else
		 {
			 signMessage.Text = "new user?";
			 enterMethod.Text = "SIGN IN";
			 ButtonClicked.Text = "LOG IN";


		 }
		
	}
}