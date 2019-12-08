using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;


namespace Game_Shortcut_Manager
{
    public partial class frmAbout : Form
    {

        frmMain parentForm;

        public frmAbout(frmMain vParentForm)
        {
            InitializeComponent();

            parentForm = vParentForm;
        }


        private void frmAbout_Load(object sender, EventArgs e)
        {
            setInterfaceColour();
            getAppInfo();
        }

        private void llName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenAppURL();
        }

        private void llCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenAppURL();
        }

        private void btnSupportEmail_Click(object sender, EventArgs e)
        {
            
        }
                     
        private void pbDonate_Click(object sender, EventArgs e)
        {
            OpenDonateURL();
        }

        private void pbDonateQRCode_Click(object sender, EventArgs e)
        {
            OpenDonateURL();
        }

        internal void setInterfaceColour()
        {

            //foreach (Control c in this.Controls)
            //{
            //    c.BackColor = parentForm.colourDarker;//colourDarkest;
            //    c.ForeColor = parentForm.colourLightest;
            //}

            //this.BackColor = parentForm.colourDarker;//colourDarkest;
            //this.ForeColor = parentForm.colourLightest;

            //this.llName.LinkColor = parentForm.colourLink;
            //this.llCompany.LinkColor = parentForm.colourLink;

        }

        private void getAppInfo()
        {
            try
            {
                string company = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCompanyAttribute), false)).Company;
                string Title = ((AssemblyTitleAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute), false)).Title;

                var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

                llName.Text = Title;

                //this.lblProductName.Text = Title; //this.GetType().Assembly.GetName().FullName.ToString();  //this.GetType().Assembly.GetCustom.GetName().Name.ToString();
                this.lblVersion.Text = "" + this.GetType().Assembly.GetName().Version.ToString();
                this.llCompany.Text = company; //"Strangetimez";
                this.lblCopyright.Text = versionInfo.LegalCopyright;

                var descriptionAttribute = this.GetType().Assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)
                    .OfType<AssemblyDescriptionAttribute>()
                    .FirstOrDefault();

                if (descriptionAttribute != null) this.txtDescription.Text = descriptionAttribute.Description;

                //var copmpanyAttribute = this.GetType().Assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false)
                //                .OfType<AssemblyCompanyAttribute>()
                //                .FirstOrDefault();

                //if (copmpanyAttribute != null) this.lblCompany.Text = copmpanyAttribute.Company;
            }
            catch (ArgumentException ex)
            {
                //ProcessError(ex, ErrorMessageType.GetValue, ShowError.NoShow, ThrowError.NoThrow, String.Format(CultureInfo.InvariantCulture, ""), FileFunctions.GetErrorLogFullPath());
            }
            catch (AmbiguousMatchException ex)
            {
                //ProcessError(ex, ErrorMessageType.GetValue, ShowError.NoShow, ThrowError.NoThrow, String.Format(CultureInfo.InvariantCulture, ""), FileFunctions.GetErrorLogFullPath());
            }



        }

        internal static void OpenDonateURL()
        {
            System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=ZY9EW2SVJ84NU&item_name=GameShortcutManager&currency_code=AUD&source=url");
        }


        internal static void OpenAppURL()
        {
            System.Diagnostics.Process.Start("https://www.strangetimez.com/Blog/game-shortcut-manager/"); 
        }

        internal static void OpenFBURL()
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/Strangetimez/"); 
        }

        private void pbFacebook_Click(object sender, EventArgs e)
        {
            OpenFBURL();
        }

        private void pbIcon_Click(object sender, EventArgs e)
        {
            OpenAppURL();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "mailto:tgrowden@gmail.com?subject=" + frmMain.AppPathName + " Feedback/Support/Question&body=I have a Question / some Feedback / a Support Issue (**please say which one**)\n\n";
            proc.Start();
        }
    }
}
