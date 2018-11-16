using System;
using System.IO;

namespace Farming_Simulator_Mod_Manager {
    /// <summary>
    /// 
    /// </summary>
    public class Fs17 {
       private static string Fs17PreFix { get; set; }

        private static string Fs17Repo { get; } = @"Fs17Repo\";

        private static string Fs17BackUp { get; } = @"Fs17Repo\Fs17BackUp\";

        private static string Fs17Xml { get; } = @"Fs17Repo\Fs17XML\";

        private static string Fs17Groups { get; } = @"Fs17Repo\Fs17Groups\";

        private static string Fs17Profiles { get; } = @"Fs17Repo\Fs17Profiles\";

        private static string Fs17Work { get; } = @"Fs17Repo\Fs17Work\";
        
        private static string Fs17Specials { get; } = @"Fs17Repo\Fs17BackUp\Fs17Specials\";

        /// <summary>
        /// initialize Fs17
        /// </summary>
        public void InitFs17() {
            FolderCreator();
        }

        private static void FolderCreator() {
            try {
                Directory.CreateDirectory(Fs17PreFix + Fs17Groups);
                Directory.CreateDirectory(Fs17PreFix + Fs17Profiles);
                Directory.CreateDirectory(Fs17PreFix + Fs17Xml);
                Directory.CreateDirectory(Fs17PreFix + Fs17Work);
                Directory.CreateDirectory(Fs17PreFix + Fs17Specials);
                Directory.CreateDirectory(Fs17PreFix + Fs17BackUp);
                Directory.CreateDirectory(Fs17PreFix + Fs17Repo);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}