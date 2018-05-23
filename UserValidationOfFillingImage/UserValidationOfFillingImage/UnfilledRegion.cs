using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace UserValidationOfFillingImage
{
    public class UnfilledRegion
    {
        private GraphicsPath m_clipRegion = new GraphicsPath();

        private const int RECT_WIDTH = 50;
        private const int RECT_HEIGHT = 30;
        private const int ARC_RADIUS = 5;
        
        private void InitGraphicsPath()
        {
            m_clipRegion.FillMode= FillMode.Winding;

            m_clipRegion.AddLine(ARC_RADIUS, 0, ARC_RADIUS + RECT_WIDTH, 0);
            m_clipRegion.AddLine(ARC_RADIUS + RECT_WIDTH, 0, ARC_RADIUS + RECT_WIDTH, RECT_HEIGHT / 2 - ARC_RADIUS);                      
            m_clipRegion.AddArc(RECT_WIDTH, 10, ARC_RADIUS * 2, ARC_RADIUS * 2, -90, 90);           
            m_clipRegion.AddLine(ARC_RADIUS + RECT_WIDTH, RECT_HEIGHT / 2 + ARC_RADIUS, ARC_RADIUS + RECT_WIDTH, RECT_HEIGHT);
            m_clipRegion.AddLine(ARC_RADIUS + RECT_WIDTH, RECT_HEIGHT, ARC_RADIUS, RECT_HEIGHT);
            m_clipRegion.AddLine(ARC_RADIUS, RECT_HEIGHT, ARC_RADIUS, RECT_HEIGHT / 2 + ARC_RADIUS);
            m_clipRegion.AddArc(0, 10, ARC_RADIUS * 2, ARC_RADIUS * 2, 90, 270);            
            m_clipRegion.AddLine(ARC_RADIUS, RECT_HEIGHT / 2 - ARC_RADIUS, ARC_RADIUS, 0);
        }

        public UnfilledRegion()
        {
            InitGraphicsPath();
        }

        public int RegionWidth
        {
            get
            {
                return ARC_RADIUS + ARC_RADIUS + RECT_WIDTH;
            }
        }

        public int RegionHeight
        {
            get
            {
                return RECT_HEIGHT;
            }
        }

        public GraphicsPath ClipRegion
        {
            get
            {
                return m_clipRegion;
            }
        }
    }

}
