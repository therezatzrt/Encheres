using Encheres.VuesModeles;
using Encheres.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encheres.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPageVue : ContentPage
    {
        public LoginPageVue()
        {
            OnAppearing();
            InitializeComponent();
            BindingContext = new LoginVueModeles();
        }

        private void SaisieIdentifiant_Unfocused(object sender, FocusEventArgs e)
        {
            SaisieMdp.Focus();
        }

        private void SaisieMdp_Unfocused(object sender, FocusEventArgs e)
        {
           
        }

        

            protected async override void OnAppearing()
            {
                if (Constantes.Connected) await Application.Current.MainPage.Navigation.PushAsync(new ProfilVue());
            }
        
    }
}