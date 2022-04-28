using Encheres.Modeles;
using Encheres.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Encheres.VuesModeles
{
    class EnchereTypeInverseVueModele : BaseVueModele
    {
        #region attributs
        private readonly Api _apiServices = new Api();
        private DecompteTimer tmps;
        private Enchere _monEnchere;
        private int _tempsRestantJour;
        private int _tempsRestantHeures;
        private int _tempsRestantMinutes;
        private int _tempsRestantSecondes;
        private ObservableCollection<Encherir> _maListeSixDernieresEncheres;
        private Encherir _prixActuel;
        private string _idUser;
        private User _unUser;
        private float _plafond;
        private float _saisieSecondes;
        public bool OnCancel;
        private bool _visibleSaisieEnchere;
        private bool _visibleGagnant;
        TimeSpan interval;
        #endregion
        #region Constructeurs

        public EnchereTypeInverseVueModele(Enchere param)
        {
            _monEnchere = param;
            DateTime datefin = param.Datefin;
            interval = datefin - DateTime.Now;
            this.VisibleSaisieEnchere = true;
            tmps = new DecompteTimer();
            this.GetTimerRemaining(param.Datefin);
            this.GetGagnant(MonEnchere.Id.ToString());


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
        public bool VisibleSaisieEnchere
        {
            get { return _visibleSaisieEnchere; }
            set { SetProperty(ref _visibleSaisieEnchere, value); }
        }
        public Enchere MonEnchere
        {
            get { return _monEnchere; }
            set { SetProperty(ref _monEnchere, value); }
        }
        public int TempsRestantHeures
        {
            get { return _tempsRestantHeures; }
            set { SetProperty(ref _tempsRestantHeures, value); }
        }
        public int TempsRestantJour
        {
            get { return _tempsRestantJour; }
            set { SetProperty(ref _tempsRestantJour, value); }
        }
        public int TempsRestantMinutes
        {
            get { return _tempsRestantMinutes; }
            set { SetProperty (ref _tempsRestantMinutes, value); }
        }
        public int TempsRestantSecondes
        {
            get { return _tempsRestantSecondes; }
            set { SetProperty(ref _tempsRestantSecondes, value); }
        }

        public Encherir PrixActuel
        {
            get { return _prixActuel; }
            set { SetProperty(ref _prixActuel, value); }
        }
        public bool VisibleGagnant
        {
            get { return _visibleGagnant; }
            set { SetProperty(ref _visibleGagnant, value); }
        }
        public string IdUser
        {
            get => _idUser;
            set => _idUser = value;
        }

        public float Plafond
        {
            get => _plafond;
            set { SetProperty(ref _plafond, value); }
        }

        public float SaisieSecondes
        {
            get => _saisieSecondes;
            set { SetProperty(ref _saisieSecondes, value); }
        }
        #endregion



        #region methodes


        //méthode pour récupérer le temps restant de l'enchère inverse en cours
        public void GetTimerRemaining(DateTime param)
        {

            // vérification si le temps est inférieur a 0 si c'ets le cas l'utilisateur ne peut pas saisir d'enchère 
            if (interval < TimeSpan.Zero)
            {
                OnCancel = true;
                interval = TimeSpan.Zero;
                VisibleSaisieEnchere = false;
            }
            var task = Task.Run(() =>
            {
                tmps.Start(interval);
                while (OnCancel == false || tmps.TempsRestant > TimeSpan.Zero)
                {
                    TempsRestantJour = tmps.TempsRestant.Days;
                    TempsRestantHeures = tmps.TempsRestant.Hours;
                    TempsRestantMinutes = tmps.TempsRestant.Minutes;
                    TempsRestantSecondes = tmps.TempsRestant.Seconds;

                }

            });


        }


        //méthode pour récupérer le gagant 
        public void GetGagnant(string param)
        {
            bool fin = false;
            Task.Run(async () =>
            {
                while (fin == false)
                {

                    //vérification le temps restant de lenchère, si <= 0 alors on récupère le gagant et l'afficher 
                    if (tmps.TempsRestant <= TimeSpan.Zero) UnUser = await _apiServices.GetOneAsyncID<User>("api/getGagnant", User.CollClasse, param);
                    if (UnUser != null)
                    {
                        User.CollClasse.Clear();
                        VisibleGagnant = true;
                        fin = true;
                    }
                }
            });


        }




        //méthode pour encherir manuellement 
        public async void EncherirManuel(float param)
        {

            IdUser = await SecureStorage.GetAsync("ID");
            int resultat = await _apiServices.PostAsync<Encherir>(new Encherir(param, int.Parse(IdUser), MonEnchere.Id, 0, ""), "api/postEncherirInverse");
            tmps.TempsRestant = TimeSpan.Zero;
            VisibleSaisieEnchere = false;
        }

        #endregion
    }
}
