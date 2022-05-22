using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Encheres.Modeles
{
    public class Enchere
    {
        #region Attributs
        public static List<Enchere> CollClasse = new List<Enchere>();
        private int _id;
        private DateTime _datedebut;
        private DateTime _datefin;
        private double _prixReserve;
        //private double prix_enchere;
        //private ObservableCollection<Encherir> lesEncherirs;
        private TypeEncheres leTypeEnchere;
        private Produit leProduit;


        private double _prixHT;
        private double _prixTVA;

        #endregion

        #region Constructeurs

        public Enchere(int id, DateTime datedebut, DateTime datefin, double prixReserve, double prixHT, double prixTVA, TypeEncheres leTypeEnchere = null, Produit leProduit = null)
        {
            Enchere.CollClasse.Add(this);
            this._id = id;
            this._datedebut = datedebut;
            this._datefin = datefin;
            this._prixReserve = prixReserve;
            //this.prix_enchere = prix_enchere;
            this.leTypeEnchere = leTypeEnchere;
            this.leProduit = leProduit;
            this._prixHT = prixHT;
            this._prixTVA = prixTVA;
        }

        #endregion

        #region Getters/Setters
        public int Id { get => _id; set => _id = value; }
        public DateTime Datedebut { get => _datedebut; set => _datedebut = value; }
        public DateTime Datefin { get => _datefin; set => _datefin = value; }
        public double PrixReserve { get => _prixReserve; set => _prixReserve = value; }
        //public double Prix_enchere { get => prix_enchere; set => prix_enchere = value; }
        public TypeEncheres LeTypeEnchere { get => leTypeEnchere; set => leTypeEnchere = value; }
        public Produit LeProduit { get => leProduit; set => leProduit = value; }
        public double PrixHT { get => _prixHT; set => _prixHT = value; }
        public double PrixTVA { get => _prixTVA; set => _prixTVA = value; }
        #endregion



        #region Methodes

       

        #endregion
    }
}
