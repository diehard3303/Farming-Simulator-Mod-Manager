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

using Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Farming_Simulator_Mod_Manager {

    /// <inheritdoc />
    ///  <summary>
    ///  </summary>
    public partial class Chooser : Form {
        private readonly List<string> _type = new List<string>();
        private string _brand = string.Empty;

        /// <inheritdoc />
        ///  <summary>
        ///  </summary>
        public Chooser() {
            InitializeComponent();
        }

        /// <summary>
        ///
        /// </summary>
        public bool Multiple { get; set; }

        private void button1_Click(object sender, EventArgs e) => Dispose();

        private void button2_Click(object sender, EventArgs e) => LoadVehicles();

        private void button3_Click(object sender, EventArgs e) {
            lstChoose.Items.Clear();
            _type.Clear();
        }

        private void button4_Click(object sender, EventArgs e) {
            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            string tmp = null;
            switch (gam) {
                case "FS19":
                    tmp = reg.Read(FS19RegKeys.FS19_XML) + @"mods\";
                    break;
            }
            Process.Start(tmp ?? throw new InvalidOperationException());
        }

        private void button5_Click(object sender, EventArgs e) {
            const string TMP = @"E:\GIANTS_Editor_8.0.0_64-bit\x64\editor.exe";
            Process.Start(TMP);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) => Multiple = true;

        private void Chooser_Load(object sender, EventArgs e) {
            Multiple = false;
            LoadBrands();
        }

        private void LoadBrands() {
            var reg = new RegWork(true);
            var tmp = reg.Read(FS19RegKeys.FS19_DATA_DIR);
            var fld = GetFilesFolders.GetFolders(tmp, "*.*");
            foreach (var v in fld) {
                lstBrands.Items.Add(v.GetLastFolderName());
            }
        }

        private void LoadVehicles() {
            var reg = new RegWork(true);
            var lst = GetFilesFolders.GetFoldersRecursive(reg.Read(FS19RegKeys.FS19_DATA_DIR), "*.*");
            foreach (var v in lst) {
                foreach (var t in _type) {
                    if (!v.Contains(t)) continue;
                    var tmp = GetFilesFolders.GetFiles(v, "*.xml");
                    var enumerable = tmp.ToList();
                    if (tmp.IsNull() || !enumerable.Any()) continue;
                    lstChoose.Items.Add(enumerable[0]);
                }
            }
        }

        private void lstBrands_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstBrands.SelectedItem.IsNull()) return;
            _brand = lstBrands.SelectedItem.ToString();
            if (!Multiple) _type.Clear();
            _type.Add(_brand);
        }

        private void lstChoose_SelectedIndexChanged(object sender, EventArgs e) {
            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            var fi = lstChoose.SelectedItem.ToString();
            string loc = null;

            switch (gam) {
                case "FS11":
                    loc = reg.Read(Fs11RegKeys.FS11_XML) + @"Mods\" + fi.GetFileName();
                    break;

                case "FS13":
                    loc = reg.Read(Fs13RegKeys.FS13_XML) + @"Mods\" + fi.GetFileName();
                    break;

                case "FS15":
                    loc = reg.Read(Fs15RegKeys.FS15_XML) + @"Mods\" + fi.GetFileName();
                    break;

                case "FS17":
                    loc = reg.Read(Fs17RegKeys.FS17_XML) + @"Mods\" + fi.GetFileName();
                    break;

                case "FS19":
                    loc = reg.Read(FS19RegKeys.FS19_XML) + @"Mods\" + fi.GetFileName();
                    break;
            }
            FileCopy.Destination = loc;
            FileCopy.Source = fi;
            FileCopy.DoCopy();
        }
    }
}