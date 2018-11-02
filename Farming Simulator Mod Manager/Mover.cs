//
//  Author:
//    DieHard diehard@eclcmail.com
//
//  Copyright (c) 2016, 2007
//
//  All rights reserved.
//
//  Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
//
//     * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in
//       the documentation and/or other materials provided with the distribution.
//     * Neither the name of the [ORGANIZATION] nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
//
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
//  "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
//  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
//  A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
//  CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
//  EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
//  PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
//  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
//  LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
//  NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
//  SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Extensions;

namespace Farming_Simulator_Mod_Manager {
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Mover : Form {
        private string _mod = string.Empty;
        private string _mov = string.Empty;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Mover"/> class.
        /// </summary>
        public Mover() {
            InitializeComponent();
        }

        private void Mover_Load(object sender, EventArgs e) {
            LoadRepofiles();
        }

        private void LoadRepofiles() {
            var reg = new RegWork(false);
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            var pth = string.Empty;
            
            switch (gam) {
                case "FS11":
                    pth = reg.Read(Fs11RegKeys.FS11_REPO);
                    break;
                case "FS13":
                    pth = reg.Read(Fs13RegKeys.FS13_REPO);
                    break;
                case "FS15":
                    pth = reg.Read(Fs15RegKeys.FS15_REPO);
                    break;
                case "FS17":
                    pth = reg.Read(Fs17RegKeys.FS17_REPO);
                    break;
                case "FS19":
                    pth = reg.Read(FS19RegKeys.FS19_REPO);
                    break;
            }
            var lst = GetFilesFolders.GetFiles(pth, "*.zip");
            foreach (var v in lst) {
                lstRepo.Items.Add(v.GetFileName());
            }
            LoadGroupFolders();
        }

        private void LoadGroupFolders() {
            var reg = new RegWork(false);
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            var pth = string.Empty;

            switch (gam) {
                case "FS11":
                    pth = reg.Read(Fs11RegKeys.FS11_GROUPS);
                    break;
                case "FS13":
                    pth = reg.Read(Fs13RegKeys.FS13_GROUPS);
                    break;
                case "FS15":
                    pth = reg.Read(Fs15RegKeys.FS15_GROUPS);
                    break;
                case "FS17":
                    pth = reg.Read(Fs17RegKeys.FS17_GROUPS);
                    break;
                case "FS19":
                    pth = reg.Read(FS19RegKeys.FS19_GROUPS);
                    break;
            }
            var lst = GetFilesFolders.GetFolders(pth, "*.*");
            foreach (var v in lst) {
                lstGroups.Items.Add(v.GetLastFolderName());
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            Dispose();
        }

        private void copyModToolStripMenuItem_Click(object sender, EventArgs e) {
            _mod = lstRepo.SelectedItem.ToString();

        }

        private void moveHereToolStripMenuItem_Click(object sender, EventArgs e) {
            _mov = lstGroups.SelectedItem.ToString();
             var reg = new RegWork(false);
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            
            if (_mov.IsNullOrEmpty() || gam.IsNullOrEmpty()) return;
            var grpPath = string.Empty;
            var modPath = string.Empty;
            
            switch (gam) {
                case "FS11":
                    grpPath = reg.Read(Fs11RegKeys.FS11_GROUPS) + _mov + @"\" + _mod;
                    modPath = reg.Read(Fs11RegKeys.FS11_REPO) + _mod;
                    break;
                case "FS13":
                    grpPath = reg.Read(Fs13RegKeys.FS13_GROUPS) + _mov + @"\" + _mod;
                    modPath = reg.Read(Fs13RegKeys.FS13_REPO) + _mod;
                    break;
                case "FS15":
                    grpPath = reg.Read(Fs15RegKeys.FS15_GROUPS) + _mov + @"\" + _mod;
                    modPath = reg.Read(Fs15RegKeys.FS15_REPO) + _mod;
                    break;
                case "FS17":
                    grpPath = reg.Read(Fs17RegKeys.FS17_GROUPS) + _mov + @"\" + _mod;
                    modPath = reg.Read(Fs17RegKeys.FS17_REPO) + _mod;
                    break;
                case "FS19":
                    grpPath = reg.Read(FS19RegKeys.FS19_GROUPS) + _mov + @"\" + _mod;
                    modPath = reg.Read(FS19RegKeys.FS19_REPO) + _mod;
                    break;
            }
            
            
            var ls = new ListCreator();
            
            FileCopyMove.FileCopy(modPath, grpPath, true);
            lstRepo.Items.Remove(_mod);
            ls.CreateSortedLists();
            ls.SortedFileListComplete();
        }

        private void createFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            var grpPth = string.Empty;

            if (gam.IsNullOrEmpty()) return;

            switch (gam) {
                case "FS11":
                    grpPth = reg.Read(Fs11RegKeys.FS11_GROUPS);
                    break;
                case "FS13":
                    grpPth = reg.Read(Fs13RegKeys.FS13_GROUPS);
                    break;
                case "FS15":
                    grpPth = reg.Read(Fs15RegKeys.FS15_GROUPS);
                    break;
                case "FS17":
                    grpPth = reg.Read(Fs17RegKeys.FS17_GROUPS);
                    break;
                case "FS19":
                    grpPth = reg.Read(FS19RegKeys.FS19_GROUPS);
                    break;
            }

            Vars.FolderName = grpPth;
            var fld = new FolderBox();
            fld.ShowDialog();
        }

        private void addModHashToolStripMenuItem_Click(object sender, EventArgs e) {
            var reg = new RegWork(true);
            var nMod = lstRepo.SelectedItem.ToString();
            var gi = new GameInfo();
            var gam = gi.GetGame();
            Dictionary<string, string> dic;
            string tmp;

            switch (gam) {
                case "FS11":
                    dic = Serializer.DeserializeDictionary(reg.Read(Fs11RegKeys.FS11_XML) + "hash.xml");
                    tmp = reg.Read(Fs11RegKeys.FS11_REPO) + nMod;
                    if (dic.ContainsKey(nMod)) return;
                    dic.Add(nMod, Hasher.HashFile(tmp));
                    Serializer.SerializeDictionary(reg.Read(Fs11RegKeys.FS11_XML) + "hash.xml", dic);
                    break;
                case "FS13":
                    dic = Serializer.DeserializeDictionary(reg.Read(Fs13RegKeys.FS13_XML) + "hash.xml");
                    tmp = reg.Read(Fs13RegKeys.FS13_REPO) + nMod;
                    if (dic.ContainsKey(nMod)) return;
                    dic.Add(nMod, Hasher.HashFile(tmp));
                    Serializer.SerializeDictionary(reg.Read(Fs13RegKeys.FS13_XML) + "hash.xml", dic);
                    break;
                case "FS15":
                    dic = Serializer.DeserializeDictionary(reg.Read(Fs15RegKeys.FS15_XML) + "hash.xml");
                    tmp = reg.Read(Fs15RegKeys.FS15_REPO) + nMod;
                    if (dic.ContainsKey(nMod)) return;
                    dic.Add(nMod, Hasher.HashFile(tmp));
                    Serializer.SerializeDictionary(reg.Read(Fs15RegKeys.FS15_XML) + "hash.xml", dic);
                    break;
                case "FS17":
                    dic = Serializer.DeserializeDictionary(reg.Read(Fs17RegKeys.FS17_XML) + "hash.xml");
                    tmp = reg.Read(Fs17RegKeys.FS17_REPO) + nMod;
                    if (dic.ContainsKey(nMod)) return;
                    dic.Add(nMod, Hasher.HashFile(tmp));
                    Serializer.SerializeDictionary(reg.Read(Fs17RegKeys.FS17_XML) + "hash.xml", dic);
                    break;
                case "FS19":
                    dic = Serializer.DeserializeDictionary(reg.Read(FS19RegKeys.FS19_XML) + "hash.xml");
                    tmp = reg.Read(FS19RegKeys.FS19_REPO) + nMod;
                    if (dic.ContainsKey(nMod)) return;
                    dic.Add(nMod, Hasher.HashFile(tmp));
                    Serializer.SerializeDictionary(reg.Read(FS19RegKeys.FS19_XML) + "hash.xml", dic);
                    break;

            }

            MsgBx.Msg("Hash Computed and Added to XML", "Hasher");
        }
    }
}
