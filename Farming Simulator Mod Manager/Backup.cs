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
using Extensions;

namespace Farming_Simulator_Mod_Manager {
    internal class Backup {
        public void BackupFiles() {
            var saveList = new List<string> {
                "saveGame1", "saveGame2", "saveGame3", "saveGame4", "saveGame5", "saveGame6",
                "saveGame7", "saveGame8", "saveGame9", "saveGame10", "saveGame11", "saveGame12",
                "saveGame13", "saveGame14", "saveGame15", "saveGame16", "saveGame17", "saveGame18",
                "saveGame19", "saveGame20"
            };

            var reg = new RegWork(true);
            var cm = new FsCheatMoney();
            var bacPath = reg.Read(Fs17RegKeys.FS17_BACKUP) + @"\";
            var bacFile = string.Empty;
            var bacFileFull = string.Empty;
            var gam = reg.Read(RegKeys.CURRENT_GAME);

            if (gam.IsNullOrEmpty()) return;

            switch (gam) {
                case "FS13":
                    foreach (var v in saveList) {
                        bacFile = reg.Read(Fs13RegKeys.FS13_SAVE_GAMES) + @"\" + v + @"\vehicles.xml";
                        if (!bacFile.FileExists()) continue;
                        bacFileFull = bacPath + cm.GetMapName(reg.Read(Fs13RegKeys.FS13_SAVE_GAMES) + @"\" +
                                                              v) + "_" + Guid.NewGuid() + "_vehicles.xml";
                    }
                    break;
                case "FS15":
                    foreach (var v in saveList) {
                        bacFile = reg.Read(Fs15RegKeys.FS15_SAVE_GAMES) + @"\" + v + @"\vehicles.xml";
                        if (!bacFile.FileExists()) continue;
                        bacFileFull = bacPath + cm.GetMapName(reg.Read(Fs15RegKeys.FS15_SAVE_GAMES) + @"\" +
                                                              v) + "_" + Guid.NewGuid() + "_vehicles.xml";
                    }
                    break;
                case  "FS17":
                    foreach (var v in saveList) {
                        bacFile = reg.Read(Fs17RegKeys.FS17_SAVE_GAMES) + @"\" + v + @"\vehicles.xml";
                        if (!bacFile.FileExists()) continue;
                        bacFileFull = bacPath + cm.GetMapName(reg.Read(Fs17RegKeys.FS17_SAVE_GAMES) + @"\" +
                                                              v) + "_" + Guid.NewGuid() + "_vehicles.xml";
                    }

                    break;
                case "FS19":
                    foreach (var v in saveList) {
                        bacFile = reg.Read(FS19RegKeys.FS19_SAVE_GAMES) + @"\" + v + @"\vehicles.xml";
                        if (!bacFile.FileExists()) continue;
                        bacFileFull = bacPath + cm.GetMapName(reg.Read(FS19RegKeys.FS19_SAVE_GAMES) + @"\" +
                                                              v) + "_" + Guid.NewGuid() + "_vehicles.xml";
                    }
                    break;
                    
            }
            
            
                bacFile = bacFile.GetSafeFilename();
                bacFileFull = bacFileFull.GetSafeFilename();
                
                FileCopyMove.FileCopy(bacFile, bacFileFull);
            }
        }
    }
