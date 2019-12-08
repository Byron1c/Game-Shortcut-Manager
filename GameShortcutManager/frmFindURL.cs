using Game_Shortcut_Manager.Objects;
using SteamStoreQuery;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Shortcut_Manager
{
    public partial class frmFindURL : Form
    {

        internal String Found = string.Empty;
        internal String FoundName = string.Empty;

        internal List<Listing> results = null;
        internal ImageList ilImages = null;

        public frmFindURL()
        {
            InitializeComponent();
        }

        private void frmFindURL_Load(object sender, EventArgs e)
        {
            olvResults.MouseDoubleClick += OlvResults_MouseDoubleClick;
            txtSearch.KeyPress += TxtSearch_KeyPress;
        }

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                doSearch();
            }
        }

        private void OlvResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            doSelect();
        }

        private void doSelect()
        {
            if (olvResults.SelectedItem == null) return;
            Listing row = (Listing)olvResults.SelectedItem.RowObject;
            Found = "steam://rungameid/" + row.AppId; //SteamWebAPIExt.GetSteamAppID(txtSearch.Text);
            FoundName = row.Name;
            this.Hide();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //Found = "steam://rungameid/" + SteamWebAPIExt.GetSteamAppID(txtSearch.Text);
            doSelect();
            
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            doSearch();
        }

        private void doSearch()
        {
            //Found = "steam://rungameid/" + SteamWebAPIExt.GetSteamAppID(txtSearch.Text);
            results = SteamWebAPIExt.GetSteamApps(txtSearch.Text);
            fillResultsList();
        }

        internal void fillResultsList()
        {
            //getListImages(this.results);
                        
            //adjustMyObjectListViewHeader();
            ObjectListViewExt.adjustMyObjectListViewHeader(this.olvResults, Color.GhostWhite, Color.DarkGray);//parentForm.colourLightest, parentForm.colourDarkest);
            ObjectListViewExt.ChangeHotItemStyle(olvResults, ObjectListViewExt.HotItemStyleNum.LightBox); // set hover to translucent
            
            olvResults.VirtualMode = false;
            olvResults.ShowGroups = false;
            //olvResults.LargeImageList = this.ilImages;

            //olvName.ImageAspectName = "Image";
            //olvName.ImageGetter += delegate (object rowObject)
            //{
            //    // this would essentially be the same as using the ImageAspectName
            //    return ((Item)rowObject).Image;
            //};
            //olvName.ImageGetter += delegate (object rowObject) {
            //    int imageListIndex = 0;

            //    // some logic here
            //    // decide which image to use based on rowObject properties or any other criteria

            //    return imageListIndex;
            //};

            this.olvResults.SetObjects(results);

            //int index = 0;
            //foreach (ListViewItem item in olvResults.Items)
            //{
            //    item.ImageIndex = index;
            //    item.ImageKey = index.ToString();
            //    index++;
            //}

        }

        internal void getListImages(List<Listing> vResults)
        {
            this.ilImages = new ImageList();

            int index = 0;
            foreach (Listing item in vResults)
            {
                System.Net.WebRequest request = System.Net.WebRequest.Create(item.ImageLink);
                System.Net.WebResponse resp = request.GetResponse();
                System.IO.Stream respStream = resp.GetResponseStream();
                Bitmap bmp = new Bitmap(respStream);
                respStream.Dispose();

                ilImages.Images.Add(index.ToString(), bmp);
                index++;
            }
        }

        private void olvResults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
