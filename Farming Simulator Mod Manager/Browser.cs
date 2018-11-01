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

using System.Diagnostics;

namespace Farming_Simulator_Mod_Manager {
    internal static class Browser {
        /// <summary>
        ///     Browses the folders.
        /// </summary>
        /// <param name="fold">The fold.</param>
        public static void BrowseFolders(string fold) {
            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            const string modList = "sortedFileListComplete.xml";
            var pth = string.Empty;

            switch (fold) {
                case "repo":
                    switch (gam) {
                       case "FS11":
                            pth = reg.Read(Fs11RegKeys.FS11_REPO);
                            break;
                        
                        case "FS13":
                            pth = reg.Read(Fs13RegKeys.FS13_REPO);
                            break;

                        case "FS15":
                            pth = reg.Read(Fs15RegKeys.FS15_REPO);
                            break;

                        case "FS17":
                            pth = reg.Read(Fs17RegKeys.FS17_REPO);
                            break;
                        
                        case "FS19":
                            pth = reg.Read(FS19RegKeys.FS19_REPO);
                            break;
                    }

                    break;

                case "backup":
                    switch (gam) {
                        case "FS11":
                            pth = reg.Read(Fs11RegKeys.FS11_BACKUP);
                            break;
                        
                        case "FS13":
                            pth = reg.Read(Fs13RegKeys.FS13_BACKUP);
                            break;

                        case "FS15":
                            pth = reg.Read(Fs15RegKeys.FS15_BACKUP);
                            break;

                        case "FS17":
                            pth = reg.Read(Fs17RegKeys.FS17_BACKUP);
                            break;
                        
                        case "FS19":
                            pth = reg.Read(FS19RegKeys.FS19_BACKUP);
                            break;
                    }

                    break;

                case "groups":
                    switch (gam) {
                        case "FS11":
                            pth = reg.Read(Fs11RegKeys.FS11_GROUPS);
                            break;
                        
                        case "FS13":
                            pth = reg.Read(Fs13RegKeys.FS13_GROUPS);
                            break;

                        case "FS15":
                            pth = reg.Read(Fs15RegKeys.FS15_GROUPS);
                            break;

                        case "FS17":
                            pth = reg.Read(Fs17RegKeys.FS17_GROUPS);
                            break;
                        
                        case "FS19":
                            pth = reg.Read(FS19RegKeys.FS19_GROUPS);
                            break;
                    }

                    break;

                case "work":
                    switch (gam) {
                        case "FS11":
                            pth = reg.Read(Fs11RegKeys.FS11_WORK);
                            break;
                        
                        case "FS13":
                            pth = reg.Read(Fs13RegKeys.FS13_WORK);
                            break;

                        case "FS15":
                            pth = reg.Read(Fs15RegKeys.FS15_WORK);
                            break;

                        case "FS17":
                            pth = reg.Read(Fs17RegKeys.FS17_WORK);
                            break;
                        
                        case "FS19":
                            pth = reg.Read(FS19RegKeys.FS19_WORK);
                            break;
                    }

                    break;

                case "list":
                    switch (gam) {
                        case "FS11":
                            pth = reg.Read(Fs11RegKeys.FS11_XML) + modList;
                            break;
                        
                        case "FS13":
                            pth = reg.Read(Fs13RegKeys.FS13_XML) + modList;
                            break;

                        case "FS15":
                            pth = reg.Read(Fs15RegKeys.FS15_XML) + modList;
                            break;

                        case "FS17":
                            pth = reg.Read(Fs17RegKeys.FS17_XML) + modList;
                            break;
                        
                        case "FS19":
                            pth = reg.Read(FS19RegKeys.FS19_XML) + modList;
                            break;
                    }

                    break;

                case "fav":
                    switch (gam) {
                        case "FS11":
                            pth = reg.Read(Fs11RegKeys.FS11_GROUPS) + "BypassSorting.xml";
                            break;
                        case "FS13":
                            pth = reg.Read(Fs13RegKeys.FS13_GROUPS) + "BypassSorting.xml";
                            break;
                        case "FS15":
                            pth = reg.Read(Fs15RegKeys.FS15_GROUPS) + "BypassSorting.xml";
                            break;
                        case "FS17":
                            pth = reg.Read(Fs17RegKeys.FS17_GROUPS) + "BypassSorting.xml";
                            break;
                        case "FS19":
                            pth = reg.Read(FS19RegKeys.FS19_GROUPS) + "BypassSorting.xml";
                            break;
                    }

                    break;
            }

            Process.Start(pth);
        }
    }
}