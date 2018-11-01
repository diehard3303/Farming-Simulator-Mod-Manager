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
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Extensions;

namespace Farming_Simulator_Mod_Manager {
    /// <summary>
    /// 
    /// </summary>
    public partial class Creation : Form {
        /// <summary>
        /// 
        /// </summary>
        public Creation() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            var nam = txtName.Text;
            if (nam.IsNullOrEmpty()) {
                Dispose();
            }

            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            var frn = Application.OpenForms.OfType<Form1>().Single();

            switch (gam) {
                case "FS11":
                    if (rbCreateProfile.Checked) {
                        Directory.CreateDirectory(reg.Read(Fs11RegKeys.FS11_PROFILES) + @"\" + nam);
                        CreateFile(nam);
                        frn.SetSimFs11();
                    }

                    if (rbCreateGroup.Checked) {
                        Directory.CreateDirectory(reg.Read(Fs11RegKeys.FS11_GROUPS) + @"\" + nam);
                        frn.InitStartUp();
                    }

                    break;
                case "FS13":
                    if (rbCreateProfile.Checked) {
                        Directory.CreateDirectory(reg.Read(Fs13RegKeys.FS13_PROFILES) + @"\" + nam);
                        CreateFile(nam);
                        frn.SetSimFs13();
                    }

                    if (rbCreateGroup.Checked) {
                        Directory.CreateDirectory(reg.Read(Fs13RegKeys.FS13_GROUPS) + @"\" + nam);
                        frn.InitStartUp();
                    }

                    break;
                case "FS15":
                    if (rbCreateProfile.Checked) {
                        Directory.CreateDirectory(reg.Read(Fs15RegKeys.FS15_PROFILES) + @"\" + nam);
                        CreateFile(nam);
                        frn.SetSimFs15();
                    }

                    if (rbCreateGroup.Checked) {
                        Directory.CreateDirectory(reg.Read(Fs15RegKeys.FS15_GROUPS) + @"\" + nam);
                        frn.InitStartUp();
                    }

                    break;
                case "FS17":
                    if (rbCreateProfile.Checked) {
                        Directory.CreateDirectory(reg.Read(Fs17RegKeys.FS17_PROFILES) + @"\" + nam);
                        CreateFile(nam);
                        frn.SetSimFs17();
                    }

                    if (rbCreateGroup.Checked) {
                        Directory.CreateDirectory(reg.Read(Fs17RegKeys.FS17_GROUPS) + @"\" + nam);
                        frn.InitStartUp();
                    }

                    break;
                case "FS19":
                    if (rbCreateProfile.Checked) {
                        Directory.CreateDirectory(reg.Read(FS19RegKeys.FS19_PROFILES) + @"\" + nam);
                        CreateFile(nam);
                        frn.SetSimFs19();
                    }

                    if (rbCreateGroup.Checked) {
                        Directory.CreateDirectory(reg.Read(FS19RegKeys.FS19_GROUPS) + @"\" + nam);
                        frn.InitStartUp();
                    }

                    break;
            }

            Dispose();
        }
        
        private static void CreateFile(string nam) {
            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            var tmp = string.Empty;

            switch (gam) {
                case "FS11":
                    tmp = reg.Read(Fs11RegKeys.FS11_PROFILES) + @"\" + nam + @"\" + nam + ".xml";
                    break;
                case "FS13":
                     tmp = reg.Read(Fs13RegKeys.FS13_PROFILES) + @"\" + nam + @"\" + nam + ".xml";
                    break;
                case "FS15":
                    tmp = reg.Read(Fs15RegKeys.FS15_PROFILES) + @"\" + nam + @"\" + nam + ".xml";
                    break;
                case "FS17":
                    tmp = reg.Read(Fs17RegKeys.FS17_PROFILES) + @"\" + nam + @"\" + nam + ".xml";
                    break;
                case "FS19":
                    tmp = reg.Read(FS19RegKeys.FS19_PROFILES) + @"\" + nam + @"\" + nam + ".xml";
                    break;
            }

            var dic = new Dictionary<string, string>();
            Serializer.SerializeDictionary(tmp, dic);
        }
    }
}