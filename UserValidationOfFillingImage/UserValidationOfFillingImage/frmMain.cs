using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UserValidationOfFillingImage
{
    public partial class frmMain : Form
    {
        private const int DISTANCE_FROM_SIDE_X = 130;
        private const int DISTANCE_FROM_SIDE_Y = 30;
        private const int UNFILLED_RERION_START_Y = 120;
        private const int CUTTED_IMAGE_START_X = 30;
        private UnfilledRegion m_unfilledRegion = null;
        private Bitmap m_cuttedImage = null;
        private Random m_random = new Random(DateTime.Now.Millisecond);
        private int m_unfilledRegionStartX = 0;
        private Rectangle m_dragRegion;

        public frmMain()
        {
            InitializeComponent();

            m_unfilledRegion = new UnfilledRegion();
            m_cuttedImage = new Bitmap(m_unfilledRegion.RegionWidth, m_unfilledRegion.RegionHeight);
            m_dragRegion = new Rectangle(CUTTED_IMAGE_START_X,picBoard.Height-DISTANCE_FROM_SIDE_Y * 2, m_unfilledRegion.RegionWidth, m_unfilledRegion.RegionHeight);
            InitUnfilledRegionStartX();
            ResetCuttedImage();
            this.DoubleBuffered = true;
        }

        private void InitUnfilledRegionStartX()
        {
            m_unfilledRegionStartX = m_random.Next(0, UserValidationOfFillingImage.Properties.Resources.hehua.Width - m_unfilledRegion.RegionWidth);
        }

        private void ResetDragRegion()
        {
            m_dragRegion.X = CUTTED_IMAGE_START_X;
        }
             

        private void ResetCuttedImage()
        {
            // 使用Clone方法
            //m_cuttedImage = UserValidationOfFillingImage.Properties.Resources.hehua.Clone(
            //        new Rectangle(m_unfilledRegionStartX, UNFILLED_RERION_START_Y, m_unfilledRegion.RegionWidth, m_unfilledRegion.RegionHeight),
            //        UserValidationOfFillingImage.Properties.Resources.hehua.PixelFormat);

            // 使用Graphics.DrawImage方法
            using (Graphics g = Graphics.FromImage(m_cuttedImage))
            {
                g.Clip = new System.Drawing.Region(m_unfilledRegion.ClipRegion);
                g.DrawImage(UserValidationOfFillingImage.Properties.Resources.hehua,
                    0, 0, new Rectangle(m_unfilledRegionStartX, UNFILLED_RERION_START_Y, m_cuttedImage.Width, m_cuttedImage.Height), GraphicsUnit.Pixel);
            }
        }

        private void picBoard_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Pixel;

            //图片尺寸：400*300，DPI：96
            e.Graphics.DrawImageUnscaled(UserValidationOfFillingImage.Properties.Resources.hehua, DISTANCE_FROM_SIDE_X, DISTANCE_FROM_SIDE_Y);
            
            System.Drawing.Drawing2D.GraphicsContainer gc = e.Graphics.BeginContainer();
            try
            {
                e.Graphics.FillRectangle(Brushes.Orange, m_dragRegion);
                e.Graphics.TranslateTransform(DISTANCE_FROM_SIDE_X + m_unfilledRegionStartX, DISTANCE_FROM_SIDE_Y + UNFILLED_RERION_START_Y);
                e.Graphics.FillPath(Brushes.Red, m_unfilledRegion.ClipRegion);
            }
            finally
            {
                e.Graphics.EndContainer(gc);
            }

            e.Graphics.DrawImageUnscaled(m_cuttedImage, m_dragRegion.X, DISTANCE_FROM_SIDE_Y + UNFILLED_RERION_START_Y);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            InitUnfilledRegionStartX();
            ResetCuttedImage();
            ResetDragRegion();
            this.picBoard.Refresh();
        }

        private void picBoard_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = m_dragRegion.Contains(e.Location) ? Cursors.Hand : Cursors.Default;

            if (m_isDraging)
            {
                int newXPos = CUTTED_IMAGE_START_X + e.X - m_originPos.X;
                if (newXPos <= 0)
                {
                    newXPos = 0;
                }
                else if (newXPos + m_dragRegion.Width > picBoard.Width)
                {
                    newXPos = picBoard.Width - m_dragRegion.Width;
                }

                m_dragRegion.X = newXPos;

                picBoard.Refresh();
            }
        }

        private bool m_isDraging = false;
        private Point m_originPos = new Point(0, 0);
        private void picBoard_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && m_dragRegion.Contains(e.Location))
            {
                m_isDraging = true;
                m_originPos.X = e.X;
                m_originPos.Y = e.Y;
            }
        }

        private void picBoard_MouseUp(object sender, MouseEventArgs e)
        {
            if (!m_isDraging)
            {
                return;
            }

            m_isDraging = false;

            if (Math.Abs(DISTANCE_FROM_SIDE_X + m_unfilledRegionStartX - m_dragRegion.X) < 1)
            {
                MessageBox.Show("验证成功");
            }
            else
            {
                MessageBox.Show("验证失败");
            }

            ResetDragRegion();
            this.picBoard.Refresh();
        }
    }
}
