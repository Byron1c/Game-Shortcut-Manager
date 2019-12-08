using BrightIdeasSoftware;
using System.Drawing;

namespace Game_Shortcut_Manager.Objects
{
    internal static class ObjectListViewExt
    {

        internal enum HotItemStyleNum
        {
            TurnOff = 0,
            None = 1,
            TextColour = 2,
            Border = 3,
            Translucent = 4,
            LightBox = 5,
        }


        internal static void adjustMyObjectListViewHeader(ObjectListView vOLVList, Color vForeColour, Color vBackColour)
        {
            foreach (OLVColumn item in vOLVList.Columns)
            {
                var headerstyle = new HeaderFormatStyle();
                headerstyle.SetBackColor(vBackColour);
                headerstyle.SetForeColor(vForeColour);
                item.HeaderFormatStyle = headerstyle;
            }
        }


        /// <summary>
        /// 1: None
        /// 2: Text Colour
        /// 3: Border
        /// 4: Translucent
        /// 5: Light Box
        /// </summary>
        /// <param name="olv"></param>
        /// <param name="vStyle"></param>
        internal static void ChangeHotItemStyle(ObjectListView olv, HotItemStyleNum vStyle)
        {
            olv.UseTranslucentHotItem = false;
            olv.UseHotItem = true;
            olv.UseExplorerTheme = false;

            switch (vStyle)
            {
                case HotItemStyleNum.TurnOff:// 0:
                    olv.UseHotItem = false;
                    break;
                case HotItemStyleNum.None:
                    HotItemStyle hotItemStyle = new HotItemStyle
                    {
                        ForeColor = Color.AliceBlue,
                        BackColor = Color.FromArgb(255, 64, 64, 64)
                    };
                    olv.HotItemStyle = hotItemStyle;
                    break;
                case HotItemStyleNum.TextColour:
                    RowBorderDecoration rbd = new RowBorderDecoration
                    {
                        BorderPen = new Pen(Color.SeaGreen, 2),
                        FillBrush = null,
                        CornerRounding = 4.0f
                    };
                    HotItemStyle hotItemStyle2 = new HotItemStyle
                    {
                        Decoration = rbd
                    };
                    olv.HotItemStyle = hotItemStyle2;
                    break;
                case HotItemStyleNum.Border:
                    olv.UseTranslucentHotItem = true;
                    break;
                case HotItemStyleNum.Translucent:
                    HotItemStyle hotItemStyle3 = new HotItemStyle
                    {
                        Decoration = new LightBoxDecoration()
                    };
                    olv.HotItemStyle = hotItemStyle3;
                    break;
                case HotItemStyleNum.LightBox:
                    olv.FullRowSelect = true;
                    olv.UseHotItem = false;
                    olv.UseExplorerTheme = true;
                    break;
            }
            olv.Invalidate();
        }


    }
}
