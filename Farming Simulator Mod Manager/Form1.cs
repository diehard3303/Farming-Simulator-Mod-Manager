﻿//
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
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Extensions;

namespace Farming_Simulator_Mod_Manager {
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    /// <inheritdoc />
    public partial class Form1 : Form {
        private const string FS11 = "FS11";
        private const string FS13 = "FS13";
        private const string FS15 = "FS15";
        private const string FS17 = "FS17";
        private const string FS19 = "FS19";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <param name="lpExistingFileName"></param>
        /// <param name="lpSecurityAttributes"></param>
        /// <returns></returns>
        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern bool CreateHardLink(
            string lpFileName,
            string lpExistingFileName,
            IntPtr lpSecurityAttributes
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool CreateSymbolicLink(
            string lpSymlinkFileName, string lpTargetFileName, SymbolicLink dwFlags);

        private enum SymbolicLink {
            File = 0,
            Directory = 1
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        /// <inheritdoc />
        public Form1() => InitializeComponent();

        private void btnExit_Click(object sender, System.EventArgs e) => Application.Exit();

        private void rbFarmSim17_CheckedChanged(object sender, System.EventArgs e) => SetSimFs17();

        /// <summary>
        /// Sets the sim FS17.
        /// </summary>
        public void SetSimFs17() {
            if (!rbFarmSim17.Checked) return;
            InitFarmSimulator();
            var reg = new RegWork(true);
            reg.Write(RegKeys.CURRENT_GAME, FS17);
            var lst = Loader.ProfileLoader;
            lstProfiles.Items.Clear();
            foreach (var v in lst) {
                lstProfiles.Items.Add(v.GetLastFolderName());
            }

            SetProfileCount();
            InitStartUp();
            lblGame.Text = @"Game: FS17";
            lblProf.Text = @"Profile:";
        }

        private void SetProfileCount() {
            lstProfileMods.Items.Clear();
            lblProfileCount.Text = $@"Profiles: {lstProfiles.Items.Count}";
            lblProfileModCount.Text = @"Profile Mods: ";
        }

        private static void InitFarmSimulator() {
            var init = new InitFarmSim();
            init.Initialize();
        }

        private void lstProfiles_SelectedIndexChanged(object sender, System.EventArgs e) => SetLoadProfile();

        /// <summary>
        /// Set and load profile.
        /// </summary>
        public void SetLoadProfile() {
            if (lstProfiles.SelectedItem.IsNull()) return;
            lblProf.Text = @"Profile: " + lstProfiles.SelectedItem;
            var reg = new RegWork(true);
            reg.Write(RegKeys.CURRENT_PROFILE, lstProfiles.SelectedItem.ToString());
            var lst = Loader.ProfileModLoader(lstProfiles.SelectedItem.ToString());
            lstProfileMods.Items.Clear();
            if (lst.IsNull()) return;
            foreach (var v in lst) {
                lstProfileMods.Items.Add(v.GetFileName());
            }

            lblProfileModCount.Text = $@"Profile Mods:  {lstProfileMods.Items.Count}";
            Working.ModifyGameSettings();
        }

        private void rbFarmSim11_CheckedChanged(object sender, System.EventArgs e) => SetSimFs11();

        /// <summary>
        /// Sets the sim FS11.
        /// </summary>
        public void SetSimFs11() {
            if (!rbFarmSim11.Checked) return;
            InitFarmSimulator();
            var reg = new RegWork(true);
            reg.Write(RegKeys.CURRENT_GAME, FS11);
            var lst = Loader.ProfileLoader;
            lstProfiles.Items.Clear();
            foreach (var v in lst) {
                lstProfiles.Items.Add(v.GetLastFolderName());
            }

            SetProfileCount();
            InitStartUp();
            lblGame.Text = @"Game: FS11";
            lblProf.Text = @"Profile:";
        }

        private void rbFarmSim13_CheckedChanged(object sender, System.EventArgs e) => SetSimFs13();

        /// <summary>
        /// Sets the sim FS13.
        /// </summary>
        public void SetSimFs13() {
            if (!rbFarmSim13.Checked) return;
            InitFarmSimulator();
            var reg = new RegWork(true);
            reg.Write(RegKeys.CURRENT_GAME, FS13);
            var lst = Loader.ProfileLoader;
            lstProfiles.Items.Clear();
            foreach (var v in lst) {
                lstProfiles.Items.Add(v.GetLastFolderName());
            }

            SetProfileCount();
            InitStartUp();
            lblGame.Text = @"Game: FS13";
            lblProf.Text = @"Profile:";
        }

        private void rbFarmSim15_CheckedChanged(object sender, System.EventArgs e) => SetSimFs15();

        /// <summary>
        /// Sets the sim FS15.
        /// </summary>
        public void SetSimFs15() {
            if (!rbFarmSim15.Checked) return;
            InitFarmSimulator();
            var reg = new RegWork(true);
            reg.Write(RegKeys.CURRENT_GAME, FS15);
            var lst = Loader.ProfileLoader;
            lstProfiles.Items.Clear();
            foreach (var v in lst) {
                lstProfiles.Items.Add(v.GetLastFolderName());
            }

            SetProfileCount();
            InitStartUp();
            lblGame.Text = @"Game: FS15";
            lblProf.Text = @"Profile:";
        }

        private void rbFarmSim19_CheckedChanged(object sender, System.EventArgs e) => SetSimFs19();

        /// <summary>
        /// Sets the sim FS19.
        /// </summary>
        public void SetSimFs19() {
            if (!rbFarmSim19.Checked) return;
            InitFarmSimulator();
            var reg = new RegWork(true);
            reg.Write(RegKeys.CURRENT_GAME, FS19);
            var lst = Loader.ProfileLoader;
            lstProfiles.Items.Clear();
            foreach (var v in lst) {
                lstProfiles.Items.Add(v.GetLastFolderName());
            }

            SetProfileCount();
            InitStartUp();
            lblGame.Text = @"Game: FS19";
            lblProf.Text = @"Profile:";
        }

        private void deleteProfileToolStripMenuItem_Click(object sender, System.EventArgs e) {
            if (lstProfiles.SelectedItem.IsNull()) return;
            Working.DeleteProfile();
        }


        private void removeModToolStripMenuItem_Click(object sender, System.EventArgs e) {
            if (lstProfileMods.SelectedItem.IsNull()) return;
            var mod = Working.DeleteProfileMod(lstProfileMods.SelectedItem.ToString());
            SetLoadProfile();
            MsgBx.Msg(mod.GetFileName() + " Was removed from Profile", "Mod Remover");
        }


        private void Form1_Load(object sender, System.EventArgs e) {
        }

        /// <summary>
        /// Initializes the start up.
        /// </summary>
        public void InitStartUp() {
            lstGroups.Items.Clear();
            var lst = Loader.GroupLoader;
            foreach (var v in lst) {
                lstGroups.Items.Add(v.GetLastFolderName());
            }

            lblGroupCount.Text = $@"Groups: {lstGroups.Items.Count}";
        }

        private void lstGroups_SelectedIndexChanged(object sender, System.EventArgs e) {
            LoadGroupMods();
        }

        private void LoadGroupMods() {
            if (lstGroups.SelectedItem.IsNull()) return;
            Vars.FolderName = lstGroups.SelectedItem.ToString();
            lstGroupMods.Items.Clear();
            var lst = Loader.GroupModLoader(lstGroups.SelectedItem.ToString());
            foreach (var v in lst) {
                lstGroupMods.Items.Add(v.GetFileName());
            }

            lblGroupModsCount.Text = $@"Group Mods: {lstGroupMods.Items.Count}";
        }

        private void createProfileToolStripMenuItem_Click(object sender, System.EventArgs e) {
            var cre = new Creation {rbCreateProfile = {Checked = true}};
            cre.ShowDialog();
        }

        private void createGroupToolStripMenuItem_Click(object sender, System.EventArgs e) {
            var cre = new Creation {rbCreateGroup = {Checked = true}};
            cre.ShowDialog();
        }

        private void deleteGroupToolStripMenuItem_Click(object sender, System.EventArgs e) {
            if (lstGroups.SelectedItem.IsNull()) return;
            Working.DeleteGroup(lstGroups.SelectedItem.ToString());
            InitStartUp();
        }


        private void eleteModToolStripMenuItem_Click(object sender, System.EventArgs e) {
            if (lstGroupMods.SelectedItem.IsNull()) return;
            Working.DeleteGroupMod(lstGroupMods.SelectedItem.ToString());
            LoadGroupMods();
        }


        private void editModToolStripMenuItem_Click(object sender, System.EventArgs e) {
            if (lstGroupMods.SelectedItem.ToString().IsNullOrEmpty()) return;
            Working.EditGroupMod(lstGroupMods.SelectedItem.ToString());
        }

        private void startFarmSimulatorToolStripMenuItem_Click(object sender, System.EventArgs e) =>
            Loader.GameStarter();

        private void startFarmSimulatorToolStripMenuItem1_Click(object sender, System.EventArgs e) =>
            Loader.GameStarter();

        private void startFarmSimulatorToolStripMenuItem2_Click(object sender, System.EventArgs e) =>
            Loader.GameStarter();

        private void startFarmSimulatorToolStripMenuItem3_Click(object sender, System.EventArgs e) =>
            Loader.GameStarter();

        private void addModToProfileToolStripMenuItem_Click(object sender, System.EventArgs e) {
            if (lstGroupMods.SelectedItem.ToString().IsNullOrEmpty()) return;
            var mod = lstGroupMods.SelectedItem.ToString();
            Working.AddModToProfile(mod);
        }


        private void copyProfileToolStripMenuItem_Click(object sender, System.EventArgs e) => ProfileCopy.CopyProfile();

        private void repoWorkToolStripMenuItem_Click(object sender, System.EventArgs e) {
            var mov = new Mover();
            mov.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, System.EventArgs e) {
            if (radioButton1.Checked) {
                Browser.BrowseFolders("repo");
                ResetRb();
            }
        }

        private void radioButton3_CheckedChanged(object sender, System.EventArgs e) {
            if (radioButton3.Checked) {
                Browser.BrowseFolders("work");
                ResetRb();
            }
        }

        private void radioButton2_CheckedChanged(object sender, System.EventArgs e) {
            if (radioButton2.Checked) {
                Browser.BrowseFolders("groups");
                ResetRb();
            }
        }

        private void radioButton4_CheckedChanged(object sender, System.EventArgs e) {
            if (radioButton4.Checked) {
                Browser.BrowseFolders("backup");
                ResetRb();
            }
        }

        private void ResetRb() {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e) {
            var lc = new ListCreator();
            lc.CreateSortedLists();
            lc.SortedFileListComplete();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e) {
            if (radioButton8.Checked) {
                var re = new ReadLogFile();
                re.ReadLogFiles();
                ResetRb();
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e) {
            if (radioButton5.Checked) {
                Browser.BrowseFolders("list");
                ResetRb();
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e) {
            if (radioButton7.Checked) {
                var em = new EditMod();
                em.ShowDialog();
                ResetRb();
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e) {
            //specials
        }

        private void button3_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e) {
            var lc = new ListCreator();
            lc.CreateSortedLists();
            lc.SortedFileListComplete();
        }

        private void moveModToRepoToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstGroupMods.SelectedItem.IsNull()) return;
            var mod = lstGroupMods.SelectedItem.ToString();
            var lst = Working.ModToRepo(mod);
            lstGroupMods.Items.Clear();
            foreach (var v in lst) {
                lstGroupMods.Items.Add(v.GetFileName());
            }
        }

        private void saveProfileAsSpecialToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstProfiles.SelectedItem.ToString().IsNull()) return;
            var gi = new GameInfo();
            var gam = gi.GetGame();
            var reg = new RegWork(true);
            var ap = reg.Read(RegKeys.CURRENT_PROFILE);
            var dic = new Dictionary<string, string>();

            switch (gam) {
                case "FS11":
                    var prof = reg.Read(Fs11RegKeys.FS11_PROFILES) + ap + @"\" + ap + ".xml";
                    dic = Serializer.DeserializeDictionary(prof);
                    Vars.Dict = dic;
                    var frm = new Specials();
                    frm.ShowDialog();
                    break;
                case "FS13":
                    prof = reg.Read(Fs13RegKeys.FS13_PROFILES) + ap + @"\" + ap + ".xml";
                    dic = Serializer.DeserializeDictionary(prof);
                    Vars.Dict = dic;
                    frm = new Specials();
                    frm.ShowDialog();
                    break;
                case "FS15":
                    prof = reg.Read(Fs15RegKeys.FS15_PROFILES) + ap + @"\" + ap + ".xml";
                    dic = Serializer.DeserializeDictionary(prof);
                    Vars.Dict = dic;
                    frm = new Specials();
                    frm.ShowDialog();
                    break;
                case "FS17":
                    prof = reg.Read(Fs17RegKeys.FS17_PROFILES) + ap + @"\" + ap + ".xml";
                    dic = Serializer.DeserializeDictionary(prof);
                    Vars.Dict = dic;
                    frm = new Specials();
                    frm.ShowDialog();
                    break;
                case "FS19":
                    prof = reg.Read(FS19RegKeys.FS19_PROFILES) + ap + @"\" + ap + ".xml";
                    dic = Serializer.DeserializeDictionary(prof);
                    Vars.Dict = dic;
                    frm = new Specials();
                    frm.ShowDialog();
                    break;
            }
        }

        private void createNewProfileFromGroupToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstGroups.SelectedItem.IsNull()) return;
            var nProf = lstGroups.SelectedItem.ToString();
            var gi = new GameInfo();
            var gam = gi.GetGame();
            Dictionary<string, string> dic;
            var reg = new RegWork(true);

            switch (gam) {
                case "FS11":
                    var proLoc = reg.Read(Fs11RegKeys.FS11_PROFILES) + nProf;
                    Directory.CreateDirectory(proLoc);
                    var grpLoc = reg.Read(Fs11RegKeys.FS11_GROUPS) + nProf + @"\";
                    dic = Serializer.DeserializeDictionary(grpLoc + nProf + ".xml");
                    foreach (var v in dic) {
                        var tmp = proLoc + @"\" + v.Key;
                        var orig = v.Value + @"\" + v.Key;
                        //CreateSymbolicLink(tmp, orig, SymbolicLink.File);
                        CreateHardLink(tmp, orig, IntPtr.Zero);
                    }

                    Serializer.SerializeDictionary(proLoc + @"\" + nProf + ".xml", dic);
                    break;
                case "FS13":
                    proLoc = reg.Read(Fs13RegKeys.FS13_PROFILES) + nProf;
                    Directory.CreateDirectory(proLoc);
                    grpLoc = reg.Read(Fs13RegKeys.FS13_GROUPS) + nProf + @"\";
                    dic = Serializer.DeserializeDictionary(grpLoc + nProf + ".xml");
                    foreach (var v in dic) {
                        var tmp = proLoc + @"\" + v.Key;
                        var orig = v.Value + @"\" + v.Key;
                        //CreateSymbolicLink(tmp, orig, SymbolicLink.File);
                        CreateHardLink(tmp, orig, IntPtr.Zero);
                    }

                    Serializer.SerializeDictionary(proLoc + @"\" + nProf + ".xml", dic);
                    break;
                case "FS15":
                    proLoc = reg.Read(Fs15RegKeys.FS15_PROFILES) + nProf;
                    Directory.CreateDirectory(proLoc);
                    grpLoc = reg.Read(Fs15RegKeys.FS15_GROUPS) + nProf + @"\";
                    dic = Serializer.DeserializeDictionary(grpLoc + nProf + ".xml");
                    foreach (var v in dic) {
                        var tmp = proLoc + @"\" + v.Key;
                        var orig = v.Value + @"\" + v.Key;
                        //CreateSymbolicLink(tmp, orig, SymbolicLink.File);
                        CreateHardLink(tmp, orig, IntPtr.Zero);
                    }

                    Serializer.SerializeDictionary(proLoc + @"\" + nProf + ".xml", dic);
                    break;
                case "FS17":
                    proLoc = reg.Read(Fs17RegKeys.FS17_PROFILES) + nProf;
                    Directory.CreateDirectory(proLoc);
                    grpLoc = reg.Read(Fs17RegKeys.FS17_GROUPS) + nProf + @"\";
                    dic = Serializer.DeserializeDictionary(grpLoc + nProf + ".xml");
                    foreach (var v in dic) {
                        var tmp = proLoc + @"\" + v.Key;
                        var orig = v.Value + @"\" + v.Key;
                        //CreateSymbolicLink(tmp, orig, SymbolicLink.File);
                        //CreateHardLink(tmp,orig, IntPtr.Zero);
                        FileCopy.Destination = tmp;
                        FileCopy.Source = orig;
                        FileCopy.DoCopy();
                    }

                    Serializer.SerializeDictionary(proLoc + @"\" + nProf + ".xml", dic);
                    break;
                case "FS19":
                    proLoc = reg.Read(FS19RegKeys.FS19_PROFILES) + nProf;
                    Directory.CreateDirectory(proLoc);
                    grpLoc = reg.Read(FS19RegKeys.FS19_GROUPS) + nProf + @"\";
                    dic = Serializer.DeserializeDictionary(grpLoc + nProf + ".xml");
                    foreach (var v in dic) {
                        var tmp = proLoc + @"\" + v.Key;
                        var orig = v.Value + @"\" + v.Key;
                        //CreateSymbolicLink(tmp, orig, SymbolicLink.File);
                        CreateHardLink(tmp, orig, IntPtr.Zero);
                    }

                    Serializer.SerializeDictionary(proLoc + @"\" + nProf + ".xml", dic);
                    break;
            }

            var lst = Loader.ProfileLoader;
            lstProfiles.Items.Clear();
            foreach (var v in lst) {
                lstProfiles.Items.Add(v.GetLastFolderName());
            }
        }

        private void createProfileFromFilemapToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstGroupMods.SelectedItem.IsNull()) return;
            var map = lstGroupMods.SelectedItem.ToString();
            var nam = map.GetNameNoExtension();
            var gi = new GameInfo();
            var gam = gi.GetGame();
            var reg = new RegWork(true);


            switch (gam) {
                case "FS11":
                    var proLoc = reg.Read(Fs11RegKeys.FS11_PROFILES) + nam;
                    Directory.CreateDirectory(proLoc);
                    var dic = new Dictionary<string, string>();
                    var pth = reg.Read(Fs11RegKeys.FS11_GROUPS) + lstGroups.SelectedItem + @"\" + map.GetFileName();
                    dic.Add(map.GetFileName(), reg.Read(Fs11RegKeys.FS11_GROUPS) + lstGroups.SelectedItem + @"\");
                    var tmp = proLoc + @"\" + map.GetFileName();
                    var orig = pth;
                    // FileCopyMove.FileCopy(orig, tmp);
                    CreateHardLink(tmp, orig, IntPtr.Zero);
                    Serializer.SerializeDictionary(proLoc + @"\" + nam + ".xml", dic);
                    break;
                case "FS13":
                    proLoc = reg.Read(Fs13RegKeys.FS13_PROFILES) + nam;
                    Directory.CreateDirectory(proLoc);
                    dic = new Dictionary<string, string>();
                    pth = reg.Read(Fs13RegKeys.FS13_GROUPS) + lstGroups.SelectedItem + @"\" + map.GetFileName();
                    dic.Add(map.GetFileName(), reg.Read(Fs13RegKeys.FS13_GROUPS) + lstGroups.SelectedItem + @"\");
                    tmp = proLoc + @"\" + map.GetFileName();
                    orig = pth;
                    // FileCopyMove.FileCopy(orig, tmp);
                    CreateHardLink(tmp, orig, IntPtr.Zero);
                    Serializer.SerializeDictionary(proLoc + @"\" + nam + ".xml", dic);
                    break;
                case "FS15":
                    proLoc = reg.Read(Fs15RegKeys.FS15_PROFILES) + nam;
                    Directory.CreateDirectory(proLoc);
                    dic = new Dictionary<string, string>();
                    pth = reg.Read(Fs15RegKeys.FS15_GROUPS) + lstGroups.SelectedItem + @"\" + map.GetFileName();
                    dic.Add(map.GetFileName(), reg.Read(Fs15RegKeys.FS15_GROUPS) + lstGroups.SelectedItem + @"\");
                    tmp = proLoc + @"\" + map.GetFileName();
                    orig = pth;
                    // FileCopyMove.FileCopy(orig, tmp);
                    CreateHardLink(tmp, orig, IntPtr.Zero);
                    Serializer.SerializeDictionary(proLoc + @"\" + nam + ".xml", dic);
                    break;
                case "FS17":
                    proLoc = reg.Read(Fs17RegKeys.FS17_PROFILES) + nam;
                    Directory.CreateDirectory(proLoc);
                    dic = new Dictionary<string, string>();
                    pth = reg.Read(Fs17RegKeys.FS17_GROUPS) + lstGroups.SelectedItem + @"\" + map.GetFileName();
                    dic.Add(map.GetFileName(), reg.Read(Fs17RegKeys.FS17_GROUPS) + lstGroups.SelectedItem + @"\");
                    tmp = proLoc + @"\" + map.GetFileName();
                    orig = pth;
                   // FileCopyMove.FileCopy(orig, tmp);
                    CreateHardLink(tmp, orig, IntPtr.Zero);
                    Serializer.SerializeDictionary(proLoc + @"\" + nam + ".xml", dic);
                    break;
                case "FS19":
                    proLoc = reg.Read(FS19RegKeys.FS19_PROFILES) + nam;
                    Directory.CreateDirectory(proLoc);
                    dic = new Dictionary<string, string>();
                    pth = reg.Read(FS19RegKeys.FS19_GROUPS) + lstGroups.SelectedItem + @"\" + map.GetFileName();
                    dic.Add(map.GetFileName(), reg.Read(FS19RegKeys.FS19_GROUPS) + lstGroups.SelectedItem + @"\");
                    tmp = proLoc + @"\" + map.GetFileName();
                    orig = pth;
                    // FileCopyMove.FileCopy(orig, tmp);
                    CreateHardLink(tmp, orig, IntPtr.Zero);
                    Serializer.SerializeDictionary(proLoc + @"\" + nam + ".xml", dic);
                    break;
            }

            var lst = Loader.ProfileLoader;
            lstProfiles.Items.Clear();
            foreach (var v in lst) {
                lstProfiles.Items.Add(v.GetLastFolderName());
            }
        }
    }
}