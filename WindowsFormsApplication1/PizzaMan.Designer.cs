namespace PizzaManDelivery
{
    partial class PizzaMan
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda wsparcia projektanta - nie należy modyfikować
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxStreet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxActual = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textBoxResults = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(170, 66);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Dodaj";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxStreet
            // 
            this.textBoxStreet.Location = new System.Drawing.Point(12, 68);
            this.textBoxStreet.Name = "textBoxStreet";
            this.textBoxStreet.Size = new System.Drawing.Size(95, 20);
            this.textBoxStreet.TabIndex = 3;
            this.textBoxStreet.Text = "Ulica";
            this.textBoxStreet.Enter += new System.EventHandler(this.textBoxStreet_Enter);
            this.textBoxStreet.Leave += new System.EventHandler(this.textBoxStreet_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Adres";
            // 
            // listBoxActual
            // 
            this.listBoxActual.FormattingEnabled = true;
            this.listBoxActual.Location = new System.Drawing.Point(12, 146);
            this.listBoxActual.Name = "listBoxActual";
            this.listBoxActual.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxActual.Size = new System.Drawing.Size(233, 95);
            this.listBoxActual.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Aktualne adresy:";
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(170, 279);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 11;
            this.buttonAccept.Text = "Zaakceptuj";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Liczba dostawców";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(113, 279);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(47, 20);
            this.textBoxCount.TabIndex = 13;
            this.textBoxCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCount_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(278, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Trasy:";
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(127, 68);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(33, 20);
            this.textBoxNumber.TabIndex = 16;
            this.textBoxNumber.Text = "Nr";
            this.textBoxNumber.Enter += new System.EventHandler(this.textBoxNumber_Enter);
            this.textBoxNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumber_KeyPress);
            this.textBoxNumber.Leave += new System.EventHandler(this.textBoxNumber_Leave);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(170, 247);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 17;
            this.buttonDelete.Text = "Usuń";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // textBoxResults
            // 
            this.textBoxResults.Enabled = false;
            this.textBoxResults.Location = new System.Drawing.Point(281, 68);
            this.textBoxResults.Multiline = true;
            this.textBoxResults.Name = "textBoxResults";
            this.textBoxResults.Size = new System.Drawing.Size(269, 234);
            this.textBoxResults.TabIndex = 18;
            // 
            // PizzaMan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 337);
            this.Controls.Add(this.textBoxResults);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBoxActual);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxStreet);
            this.Controls.Add(this.buttonAdd);
            this.Name = "PizzaMan";
            this.Text = "PizzaMan";
            this.Load += new System.EventHandler(this.PizzaMan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxStreet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxActual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textBoxResults;
    }
}

