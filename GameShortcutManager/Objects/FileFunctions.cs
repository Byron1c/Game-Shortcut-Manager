using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
//using FastPhotoRenamer.Objects;

namespace Game_Shortcut_Manager.Objects
{
    internal class FileFunctions
    {

        internal static String ErrorLogFilename = "Errors.txt";

        public static string GetDataFullPath(String vAppPathName)
        {
            string fullPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                + "\\" + vAppPathName + "\\";

            // if the Settings folder does not exist, create one
            if (!System.IO.Directory.Exists(fullPath))
            {
                System.IO.Directory.CreateDirectory(fullPath);
            }

            return fullPath;
        }

        //internal static string GetLogFullPath(String vAppPathName)
        //{
        //    String fullPath = GetDataFullPath(vAppPathName) + Log.LogFilename;

        //    return fullPath;
        //}

        internal static String GetAppFullPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }


        internal static string GetErrorLogFullPath(String vAppPathName)
        {
            String fullPath = GetDataFullPath(vAppPathName) + ErrorLogFilename;

            return fullPath;
        }

        //public static string GetErrorLogFullPath()
        //{
        //    String fullPath = GetDataFullPath() + ErrorLogFilename;

        //    return fullPath;
        //}



        //public static string GetDataFullPath()
        //{
        //    //String settingsFullPath = Application.StartupPath + "\\" + MainFunctions.SettingsFilenameOnly; // read file from app path
        //    string fullPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        //        + "\\" + frmMain.AppPathName + "\\";

        //    // if the Settings folder does not exist, create one
        //    if (!System.IO.Directory.Exists(fullPath))
        //    {
        //        System.IO.Directory.CreateDirectory(fullPath);
        //    }

        //    return fullPath;
        //}

        /// <summary>
        /// Get the folder to be used for random pictures
        /// </summary>
        /// <returns></returns>
        internal static String SelectShortcutFolder(String vStartPath)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = vStartPath;

            DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                return dialog.SelectedPath;
            }

            dialog.Dispose();

            return string.Empty;

        }


        /// <summary>
        /// Open a path/file with the default app (in windows) for that exstension
        /// </summary>
        /// <param name="vPath"></param>
        public static void PlayExternalFile(String vPath)
        {
            try
            {
                if (System.IO.File.Exists(vPath))
                {
                    Process.Start(vPath);
                }
                else
                {
                    MessageBox.Show("Sorry, this file does not exist (" + vPath + "). \n\nPlease rescan the folder contents.", "File Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (FileLoadException ex)
            {
                MessageBox.Show("There was an error opening the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Use this instead of Path.GetExtension as it doesnt handle fullstops in filenames
        /// </summary>
        /// <param name="vFilePath"></param>
        /// <returns></returns>
        internal static String getExtension(String vFilePath)
        {
            string output = "." + vFilePath.Split('.').Last();

            if (!vFilePath.Contains("."))
            {
                output = ".";
            }

            return output;
        }

        /// <summary>
        /// Use this instead of Path.GetFilename as it doesnt handle full stops well
        /// </summary>
        /// <param name="vFilePath"></param>
        /// <returns></returns>
        internal static String getFilename(String vFilePath, Boolean vKeepExtension)
        {
            String output = vFilePath;
            if (output.Contains('\\'))
            {
                output = output.Split('\\').Last();
            }
            else
            {
                //no slashes... no path in file
            }

            if (!vKeepExtension)
            {
                String ext = getExtension(vFilePath);
                output = output.Replace(ext, "");
            }

            return output;
        }

        //internal static void setSendToShortcut(Boolean vSet)
        //{
        //    Boolean shortcutExists = FileShellExtension.SendToShortcutExists();
        //    if (vSet)
        //    {
        //        if (!shortcutExists)
        //        {
        //            FileShellExtension.CreateSendToShortcut();
        //        }
        //    }
        //    else
        //    {
        //        // user doesnt want shortcut
        //        if (shortcutExists)
        //        {
        //            FileShellExtension.RemoveSendToShortcut();
        //        }
        //    }
        //}


        internal static bool HasRights(string path, FileSystemRights rights, WindowsIdentity user)
        {
            //How you might use it
            //HasRights(@"C:\SomePath", FileSystemRights.ChangePermissions, WindowsIdentity.GetCurrent());

            var security = Directory.GetAccessControl(path);
            var rules = security.GetAccessRules(true, true, typeof(SecurityIdentifier));

            return rules.OfType<FileSystemAccessRule>().Any(r =>
                    ((int)r.FileSystemRights & (int)rights) != 0 && r.IdentityReference.Value == user.User.Value);
        }



        internal static string GetNotFoundImagePath()
        {
            return Application.StartupPath + "\\Images\\image-not-found.png";
        }

        internal static string GetNoImagePath()
        {
            return Application.StartupPath + "\\Images\\no-image.png";
        }




        private void FillDriveList()
        {
            //cbDrives.DataSource = System.IO.DriveInfo.GetDrives();
            //cbDrives.DisplayMember = "Name";

            //cbDrives.DataSource = System.IO.DriveInfo.GetDrives().Where(d => d.DriveType == System.IO.DriveType.Network);
            //cbDrives.DisplayMember = "Name";

            foreach (var drive in DriveInfo.GetDrives())
            {
                double freeSpace = drive.TotalFreeSpace;
                double totalSpace = drive.TotalSize;
                double percentFree = (freeSpace / totalSpace) * 100;
                float num = (float)percentFree;

                //Console.WriteLine("Drive:{0} With {1} % free", drive.Name, num);
                //Console.WriteLine("Space Remaining:{0}", drive.AvailableFreeSpace);
                //Console.WriteLine("Percent Free Space:{0}", percentFree);
                //Console.WriteLine("Space used:{0}", drive.TotalSize);
                //Console.WriteLine("Type: {0}", drive.DriveType);
            }


        }


        internal enum RenameResult
        {
            Success,
            NoChange,
            Error
        }

        ///// <summary>
        ///// Returns the full path of the new file
        ///// </summary>
        ///// <param name="vSourceFullPath"></param>
        ///// <param name="vDestFile"></param>
        ///// <returns></returns>
        //internal static RenameResult RenameFile(String vSourceFullPath, String vDestFile)
        //{

        //    if (!string.IsNullOrEmpty(vDestFile) && System.IO.File.Exists(vSourceFullPath))
        //    {
        //        // (rename) move the file to the same folder, with the new name
        //        string destination = System.IO.Path.GetDirectoryName(vSourceFullPath) + "\\" + FileFunctions.getFilename(vDestFile, true);//Path.GetFileName(vDestFilePath);

        //        // if there is no change, cancel the rename
        //        if (vSourceFullPath == destination)
        //        {
        //            return RenameResult.NoChange;
        //        }

        //        try
        //        {
        //            // DOES NOT COPY METADATA: System.IO.File.Move(vSourceFullPath, destination);

        //            string filenameOnly = FileFunctions.getFilename(destination, true);
        //            Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(vSourceFullPath,  filenameOnly);
        //            return RenameResult.Success;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("There was a problem renaming this file. Please check the permissons on the file and folder. Also check if the file is Read-Only."
        //                + System.Environment.NewLine + System.Environment.NewLine + ex.Message
        //                , "Problem Renaming File", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }

        //    return RenameResult.Error;
        //}


        ///// <summary>
        ///// Delete a file to the recyclebin with VB.NET
        ///// </summary>
        ///// <param name="vFilePath"></param>
        internal static void DeleteFileToRecycleBin(String vFilePath)
        {
            FileSystem.DeleteFile(vFilePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
        }


        /// <summary>
        /// duh
        /// </summary>
        /// <param name="filename"></param>
        public static void CreateEmptyFile(string filename)
        {
            if (!File.Exists(filename))
            {
                File.Create(filename).Dispose();
            }
        }


        internal static long FileSize(string VPath)
        {
            if (!File.Exists(VPath)) return -1;

            //System.IO.FileInfo fi = new System.IO.FileInfo(VPath);
            return new System.IO.FileInfo(VPath).Length;
        }


        internal static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        internal static double ConvertBytesToKilobytes(long bytes)
        {
            return (bytes / 1024f);
        }

        internal static double ConvertKilobytesToMegabytes(long kilobytes)
        {
            return kilobytes / 1024f;
        }


        internal static Boolean IsReadOnly(String vPath)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(vPath);

            if (System.IO.FileAttributes.ReadOnly == fi.Attributes || fi.IsReadOnly)
            {
                //The file is read only.
                return true;
            }
            //OR
            //if (fi.IsReadOnly)
            //{
            //    //In 2005 The File is read only
            //}
            return false;
        }

        internal static void ClearReadOnly(String vPath)
        {
            //File.SetAttributes(vPath, File.GetAttributes(vPath) & ~FileAttributes.ReadOnly);

            var attr = File.GetAttributes(vPath);

            // set read-only
            //attr = attr | FileAttributes.ReadOnly;
            //File.SetAttributes(vPath, attr);

            // unset read-only
            attr = attr & ~FileAttributes.ReadOnly;
            File.SetAttributes(vPath, attr);

        }

        internal static void SetReadOnly(String vPath)
        {
            var attr = File.GetAttributes(vPath);

            // set read-only
            attr = attr | FileAttributes.ReadOnly;
            File.SetAttributes(vPath, attr);

            // unset read-only
            //attr = attr & ~FileAttributes.ReadOnly;
            //File.SetAttributes(vPath, attr);
        }



        internal static bool FileExists(string rootpath, string filename)
        {
            if (File.Exists(Path.Combine(rootpath, filename)))
                return true;

            foreach (string subDir in Directory.GetDirectories(rootpath, "*", System.IO.SearchOption.AllDirectories))
            {
                if (File.Exists(Path.Combine(subDir, filename)))
                    return true;
            }

            return false;
        }

        internal static String FileExistsPath(string rootpath, string filename)
        {
            if (File.Exists(Path.Combine(rootpath, filename)))
                return Path.Combine(rootpath, filename);

            foreach (string subDir in Directory.GetDirectories(rootpath, "*", System.IO.SearchOption.AllDirectories))
            {
                if (File.Exists(Path.Combine(subDir, filename)))
                    return Path.Combine(subDir, filename);
            }

            return string.Empty;
        }

        internal static bool FileExistsRecursive(string rootPath, string filename)
        {
            if (File.Exists(Path.Combine(rootPath, filename)))
                return true;

            foreach (string subDir in Directory.GetDirectories(rootPath))
            {
                return FileExistsRecursive(subDir, filename);
            }

            return false;
        }

        internal static String FileExistsRecursivePath(string rootPath, string filename)
        {
            if (File.Exists(Path.Combine(rootPath, filename)))
                return Path.Combine(rootPath, filename);

            foreach (string subDir in Directory.GetDirectories(rootPath))
            {
                return FileExistsRecursivePath(subDir, filename);
            }

            return string.Empty;
        }



    }
}
