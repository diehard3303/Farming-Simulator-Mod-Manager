// ***********************************************************************
// Assembly         : DMM
// Author           : TJ (DieHard)
// Created          : 10-08-2013
//
// Last Modified By : TJ (DieHard)
// Last Modified On : 10-08-2013
// ***********************************************************************
// <copyright file="FileWriter.cs" company="DieHard Development">
//     Copyright (c) DieHard Development. All rights reserved.
// </copyright>
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
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extensions;
using Microsoft.VisualBasic;

namespace Farming_Simulator_Mod_Manager {
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:System.Windows.Forms.Form" />
    public partial class Results : Form {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Farming_Simulator_Mod_Manager.Results" /> class.
        /// </summary>
        public Results() => InitializeComponent();

        private static string _flder;
        private static readonly Dictionary<string, string> Dic = Utils.ByPassList;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
        }

        private void Results_Load(object sender, EventArgs e) {
            foreach (var v in Vars.UniList) {
                lstResults.Items.Add(v.GetFileName());
            }

            label1.Text = @"FileCount: " + lstResults.Items.Count;

            ReloadGroupList();
        }

        private void ReloadGroupList() {
            var lst = Loader.GroupLoader;
            lstGroups.Items.Clear();
            foreach (var t in lst) {
                if (Dic.ContainsKey(t.GetLastFolderName())) continue;
                lstGroups.Items.Add(t.GetLastFolderName());
            }
           
        }

        private void button1_Click(object sender, EventArgs e) {
            var cList = Utils.CompleteSortedList;
            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);

            switch (gam) {
                case "FS11":
                    foreach (var v in Vars.UniList) {
                        cList.TryGetValue(v.GetFileName(), out var fnd);
                        if (_flder.IsNullOrEmpty()) {
                            MsgBx.Msg("You must choose a destination folder", "Folder Chooser");
                            return;
                        }

                        var dest = reg.Read(Fs11RegKeys.FS11_GROUPS) + _flder + @"\" + v.GetFileName();
                        if (dest.FileExists()) continue;
                        FileCopyMove.FileCopy(fnd + @"\" + v.GetFileName(), dest, true);
                    }
                    break;
                case "FS13":
                    foreach (var v in Vars.UniList) {
                        cList.TryGetValue(v.GetFileName(), out var fnd);
                        if (_flder.IsNullOrEmpty()) {
                            MsgBx.Msg("You must choose a destination folder", "Folder Chooser");
                            return;
                        }

                        var dest = reg.Read(Fs13RegKeys.FS13_GROUPS) + _flder + @"\" + v.GetFileName();
                        if (dest.FileExists()) continue;
                        FileCopyMove.FileCopy(fnd + @"\" + v.GetFileName(), dest, true);
                    }
                    break;
                case "FS15":
                    foreach (var v in Vars.UniList) {
                        cList.TryGetValue(v.GetFileName(), out var fnd);
                        if (_flder.IsNullOrEmpty()) {
                            MsgBx.Msg("You must choose a destination folder", "Folder Chooser");
                            return;
                        }

                        var dest = reg.Read(Fs15RegKeys.FS15_GROUPS) + _flder + @"\" + v.GetFileName();
                        if (dest.FileExists()) continue;
                        FileCopyMove.FileCopy(fnd + @"\" + v.GetFileName(), dest, true);
                    }
                    break;
                case "FS17":
                    foreach (var v in Vars.UniList) {
                        cList.TryGetValue(v.GetFileName(), out var fnd);
                        if (_flder.IsNullOrEmpty()) {
                            MsgBx.Msg("You must choose a destination folder", "Folder Chooser");
                            return;
                        }

                        var dest = reg.Read(Fs17RegKeys.FS17_GROUPS) + _flder + @"\" + v.GetFileName();
                        if (dest.FileExists()) continue;
                        FileCopyMove.FileCopy(fnd + @"\" + v.GetFileName(), dest, true);
                    }
                    break;
                case "FS19":
                    foreach (var v in Vars.UniList) {
                        cList.TryGetValue(v.GetFileName(), out var fnd);
                        if (_flder.IsNullOrEmpty()) {
                            MsgBx.Msg("You must choose a destination folder", "Folder Chooser");
                            return;
                        }

                        var dest = reg.Read(FS19RegKeys.FS19_GROUPS) + _flder + @"\" + v.GetFileName();
                        if (dest.FileExists()) continue;
                        FileCopyMove.FileCopy(fnd + @"\" + v.GetFileName(), dest, true);
                    }
                    break;
            }
            lstResults.Items.Clear();
            var lc = new ListCreator();
            lc.CreateSortedLists();
            lc.SortedFileListComplete();
        }

        private void lstGroups_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstGroups.SelectedItem.IsNull()) return;
            _flder = lstGroups.SelectedItem.ToString();
        }

        private void createGroupToolStripMenuItem_Click(object sender, EventArgs e) {
            var input = Interaction.InputBox("Type in New Group Name", "Group Creator");
            if (input.IsNullOrEmpty()) return;

            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);

            switch (gam) {
                case "FS11":
                    Directory.CreateDirectory(reg.Read(Fs11RegKeys.FS11_GROUPS) + input);
                    break;
                case "FS13":
                    Directory.CreateDirectory(reg.Read(Fs13RegKeys.FS13_GROUPS) + input);
                    break;
                case "FS15":
                    Directory.CreateDirectory(reg.Read(Fs15RegKeys.FS15_GROUPS) + input);
                    break;
                case "FS17":
                    Directory.CreateDirectory(reg.Read(Fs17RegKeys.FS17_GROUPS) + input);
                    break;
                case "FS19":
                    Directory.CreateDirectory(reg.Read(FS19RegKeys.FS19_GROUPS) + input);
                    break;
            }
            ReloadGroupList();
        }
    }
}