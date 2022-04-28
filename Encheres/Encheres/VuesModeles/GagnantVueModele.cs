using Encheres.Modeles;
using Encheres.Services;
using Encheres.Vues;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace Encheres.VuesModeles
{
    class GagnantVueModele : BaseVueModele
    {
        #region Attributs
        private readonly Api _apiServices = new Api();
        User _unUser;
        bool _visibleEtatGagant = false;
        bool _visiblePhotoStream = false;
        


        #endregion

        #region Constructeurs

        public GagnantVueModele(string param)
        {
            this.GetGagnant(param);
        }

        #endregion

        #region Getters/Setters

        public User UnUser
        {
            get
            {
                return _unUser;
            }
            set
            {
                SetProperty(ref _unUser, value);
            }
        }

        public bool VisibleEtatGagant 
        {
            get => _visibleEtatGagant;
            set { SetProperty(ref _visibleEtatGagant, value); }
        }

        public bool VisiblePhotoStream 
        { 
            get => _visiblePhotoStream;
            set { SetProperty(ref _visiblePhotoStream, value); }
        }


        #endregion

        #region Methodes

        //méthode pour récupérer le gagant de l'enchère 
        public async void GetGagnant(string param)
        {
            UnUser = await _apiServices.GetOneAsyncID<User>("api/getGagnant", User.CollClasse, param);
            if (UnUser == null) VisibleEtatGagant = true;
            User.CollClasse.Clear();
            if (UnUser.PhotoStream == null) VisiblePhotoStream = true;
           
        }

        #endregion
    }
}
