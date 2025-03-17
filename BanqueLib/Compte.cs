using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BanqueLib
{
    public class Compte
    {
        #region -----champs-----
        private readonly int _numéro;
        private string _détenteur;
        private decimal _solde = 0;
        private StatutCompte _statut = StatutCompte.OK;
        private bool _estGeler = false;
        #endregion

        #region-----Constructeurs-----
        public Compte (int Numéro, string Détenteur)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(Numéro);
            this._numéro = Numéro;
            SetDétenteur(Détenteur);
        }

        public Compte(int Numéro, string Détenteur, decimal Solde)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(Numéro);
            this._numéro = Numéro;
            SetDétenteur(Détenteur);
            this._solde = Solde;
        }

        public Compte(int Numéro, string Détenteur, decimal Solde, StatutCompte Statu )
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(Numéro);
            this._numéro = Numéro;
            this._statut = Statu;
            this._solde = Solde;
            SetDétenteur(Détenteur);
        }
        #endregion

        #region-----getters / champs calculable-----
        public int Numéro => _numéro;
        public string Détenteur => _détenteur;
        public decimal Solde => _solde;
        public StatutCompte Statut => _statut;
        public bool EstGelé => _estGeler;
        #endregion

        #region-----setters-----

        [MemberNotNull(nameof(Détenteur))]
        public void SetDétenteur(string Détenteur)
        {
            if(string.IsNullOrEmpty(Détenteur)) 
                throw new ArgumentNullException(nameof(Détenteur));
            this._détenteur = Détenteur.Trim();
        }
        #endregion


        #region-----méthodes calculantes-----
        public bool PeutDéposer(decimal montant = 0)
        {
           ArgumentOutOfRangeException.ThrowIfNegative(montant);
            ArgumentOutOfRangeException.ThrowIfNotEqual(montant, decimal.Round(montant, 2));
            if(_estGeler)
                return false;
            else return true;

        }

        public bool PeutRetirer(decimal montant = 0)
        {

            ArgumentOutOfRangeException.ThrowIfNegative(montant);
            ArgumentOutOfRangeException.ThrowIfNotEqual(montant, decimal.Round(montant, 2));
            if (_estGeler)
                return false;
            else return true;


        }

        public string Description()
        {
            return $@"
            [LRB] * *************************************************
            [LRB] *                                                 *
            [LRB] *  COMPTE {Numéro,-12}                            *
            [LRB] *      DE: {Détenteur, -16}                       *
            [LRB] *   Solde: {Solde, -12}$                          *
            [LRB] *  Statut: {Statut,-12}                           *
            [LRB] *                                                 *
            [LRB] * *************************************************";


        }
        #endregion

        #region-----méthodes modifiantes-----
        public void Déposer(decimal montant)
        {
            if (!PeutDéposer(montant))
            {
                throw new InvalidOperationException(nameof(montant));

            }
            else
            {
                _solde += montant;

            }
        }

        public void Retirer(decimal montant)
        {
            if (!PeutRetirer(montant) || montant > Solde)
            {
                throw new InvalidOperationException(nameof(montant));

            }
            else
            {
                _solde -= montant;
            }

        }

        public void Geler()
        { 
            if(Statut == StatutCompte.Gelé)
                throw new InvalidOperationException();
            else
            _statut = StatutCompte.Gelé;
            
        }

        public void Dégeler()
        {
            if (Statut == StatutCompte.OK)
                throw new InvalidOperationException();
           else
            _statut = StatutCompte.OK;
        }

        public decimal Vider()
        {
            if(Solde == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                _solde = 0;
                return Solde;
            }
        }
        #endregion

    }

    public enum StatutCompte { OK, Gelé };
}
