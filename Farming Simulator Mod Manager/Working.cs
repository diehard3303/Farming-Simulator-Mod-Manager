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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Farming_Simulator_Mod_Manager {

    /// <summary>
    ///
    /// </summary>
    internal static class Working {
        private const string FS11 = "FS11";
        private const string FS13 = "FS13";
        private const string FS15 = "FS15";
        private const string FS17 = "FS17";
        private const string FS19 = "FS19";
        private const string PROFILE_PATH_END = @" />";
        private const string SEARCH_PATTERN = "*.zip";

        private enum SymbolicLink {
            File = 0,
            Directory = 1
        }

        private static string ProfilePathPreTrue { get; } = @"<modsDirectoryOverride active="
                                                                    + Vars.QuoteMark
                                                            + "True" + Vars.QuoteMark
                                                            + " directory=";

        private static string SetGameSettingString {
            get {
                var reg = new RegWork(true);
                var gam = reg.Read(RegKeys.CURRENT_GAME);
                var profile = reg.Read(RegKeys.CURRENT_PROFILE) + "\\";
                string profilePath;
                var pth = string.Empty;

                switch (gam) {
                    case FS11:
                        profilePath = reg.Read(Fs11RegKeys.FS11_PROFILES);
                        pth =
                            $"{ProfilePathPreTrue}{Vars.QuoteMark}{profilePath}{profile}{Vars.QuoteMark} {PROFILE_PATH_END}";
                        break;

                    case FS13:
                        profilePath = reg.Read(Fs13RegKeys.FS13_PROFILES);
                        pth =
                            $"{ProfilePathPreTrue}{Vars.QuoteMark}{profilePath}{profile}{Vars.QuoteMark} {PROFILE_PATH_END}";
                        break;

                    case FS15:
                        profilePath = reg.Read(Fs15RegKeys.FS15_PROFILES);
                        pth =
                            $"{ProfilePathPreTrue}{Vars.QuoteMark}{profilePath}{profile}{Vars.QuoteMark} {PROFILE_PATH_END}";
                        break;

                    case FS17:
                        profilePath = reg.Read(Fs17RegKeys.FS17_PROFILES);
                        pth =
                            $"{ProfilePathPreTrue}{Vars.QuoteMark}{profilePath}{profile}{Vars.QuoteMark} {PROFILE_PATH_END}";
                        break;

                    case FS19:
                        profilePath = reg.Read(FS19RegKeys.FS19_PROFILES);
                        pth =
                            $"{ProfilePathPreTrue}{Vars.QuoteMark}{profilePath}{profile}{Vars.QuoteMark} {PROFILE_PATH_END}";
                        break;
                }

                return pth;
            }
        }

        /// <summary>
        /// Adds the mod to profile.
        /// </summary>
        /// <param name="mod">The mod.</param>
        public static void AddModToProfile(string mod) {
            var frn = Application.OpenForms.OfType<Form1>().Single();
            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            string prof;
            Dictionary<string, string> dic;
            var dic2 = new Dictionary<string, string>();
            IEnumerable<string> lst;

            switch (gam) {
                case "FS11":
                    var profPth = reg.Read(Fs11RegKeys.FS11_PROFILES) + reg.Read(RegKeys.CURRENT_PROFILE) + @"\";
                    prof = profPth + mod;
                    dic = Utils.CompleteSortedList;
                    dic.TryGetValue(mod, out var fnd);
                    if (fnd.IsNullOrEmpty()) return;
                    var modPth = fnd + @"\" + mod;
                    //CreateHardLink(prof, modPth, IntPtr.Zero);
                    CreateLink(prof, modPth);

                    lst = GetFilesFolders.GetFiles(profPth, "*.zip");
                    foreach (var v in lst) {
                        dic.TryGetValue(v.GetFileName(), out var pth);
                        if (dic2.ContainsKey(v.GetFileName())) continue;
                        dic2.Add(v.GetFileName(), pth);
                    }

                    Serializer.SerializeDictionary(profPth + reg.Read(RegKeys.CURRENT_PROFILE) + ".xml", dic2);
                    break;

                case "FS13":
                    profPth = reg.Read(Fs13RegKeys.FS13_PROFILES) + reg.Read(RegKeys.CURRENT_PROFILE) + @"\";
                    prof = profPth + mod;
                    dic = Utils.CompleteSortedList;
                    dic.TryGetValue(mod, out fnd);
                    if (fnd.IsNullOrEmpty()) return;
                    modPth = fnd + @"\" + mod;
                    //CreateHardLink(prof, modPth, IntPtr.Zero);
                    CreateLink(prof, modPth);

                    lst = GetFilesFolders.GetFiles(profPth, "*.zip");
                    foreach (var v in lst) {
                        dic.TryGetValue(v.GetFileName(), out var pth);
                        if (dic2.ContainsKey(v.GetFileName())) continue;
                        dic2.Add(v.GetFileName(), pth);
                    }

                    Serializer.SerializeDictionary(profPth + reg.Read(RegKeys.CURRENT_PROFILE) + ".xml", dic2);
                    break;

                case "FS15":
                    profPth = reg.Read(Fs15RegKeys.FS15_PROFILES) + reg.Read(RegKeys.CURRENT_PROFILE) + @"\";
                    prof = profPth + mod;
                    dic = Utils.CompleteSortedList;
                    dic.TryGetValue(mod, out fnd);
                    if (fnd.IsNullOrEmpty()) return;
                    modPth = fnd + @"\" + mod;
                    //CreateHardLink(prof, modPth, IntPtr.Zero);
                    CreateLink(prof, modPth);

                    lst = GetFilesFolders.GetFiles(profPth, "*.zip");
                    foreach (var v in lst) {
                        dic.TryGetValue(v.GetFileName(), out var pth);
                        if (dic2.ContainsKey(v.GetFileName())) continue;
                        dic2.Add(v.GetFileName(), pth);
                    }

                    Serializer.SerializeDictionary(profPth + reg.Read(RegKeys.CURRENT_PROFILE) + ".xml", dic2);
                    break;

                case "FS17":
                    profPth = reg.Read(Fs17RegKeys.FS17_PROFILES) + reg.Read(RegKeys.CURRENT_PROFILE) + @"\";
                    prof = profPth + mod;
                    dic = Utils.CompleteSortedList;
                    dic.TryGetValue(mod, out fnd);
                    if (fnd.IsNullOrEmpty()) return;
                    modPth = fnd + @"\" + mod;
                    //CreateHardLink(prof, modPth, IntPtr.Zero);
                    CreateLink(prof, modPth);

                    lst = GetFilesFolders.GetFiles(profPth, "*.zip");
                    foreach (var v in lst) {
                        dic.TryGetValue(v.GetFileName(), out var pth);
                        if (dic2.ContainsKey(v.GetFileName()) || pth.IsNullOrEmpty()) continue;
                        dic2.Add(v.GetFileName(), pth);
                    }

                    Serializer.SerializeDictionary(profPth + reg.Read(RegKeys.CURRENT_PROFILE) + ".xml", dic2);
                    break;

                case "FS19":
                    profPth = reg.Read(FS19RegKeys.FS19_PROFILES) + reg.Read(RegKeys.CURRENT_PROFILE) + @"\";
                    prof = profPth + mod;
                    dic = Utils.CompleteSortedList;
                    dic.TryGetValue(mod, out fnd);
                    if (fnd.IsNullOrEmpty()) return;
                    modPth = fnd + @"\" + mod;
                    //CreateHardLink(prof, modPth, IntPtr.Zero);
                    CreateLink(prof, modPth);

                    lst = GetFilesFolders.GetFiles(profPth, "*.zip");
                    foreach (var v in lst) {
                        dic.TryGetValue(v.GetFileName(), out var pth);
                        if (dic2.ContainsKey(v.GetFileName())) continue;
                        dic2.Add(v.GetFileName(), pth);
                    }

                    Serializer.SerializeDictionary(profPth + reg.Read(RegKeys.CURRENT_PROFILE) + ".xml", dic2);
                    break;
            }

            frn.SetLoadProfile();
        }

        /// <summary>
        ///     Creates the link.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <param name="orig">The original.</param>
        public static void CreateLink(string link, string orig) {
            if (Vars.SoftLink) CreateSymbolicLink(link, orig, 0);

            if (Vars.HardLink) CreateHardLink(link, orig, IntPtr.Zero);

            if (Vars.FileCopy) FileCopyMove.FileCopy(orig, link);
        }

        /// <summary>
        /// Deletes the group.
        /// </summary>
        /// <param name="grp">The GRP.</param>
        public static void DeleteGroup(string grp) {
            var lc = new ListCreator();
            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            var hash = Utils.HashListing;

            switch (gam) {
                case FS11:
                    var fPth = reg.Read(Fs11RegKeys.FS11_GROUPS) + @"\" + grp;
                    var lst = GetFilesFolders.GetFiles(fPth + @"\", "*.zip");
                    foreach (var v in lst) {
                        if (!hash.ContainsKey(v.GetFileName())) continue;
                        hash.Remove(v.GetFileName());
                    }
                    Serializer.SerializeDictionary(reg.Read(Fs11RegKeys.FS11_XML) + "hash.xml", hash);
                    DeleteFiles.DeleteFilesOrFolders(fPth);
                    break;

                case FS13:
                    fPth = reg.Read(Fs13RegKeys.FS13_GROUPS) + @"\" + grp;
                    lst = GetFilesFolders.GetFiles(fPth + @"\", "*.zip");
                    foreach (var v in lst) {
                        if (!hash.ContainsKey(v.GetFileName())) continue;
                        hash.Remove(v.GetFileName());
                    }
                    Serializer.SerializeDictionary(reg.Read(Fs13RegKeys.FS13_XML) + "hash.xml", hash);
                    DeleteFiles.DeleteFilesOrFolders(fPth);
                    break;

                case FS15:
                    fPth = reg.Read(Fs15RegKeys.FS15_GROUPS) + @"\" + grp;
                    lst = GetFilesFolders.GetFiles(fPth + @"\", "*.zip");
                    foreach (var v in lst) {
                        if (!hash.ContainsKey(v.GetFileName())) continue;
                        hash.Remove(v.GetFileName());
                    }
                    Serializer.SerializeDictionary(reg.Read(Fs15RegKeys.FS15_XML) + "hash.xml", hash);
                    DeleteFiles.DeleteFilesOrFolders(fPth);
                    break;

                case FS17:
                    fPth = reg.Read(Fs17RegKeys.FS17_GROUPS) + @"\" + grp;
                    lst = GetFilesFolders.GetFiles(fPth + @"\", "*.zip");
                    foreach (var v in lst) {
                        if (!hash.ContainsKey(v.GetFileName())) continue;
                        hash.Remove(v.GetFileName());
                    }
                    Serializer.SerializeDictionary(reg.Read(Fs17RegKeys.FS17_XML) + "hash.xml", hash);
                    DeleteFiles.DeleteFilesOrFolders(fPth);
                    break;

                case FS19:
                    fPth = reg.Read(FS19RegKeys.FS19_GROUPS) + @"\" + grp;
                    lst = GetFilesFolders.GetFiles(fPth + @"\", "*.zip");
                    foreach (var v in lst) {
                        if (!hash.ContainsKey(v.GetFileName())) continue;
                        hash.Remove(v.GetFileName());
                    }
                    Serializer.SerializeDictionary(reg.Read(FS19RegKeys.FS19_XML) + "hash.xml", hash);
                    DeleteFiles.DeleteFilesOrFolders(fPth);
                    break;
            }

            lc.CreateSortedLists();
            lc.SortedFileListComplete();
        }

        /// <summary>
        /// Deletes the group mod.
        /// </summary>
        /// <param name="mod">The mod.</param>
        public static void DeleteGroupMod(string mod) {
            var hash = Utils.HashListing;
            var lc = new ListCreator();
            lc.SortedFileListComplete(false);
            var dic = Utils.CompleteSortedList;
            dic.TryGetValue(mod, out var fnd);
            hash.TryGetValue(mod, out var fndHash);
            if (!fndHash.IsNullOrEmpty()) {
                hash.Remove(mod);
            }
            Utils.WriteHashList(hash);
            DeleteFileA(fnd + @"\" + mod);

            lc.CreateSortedLists();
            lc.SortedFileListComplete();
        }

        /// <summary>
        /// Deletes the profile.
        /// </summary>
        public static void DeleteProfile() {
            var reg = new RegWork(true);
            var lc = new ListCreator();
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            var prof = reg.Read(RegKeys.CURRENT_PROFILE);
            var frn = Application.OpenForms.OfType<Form1>().Single();

            switch (gam) {
                case FS11:
                    DeleteFiles.DeleteFilesOrFolders(reg.Read(Fs11RegKeys.FS11_PROFILES) + @"\" + prof);
                    frn.SetSimFs11();
                    break;

                case FS13:
                    DeleteFiles.DeleteFilesOrFolders(reg.Read(Fs13RegKeys.FS13_PROFILES) + @"\" + prof);
                    frn.SetSimFs13();
                    break;

                case FS15:
                    DeleteFiles.DeleteFilesOrFolders(reg.Read(Fs15RegKeys.FS15_PROFILES) + @"\" + prof);
                    frn.SetSimFs15();
                    break;

                case FS17:
                    DeleteFiles.DeleteFilesOrFolders(reg.Read(Fs17RegKeys.FS17_PROFILES) + @"\" + prof);
                    frn.SetSimFs17();
                    break;

                case FS19:
                    DeleteFiles.DeleteFilesOrFolders(reg.Read(FS19RegKeys.FS19_PROFILES) + @"\" + prof);
                    frn.SetSimFs19();
                    break;
            }

            lc.CreateSortedLists();
        }

        /// <summary>
        /// Deletes the profile mod.
        /// </summary>
        /// <param name="mod">The mod.</param>
        /// <returns></returns>
        public static string DeleteProfileMod(string mod) {
            if (mod.IsNullOrEmpty()) return mod;
            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            var prof = reg.Read(RegKeys.CURRENT_PROFILE);
            var dic = new Dictionary<string, string>();
            var dic2 = Utils.CompleteSortedList;

            IEnumerable<string> lst;
            var ls = new ListCreator();
            if (prof.IsNullOrEmpty()) return mod;

            switch (gam) {
                case FS11:
                    DeleteFileA(reg.Read(Fs11RegKeys.FS11_PROFILES) + @"\" + prof + @"\" +
                                                     mod.GetFileName());
                    lst = GetFilesFolders.GetFiles(reg.Read(Fs11RegKeys.FS11_PROFILES) + @"\" + prof + @"\", "*.zip");
                    foreach (var v in lst) {
                        dic2.TryGetValue(v.GetFileName(), out var fnd);
                        if (dic.ContainsKey(v.GetFileName())) continue;
                        dic.Add(v.GetFileName(), fnd);
                    }
                    Serializer.SerializeDictionary(
                        reg.Read(Fs11RegKeys.FS11_PROFILES) + @"\" + prof + @"\" + prof + ".xml",
                        dic);
                    break;

                case FS13:
                    DeleteFileA(reg.Read(Fs13RegKeys.FS13_PROFILES) + @"\" + prof + @"\" +
                                                     mod.GetFileName());
                    lst = GetFilesFolders.GetFiles(reg.Read(Fs13RegKeys.FS13_PROFILES) + @"\" + prof + @"\", "*.zip");
                    foreach (var v in lst) {
                        dic2.TryGetValue(v.GetFileName(), out var fnd);
                        if (dic.ContainsKey(v.GetFileName())) continue;
                        dic.Add(v.GetFileName(), fnd);
                    }
                    Serializer.SerializeDictionary(
                         reg.Read(Fs13RegKeys.FS13_PROFILES) + @"\" + prof + @"\" + prof + ".xml",
                         dic);
                    break;

                case FS15:
                    DeleteFileA(reg.Read(Fs15RegKeys.FS15_PROFILES) + @"\" + prof + @"\" +
                                                     mod.GetFileName());
                    lst = GetFilesFolders.GetFiles(reg.Read(Fs15RegKeys.FS15_PROFILES) + @"\" + prof + @"\", "*.zip");
                    foreach (var v in lst) {
                        dic2.TryGetValue(v.GetFileName(), out var fnd);
                        if (dic.ContainsKey(v.GetFileName())) continue;
                        dic.Add(v.GetFileName(), fnd);
                    }
                    Serializer.SerializeDictionary(
                         reg.Read(Fs15RegKeys.FS15_PROFILES) + @"\" + prof + @"\" + prof + ".xml",
                         dic);
                    break;

                case FS17:
                    var tmp = reg.Read(Fs17RegKeys.FS17_PROFILES) + prof + @"\" + mod.GetFileName();
                    DeleteFileA(tmp);
                    lst = GetFilesFolders.GetFiles(reg.Read(Fs17RegKeys.FS17_PROFILES) + @"\" + prof + @"\", "*.zip");
                    foreach (var v in lst) {
                        dic2.TryGetValue(v.GetFileName(), out var fnd);
                        if (dic.ContainsKey(v.GetFileName())) continue;
                        dic.Add(v.GetFileName(), fnd);
                    }
                    Serializer.SerializeDictionary(
                        reg.Read(Fs17RegKeys.FS17_PROFILES) + @"\" + prof + @"\" + prof + ".xml",
                        dic);
                    break;

                case FS19:
                    DeleteFileA(reg.Read(FS19RegKeys.FS19_PROFILES) + @"\" + prof + @"\" +
                                                     mod.GetFileName());
                    lst = GetFilesFolders.GetFiles(reg.Read(FS19RegKeys.FS19_PROFILES) + @"\" + prof + @"\", "*.zip");
                    foreach (var v in lst) {
                        dic2.TryGetValue(v.GetFileName(), out var fnd);
                        if (dic.ContainsKey(v.GetFileName())) continue;
                        dic.Add(v.GetFileName(), fnd);
                    }
                    Serializer.SerializeDictionary(
                        reg.Read(FS19RegKeys.FS19_PROFILES) + @"\" + prof + @"\" + prof + ".xml",
                        dic);
                    break;
            }

            ls.CreateSortedLists();
            ls.SortedFileListComplete();
            return mod;
        }

        /// <summary>
        /// Edits the group mod.
        /// </summary>
        /// <param name="key">The key.</param>
        public static void EditGroupMod(string key) {
            var reg = new RegWork(true);
            var pth = string.Empty;
            var dic = Utils.CompleteSortedList;

            if (dic != null && dic.Any(v => string.Equals(v.Key, key, StringComparison.OrdinalIgnoreCase)))
                dic.TryGetValue(key, out pth);

            reg.Write(RegKeys.CURRENT_ORIGINAL_FILE_EDIT_PATH, pth + "\\" + key);
            reg.Write(RegKeys.CURRENT_FILE_EDIT, key);
            FsZip.ExtractArchive(pth + "\\" + key);
            var frm = new EditMod();
            frm.LoadTree();
            frm.ShowDialog();
        }

        /// <summary>
        /// Loads the folder.
        /// </summary>
        public static void LoadFolder(string grp) {
            var gi = new GameInfo();
            var gam = gi.GetGame();
            var reg = new RegWork(true);
            string prof;
            var dic = Utils.GetGroupFileListing(grp);
            var dic2 = Utils.ProfileFileList; ;
            var frn = Application.OpenForms.OfType<Form1>().Single();
            string profXml;

            switch (gam) {
                case "FS11":
                    prof = reg.Read(Fs11RegKeys.FS11_PROFILES) + reg.Read(RegKeys.CURRENT_PROFILE) + @"\";
                    profXml = prof + reg.Read(RegKeys.CURRENT_PROFILE) + ".xml";
                    foreach (var v in dic) {
                        CreateLink(prof + v.Key, v.Value + @"\" + v.Key);
                        if (dic2.ContainsKey(v.Key)) continue;
                        dic2.Add(v.Key, v.Value);
                    }

                    Serializer.SerializeDictionary(profXml, dic2);
                    break;

                case "FS13":
                    prof = reg.Read(Fs13RegKeys.FS13_PROFILES) + reg.Read(RegKeys.CURRENT_PROFILE) + @"\";
                    profXml = prof + reg.Read(RegKeys.CURRENT_PROFILE) + ".xml";
                    foreach (var v in dic) {
                        CreateLink(prof + v.Key, v.Value + @"\" + v.Key);
                        if (dic2.ContainsKey(v.Key)) continue;
                        dic2.Add(v.Key, v.Value);
                    }

                    Serializer.SerializeDictionary(profXml, dic2);
                    break;

                case "FS15":
                    prof = reg.Read(Fs15RegKeys.FS15_PROFILES) + reg.Read(RegKeys.CURRENT_PROFILE) + @"\";
                    profXml = prof + reg.Read(RegKeys.CURRENT_PROFILE) + ".xml";
                    foreach (var v in dic) {
                        CreateLink(prof + v.Key, v.Value + @"\" + v.Key);
                        if (dic2.ContainsKey(v.Key)) continue;
                        dic2.Add(v.Key, v.Value);
                    }

                    Serializer.SerializeDictionary(profXml, dic2);
                    break;

                case "FS17":
                    prof = reg.Read(Fs17RegKeys.FS17_PROFILES) + reg.Read(RegKeys.CURRENT_PROFILE) + @"\";
                    profXml = prof + reg.Read(RegKeys.CURRENT_PROFILE) + ".xml";
                    foreach (var v in dic) {
                        CreateLink(prof + v.Key, v.Value + @"\" + v.Key);
                        if (dic2.ContainsKey(v.Key)) continue;
                        dic2.Add(v.Key, v.Value);
                    }

                    Serializer.SerializeDictionary(profXml, dic2);
                    break;

                case "FS19":
                    prof = reg.Read(FS19RegKeys.FS19_PROFILES) + reg.Read(RegKeys.CURRENT_PROFILE) + @"\";
                    profXml = prof + reg.Read(RegKeys.CURRENT_PROFILE) + ".xml";
                    foreach (var v in dic) {
                        CreateLink(prof + v.Key, v.Value + @"\" + v.Key);
                        if (dic2.ContainsKey(v.Key)) continue;
                        dic2.Add(v.Key, v.Value);
                    }

                    Serializer.SerializeDictionary(profXml, dic2);
                    break;
            }

            frn.SetLoadProfile();
        }

        /// <summary>
        /// Modifies the game settings.
        /// </summary>
        public static void ModifyGameSettings() {
            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            var fw = new FileWriter();
            var tmp = new List<string>();

            switch (gam) {
                case FS11:
                    tmp = fw.FileToList(reg.Read(Fs11RegKeys.FS11_GAME_SETTINGS_XML));
                    break;

                case FS13:
                    tmp = fw.FileToList(reg.Read(Fs13RegKeys.FS13_GAME_SETTINGS_XML));
                    break;

                case FS15:
                    tmp = fw.FileToList(reg.Read(Fs15RegKeys.FS15_GAME_SETTINGS_XML));
                    break;

                case FS17:
                    tmp = fw.FileToList(reg.Read(Fs17RegKeys.FS17_GAME_SETTINGS_XML));
                    break;

                case FS19:
                    tmp = fw.FileToList(reg.Read(FS19RegKeys.FS19_GAME_SETTINGS_XML));
                    break;
            }

            foreach (var s in tmp) {
                if (!s.Contains(@"<modsDirectoryOverride")) continue;
                tmp.Remove(s);
                tmp.Insert(6, SetGameSettingString);
                break;
            }

            fw.ChangeGameSettings(tmp);
        }

        /// <summary>
        /// Mods to repo.
        /// </summary>
        /// <param name="mod">The mod.</param>
        /// <returns></returns>
        public static IEnumerable<string> ModToRepo(string mod) {
            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            reg.Read(RegKeys.CURRENT_PROFILE);
            var ls = new ListCreator();

            IEnumerable<string> lst = null;

            switch (gam) {
                case FS11:
                    var modPath = reg.Read(Fs11RegKeys.FS11_GROUPS) + Vars.FolderName + @"\" + mod;
                    var repo = reg.Read(Fs11RegKeys.FS11_REPO) + mod;
                    FileCopyMove.FileCopy(modPath, repo, true);
                    DeleteFileA(modPath);

                    ls.CreateSortedLists();
                    ls.SortedFileListComplete();
                    break;

                case FS13:
                    modPath = reg.Read(Fs13RegKeys.FS13_GROUPS) + Vars.FolderName + @"\" + mod;
                    repo = reg.Read(Fs13RegKeys.FS13_REPO) + mod;
                    FileCopyMove.FileCopy(modPath, repo, true);
                    DeleteFileA(modPath);

                    ls.CreateSortedLists();
                    ls.SortedFileListComplete();

                    lst = GetFilesFolders.GetFiles(reg.Read(Fs13RegKeys.FS13_GROUPS) + Vars.FolderName + @"\",
                        SEARCH_PATTERN);
                    break;

                case FS15:
                    modPath = reg.Read(Fs15RegKeys.FS15_GROUPS) + Vars.FolderName + @"\" + mod;
                    repo = reg.Read(Fs15RegKeys.FS15_REPO) + mod;
                    FileCopyMove.FileCopy(modPath, repo, true);
                    DeleteFileA(modPath);

                    ls.CreateSortedLists();
                    ls.SortedFileListComplete();

                    lst = GetFilesFolders.GetFiles(reg.Read(Fs15RegKeys.FS15_GROUPS) + Vars.FolderName + @"\",
                        SEARCH_PATTERN);
                    break;

                case FS17:
                    modPath = reg.Read(Fs17RegKeys.FS17_GROUPS) + Vars.FolderName + @"\" + mod;
                    repo = reg.Read(Fs17RegKeys.FS17_REPO) + mod;
                    FileCopyMove.FileCopy(modPath, repo, true);
                    DeleteFileA(modPath);

                    ls.CreateSortedLists();
                    ls.SortedFileListComplete();

                    lst = GetFilesFolders.GetFiles(reg.Read(Fs17RegKeys.FS17_GROUPS) + Vars.FolderName + @"\",
                        SEARCH_PATTERN);
                    break;

                case FS19:
                    modPath = reg.Read(FS19RegKeys.FS19_GROUPS) + Vars.FolderName + @"\" + mod;
                    repo = reg.Read(FS19RegKeys.FS19_REPO) + mod;
                    FileCopyMove.FileCopy(modPath, repo, true);
                    DeleteFileA(modPath);

                    ls.CreateSortedLists();
                    ls.SortedFileListComplete();

                    lst = GetFilesFolders.GetFiles(reg.Read(FS19RegKeys.FS19_GROUPS) + Vars.FolderName + @"\",
                        SEARCH_PATTERN);
                    break;
            }

            return lst;
        }

        /// <summary>
        /// Verifies the mods.
        /// </summary>
        /// <param name="file">The file.</param>
        public static void VerifyMods(string file) {
            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            string pth = null;
            var lc = new ListCreator();

            switch (gam) {
                case "FS11":
                    pth = reg.Read(Fs11RegKeys.FS11_BACKUP) + @"Specials\" + file;
                    break;

                case "FS13":
                    pth = reg.Read(Fs13RegKeys.FS13_BACKUP) + @"Specials\" + file;
                    break;

                case "FS15":
                    pth = reg.Read(Fs15RegKeys.FS15_BACKUP) + @"Specials\" + file;
                    break;

                case "FS17":
                    pth = reg.Read(Fs17RegKeys.FS17_BACKUP) + @"Specials\" + file;
                    break;

                case "FS19":
                    pth = reg.Read(FS19RegKeys.FS19_BACKUP) + @"Specials\" + file;
                    break;
            }

            var cmpList = Utils.CompleteSortedList;
            var hash = Utils.HashListing;
            var lst = new List<string>();

            var dic = Serializer.DeserializeDictionary(pth);
            foreach (var v in dic) {
                var tmp = v.Value + @"\" + v.Key;
                if (tmp.FileExists()) continue;
                cmpList.Remove(v.Key);
                hash.Remove(v.Key);
                lst.Add(v.Key);
            }

            if (lst.Count > 0) {
                foreach (var v in lst) {
                    if (dic.ContainsKey(v.GetFileName())) {
                        dic.Remove(v.GetFileName());
                    }
                }
            }

            Utils.WriteHashList(hash);
            Utils.WriteSpecials(dic, file);
            lc.SortedFileListComplete();
            MsgBx.Msg("Specials Verified and corrected", "Verifier");
        }

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

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool CreateSymbolicLink(
            string lpSymlinkFileName,
            string lpTargetFileName,
            SymbolicLink dwFlags
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteFileA([MarshalAs(UnmanagedType.LPStr)] string lpFileName);
    }
}