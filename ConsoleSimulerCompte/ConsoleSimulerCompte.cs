using System.Numerics;
using System.Text.Json;
using BanqueLib;
Random random = new Random();
var compteInitial = Persistance.Dederialisation();
while (true)
{
    Console.Clear();
    Console.WriteLine(compteInitial.Description());

    Console.WriteLine("""
    

     1 - Modifier détenteur
     2 - Peut déposer
     3 - Peut retirer
     4 - Peut retirer (montant)
     5 - Déposer (montant)
     6 - Retirer (montant)
     7 - Vider
     8 - Geler
     9 - Dégeler
     q - Quitter
     r - reset

     Votre choix, Lili-Rose Blouin ?

    """);

    switch (Console.ReadKey(true).KeyChar)
    {
        case '1':
            string nouveauDétenteur = "Lili-Rose B. " + new Random().Next(1, 100);
            compteInitial.SetDétenteur(nouveauDétenteur);

            Console.WriteLine("** Détenteur modifié pour : " + nouveauDétenteur + " **");
            Persistance.Serialisation(compteInitial);
            break;
        case '2':
            {
                if(compteInitial.PeutDéposer())
                {
                    Console.WriteLine("** Peut déposer? Oui. **");
                }
                else
                {
                    Console.WriteLine("** Peut déposer? Non. **");
                }
            }
            break;
        case '3':
            {

                if (compteInitial.PeutRetirer())
                {
                    Console.WriteLine("** Peut retirer ? Oui. **");
                }
                else
                {
                    Console.WriteLine("** Peut retirer ? Non. **");
                }
            }
            break;
        case '4': 
            {
                decimal montantAleatoire = (decimal)(random.NextDouble() * (99.99 - 0.01) + 0.01);
                montantAleatoire = Math.Round(montantAleatoire, 2);

                if (compteInitial.PeutRetirer(montantAleatoire))
                {
                    Console.WriteLine($"** Peut retirer {montantAleatoire} $ ? Oui. **");
                }
                else
                {
                    Console.WriteLine($"** Peut retirer {montantAleatoire} $ ? Non. **");
                }

            }
            break;
        case '5': 
            {
                decimal montantAleatoire = (decimal)(random.NextDouble() * (99.99 - 0.01) + 0.01);
                montantAleatoire = Math.Round(montantAleatoire, 2);
                if (compteInitial.PeutDéposer())
                {
                    
                    compteInitial.Déposer(montantAleatoire);
                    Console.WriteLine($"** Dépot de : {montantAleatoire} $ **");
                }
                else
                {
                    Console.WriteLine($"** Impossible de déposer {montantAleatoire} $ **");
                }
                Persistance.Serialisation(compteInitial);
            }
            break;
        case '6': 
            {
                decimal montantAleatoire = (decimal)(random.NextDouble() * (99.99 - 0.01) + 0.01);
                montantAleatoire = Math.Round(montantAleatoire, 2);
                if (compteInitial.PeutRetirer())
                {

                    compteInitial.Retirer(montantAleatoire);
                    Console.WriteLine($"** Retrait de : {montantAleatoire} $ **");
                }
                else
                {
                    Console.WriteLine($"** Impossible de retirer {montantAleatoire} $ **");
                }
                Persistance.Serialisation(compteInitial);
            }
            break;
        case '7': 
            {
                if(compteInitial.PeutVider())
                {
                    decimal solde = compteInitial.Solde;
                    decimal montantVide = compteInitial.Vider();
                    Console.WriteLine($"** Retrait complet de {solde} $ **");
                }
                else
                {
                    Console.WriteLine($"** Impossible de vider un compte vide ou geler **");
                }
                Persistance.Serialisation(compteInitial);
            }
            break;
        case '8':
            {
                if (compteInitial.Statut == StatutCompte.Gelé)
                {
                    Console.WriteLine("** Impossible de geler un compte déja gelé. **");
                }
                else
                {
                    compteInitial.Geler();
                    Console.WriteLine("** Le compte a été gelé. **");
                }
                Persistance.Serialisation(compteInitial);
            }

            break;
        case '9': 
            {
                if (compteInitial.Statut == StatutCompte.OK)
                {
                    Console.WriteLine("** Impossible de dégeler un compte non gelé. **");
                }
                else
                {
                    compteInitial.Dégeler();
                    Console.WriteLine("** Le compte a été dégelé. **");
                }
                Persistance.Serialisation(compteInitial);
            }
            break;
        case 'q':
            Environment.Exit(0); 
            break;
        case 'r':
            {
                int nouveauNumero = random.Next(100, 999);
                var nouveauCompte = new Compte(nouveauNumero, "Lili-Rose B.");

                compteInitial = nouveauCompte;
                Console.WriteLine("Un nouveau compte à été crée");
                Persistance.Serialisation(compteInitial);
            }
            break;
        default:
            Console.WriteLine(" Mauvais choix"); break;
    }
    Console.WriteLine("\n Appuyer sur ENTER pour continuer...");
    Console.ReadLine();
}
static class Persistance
{
    private const string FICHIER = "Compte.json";

    public static Compte Dederialisation()
    {
        if (File.Exists(FICHIER))
        {
            string json = File.ReadAllText(FICHIER);
            return JsonSerializer.Deserialize<Compte>(json)!;
        }
        else
        {
            Random random = new Random();
            return new Compte(random.Next(100, 999), "Lili-Rose B.");
        }
    }

    public static void Serialisation(Compte compte)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(compte, options);
        File.WriteAllText(FICHIER, json);
    }
}
#pragma warning disable S3903 // Types should be defined in named namespaces
static class Utile
{
    public static (string, string?) ExceptMsg(Action action)
    {
        try
        {
            action();
            return ("EXCEPTION attendue", null);
        }
        catch (Exception ex)
        {
            return (ex.GetType().Name, ex.Message);
        }
    }
}