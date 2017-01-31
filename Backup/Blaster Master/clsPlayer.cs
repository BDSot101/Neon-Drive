//   - Blaster Master Class -
// Purpose:      Player's ship
// Rev:          1.0
// Last updated: 22/03/10

using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace BlasterMaster
{ 
    public class clsPlayer : clsCommon
    {

        // Obj refs and instances
        private System.Drawing.Bitmap[] player = new System.Drawing.Bitmap[2];
        private System.Drawing.Bitmap[] playerSheild = new System.Drawing.Bitmap[2];
        private System.Drawing.Bitmap[] explosion = new System.Drawing.Bitmap[6];
        private ImageAttributes ImagingAtt = new ImageAttributes();
        private Rectangle sheildRect = new Rectangle();
        private clsTScales tScales = new clsTScales();
        
        // Properties for this class 
        private int[] pivotX = new int[129];
        private int[] pivotY = new int[129];
        private int firePower;
        private int sheildTime;
        private int x3FireAmmo;
        private int x5FireAmmo;
        private int sheildX;
        private int sheildY;
        private int playerAni;
        private int sheildAni;
        private int warpW;
        private int warpH;
        private bool sheild;
        private bool warp;
        private bool dead;

        public clsPlayer(int x, int y): base(x, y, 0, 0)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Class constructor  
            //------------------------------------------------------------------------------------------------------------------

            //:: Load resource image(s) & remove background and thu a sprite is born ::

            // Player images
            player[0] = BlasterMaster.Properties.Resources.playerA;
            player[1] = BlasterMaster.Properties.Resources.playerB;

            // Explosion images
            explosion[0] = BlasterMaster.Properties.Resources.explosion5;
            explosion[1] = BlasterMaster.Properties.Resources.explosion4;
            explosion[2] = BlasterMaster.Properties.Resources.explosion3;
            explosion[3] = BlasterMaster.Properties.Resources.explosion2;
            explosion[4] = BlasterMaster.Properties.Resources.explosion1;

            // Sheild pickup ...
            playerSheild[0] = BlasterMaster.Properties.Resources.sheildA;
            playerSheild[1] = BlasterMaster.Properties.Resources.sheildB;

            // Remove backgrounds
            player[0].MakeTransparent(Color.White);
            player[1].MakeTransparent(Color.White);
            playerSheild[0].MakeTransparent(Color.Red);
            playerSheild[1].MakeTransparent(Color.Red);

            for (int i = 0; i <= 4; i++)
            {
                explosion[i].MakeTransparent(Color.White);
            }

            // Load piviot dat
            this.loadPivotDat();
        }

        public bool isDead()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (is the player dead?)  
            //------------------------------------------------------------------------------------------------------------------

            return this.dead;
        }

        public void setPlayerDead(bool dead)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Mutator (set player dead or alive)  
            //------------------------------------------------------------------------------------------------------------------

            this.dead = dead;
        }

        public bool isDoingWarp()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (player doing warp?)  
            //------------------------------------------------------------------------------------------------------------------

            return this.warp;
        }

        public void setDoWarp(bool warp)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Mutator (set player doing end of level warp) 
            //------------------------------------------------------------------------------------------------------------------

            this.warp = warp;
        }

        public void setWarpW(int w)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Mutator (set warp width) 
            //------------------------------------------------------------------------------------------------------------------

            this.warpW = w;
        }

        public void setWarpH(int h)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Mutator (height) 
            //------------------------------------------------------------------------------------------------------------------

            this.warpH = h;
        }

        public int getWarpW()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (fetch warp width)  
            //------------------------------------------------------------------------------------------------------------------

            return this.warpW;
        }

        public int getWarpH()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (height)  
            //------------------------------------------------------------------------------------------------------------------

            return this.warpH;
        }

        public void setFirePower(int firePower)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Mutator (set player's level of fire power)  
            //------------------------------------------------------------------------------------------------------------------

            this.firePower = firePower;
        }

        public int getFirePowerLevel()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (fetch player's level of fire power)  
            //------------------------------------------------------------------------------------------------------------------

            return this.firePower;
        }

        public bool hasSheild()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (has the player got the sheild pickup?)  
            //------------------------------------------------------------------------------------------------------------------

            return this.sheild;
        }

        public void setSheild(bool sheild)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Mutator (set player with / without sheild)  
            //------------------------------------------------------------------------------------------------------------------

            this.sheild = sheild;
        }

        public void setSheildTime(int sheildTime)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Mutator (set player's time with having a sheild)  
            //------------------------------------------------------------------------------------------------------------------

            this.sheildTime = sheildTime;
        }

        public int getSheildTime()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (fetch the amount of time that the player has had a sheild for)  
            //------------------------------------------------------------------------------------------------------------------

            return this.sheildTime;
        }

        public void setX3FireAmmo(int x3FireAmmo)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Mutator (set player's num of bullets remaining with this weapon)  
            //------------------------------------------------------------------------------------------------------------------

            this.x3FireAmmo = x3FireAmmo;
        }

        public int getX3FireAmmo()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (fetch ammo remaining with this weapon)  
            //------------------------------------------------------------------------------------------------------------------

            return this.x3FireAmmo;
        }

        public void setX5FireAmmo(int x5FireAmmo)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Mutator (set player's num of bullets remaining with this weapon)    
            //------------------------------------------------------------------------------------------------------------------

            this.x5FireAmmo = x5FireAmmo;
        }

        public int getX5FireAmmo()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (fetch ammo remaining with this weapon)  
            //------------------------------------------------------------------------------------------------------------------

            return this.x5FireAmmo;
        }

        public void setSheildX(int X)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Mutator (set sheild location x)  
            //------------------------------------------------------------------------------------------------------------------

            this.sheildX = X;
        }

        public void setSheildY(int Y)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Mutator (location y)  
            //------------------------------------------------------------------------------------------------------------------

            this.sheildY = Y;
        }

        public int getSheildX()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (fetch x)  
            //------------------------------------------------------------------------------------------------------------------

            return this.sheildX;
        }

        public int getSheildY()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (fetch y) 
            //------------------------------------------------------------------------------------------------------------------

            return this.sheildY;
        }

        public void setSheildRectX(int X)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Mutator (set collision rect x)   
            //------------------------------------------------------------------------------------------------------------------

            this.sheildRect.X = X;
        }

        public void setSheildRectY(int Y)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Mutator (set collision rect y)    
            //------------------------------------------------------------------------------------------------------------------

            this.sheildRect.Y = Y;
        }

        public void setSheildRectH(int H)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Mutator (set collision rect height)    
            //------------------------------------------------------------------------------------------------------------------

            this.sheildRect.Height = H;
        }

        public void setSheildRectW(int W)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Mutator (width)   
            //------------------------------------------------------------------------------------------------------------------

            this.sheildRect.Width = W;
        }

        public int getSheildRectX()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (fetch collision rect x)  
            //------------------------------------------------------------------------------------------------------------------

            return this.sheildRect.X;
        }

        public int getSheildRectY()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (y)   
            //------------------------------------------------------------------------------------------------------------------

            return this.sheildRect.Y;
        }

        public int getSheildRectW()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (fetch collision rect width)   
            //------------------------------------------------------------------------------------------------------------------

            return this.sheildRect.Width;
        }

        public int getSheildRectH()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (height)   
            //------------------------------------------------------------------------------------------------------------------

            return this.sheildRect.Height;
        }

        public int getPivotX(int index)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (fetch player x axis to pivot on) 
            //------------------------------------------------------------------------------------------------------------------

            return this.pivotX[index];
        }

        public int getPivotY(int index)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (fetch player y axis to pivot on)   
            //------------------------------------------------------------------------------------------------------------------

            return this.pivotY[index];
        }

        public void Draw(Graphics Destination, bool doExplosion, int enabled)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: method to draw player's sprite and sync collision rect  
            //------------------------------------------------------------------------------------------------------------------

            if (enabled == 0)
            {
                // Inc time scalers
                tScales.setTScaleB(tScales.getTAcaleB() + 1);
                tScales.setTScaleB(tScales.getTAcaleB() % 10);

                // Animate player / explosions
                if (tScales.getTAcaleB() == 0)
                {
                    playerAni += 1;
                }

                // Either do explsion graphics or draw player's ship
                if (doExplosion == true)
                {
                    // Draw exposion sprites ...
                    playerAni = playerAni % 5;
                    Destination.DrawImage(explosion[playerAni], new Rectangle(base.getX() + Convert.ToInt32((base.getRectW() / 2) - (explosion[playerAni].Width / 2)), base.getY() + 15, explosion[playerAni].Width, explosion[playerAni].Height), 0, 0, explosion[playerAni].Width, explosion[playerAni].Height, GraphicsUnit.Pixel, ImagingAtt);

                }
                else //- Draw the player's ship -
                {
                    // Animate & render ...
                    playerAni = playerAni % 2;
                    Destination.DrawImage(player[playerAni], new Rectangle(base.getX(), base.getY(), player[playerAni].Width - this.warpW, player[playerAni].Height - this.warpH), 0, 0, player[playerAni].Width, player[playerAni].Height, GraphicsUnit.Pixel, ImagingAtt);

                    // Sync collision rect with player's ship
                    base.setRectW(player[1].Width - 5);
                    base.setRectH(player[1].Height - 20);
                    base.setRectX(base.getX() + 2);
                    base.setRectY(base.getY() + 20);

                    // Sheild?
                    if (this.hasSheild())
                    {
                        // Animate player's sheild
                        if (tScales.getTAcaleB() == 0)
                        {
                            sheildAni += 1;
                            sheildAni = sheildAni % 2;
                        }

                        // Apply x & y
                        this.setSheildX(base.getX() - 8);
                        this.setSheildY(base.getY() - 20);

                        // Render sheild to graphics buffer ...
                        Destination.DrawImage(playerSheild[sheildAni], new Rectangle(this.getSheildX(), this.getSheildY(), playerSheild[sheildAni].Width, playerSheild[sheildAni].Height), 0, 0, playerSheild[sheildAni].Width, playerSheild[sheildAni].Height, GraphicsUnit.Pixel, ImagingAtt);

                        // Sync collision rect with player's sheild
                        this.setSheildRectX(this.getSheildX());
                        this.setSheildRectY(this.getSheildY());
                        this.setSheildRectW(this.playerSheild[sheildAni].Width);
                        this.setSheildRectH(this.playerSheild[sheildAni].Height);

                    }
                }
            }
        }       

        private void loadPivotDat()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Method to load piviot data   
            //------------------------------------------------------------------------------------------------------------------

            pivotX[0] = 570;
            pivotY[0] = 434;
            pivotX[1] = 569;
            pivotY[1] = 437;
            pivotX[2] = 567;
            pivotY[2] = 441;
            pivotX[3] = 565;
            pivotY[3] = 445;
            pivotX[4] = 564;
            pivotY[4] = 449;
            pivotX[5] = 561;
            pivotY[5] = 452;
            pivotX[6] = 559;
            pivotY[6] = 456;
            pivotX[7] = 557;
            pivotY[7] = 460;
            pivotX[8] = 555;
            pivotY[8] = 463;
            pivotX[9] = 552;
            pivotY[9] = 467;
            pivotX[10] = 550;
            pivotY[10] = 470;
            pivotX[11] = 547;
            pivotY[11] = 474;
            pivotX[12] = 544;
            pivotY[12] = 477;
            pivotX[13] = 541;
            pivotY[13] = 481;
            pivotX[14] = 538;
            pivotY[14] = 484;
            pivotX[15] = 535;
            pivotY[15] = 487;
            pivotX[16] = 531;
            pivotY[16] = 491;
            pivotX[17] = 528;
            pivotY[17] = 494;
            pivotX[18] = 525;
            pivotY[18] = 497;
            pivotX[19] = 521;
            pivotY[19] = 500;
            pivotX[19] = 517;
            pivotY[20] = 503;
            pivotX[20] = 514;
            pivotY[21] = 507;
            pivotX[21] = 510;
            pivotY[22] = 510;
            pivotX[22] = 506;
            pivotY[23] = 512;
            pivotX[23] = 502;
            pivotY[24] = 515;
            pivotX[24] = 497;
            pivotY[25] = 518;
            pivotX[25] = 493;
            pivotY[26] = 521;
            pivotX[26] = 489;
            pivotY[27] = 524;
            pivotX[27] = 484;
            pivotY[28] = 526;
            pivotX[28] = 480;
            pivotY[29] = 529;
            pivotX[29] = 475;
            pivotY[30] = 531;
            pivotX[30] = 471;
            pivotY[31] = 534;
            pivotX[31] = 466;
            pivotY[32] = 536;
            pivotX[32] = 461;
            pivotY[33] = 539;
            pivotX[33] = 456;
            pivotY[34] = 541;
            pivotX[34] = 451;
            pivotY[35] = 543;
            pivotX[35] = 446;
            pivotY[36] = 545;
            pivotX[36] = 441;
            pivotY[37] = 547;
            pivotX[37] = 436;
            pivotY[38] = 549;
            pivotX[38] = 431;
            pivotY[39] = 551;
            pivotX[39] = 425;
            pivotY[40] = 553;
            pivotX[40] = 420;
            pivotY[41] = 555;
            pivotX[41] = 414;
            pivotY[42] = 557;
            pivotX[42] = 409;
            pivotY[43] = 558;
            pivotX[43] = 403;
            pivotY[44] = 560;
            pivotX[44] = 398;
            pivotY[45] = 561;
            pivotX[45] = 392;
            pivotY[46] = 563;
            pivotX[46] = 387;
            pivotY[47] = 564;
            pivotX[47] = 381;
            pivotY[48] = 565;
            pivotX[48] = 375;
            pivotY[49] = 566;
            pivotX[49] = 369;
            pivotY[50] = 568;
            pivotX[50] = 363;
            pivotY[51] = 569;
            pivotX[51] = 358;
            pivotY[52] = 570;
            pivotX[52] = 352;
            pivotY[53] = 570;
            pivotX[53] = 346;
            pivotY[54] = 571;
            pivotX[54] = 340;
            pivotY[55] = 572;
            pivotX[55] = 334;
            pivotY[56] = 572;
            pivotX[56] = 328;
            pivotY[57] = 573;
            pivotX[57] = 322;
            pivotY[58] = 573;
            pivotX[58] = 316;
            pivotY[59] = 574;
            pivotX[59] = 310;
            pivotY[60] = 574;
            pivotX[60] = 304;
            pivotY[61] = 574;
            pivotX[61] = 298;
            pivotY[62] = 574;
            pivotX[62] = 292;
            pivotY[63] = 575;
            pivotX[63] = 286;
            pivotY[64] = 574;
            pivotX[64] = 280;
            pivotY[65] = 574;
            pivotX[65] = 274;
            pivotY[66] = 574;
            pivotX[66] = 268;
            pivotY[67] = 574;
            pivotX[67] = 262;
            pivotY[68] = 573;
            pivotX[68] = 256;
            pivotY[69] = 573;
            pivotX[69] = 250;
            pivotY[70] = 572;
            pivotX[70] = 244;
            pivotY[71] = 572;
            pivotX[71] = 238;
            pivotY[72] = 571;
            pivotX[72] = 232;
            pivotY[73] = 570;
            pivotX[73] = 226;
            pivotY[74] = 570;
            pivotX[74] = 221;
            pivotY[75] = 569;
            pivotX[75] = 215;
            pivotY[76] = 568;
            pivotX[76] = 209;
            pivotY[77] = 566;
            pivotX[77] = 203;
            pivotY[78] = 565;
            pivotX[78] = 197;
            pivotY[79] = 564;
            pivotX[79] = 192;
            pivotY[80] = 563;
            pivotX[80] = 186;
            pivotY[81] = 561;
            pivotX[81] = 181;
            pivotY[82] = 560;
            pivotX[82] = 175;
            pivotY[83] = 558;
            pivotX[83] = 170;
            pivotY[84] = 557;
            pivotX[84] = 164;
            pivotY[85] = 555;
            pivotX[85] = 159;
            pivotY[86] = 553;
            pivotX[86] = 153;
            pivotY[87] = 551;
            pivotX[87] = 148;
            pivotY[88] = 549;
            pivotX[88] = 143;
            pivotY[89] = 547;
            pivotX[89] = 138;
            pivotY[90] = 545;
            pivotX[90] = 133;
            pivotY[91] = 543;
            pivotX[91] = 128;
            pivotY[92] = 541;
            pivotX[92] = 123;
            pivotY[93] = 539;
            pivotX[93] = 118;
            pivotY[94] = 536;
            pivotX[94] = 113;
            pivotY[95] = 534;
            pivotX[95] = 109;
            pivotY[96] = 531;
            pivotX[96] = 104;
            pivotY[97] = 529;
            pivotX[97] = 100;
            pivotY[98] = 526;
            pivotX[98] = 95;
            pivotY[99] = 524;
            pivotX[99] = 91;
            pivotY[100] = 521;
            pivotX[100] = 87;
            pivotY[101] = 518;
            pivotX[101] = 82;
            pivotY[102] = 515;
            pivotX[102] = 78;
            pivotY[103] = 512;
            pivotX[103] = 74;
            pivotY[104] = 510;
            pivotX[104] = 70;
            pivotY[105] = 507;
            pivotX[105] = 67;
            pivotY[106] = 503;
            pivotX[106] = 63;
            pivotY[107] = 500;
            pivotX[107] = 59;
            pivotY[108] = 497;
            pivotX[108] = 56;
            pivotY[109] = 494;
            pivotX[109] = 53;
            pivotY[110] = 491;
            pivotX[110] = 49;
            pivotY[111] = 487;
            pivotX[111] = 46;
            pivotY[112] = 484;
            pivotX[112] = 43;
            pivotY[113] = 481;
            pivotX[113] = 40;
            pivotY[114] = 477;
            pivotX[114] = 37;
            pivotY[115] = 474;
            pivotX[115] = 34;
            pivotY[116] = 470;
            pivotX[116] = 32;
            pivotY[117] = 467;
            pivotX[117] = 29;
            pivotY[117] = 463;
            pivotX[118] = 27;
            pivotY[118] = 460;
            pivotX[119] = 25;
            pivotY[119] = 456;
            pivotX[120] = 23;
            pivotY[120] = 452;
            pivotX[121] = 20;
            pivotY[121] = 449;

        }
    }
}
