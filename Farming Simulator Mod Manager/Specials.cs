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
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Specials"/> class.
        /// </summary>
        /// <param name="components">The components.</param>
        /// <param name="lstSpecials">The LST specials.</param>
        /// <param name="contextMenuStrip1">The context menu strip1.</param>
        /// <param name="removeModToolStripMenuItem">The remove mod tool strip menu item.</param>
        /// <exception cref="ArgumentNullException">
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
            if (lst.IsNull()) return;
            foreach (var v in lst) {
                lstArchive.Items.Add(v.GetFileName());
            }
           
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
            Dispose();
        }

        private void lstArchive_SelectedIndexChanged(object sender, EventArgs e) {
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
                CreateHardLink(tmp, v.Value + @"\" + v.Key, IntPtr.Zero);
            }
            var lc = new ListCreator();
            lc.CreateSortedLists();

            MsgBx.Msg("Specials have been added to Profile", "Specials");
        }
    }
}