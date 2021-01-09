﻿using System;
using CheckinLS.API.Misc;
using Xamarin.Forms.Xaml;
using MainSql = CheckinLS.API.Sql.MainSql;

// ReSharper disable RedundantCapturedContext

namespace CheckinLS.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewUserPage
    {
        private readonly string _password;

        public AddNewUserPage(string password)
        {
            InitializeComponent();

            _password = password;
        }

        private async void Enter_Clicked(object sender, EventArgs e)
        {
            if (MainSql.Conn == null)
                return;

            if (string.IsNullOrEmpty(Username.Text))
                return;

            var username = Username.Text.ToLowerInvariant().RemoveWhitespace();

            try
            {
                await MainSql.MakeUserAccountAsync(username, _password);
            }
            catch (UserTableNotFound)
            {
                await DisplayAlert("Error", "No table found with that name!", "OK");
                return;
            }
            catch (UserAlreadyExists)
            {
                await DisplayAlert("Error", "User already registered!", "OK");
                return;
            }
            catch (PinAlreadyExists)
            {
                await DisplayAlert("Error", "Password already used!", "OK");
                return;
            }

            await DisplayAlert("New user", "User created! Please re-enter pin", "OK");

            await Navigation.PopModalAsync();
        }
    }
}