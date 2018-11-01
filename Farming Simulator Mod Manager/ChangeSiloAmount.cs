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

using System.Linq;
using System.Xml.Linq;
using Extensions;

namespace Farming_Simulator_Mod_Manager {
    internal class ChangeSiloAmount {
        private const string AMOUNT = "100000000.000000";

        /// <summary>
        ///     Changes the silo total amount.
        /// </summary>
        public void ChangeSiloTotalAmount(string saveGame) {
            if (saveGame.IsNullOrEmpty()) {
                MsgBx.Msg("You did not choose a SaveGame to Modify", "Profile Error");
                return;
            }

            var pth = saveGame + "careerSavegame.xml";
            if (!pth.FileExists()) return;

            var doc = XDocument.Load(pth);
            var q = from node in doc.Descendants()
                where node.Name == "totalAmount"
                where node.Attributes().Any()
                select new {NodeName = node.Name, Attributes = node.Attributes()};

            foreach (var node in q)
            foreach (var attribute in node.Attributes)
                if (attribute.Name == "value")
                    attribute.SetValue(AMOUNT);
            doc.Save(pth);

            MsgBx.Msg("Cheat - Change Silo Capacity - has been applied to " + saveGame.GetLastFolderName(), "Cheat");
        }
    }
}