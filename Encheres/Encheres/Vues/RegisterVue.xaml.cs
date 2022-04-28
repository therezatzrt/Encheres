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
    public partial class RegisterVue : ContentPage
    {
        public RegisterVue()
        {
            InitializeComponent();
            BindingContext = new RegisterVueModeles(Navigation);
        }

        private void SaisiePrenom_Unfocused(object sender, FocusEventArgs e)
        {
            SaisieEmail.Focus();
        }

        private void SaisieEmail_Unfocused(object sender, FocusEventArgs e)
        {
            SaisieMdp.Focus();
        }

        private void SaisieMdp_Unfocused(object sender, FocusEventArgs e)
        {

        }
    }
}