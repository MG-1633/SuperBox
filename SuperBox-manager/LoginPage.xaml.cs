using System.Net.Mime;
//using PassKit;

namespace SuperBox_manager;



public partial class LoginPage : ContentPage
{


	private readonly FileService _fileService;
	public LoginPage()
	{
		InitializeComponent();
		_fileService = new FileService(); 
	}
List<User> users = new List<User>();
List<Comanda> Comenzi = new List<Comanda>();

    private async void ButtonClicked_OnClicked(object sender, EventArgs e)
	{
		string username = this.username.Text; 
		string password = this.password.Text; 
		string fileName = "credentialsTest.txt";
		string fileNameForDelivery = "Delivery3.txt";
		

        users = await _fileService.ReadUser(fileName);
        try
        {
	        foreach (var user in users)
	        {
		        if (user.Username == username && user.Password == password)
		        {
			        Comenzi = await _fileService.ReadDelivery(fileNameForDelivery, user);

			        Console.WriteLine("Logged in as: " + user.Username + "admin" + user.Admin);
			        if (user.Admin == "true")
			        {
				        await Navigation.PushAsync(new Home(user,Comenzi));

			        }
			        else await Navigation.PushAsync(new MainPage(user,Comenzi));



		        }

	        }
        }
        catch (Exception ex)
        {
	        await DisplayAlert("Eroare", $"Naspaaaaaaa {ex.Message}", "OK");
        }


        
        //	if (savedData != null)
	//	{




			//catre MainPage
	//		if (savedData.Admin == "true")
	//		{
      //          await Navigation.PushAsync(new Home(savedData));

     //       }
     //       else await Navigation.PushAsync(new MainPage(savedData));

	//	}
	//	else
	//	{

	//		await DisplayAlert("Eșec", "Utilizator sau parolă incorecte.", "OK");
	//	}
	}
	
	private async void EnterMethod_OnClicked(object? sender, EventArgs e)
	{
		
			 await Navigation.PushAsync(new SignInPage());

	}
}