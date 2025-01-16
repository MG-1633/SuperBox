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
    List<Comanda> Comenzi = new List<Comanda>();
    List<User> Users = new List<User>();
    public Home(User user, List<Comanda> comenzi, List<User> users)
    {
        InitializeComponent();
        Uuser = user;
        Users = users;
        userName.Text = Uuser.Username;
        Comenzi = comenzi;
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
        await Navigation.PushAsync(new PlacedOrders(Uuser, Comenzi));

    }

    private async void ButtonShowIncomingOrders_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new IncomingPage(Comenzi,Uuser));

    }

    private async void ButtonAddSuperBox_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddSuperBox());
    }

    private async void ButtonSeeAdminRequests_OnClicked(object sender, EventArgs e)
    {
        
        await Navigation.PushAsync(new AdminRequestList());
    }
    

    private async void ButtonShowSuperBox_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new SuperBoxList());
    }
}