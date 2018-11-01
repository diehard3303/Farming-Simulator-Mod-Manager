namespace Farming_Simulator_Mod_Manager {
    partial class Creation {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rbCreateProfile = new System.Windows.Forms.RadioButton();
            this.rbCreateGroup = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(63, 26);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(148, 20);
            this.txtName.TabIndex = 0;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbCreateProfile
            // 
            this.rbCreateProfile.AutoSize = true;
            this.rbCreateProfile.Location = new System.Drawing.Point(33, 73);
            this.rbCreateProfile.Name = "rbCreateProfile";
            this.rbCreateProfile.Size = new System.Drawing.Size(88, 17);
            this.rbCreateProfile.TabIndex = 2;
            this.rbCreateProfile.TabStop = true;
            this.rbCreateProfile.Text = "Create Profile";
            this.rbCreateProfile.UseVisualStyleBackColor = true;
            // 
            // rbCreateGroup
            // 
            this.rbCreateGroup.AutoSize = true;
            this.rbCreateGroup.Location = new System.Drawing.Point(154, 73);
            this.rbCreateGroup.Name = "rbCreateGroup";
            this.rbCreateGroup.Size = new System.Drawing.Size(88, 17);
            this.rbCreateGroup.TabIndex = 3;
            this.rbCreateGroup.TabStop = true;
            this.rbCreateGroup.Text = "Create Group";
            this.rbCreateGroup.UseVisualStyleBackColor = true;
            // 
            // Creation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 151);
            this.Controls.Add(this.rbCreateGroup);
            this.Controls.Add(this.rbCreateProfile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Creation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.RadioButton rbCreateProfile;
        public System.Windows.Forms.RadioButton rbCreateGroup;
    }
}