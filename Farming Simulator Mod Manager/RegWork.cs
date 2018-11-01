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
using System.Windows.Forms;
using Microsoft.Win32;

namespace Farming_Simulator_Mod_Manager {
    internal class RegWork {
        /// <summary>
        ///     The _sub key
        /// </summary>
        private const string SUB_KEY = @"SOFTWARE\DieHard Development\Mod Manager Ultimate\";

        /// <summary>
        ///     The _base registry key
        /// </summary>
        private readonly RegistryKey _baseRegistryKey = Registry.CurrentUser;

        public RegWork(bool showError) {
            ShowError = showError;
        }

        /// <summary>
        ///     A property to show or hide error messages (default = false)
        /// </summary>
        /// <value><c>true</c> if [show error]; otherwise, <c>false</c>.</value>
        private bool ShowError { get; }

        /// <summary>
        ///     To read a registry key.
        ///     input: KeyName (string)
        ///     output: value (string)
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <returns>System.String.</returns>
        public string Read(string keyName) {
            // Opening the registry key
            var rk = _baseRegistryKey;
            // Open a subKey as read-only
            var sk1 = rk.OpenSubKey(SUB_KEY);
            // If the RegistrySubKey doesn't exist -> (null)
            if (sk1 == null) return null;
            try {
                // If the RegistryKey exists I get its value or null is returned.
                return (string) sk1.GetValue(keyName);
            }
            catch (Exception e) {
                ShowErrorMessage(e, "Reading registry " + keyName);
                return null;
            }
        }

        /// <summary>
        ///     To write into a registry key.
        ///     input: KeyName (string) , Value (object)
        ///     output: true or false
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public void Write(string keyName, object value) {
            try {
                // Setting
                var rk = _baseRegistryKey;
                // I have to use CreateSubKey (create or open it if already exits), 'cause
                // OpenSubKey open a subKey as read-only
                var sk1 = rk.CreateSubKey(SUB_KEY);
                // Save the value
                sk1?.SetValue(keyName, value);
            }
            catch (Exception e) {
                ShowErrorMessage(e, "Writing registry " + keyName);
            }
        }

        /// <summary>
        ///     Shows the error message.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <param name="title">The title.</param>
        private void ShowErrorMessage(Exception e, string title) {
            if (ShowError)
                MessageBox.Show(e.Message,
                    title
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
        }
    }
}