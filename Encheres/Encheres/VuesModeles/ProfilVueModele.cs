using Encheres.Modeles;
using Encheres.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Encheres.VuesModeles
{
    class ProfilVueModele : BaseVueModele
    {
        private string _idUser;
        private readonly Api _apiServices = new Api();
        private User _UnUser;
        bool _visiblePhotoStream = false;

        public ProfilVueModele()
        {
            GetUser();
        }

        public string IdUser
        { 
                get => _idUser; 
                set => _idUser = value; 
        }

        public User UnUser
        {
            get { return _UnUser; }
            set { SetProperty(ref _UnUser, value); }
        }

        public bool VisiblePhotoStream
        {
            get => _visiblePhotoStream;
            set { SetProperty(ref _visiblePhotoStream, value); }
        }


        // méthode qui permet de récupérer les info de User grâce a l'ID en interrogeant l'API

        public async void GetUser()
        {
            IdUser = await SecureStorage.GetAsync("ID");
            UnUser = await _apiServices.GetOneAsyncByID<User>("api/getUser", User.CollClasse, IdUser.ToString());

        }
    }
}
