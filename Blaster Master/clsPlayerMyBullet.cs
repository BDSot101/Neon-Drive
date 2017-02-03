using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace BlasterMaster
{
    class clsPlayerMyBullet : clsPlayerBullet
    {
        // Obj refs and instances
        private System.Drawing.Bitmap bullet;
        private ImageAttributes ImagingAtt = new ImageAttributes();
        private int m_position;

        public clsPlayerMyBullet(int x, int y, int i): base(x, y)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Class constructor  
            //------------------------------------------------------------------------------------------------------------------

            // Load resource image(s) & remove background and thu a sprite is born 
            bullet = BlasterMaster.Properties.Resources.playerMyBullet;
            bullet.MakeTransparent(Color.White);
            m_position = i;
        }

        public override void moveBullets(Graphics Destination)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Method to move the player's bullets by 16 pixels every frame  
            //------------------------------------------------------------------------------------------------------------------

            // Scroll bullets
            base.setY(base.getY() - 15);
            if (m_position == 2)
            {
                base.setX(base.getX() - 3);
            }
            else
            {
                if (m_position == 3)
                {
                    base.setX(base.getX() + 3);
                }
                else
                {
                    if (m_position == 4)
                    {
                        base.setX(base.getX() - 5);
                    }
                    else
                    {
                        if (m_position == 5)
                        {
                            base.setX(base.getX() + 5);
                        }
                    }
                }
            }

            // Sync collision rect
            base.setRectX(base.getX() + 2);
            base.setRectY(base.getY());
            base.setRectW(base.getW() - 5);
            base.setRectH(base.getH());

            // call to render
            this.Draw(Destination);
        }

        private void Draw(Graphics Destination)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Method to render the player's sprite  
            //------------------------------------------------------------------------------------------------------------------

            // Draw sprite
            Destination.DrawImage(bullet, new Rectangle(base.getX(), base.getY(), base.getW(), base.getH()), 0, 0, base.getW(), base.getH(), GraphicsUnit.Pixel, ImagingAtt);
        }
    }
}
