using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static FastPhotoRenamer.Common.ErrorHandling;

namespace Game_Shortcut_Manager
{
    public partial class frmShowText : Form
    {

        //
        // source code 
        // Code Snippet
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }



        private readonly frmMain parentForm;// = null;

        /// <summary>
        /// used to determine if the OK button will hide the form
        /// </summary>
        internal Boolean OKHide = false;

        public frmShowText()
        {
            InitializeComponent();
        }

        public frmShowText(frmMain vParentForm)
        {
            InitializeComponent();

            parentForm = vParentForm;
            
        }

        private void frmShowText_Load(object sender, EventArgs e)
        {
            setColour(parentForm);
        }



        internal void setColour(frmMain vParentForm)
        {
            //this.BackColor = vParentForm.colourDarkest;
            //this.ForeColor = vParentForm.colourLightest;
            //this.richText.BackColor = vParentForm.colourDarkest;
            //this.richText.ForeColor = vParentForm.colourLightest;
            //this.btnCancel.BackColor = vParentForm.colourDarkest;
            //this.btnCancel.ForeColor = vParentForm.colourLightest;
            //this.btnOK.BackColor = vParentForm.colourDarkest;
            //this.btnOK.ForeColor = vParentForm.colourLightest;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //this.Hide();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.OKHide) this.Hide();
        }

        private void btnSendError_Click(object sender, EventArgs e)
        {
            btnSendError.Text = "Sending...";
            btnSendError.Enabled = false;
            lblWorking.Visible = true;
            lblWorking.Refresh();

            //TODO: Fix / implement this?
            //ErrorHandling.SendSMTPMail("tgrowden@gmail.com", "troy@strangetimez.com", "FastPhotoRenamer Error Received!", this.richText.Text, FileFunctions.GetErrorLogFullPath(), null, MailPriority.High); //TODO: Change these!!! Non named emails

            btnSendError.Text = "Send Error";
            btnSendError.Enabled = true;
            lblWorking.Visible = false;
            lblWorking.Refresh();

            MessageBox.Show("Thank you for sending the error information.", "Information Sent", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //this.Hide();
        }


    }
}
