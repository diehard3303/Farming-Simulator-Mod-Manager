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

namespace Farming_Simulator_Mod_Manager {

    internal class UpdateSystem {

        /// <summary>
        /// CHKs the mod.
        /// </summary>
        /// <param name="profile">The mod.</param>
        public static void ChkMod(string profile) {
            var gi = new GameInfo();
            var gam = gi.GetGame();

            var dic = Utils.ProfileFileList;
            var hash = Utils.HashListing;

            switch (gam) {
                case "FS11":
                    foreach (var v in dic) {
                        var tmp = v.Value + @"\" + v.Key;
                        var tmpHash = Hasher.HashFile(tmp);
                        hash.TryGetValue(v.Key, out var fnd);
                        if (string.Equals(fnd, tmpHash, StringComparison.OrdinalIgnoreCase)) continue;
                        if (hash.ContainsKey(v.Key)) {
                            hash.Remove(v.Key);
                        }
                        hash.Add(v.Key, tmpHash);
                    }
                    Utils.WriteHashList(hash);
                    break;

                case "FS13":
                    foreach (var v in dic) {
                        var tmp = v.Value + @"\" + v.Key;
                        var tmpHash = Hasher.HashFile(tmp);
                        hash.TryGetValue(v.Key, out var fnd);
                        if (string.Equals(fnd, tmpHash, StringComparison.OrdinalIgnoreCase)) continue;
                        if (hash.ContainsKey(v.Key)) {
                            hash.Remove(v.Key);
                        }
                        hash.Add(v.Key, tmpHash);
                    }
                    Utils.WriteHashList(hash);
                    break;

                case "FS15":
                    foreach (var v in dic) {
                        var tmp = v.Value + @"\" + v.Key;
                        var tmpHash = Hasher.HashFile(tmp);
                        hash.TryGetValue(v.Key, out var fnd);
                        if (string.Equals(fnd, tmpHash, StringComparison.OrdinalIgnoreCase)) continue;
                        if (hash.ContainsKey(v.Key)) {
                            hash.Remove(v.Key);
                        }
                        hash.Add(v.Key, tmpHash);
                    }
                    Utils.WriteHashList(hash);
                    break;

                case "FS17":
                    foreach (var v in dic) {
                        var tmp = v.Value + @"\" + v.Key;
                        var tmpHash = Hasher.HashFile(tmp);
                        hash.TryGetValue(v.Key, out var fnd);
                        if (string.Equals(fnd, tmpHash, StringComparison.OrdinalIgnoreCase)) continue;
                        if (hash.ContainsKey(v.Key)) {
                            hash.Remove(v.Key);
                        }

                        hash.Add(v.Key, tmpHash);
                    }
                    Utils.WriteHashList(hash);
                    break;

                case "FS19":
                    foreach (var v in dic) {
                        var tmp = v.Value + @"\" + v.Key;
                        var tmpHash = Hasher.HashFile(tmp);
                        hash.TryGetValue(v.Key, out var fnd);
                        if (string.Equals(fnd, tmpHash, StringComparison.OrdinalIgnoreCase)) continue;
                        if (hash.ContainsKey(v.Key)) {
                            hash.Remove(v.Key);
                        }
                        hash.Add(v.Key, tmpHash);
                    }
                    Utils.WriteHashList(hash);
                    break;
            }

            MsgBx.Msg("Profile has been updated", "Hasher");
        }

        /// <summary>
        /// Hashes all files.
        /// </summary>
        public static void HashAllFiles() {
            var lc = new ListCreator();
            lc.SortedFileListComplete();

            var dic = new Dictionary<string, string>();
            var lkUp = Utils.CompleteSortedList;

            foreach (var v in lkUp) {
                var tmp = v.Value + @"\" + v.Key;
                var hash = Hasher.HashFile(tmp);
                dic.Add(v.Key, hash);
            }

            Utils.WriteHashList(dic);
        }
    }
}