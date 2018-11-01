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

using Extensions;
using System;
using System.Windows.Forms;

namespace Farming_Simulator_Mod_Manager {
    class InitFarmSim {
        public void Initialize() {
            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);

            switch (gam) {
                case "FS11":
                    var tmp = reg.Read(Fs11RegKeys.FS11_REPO);
                    if (!tmp.IsNullOrEmpty()) return;
                    var diag = MessageBox.Show(@"Do you want me to setup Farming Simulator 2011?", @"FS 11 Init",
                        MessageBoxButtons.YesNo);
                    if (diag != DialogResult.Yes) return;

                    CreateFoldersFs11();
                    break;

                case "FS13":
                    tmp = reg.Read(Fs13RegKeys.FS13_REPO);
                    if (!tmp.IsNullOrEmpty()) return;
                    diag = MessageBox.Show(@"Do you want me to setup Farming Simulator 2013?", @"FS 13 Init",
                        MessageBoxButtons.YesNo);
                    if (diag != DialogResult.Yes) return;

                    CreateFoldersFs13();
                    break;

                case "FS15":
                    tmp = reg.Read(Fs15RegKeys.FS15_REPO);
                    if (!tmp.IsNullOrEmpty()) return;
                    diag = MessageBox.Show(@"Do you want me to setup Farming Simulator 2015?", @"FS 15 Init",
                        MessageBoxButtons.YesNo);
                    if (diag != DialogResult.Yes) return;

                    CreateFoldersFs15();
                    break;

                case "FS17":
                    tmp = reg.Read(Fs17RegKeys.FS17_REPO);
                    if (!tmp.IsNullOrEmpty()) return;
                    diag = MessageBox.Show(@"Do you want me to setup Farming Simulator 2017?", @"FS 17 Init",
                        MessageBoxButtons.YesNo);
                    if (diag != DialogResult.Yes) return;

                    CreateFoldersFs17();
                    break;

                case "FS19":
                    tmp = reg.Read(FS19RegKeys.FS19_REPO);
                    if (!tmp.IsNullOrEmpty()) return;
                    diag = MessageBox.Show(@"Do you want me to setup Farming Simulator 2019?", @"FS 19 Init",
                        MessageBoxButtons.YesNo);
                    if (diag != DialogResult.Yes) return;

                    CreateFoldersFs19();
                    break;
            }
        }

        private static void CreateFoldersFs19() {
            var fs19Rw = new RegWork(true);

            var ofd = new FolderBrowserDialog {
                Description = @"Navigate to where you want the top folder for FS19Loader",
                ShowNewFolderButton = false
            };
            ofd.ShowDialog();
            if (!ofd.SelectedPath.FolderExists()) return;
            var pth = ofd.SelectedPath;
            FolderCreator.CreatePublicFolders(pth + "\\FS19Repo");
            fs19Rw.Write(FS19RegKeys.FS19_REPO, pth + "\\FS19Repo\\");
            var tmp = pth + "\\FS19Repo\\";
            FolderCreator.CreatePublicFolders(tmp + "FS19Extraction");
            fs19Rw.Write(FS19RegKeys.FS19_EXTRACTION, tmp + "FS19Extraction");
            FolderCreator.CreatePublicFolders(tmp + "FS19Profiles");
            fs19Rw.Write(FS19RegKeys.FS19_PROFILES, tmp + "Fs19Profiles\\");
            FolderCreator.CreatePublicFolders(tmp + "FS19Groups");
            fs19Rw.Write(FS19RegKeys.FS19_GROUPS, tmp + "FS19Groups\\");
            FolderCreator.CreatePublicFolders(tmp + "FS19Xml");
            fs19Rw.Write(FS19RegKeys.FS19_XML, tmp + "FS19Xml\\");
            FolderCreator.CreatePublicFolders(tmp + "FS19Work");
            fs19Rw.Write(FS19RegKeys.FS19_WORK, tmp + "FS19Work\\");
            FolderCreator.CreatePublicFolders(tmp + "FS19Backup\\");
            fs19Rw.Write(FS19RegKeys.FS19_BACKUP, tmp + "FS19Backup\\");

            ofd = new FolderBrowserDialog {
                Description = @"Navigate to Farming Simulator 2019 Mod Folder",
                ShowNewFolderButton = false
            };
            ofd.ShowDialog();
            if (ofd.SelectedPath.FolderExists()) {
                fs19Rw.Write(FS19RegKeys.FS19_GAME_MOD_FOLDER, ofd.SelectedPath + "\\");
                var t = ofd.SelectedPath.LastIndexOf("\\", StringComparison.OrdinalIgnoreCase);
                var fix = ofd.SelectedPath.Substring(0, t) + "\\";
                fs19Rw.Write(FS19RegKeys.FS19_GAME_SETTINGS_XML, fix + "gameSettings.xml");
            }

            MsgBx.Msg("All folders have been created for FS19Loader", "Game Intializer");
        }

        private static void CreateFoldersFs17() {
            var atsw = new RegWork(true);

            var ofd = new FolderBrowserDialog {
                Description = @"Navigate to where you want the top folder for FS17",
                ShowNewFolderButton = false
            };
            ofd.ShowDialog();
            if (!ofd.SelectedPath.FolderExists()) return;
            var pth = ofd.SelectedPath;
            FolderCreator.CreatePublicFolders(pth + "\\FS17Repo");
            atsw.Write(Fs17RegKeys.FS17_REPO, pth + "\\FS17Repo\\");
            var tmp = pth + "\\FS17Repo\\";
            FolderCreator.CreatePublicFolders(tmp + "FS17Extraction");
            atsw.Write(Fs17RegKeys.FS17_EXTRACTION, tmp + "FS17Extraction");
            FolderCreator.CreatePublicFolders(tmp + "FS17Profiles");
            atsw.Write(Fs17RegKeys.FS17_PROFILES, tmp + "Fs17Profiles\\");
            FolderCreator.CreatePublicFolders(tmp + "FS17Groups");
            atsw.Write(Fs17RegKeys.FS17_GROUPS, tmp + "FS17Groups\\");
            FolderCreator.CreatePublicFolders(tmp + "FS17Xml");
            atsw.Write(Fs17RegKeys.FS17_XML, tmp + "FS17Xml\\");
            FolderCreator.CreatePublicFolders(tmp + "FS17Work");
            atsw.Write(Fs17RegKeys.FS17_WORK, tmp + "FS17Work\\");
            FolderCreator.CreatePublicFolders(tmp + "FS17Backup\\");
            atsw.Write(Fs17RegKeys.FS17_BACKUP, tmp + "FS17Backup\\");
            FolderCreator.CreatePublicFolders(tmp + "FS17Export\\");
            atsw.Write(Fs17RegKeys.FS17_EXPORT_DIR, tmp + "FS17Export");

            ofd = new FolderBrowserDialog {
                Description = @"Navigate to Farming Simulator 2017 Mod Folder",
                ShowNewFolderButton = false
            };
            ofd.ShowDialog();
            if (ofd.SelectedPath.FolderExists()) {
                atsw.Write(Fs17RegKeys.FS17_GAME_MOD_FOLDER, ofd.SelectedPath + "\\");
                var t = ofd.SelectedPath.LastIndexOf("\\", StringComparison.OrdinalIgnoreCase);
                var fix = ofd.SelectedPath.Substring(0, t) + "\\";
                atsw.Write(Fs17RegKeys.FS17_GAME_SETTINGS_XML, fix + "gameSettings.xml");
            }

            MsgBx.Msg("All folders have been created for FS17", "Game Intializer");
        }

        private static void CreateFoldersFs15() {
            var atsw = new RegWork(true);

            var ofd = new FolderBrowserDialog {
                Description = @"Navigate to where you want the top folder for FS15",
                ShowNewFolderButton = false
            };
            ofd.ShowDialog();
            if (!ofd.SelectedPath.FolderExists()) return;
            var pth = ofd.SelectedPath;
            FolderCreator.CreatePublicFolders(pth + "\\FS15Repo");
            atsw.Write(Fs15RegKeys.FS15_REPO, pth + "\\FS15Repo\\");
            var tmp = pth + "\\FS15Repo\\";
            FolderCreator.CreatePublicFolders(tmp + "FS15Extraction");
            atsw.Write(Fs15RegKeys.FS15_EXTRACTION, tmp + "FS15Extraction");
            FolderCreator.CreatePublicFolders(tmp + "FS15Profiles");
            atsw.Write(Fs15RegKeys.FS15_PROFILES, tmp + "Fs15Profiles\\");
            FolderCreator.CreatePublicFolders(tmp + "FS15Groups");
            atsw.Write(Fs15RegKeys.FS15_GROUPS, tmp + "FS15Groups\\");
            FolderCreator.CreatePublicFolders(tmp + "FS15Xml");
            atsw.Write(Fs15RegKeys.FS15_XML, tmp + "FS15Xml\\");
            FolderCreator.CreatePublicFolders(tmp + "FS15Work");
            atsw.Write(Fs15RegKeys.FS15_WORK, tmp + "FS15Work\\");
            FolderCreator.CreatePublicFolders(tmp + "FS15Backup");
            atsw.Write(Fs15RegKeys.FS15_BACKUP, tmp + "FS15Backup\\");

            ofd = new FolderBrowserDialog {
                Description = @"Navigate to Farming Simulator 2015 Mod Folder",
                ShowNewFolderButton = false
            };
            ofd.ShowDialog();
            if (ofd.SelectedPath.FolderExists()) {
                atsw.Write(Fs15RegKeys.FS15_GAME_MOD_FOLDER, ofd.SelectedPath + "\\");
                var t = ofd.SelectedPath.LastIndexOf("\\", StringComparison.OrdinalIgnoreCase);
                var fix = ofd.SelectedPath.Substring(0, t) + "\\";
                atsw.Write(Fs15RegKeys.FS15_GAME_SETTINGS_XML, fix + "gameSettings.xml");
            }

            MsgBx.Msg("All folders have been created for FS15", "Game Intializer");
        }

        private static void CreateFoldersFs13() {
            var reg = new RegWork(true);

            var ofd = new FolderBrowserDialog {
                Description = @"Navigate to where you want the top folder for FS13",
                ShowNewFolderButton = false
            };
            ofd.ShowDialog();
            if (!ofd.SelectedPath.FolderExists()) return;
            var pth = ofd.SelectedPath;
            FolderCreator.CreatePublicFolders(pth + "\\FS13Repo");
            reg.Write(Fs13RegKeys.FS13_REPO, pth + "\\FS13Repo\\");
            var tmp = pth + "\\FS13Repo\\";
            FolderCreator.CreatePublicFolders(tmp + "FS13Extraction");
            reg.Write(Fs13RegKeys.FS13_EXTRACTION, tmp + "FS13Extraction");
            FolderCreator.CreatePublicFolders(tmp + "FS13Profiles");
            reg.Write(Fs13RegKeys.FS13_PROFILES, tmp + "FS13Profiles\\");
            FolderCreator.CreatePublicFolders(tmp + "FS13Groups");
            reg.Write(Fs13RegKeys.FS13_GROUPS, tmp + "FS13Groups\\");
            FolderCreator.CreatePublicFolders(tmp + "FS13Xml");
            reg.Write(Fs13RegKeys.FS13_XML, tmp + "FS13Xml\\");
            FolderCreator.CreatePublicFolders(tmp + "FS13Work");
            reg.Write(Fs13RegKeys.FS13_WORK, tmp + "FS13Work\\");
            FolderCreator.CreatePublicFolders(tmp + "FS13Backup");
            reg.Write(Fs13RegKeys.FS13_BACKUP, tmp + "FS13Backup\\");

            ofd = new FolderBrowserDialog {
                Description = @"Navigate to Farming Simulator 2013 Mod Folder",
                ShowNewFolderButton = false
            };
            ofd.ShowDialog();
            if (ofd.SelectedPath.FolderExists()) {
                reg.Write(Fs13RegKeys.FS13_GAME_MOD_FOLDER, ofd.SelectedPath + "\\");
                var t = ofd.SelectedPath.LastIndexOf("\\", StringComparison.OrdinalIgnoreCase);
                var fix = ofd.SelectedPath.Substring(0, t) + "\\";
                reg.Write(Fs13RegKeys.FS13_GAME_SETTINGS_XML, fix + "gameSettings.xml");
            }

            MsgBx.Msg("All folders have been created for FS13", "Game Intializer");
        }

        private static void CreateFoldersFs11() {
            var reg = new RegWork(true);

            var ofd = new FolderBrowserDialog {
                Description = @"Navigate to where you want the top folder for FS11",
                ShowNewFolderButton = false
            };
            ofd.ShowDialog();
            if (!ofd.SelectedPath.FolderExists()) return;
            var pth = ofd.SelectedPath;
            FolderCreator.CreatePublicFolders(pth + "\\FS11Repo");
            reg.Write(Fs11RegKeys.FS11_REPO, pth + "\\FS11Repo\\");
            var tmp = pth + "\\FS11Repo\\";
            FolderCreator.CreatePublicFolders(tmp + "FS11Extraction");
            reg.Write(Fs11RegKeys.FS11_EXTRACTION, tmp + "FS11Extraction");
            FolderCreator.CreatePublicFolders(tmp + "FS11Profiles");
            reg.Write(Fs11RegKeys.FS11_PROFILES, tmp + "FS11Profiles\\");
            FolderCreator.CreatePublicFolders(tmp + "FS11Groups");
            reg.Write(Fs11RegKeys.FS11_GROUPS, tmp + "FS11Groups\\");
            FolderCreator.CreatePublicFolders(tmp + "FS11Xml");
            reg.Write(Fs11RegKeys.FS11_XML, tmp + "FS11Xml\\");
            FolderCreator.CreatePublicFolders(tmp + "FS11Work");
            reg.Write(Fs11RegKeys.FS11_WORK, tmp + "FS11Work\\");
            FolderCreator.CreatePublicFolders(tmp + "FS11Backup");
            reg.Write(Fs11RegKeys.FS11_BACKUP, tmp + "FS11Backup\\");

            ofd = new FolderBrowserDialog {
                Description = @"Navigate to Farming Simulator 2011 Mod Folder",
                ShowNewFolderButton = false
            };
            ofd.ShowDialog();
            if (ofd.SelectedPath.FolderExists()) {
                reg.Write(Fs11RegKeys.FS11_GAME_MOD_FOLDER, ofd.SelectedPath + "\\");
                var t = ofd.SelectedPath.LastIndexOf("\\", StringComparison.OrdinalIgnoreCase);
                var fix = ofd.SelectedPath.Substring(0, t) + "\\";
                reg.Write(Fs11RegKeys.FS11_GAME_SETTINGS_XML, fix + "gameSettings.xml");
            }

            MsgBx.Msg("All folders have been created for FS11", "Game Intializer");
        }
    }
}