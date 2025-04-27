using System.Text.Json;
using BanqueLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using System.Reflection;

namespace WinFormsSimulerCompte
{
    internal static class Program
    {
        private const string JsonFile = "Lili-Rose_Blouin.json";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();
            Compte compte;

            if (File.Exists(JsonFile))
            {
                string json = File.ReadAllText(JsonFile);
                compte = JsonSerializer.Deserialize<Compte>(json)!;
            }
            else
            {
                Random random = new Random();
                int numero = random.Next(1000, 10000);
                decimal solde = Math.Round((decimal)random.NextDouble() * 99 + 1, 2);

                compte = new Compte(numero, "Lili-Rose Blouin", solde, StatutCompte.OK);

                string json = JsonSerializer.Serialize(compte, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(JsonFile, json);
            }

            Application.Run(new Form1(compte));
        }
    }
}