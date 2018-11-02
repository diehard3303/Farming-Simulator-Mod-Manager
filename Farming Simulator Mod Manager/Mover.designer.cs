namespace Farming_Simulator_Mod_Manager {
    partial class Mover {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mover));
            this.lstRepo = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstGroups = new System.Windows.Forms.ListBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.addModHashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstRepo
            // 
            this.lstRepo.ContextMenuStrip = this.contextMenuStrip1;
            this.lstRepo.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRepo.FormattingEnabled = true;
            this.lstRepo.ItemHeight = 22;
            this.lstRepo.Location = new System.Drawing.Point(12, 12);
            this.lstRepo.Name = "lstRepo";
            this.lstRepo.Size = new System.Drawing.Size(250, 400);
            this.lstRepo.Sorted = true;
            this.lstRepo.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyModToolStripMenuItem,
            this.addModHashToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
            // 
            // copyModToolStripMenuItem
            // 
            this.copyModToolStripMenuItem.Name = "copyModToolStripMenuItem";
            this.copyModToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyModToolStripMenuItem.Text = "Copy Mod";
            this.copyModToolStripMenuItem.Click += new System.EventHandler(this.copyModToolStripMenuItem_Click);
            // 
            // lstGroups
            // 
            this.lstGroups.ContextMenuStrip = this.contextMenuStrip2;
            this.lstGroups.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstGroups.FormattingEnabled = true;
            this.lstGroups.ItemHeight = 22;
            this.lstGroups.Location = new System.Drawing.Point(293, 12);
            this.lstGroups.Name = "lstGroups";
            this.lstGroups.Size = new System.Drawing.Size(250, 400);
            this.lstGroups.TabIndex = 1;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveHereToolStripMenuItem,
            this.createFolderToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(145, 48);
            // 
            // moveHereToolStripMenuItem
            // 
            this.moveHereToolStripMenuItem.Name = "moveHereToolStripMenuItem";
            this.moveHereToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.moveHereToolStripMenuItem.Text = "Move Here";
            this.moveHereToolStripMenuItem.Click += new System.EventHandler(this.moveHereToolStripMenuItem_Click);
            // 
            // createFolderToolStripMenuItem
            // 
            this.createFolderToolStripMenuItem.Name = "createFolderToolStripMenuItem";
            this.createFolderToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.createFolderToolStripMenuItem.Text = "Create Folder";
            this.createFolderToolStripMenuItem.Click += new System.EventHandler(this.createFolderToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(468, 451);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addModHashToolStripMenuItem
            // 
            this.addModHashToolStripMenuItem.Name = "addModHashToolStripMenuItem";
            this.addModHashToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addModHashToolStripMenuItem.Text = "Add Mod / Hash";
            this.addModHashToolStripMenuItem.Click += new System.EventHandler(this.addModHashToolStripMenuItem_Click);
            // 
            // Mover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 486);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstGroups);
            this.Controls.Add(this.lstRepo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mover";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mover";
            this.Load += new System.EventHandler(this.Mover_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstRepo;
        private System.Windows.Forms.ListBox lstGroups;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyModToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem moveHereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addModHashToolStripMenuItem;
    }
}