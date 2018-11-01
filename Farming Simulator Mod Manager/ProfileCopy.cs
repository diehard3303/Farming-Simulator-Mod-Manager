using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Extensions;

namespace Farming_Simulator_Mod_Manager {
    /// <summary>
    /// 
    /// </summary>
    public static class ProfileCopy {
        private const string SEARCH_PATTERN = "*.zip";

        /// <summary>
        /// 
        /// </summary>
        public static void CopyProfile() {
            CopyProf();
        }

        private static void CopyProf() {
            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            var prof = reg.Read(RegKeys.CURRENT_PROFILE);
            if (prof.IsNullOrEmpty() || gam.IsNullOrEmpty()) {
                MsgBx.Msg("You must have a Profile / Game Active", "Profile Error");
                return;
            }
            string pth;
            IEnumerable<string> lst;

            switch (gam) {
                case "FS11":
                    pth = reg.Read(Fs11RegKeys.FS11_PROFILES) + prof;
                    lst = GetFilesFolders.GetFiles(pth, SEARCH_PATTERN);
                    var dic = Serializer.DeserializeDictionary(
                        $"{reg.Read(Fs11RegKeys.FS11_XML)}sortedFileListComplete.xml");
                    var dic2 = new Dictionary<string, string>();
                    var enumerable = lst.ToList();
                    foreach (var v in dic) {
                        foreach (var c in enumerable) {
                            if (string.Equals(v.Key, c.GetFileName(), StringComparison.OrdinalIgnoreCase)) {
                                dic2.Add(v.Key, v.Value);
                            }
                        }
                    }

                    if (dic2.IsNull()) return;
                    var bckPath = $"{reg.Read(Fs11RegKeys.FS11_BACKUP)}\\{prof}.xml";
                    Serializer.SerializeDictionary(bckPath, dic2);
                    Process.Start(bckPath);
                    break;
                case "FS13":
                    pth = reg.Read(Fs13RegKeys.FS13_PROFILES) + prof;
                    lst = GetFilesFolders.GetFiles(pth, SEARCH_PATTERN);
                    dic = Serializer.DeserializeDictionary(
                        $"{reg.Read(Fs13RegKeys.FS13_XML)}sortedFileListComplete.xml");
                    dic2 = new Dictionary<string, string>();
                    enumerable = lst.ToList();
                    foreach (var v in dic) {
                        foreach (var c in enumerable) {
                            if (string.Equals(v.Key, c.GetFileName(), StringComparison.OrdinalIgnoreCase)) {
                                dic2.Add(v.Key, v.Value);
                            }
                        }
                    }

                    if (dic2.IsNull()) return;
                    bckPath = $"{reg.Read(Fs13RegKeys.FS13_BACKUP)}\\{prof}.xml";
                    Serializer.SerializeDictionary(bckPath, dic2);
                    Process.Start(bckPath);
                    break;
                case "FS15":
                    pth = reg.Read(Fs15RegKeys.FS15_PROFILES) + prof;
                    lst = GetFilesFolders.GetFiles(pth, SEARCH_PATTERN);
                    dic = Serializer.DeserializeDictionary(
                        $"{reg.Read(Fs15RegKeys.FS15_XML)}sortedFileListComplete.xml");
                    dic2 = new Dictionary<string, string>();
                    enumerable = lst.ToList();
                    foreach (var v in dic) {
                        foreach (var c in enumerable) {
                            if (string.Equals(v.Key, c.GetFileName(), StringComparison.OrdinalIgnoreCase)) {
                                dic2.Add(v.Key, v.Value);
                            }
                        }
                    }

                    if (dic2.IsNull()) return;
                    bckPath = $"{reg.Read(Fs15RegKeys.FS15_BACKUP)}\\{prof}.xml";
                    Serializer.SerializeDictionary(bckPath, dic2);
                    Process.Start(bckPath);
                    break;
                case "FS17":
                    pth = reg.Read(Fs17RegKeys.FS17_PROFILES) + prof;
                    lst = GetFilesFolders.GetFiles(pth, SEARCH_PATTERN);
                    dic = Serializer.DeserializeDictionary(
                        $"{reg.Read(Fs17RegKeys.FS17_XML)}sortedFileListComplete.xml");
                    dic2 = new Dictionary<string, string>();
                    enumerable = lst.ToList();
                    foreach (var v in dic) {
                        foreach (var c in enumerable) {
                            if (string.Equals(v.Key, c.GetFileName(), StringComparison.OrdinalIgnoreCase)) {
                                dic2.Add(v.Key, v.Value);
                            }
                        }
                    }

                    if (dic2.IsNull()) return;
                    bckPath = $"{reg.Read(Fs17RegKeys.FS17_BACKUP)}\\{prof}.xml";
                    Serializer.SerializeDictionary(bckPath, dic2);
                    Process.Start(bckPath);
                    break;
                case "FS19":
                    pth = reg.Read(FS19RegKeys.FS19_PROFILES) + prof;
                    lst = GetFilesFolders.GetFiles(pth, SEARCH_PATTERN);
                    dic = Serializer.DeserializeDictionary($"{reg.Read(FS19RegKeys.FS19_XML)}sortedFileListComplete.xml");
                    dic2 = new Dictionary<string, string>();
                    enumerable = lst.ToList();
                    foreach (var v in dic) {
                        foreach (var c in enumerable) {
                            if (string.Equals(v.Key, c.GetFileName(), StringComparison.OrdinalIgnoreCase)) {
                                dic2.Add(v.Key, v.Value);
                            }
                        }
                    }

                    if (dic2.IsNull()) return;
                    bckPath = $"{reg.Read(FS19RegKeys.FS19_BACKUP)}\\{prof}.xml";
                    Serializer.SerializeDictionary(bckPath, dic2);
                    Process.Start(bckPath);
                    break;
            }

          
        }
    }
}