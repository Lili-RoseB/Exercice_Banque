using BanqueLib;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text.Json;

namespace WinFormsSimulerCompte
{
    public partial class Form1 : Form
    {
        private Compte _compte;
        private Random _random = new Random();
        private bool operationEffectuee = false;

        private readonly string configPath = "config.json";
        private Configuration config;
        public Form1(Compte compte)
        {
            InitializeComponent();
            _compte = compte;
            InitialiserChamps();

        }
        private void InitialiserChamps()
        {
            textBoxNumero.Text = _compte.Num�ro.ToString();
            textBoxDetenteur.Text = _compte.D�tenteur;
            textBoxSolde.Text = _compte.Solde.ToString();
            checkBoxGele.Checked = _compte.Statut == StatutCompte.Gel�;
        }

        private void textBoxNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxDetenteur_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (_compte.D�tenteur != textBoxDetenteur.Text))
            {
                DialogResult result = MessageBox.Show("Le nom du d�tenteur a �t� modifi�",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    _compte.SetD�tenteur(textBoxDetenteur.Text);
                    AjouterLog($"Nom du d�tenteur modifi� par {textBoxDetenteur.Text}");
                    operationEffectuee = true;
                    MettreAJourEtatDesBoutons();
                    Sauvegarder();

                }
                else
                {
                    textBoxDetenteur.Text = _compte.D�tenteur;
                }
            }
           
        }

        private void textBoxSolde_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxGele_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGele.Checked)
            {
                if (_compte.Statut != StatutCompte.Gel�)
                {
                    _compte.Geler();
                    buttonDeposer.Enabled = false;
                    buttonRetirer.Enabled = false;
                    buttonVider.Enabled = false;
                    buttonReset.Enabled = false;
                    AjouterLog("Gel�");
                    MettreAJourEtatDesBoutons();

                }
            }
            else
            {
                if (_compte.Statut != StatutCompte.OK)
                {
                    _compte.D�geler();
                    buttonDeposer.Enabled = true;
                    buttonRetirer.Enabled = true;
                    buttonVider.Enabled = true;
                    buttonReset.Enabled = true;
                    operationEffectuee = true;
                    AjouterLog("D�gel�");
                    MettreAJourEtatDesBoutons();
                }
            }

            InitialiserChamps();
            Sauvegarder();
        }

        private void numericUpDownMontant_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonReinitialiser_Click(object sender, EventArgs e)
        {
            decimal montant = 0.01M;
            numericUpDownMontant.Value = montant;
            
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            decimal montant = Math.Round((decimal)_random.NextDouble() * 99 + 1, 2);
            numericUpDownMontant.Value = montant;
        }

        private void radioButton0_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton0.Checked)
            {
                decimal montant = Math.Round((decimal)_random.NextDouble(), 2);
                numericUpDownMontant.Value = montant;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                decimal montant = Math.Round((decimal)(_random.NextDouble() * 9 + 1), 2); 
                numericUpDownMontant.Value = montant;
            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked)
            {
                decimal montant = Math.Round((decimal)(_random.NextDouble() * 90 + 10), 2);
                numericUpDownMontant.Value = montant;
            }
        }

        private void radioButton100_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton100.Checked)
            {
                decimal montant = Math.Round((decimal)(_random.NextDouble() * 900 + 100), 2); 
                numericUpDownMontant.Value = montant;
            }
        }

        private void buttonDeposer_Click(object sender, EventArgs e)
        {
            decimal montant = numericUpDownMontant.Value;
            if (_compte.PeutD�poser(montant))
            {
                _compte.D�poser(montant);
                AjouterLog($"D�p�t de {montant:C2}");
                operationEffectuee = true;
                MettreAJourEtatDesBoutons();
                Sauvegarder();
            }
        }

        private void buttonRetirer_Click(object sender, EventArgs e)
        {
            decimal montant = numericUpDownMontant.Value;

            if (_compte.PeutRetirer(montant))
            {
                if(_compte.Solde >= montant)
                {
                    _compte.Retirer(montant);
                    AjouterLog($"Retrait de {montant:C2}");
                    operationEffectuee = true;

                }
                else
                {
                    MessageBox.Show("Fonds insuffisants.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            MettreAJourEtatDesBoutons();
            Sauvegarder();
        }

        private void buttonVider_Click(object sender, EventArgs e)
        {
            decimal montantVid� = _compte.Solde;
            _compte.Vider();
            AjouterLog($"Retrait complet {montantVid�:C2}");
            operationEffectuee = true;
            MettreAJourEtatDesBoutons();
            Sauvegarder();
           
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if(operationEffectuee)
            {
                DialogResult result = MessageBox.Show("Voulez-vous effacer la simulation?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    textBoxNumero.Text = _compte.Num�ro.ToString();
                    textBoxDetenteur.Text = _compte.D�tenteur;

                    _compte.Vider();
                    decimal montant = Math.Round((decimal)_random.NextDouble() * 99 + 1, 2);
                    
                    _compte.D�poser(montant);
                    textBoxSolde.Text = _compte.Solde.ToString("C2");

                    checkBoxGele.Checked = _compte.Statut == StatutCompte.Gel�;
                    numericUpDownMontant.Value = 0.01m;
                    textBoxLog.Clear();

                    operationEffectuee = false;
                    Sauvegarder();
                    MettreAJourEtatDesBoutons();

                }
                else
                {
                    textBoxSolde.Text = _compte.Solde.ToString("C2");

                }
            }
            else
            {
                buttonReset.Enabled = false;
            }
            
        }

        private void textBoxLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLog_DoubleClick(object sender, EventArgs e)
        {
            if (textBoxLog.Text.Length == 0) { return; }
            if (MessageBox.Show("Voulez vous effacer le log?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                textBoxLog.Text = "";
            }
        }

        private void AjouterLog(string message)
        {
            textBoxLog.AppendText($" [LRB] {message}{Environment.NewLine}");
        }

        private void Sauvegarder()
        {
            InitialiserChamps();
            File.WriteAllText("Lili-Rose_Blouin.json", JsonSerializer.Serialize(_compte, new JsonSerializerOptions { WriteIndented = true }));
        }

        private void MettreAJourEtatDesBoutons()
        {
            decimal montant = numericUpDownMontant.Value;

            buttonDeposer.Enabled = _compte.PeutD�poser(montant);


            buttonRetirer.Enabled = _compte.PeutRetirer(montant) && _compte.Solde >= montant; ;

            buttonVider.Enabled = _compte.PeutVider();

            buttonReset.Enabled = operationEffectuee || _compte.EstGel�;
        }
    }

}
