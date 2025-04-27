namespace WinFormsSimulerCompte
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBoxDonnes = new GroupBox();
            checkBoxGele = new CheckBox();
            textBoxDetenteur = new TextBox();
            textBoxSolde = new TextBox();
            textBoxNumero = new TextBox();
            labelDetenteur = new Label();
            labelSolde = new Label();
            labelNumero = new Label();
            groupBoxMontant = new GroupBox();
            radioButton100 = new RadioButton();
            radioButton1 = new RadioButton();
            radioButton10 = new RadioButton();
            radioButton0 = new RadioButton();
            buttonRandom = new Button();
            buttonReinitialiser = new Button();
            numericUpDownMontant = new NumericUpDown();
            buttonDeposer = new Button();
            buttonReset = new Button();
            buttonVider = new Button();
            buttonRetirer = new Button();
            textBoxLog = new TextBox();
            groupBoxDonnes.SuspendLayout();
            groupBoxMontant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMontant).BeginInit();
            SuspendLayout();
            // 
            // groupBoxDonnes
            // 
            groupBoxDonnes.Controls.Add(checkBoxGele);
            groupBoxDonnes.Controls.Add(textBoxDetenteur);
            groupBoxDonnes.Controls.Add(textBoxSolde);
            groupBoxDonnes.Controls.Add(textBoxNumero);
            groupBoxDonnes.Controls.Add(labelDetenteur);
            groupBoxDonnes.Controls.Add(labelSolde);
            groupBoxDonnes.Controls.Add(labelNumero);
            groupBoxDonnes.Location = new Point(27, 23);
            groupBoxDonnes.Name = "groupBoxDonnes";
            groupBoxDonnes.Size = new Size(460, 233);
            groupBoxDonnes.TabIndex = 0;
            groupBoxDonnes.TabStop = false;
            groupBoxDonnes.Text = "Données du compte";
            // 
            // checkBoxGele
            // 
            checkBoxGele.AutoSize = true;
            checkBoxGele.Location = new Point(336, 46);
            checkBoxGele.Name = "checkBoxGele";
            checkBoxGele.Size = new Size(94, 36);
            checkBoxGele.TabIndex = 6;
            checkBoxGele.Text = "Gelé";
            checkBoxGele.UseVisualStyleBackColor = true;
            checkBoxGele.CheckedChanged += checkBoxGele_CheckedChanged;
            // 
            // textBoxDetenteur
            // 
            textBoxDetenteur.Location = new Point(146, 105);
            textBoxDetenteur.Name = "textBoxDetenteur";
            textBoxDetenteur.Size = new Size(284, 39);
            textBoxDetenteur.TabIndex = 5;
            textBoxDetenteur.KeyDown += textBoxDetenteur_KeyDown;
            // 
            // textBoxSolde
            // 
            textBoxSolde.Location = new Point(146, 167);
            textBoxSolde.Name = "textBoxSolde";
            textBoxSolde.ReadOnly = true;
            textBoxSolde.Size = new Size(284, 39);
            textBoxSolde.TabIndex = 4;
            textBoxSolde.TextChanged += textBoxSolde_TextChanged;
            // 
            // textBoxNumero
            // 
            textBoxNumero.Location = new Point(146, 43);
            textBoxNumero.Name = "textBoxNumero";
            textBoxNumero.ReadOnly = true;
            textBoxNumero.Size = new Size(176, 39);
            textBoxNumero.TabIndex = 3;
            textBoxNumero.TextChanged += textBoxNumero_TextChanged;
            // 
            // labelDetenteur
            // 
            labelDetenteur.AutoSize = true;
            labelDetenteur.Location = new Point(6, 108);
            labelDetenteur.Name = "labelDetenteur";
            labelDetenteur.Size = new Size(134, 32);
            labelDetenteur.TabIndex = 2;
            labelDetenteur.Text = "Détenteur :";
            // 
            // labelSolde
            // 
            labelSolde.AutoSize = true;
            labelSolde.Location = new Point(54, 170);
            labelSolde.Name = "labelSolde";
            labelSolde.Size = new Size(86, 32);
            labelSolde.TabIndex = 1;
            labelSolde.Text = "Solde :";
            // 
            // labelNumero
            // 
            labelNumero.AutoSize = true;
            labelNumero.Location = new Point(26, 46);
            labelNumero.Name = "labelNumero";
            labelNumero.Size = new Size(114, 32);
            labelNumero.TabIndex = 0;
            labelNumero.Text = "Numéro :";
            // 
            // groupBoxMontant
            // 
            groupBoxMontant.Controls.Add(radioButton100);
            groupBoxMontant.Controls.Add(radioButton1);
            groupBoxMontant.Controls.Add(radioButton10);
            groupBoxMontant.Controls.Add(radioButton0);
            groupBoxMontant.Controls.Add(buttonRandom);
            groupBoxMontant.Controls.Add(buttonReinitialiser);
            groupBoxMontant.Controls.Add(numericUpDownMontant);
            groupBoxMontant.Location = new Point(539, 23);
            groupBoxMontant.Name = "groupBoxMontant";
            groupBoxMontant.Size = new Size(402, 233);
            groupBoxMontant.TabIndex = 1;
            groupBoxMontant.TabStop = false;
            groupBoxMontant.Text = "Montant LRB";
            // 
            // radioButton100
            // 
            radioButton100.AutoSize = true;
            radioButton100.Location = new Point(198, 176);
            radioButton100.Name = "radioButton100";
            radioButton100.Size = new Size(162, 36);
            radioButton100.TabIndex = 13;
            radioButton100.TabStop = true;
            radioButton100.Text = "100 à 1000";
            radioButton100.UseVisualStyleBackColor = true;
            radioButton100.CheckedChanged += radioButton100_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(198, 84);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(110, 36);
            radioButton1.TabIndex = 12;
            radioButton1.TabStop = true;
            radioButton1.Text = "1 à 10";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton10
            // 
            radioButton10.AutoSize = true;
            radioButton10.Location = new Point(198, 130);
            radioButton10.Name = "radioButton10";
            radioButton10.Size = new Size(136, 36);
            radioButton10.TabIndex = 11;
            radioButton10.TabStop = true;
            radioButton10.Text = "10 à 100";
            radioButton10.UseVisualStyleBackColor = true;
            radioButton10.CheckedChanged += radioButton10_CheckedChanged;
            // 
            // radioButton0
            // 
            radioButton0.AutoSize = true;
            radioButton0.Location = new Point(198, 38);
            radioButton0.Name = "radioButton0";
            radioButton0.Size = new Size(97, 36);
            radioButton0.TabIndex = 10;
            radioButton0.TabStop = true;
            radioButton0.Text = "0 à 1";
            radioButton0.UseVisualStyleBackColor = true;
            radioButton0.CheckedChanged += radioButton0_CheckedChanged;
            // 
            // buttonRandom
            // 
            buttonRandom.Location = new Point(16, 164);
            buttonRandom.Name = "buttonRandom";
            buttonRandom.Size = new Size(111, 38);
            buttonRandom.TabIndex = 9;
            buttonRandom.Text = "Random";
            buttonRandom.UseVisualStyleBackColor = true;
            buttonRandom.Click += buttonRandom_Click;
            // 
            // buttonReinitialiser
            // 
            buttonReinitialiser.Location = new Point(16, 105);
            buttonReinitialiser.Name = "buttonReinitialiser";
            buttonReinitialiser.Size = new Size(111, 38);
            buttonReinitialiser.TabIndex = 8;
            buttonReinitialiser.Text = "0.01";
            buttonReinitialiser.UseVisualStyleBackColor = true;
            buttonReinitialiser.Click += buttonReinitialiser_Click;
            // 
            // numericUpDownMontant
            // 
            numericUpDownMontant.DecimalPlaces = 2;
            numericUpDownMontant.ForeColor = Color.Black;
            numericUpDownMontant.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownMontant.Location = new Point(16, 44);
            numericUpDownMontant.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownMontant.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownMontant.Name = "numericUpDownMontant";
            numericUpDownMontant.ReadOnly = true;
            numericUpDownMontant.Size = new Size(111, 39);
            numericUpDownMontant.TabIndex = 7;
            numericUpDownMontant.TextAlign = HorizontalAlignment.Center;
            numericUpDownMontant.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownMontant.ValueChanged += numericUpDownMontant_ValueChanged;
            // 
            // buttonDeposer
            // 
            buttonDeposer.Location = new Point(40, 298);
            buttonDeposer.Name = "buttonDeposer";
            buttonDeposer.Size = new Size(150, 46);
            buttonDeposer.TabIndex = 2;
            buttonDeposer.Text = "Déposer";
            buttonDeposer.UseVisualStyleBackColor = true;
            buttonDeposer.Click += buttonDeposer_Click;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(754, 298);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(150, 46);
            buttonReset.TabIndex = 3;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // buttonVider
            // 
            buttonVider.Location = new Point(516, 298);
            buttonVider.Name = "buttonVider";
            buttonVider.Size = new Size(150, 46);
            buttonVider.TabIndex = 4;
            buttonVider.Text = "Vider";
            buttonVider.UseVisualStyleBackColor = true;
            buttonVider.Click += buttonVider_Click;
            // 
            // buttonRetirer
            // 
            buttonRetirer.Location = new Point(278, 298);
            buttonRetirer.Name = "buttonRetirer";
            buttonRetirer.Size = new Size(150, 46);
            buttonRetirer.TabIndex = 5;
            buttonRetirer.Text = "Retirer";
            buttonRetirer.UseVisualStyleBackColor = true;
            buttonRetirer.Click += buttonRetirer_Click;
            // 
            // textBoxLog
            // 
            textBoxLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxLog.Location = new Point(40, 398);
            textBoxLog.Multiline = true;
            textBoxLog.Name = "textBoxLog";
            textBoxLog.Size = new Size(864, 128);
            textBoxLog.TabIndex = 6;
            textBoxLog.TextChanged += textBoxLog_TextChanged;
            textBoxLog.DoubleClick += textBoxLog_DoubleClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 538);
            Controls.Add(textBoxLog);
            Controls.Add(buttonRetirer);
            Controls.Add(buttonVider);
            Controls.Add(buttonReset);
            Controls.Add(buttonDeposer);
            Controls.Add(groupBoxMontant);
            Controls.Add(groupBoxDonnes);
            Name = "Form1";
            Text = "Simulateur de Compte -- Lili-Rose B.";
            groupBoxDonnes.ResumeLayout(false);
            groupBoxDonnes.PerformLayout();
            groupBoxMontant.ResumeLayout(false);
            groupBoxMontant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMontant).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private GroupBox groupBoxDonnes;
        private GroupBox groupBoxMontant;
        private TextBox textBoxSolde;
        private TextBox textBoxNumero;
        private Label labelDetenteur;
        private Label labelSolde;
        private Label labelNumero;
        private CheckBox checkBoxGele;
        private TextBox textBoxDetenteur;
        private Button buttonDeposer;
        private Button buttonReset;
        private Button buttonVider;
        private Button buttonRetirer;
        private NumericUpDown numericUpDownMontant;
        private TextBox textBoxLog;
        private RadioButton radioButton100;
        private RadioButton radioButton1;
        private RadioButton radioButton10;
        private RadioButton radioButton0;
        private Button buttonRandom;
        private Button buttonReinitialiser;
    }
}
