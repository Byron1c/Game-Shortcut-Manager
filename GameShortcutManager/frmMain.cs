using BrightIdeasSoftware;
using Game_Shortcut_Manager.Objects;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
//using System.Windows.Input;

namespace Game_Shortcut_Manager
{
    public partial class frmMain : Form
    {
        internal static string AppPathName = "GameShortcutManager";

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        internal static extern IntPtr LoadLibrary(string lpLibFileName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        internal static extern int LoadString(IntPtr hInstance, uint wID, StringBuilder lpBuffer, int nBufferMax);


        internal const string SettingsFilename = "settings.xml";

        internal enum Mode
        {
            Add,
            Edit
        }

        //TODO: add other urls ?

        /// <summary>
        /// -URL xxx    The Steam URL supplied
        /// -ICON xxx   Use the exe's ICON
        /// </summary>
        /// <param name="args"></param>

        //private String TaskbarShortcutPath = @"%APPDATA%\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar";

        //TODO: Handle when shortcut location is changed - remove shortcuts(task, start), delete old file, create new file, add shortcuts (task, start)

        private String URL = string.Empty;
        // Check if taskbar allows pinning (Group Policy can disable it, or some device families don't have taskbar)
        //private bool isPinningAllowed = false;
        private String CurrentEXEFilePath = string.Empty;
        private String CurrentURL = string.Empty;
        private String CurrentShortcutPath = string.Empty;
        private String CurrentName = string.Empty;
        private String CurrentShortcutKeys = string.Empty;

        internal Shortcuts Shortcuts;

        private String ExampleEXEFilePath = @"D:\Games\Steam\steamapps\common\MyGame\MyGame_x64.exe";
        private String ExampleURL = @"steam://rungameid/1234567890";
        private String ExampleShortcutPath = @"C:\Temp";
        private String ExampleName = @"My App Shortcut";
        private String ExampleShortcutKey = @"Ctrl+Alt+G";

        internal frmShowText formShowInfo;

        private String EditShortcutPath = string.Empty;

        internal Boolean ApplyingSettings = false;
        
        internal Boolean ShortcutPathChanged = false;
        internal String ShortcutPathOld = string.Empty;

        internal Mode mode = Mode.Add;
        private ShortcutItem editItem = null;

        //com.epicgames.launcher://apps/Curry?action=launch&silent=true
        //Origin: NONE
        //uplay://launch/720/0
        //steam://rungameid/1234567890
        //twitch://fuel-launch/e94696a4-61ce-4930-80ba-138c0da0b433


        //*****************************************************************************************************************
        public frmMain(string[] args)
        {
            InitializeComponent();

            Boolean Launch = false;

            this.Hide();

            //**** Command Line Argument handling ***************
            if (args.Length > 0)
            {
                int index = 0;
                //string[] allArgs = args.ToString(CultureInfo.InvariantCulture).ToLower().Split('-');
                foreach (String arg in args)
                {
                    if (arg.ToUpperInvariant().Contains("-URL") && args.Length >= index)
                    {                        
                        //Find the WEB URL in the arg
                        foreach (Match item in Regex.Matches(args[index + 1], @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)"))
                        {
                            if (item.Success)
                            {
                                URL = item.Value;
                                break;
                            }
                        }

                        //Find the STEAM URL in the arg
                        //foreach (Match item in Regex.Matches(arg, @"(steam|http|ftp|https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?"))
                        foreach (Match item in Regex.Matches(args[index + 1], @"steam:\/\/rungameid/\d+"))
                        {
                            if (item.Success)
                            {
                                URL = item.Value;
                                break;
                            }
                        }

                        //uplay://launch/720/0
                        foreach (Match item in Regex.Matches(args[index + 1], @"uplay:\/\/launch\/\d+\/\d+"))
                        {
                            if (item.Success)
                            {
                                URL = item.Value;
                                break;
                            }
                        }

                        //com.epicgames.launcher://apps/Curry?action=launch&silent=true
                        foreach (Match item in Regex.Matches(args[index + 1], @"com.epicgames.launcher:\/\/apps\/.*"))
                        {
                            if (item.Success)
                            {
                                URL = item.Value;
                                break;
                            }
                        }

                        //twitch://fuel-launch/e94696a4-61ce-4930-80ba-138c0da0b433
                        foreach (Match item in Regex.Matches(args[index + 1], @"twitch:\/\/fuel-launch\/.*"))
                        {
                            if (item.Success)
                            {
                                URL = item.Value;
                                break;
                            }
                        }

                    }

                    if (arg.ToUpperInvariant().Contains("-ICON") && args.Length >= index)
                    {
                        String filePath = args[index + 1];
                        setIcon(filePath);
                    }

                    index++;
                }
            }            

            if (URL != string.Empty && Launch == true)
            if (URL != string.Empty && Launch == true)
            {
                OpenURL(URL);
                Quit();
            }
            //*****************************************************************************************************************


            // keep settings when reinstalled / updated / uninstall
            //https://stackoverflow.com/questions/3779307/how-to-keep-user-settings-on-uninstall
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            showWelcome();

            ApplyingSettings = true;

            if (Properties.Settings.Default.CheckForUpdate) CheckForUpdate(false);

            formShowInfo = new frmShowText(this);

            Shortcuts = new Shortcuts();
            Shortcuts.Load(GetAppFullPath() + SettingsFilename);

            setValues();
            setHandlers();

            ApplyingSettings = false;

            this.Show();
            this.BringToFront();
            this.Focus();
        }


        //*****************************************************************************************************************
        internal void setValues()
        {
            
            setIcon(CurrentEXEFilePath);

            txtName.Text = ExampleName;
            txtEXEPath.Text = ExampleEXEFilePath;
            txtURL.Text = ExampleURL;
            txtShortcutPath.Text = ExampleShortcutPath;
            txtShortcutKey.Text = ExampleShortcutKey;

            SetSpecialFolders();
            if (!String.IsNullOrEmpty(Properties.Settings.Default.ShortcutPathPreset))
            {
                cbFileLocation.SelectedItem = Properties.Settings.Default.ShortcutPathPreset;
            }
            

            lblResults.Text = "";

            cbCheckForUpdate.Checked = Properties.Settings.Default.CheckForUpdate;

            SetAllText();

            setFileLocationControls();
            fillShortcutsList();
            setShortcutButtons();

        }

        private void SetAllText()
        {
            setText(txtName, ExampleName);
            setText(txtEXEPath, ExampleEXEFilePath);
            setText(txtURL, ExampleURL);
            setText(txtShortcutPath, ExampleShortcutPath);
            setText(txtShortcutKey, ExampleShortcutKey);

        }

        private void showWelcome()
        {

            if (!Properties.Settings.Default.WelcomeMessageShown)
            {
                MessageBox.Show(
                    "I hope you find Game Shortcut Manager useful!"  + System.Environment.NewLine + System.Environment.NewLine
                    + "This is a small tool to help you manage URLs (web links) to  " + System.Environment.NewLine
                    + "applications and games and pin them to the Start Menu, and " + System.Environment.NewLine 
                    + "Taskbar. Windows cannot do this on its own.  " + System.Environment.NewLine + System.Environment.NewLine
                    + "Occasionally you may find the Add to Start Menu and Taskbar " + System.Environment.NewLine
                    + "functions may not work on first try, you may need to give " + System.Environment.NewLine
                    + "it another go: Click Remove, then add it again." + System.Environment.NewLine
                    + "(I have not been able to resolve this with the available tools)" + System.Environment.NewLine + System.Environment.NewLine
                    + "Note: When adding or removing an entry from the Start Menu, " + System.Environment.NewLine
                    + "the menu will appear - this is normal, and necessary to" + System.Environment.NewLine
                    + "work properly. " + System.Environment.NewLine
                    ,
                    "Welcome to Game Shortcut Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Properties.Settings.Default.WelcomeMessageShown = true;
                Properties.Settings.Default.Save();
            }
        }

        private void setEdit(String vShortcutPath, String vArguments)
        {
            //ShortcutExt.GetShortcutInfo(vShortcutPath, out string name, out string path, out string desc, out string workingDir, out string args);
            this.mode = Mode.Edit;

            //ShortcutItem SI;
            if (File.Exists(vShortcutPath))
            {
                ShortcutExt.GetShortcutInfo(vShortcutPath, out this.editItem);
            } 
            else
            {
                editItem = Shortcuts.Items.Find(x => x.Arguments.Contains(vArguments));
            }

            if (editItem != null)
            {
                setIcon(editItem.IconPath);
                txtDescription.Text = editItem.Description;
                txtShortcutKey.Text = editItem.Hotkey;
                txtEXEPath.Text = editItem.IconPath;
                txtName.Text = editItem.Name;
                txtURL.Text = editItem.Arguments.Replace("-LAUNCH ", "").Replace("-URL ", "").Trim();
                cbWindowStyle.SelectedItem = editItem.WindowStyle;
                txtShortcutPath.Text = Path.GetDirectoryName(vShortcutPath);
                cbFileLocation.SelectedItem = editItem.ShortcutPathSpecialFolder;
                //txtDescription.Text = SI.WorkingDirectory;
                //txtDescription.Text = SI.Target;
                //txtDescription.Text = SI.Arguments;
                //setText(txtURL, ExampleURL);
                SetAllText();
            }
            

        }


        /// <summary>
        /// When the user clicks on Save Shortcut, this will cleanup the old location and other references
        /// </summary>
        private void CleanUpOldShortcut(String vShortcutPath)
        {
            Boolean isInStart = IsInStartMenu(vShortcutPath);// Path.Combine(ShortcutPathOld, vShortcutFilename));
            Boolean isInTaskbar = IsInTaskbar(vShortcutPath);// Path.Combine(ShortcutPathOld, vShortcutFilename));

            if (isInStart) ShortcutExt.RemoveFromStartMenu(vShortcutPath);
            if (isInTaskbar) ShortcutExt.RemoveFromTaskbar(vShortcutPath);

            FileFunctions.DeleteFileToRecycleBin(vShortcutPath);// Path.Combine(ShortcutPathOld, vShortcutFilename));
        }

        internal static void OpenURL(String vURL)
        {
            System.Diagnostics.Process.Start(vURL); 
        }

        private void setIcon(String vFilePath)
        {
            if (String.IsNullOrEmpty(vFilePath)) return;

            //Icon TheIcon = IconFromFilePath(vFilePath);
            //pbIcon.Image = TheIcon.ToBitmap();
            

            pbIcon.Image = IconFromFilePath(vFilePath).ToBitmap(); 
        }

        internal static Icon IconFromFilePath(String vPath)
        {
            Icon result = null;

            try
            {
                result = Icon.ExtractAssociatedIcon(vPath);
            }
            catch (Exception)
            {
                //return nothing.You could supply a default Icon here as well
            }

            return result;
        }
        

        public static bool PinUnpinTaskbar(string filePath, bool pin)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);
            int MAX_PATH = 255;
            var actionIndex = pin ? 5386 : 5387; // 5386 is the DLL index for"Pin to Tas&kbar", ref. http://www.win7dll.info/shell32_dll.html
                                                 //uncomment the following line to pin to start instead
                                                 //actionIndex = pin ? 51201 : 51394;
            StringBuilder szPinToStartLocalized = new StringBuilder(MAX_PATH);
            IntPtr hShell32 = LoadLibrary("Shell32.dll");
            LoadString(hShell32, (uint)actionIndex, szPinToStartLocalized, MAX_PATH);
            string localizedVerb = szPinToStartLocalized.ToString();

            string path = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileName(filePath);

            // create the shell application object
            dynamic shellApplication = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"));
            dynamic directory = shellApplication.NameSpace(path);
            dynamic link = directory.ParseName(fileName);

            dynamic verbs = link.Verbs();
            for (int i = 0; i < verbs.Count(); i++)
            {
                dynamic verb = verbs.Item(i);
                //String ggg = verb.Name;
                //if (ggg.Contains("New folder"))
                //{ int g = 1; }
                if (verb.Name.Equals(localizedVerb))
                {
                    verb.DoIt();
                    return true;
                }
            }
            return false;
        }

        public static String GetAppFullPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public static String GetLauncherFullPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory + "Launcher.exe";
        }

        //https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.filedialog?view=netframework-4.8#examples
        internal String SelectEXEICO(String vLastPath)
        {
            //var fileContent = string.Empty;
            var filePath = string.Empty;
            String lastPath = vLastPath;

            if (String.IsNullOrEmpty(lastPath))
            {
                lastPath = "c:\\";
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //String Filter = "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff";
                //Filter = "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|"
                //    + "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
                
                openFileDialog.InitialDirectory = lastPath; //"c:\\";
                openFileDialog.Filter = "All Icon Types|*.exe;*.ico;|ico files (*.ico)|*.ico|exe files (*.exe)|*.exe|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    //using (StreamReader reader = new StreamReader(fileStream))
                    //{
                    //    fileContent = reader.ReadToEnd();
                    //}
                }
            }

            //MessageBox.Show("File path: " + filePath, "", MessageBoxButtons.OK);

            return filePath;

        }



        internal Boolean FormOK(Boolean vHighlight, Boolean vShowError)
        {
            if (ApplyingSettings) return true;

            Boolean output = true;
            String message = string.Empty;

            txtName.BackColor = Color.White;
            txtURL.BackColor = Color.White;
            txtEXEPath.BackColor = Color.White;
            txtShortcutPath.BackColor = Color.White;


            if (String.IsNullOrEmpty(txtName.Text.Trim())
                || txtName.Text.Equals(ExampleName)
                )
            {
                output = false;
                message += " * Give the shortcut a Name" + System.Environment.NewLine;
                if (vHighlight) txtName.BackColor = Color.PaleGoldenrod;
            }
            
            if (String.IsNullOrEmpty(txtURL.Text.Trim())
                || txtURL.Text.Equals(ExampleURL)
                )
            {
                output = false;
                message += " * Paste or Find the URL for your Game/App" + System.Environment.NewLine;
                if (vHighlight) txtURL.BackColor = Color.PaleGoldenrod;
            }

            if (String.IsNullOrEmpty(txtEXEPath.Text.Trim())
                || txtEXEPath.Text.Equals(ExampleEXEFilePath)
                )
            {
                output = false;
                message += " * Find the file for the Icon (.Exe or .Ico)" + System.Environment.NewLine;
                if (vHighlight) txtEXEPath.BackColor = Color.PaleGoldenrod;
            }
            if (!File.Exists(txtEXEPath.Text.Trim()))
            {
                output = false;
                message += " * The icon you have selected does not exist" + System.Environment.NewLine;
                if (vHighlight) txtName.BackColor = Color.PaleGoldenrod;
            }

            if (!String.IsNullOrEmpty(txtShortcutKey.Text))
            {
                Boolean matchFound = IsShortcutKeysOK(txtShortcutKey.Text.Trim(), out String MatchString);
                ////String keysRegEx = @"(ctrl|shift|alt)\s*\+\s*([a-z+\-.,/]|Numpad\s*[0-9+\-/]+|insert)(\s*(,|\+)\s*((ctrl|shift|alt)\s*\+\s*)*([a-z+\-.,/]|Numpad\s*[0-9+\-/]+|insert))*(?=\W)";
                ////String keysRegEx = @"(ctrl|shift|alt|Ctrl|Shift|Alt)\s*\+\s*(ctrl|shift|alt|Ctrl|Shift|Alt)\s*\+\s*([a-z+\-.,/]|Numpad\s*[0-9+\-/]+|insert)";
                //String keysRegEx = @"(ctrl|shift|alt|Ctrl|Shift|Alt)\s*\+\s*(ctrl|shift|alt|Ctrl|Shift|Alt)\s*\+\s*([A-Z+\-.,/]|[a-z+\-.,/]|Numpad\s*[0-9+\-/]+|insert)";
                //foreach (Match item in Regex.Matches(txtShortcutKey.Text.Trim(), keysRegEx))
                //{
                //    if (item.Success)
                //    {
                //        matchFound = true;
                //        break;
                //    }
                //}
                if (!matchFound)
                {
                    output = false;
                    message += " * The Shortcut Keys are not formatted correctly" + System.Environment.NewLine;
                    if (vHighlight) txtShortcutKey.BackColor = Color.PaleGoldenrod;
                }
            }

            if (String.IsNullOrEmpty(txtShortcutPath.Text.Trim())
                || txtShortcutPath.Text.Equals(ExampleShortcutPath)
                )
            {
                output = false;
                message += " * You need to supply a storage location for the shortcut" + System.Environment.NewLine;
                if (vHighlight) txtShortcutPath.BackColor = Color.PaleGoldenrod;
            }
            if (!Directory.Exists(txtShortcutPath.Text.Trim()))
            {
                output = false;
                message += " * The Shortcut path you have selected does not exist" + System.Environment.NewLine;
                if (vHighlight) txtShortcutPath.BackColor = Color.PaleGoldenrod;
            }
            if (mode == Mode.Add && Shortcuts.Items.Find(x => x.Arguments.Equals("-URL " + txtURL.Text.Trim())) != null)
            {
                output = false;
                message += " * This App / Game / URL is already in your list of Shortcuts" + System.Environment.NewLine;
                if (vHighlight) txtURL.BackColor = Color.PaleGoldenrod;
            }


            if (vShowError && output == false)
            {
                message = "The form has the following problems:" + System.Environment.NewLine + message;
                MessageBox.Show(message, "Problems Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return output;
        }

        private Boolean IsShortcutKeysOK(String vKeys, out String vMatchItem)
        {
            vMatchItem = string.Empty;

            Boolean matchFound = false;
            //String keysRegEx = @"(ctrl|shift|alt)\s*\+\s*([a-z+\-.,/]|Numpad\s*[0-9+\-/]+|insert)(\s*(,|\+)\s*((ctrl|shift|alt)\s*\+\s*)*([a-z+\-.,/]|Numpad\s*[0-9+\-/]+|insert))*(?=\W)";
            //String keysRegEx = @"(ctrl|shift|alt|Ctrl|Shift|Alt)\s*\+\s*(ctrl|shift|alt|Ctrl|Shift|Alt)\s*\+\s*([a-z+\-.,/]|Numpad\s*[0-9+\-/]+|insert)";
            
            //Test for 3 Control Characters
            String keysRegEx2 = @"(ctrl|shift|alt|Ctrl|Shift|Alt)\s*\+\s*(ctrl|shift|alt|Ctrl|Shift|Alt)\s*\+\s*([A-Z+\-.,/]|[a-z+\-.,/]|Numpad\s*[0-9+\-/]+|insert)";
            String keysRegEx3 = @"(?:(ctrl|shift|alt|Ctrl|Shift|Alt)\s*\+\s*_)?(ctrl|shift|alt|Ctrl|Shift|Alt)\s*\+\s*(ctrl|shift|alt|Ctrl|Shift|Alt)\s*\+\s*([A-Z+\-.,/]|[a-z+\-.,/]|Numpad\s*[0-9+\-/]+|insert)";
            
            foreach (Match item in Regex.Matches(vKeys, keysRegEx3))
            {
                if (item.Success)
                {
                    matchFound = true;
                    vMatchItem = item.Value;
                    break;
                }
            }

            // if no match on 3 control characters
            if (matchFound == false)
            {
                
                //Now test for 2 Control Characters
                foreach (Match item in Regex.Matches(vKeys, keysRegEx2))
                {
                    if (item.Success)
                    {
                        matchFound = true;
                        vMatchItem = item.Value;
                        break;
                    }
                }
            }
            
            return matchFound;
        }


        private void CreateShortcut(Boolean vPinToStart, Boolean vPintToTaskbar)
        {
            ShowWorking();
            
            if (!FormOK(true, true))
            {
                lblResults.Text = "Check form problems";
                lblResults.ForeColor = Color.DarkRed;
                HideWorking();
                return;
            }

            this.CurrentEXEFilePath = txtEXEPath.Text;
            this.CurrentName = txtName.Text;
            this.CurrentShortcutPath = txtShortcutPath.Text;
            this.CurrentURL = txtURL.Text;
            this.CurrentShortcutKeys = txtShortcutKey.Text;

            //string appPath = GetLauncherFullPath(); //GetAppFullPath() + System.AppDomain.CurrentDomain.FriendlyName;
            //appPath += " -URL " + this.CurrentURL;
            Properties.Settings.Default.LastShortcutPath = CurrentShortcutPath;
            Properties.Settings.Default.Save();

            string shortcutPath = this.CurrentShortcutPath + @"\" + CurrentName + ".lnk";

            ShortcutItem si = new ShortcutItem();
            si.Arguments = "-URL " + this.CurrentURL; //-LAUNCH
            si.Description = txtDescription.Text;
            si.Hotkey = ShortcutExt.ToCamelCase(txtShortcutKey.Text);
            si.IconPath = this.CurrentEXEFilePath;
            si.Name = CurrentName;
            si.ShortcutPath = shortcutPath;
            si.Target = GetLauncherFullPath(); //GetAppFullPath() + System.AppDomain.CurrentDomain.FriendlyName;
            si.WorkingDirectory = GetAppFullPath();
            si.WindowStyle = cbWindowStyle.SelectedItem.ToString();
            si.ShortcutPathSpecialFolder = cbFileLocation.SelectedItem.ToString();

            //do this BEFORE saving the shortcut
            Boolean shortcutExists = false;
            shortcutExists = File.Exists(shortcutPath);

            if (!shortcutExists)
            {
                shortcutExists = (Shortcuts.Items.Find(x => x.Arguments.Contains(si.Arguments)) != null);
            }

            // this overwrites existing shortcuts:
            Boolean successShortcut = ShortcutExt.CreateShortcut(si);

            if (!shortcutExists)
            {
                Shortcuts.Items.Add(si);
            }
            else
            {
                //SHORTCUT EXISTS
                //Shortcuts.Items.Find(x => x.ShortcutPath.Contains(EditShortcutPath));
                Shortcuts.Items.RemoveAll(x => x.Arguments == si.Arguments); // EditShortcutPath);
                Shortcuts.Items.Add(si);
            }

            Shortcuts.Save(GetAppFullPath() + SettingsFilename);
            fillShortcutsList();

            //Shortcut.CreateShortcut(
            //    shortcutPath, //this.CurrentShortcutPath + @"\" + CurrentName + ".lnk", //Shortcut path
            //    CurrentName,  //TITLE
            //    "Description here", //DESCRIPTION
            //    GetAppFullPath() + System.AppDomain.CurrentDomain.FriendlyName,   //TARGET
            //    GetAppFullPath(), // WORKING DIRECTORY
            //    this.CurrentEXEFilePath,  //icon
            //    "-LAUNCH -URL " + this.CurrentURL,
            //    "" //hotkey
            //    );

            if (cbPinToTaskbar.Checked || vPintToTaskbar)
            {
                ShortcutExt.PinToTaskbar(shortcutPath);
            }

            if (cbPinToStartMenu.Checked || vPinToStart)
            {
                ShortcutExt.PinToStartMenu(shortcutPath);
            }

            //lblResults.Visible = true;
            if (successShortcut)
            {
                lblResults.Text = "Shortcut " + CurrentName + " Saved";
                lblResults.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblResults.Text = "Shortcut " + CurrentName + " NOT Saved";
                lblResults.ForeColor = Color.DarkRed;
            }

            //txtName.Text = string.Empty;
            //txtEXEPath.Text = string.Empty;
            //txtShortcutPath.Text = string.Empty;
            //txtURL.Text = string.Empty;
            //txtDescription.Text = string.Empty;
            //txtShortcutKey.Text = string.Empty;
            //cbWindowStyle.SelectedItem = "Normal Window";

            //setText(txtEXEPath, ExampleEXEFilePath);
            //setText(txtName, ExampleName);
            //setText(txtShortcutPath, ExampleShortcutPath);
            //setText(txtURL, ExampleURL);
            ClearForm();
            HideWorking();
        }


        private void ClearForm()
        {
            ApplyingSettings = true;

            mode = Mode.Add;

            txtName.Text = ExampleName; // string.Empty;
            txtEXEPath.Text = ExampleEXEFilePath; // string.Empty;
            txtShortcutPath.Text = Properties.Settings.Default.LastShortcutPath;// string.Empty;
            txtURL.Text = ExampleURL;
            txtDescription.Text = string.Empty;
            txtShortcutKey.Text = ExampleShortcutKey;
            cbWindowStyle.SelectedItem = "Normal Window";

            SetAllText();
            //setText(txtEXEPath, ExampleEXEFilePath);
            //setText(txtName, ExampleName);
            //setText(txtShortcutPath, ExampleShortcutPath);
            //setText(txtURL, ExampleURL);
            //setText(txtShortcutKey, ExampleShortcutKey);

            EditShortcutPath = string.Empty;
            lblResults.Text = string.Empty;

            ApplyingSettings = false;
        }

        internal static int StringToWindowStyle(String vSelected)
        {
            switch (vSelected)
            {
                case "Normal Window":
                    return 1;
                case "Maximised":
                    return 3;
                case "Minimised":
                    return 7;
                default:
                    return 1;
            }
        }

        internal static String WindowStyleToInt(int vSelected)
        {
            switch (vSelected)
            {
                case 1:  
                    return "Normal Window";
                case 3:
                    return "Maximised";
                case 7:
                    return "Minimised";
                default:
                    return "Normal Window";
            }
        }

        internal void Quit()
        {
            //https://stackoverflow.com/questions/12977924/how-to-properly-exit-a-c-sharp-application
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }

        

        private void setText(TextBox vTextBox, String vExampleText)
        {
            if (!String.IsNullOrEmpty(vTextBox.Text.Trim()))
            {
                if (vTextBox.Text.Trim() == vExampleText)
                {
                    vTextBox.ForeColor = Color.Gray;
                } 
                else
                {
                    vTextBox.ForeColor = Color.Black;
                }
            } 
            else
            {
                //empty textbox
                //vTextBox.Text = vExampleText;
                //vTextBox.ForeColor = Color.Gray;
            }


            if (!FormOK(false, false))
            {
                disableButton(btnCreateShortcut);
                //btnCreateShortcut.Enabled = false;
            } else
            {
                enableButton(btnCreateShortcut);
                //btnCreateShortcut.Enabled = true;
            }
        }

        private void setTextBoxLostFocus(TextBox vTextBox, String vExampleText)
        {
            //setText(txtName, ExampleName);
            if (String.IsNullOrEmpty(vTextBox.Text.Trim()))
            {
                vTextBox.Text = vExampleText;
            }
        }



        private void CheckForm(Boolean vHighlight, Boolean vShowError)
        {
            if (!FormOK(vHighlight, vShowError))
            {
                lblResults.Text = "Check form problems";
                lblResults.ForeColor = Color.DarkRed;
                disableButton(btnCreateShortcut);
                //btnCreateShortcut.Enabled = false;
                return;
            } else
            {
                lblResults.Text = "Form is OK";
                lblResults.ForeColor = Color.DarkGreen;
                enableButton(btnCreateShortcut);
                //btnCreateShortcut.Enabled = true;
                return;
            }
        }


        private void SetSpecialFolders()
        {
            cbFileLocation.Items.Clear();
            cbFileLocation.Items.Add("Desktop");
            cbFileLocation.Items.Add("My Documents"); 
            cbFileLocation.Items.Add("My Pictures"); 
            cbFileLocation.Items.Add("My Music"); 
            cbFileLocation.Items.Add("My Videos"); 
            cbFileLocation.Items.Add("Program Files");
            cbFileLocation.Items.Add("Startup"); 
            cbFileLocation.Items.Add("Windows");
            cbFileLocation.Items.Add("Other");
        }

        private String GetSpecialFolderPath(String vName)
        {
            switch (vName)
            {
                case "Desktop":
                    return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                case "My Documents":
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                case "My Pictures":
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                case "My Music":
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                case "My Videos":
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                case "Program Files":
                    return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                case "Startup":
                    return Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                case "Windows":
                    return Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                case "Other":
                    return string.Empty;
                default:
                    return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
        }

        internal void setFileLocationControls()
        {
            if (cbFileLocation.SelectedItem == "Other")
            {
                txtShortcutPath.ReadOnly = false;
            } else
            {
                txtShortcutPath.ReadOnly = true;
            }
        }

        internal void fillShortcutsList()
        {
            ObjectListViewExt.adjustMyObjectListViewHeader(this.olvShortcuts, Color.GhostWhite, Color.DarkGray);//parentForm.colourLightest, parentForm.colourDarkest);
            ObjectListViewExt.ChangeHotItemStyle(olvShortcuts, ObjectListViewExt.HotItemStyleNum.LightBox); // set hover to translucent

            olvShortcuts.UseAlternatingBackColors = true;
            olvShortcuts.AlternateRowBackColor = Color.AliceBlue;

            olvShortcuts.VirtualMode = false; 
            olvShortcuts.ShowGroups = false;

            olvShortcuts.TintSortColumn = true;
            olvShortcuts.PrimarySortColumn = olvShortcuts.AllColumns[0];
            olvShortcuts.Sort();

            this.olvShortcuts.SetObjects(Shortcuts.Items);
        }



        private void setShortcutButtons()
        {
            //btnRemoveEntry.Enabled = false;
            disableButton(btnRemoveEntry);

            if (olvShortcuts.SelectedItems.Count > 0)
            {
                lblResults.Text = string.Empty;

                //btnCreateShortcut.Enabled = true;
                enableButton(btnRemoveShortcut);
                enableButton(btnPinStart);
                enableButton(btnPinTaskbar);
                enableButton(btnRemoveEntry);
                //btnPinStart.Enabled = true;
                //btnPinTaskbar.Enabled = true;
                //btnRemoveShortcut.Enabled = true;
                //btnRemoveEntry.Enabled = true;

                String path = ((ShortcutItem)olvShortcuts.SelectedItem.RowObject).ShortcutPath;
                String filename = FileFunctions.getFilename(path, true);

                if (IsInTaskbar(filename))
                {
                    btnPinTaskbar.Text = "Remove from Taskbar";
                } else
                {
                    btnPinTaskbar.Text = "Add to Taskbar";
                }

                if (IsInStartMenu(path))
                {
                    btnPinStart.Text = "Remove from Start Menu";
                }
                else
                {
                    btnPinStart.Text = "Add to Start Menu";
                }

                if (File.Exists(path))
                {
                    btnRemoveShortcut.Text = "Remove Shortcut";
                    enableButton(btnPinTaskbar);
                    enableButton(btnPinStart);
                    //btnPinTaskbar.Enabled = true;
                    //btnPinStart.Enabled = true;
                }
                else
                {
                    btnRemoveShortcut.Text = "Save Shortcut";
                    disableButton(btnPinTaskbar);
                    disableButton(btnPinStart);
                    //btnPinTaskbar.Enabled = false;
                    //btnPinStart.Enabled = false;
                }


            } 
            else
            {
                //btnCreateShortcut.Enabled = false;
                disableButton(btnRemoveShortcut);
                disableButton(btnPinStart);
                disableButton(btnPinTaskbar);
                disableButton(btnRemoveEntry);

            }

        }

        
        internal Boolean IsInTaskbar(String vFilename)
        {
            Boolean output = false;

            String filename = FileFunctions.getFilename(vFilename, true);

            String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\" + filename;

            if (File.Exists(path))
            {
                output = true;
            }

            return output;
        }


        internal Boolean IsInStartMenu(String vPath)
        {
            Boolean output = false;

            String path = vPath; //((ShortcutItem)olvShortcuts.SelectedItem.RowObject).ShortcutPath;
            String filename = FileFunctions.getFilename(path, true);

            string commonStartMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
            string userStartMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Start Menu\Programs\";

            if (FileFunctions.FileExistsRecursive(commonStartMenuPath, filename)
                        || FileFunctions.FileExistsRecursive(userStartMenuPath, filename)
                )
            {
                output = true;
            }

            return output;
        }



        public static bool CheckForInternetConnection()
        {
            Boolean output = false;
            try
            {
                using (var ping = new Ping())
                {
                    var reply = ping.Send("8.8.8.8");
                    if (reply != null && reply.Status != IPStatus.Success)
                    {
                        // Raise an event
                        // you might want to check for consistent failures 
                        // before signalling a the Internet is down
                        output = false;
                    }
                    else if (reply.Status == IPStatus.Success)
                    {
                        output = true;
                    }
                    else
                    {
                        output = false;
                    }
                }
            }
            catch (NetworkInformationException)
            {
                output = false;
            }
            catch (System.Net.NetworkInformation.PingException)
            {
                output = false;
            }
            return output;
        }


        /// <summary>
        /// Check for version updates
        /// </summary>
        /// <param name="vShowWhenOkay"></param>
        private void CheckForUpdate(Boolean vShowWhenOkay)
        {
            if (CheckForInternetConnection() == false)
            {
                return;
            }

            //http://www.csharp-station.com/HowTo/HttpWebFetch.aspx

            int currentVersion = int.Parse("0" + this.GetType().Assembly.GetName().Version.ToString().Replace(".", ""), CultureInfo.InvariantCulture);
            int latestVersion = 0;
            string versionString = string.Empty;
            string latestChanges = string.Empty;

            try
            {
                versionString = GetLatestVersionNumber();
                latestChanges = GetLatestChanges();
                latestVersion = int.Parse("0" + versionString.Replace(".", ""), CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                //TODO: Error here
                //ProcessError(ex, ErrorMessageType.CheckForUpdate, ShowError.NoShow, ThrowError.Throw, String.Format(CultureInfo.InvariantCulture, ""), FileFunctions.GetErrorLogFullPath(), formShowInfo);
            }


            if (latestVersion > currentVersion)
            {
                if (formShowInfo.Visible) formShowInfo.Hide();

                formShowInfo.Text = "New Version Available";
                formShowInfo.lblHeading.Text = "There is a new version of Game Shortcut Manager available";
                formShowInfo.lblDetails.Text = "You can download it from my blog page where you can find extra info about the application.";
                formShowInfo.richText.Text = "Newer version available.\n\nWould you like visit the website for Game Shortcut Manager?\n\n"; // Recent Changes:\n\n" + latestChanges;
                formShowInfo.richText.Text += "Change History:\n" + latestChanges;
                formShowInfo.richText.Visible = true;
                formShowInfo.Size = new Size(350, 260);
                formShowInfo.StartPosition = FormStartPosition.CenterParent;
                formShowInfo.OKHide = true;
                formShowInfo.ShowDialog();
                DialogResult result = formShowInfo.DialogResult;

                if (result == System.Windows.Forms.DialogResult.Yes
                    || result == System.Windows.Forms.DialogResult.OK)
                {
                    frmAbout.OpenAppURL();
                }
            }
            else if (latestVersion < currentVersion)
            {
                if (vShowWhenOkay) MessageBox.Show("This version is NEWER than the official release.\n\nYou are very Cool :)\n\nRecent Changes:\n\n"
                    + latestChanges, "Game Shortcut Manager Version " + versionString, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (vShowWhenOkay)
                {

                    if (formShowInfo.Visible) formShowInfo.Hide();

                    formShowInfo.Text = "Game Shortcut Manager Is Up-To-Date";
                    formShowInfo.lblHeading.Text = "Game Shortcut Manager Is Up-To-Date";
                    formShowInfo.lblDetails.Text = "You do not need to do anything.";
                    formShowInfo.richText.Text = "This version is Up-To-Date.\n\n";
                    formShowInfo.richText.Text += "Change History:\n" + latestChanges;
                    formShowInfo.richText.Visible = true;
                    formShowInfo.btnCancel.Visible = false;
                    formShowInfo.Size = new Size(350, 260);
                    formShowInfo.StartPosition = FormStartPosition.CenterParent;
                    formShowInfo.OKHide = true;
                    formShowInfo.ShowDialog();

                }

            }
        }


        public string GetLatestVersionNumber()
        {
            return GetWebData(new Uri("https://www.strangetimez.com/Apps/GameShortcutManager/latestversion.txt"));
        }

        public string GetLatestChanges()
        {
            return GetWebData(new Uri("https://www.strangetimez.com/Apps/GameShortcutManager/latestchanges.txt"));
        }

        public string GetWebData(Uri vURI)
        {
            // used to build entire input
            StringBuilder sb = new StringBuilder();

            try
            {
                if (CheckForInternetConnection() == false)
                {
                    return string.Empty;
                }

                // used on each read operation
                byte[] buf = new byte[8192];

                // prepare the web page we will be asking for
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(vURI);//("https://www.strangetimez.com/Apps/FastPhotoRenamer/latestversion.txt");

                // execute the request
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // we will read data via the response stream
                Stream resStream = response.GetResponseStream();

                string tempString = null;
                int count = 0;

                do
                {
                    // fill the buffer with data
                    count = resStream.Read(buf, 0, buf.Length);

                    // make sure we read some data
                    if (count != 0)
                    {
                        // translate from bytes to ASCII text
                        tempString = Encoding.ASCII.GetString(buf, 0, count);

                        // continue building the string
                        sb.Append(tempString);
                    }
                }
                while (count > 0); // any more data to read?

            }
            catch (NetworkInformationException ex)
            {
                //ProcessError(ex, ErrorMessageType.GetWebData, ShowError.NoShow, ThrowError.NoThrow, String.Format(CultureInfo.InvariantCulture, ""), FileFunctions.GetErrorLogFullPath(), formShowInfo);
            }
            catch (TimeoutException ex)
            {
                //ProcessError(ex, ErrorMessageType.GetWebData, ShowError.NoShow, ThrowError.NoThrow, String.Format(CultureInfo.InvariantCulture, ""), FileFunctions.GetErrorLogFullPath(), formShowInfo);
            }
            catch (System.Net.WebException ex)
            {
                //ProcessError(ex, ErrorMessageType.GetWebData, ShowError.NoShow, ThrowError.NoThrow, String.Format(CultureInfo.InvariantCulture, ""), FileFunctions.GetErrorLogFullPath(), formShowInfo);
            }
            catch (ProtocolViolationException ex)
            {
                //ProcessError(ex, ErrorMessageType.GetWebData, ShowError.NoShow, ThrowError.NoThrow, String.Format(CultureInfo.InvariantCulture, ""), FileFunctions.GetErrorLogFullPath(), formShowInfo);
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                //ProcessError(ex, ErrorMessageType.GetWebData, ShowError.NoShow, ThrowError.NoThrow, String.Format(CultureInfo.InvariantCulture, ""), FileFunctions.GetErrorLogFullPath(), formShowInfo);
            }


            // print out page source
            return sb.ToString();

        }

        //*****************************************************************************************************************

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (frmAbout formAbout = new frmAbout(this))
            {
                formAbout.ShowDialog();
                formAbout.Dispose();
            }
        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForUpdate(true);
        }

        private void cbCheckForUpdate_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckForUpdate = cbCheckForUpdate.Checked;
            Properties.Settings.Default.Save();
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void openShortcutFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (olvShortcuts.SelectedItems.Count > 0)
            {
                String shortcutPath = ((ShortcutItem)(olvShortcuts.SelectedItem.RowObject)).ShortcutPath;
                string argument = @"/select, " + shortcutPath;

                System.Diagnostics.Process.Start("explorer.exe", argument); 
            }
        }

        private void openIconFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (olvShortcuts.SelectedItems.Count > 0)
            {
                String iconPath = ((ShortcutItem)(olvShortcuts.SelectedItem.RowObject)).IconPath;
                string argument = @"/select, " + iconPath;

                System.Diagnostics.Process.Start("explorer.exe", argument);
            }
        }

        internal void ShowWorking()
        {
            pnlWorking.Visible = true;
            pnlForm.Enabled = false;
            pnlList.Enabled = false;

            disableButton(btnRemoveShortcut);
            disableButton(btnPinStart);
            disableButton(btnPinTaskbar);
            disableButton(btnRemoveEntry);

        }

        internal void HideWorking()
        {
            pnlForm.Enabled = true;
            pnlList.Enabled = true;
            pnlWorking.Visible = false;

            enableButton(btnRemoveShortcut);
            enableButton(btnPinStart);
            enableButton(btnPinTaskbar);
            enableButton(btnRemoveEntry);
        }

        private void disableButton(Button vButton)
        {
            vButton.Enabled = false;
            vButton.BackColor = Color.LightGray;
            vButton.ForeColor = Color.Gray;
        }

        private void enableButton(Button vButton)
        {
            vButton.Enabled = true;
            vButton.BackColor = Color.Lavender;
            vButton.ForeColor = Color.Black;
        }

        private void btnRemoveEntry_Click(object sender, EventArgs e)
        {
            if (olvShortcuts.SelectedItems.Count > 0)
            {
                try
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to COMPLETELY remove this shortcut entry?", "Remove Shortcut", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (result == DialogResult.OK)
                    {
                        ShowWorking();

                        String path = ((ShortcutItem)olvShortcuts.SelectedItem.RowObject).ShortcutPath;
                        String filename = FileFunctions.getFilename(path, true);

                        ShortcutExt.RemoveFromTaskbar(path);
                        ShortcutExt.RemoveFromStartMenu(path);
                        //delete file
                        if (File.Exists(path)) FileFunctions.DeleteFileToRecycleBin(path);
                        Shortcuts.Items.RemoveAll(x => x.ShortcutPath == path);
                        
                        //fillShortcutsList();

                        lblResults.Text = filename + " Removed";
                        lblResults.ForeColor = Color.DarkGreen;

                        HideWorking();
                    }

                }
                catch (Exception)
                {
                    String path = ((ShortcutItem)olvShortcuts.SelectedItem.RowObject).ShortcutPath;
                    String filename = FileFunctions.getFilename(path, true);

                    lblResults.Text = filename + ": Problem removing shortcut";
                    lblResults.ForeColor = Color.DarkRed;
                }

            }

            fillShortcutsList();
            HideWorking();
            setShortcutButtons();
        }








        internal void setHandlers()
        {
            txtName.MouseClick += TxtName_MouseClick;
            txtName.LostFocus += TxtName_LostFocus;

            txtEXEPath.MouseClick += TxtEXEPath_MouseClick;
            txtEXEPath.LostFocus += TxtEXEPath_LostFocus;

            txtURL.MouseClick += TxtURL_MouseClick;
            txtURL.LostFocus += TxtURL_LostFocus;

            txtShortcutPath.MouseClick += TxtShortcutPath_MouseClick;
            txtShortcutPath.LostFocus += TxtShortcutPath_LostFocus;
            txtShortcutKey.KeyDown += TxtShortcutKey_KeyDown;

            olvShortcuts.MouseDoubleClick += OlvShortcuts_MouseDoubleClick;
            olvShortcuts.MouseDown += OlvShortcuts_MouseDown;

            txtShortcutKey.MouseClick += TxtShortcutKey_MouseClick;
            txtShortcutKey.LostFocus += TxtShortcutKey_LostFocus;
        }

        private void TxtShortcutKey_KeyDown(object sender, KeyEventArgs e)
        {
            
            string keys = "";

            if ((System.Windows.Input.Keyboard.Modifiers & System.Windows.Input.ModifierKeys.Control) > 0)
            {
                keys += "Ctrl+";
            }

            if ((System.Windows.Input.Keyboard.Modifiers & System.Windows.Input.ModifierKeys.Alt) > 0)
            {
                keys += "Alt+";
            }

            if ((System.Windows.Input.Keyboard.Modifiers & System.Windows.Input.ModifierKeys.Shift) > 0)
            {
                keys += "Shift+";
            }

            keys += e.KeyCode;// Key;

            txtShortcutKey.Text = keys;

            //Boolean ShortcutOK = IsShortcutKeysOK(txtShortcutKey.Text.Trim(), out String MatchString);
            //txtShortcutKey.Text = MatchString;

            //if (!ApplyingSettings) CheckForm(false, false);
        }

        private void txtShortcutKey_TextChanged(object sender, EventArgs e)
        {
            setText(((TextBox)sender), ExampleShortcutKey);
            //if (!ApplyingSettings) CheckForm(false, false);
        }

        private void TxtShortcutKey_LostFocus(object sender, EventArgs e)
        {
            setTextBoxLostFocus(((TextBox)sender), ExampleShortcutKey);

            if (!IsShortcutKeysOK(txtShortcutKey.Text.Trim(), out String MatchString))
            {
                //message += " * The Shortcut Keys are not formatted correctly" + System.Environment.NewLine;
                lblResults.Text = "Check form problems";
                lblResults.ForeColor = Color.DarkRed;
                txtShortcutKey.BackColor = Color.PaleGoldenrod;
            } else
            {
                txtShortcutKey.Text = MatchString;
            }

        }

        private void TxtShortcutKey_MouseClick(object sender, MouseEventArgs e)
        {
            if (((TextBox)sender).Text == ExampleShortcutKey)
            {
                ((TextBox)sender).Text = string.Empty;
            }
        }

        private void OlvShortcuts_MouseDown(object sender, MouseEventArgs e)
        {
            // show context menu
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (olvShortcuts.SelectedItems.Count > 0)
                {
                    this.cmShortcuts.Show((ObjectListView)sender, e.Location);
                }
            }
        }

        private void OlvShortcuts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (olvShortcuts.SelectedItems.Count > 0)
            {
                ApplyingSettings = true;

                setEdit(((ShortcutItem)olvShortcuts.SelectedItem.RowObject).ShortcutPath, ((ShortcutItem)olvShortcuts.SelectedItem.RowObject).Arguments);
                EditShortcutPath = ((ShortcutItem)olvShortcuts.SelectedItem.RowObject).ShortcutPath;
                //btnCreateShortcut.Enabled = true;
                enableButton(btnCreateShortcut);

                ApplyingSettings = false;
            }
            else
            {
                ClearForm();
            }
        }


        private void btnBrowseEXE_Click(object sender, EventArgs e)
        {
            //TODO: Check for canceled dialog / no result

            string path = SelectEXEICO(Properties.Settings.Default.LastEXEPath);

            if (!String.IsNullOrEmpty(path))
            {
                Properties.Settings.Default.LastEXEPath = System.IO.Path.GetDirectoryName(path);
                Properties.Settings.Default.Save();

                ApplyingSettings = true;
                CurrentEXEFilePath = path;
                txtEXEPath.Text = path;
                setIcon(CurrentEXEFilePath);
                ApplyingSettings = false;
            }

        }

        private void btnManageShortcut_Click(object sender, EventArgs e)
        {
            if (olvShortcuts.SelectedItems.Count > 0)
            {
                try
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to remove this shortcut file?", "Remove Shortcut", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (result == DialogResult.OK)
                    {
                        ShowWorking();

                        String path = ((ShortcutItem)olvShortcuts.SelectedItem.RowObject).ShortcutPath;
                        String filename = FileFunctions.getFilename(path, true);

                        ShortcutExt.RemoveFromTaskbar(path);
                        ShortcutExt.RemoveFromStartMenu(path);
                        //delete file
                        FileFunctions.DeleteFileToRecycleBin(path);

                        //result = MessageBox.Show("Are you sure you want to remove this shortcut from the list?", "Remove Shortcut from List", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        //if (result == DialogResult.OK)
                        //{
                        //    Shortcuts.Items.RemoveAll(x => x.ShortcutPath == path);
                        //}                        

                        fillShortcutsList();

                        lblResults.Text = filename + " Removed";
                        lblResults.ForeColor = Color.DarkGreen;

                        HideWorking();
                    }

                }
                catch (Exception)
                {
                    String path = ((ShortcutItem)olvShortcuts.SelectedItem.RowObject).ShortcutPath;
                    String filename = FileFunctions.getFilename(path, true);

                    lblResults.Text = filename + ": Problem removing shortcut";
                    lblResults.ForeColor = Color.DarkRed;
                }

            }

            setShortcutButtons();
        }

        private void btnManageTaskbar_Click(object sender, EventArgs e)
        {
            if (olvShortcuts.SelectedItems.Count > 0)
            {
                ShowWorking();

                String path = ((ShortcutItem)olvShortcuts.SelectedItem.RowObject).ShortcutPath;
                String filename = FileFunctions.getFilename(path, true);
                if (!IsInTaskbar(filename))
                {
                    ShortcutExt.PinToTaskbar(path);// @"E:\Users\Troy\Dropbox\@Backup\VisualStudio\LAWC\LAWC\bin\x64\Release\LAWC.exe");
                    lblResults.Text = filename + " Pinned to Taskbar";
                    lblResults.ForeColor = Color.DarkGreen;
                }
                else
                {
                    ShortcutExt.RemoveFromTaskbar(path); // @"E:\Users\Troy\Dropbox\@Backup\VisualStudio\LAWC\LAWC\bin\x64\Release\LAWC.exe");
                    lblResults.Text = filename + " Removed from Taskbar";
                    lblResults.ForeColor = Color.DarkGreen;
                }
            }
            setShortcutButtons();
            HideWorking();

        }


        private void btnCreateShortcut_Click(object sender, EventArgs e)
        {
            Boolean isInStart = false;
            Boolean isInTaskbar = false;

            //do cleanup of old shortcut first
            if (ShortcutPathChanged && mode == Mode.Edit)
            {
                isInStart = IsInStartMenu(Path.Combine(this.ShortcutPathOld, editItem.Name + ".lnk"));// Path.Combine(ShortcutPathOld, vShortcutFilename));
                isInTaskbar = IsInTaskbar(Path.Combine(this.ShortcutPathOld, editItem.Name + ".lnk"));// Path.Combine(ShortcutPathOld, vShortcutFilename));

                CleanUpOldShortcut(Path.Combine(this.ShortcutPathOld, editItem.Name + ".lnk"));
                ShortcutPathOld = string.Empty;
                ShortcutPathChanged = false;
            }
            //Create new shortcut

            CreateShortcut(isInStart, isInTaskbar);

        }


        private void btnBrowseShortcutLocation_Click(object sender, EventArgs e)
        {

            string path = FileFunctions.SelectShortcutFolder(Properties.Settings.Default.LastShortcutPath);
            if (System.IO.Directory.Exists(path))
            {
                Properties.Settings.Default.LastShortcutPath = path;
                Properties.Settings.Default.Save();

                ApplyingSettings = true;
                CurrentShortcutPath = path;
                txtShortcutPath.Text = path;
                ApplyingSettings = false;
            }

        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            using (frmFindURL formFind = new frmFindURL())
            {
                formFind.ShowDialog();
                
                ApplyingSettings = true;
                if (!String.IsNullOrEmpty(formFind.Found)) txtURL.Text = formFind.Found;
                if (!String.IsNullOrEmpty(formFind.FoundName)) txtName.Text = formFind.FoundName;
                
                //CheckForm(false, false);
                //Check if this entry is already in the list
                if (mode == Mode.Add && Shortcuts.Items.Find(x => x.Arguments.Equals("-URL " + txtURL.Text.Trim())) != null)
                {
                    txtURL.BackColor = Color.PaleGoldenrod;
                    lblResults.Text = "Check form problems";
                    lblResults.ForeColor = Color.DarkRed;
                    MessageBox.Show("This App / Game / URL is already in your list of Shortcuts", "Entry already Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else
                {
                    lblResults.Text = "";
                    lblResults.ForeColor = Color.DarkGreen;
                }

                ApplyingSettings = false;
            }
        }


        private void TxtShortcutPath_LostFocus(object sender, EventArgs e)
        {
            setTextBoxLostFocus(((TextBox)sender), ExampleShortcutPath);
        }

        private void TxtShortcutPath_MouseClick(object sender, MouseEventArgs e)
        {
            if (((TextBox)sender).Text == ExampleShortcutPath)
            {
                ((TextBox)sender).Text = string.Empty;
            }
        }

        private void TxtURL_LostFocus(object sender, EventArgs e)
        {
            setTextBoxLostFocus(((TextBox)sender), ExampleURL);
        }

        private void TxtURL_MouseClick(object sender, MouseEventArgs e)
        {
            if (((TextBox)sender).Text == ExampleURL)
            {
                ((TextBox)sender).Text = string.Empty;
            }
        }

        private void TxtEXEPath_LostFocus(object sender, EventArgs e)
        {
            setTextBoxLostFocus(((TextBox)sender), ExampleEXEFilePath);
        }

        private void TxtEXEPath_MouseClick(object sender, MouseEventArgs e)
        {
            if (((TextBox)sender).Text == ExampleEXEFilePath)
            {
                ((TextBox)sender).Text = string.Empty;
            }
        }

        private void TxtName_LostFocus(object sender, EventArgs e)
        {
            setTextBoxLostFocus(((TextBox)sender), ExampleName);
        }

        private void TxtName_MouseClick(object sender, MouseEventArgs e)
        {
            if (((TextBox)sender).Text == ExampleName)
            {
                ((TextBox)sender).Text = string.Empty;
            }

            //if (txtName.Text == ExampleName)
            //{
            //    txtName.Text = string.Empty;
            //}
        }



        private void txtName_TextChanged(object sender, EventArgs e)
        {
            setText(txtName, ExampleName);
            CheckShortcutPathChanged();
            if (!ApplyingSettings) CheckForm(false, false);
            
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            if (ApplyingSettings) return;

            setText(((TextBox)sender), ExampleURL);

            //Check if this entry is already in the list
            if (mode == Mode.Add && txtURL.Text != ExampleURL && Shortcuts.Items.Find(x => x.Arguments.Equals("-URL " + txtURL.Text.Trim())) != null)
            {
                txtURL.BackColor = Color.PaleGoldenrod;
                lblResults.Text = "Check form problems";
                lblResults.ForeColor = Color.DarkRed;
                MessageBox.Show("This App / Game / URL is already in your list of Shortcuts", "Entry already Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                lblResults.Text = "";
                lblResults.ForeColor = Color.DarkGreen;
            }

             //CheckForm(false, false);
        }

        private void txtEXEPath_TextChanged(object sender, EventArgs e)
        {
            setText(((TextBox)sender), ExampleEXEFilePath);
            if (!ApplyingSettings) CheckForm(false, false);
        }

        private void txtShortcutPath_TextChanged(object sender, EventArgs e)
        {
            setText(((TextBox)sender), ExampleShortcutPath);
            CheckShortcutPathChanged();
            if (!ApplyingSettings) CheckForm(false, false);

        }

        private void CheckShortcutPathChanged()
        {
            if (mode == Mode.Edit)
            {
                if (txtShortcutPath.Text != ExampleShortcutPath
                && txtShortcutPath.Text != ShortcutPathOld //Properties.Settings.Default.LastShortcutPath
                && txtName.Text != ExampleName
                && txtName.Text != editItem.Name
                )
                {
                    ShortcutPathOld = Properties.Settings.Default.LastShortcutPath;
                    ShortcutPathChanged = true;
                }
                else
                {
                    ShortcutPathOld = string.Empty;
                    ShortcutPathChanged = false;
                }
            } else
            {
                // new entry
                ShortcutPathOld = string.Empty;
                ShortcutPathChanged = false;
            }
            
        }

        private void cbFileLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newPath = GetSpecialFolderPath(cbFileLocation.SelectedItem.ToString());
            if (cbFileLocation.SelectedItem.ToString() != "Other")
            {
                txtShortcutPath.Text = newPath;
            }
            else
            {
                //Other
                txtShortcutPath.Text = Properties.Settings.Default.LastShortcutPath;
            }
            Properties.Settings.Default.ShortcutPathPreset = cbFileLocation.SelectedItem.ToString();
            Properties.Settings.Default.Save();

            CheckShortcutPathChanged();
            setFileLocationControls();

            if (!ApplyingSettings) CheckForm(false, false);
        }


        private void btnPinStart_Click(object sender, EventArgs e)
        {
            if (olvShortcuts.SelectedItems.Count > 0)
            {
                ShowWorking();

                String path = ((ShortcutItem)olvShortcuts.SelectedItem.RowObject).ShortcutPath;
                String filename = FileFunctions.getFilename(path, true);

                if (!IsInStartMenu(path))
                {
                    ShortcutExt.PinToStartMenu(path);
                    lblResults.Text = filename + " Pinned to Start Menu";
                    lblResults.ForeColor = Color.DarkGreen;
                }
                else
                {
                    ShortcutExt.RemoveFromStartMenu(path);
                    lblResults.Text = filename + " Removed from Start Menu";
                    lblResults.ForeColor = Color.DarkGreen;
                }
            }
            //need to open the start menu to register the change
            KeyboardSend.KeyDown(Keys.LWin);
            KeyboardSend.KeyUp(Keys.LWin);

            setShortcutButtons();
            HideWorking();
        }


        private void olvShortcuts_SelectedIndexChanged(object sender, EventArgs e)
        {
            setShortcutButtons();
        }


        //*****************************************************************************************************************
        



    }
}
