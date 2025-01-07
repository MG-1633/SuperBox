﻿namespace SuperBox_manager
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
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

        private void ButtonBackToLogIn_OnClicked(object? sender, EventArgs e)
        {
           // throw new NotImplementedException();
        }

        private void ButtonMakeNewDelivery_OnClicked(object? sender, EventArgs e)
        {
           // throw new NotImplementedException();
        }

        private void ButtonMakeMeAdmin_OnClicked(object? sender, EventArgs e)
        {
           // throw new NotImplementedException();
        }

        private void ButtonShowPlacedOrders_OnClicked(object? sender, EventArgs e)
        {
            //throw new NotImplementedException();
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
