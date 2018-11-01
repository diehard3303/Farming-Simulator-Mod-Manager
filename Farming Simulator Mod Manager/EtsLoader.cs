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
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Extensions;

namespace Farming_Simulator_Mod_Manager {
    internal class EtsLoader {
        /// <summary>
        ///     Loads the ets group mods.
        /// </summary>
        /// <param name="grp">The GRP.</param>
        /// <returns></returns>
        public IEnumerable<string> LoadEtsGroupMods(string grp) {
            var ets = new RegWork(true);
            var lst = GetFilesFolders.GetFiles(ets.Read(EtsRegKeys.ETS_GROUPS) + grp + "\\", "*.scs");

            return lst;
        }

        /// <summary>
        ///     Loads the ats groups.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> LoadEtsGroups() {
            var ets = new RegWork(true);
            var lst = GetFilesFolders.GetFolders(ets.Read(EtsRegKeys.ETS_GROUPS), "*.*");

            return lst;
        }

        /// <summary>
        ///     Loads the ats mod choice.
        /// </summary>
        /// <param name="chc">The CHC.</param>
        /// <returns></returns>
        public string LoadEtsModChoice(string chc) {
            var ets = new RegWork(true);
            var fnd = string.Empty;
            var dic = Serializer.DeserializeDictionary(ets.Read(EtsRegKeys.ETS_XML) + "sortedFileListComplete.xml");
            if (dic.Any(v => string.Equals(v.Key, chc, StringComparison.OrdinalIgnoreCase)))
                dic.TryGetValue(chc, out fnd);
            return fnd + chc;
        }

        /// <summary>
        ///     Loads the ats profile mods.
        /// </summary>
        /// <param name="prof">The PTH.</param>
        /// <returns></returns>
        public Dictionary<string, string> LoadEtsProfileMods(string prof) {
            var ets = new RegWork(true);
            var pro = ets.Read(EtsRegKeys.ETS_PROFILES) + ets.Read(RegKeys.CURRENT_PROFILE) + "\\" + prof + ".xml";
            if (!pro.FileExists()) return null;
            var dic = Serializer.DeserializeDictionary(pro);

            return dic;
        }

        /// <summary>
        ///     Loads the ats profiles.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> LoadEtsProfiles() {
            var ets = new RegWork(true);
            var lst = GetFilesFolders.GetFolders(ets.Read(EtsRegKeys.ETS_PROFILES), "*.*");

            return lst;
        }

        /// <summary>
        ///     Starts the ats.
        /// </summary>
        public void StartEts() {
            var ets = new RegWork(true);
            var gam = ets.Read(EtsRegKeys.ETS_START_GAME_PATH);

            if (gam.IsNullOrEmpty()) {
                var ofd = new OpenFileDialog {
                    CheckFileExists = true,
                    Title = @"Navigate to the Euro Truck Simulator Exe"
                };

                ofd.ShowDialog();
                gam = ofd.FileName;
                ets.Write(EtsRegKeys.ETS_START_GAME_PATH, ofd.FileName);
            }

            Process.Start(gam);
        }
    }
}