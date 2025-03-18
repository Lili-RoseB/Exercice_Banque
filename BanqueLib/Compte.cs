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
        private decimal _solde = 0M;
        private StatutCompte _statut = StatutCompte.OK;
        private bool _estGeler = false;
        #endregion

        #region-----Constructeurs-----
        public Compte (int Numéro, string Détenteur)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(Numéro);
            this._numéro = Numéro;
            ArgumentException.ThrowIfNullOrWhiteSpace(Détenteur);
            SetDétenteur(Détenteur);
        }

        public Compte(int Numéro, string Détenteur, decimal Solde)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(Numéro);
            this._numéro = Numéro;
            ArgumentException.ThrowIfNullOrWhiteSpace(Détenteur);
            SetDétenteur(Détenteur);
            ArgumentOutOfRangeException.ThrowIfNegative(Solde);
            ArgumentOutOfRangeException.ThrowIfNotEqual(Solde, decimal.Round(Solde, 2));
            this._solde = Solde;
        }

        public Compte(int Numéro, string Détenteur, decimal Solde, StatutCompte Statu )
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(Numéro);
            this._numéro = Numéro;
            this._statut = Statu;
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(Solde);
            ArgumentOutOfRangeException.ThrowIfNotEqual(Solde, decimal.Round(Solde, 2));
            this._solde = Solde;
            ArgumentException.ThrowIfNullOrWhiteSpace(Détenteur);
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
            ArgumentException.ThrowIfNullOrWhiteSpace(Détenteur);
            this._détenteur = Détenteur.Trim();
        }

        #endregion


        #region-----méthodes calculantes-----
        public bool PeutDéposer(decimal montant = 0M)
        {
           ArgumentOutOfRangeException.ThrowIfNegative(montant);
           ArgumentOutOfRangeException.ThrowIfNotEqual(montant, decimal.Round(montant, 2));
            if(Statut == StatutCompte.Gelé)
                return false;
            else 
                return true;

        }

        public bool PeutRetirer(decimal montant = 0M)
        {

            ArgumentOutOfRangeException.ThrowIfNegative(montant);
            ArgumentOutOfRangeException.ThrowIfNotEqual(montant, decimal.Round(montant, 2));
            if (Statut == StatutCompte.Gelé || montant > Solde)
                return false;
            else 
                return true;


        }

        public bool PeutVider()
        {
            if (Solde == 0M || Statut == StatutCompte.Gelé)
            {
                throw new InvalidOperationException(nameof(Vider));
                return false;
            }
            else
            {
                return true;
            }
        }
        public string Description()
        {
            return $@"
            [LRB] * *************************************************
            [LRB] *                                                 *
            [LRB] *  COMPTE {Numéro,-12}                            *
            [LRB] *      DE: {Détenteur, -39}*
            [LRB] *   Solde: {Solde, -15:C2}                        *
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
                throw new InvalidOperationException(nameof(Déposer));

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
                throw new InvalidOperationException(nameof(Retirer));

            }
            else
            {
                _solde -= montant;
            }

        }

        public void Geler()
        {
            if (Statut == StatutCompte.Gelé)
                throw new InvalidOperationException(nameof(Geler));
            else
            _statut = StatutCompte.Gelé;
            
        }

        public void Dégeler()
        {
            if (Statut == StatutCompte.OK)
                throw new InvalidOperationException(nameof(Dégeler));
           else
            _statut = StatutCompte.OK;
        }

        public decimal Vider()
        {
            if (!PeutVider())
            {
                throw new InvalidOperationException(nameof(Vider));
            }
            else
            {
                _solde = 0M;
                return Solde;
            }
        }
        #endregion

    }

    public enum StatutCompte { OK, Gelé };
}
