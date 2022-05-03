using Encheres.Modeles;
using Encheres.Services;
using Encheres.Vues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Encheres.VuesModeles
{
    class LoginVueModeles : BaseVueModele
    {
        #region Attributs
        private readonly ApiAuthentification _apiServicesAuthentification = new ApiAuthentification();
        private string _password;
        private string _email;
        private bool auth = false;

        #endregion



        #region Constructeur
        public LoginVueModeles()
        {
            CommandeButtonAuthentification = new Command(ActionPageAuthentification);
            CommandeButtonRegister = new Command(ActionPageRegister);
        }

        #endregion


        #region Getters/Setters
        public ICommand CommandeButtonAuthentification { get; }
        public ICommand CommandeButtonRegister { get; }

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

        #endregion

        #region Méthodes

        //méthode pour la validation de co par l'API
        public async void ActionPageAuthentification()
        {
            // 
            User unUser = new User(Email,"", Password, "");
            // recupération des données de l'utilisateur (mail et mdp)
            var connexion = await _apiServicesAuthentification.GetAuthAsync(unUser, "api/getUserByMailAndPass");
                if (connexion != default(User))
                {
                //authentification avec succès er la direction 
                    auth = true;
                Storage.StockerMotDePasse(connexion.Id.ToString());
                Constantes.Connected = true;
                User.currentUser = connexion;
                    await Shell.Current.GoToAsync($"//{nameof(ListeEnchereVue)}");

                }
                else
                {
                //message d'erreuc a l'échoue de la connexion 
                    auth = false;
                    await Application.Current.MainPage.DisplayAlert("connexion echouée", "Echec", "recommencer");
                }

            
        }
        public async void ActionPageRegister()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterVue());

        }
        #endregion

       

      

    }
}
