﻿using Encheres.VuesModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encheres.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilVue : ContentPage
    {
        ProfilVueModele VueModele;
        public ProfilVue ()
        {
            InitializeComponent();
            BindingContext = VueModele = new ProfilVueModele();


        }
        private void OnClickDeconnexion ( object sender, EventArgs e )
        {
            //Lors de l'appuie sur le bouton de déconnexion, on efface l'id et le pseudo de l'utilisateur
            //présent dans le cache de l'application.
            SecureStorage.Remove("ID");
            SecureStorage.Remove("PSEUDO");
            Constantes.Connected = false;

            VueModele.UnUser = null;
            //On redirige l'utilisateur vers la page de connexion de l'application
            Application.Current.MainPage.Navigation.PopToRootAsync();
            Shell.Current.GoToAsync($"//{nameof(LoginPageVue)}");
        }

/*        protected override void OnDisappearing()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }*/

       
    }
}
