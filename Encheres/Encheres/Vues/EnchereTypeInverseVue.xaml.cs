using Encheres.Modeles;
using Encheres.VuesModeles;
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
    public partial class EnchereTypeInverseVue : ContentPage
    {
        EnchereTypeInverseVueModele VueModele;
        private Enchere current;

        public EnchereTypeInverseVue(Enchere param)
        {
            InitializeComponent();
            BindingContext = VueModele = new EnchereTypeInverseVueModele(param);
        }


        protected override void OnAppearing()

        {

            base.OnAppearing();

        }

        private void ButtonValiderEnchere_Clicked(object sender, EventArgs e)
        {
            if (SaisieEnchere.Text != null) VueModele.EncherirManuel(float.Parse(SaisieEnchere.Text));

        }
        private async void Remonte_Clicked ( object sender, EventArgs e )
        {
            await remote.ScrollToAsync(0, 0, true);
        }
        private void GoBack_Clicked ( object sender, EventArgs e )
        {
            Application.Current.MainPage = new ListeEnchereVue();

        }


        //private void OnClickRetourArriere(object sender, EventArgs e)
        //{
        //Navigation.PopAsync();
        // Application.Current.MainPage.Navigation.PopAsync();
        //}
    }
}