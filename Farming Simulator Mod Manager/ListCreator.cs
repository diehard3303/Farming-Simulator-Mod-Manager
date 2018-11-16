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
using System.IO;
using Extensions;

namespace Farming_Simulator_Mod_Manager {
    internal class ListCreator {
        private string FolderPath { set; get; }

        /// <summary>
        ///     Creates the sorted lists.
        /// </summary>
        public void CreateSortedLists() {
            var gi = new GameInfo();
            var tmp = gi.GetGame();
            if (tmp.IsNullOrEmpty()) return;
            var src = string.Empty;
            var reg = new RegWork(true);
            var dicPath = string.Empty;
            Dictionary<string, string> sl = null;

            var pth = string.Empty;
            var cProf = string.Empty;

            switch (tmp) {
                case "FS11":
                    var fs11 = new RegWork(true);
                    pth = fs11.Read(Fs11RegKeys.FS11_GROUPS);
                    cProf = fs11.Read(Fs11RegKeys.FS11_PROFILES);
                    src = "*.zip";
                    sl = Serializer.DeserializeDictionary(reg.Read(Fs11RegKeys.FS11_XML) +
                                                          @"\sortedFileListComplete.xml");
                    break;

                case "FS13":
                    var fs13 = new RegWork(true);
                    pth = fs13.Read(Fs13RegKeys.FS13_GROUPS);
                    cProf = fs13.Read(Fs13RegKeys.FS13_PROFILES);
                    src = "*.zip";
                    sl = Serializer.DeserializeDictionary(reg.Read(Fs13RegKeys.FS13_XML) +
                                                          @"\sortedFileListComplete.xml");
                    break;

                case "FS15":
                    var fs15 = new RegWork(true);
                    pth = fs15.Read(Fs15RegKeys.FS15_GROUPS);
                    cProf = fs15.Read(Fs15RegKeys.FS15_PROFILES);
                    src = "*.zip";
                    sl = Serializer.DeserializeDictionary(reg.Read(Fs15RegKeys.FS15_XML) +
                                                          @"\sortedFileListComplete.xml");
                    break;

                case "FS17":
                    var fs17 = new RegWork(true);
                    pth = fs17.Read(Fs17RegKeys.FS17_GROUPS);
                    cProf = fs17.Read(Fs17RegKeys.FS17_PROFILES);
                    src = "*.zip";
                    sl = Serializer.DeserializeDictionary(reg.Read(Fs17RegKeys.FS17_XML) +
                                                          @"\sortedFileListComplete.xml");
                    break;

                case "FS19":
                    var fs19 = new RegWork(true);
                    pth = fs19.Read(FS19RegKeys.FS19_GROUPS);
                    cProf = fs19.Read(FS19RegKeys.FS19_PROFILES);
                    src = "*.zip";
                    sl = Serializer.DeserializeDictionary(reg.Read(FS19RegKeys.FS19_XML) +
                                                          @"\sortedFileListComplete.xml");
                    break;
            }

            var foldList = GetFilesFolders.GetFolders(pth, "*.*");
            var profList = GetFilesFolders.GetFolders(cProf, "*.*");
            var dic = new Dictionary<string, string>();

            foreach (var v in foldList) {
                var lst = GetFilesFolders.GetFiles(v, src);
                dic = new Dictionary<string, string>();
                foreach (var t in lst) {
                    if (CheckPath(t)) continue;
                    var file = t.GetFileName();
                    var ph = Path.GetDirectoryName(t);
                    if (dic.ContainsKey(file)) continue;
                    dic.Add(file, ph + "\\");
                }

                var nam = v.GetLastFolderName();
                Serializer.SerializeDictionary(v + "\\" + nam + ".xml", dic);
            }

            foreach (var v in profList) {
                var proFiles = GetFilesFolders.GetFiles(v + @"\", src);
                dic = new Dictionary<string, string>();
                Vars.FldName = @"\" + v.GetLastFolderName() + @"\";
                foreach (var proFile in proFiles) {
                    sl.TryGetValue(proFile.GetFileName(), out var fnd);
                    if (fnd.IsNullOrEmpty()) continue;
                    if (dic.ContainsKey(proFile.GetFileName())) continue;
                    dic.Add(proFile.GetFileName(), fnd);
                }

                Serializer.SerializeDictionary(v + @"\" + v.GetLastFolderName() + ".xml", dic);
            }
        }

        /// <summary>
        ///     Makes the sorted list.
        /// </summary>
        public void SortedFileListComplete(bool pop = true) {
            var gi = new GameInfo();
            var tmp = gi.GetGame();
            if (tmp.IsNullOrEmpty()) return;
            IEnumerable<string> lst = null;
            var path = string.Empty;

            switch (tmp) {
                case "FS11":
                    var fs11 = new RegWork(true);
                    path = fs11.Read(Fs11RegKeys.FS11_XML) + "sortedFileListComplete.xml";
                    FolderPath = fs11.Read(Fs11RegKeys.FS11_GROUPS);
                    lst = GetFilesFolders.GetFilesRecursive(FolderPath, "*.zip");
                    break;

                case "FS13":
                    var fs13 = new RegWork(true);
                    path = fs13.Read(Fs13RegKeys.FS13_XML) + "sortedFileListComplete.xml";
                    FolderPath = fs13.Read(Fs13RegKeys.FS13_GROUPS);
                    lst = GetFilesFolders.GetFilesRecursive(FolderPath, "*.zip");
                    break;

                case "FS15":
                    var fs15 = new RegWork(true);
                    path = fs15.Read(Fs15RegKeys.FS15_XML) + "sortedFileListComplete.xml";
                    FolderPath = fs15.Read(Fs15RegKeys.FS15_GROUPS);
                    lst = GetFilesFolders.GetFilesRecursive(FolderPath, "*.zip");
                    break;

                case "FS17":
                    var fs17 = new RegWork(true);
                    path = fs17.Read(Fs17RegKeys.FS17_XML) + "sortedFileListComplete.xml";
                    FolderPath = fs17.Read(Fs17RegKeys.FS17_GROUPS);
                    lst = GetFilesFolders.GetFilesRecursive(FolderPath, "*.zip");
                    break;

                case "FS19":
                    var fs19 = new RegWork(true);
                    path = fs19.Read(FS19RegKeys.FS19_XML) + "sortedFileListComplete.xml";
                    FolderPath = fs19.Read(FS19RegKeys.FS19_GROUPS);
                    lst = GetFilesFolders.GetFilesRecursive(FolderPath, "*.zip");
                    break;
            }

            var dic = new Dictionary<string, string>();
            // ReSharper disable once PossibleNullReferenceException
            foreach (var v in lst) {
                var file = v.GetFileName();
                var pth = Path.GetDirectoryName(v);
                if (dic.ContainsKey(file)) continue;
                dic.Add(file, pth + "\\");
            }

            Serializer.SerializeDictionary(path, dic);
            if (pop) {
                MsgBx.Msg("List Creation Completed", "List Creator");
            }
        }

        private static bool CheckPath(string t) {
            var inFo = new DirectoryInfo(t);
            var fnd =inFo.GetSymbolicLinkTarget();
            return fnd.IsNullOrEmpty();
        }
    }
}