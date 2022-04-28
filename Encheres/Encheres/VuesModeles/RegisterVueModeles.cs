﻿using Encheres.Modeles;
using Encheres.Services;
using Encheres.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Encheres.VuesModeles
{
    class RegisterVueModeles : BaseVueModele
    {
        #region Attributs
        private readonly ApiRegistration _apiServicesRegistration = new ApiRegistration();
        private string _pseudo;
        private string _password;
        private string _email;
        private string _photo;
        private bool auth = false;
        private bool _succes;

        #endregion

        #region Constructeur
        public RegisterVueModeles(INavigation navigation)
        {
            CommandeButtonRegistration = new Command(ActionPageRegistration);
            CommandeButtonLogin = new Command(ActionPageLogin);

            _succes = false;
        }

        #endregion

        #region Getters/Setters
        public ICommand CommandeButtonRegistration { get; }
        public ICommand CommandeButtonLogin { get; }

        public string Pseudo
        {
            get
            {
                return _pseudo;
            }
            set
            {
                if (_pseudo != value)
                {
                    _pseudo = value;
                    OnPropertyChanged(nameof(Pseudo));
                }
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }
        public string Photo
        {
            get
            {
                return _photo;
            }
            set
            {
                if (_photo != value)
                {
                    _photo = value;
                    OnPropertyChanged(nameof(Photo));
                }
            }
        }
        public bool Succes
        {
            get
            {
                return _succes;
            }
            set
            {
                if (_succes != value)
                {
                    _succes = value;
                    OnPropertyChanged(nameof(Succes));
                }
            }
        }
        #endregion

        #region Méthodes
        // méthode qui permet d'inscrire un nouveau utilisateur dans la BDD en interrogeant l'API de l'existance des données saisis 
        public async void ActionPageRegistration()
        {
            // instanciation des ifnos a l'utilisateur 
            User unUser = new User(Email, Photo, Password, Pseudo);
            
            // validation de l'inscription ou pas de la part de l'API
                var response = await _apiServicesRegistration.PostRegistrationAsync(unUser, "api/postUser");
                if (response)
                {
                    auth = true;
                Succes = true;
                await Task.Delay(3000);
                // inscription réussi, redirigé vers la page d'authentification 
                    await Application.Current.MainPage.Navigation.PushAsync(new LoginPageVue());
                }
                else
                {
                //message d'erreur si le mail est deja stocké dans la BDD
                     await App.Current.MainPage.DisplayAlert("Erreur","L'email que vous avez entré est déja utliser", "cancel");

                    auth = false;
                }

            
        }
        public async void ActionPageLogin()
        {
            //redirection vers la page de connexion si l'utilisateur est deja inscrit 
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPageVue());

        }
        #endregion
    }
}
