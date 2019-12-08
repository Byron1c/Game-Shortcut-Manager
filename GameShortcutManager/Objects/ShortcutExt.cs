using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game_Shortcut_Manager.Objects;
using IWshRuntimeLibrary;
using Shell32;

namespace Game_Shortcut_Manager
{
    internal static class ShortcutExt
    {



        //https://stackoverflow.com/questions/4897655/create-a-shortcut-on-desktop
        internal static void CreateShortcutDesktop()
        {
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\Notepad.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "New shortcut for a Notepad";
            shortcut.Hotkey = "Ctrl+Shift+N";
            shortcut.TargetPath = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\notepad.exe";
            
            shortcut.Save();
        }


        internal static Boolean CreateShortcut(ShortcutItem vItem)
        {
            return CreateShortcut(
                vItem.ShortcutPath,
                vItem.Name,
                vItem.Description,
                vItem.Target,
                vItem.WorkingDirectory,
                vItem.IconPath,
                vItem.Arguments,
                vItem.WindowStyle,
                vItem.Hotkey
                );
        }
        internal static Boolean CreateShortcut(String vShortcutPath, String vTitle, String vDescription, String vTargetPath, String vWorkingDirectory, 
            String vIconPathExe, String vArguments, String vWindowStyle, String vHotkey)
        {
            //%APPDATA%\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar
            //if (!System.IO.File.Exists(vShortcutPath)) return false;

            try
            {
                //AppDataPath = "C:\\";
                //object shDesktop = (object)"Desktop";
                WshShell shell = new WshShell();
                //string shortcutPath = vShortcutPath;// + "\\Test.lnk"; //(string)shell.SpecialFolders.Item(ref shDesktop) + @"\Notepad.lnk";

                //string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\Notepad.lnk";
                //IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);

                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(vShortcutPath);
                shortcut.Description = vDescription;
                shortcut.Hotkey = ToCamelCase(vHotkey).Replace(" ", ""); //"Ctrl+Shift+N";
                shortcut.TargetPath = vTargetPath; // Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\notepad.exe";
                                                   //string ggg = shortcut.FullName;
                shortcut.IconLocation = vIconPathExe;
                shortcut.Arguments = vArguments;
                //shortcut.RelativePath = ;
                shortcut.WindowStyle = frmMain.StringToWindowStyle(vWindowStyle);
                shortcut.WorkingDirectory = vWorkingDirectory;

                shortcut.Save();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        internal static string ToCamelCase(String vText)
        {
            String output = vText;

            TextInfo txtInfo = new CultureInfo("en-us", false).TextInfo;
            output = txtInfo.ToTitleCase(output);

            //output = txtInfo.ToTitleCase(output).Replace("_", string.Empty).Replace(" ", string.Empty);
            //output = $"{output.First().ToString(CultureInfo.InvariantCulture).ToLowerInvariant()}{output.Substring(1)}";

            return output;
        }



        //Usage :
        //  syspin ["file"] #### or syspin ["file"] "commandstring"
        //  5386  : Pin to taskbar
        //  5387  : Unpin from taskbar
        //  51201 : Pin to start
        //  51394 : Unpin to start
        //Samples :
        //  syspin "%PROGRAMFILES%\Internet Explorer\iexplore.exe" 5386
        //  syspin "C:\Windows\notepad.exe" "Pin to taskbar"
        //  syspin "%WINDIR%\System32\calc.exe" "Pin to start"
        //  syspin "%WINDIR%\System32\calc.exe" "Unpin from taskbar"
        //  syspin "C:\Windows\System32\calc.exe" 51201


        //Note :  You cannot pin any metro app or batch file
        internal static String PinToTaskbar(String vPathToEXE)
        {
            //String commandline =  "\"" + vPathToEXE + "\"" + " c:5386 ";
            //commandline = " \"" + frmMain.GetAppFullPath() + @"Objects\syspin.exe" + "\" " + commandline;
            String commandline = "\"" + vPathToEXE + "\"" + " 5386 ";
            commandline = ".\\Objects\\syspin.exe" + " " + commandline;

            //commandline = ".\\Objects\\syspin.exe";
            return RunCommand(commandline);

        }
        
        internal static String PinToStartMenu(String vPathToEXE)
        {
            //String commandline =  "\"" + vPathToEXE + "\"" + " c:5386 ";
            //commandline = " \"" + frmMain.GetAppFullPath() + @"Objects\syspin.exe" + "\" " + commandline;

            String commandline = "\"" + vPathToEXE + "\"" + " 51201 ";
            commandline = ".\\Objects\\syspin.exe" + " " + commandline;

            //commandline = ".\\Objects\\syspin.exe";
            return RunCommand(commandline);

        }


        internal static String RemoveFromTaskbar(String vPathToEXE)
        {
            //String commandline = "\"" + vPathToEXE + "\"" + " c:5387 ";
            //commandline = " \"" + frmMain.GetAppFullPath() + @"Objects\syspin.exe" + "\" " + commandline;
            String commandline = "\"" + vPathToEXE + "\"" + " 5387 ";
            commandline = ".\\Objects\\syspin.exe" + " " + commandline;
            return RunCommand(commandline);
        }

        internal static String RemoveFromStartMenu(String vPathToEXE)
        {
            //String commandline = "\"" + vPathToEXE + "\"" + " c:5387 ";
            //commandline = " \"" + frmMain.GetAppFullPath() + @"Objects\syspin.exe" + "\" " + commandline;
            String commandline = "\"" + vPathToEXE + "\"" + " 51394 ";
            commandline = ".\\Objects\\syspin.exe" + " " + commandline;
            return RunCommand(commandline);
        }


        private static String RunCommand(String vCommand)
        {
            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            ////startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = "/C " + vCommand;
            //process.StartInfo = startInfo;
            //process.Start();
            //if (process != null && !process.HasExited)
            //    process.WaitForExit();


            var sb = new StringBuilder();
            Process p = new Process();

            // redirect the output
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;

            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/C " + vCommand;
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;

            // hookup the eventhandlers to capture the data that is received
            p.OutputDataReceived += (sender, args) =>
            {
                if (args.Data != string.Empty) sb.AppendLine(args.Data);
            };
            p.ErrorDataReceived += (sender, args) =>
            {
                if (args.Data != string.Empty) sb.AppendLine(args.Data);
            };

            // direct start
            p.StartInfo.UseShellExecute = false;

            p.Start();
            // start our event pumps
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();

            // until we are done
            p.WaitForExit();

            // do whatever you need with the content of sb.ToString();
            String output = sb.ToString().Replace(System.Environment.NewLine, "");

            return output;
        }


        internal static String CreateGameURLLink(String vURLPath, String vURL, String vName)
        {
           
            using (System.IO.StreamWriter file =
            //new System.IO.StreamWriter(vURLPath + @"\L4D2.url")) 
            new System.IO.StreamWriter(vURLPath + @"\" + vName + ".url")) 
            {
                file.WriteLine("[{000214A0-0000-0000-C000-000000000046}]");
                file.WriteLine("Prop3=19,0");
                file.WriteLine("[InternetShortcut]");
                file.WriteLine("IDList=");
                file.WriteLine("IconIndex=0");
                file.WriteLine("URL=" + vURL);
                file.WriteLine(@"IconFile=D:\Games\Steam\steam\games\1a8d50f6078b5d023582ea1793b0e53813d57b7f.ico");

            }

            return vURLPath + @"\" + vName + ".url";
        }

        public static string ShortcutToText(Shortcut shortcutKeys)
        {
            if (shortcutKeys == Shortcut.None)
            {
                return string.Empty;
            }
            return new KeysConverter().ConvertToString((Keys)shortcutKeys);
        }

        public static string ShortcutToText(Keys shortcutKeys)
        {
            if (shortcutKeys == Keys.None)
            {
                return string.Empty;
            }
            return new KeysConverter().ConvertToString((Keys)shortcutKeys);
        }

        //http://csharphelper.com/blog/2018/06/get-information-about-windows-shortcuts-in-c/
        // Get information about this link.
        // Return an error message if there's a problem.
        internal static string GetShortcutInfo(string full_name,
            out ShortcutItem vSI)
        {
            //name = "";
            //path = "";
            //descr = "";
            //working_dir = "";
            //args = "";
            //var sc = Keys.Control && Keys.LShiftKey && Keys.A;
            //var txt = new KeysConverter().ConvertToString((Keys)sc);
            //Console.WriteLine(txt);
            


            vSI = new ShortcutItem();

            try
            {
                // Make a Shell object.
                Shell32.Shell shell = new Shell32.Shell();

                // Get the shortcut's folder and name.
                string shortcut_path =
                    full_name.Substring(0, full_name.LastIndexOf("\\"));
                string shortcut_name =
                    full_name.Substring(full_name.LastIndexOf("\\") + 1);
                if (!shortcut_name.EndsWith(".lnk"))
                    shortcut_name += ".lnk";

                // Get the shortcut's folder.
                Shell32.Folder shortcut_folder =
                    shell.NameSpace(shortcut_path);

                // Get the shortcut's file.
                Shell32.FolderItem folder_item =
                    shortcut_folder.Items().Item(shortcut_name);

                if (folder_item == null)
                    return "Cannot find shortcut file '" + full_name + "'";
                if (!folder_item.IsLink)
                    return "File '" + full_name + "' isn't a shortcut.";

                // Display the shortcut's information.
                Shell32.ShellLinkObject lnk = (Shell32.ShellLinkObject)folder_item.GetLink;

                vSI.Arguments = lnk.Arguments;
                vSI.Description = lnk.Description;
                //vSI.Hotkey = lnk.Hotkey.ToString();
                lnk.GetIconLocation(out string bps);
                vSI.IconPath = bps;
                vSI.Name = folder_item.Name;
                vSI.ShortcutPath = lnk.Path;
                FolderItem fi = lnk.Target;
                vSI.Target = GetShortcutTargetFile(full_name);//fi.IsFolder.ToString();
                //vSI.WindowStyle = "1";
                vSI.WorkingDirectory = lnk.WorkingDirectory;

                WshShell theShell = new WshShell();
                WshShortcut theShortcut = (WshShortcut)theShell.CreateShortcut(full_name);
                vSI.WindowStyle = frmMain.WindowStyleToInt(theShortcut.WindowStyle);
                vSI.Hotkey = theShortcut.Hotkey.ToString();

                //name = folder_item.Name;
                //descr = lnk.Description;
                //path = lnk.Path;
                //working_dir = lnk.WorkingDirectory;
                //args = lnk.Arguments;

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //http://csharphelper.com/blog/2018/06/get-information-about-windows-shortcuts-in-c/
        internal static string GetShortcutInfo(string full_name,
            out string name, out string path, out string descr,
            out string working_dir, out string args)
        {
            name = "";
            path = "";
            descr = "";
            working_dir = "";
            args = "";
            try
            {
                // Make a Shell object.
                Shell32.Shell shell = new Shell32.Shell();

                // Get the shortcut's folder and name.
                string shortcut_path =
                    full_name.Substring(0, full_name.LastIndexOf("\\"));
                string shortcut_name =
                    full_name.Substring(full_name.LastIndexOf("\\") + 1);
                if (!shortcut_name.EndsWith(".lnk"))
                    shortcut_name += ".lnk";

                // Get the shortcut's folder.
                Shell32.Folder shortcut_folder =
                    shell.NameSpace(shortcut_path);

                // Get the shortcut's file.
                Shell32.FolderItem folder_item =
                    shortcut_folder.Items().Item(shortcut_name);

                if (folder_item == null)
                    return "Cannot find shortcut file '" + full_name + "'";
                if (!folder_item.IsLink)
                    return "File '" + full_name + "' isn't a shortcut.";

                // Display the shortcut's information.
                Shell32.ShellLinkObject lnk =
                    (Shell32.ShellLinkObject)folder_item.GetLink;
                name = folder_item.Name;
                descr = lnk.Description;
                path = lnk.Path;
                working_dir = lnk.WorkingDirectory;
                args = lnk.Arguments;
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public static string GetShortcutTargetFile(string shortcutFilename)
        {
            string pathOnly = Path.GetDirectoryName(shortcutFilename);
            string filenameOnly = Path.GetFileName(shortcutFilename);
            Shell shell = new Shell();
            Shell32.Folder folder = shell.NameSpace(pathOnly);
            FolderItem folderItem = folder.ParseName(filenameOnly);
            if (folderItem != null)
            {
                ShellLinkObject link = (ShellLinkObject)folderItem.GetLink;
                return link.Path;
            }

            return string.Empty;
        }




    }
}
