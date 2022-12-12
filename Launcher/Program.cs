using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{
    
    // HOW TO PROPERLY EXIT A PROGRAM
    //https://stackoverflow.com/questions/12977924/how-to-properly-exit-a-c-sharp-application



    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());


            String URL = string.Empty;
            Boolean Launch = false;


            //**** Command Line Argument handling ***************
            if (args.Length > 0)
            {
                try
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

                        //if (arg.ToUpperInvariant().Contains("-LAUNCH"))
                        //{
                        Launch = true;
                        //}


                        index++;
                    }
                    
                    if (URL != string.Empty && Launch == true)
                    {
                        OpenURL(URL);
                        //Quit();
                    }

                    Quit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error starting the link:" + System.Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                
            }


            Quit();
            //***************************************************


        }

        internal static void OpenURL(String vURL)
        {
            //System.Diagnostics.ProcessStartInfo startInfo;

            System.Diagnostics.Process.Start(vURL);
        }

        internal static void Quit()
        {
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



    }
}
