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
using System.Linq;
using Extensions;

namespace Farming_Simulator_Mod_Manager {
    static class Search {

        /// <summary>
        /// Searches the mods.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        public static IEnumerable<string> SearchMods(string pattern) {
           var lst = new List<string>();
            var reg = new RegWork(true);
            reg.Read(RegKeys.CURRENT_GAME);
            var groupList = Loader.GroupLoader;
            var byP = Utils.ByPassList;
            var fList = groupList.Where(v => !byP.ContainsKey(v.GetLastFolderName())).ToList();

            foreach (var v in fList) {
                var fnd = GetFilesFolders.GetFiles(v + @"\", "*.zip");
                lst.AddRange(from f in fnd where f.Contains(pattern, StringComparison.OrdinalIgnoreCase) select f);
            }
            Vars.UniList = lst;
            return lst;
        }
    }
}
