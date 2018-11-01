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
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Extensions;

namespace Farming_Simulator_Mod_Manager {
    internal class FsCheatMoney {
        private const string MONEY = "5000000";
        private const string WITHER = "false";

        public string GetMapName(string saveGame) {
            var tmp = string.Empty;
            var pth = saveGame;
            var chk = pth.GetExtension();

            if (chk.IsNullOrEmpty()) {
                pth = pth + @"\careerSavegame.xml";
            }

            var po = XDocument.Load(pth);
            if (po.Root == null) return tmp;
            var list1 = po.Root.Descendants("mapTitle");
            foreach (var v in list1) {
                tmp = v.Value;
                break;
            }

            return tmp;
        }

        /// <summary>
        ///     Sets the cheat values.
        /// </summary>
        public void SetCheatValues(string saveGame) {
            var reg = new RegWork(true);
            var gam = reg.Read(RegKeys.CURRENT_GAME);

            switch (gam) {
                case "FS11":
                    var pth = saveGame;
                    if (!pth.FileExists()) return;
                    var xmlFile = XDocument.Load(pth + "\\careerSavegame.xml");
                    var query = from c in xmlFile.Elements("careerSavegame")
                        select c;

                    foreach (var element in query) {
                        var xAttribute = element.Attribute("money");
                        if (xAttribute != null) xAttribute.Value = MONEY;
                        var attribute = element.Attribute("isPlantWitheringEnabled");
                        if (attribute != null)
                            attribute.Value = WITHER;
                    }

                    xmlFile.Save(pth + "\\careerSavegame.xml");

                    MsgBx.Msg("Money / Wither Cheat Applied to " + saveGame.GetLastFolderName(), "Cheat");
                    break;
                 
                case "FS13":
                    pth = saveGame;
                    if (!pth.FileExists()) return;
                    xmlFile = XDocument.Load(pth + "\\careerSavegame.xml");
                    query = from c in xmlFile.Elements("careerSavegame")
                        select c;

                    foreach (var element in query) {
                        var xAttribute = element.Attribute("money");
                        if (xAttribute != null) xAttribute.Value = MONEY;
                        var attribute = element.Attribute("isPlantWitheringEnabled");
                        if (attribute != null)
                            attribute.Value = WITHER;
                    }

                    xmlFile.Save(pth + "\\careerSavegame.xml");

                    MsgBx.Msg("Money / Wither Cheat Applied to " + saveGame.GetLastFolderName(), "Cheat");
                    break;

                case "FS15":
                    pth = saveGame;
                    if (!pth.FileExists()) return;
                    xmlFile = XDocument.Load(pth + "\\careerSavegame.xml");
                    query = from c in xmlFile.Elements("careerSavegame")
                        select c;

                    foreach (var element in query) {
                        var xAttribute = element.Attribute("money");
                        if (xAttribute != null) xAttribute.Value = MONEY;
                        var attribute = element.Attribute("isPlantWitheringEnabled");
                        if (attribute != null)
                            attribute.Value = WITHER;
                    }

                    xmlFile.Save(pth + "\\careerSavegame.xml");

                    MsgBx.Msg("Money / Wither Cheat Applied to " + saveGame.GetLastFolderName(), "Cheat");
                    break;

                case "FS17":
                    var xdoc = new XmlDocument();
                    xdoc.Load(saveGame + "\\careerSavegame.xml");

                    var nodes = xdoc.SelectNodes("careerSavegame/statistics/money");
                    if (nodes == null) return;
                    foreach (XmlNode node in nodes) {
                        if (node.Name != "money") continue;
                        var amt = node.InnerText;
                        var cash = Convert.ToInt32(amt);
                        var done = cash + Convert.ToInt32(MONEY);
                        node.InnerText = done.ToString();
                        break;
                    }

                    xdoc.Save(saveGame + "\\careerSavegame.xml");
                    MsgBx.Msg("Money Cheat Applied to " + saveGame.GetLastFolderName(), "Money Cheat");
                    break;

                case "FS19":
                    xdoc = new XmlDocument();
                    xdoc.Load(saveGame + "\\careerSavegame.xml");

                    nodes = xdoc.SelectNodes("careerSavegame/statistics/money");
                    if (nodes == null) return;
                    foreach (XmlNode node in nodes) {
                        if (node.Name != "money") continue;
                        var amt = node.InnerText;
                        var cash = Convert.ToInt32(amt);
                        var done = cash + Convert.ToInt32(MONEY);
                        node.InnerText = done.ToString();
                        break;
                    }

                    xdoc.Save(saveGame + "\\careerSavegame.xml");
                    MsgBx.Msg("Money Cheat Applied to " + saveGame.GetLastFolderName(), "Money Cheat");
                    break;
            }
        }
    }
}