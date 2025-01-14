using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
//using Windows.System;

namespace SuperBox_manager;

public partial class Home : ContentPage
{

    public User Uuser { get; set; }
    public Home(User user)
    {
        InitializeComponent();
        Uuser = user;
        userName.Text = Uuser.Username;
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

    private async void ButtonAddSuperBox_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddSuperBox());
    }

    private void ButtonSeeAdminRequests_OnClicked(object sender, EventArgs e)
    {
        // Your event handling logic here
      
    }

    private void ButtonShowSuperBox_OnClicked(object sender, EventArgs e)
    {
        // Add your event handling logic here
        
    }
}