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

using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Extensions;

namespace Farming_Simulator_Mod_Manager {
    internal static class Loader {
        private const string ZIP_S = "*.zip";
        private const string SEARCH_PATTERN = "*.*";

        /// <summary>
        /// Gets the group loader.
        /// </summary>
        /// <value>
        /// The group loader.
        /// </value>
        public static IEnumerable<string> GroupLoader {
            get {
                var reg = new RegWork(true);
                var gam = reg.Read(RegKeys.CURRENT_GAME);
                IEnumerable<string> lst = null;

                switch (gam) {
                    case "FS11":
                        lst = GetFilesFolders.GetFolders(reg.Read(Fs11RegKeys.FS11_GROUPS), SEARCH_PATTERN);
                        break;
                    case "FS13":
                        lst = GetFilesFolders.GetFolders(reg.Read(Fs13RegKeys.FS13_GROUPS), SEARCH_PATTERN);
                        break;
                    case "FS15":
                        lst = GetFilesFolders.GetFolders(reg.Read(Fs15RegKeys.FS15_GROUPS), SEARCH_PATTERN);
                        break;
                    case "FS17":
                        lst = GetFilesFolders.GetFolders(reg.Read(Fs17RegKeys.FS17_GROUPS), SEARCH_PATTERN);
                        break;
                    case "FS19":
                        lst = GetFilesFolders.GetFolders(reg.Read(FS19RegKeys.FS19_GROUPS), SEARCH_PATTERN);
                        break;
                }

                return lst;
            }
        }

        /// <summary>
        /// Groups the mod loader.
        /// </summary>
        /// <param name="grp">The GRP.</param>
        /// <returns></returns>
        public static IEnumerable<string> GroupModLoader(string grp) {
            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            IEnumerable<string> lst = null;

            switch (gam) {
                case "FS11":
                    lst = GetFilesFolders.GetFiles(reg.Read(Fs11RegKeys.FS11_GROUPS) + @"\" + grp + @"\", ZIP_S);
                    break;
                case "FS13":
                    lst = GetFilesFolders.GetFiles(reg.Read(Fs13RegKeys.FS13_GROUPS) + @"\" + grp + @"\", ZIP_S);
                    break;
                case "FS15":
                    lst = GetFilesFolders.GetFiles(reg.Read(Fs15RegKeys.FS15_GROUPS) + @"\" + grp + @"\", ZIP_S);
                    break;
                case "FS17":
                    lst = GetFilesFolders.GetFiles(reg.Read(Fs17RegKeys.FS17_GROUPS) + @"\" + grp + @"\", ZIP_S);
                    break;
                case "FS19":
                    lst = GetFilesFolders.GetFiles(reg.Read(FS19RegKeys.FS19_GROUPS) + @"\" + grp + @"\", ZIP_S);
                    break;
            }

            return lst;
        }

        /// <summary>
        /// Gets the profile loader.
        /// </summary>
        /// <value>
        /// The profile loader.
        /// </value>
        public static IEnumerable<string> ProfileLoader {
            get {
                var reg = new RegWork(true);
                var gam = reg.Read(RegKeys.CURRENT_GAME);
                IEnumerable<string> lst = null;

                switch (gam) {
                    case "FS11":
                        lst = GetFilesFolders.GetFolders(reg.Read(Fs11RegKeys.FS11_PROFILES), SEARCH_PATTERN);
                        break;
                    case "FS13":
                        lst = GetFilesFolders.GetFolders(reg.Read(Fs13RegKeys.FS13_PROFILES), SEARCH_PATTERN);
                        break;
                    case "FS15":
                        lst = GetFilesFolders.GetFolders(reg.Read(Fs15RegKeys.FS15_PROFILES), SEARCH_PATTERN);
                        break;
                    case "FS17":
                        lst = GetFilesFolders.GetFolders(reg.Read(Fs17RegKeys.FS17_PROFILES), SEARCH_PATTERN);
                        break;
                    case "FS19":
                        lst = GetFilesFolders.GetFolders(reg.Read(FS19RegKeys.FS19_PROFILES), SEARCH_PATTERN);
                        break;
                }

                return lst;
            }
        }

        /// <summary>
        /// Profiles the mod loader.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> ProfileModLoader() {
            var lst = new List<string>();
            var dic = Utils.ProfileFileList;

            foreach (var v in dic) {
                lst.Add(v.Key);
            }

            return lst;
        }

        /// <summary>
        /// Games the starter.
        /// </summary>
        public static void GameStarter() {
            var reg = new RegWork(true);
            var gam1 = reg.Read(RegKeys.CURRENT_GAME);
            var gam = string.Empty;

            switch (gam1) {
                case "FS11":
                    var fs11 = new RegWork(true);
                    gam = fs11.Read(Fs11RegKeys.FS11_START_GAME_PATH);

                    if (gam.IsNullOrEmpty()) {
                        var ofd = new OpenFileDialog {
                            CheckFileExists = true,
                            Title = @"Navigate to the Farming Simulator 2011 Exe"
                        };

                        ofd.ShowDialog();
                        gam = ofd.FileName;
                        fs11.Write(Fs11RegKeys.FS11_START_GAME_PATH, ofd.FileName);
                        var bckUp = new Backup();
                        bckUp.BackupFiles();
                    }

                    break;
                case "FS13":
                    var fs13 = new RegWork(true);
                    gam = fs13.Read(Fs13RegKeys.FS13_START_GAME_PATH);

                    if (gam.IsNullOrEmpty()) {
                        var ofd = new OpenFileDialog {
                            CheckFileExists = true,
                            Title = @"Navigate to the Farming Simulator 2013 Exe"
                        };

                        ofd.ShowDialog();
                        gam = ofd.FileName;
                        fs13.Write(Fs13RegKeys.FS13_START_GAME_PATH, ofd.FileName);
                        var bckUp = new Backup();
                        bckUp.BackupFiles();
                    }

                    break;
                case "FS15":
                    var fs15 = new RegWork(true);
                    gam = fs15.Read(Fs15RegKeys.FS15_START_GAME_PATH);

                    if (gam.IsNullOrEmpty()) {
                        var ofd = new OpenFileDialog {
                            CheckFileExists = true,
                            Title = @"Navigate to the Farming Simulator 2015 Exe"
                        };

                        ofd.ShowDialog();
                        gam = ofd.FileName;
                        fs15.Write(Fs15RegKeys.FS15_START_GAME_PATH, ofd.FileName);
                        var bckUp = new Backup();
                        bckUp.BackupFiles();
                    }

                    break;
                case "FS17":
                    var fs17 = new RegWork(true);
                    gam = fs17.Read(Fs17RegKeys.FS17_START_GAME_PATH);

                    if (gam.IsNullOrEmpty()) {
                        var ofd = new OpenFileDialog {
                            CheckFileExists = true,
                            Title = @"Navigate to the Farming Simulator 2017 Exe"
                        };

                        ofd.ShowDialog();
                        gam = ofd.FileName;
                        fs17.Write(Fs17RegKeys.FS17_START_GAME_PATH, ofd.FileName);
                        var bckUp = new Backup();
                        bckUp.BackupFiles();
                    }

                    break;
                case "FS19":
                    var fs19 = new RegWork(true);
                    gam = fs19.Read(FS19RegKeys.FS19_START_GAME_PATH);

                    if (gam.IsNullOrEmpty()) {
                        var ofd = new OpenFileDialog {
                            CheckFileExists = true,
                            Title = @"Navigate to the Farming Simulator 2019 Exe"
                        };

                        ofd.ShowDialog();
                        gam = ofd.FileName;
                        fs19.Write(FS19RegKeys.FS19_START_GAME_PATH, ofd.FileName);
                        var bckUp = new Backup();
                        bckUp.BackupFiles();
                    }

                    break;
            }

            Process.Start(gam);
        }
    }
}