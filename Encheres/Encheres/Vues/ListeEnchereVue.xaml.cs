using Encheres.Modeles;
using Encheres.Services;
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
    public partial class ListeEnchereVue : ContentPage
    {
        ListeEnchereVueModeles vueModel;
        public ListeEnchereVue()
        {
            InitializeComponent();
            BindingContext = vueModel = new ListeEnchereVueModeles();
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CollectionView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var current = (Enchere)e.CurrentSelection.FirstOrDefault();
            DecompteTimer tmps2 = new DecompteTimer();
            TimeSpan interval = current.Datefin - DateTime.Now;
            tmps2.Start(interval);

            if (tmps2.TempsRestant <= TimeSpan.Zero)
            {
                tmps2.Stop();
                Application.Current.MainPage = new GagnantVue(current.Id.ToString());

            }
            else
            {
                Application.Current.MainPage = new PageEnchereVue(current);
            }
        }

        private void classique_Clicked(object sender, EventArgs e)
        {
            vueModel.VisibleEnchereEnCoursTypeClassique = true;
            vueModel.VisibleEnchereEnCoursTypeInverse = false;
            vueModel.VisibleEnchereEnCoursTypeFlash = false;

        }

        private void inverse_Clicked(object sender, EventArgs e)
        {
            vueModel.VisibleEnchereEnCoursTypeClassique = false;
            vueModel.VisibleEnchereEnCoursTypeInverse = true;
            vueModel.VisibleEnchereEnCoursTypeFlash = false;
        }

        private void flash_Clicked(object sender, EventArgs e)
        {
            vueModel.VisibleEnchereEnCoursTypeClassique = false;
            vueModel.VisibleEnchereEnCoursTypeInverse = false;
            vueModel.VisibleEnchereEnCoursTypeFlash = true;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await remote.ScrollToAsync(0, 0, true);

        }
        private void collViewInverse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var current = (Enchere)e.CurrentSelection.FirstOrDefault();
            Application.Current.MainPage = new EnchereTypeInverseVue(current);
        }

        private void collViewFlash_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var current = (Enchere)e.CurrentSelection.FirstOrDefault();
            Application.Current.MainPage = new EnchereTypeFlashVue(current);

        }
        private async void Remonte_Clicked(object sender, EventArgs e)
        {
            await remote.ScrollToAsync(0, 0, true);
        }
        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new ListeEnchereVue();

        }
    }
}