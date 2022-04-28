using Encheres.VuesModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encheres.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GagnantVue : ContentPage
    {
        GagnantVueModele VueModele;
        public GagnantVue(string param)
        {

            InitializeComponent();

            BindingContext = VueModele = new GagnantVueModele(param);

        }
        private async void Remonte_Clicked ( object sender, EventArgs e )
        {
            await remote.ScrollToAsync(0, 0, true);
        }
        private void GoBack_Clicked ( object sender, EventArgs e )
        {
            Application.Current.MainPage = new ListeEnchereVue();

        }

    }
}