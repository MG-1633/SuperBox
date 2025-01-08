/*using System.Net.Mime;

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
		string randomNumber = random.Next(100,1000).ToString();
		string fileName = "credentials.txt";					//<aplicație-sandbox>/Library/Application Support/    - ios				//data/data/<nume-pachet-aplicație>/files/      - android

			// salvam uuid/utilizator/parola/admin/email/phone?  in fisier
		try	{
			
				await _fileService.SaveTextToFile(fileName, randomNumber, username, password, "No",phone , email );

				await DisplayAlert("Succes", $"Datele au fost salvate cu succes.", "OK");

				//către MainPage
				await Navigation.PushAsync(new LoginPage());
			}
			catch (Exception ex)
			{
				await DisplayAlert("Eroare", $"Nu s-a putut salva fișierul: {ex.Message}", "OK");
			}


		

		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
	
	}
	
	
	

	private void EnterMethod_OnClicked(object? sender, EventArgs e)
	{
		
		
		
	}
}*/
using System.Net.Mime;

namespace SuperBox_manager;

public partial class SignInPage : ContentPage
{
    private readonly FileService _fileService;

    public SignInPage()
    {
        InitializeComponent();
        _fileService = new FileService(); // Instantierea serviciului
    }

    private async void ButtonClicked_OnClicked(object sender, EventArgs e)
    {
        string username = this.username.Text;
        string password = this.password.Text;
        string email = this.email.Text;
        string phone = this.phone.Text;
        var random = new Random();
        string randomNumber = random.Next(100, 1000).ToString();
        string fileName = "credentials.txt"; // Locatie fisier

        try
        {
            // Verificam daca utilizatorul exista deja
            bool userExists = await _fileService.UserExistsInFile(fileName, username);

            if (userExists)
            {
                await DisplayAlert("Eroare", "Numele de utilizator există deja. Vă rugăm să alegeți alt nume.", "OK");
                return;
            }

            // Salvam uuid/utilizator/parola/admin/email/phone in fisier
            await _fileService.SaveTextToFile(fileName, randomNumber, username, password, "No", phone, email);

            await DisplayAlert("Succes", "Datele au fost salvate cu succes.", "OK");

            // Navigam catre LoginPage
            await Navigation.PushAsync(new LoginPage());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Eroare", $"Nu s-a putut salva fișierul: {ex.Message}", "OK");
        }
    }

    private void EnterMethod_OnClicked(object? sender, EventArgs e)
    {
        // Implementare ulterioara
    }
}

// Modificam FileService pentru a adauga metoda de verificare
public class FileService
{
    public async Task<bool> UserExistsInFile(string fileName, string username)
    {
        try
        {
            // Citim continutul fisierului
            if (File.Exists(fileName))
            {
                string[] lines = await File.ReadAllLinesAsync(fileName);

                // Verificam daca exista un utilizator cu acelasi nume
                foreach (string line in lines)
                {
                    // Presupunem formatul: uuid,username,password,admin,email,phone
                    string[] parts = line.Split(',');
                    if (parts.Length > 1 && parts[1] == username)
                    {
                        return true;
                    }
                }
            }
        }
        catch (Exception)
        {
            // Gestionam erorile (optional, logare)
        }

        return false; // Utilizatorul nu exista
    }

    public async Task SaveTextToFile(string fileName, string uuid, string username, string password, string admin, string phone, string email)
    {
        string newEntry = $"{uuid},{username},{password},{admin},{email},{phone}";

        if (!File.Exists(fileName))
        {
            using (StreamWriter sw = File.CreateText(fileName))
            {
                await sw.WriteLineAsync(newEntry);
            }
        }
        else
        {
            using (StreamWriter sw = File.AppendText(fileName))
            {
                await sw.WriteLineAsync(newEntry);
            }
        }
    }
}
