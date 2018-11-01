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
using System.Windows.Forms;
using Extensions;

namespace Farming_Simulator_Mod_Manager {
    internal class ReadLogFile {
        /// <summary>
        ///     Reads the log files.
        /// </summary>
        public void ReadLogFiles() {
            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);
            var ofd = new OpenFileDialog();
            var pth = string.Empty;

            switch (gam) {
                /*case "ATS":
                    pth = reg.Read(AtsRegKeys.ATS_LOG_FILE);
                    if (pth.IsNullOrEmpty()) {
                        ofd.Title =
                            @"Navigate to the ATS Log File, usually in my documents under American Truck Simulator";
                        ofd.ShowDialog();
                        if (!ofd.FileName.FileExists()) return;
                        reg.Write(AtsRegKeys.ATS_LOG_FILE, ofd.FileName);
                        pth = ofd.FileName;
                    }

                    break;

                case "ETS":
                    pth = reg.Read(EtsRegKeys.ETS_LOG_FILE);
                    if (pth.IsNullOrEmpty()) {
                        ofd.Title =
                            @"Navigate to the ETS Log File, usually in my documents under Euro Truck Simulator 2";
                        ofd.ShowDialog();
                        if (!ofd.FileName.FileExists()) return;
                        reg.Write(EtsRegKeys.ETS_LOG_FILE, ofd.FileName);
                        pth = ofd.FileName;
                    }

                    break;*/
                
                case "FS11":
                    pth = reg.Read(Fs11RegKeys.FS11_LOG_FILE);
                    if (pth.IsNullOrEmpty()) {
                        ofd.Title =
                            @"Navigate to the FS11 Log File, usually in my documents/My Games under Farming Simulator 2013";
                        ofd.ShowDialog();
                        if (!ofd.FileName.FileExists()) return;
                        reg.Write(Fs11RegKeys.FS11_LOG_FILE, ofd.FileName);
                        pth = ofd.FileName;
                    }
                    break;
                
                case "FS13":
                    pth = reg.Read(Fs13RegKeys.FS13_LOG_FILE);
                    if (pth.IsNullOrEmpty()) {
                        ofd.Title =
                            @"Navigate to the FS13 Log File, usually in my documents/My Games under Farming Simulator 2013";
                        ofd.ShowDialog();
                        if (!ofd.FileName.FileExists()) return;
                        reg.Write(Fs13RegKeys.FS13_LOG_FILE, ofd.FileName);
                        pth = ofd.FileName;
                    }

                    break;

                case "FS15":
                    pth = reg.Read(Fs15RegKeys.FS15_LOG_FILE);
                    if (pth.IsNullOrEmpty()) {
                        ofd.Title =
                            @"Navigate to the FS15 Log File, usually in my documents/My Games under Farming Simulator 2015";
                        ofd.ShowDialog();
                        if (!ofd.FileName.FileExists()) return;
                        reg.Write(Fs15RegKeys.FS15_LOG_FILE, ofd.FileName);
                        pth = ofd.FileName;
                    }

                    break;

                case "FS17":
                    pth = reg.Read(Fs17RegKeys.FS17_LOG_FILE);
                    if (pth.IsNullOrEmpty()) {
                        ofd.Title =
                            @"Navigate to the FS17 Log File, usually in my documents/My Games under Farming Simulator 2017";
                        ofd.ShowDialog();
                        if (!ofd.FileName.FileExists()) return;
                        reg.Write(Fs17RegKeys.FS17_LOG_FILE, ofd.FileName);
                        pth = ofd.FileName;
                    }

                    break;
                
                case "FS19":
                    pth = reg.Read(FS19RegKeys.FS19_LOG_FILE);
                    if (pth.IsNullOrEmpty()) {
                        ofd.Title =
                            @"Navigate to the FS19 Log File, usually in my documents/My Games under Farming Simulator 2019";
                        ofd.ShowDialog();
                        if (!ofd.FileName.FileExists()) return;
                        reg.Write(FS19RegKeys.FS19_LOG_FILE, ofd.FileName);
                        pth = ofd.FileName;
                    }

                    break;
            }

            if (!pth.FileExists()) return;
            Process.Start(pth);
        }
    }
}