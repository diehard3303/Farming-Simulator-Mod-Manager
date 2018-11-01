using System;
using System.Windows.Forms;
using Extensions;

namespace Farming_Simulator_Mod_Manager {
    /// <summary>
    /// 
    /// </summary>
    public partial class FolderBox : Form {
        /// <summary>
        /// 
        /// </summary>
        public FolderBox() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Vars.FolderName += txtFlder.Text;
            FolderCreator.CreatePublicFolders(Vars.FolderName);
            if (Vars.FolderName.IsNullOrEmpty()) return;
            Dispose();
        }
    }
}
