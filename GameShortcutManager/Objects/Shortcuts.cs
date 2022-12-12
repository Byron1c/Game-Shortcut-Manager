using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Game_Shortcut_Manager.Objects
{
    internal class Shortcuts
    {

        internal List<ShortcutItem> Items;


        internal Shortcuts()
        {
            Items = new List<ShortcutItem>();
        }

        internal void Load(String vSettingsPath)
        {
            try
            {
                // LOAD SETTINGS to forms and values
                DataSet dsMain;
                dsMain = ReadXML(vSettingsPath);
                if (dsMain != null)
                {
                    // add the list items to the settings
                    LoadDS(dsMain);
                    dsMain.Dispose();
                }
                else
                {                   

                }

            }
            catch (EndOfStreamException ex)
            {
                //TODO: error handling
            }

            
        }


        public static string getSettingsFullPathFixed()
        {
            string settingsFullPath;

            settingsFullPath = Application.ExecutablePath.ToString(CultureInfo.InvariantCulture).Replace("GameShortcutManager.exe", ""); // System.IO.Directory.GetCurrentDirectory() + "\\";
            
            return settingsFullPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vWriteToLog"></param>
        /// <param name="vFirstRunDone">This is the first time the app runs</param>
        /// <returns></returns>
        public DataSet ReadXML(String vSettingsFullPath)
        {
            
            DataSet output = new DataSet();

            if (System.IO.File.Exists(vSettingsFullPath))
            {
                TextReader tr;
                XmlTextReader reader;

                tr = new StreamReader(vSettingsFullPath);
                reader = new XmlTextReader(tr) { DtdProcessing = DtdProcessing.Prohibit };

                try
                {
                    //XmlReadMode mode = output.ReadXml(settingsFullPath, XmlReadMode.ReadSchema);

                    XmlReadMode mode = output.ReadXml(reader, XmlReadMode.ReadSchema);
                    if (mode != XmlReadMode.ReadSchema)
                    {
                        //ErrorHandling.ProcessError(null, ErrorHandling.ErrorMessageType.XMLFileRead, true, false, string.Format(CultureInfo.InvariantCulture, ""), vSettingsFullPath);
                        //TODO: Error here
                    }

                }
                catch (FileLoadException ex)
                {
                    //FileFunctions.WriteToLog(MainFunctions.GetErrorLogFullPath(Properties.Settings.Default.Portable), "Error 008: Settings file is corrupt, a new one will be created.", vWriteToLog);
                    //MessageBox.Show("Error reading settings file (" + settingsFullPath +").\n\n" + ex.Message.ToString(CultureInfo.InvariantCulture));
                    //MessageBox.Show("Your Settings file (" + settingsFullPath + ") is corrupt.\n\n  A new one will be created.\n\nError: " + ex.Message, "Settings File Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //TODO: Error here
                    //ErrorHandling.ProcessError(ex, ErrorHandling.ErrorMessageType.ReadingSettingsXML, false, false, string.Format(CultureInfo.InvariantCulture, ""), vSettingsFullPath);
                    //throw;
                }
                catch (XmlException ex)
                {
                    //TODO: Error here
                    //ErrorHandling.ProcessError(ex, ErrorHandling.ErrorMessageType.ReadingSettingsXML, false, false, string.Format(CultureInfo.InvariantCulture, ""), vSettingsFullPath);
                    output = null; // no xml file loaded!
                }
                finally
                {
                    reader.Close();
                    //if (tr != null) tr.Close();
                }
            }
            else
            {
                // dont log an error if this is the first time the app has run, and needs to create the settings file
                //if (vFirstRunDone) 
                //    ErrorHandling.ProcessError(null, ErrorHandling.ErrorMessageType.SettingsNotFound, false, false, string.Format(CultureInfo.InvariantCulture, ""), vSettingsFullPath);
                //FileFunctions.WriteToLog(MainFunctions.GetErrorLogFullPath(Properties.Settings.Default.Portable), "Warning 001: Settings file not found, a new one will be created.", vWriteToLog);
                //MessageBox.Show("This is your first time running LAWC.\n\n  A new settings file will be created (" + settingsFullPath + ").", "Settings File Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return output;

        }


        public void LoadDS(DataSet vDSMain)
        {
            DataRow dr;

            try
            {
                Items.Clear();

                if (vDSMain.Tables["Shortcuts"] != null)
                {

                    for (int i = 0; i < vDSMain.Tables["Shortcuts"].Rows.Count; i++)
                    {
                        dr = vDSMain.Tables["Shortcuts"].Rows[i];

                        String itemArguments = dr["Arguments"].ToString();
                        String itemDescription = dr["Description"].ToString();
                        String itemHotkey = dr["Hotkey"].ToString();
                        String itemIconPath = dr["IconPath"].ToString();
                        String itemShortcutPath = dr["ShortcutPath"].ToString();
                        String itemTarget = dr["Target"].ToString();
                        String itemWorkingDirectory = dr["WorkingDirectory"].ToString();
                        String itemName = dr["Name"].ToString();
                        String itemShortcutPathSpecialFolder = dr["ShortcutPathSpecialFolder"].ToString();

                        ShortcutItem item = new ShortcutItem
                        {
                            Arguments = itemArguments,
                            Description = itemDescription,
                            Hotkey = itemHotkey,
                            IconPath = itemIconPath,
                            ShortcutPath = itemShortcutPath,
                            Target = itemTarget,
                            WorkingDirectory = itemWorkingDirectory,
                            Name = itemName,
                            ShortcutPathSpecialFolder = itemShortcutPathSpecialFolder
                        };

                        Items.Add(item);

                    }

                } // end if
            }
            catch (Exception ex)
            {

            }
        }

        public Boolean Save(String vSettingsFullPath)
        {

            Boolean output = false;
            
            DataSet dsMain = new DataSet();
            //DataTable dtConfig = new DataTable();
            DataTable dtShortcuts = new DataTable();
            
            //DataTable dtRecentlyAdded = new DataTable();
            DataRow dr;


            //// Website URLs //////////////////////////////////

            dtShortcuts.TableName = "Shortcuts";
            dtShortcuts.Columns.Add("ShortcutPath", System.Type.GetType("System.String"));
            dtShortcuts.Columns.Add("Name", System.Type.GetType("System.String"));
            dtShortcuts.Columns.Add("Description", System.Type.GetType("System.String"));
            dtShortcuts.Columns.Add("Target", System.Type.GetType("System.String"));
            dtShortcuts.Columns.Add("WorkingDirectory", System.Type.GetType("System.String"));
            dtShortcuts.Columns.Add("IconPath", System.Type.GetType("System.String"));
            dtShortcuts.Columns.Add("Arguments", System.Type.GetType("System.String"));
            dtShortcuts.Columns.Add("Hotkey", System.Type.GetType("System.String"));
            dtShortcuts.Columns.Add("ShortcutPathSpecialFolder", System.Type.GetType("System.String"));

            dsMain.Tables.Add(dtShortcuts);

            for (int i = 0; i < this.Items.Count; i++)
            {
                dr = dsMain.Tables["Shortcuts"].NewRow();

                dr["ShortcutPath"] = Items[i].ShortcutPath;
                dr["Name"] = Items[i].Name;   //.LastVisited.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
                dr["Description"] = Items[i].Description;
                dr["Target"] = Items[i].Target;
                dr["WorkingDirectory"] = Items[i].WorkingDirectory;
                dr["IconPath"] = Items[i].IconPath;
                dr["Arguments"] = Items[i].Arguments;
                dr["Hotkey"] = Items[i].Hotkey;
                dr["ShortcutPathSpecialFolder"] = Items[i].ShortcutPathSpecialFolder;
                

                dtShortcuts.Rows.Add(dr);

            }

            //////  WRITE THE OUTPUT //////////////////

            try
            {
                if (!Directory.Exists(System.IO.Path.GetDirectoryName(vSettingsFullPath)))
                {
                    string path = System.IO.Path.GetDirectoryName(vSettingsFullPath);
                    System.IO.Directory.CreateDirectory(path);
                }
                dsMain.WriteXml(vSettingsFullPath, XmlWriteMode.WriteSchema);
                output = true;

            }
            catch (IOException ex)
            {
                //TODO: Error handling
                //ErrorHandling.ProcessError(ex, ErrorHandling.ErrorMessageType.SavingSettings, true, false, String.Format(CultureInfo.InvariantCulture, ""), Setting.getSettingsFullPath(Properties.Settings.Default.Portable));
                //MessageBox.Show("Error saving settings: \n\n" + ex.Message);
                //FileFunctions.WriteToLog(MainFunctions.GetErrorLogFullPath(Properties.Settings.Default.Portable), "Error saving settings: \n\n" + ex.Message, vSetting.WriteToLog);
                return false;
            }



            dtShortcuts.Clear();
            dtShortcuts.Dispose();

            output = true; 

            return output;

        }

    }
}
