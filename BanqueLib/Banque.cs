using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanqueLib
{
    public class Banque
    {
        public readonly string _nom;
        private readonly List<Compte> _comptes;
        private int _prochainNumero;

        public string Nom => _nom;
        public IReadOnlyList<Compte> Comptes => _comptes;
        public int ProchainNumero => _prochainNumero;
        public int NombreDeComptes => _comptes.Count;
        public decimal TotalDesDépôts => _comptes.Sum(c => c.Solde);


        public Banque(string nom, int prochainNumero, IEnumerable<Compte> comptes)
        {
            if (string.IsNullOrWhiteSpace(nom))
                ArgumentNullException.ThrowIfNullOrWhiteSpace(nom);
            if (prochainNumero <= 0)
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(prochainNumero);
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(prochainNumero, 0);


            _nom = nom;
            _prochainNumero = prochainNumero;
            _comptes = comptes?.ToList() ?? new List<Compte>();

            if (_comptes.Any(c => c == null))
                ArgumentNullException.ThrowIfNull(comptes);

            if (_comptes.Count != _comptes.Distinct().Count())
                ArgumentException.Equals(_comptes, comptes);

            var numéros = _comptes.Select(c => c.Numéro);
            if (numéros.Distinct().Count() != _comptes.Count)
                ArgumentException.Equals(numéros, _comptes);

            _comptes.Sort((a, b) => a.Numéro.CompareTo(b.Numéro));

            if (_comptes.Count > 0)
            {
                int maxNumero = _comptes.Max(c => c.Numéro);
                if (_prochainNumero <= maxNumero)
                    ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(prochainNumero, maxNumero);
            }

        }

        public Banque(string nom)
           : this(nom, 1, null) { }

        public Banque(string nom, IEnumerable<Compte> comptes)
    :       this(nom, CalculerProchainNumero(comptes), comptes?.ToList()) { }

        public Banque(string nom, int prochainNumero)
            : this(nom, prochainNumero, null) { }


        private static int CalculerProchainNumero(IEnumerable<Compte> comptes)
        {
            var comptesList = comptes?.ToList(); 

            if (comptesList == null || comptesList.Count == 0)
                return 1;

            return comptesList.Max(c => c.Numéro) + 1;
        }

        public string DescriptionSommaire()
        {
            return $"[LRB] | ======================================================|\n" +
                   $"[LRB] |                                                       |\n" +
                   $"[LRB] |     {_nom, -50}|\n" +
                   $"[LRB] |                                                       |\n" +
                   $"[LRB] |   Prochain numéro : {_prochainNumero, -34}|\n" +
                   $"[LRB] | Nombre de comptes : {NombreDeComptes, -34}|\n" +
                   $"[LRB] |  Total des dépôts : {TotalDesDépôts,-34:c}|\n" +
                   $"[LRB] |                                                       |\n" +
                   $"[LRB] | ======================================================|\n";
        }


        public string DescriptionDesComptes()
        {
            return string.Join("\n", _comptes.Select(c =>
                $"\n[LRB]  #{c.Numéro,-5} {c.Détenteur,-20} {c.Solde,10:C}  {c.Statut}\n"));
        }

        public string DescriptionComplète()
        {
            return DescriptionSommaire() + DescriptionDesComptes();
        }


        public Compte CréerCompte(string détenteur)
        {
            if (string.IsNullOrWhiteSpace(nameof(détenteur)))
                ArgumentNullException.ThrowIfNullOrWhiteSpace(nameof(détenteur));

            var nouveau = new Compte(_prochainNumero, détenteur);
            _comptes.Add(nouveau);
            _comptes.Sort((a, b) => a.Numéro.CompareTo(b.Numéro));
            _prochainNumero++;
            return nouveau;
        }


        public Compte ChercherCompte(int numero)
        {
            if (numero <= 0)
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numero);
            return _comptes.FirstOrDefault(c => c.Numéro == numero);
        }

        public bool PeutSupprimerCompte(Compte compte)
        {
            if (compte == null)
                ArgumentNullException.ThrowIfNull(compte);
            if (!_comptes.Contains(compte))
                return false;

            return !compte.EstGelé && compte.Solde == 0;
        }

        public bool PeutSupprimerCompte(int numero)
        {
            if (numero <= 0)
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numero);

            var compte = ChercherCompte(numero);
            return compte != null && PeutSupprimerCompte(compte);
        }

        public void SupprimerCompte(Compte compte)
        {
            if (compte == null)
                ArgumentOutOfRangeException.ThrowIfNullOrEmpty(nameof(compte));
            if (!PeutSupprimerCompte(compte))
                ArgumentOutOfRangeException.ThrowIfNullOrEmpty(nameof(compte));
            _comptes.Remove(compte);
        }

        public void SupprimerCompte(int numero)
        {
            if (numero <= 0)
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numero);

            var compte = ChercherCompte(numero);
            if (compte == null)
                ArgumentOutOfRangeException.ThrowIfNullOrEmpty(nameof(compte));
            SupprimerCompte(compte);
        }

    }
}
