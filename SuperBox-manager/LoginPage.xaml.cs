using System.Net.Mime;

namespace SuperBox_manager;



public partial class LoginPage : ContentPage
{


	private readonly FileService _fileService;
	public LoginPage()
	{
		InitializeComponent();
		_fileService = new FileService(); // Instanțierea serviciului
	}
List<User> users = new List<User>();

    private async void ButtonClicked_OnClicked(object sender, EventArgs e)
	{
		string username = this.username.Text; 
		string password = this.password.Text; 
		string fileName = "credentialsTest.txt";

		

        users = await _fileService.ReadUser(fileName);
        foreach (var user in users)
        {
	        if (user.Username == username && user.Password == password)
	        {
		        if (user.Admin == "true")
		        {
			        await Navigation.PushAsync(new Home(user));
		        }
		        else
		        {
			         await Navigation.PushAsync(new MainPage(user));
		        }
		        
	        }
	        
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