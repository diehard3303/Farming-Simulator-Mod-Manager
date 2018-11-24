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

namespace Farming_Simulator_Mod_Manager {

    internal class Utils {
        private const string SFL_C_S = "sortedFileListComplete.xml";
        private const string SPC = "Specials";

        /// <summary>
        ///     Gets the app path.
        /// </summary>
        /// <value>The application path.</value>
        public static string AppPath => AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        ///     Gets the by pass list.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> ByPassList {
            get {
                Dictionary<string, string> dic = null;
                var gi = new GameInfo();
                var gam = gi.GetGame();
                var reg = new RegWork(true);

                switch (gam) {
                    case "FS11":
                        dic = Serializer.DeserializeDictionary(reg.Read(Fs11RegKeys.FS11_BACKUP) + SPC + @"\" +
                                                               "bypass.xml");
                        break;

                    case "FS13":
                        dic = Serializer.DeserializeDictionary(reg.Read(Fs13RegKeys.FS13_BACKUP) + SPC + @"\" +
                                                               "bypass.xml");
                        break;

                    case "FS15":
                        dic = Serializer.DeserializeDictionary(reg.Read(Fs15RegKeys.FS15_BACKUP) + SPC + @"\" +
                                                               "bypass.xml");
                        break;

                    case "FS17":
                        dic = Serializer.DeserializeDictionary(reg.Read(Fs17RegKeys.FS17_BACKUP) + SPC + @"\" +
                                                               "bypass.xml");
                        break;

                    case "FS19":
                        dic = Serializer.DeserializeDictionary(reg.Read(FS19RegKeys.FS19_BACKUP) + SPC + @"\" +
                                                               "bypass.xml");
                        break;
                }

                return dic;
            }
        }

        /// <summary>
        ///     Gets the file listing.
        /// </summary>
        /// <returns>dictionary</returns>
        public static Dictionary<string, string> CompleteSortedList {
            get {
                Dictionary<string, string> dic = null;
                var gi = new GameInfo();
                var gam = gi.GetGame();
                var reg = new RegWork(true);

                switch (gam) {
                    case "FS11":
                        dic = Serializer.DeserializeDictionary(
                            reg.Read(Fs11RegKeys.FS11_XML) + SFL_C_S);
                        break;

                    case "FS13":
                        dic = Serializer.DeserializeDictionary(
                            reg.Read(Fs13RegKeys.FS13_XML) + SFL_C_S);
                        break;

                    case "FS15":
                        dic = Serializer.DeserializeDictionary(
                            reg.Read(Fs15RegKeys.FS15_XML) + SFL_C_S);
                        break;

                    case "FS17":
                        dic = Serializer.DeserializeDictionary(
                            reg.Read(Fs17RegKeys.FS17_XML) + SFL_C_S);
                        break;

                    case "FS19":
                        dic = Serializer.DeserializeDictionary(
                            reg.Read(FS19RegKeys.FS19_XML) + SFL_C_S);
                        break;
                }

                return dic;
            }
        }

        /// <summary>
        ///     Gets the hash listing.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> HashListing {
            get {
                Dictionary<string, string> dic = null;
                var gi = new GameInfo();
                var gam = gi.GetGame();
                var reg = new RegWork(true);

                switch (gam) {
                    case "FS11":
                        dic = Serializer.DeserializeDictionary(
                            reg.Read(Fs11RegKeys.FS11_XML) + "hash.xml");
                        break;

                    case "FS13":
                        dic = Serializer.DeserializeDictionary(
                            reg.Read(Fs13RegKeys.FS13_XML) + "hash.xml");
                        break;

                    case "FS15":
                        dic = Serializer.DeserializeDictionary(
                            reg.Read(Fs15RegKeys.FS15_XML) + "hash.xml");
                        break;

                    case "FS17":
                        dic = Serializer.DeserializeDictionary(
                            reg.Read(Fs17RegKeys.FS17_XML) + "hash.xml");
                        break;

                    case "FS19":
                        dic = Serializer.DeserializeDictionary(
                            reg.Read(FS19RegKeys.FS19_XML) + "hash.xml");
                        break;
                }

                return dic;
            }
        }

        /// <summary>
        ///     Gets the group file list.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> ProfileFileList {
            get {
                Dictionary<string, string> dic = null;
                var gi = new GameInfo();
                var gam = gi.GetGame();
                var reg = new RegWork(true);

                switch (gam) {
                    case "FS11":
                        dic = Serializer.DeserializeDictionary(reg.Read(Fs11RegKeys.FS11_PROFILES) +
                                                               reg.Read(RegKeys.CURRENT_PROFILE) + @"\" +
                                                               reg.Read(RegKeys.CURRENT_PROFILE) + ".xml");
                        break;

                    case "FS13":
                        dic = Serializer.DeserializeDictionary(reg.Read(Fs13RegKeys.FS13_PROFILES) +
                                                               reg.Read(RegKeys.CURRENT_PROFILE) + @"\" +
                                                               reg.Read(RegKeys.CURRENT_PROFILE) + ".xml");
                        break;

                    case "FS15":
                        dic = Serializer.DeserializeDictionary(reg.Read(Fs15RegKeys.FS15_PROFILES) +
                                                               reg.Read(RegKeys.CURRENT_PROFILE) + @"\" +
                                                               reg.Read(RegKeys.CURRENT_PROFILE) + ".xml");
                        break;

                    case "FS17":
                        dic = Serializer.DeserializeDictionary(reg.Read(Fs17RegKeys.FS17_PROFILES) +
                                                               reg.Read(RegKeys.CURRENT_PROFILE) + @"\" +
                                                               reg.Read(RegKeys.CURRENT_PROFILE) + ".xml");
                        break;

                    case "FS19":
                        dic = Serializer.DeserializeDictionary(reg.Read(FS19RegKeys.FS19_PROFILES) +
                                                               reg.Read(RegKeys.CURRENT_PROFILE) + @"\" +
                                                               reg.Read(RegKeys.CURRENT_PROFILE) + ".xml");
                        break;
                }

                return dic;
            }
        }

        /// <summary>
        ///     Deletes the group file list.
        /// </summary>
        /// <param name="grp">The GRP.</param>
        public static void DeleteGroupFileList(string grp) {
            var dic = GetGroupFileListing(grp);
            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            var gProf = reg.Read(RegKeys.CURRENT_PROFILE);

            switch (gam) {
                case "FS11":
                    var gProfPath = reg.Read(Fs11RegKeys.FS11_PROFILES) + gProf + @"\";
                    foreach (var v in dic) {
                        var tmp = gProfPath + v.Key;
                        if (!tmp.FileExists()) continue;
                        DeleteFiles.DeleteFilesOrFolders(tmp);
                    }

                    break;

                case "FS13":
                    gProfPath = reg.Read(Fs13RegKeys.FS13_PROFILES) + gProf + @"\";
                    foreach (var v in dic) {
                        var tmp = gProfPath + v.Key;
                        if (!tmp.FileExists()) continue;
                        DeleteFiles.DeleteFilesOrFolders(tmp);
                    }

                    break;

                case "FS15":
                    gProfPath = reg.Read(Fs15RegKeys.FS15_PROFILES) + gProf + @"\";
                    foreach (var v in dic) {
                        var tmp = gProfPath + v.Key;
                        if (!tmp.FileExists()) continue;
                        DeleteFiles.DeleteFilesOrFolders(tmp);
                    }

                    break;

                case "FS17":
                    gProfPath = reg.Read(Fs17RegKeys.FS17_PROFILES) + gProf + @"\";
                    foreach (var v in dic) {
                        var tmp = gProfPath + v.Key;
                        if (!tmp.FileExists()) continue;
                        DeleteFiles.DeleteFilesOrFolders(tmp);
                    }

                    break;

                case "FS19":
                    gProfPath = reg.Read(FS19RegKeys.FS19_PROFILES) + gProf + @"\";
                    foreach (var v in dic) {
                        var tmp = gProfPath + v.Key;
                        if (!tmp.FileExists()) continue;
                        DeleteFiles.DeleteFilesOrFolders(tmp, false);
                    }

                    break;
            }
        }

        /// <summary>
        ///     Gets the group file listing.
        /// </summary>
        /// <param name="grp">The GRP.</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetGroupFileListing(string grp) {
            Dictionary<string, string> dic = null;
            var gi = new GameInfo();
            var gam = gi.GetGame();
            var reg = new RegWork(true);

            switch (gam) {
                case "FS11":
                    dic = Serializer.DeserializeDictionary(
                        reg.Read(Fs11RegKeys.FS11_GROUPS) + grp + @"\" + grp + ".xml");
                    break;

                case "FS13":
                    dic = Serializer.DeserializeDictionary(
                        reg.Read(Fs13RegKeys.FS13_GROUPS) + grp + @"\" + grp + ".xml");
                    break;

                case "FS15":
                    dic = Serializer.DeserializeDictionary(
                        reg.Read(Fs15RegKeys.FS15_GROUPS) + grp + @"\" + grp + ".xml");
                    break;

                case "FS17":
                    dic = Serializer.DeserializeDictionary(
                        reg.Read(Fs17RegKeys.FS17_GROUPS) + grp + @"\" + grp + ".xml");
                    break;

                case "FS19":
                    dic = Serializer.DeserializeDictionary(
                        reg.Read(FS19RegKeys.FS19_GROUPS) + grp + @"\" + grp + ".xml");
                    break;
            }

            return dic;
        }

        /// <summary>
        ///     Gets the specials.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetSpecials(string fileName) {
            Dictionary<string, string> dic = null;
            var gi = new GameInfo();
            var gam = gi.GetGame();
            var reg = new RegWork(true);

            switch (gam) {
                case "FS11":
                    dic = Serializer.DeserializeDictionary(
                        reg.Read(Fs11RegKeys.FS11_BACKUP) + @"Specials\" + fileName);
                    break;

                case "FS13":
                    dic = Serializer.DeserializeDictionary(
                        reg.Read(Fs13RegKeys.FS13_BACKUP) + @"Specials\" + fileName);
                    break;

                case "FS15":
                    dic = Serializer.DeserializeDictionary(
                        reg.Read(Fs15RegKeys.FS15_BACKUP) + @"Specials\" + fileName);
                    break;

                case "FS17":
                    dic = Serializer.DeserializeDictionary(
                        reg.Read(Fs17RegKeys.FS17_BACKUP) + @"Specials\" + fileName);
                    break;

                case "FS19":
                    dic = Serializer.DeserializeDictionary(
                        reg.Read(FS19RegKeys.FS19_BACKUP) + @"Specials\" + fileName);
                    break;
            }

            return dic;
        }

        /// <summary>
        ///     Writes the by pass list.
        /// </summary>
        /// <param name="dic">The dic.</param>
        public static void WriteByPassList(Dictionary<string, string> dic) {
            var gi = new GameInfo();
            var gam = gi.GetGame();
            var reg = new RegWork(true);

            switch (gam) {
                case "FS11":
                    Serializer.SerializeDictionary(reg.Read(Fs11RegKeys.FS11_BACKUP) + SPC + @"\" +
                                                   "bypass.xml", dic);
                    break;

                case "FS13":
                    Serializer.SerializeDictionary(reg.Read(Fs13RegKeys.FS13_BACKUP) + SPC + @"\" +
                                                   "bypass.xml", dic);
                    break;

                case "FS15":
                    Serializer.SerializeDictionary(reg.Read(Fs15RegKeys.FS15_BACKUP) + SPC + @"\" +
                                                   "bypass.xml", dic);
                    break;

                case "FS17":
                    Serializer.SerializeDictionary(reg.Read(Fs17RegKeys.FS17_BACKUP) + SPC + @"\" +
                                                   "bypass.xml", dic);
                    break;

                case "FS19":
                    Serializer.SerializeDictionary(reg.Read(FS19RegKeys.FS19_BACKUP) + SPC + @"\" +
                                                   "bypass.xml", dic);
                    break;
            }
        }

        /// <summary>
        ///     Writes the hash list.
        /// </summary>
        /// <param name="dic">The dic.</param>
        public static void WriteHashList(Dictionary<string, string> dic) {
            var gi = new GameInfo();
            var gam = gi.GetGame();
            var reg = new RegWork(true);

            switch (gam) {
                case "FS11":
                    Serializer.SerializeDictionary(reg.Read(Fs11RegKeys.FS11_XML) +
                                                   "hash.xml", dic);
                    break;

                case "FS13":
                    Serializer.SerializeDictionary(reg.Read(Fs13RegKeys.FS13_XML) +
                                                   "hash.xml", dic);
                    break;

                case "FS15":
                    Serializer.SerializeDictionary(reg.Read(Fs15RegKeys.FS15_XML) +
                                                   "hash.xml", dic);
                    break;

                case "FS17":
                    Serializer.SerializeDictionary(reg.Read(Fs17RegKeys.FS17_XML) +
                                                   "hash.xml", dic);
                    break;

                case "FS19":
                    Serializer.SerializeDictionary(reg.Read(FS19RegKeys.FS19_XML) +
                                                   "hash.xml", dic);
                    break;
            }
        }

        /// <summary>
        ///     Writes the specials.
        /// </summary>
        /// <param name="spc">The SPC.</param>
        /// <param name="fileName">Name of the file.</param>
        public static void WriteSpecials(Dictionary<string, string> spc, string fileName) {
            var gi = new GameInfo();
            var gam = gi.GetGame();
            var reg = new RegWork(true);

            switch (gam) {
                case "FS11":
                    Serializer.SerializeDictionary(
                        reg.Read(Fs11RegKeys.FS11_BACKUP) + @"Specials\" + fileName, spc);
                    break;

                case "FS13":
                    Serializer.SerializeDictionary(
                        reg.Read(Fs13RegKeys.FS13_BACKUP) + @"Specials\" + fileName, spc);
                    break;

                case "FS15":
                    Serializer.SerializeDictionary(
                        reg.Read(Fs15RegKeys.FS15_BACKUP) + @"Specials\" + fileName, spc);
                    break;

                case "FS17":
                    Serializer.SerializeDictionary(
                        reg.Read(Fs17RegKeys.FS17_BACKUP) + @"Specials\" + fileName, spc);
                    break;

                case "FS19":
                    Serializer.SerializeDictionary(
                        reg.Read(FS19RegKeys.FS19_BACKUP) + @"Specials\" + fileName, spc);
                    break;
            }
        }
    }
}