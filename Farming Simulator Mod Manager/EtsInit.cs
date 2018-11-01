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

using System.Windows.Forms;
using Extensions;

namespace Farming_Simulator_Mod_Manager {
    internal class EtsInit {
        /// <summary>
        ///     Initializes the ats.
        /// </summary>
        public void InitializeEts() {
            var atsw = new RegWork(true);
            var tmp = atsw.Read(EtsRegKeys.ETS_REPO);
            if (!tmp.IsNullOrEmpty()) return;

            var diag = MessageBox.Show(@"Do you want me to setup Euro Truck Simulator 2?", @"ETS Init",
                MessageBoxButtons.YesNo);
            if (diag != DialogResult.Yes) return;

            CreateFolders();
        }

        private static void CreateFolders() {
            var atsw = new RegWork(true);

            var ofd = new FolderBrowserDialog {
                Description = @"Navigate to where you want the top folder for ETS",
                ShowNewFolderButton = false
            };
            ofd.ShowDialog();
            if (!ofd.SelectedPath.FolderExists()) return;
            var pth = ofd.SelectedPath;
            FolderCreator.CreatePublicFolders(pth + "\\ETSRepo");
            atsw.Write(EtsRegKeys.ETS_REPO, pth + "\\ETSRepo\\");
            var tmp = pth + "\\ETSRepo\\";
            FolderCreator.CreatePublicFolders(tmp + "ETSExtraction");
            atsw.Write(EtsRegKeys.ETS_EXTRACTION, tmp + "ETSExtraction");
            FolderCreator.CreatePublicFolders(tmp + "ETSProfiles");
            atsw.Write(EtsRegKeys.ETS_PROFILES, tmp + "ETSProfiles\\");
            FolderCreator.CreatePublicFolders(tmp + "ETSGroups");
            atsw.Write(EtsRegKeys.ETS_GROUPS, tmp + "ETSGroups\\");
            FolderCreator.CreatePublicFolders(tmp + "ETSXml");
            atsw.Write(EtsRegKeys.ETS_XML, tmp + "ETSXml\\");
            FolderCreator.CreatePublicFolders(tmp + "ETSWork");
            atsw.Write(EtsRegKeys.ETS_WORK, tmp + "ETSWork\\");

            ofd = new FolderBrowserDialog {
                Description = @"Navigate to your ETS Game Mod Folder",
                ShowNewFolderButton = false
            };
            ofd.ShowDialog();
            if (ofd.SelectedPath.FolderExists()) atsw.Write(EtsRegKeys.ETS_GAME_MOD_FOLDER, ofd.SelectedPath + "\\");

            MsgBx.Msg("All folders have been created for ETS", "Game Intializer");
        }
    }
}