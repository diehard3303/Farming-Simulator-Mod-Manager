// ***********************************************************************
// Assembly         : ModMaker1.0
// Author           : TJ
// Created          : 05-06-2015
//
// Last Modified By : TJ
// Last Modified On : 05-06-2015
// ***********************************************************************
//
//  Copyright (c) DieHard Development 2003-2015. All rights reserved.
//
// Released under the FreeBSD  license
//Redistribution and use in source and binary forms, with or without
//modification, are permitted provided that the following conditions are met:
//
//1. Redistributions of source code must retain the above copyright notice, this
// list of conditions and the following disclaimer.
//2. Redistributions in binary form must reproduce the above copyright notice,
// this list of conditions and the following disclaimer in the documentation
// and/or other materials provided with the distribution.
//THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
//ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
//WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
//DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
//ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
//(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
//LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
//ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
//(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
//SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
//The views and conclusions contained in the software and documentation are those
//of the authors and should not be interpreted as representing official policies,
//either expressed or implied, of the FreeBSD Project.
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Extensions;

namespace Farming_Simulator_Mod_Manager {
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:System.Windows.Forms.Form" />
    public partial class Specials : Form {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <param name="lpExistingFileName"></param>
        /// <param name="lpSecurityAttributes"></param>
        /// <returns></returns>
        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern bool CreateHardLink(
            string lpFileName,
            string lpExistingFileName,
            IntPtr lpSecurityAttributes
        );

        /// <summary>
        /// Initializes a new instance of the <see cref="Specials"/> class.
        /// </summary>
        public Specials() {
            InitializeComponent();
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Farming_Simulator_Mod_Manager.Specials" /> class.
        /// </summary>
        /// <param name="components">The components.</param>
        /// <param name="lstSpecials">The LST specials.</param>
        /// <param name="contextMenuStrip1">The context menu strip1.</param>
        /// <param name="removeModToolStripMenuItem">The remove mod tool strip menu item.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// components
        /// or
        /// lstSpecials
        /// or
        /// contextMenuStrip1
        /// or
        /// removeModToolStripMenuItem
        /// </exception>
        public Specials(IContainer components, ListBox lstSpecials, ContextMenuStrip contextMenuStrip1,
            ToolStripMenuItem removeModToolStripMenuItem) {
            this.components = components ?? throw new ArgumentNullException(nameof(components));
            this.lstSpecials = lstSpecials ?? throw new ArgumentNullException(nameof(lstSpecials));
            this.contextMenuStrip1 = contextMenuStrip1 ?? throw new ArgumentNullException(nameof(contextMenuStrip1));
            this.removeModToolStripMenuItem = removeModToolStripMenuItem ??
                                              throw new ArgumentNullException(nameof(removeModToolStripMenuItem));
        }

        private Dictionary<string, string> _dic;
        private Dictionary<string, string> _specials;
        private string _fileName;

        private void Specials_Load(object sender, EventArgs e) {
            InitSpecials();
        }

        private void InitSpecials() {
            var reg = new RegWork(true);
            _dic = Vars.Dict;
            foreach (var v in _dic) {
                lstSpecials.Items.Add(v.Key);
            }

            var gi = new GameInfo();
            var gam = gi.GetGame();
            IEnumerable<string> lst = null;

            switch (gam) {
                case "FS11":
                    var pth = reg.Read(Fs11RegKeys.FS11_BACKUP) + @"Specials\";
                    if (!pth.FolderExists()) return;
                    lst = GetFilesFolders.GetFiles(pth, "*.xml");
                    break;
                case "FS13":
                    pth = reg.Read(Fs13RegKeys.FS13_BACKUP) + @"Specials\";
                    if (!pth.FolderExists()) return;
                    lst = GetFilesFolders.GetFiles(pth, "*.xml");
                    break;
                case "FS15":
                    pth = reg.Read(Fs15RegKeys.FS15_BACKUP) + @"Specials\";
                    if (!pth.FolderExists()) return;
                    lst = GetFilesFolders.GetFiles(pth, "*.xml");
                    break;
                case "FS17":
                    pth = reg.Read(Fs17RegKeys.FS17_BACKUP) + @"Specials\";
                    if (!pth.FolderExists()) return;
                    lst = GetFilesFolders.GetFiles(pth, "*.xml");
                    break;
                case "FS19":
                    pth = reg.Read(FS19RegKeys.FS19_BACKUP) + @"Specials\";
                    if (!pth.FolderExists()) return;
                    lst = GetFilesFolders.GetFiles(pth, "*.xml");
                    break;
            }

            lstArchive.Items.Clear();
            lstChange.Items.Clear();
            if (lst.IsNull()) return;
            foreach (var v in lst) {
                lstArchive.Items.Add(v.GetFileName());
                lstChange.Items.Add(v.GetFileName());
            }

            label3.Text = @"FileCount: " + lstChange.Items.Count;
        }

        private void removeModToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstSpecials.SelectedItem.IsNull()) return;
            var mod = lstSpecials.SelectedItem.ToString();
            _dic.Remove(mod);
            lstSpecials.Items.Clear();

            foreach (var v in _dic) {
                lstSpecials.Items.Add(v.Key);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            if (txtFileName.Text.IsNullOrEmpty()) {
                MsgBx.Msg("You must supply a name for the special.", "Specials");
                return;
            }

            var reg = new RegWork(true);
            var gi = new GameInfo();
            var gam = gi.GetGame();
            string pth = null;

            switch (gam) {
                case "FS11":
                    pth = reg.Read(Fs11RegKeys.FS11_BACKUP) + @"Specials\" + txtFileName.Text.Trim() + ".xml";
                    Directory.CreateDirectory(reg.Read(Fs11RegKeys.FS11_BACKUP) + @"Specials\");
                    break;
                case "FS13":
                    pth = reg.Read(Fs13RegKeys.FS13_BACKUP) + @"Specials\" + txtFileName.Text.Trim() + ".xml";
                    Directory.CreateDirectory(reg.Read(Fs13RegKeys.FS13_BACKUP) + @"Specials\");
                    break;
                case "FS15":
                    pth = reg.Read(Fs15RegKeys.FS15_BACKUP) + @"Specials\" + txtFileName.Text.Trim() + ".xml";
                    Directory.CreateDirectory(reg.Read(Fs15RegKeys.FS15_BACKUP) + @"Specials\");
                    break;
                case "FS17":
                    pth = reg.Read(Fs17RegKeys.FS17_BACKUP) + @"Specials\" + txtFileName.Text.Trim() + ".xml";
                    Directory.CreateDirectory(reg.Read(Fs17RegKeys.FS17_BACKUP) + @"Specials\");
                    break;
                case "FS19":
                    pth = reg.Read(FS19RegKeys.FS19_BACKUP) + @"Specials\" + txtFileName.Text.Trim() + ".xml";
                    Directory.CreateDirectory(reg.Read(FS19RegKeys.FS19_BACKUP) + @"Specials\");
                    break;
            }

            Serializer.SerializeDictionary(pth, _dic);
            txtFileName.Text = "";
            InitSpecials();
        }

        private void button3_Click(object sender, EventArgs e) {
            Dispose();
        }

        private void addFileToolStripMenuItem_Click(object sender, EventArgs e) {
            var fullList = Utils.CompleteSortedList;
            var ofd = new OpenFileDialog {Filter = @"zip files (*.zip)|*.zip", CheckFileExists = true};
            ofd.ShowDialog();
            var tmp = ofd.SafeFileName;
            if (tmp.IsNullOrEmpty()) return;

            fullList.TryGetValue(tmp ?? throw new InvalidOperationException(), out var fnd);
            _specials.Add(tmp, fnd);
            Utils.WriteSpecials(_specials, _fileName);
            lstFiles.Items.Clear();
            foreach (var special in _specials) {
                lstFiles.Items.Add(special.Key);
            }
        }

        private void deleteFileToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstFiles.SelectedItem.IsNull()) return;
            var delFile = lstFiles.SelectedItem.ToString();
            if (_specials.ContainsKey(delFile)) {
                _specials.Remove(delFile);
                Utils.WriteSpecials(_specials, _fileName);
            }

            lstFiles.Items.Clear();
            foreach (var special in _specials) {
                lstFiles.Items.Add(special.Key);
            }
        }

        private void lstChange_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstChange.SelectedItem.IsNull()) return;
            _fileName = lstChange.SelectedItem.ToString();
            _specials = Utils.GetSpecials(_fileName);
            lstFiles.Items.Clear();
            foreach (var v in _specials) {
                lstFiles.Items.Add(v.Key);
            }

            label5.Text = @"FileCount: " + lstFiles.Items.Count;
        }

        private void addSpecialsToCurrentProfileToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstArchive.SelectedItem.IsNull()) return;
            var spc = lstArchive.SelectedItem.ToString();
            var reg = new RegWork(true);
            var gi = new GameInfo();
            var gam = gi.GetGame();
            var dic = new Dictionary<string, string>();
            //var dic2 = new Dictionary<string, string>();
            var pro = reg.Read(RegKeys.CURRENT_PROFILE);
            var profile = string.Empty;

            switch (gam) {
                case "FS11":
                    dic = Serializer.DeserializeDictionary(reg.Read(Fs11RegKeys.FS11_BACKUP) + @"\Specials\" + spc);
                    // dic2 = Serializer.DeserializeDictionary(Vars.SortedFileListCompletePath());
                    profile = reg.Read(Fs11RegKeys.FS11_PROFILES) + pro + @"\";
                    break;
                case "FS13":
                    dic = Serializer.DeserializeDictionary(reg.Read(Fs13RegKeys.FS13_BACKUP) + @"\Specials\" + spc);
                    // dic2 = Serializer.DeserializeDictionary(Vars.SortedFileListCompletePath());
                    profile = reg.Read(Fs13RegKeys.FS13_PROFILES) + pro + @"\";
                    break;
                case "FS15":
                    dic = Serializer.DeserializeDictionary(reg.Read(Fs15RegKeys.FS15_BACKUP) + @"\Specials\" + spc);
                    // dic2 = Serializer.DeserializeDictionary(Vars.SortedFileListCompletePath());
                    profile = reg.Read(Fs15RegKeys.FS15_PROFILES) + pro + @"\";
                    break;
                case "FS17":
                    dic = Serializer.DeserializeDictionary(reg.Read(Fs17RegKeys.FS17_BACKUP) + @"\Specials\" + spc);
                    // dic2 = Serializer.DeserializeDictionary(Vars.SortedFileListCompletePath());
                    profile = reg.Read(Fs17RegKeys.FS17_PROFILES) + pro + @"\";
                    break;
                case "FS19":
                    dic = Serializer.DeserializeDictionary(reg.Read(FS19RegKeys.FS19_BACKUP) + @"\Specials\" + spc);
                    //dic2 = Serializer.DeserializeDictionary(Vars.SortedFileListCompletePath());
                    profile = reg.Read(FS19RegKeys.FS19_PROFILES) + pro + @"\";
                    break;
            }

            foreach (var v in dic) {
                var tmp = profile + v.Key;
                if (tmp.FileExists()) continue;
                //CreateHardLink(tmp, v.Value + @"\" + v.Key, IntPtr.Zero);
                Working.CreateLink(tmp, v.Value + @"\" + v.Key);
            }

            var lc = new ListCreator();
            lc.CreateSortedLists();

            MsgBx.Msg("Specials have been added to Profile", "Specials");
        }

        private void deleteSpecialsFromCurrentProfileToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstArchive.SelectedItem.IsNull()) return;
            var spc = lstArchive.SelectedItem.ToString();
            var reg = new RegWork(true);
            var gi = new GameInfo();
            var gam = gi.GetGame();
            var dic = Utils.GetSpecials(spc);
            var pro = reg.Read(RegKeys.CURRENT_PROFILE);
            var profile = string.Empty;

            switch (gam) {
                case "FS11":
                    profile = reg.Read(Fs11RegKeys.FS11_PROFILES) + pro + @"\";
                    break;
                case "FS13":
                    profile = reg.Read(Fs13RegKeys.FS13_PROFILES) + pro + @"\";
                    break;
                case "FS15":
                    profile = reg.Read(Fs15RegKeys.FS15_PROFILES) + pro + @"\";
                    break;
                case "FS17":
                    profile = reg.Read(Fs17RegKeys.FS17_PROFILES) + pro + @"\";
                    break;
                case "FS19":
                    profile = reg.Read(FS19RegKeys.FS19_PROFILES) + pro + @"\";
                    break;
            }
            var profDic = profile + pro + ".xml";
            var pDic = Serializer.DeserializeDictionary(profDic);
            foreach (var v in dic) {
                var tmp = profile + v.Key;
                if (!tmp.FileExists()) continue;
                DeleteFiles.DeleteFilesOrFolders(tmp, false);
                pDic.Remove(v.Key);
            }
            Serializer.SerializeDictionary(profDic, pDic);
            var lc = new ListCreator();
            lc.CreateSortedLists();

            MsgBx.Msg("Specials have been removed from Profile", "Specials");
        }

        private void deleteSpecialsFilexmlToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstArchive.SelectedItem.IsNull()) return;
            var fi = lstArchive.SelectedItem.ToString();
            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            string tmp = null;

            switch (gam) {
                case "FS11":
                    tmp  = reg.Read(Fs11RegKeys.FS11_BACKUP) + @"Specials\" + fi;
                    break;
                case "FS13":
                    tmp = reg.Read(Fs13RegKeys.FS13_BACKUP) + @"Specials\" + fi;
                    break;
                case "FS15":
                    tmp = reg.Read(Fs15RegKeys.FS15_BACKUP) + @"Specials\" + fi;
                    break;
                case "FS17":
                    tmp = reg.Read(Fs17RegKeys.FS17_BACKUP) + @"Specials\" + fi;
                    break;
                case "FS19":
                    tmp = reg.Read(FS19RegKeys.FS19_BACKUP) + @"Specials\" + fi;
                    break;
            }

            if (!tmp.FileExists()) return;
            DeleteFiles.DeleteFilesOrFolders(tmp);
            InitSpecials();
        }

        private void verifySpecialsToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstArchive.SelectedItem.IsNull()) return;
            Working.VerifyMods(lstArchive.SelectedItem.ToString());
        }
    }
}