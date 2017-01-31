//   - Blaster Master Class -
// Purpose:      Enemy bullets
// Rev:          1.0
// Last updated: 22/03/10

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace BlasterMaster
{
    public class clsInvaderBullet : clsCommon
    {

        // Obj refs and instances
        private System.Drawing.Bitmap bullet;
        private ImageAttributes ImagingAtt = new ImageAttributes();

        //------------------------------------------------------------------------------------------------------------------
        // Purpose: Class constructor  
        //------------------------------------------------------------------------------------------------------------------

        // Call to super / base class
        public clsInvaderBullet(int x, int y): base(x, y, 12, 32)
        {

            // Load resource image(s) & remove background and thu a sprite is born
            bullet = BlasterMaster.Properties.Resources.enemyBullet;
            bullet.MakeTransparent(Color.White);

        }

        public void moveBullets(Graphics Destination)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Method to move the invaders bullets by 5 pixels every frame   
            //------------------------------------------------------------------------------------------------------------------

            // Move bullets
            base.setY(base.getY() + 5);

            // Sync collsion rect
            base.setRectX(base.getX() + 2);
            base.setRectY(base.getY() + 2);
            base.setRectW(base.getW() - 5);
            base.setRectH(base.getH() - 5);

            // Render them
            this.Draw(Destination);

        }

        private void Draw(Graphics Destination)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Method to render the invader's bullets 
            //------------------------------------------------------------------------------------------------------------------

            // Draw sprite
            Destination.DrawImage(bullet, new Rectangle(base.getX(), base.getY(), base.getW(), base.getH()), 0, 0, base.getW(), base.getH(), GraphicsUnit.Pixel, ImagingAtt);

        }

    }

}
