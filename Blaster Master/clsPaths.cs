﻿//   - Blaster Master Class -
// Purpose:      Enemy paths to follow
// Rev:          1.0
// Last updated: 22/03/10

using System;

namespace BlasterMaster
{
    public class clsPaths
    {

        // Properties for this class
        private int[] leftEntryX = new int[76];
        private int[] leftEntryY = new int[76];
        private int[] rightEntryX = new int[76];
        private int[] rightEntryY = new int[76];

        public clsPaths()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Class constructor  
            //------------------------------------------------------------------------------------------------------------------

		    // Set properties
		    this.loadPointDat();
        }

        public int getLeftPointEntryX(int index)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (fetch path x axis] 
            //------------------------------------------------------------------------------------------------------------------

            return this.leftEntryX[index];
        }

        public int getLeftPointEntryY(int index)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (fetch path y axis]  
            //------------------------------------------------------------------------------------------------------------------

            return this.leftEntryY[index];
        }

        public int getRightPointEntryX(int index)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (fetch path x axis] 
            //------------------------------------------------------------------------------------------------------------------

            return this.rightEntryX[index];
        }

        public int getRightPointEntryY(int index)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Accessor (fetch path y axis] 
            //------------------------------------------------------------------------------------------------------------------

            return this.rightEntryY[index];
        }

        public void loadPointDat()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Method to load path data  
            //------------------------------------------------------------------------------------------------------------------

            /*
            leftEntryX[0] = 276;
            leftEntryY[0] = 278;
            leftEntryX[1] = 277;
            leftEntryY[1] = 282;
            leftEntryX[2] = 278;
            leftEntryY[2] = 287;
            leftEntryX[3] = 279;
            leftEntryY[3] = 292;
            leftEntryX[4] = 279;
            leftEntryY[4] = 297;
            leftEntryX[5] = 279;
            leftEntryY[5] = 302;
            leftEntryX[6] = 279;
            leftEntryY[6] = 307;
            leftEntryX[7] = 279;
            leftEntryY[7] = 312;
            leftEntryX[8] = 279;
            leftEntryY[8] = 317;
            leftEntryX[9] = 279;
            leftEntryY[9] = 322;
            leftEntryX[10] = 279;
            leftEntryY[10] = 327;
            leftEntryX[11] = 278;
            leftEntryY[11] = 332;
            leftEntryX[12] = 277;
            leftEntryY[12] = 337;
            leftEntryX[13] = 276;
            leftEntryY[13] = 341;
            leftEntryX[14] = 275;
            leftEntryY[14] = 346;
            leftEntryX[15] = 274;
            leftEntryY[15] = 351;
            leftEntryX[16] = 273;
            leftEntryY[16] = 356;
            leftEntryX[17] = 271;
            leftEntryY[17] = 361;
            leftEntryX[18] = 270;
            leftEntryY[18] = 365;
            leftEntryX[19] = 268;
            leftEntryY[19] = 370;
            leftEntryX[20] = 266;
            leftEntryY[20] = 375;
            leftEntryX[21] = 264;
            leftEntryY[21] = 379;
            leftEntryX[22] = 261;
            leftEntryY[22] = 384;
            leftEntryX[23] = 259;
            leftEntryY[23] = 389;
            leftEntryX[24] = 257;
            leftEntryY[24] = 393;
            leftEntryX[25] = 254;
            leftEntryY[25] = 398;
            leftEntryX[26] = 251;
            leftEntryY[26] = 402;
            leftEntryX[27] = 248;
            leftEntryY[27] = 406;
            leftEntryX[28] = 245;
            leftEntryY[28] = 411;
            leftEntryX[29] = 242;
            leftEntryY[29] = 415;
            leftEntryX[30] = 239;
            leftEntryY[30] = 419;
            leftEntryX[31] = 235;
            leftEntryY[31] = 423;
            leftEntryX[32] = 232;
            leftEntryY[32] = 427;
            leftEntryX[33] = 228;
            leftEntryY[33] = 431;
            leftEntryX[34] = 224;
            leftEntryY[34] = 435;
            leftEntryX[35] = 220;
            leftEntryY[35] = 439;
            leftEntryX[36] = 216;
            leftEntryY[36] = 442;
            leftEntryX[37] = 212;
            leftEntryY[37] = 446;
            leftEntryX[38] = 208;
            leftEntryY[38] = 450;
            leftEntryX[39] = 204;
            leftEntryY[39] = 453;
            leftEntryX[40] = 199;
            leftEntryY[40] = 456;
            leftEntryX[41] = 194;
            leftEntryY[41] = 460;
            leftEntryX[42] = 190;
            leftEntryY[42] = 463;
            leftEntryX[43] = 185;
            leftEntryY[43] = 466;
            leftEntryX[44] = 180;
            leftEntryY[44] = 469;
            leftEntryX[45] = 175;
            leftEntryY[45] = 472;
            leftEntryX[46] = 170;
            leftEntryY[46] = 475;
            leftEntryX[47] = 165;
            leftEntryY[47] = 478;
            leftEntryX[48] = 160;
            leftEntryY[48] = 480;
            leftEntryX[49] = 155;
            leftEntryY[49] = 483;
            leftEntryX[50] = 149;
            leftEntryY[50] = 485;
            leftEntryX[51] = 144;
            leftEntryY[51] = 487;
            leftEntryX[52] = 138;
            leftEntryY[52] = 490;
            leftEntryX[53] = 133;
            leftEntryY[53] = 492;
            leftEntryX[54] = 127;
            leftEntryY[54] = 494;
            leftEntryX[55] = 121;
            leftEntryY[55] = 496;
            leftEntryX[56] = 115;
            leftEntryY[56] = 497;
            leftEntryX[57] = 110;
            leftEntryY[57] = 499;
            leftEntryX[58] = 104;
            leftEntryY[58] = 500;
            leftEntryX[59] = 98;
            leftEntryY[59] = 502;
            leftEntryX[60] = 92;
            leftEntryY[60] = 503;
            leftEntryX[61] = 86;
            leftEntryY[61] = 504;
            leftEntryX[62] = 80;
            leftEntryY[62] = 505;
            leftEntryX[63] = 74;
            leftEntryY[63] = 506;
            leftEntryX[64] = 68;
            leftEntryY[64] = 507;
            leftEntryX[65] = 62;
            leftEntryY[65] = 508;
            leftEntryX[66] = 56;
            leftEntryY[66] = 508;
            leftEntryX[67] = 49;
            leftEntryY[67] = 509;
            leftEntryX[68] = 43;
            leftEntryY[68] = 509;
            leftEntryX[69] = 37;
            leftEntryY[69] = 509;
            leftEntryX[70] = 31;
            leftEntryY[70] = 509;
            leftEntryX[71] = 25;
            leftEntryY[71] = 509;
            leftEntryX[72] = 19;
            leftEntryY[72] = 509;
            leftEntryX[73] = 13;
            leftEntryY[73] = 509;
            */

            leftEntryX[0] = 276;
            leftEntryX[1] = 277;
            leftEntryX[2] = 278;
            leftEntryX[3] = 279;
            leftEntryX[4] = 279;
            leftEntryX[5] = 279;
            leftEntryX[6] = 279;
            leftEntryX[7] = 279;
            leftEntryX[8] = 279;
            leftEntryX[9] = 279;
            leftEntryX[10] = 279;
            leftEntryX[11] = 278;
            leftEntryX[12] = 277;
            leftEntryX[13] = 276;
            leftEntryX[14] = 275;
            leftEntryX[15] = 274;
            leftEntryX[16] = 273;
            leftEntryX[17] = 271;
            leftEntryX[18] = 270;
            leftEntryX[19] = 268;
            leftEntryX[20] = 266;
            leftEntryX[21] = 264;
            leftEntryX[22] = 261;
            leftEntryX[23] = 259;
            leftEntryX[24] = 257;
            leftEntryX[25] = 254;
            leftEntryX[26] = 251;
            leftEntryX[27] = 248;
            leftEntryX[28] = 245;
            leftEntryX[29] = 242;
            leftEntryX[30] = 239;
            leftEntryX[31] = 235;
            leftEntryX[32] = 232;
            leftEntryX[33] = 228;
            leftEntryX[34] = 224;
            leftEntryX[35] = 220;
            leftEntryX[36] = 216;
            leftEntryX[37] = 212;
            leftEntryX[38] = 208;
            leftEntryX[39] = 204;
            leftEntryX[40] = 199;
            leftEntryX[41] = 194;
            leftEntryX[42] = 190;
            leftEntryX[43] = 185;
            leftEntryX[44] = 180;
            leftEntryX[45] = 175;
            leftEntryX[46] = 170;
            leftEntryX[47] = 165;
            leftEntryX[48] = 160;
            leftEntryX[49] = 155;
            leftEntryX[50] = 149;
            leftEntryX[51] = 144;
            leftEntryX[52] = 138;
            leftEntryX[53] = 133;
            leftEntryX[54] = 127;
            leftEntryX[55] = 121;
            leftEntryX[56] = 115;
            leftEntryX[57] = 110;
            leftEntryX[58] = 104;
            leftEntryX[59] = 98;
            leftEntryX[60] = 92;
            leftEntryX[61] = 86;
            leftEntryX[62] = 80;
            leftEntryX[63] = 74;
            leftEntryX[64] = 68;
            leftEntryX[65] = 62;
            leftEntryX[66] = 56;
            leftEntryX[67] = 49;
            leftEntryX[68] = 43;
            leftEntryX[69] = 37;
            leftEntryX[70] = 31;
            leftEntryX[71] = 25;
            leftEntryX[72] = 19;
            leftEntryX[73] = 13;
            rightEntryY[0] = 506;
            rightEntryY[1] = 507;
            rightEntryY[2] = 508;
            rightEntryY[3] = 508;
            rightEntryY[4] = 509;
            rightEntryY[5] = 509;
            rightEntryY[6] = 509;
            rightEntryY[7] = 509;
            rightEntryY[8] = 509;
            rightEntryY[9] = 509;
            rightEntryY[10] = 509;
            rightEntryY[11] = 509;
            rightEntryY[12] = 508;
            rightEntryY[13] = 507;
            rightEntryY[14] = 507;
            rightEntryY[15] = 506;
            rightEntryY[16] = 505;
            rightEntryY[17] = 504;
            rightEntryY[18] = 503;
            rightEntryY[19] = 501;
            rightEntryY[20] = 500;
            rightEntryY[21] = 498;
            rightEntryY[22] = 496;
            rightEntryY[23] = 495;
            rightEntryY[24] = 493;
            rightEntryY[25] = 491;
            rightEntryY[26] = 489;
            rightEntryY[27] = 486;
            rightEntryY[28] = 484;
            rightEntryY[29] = 481;
            rightEntryY[30] = 479;
            rightEntryY[31] = 476;
            rightEntryY[32] = 473;
            rightEntryY[33] = 471;
            rightEntryY[34] = 468;
            rightEntryY[35] = 465;
            rightEntryY[36] = 461;
            rightEntryY[37] = 458;
            rightEntryY[38] = 455;
            rightEntryY[39] = 451;
            rightEntryY[40] = 448;
            rightEntryY[41] = 444;
            rightEntryY[42] = 441;
            rightEntryY[43] = 437;
            rightEntryY[44] = 433;
            rightEntryY[45] = 429;
            rightEntryY[46] = 425;
            rightEntryY[47] = 421;
            rightEntryY[48] = 417;
            rightEntryY[49] = 413;
            rightEntryY[50] = 408;
            rightEntryY[51] = 404;
            rightEntryY[52] = 400;
            rightEntryY[53] = 395;
            rightEntryY[54] = 391;
            rightEntryY[55] = 386;
            rightEntryY[56] = 382;
            rightEntryY[57] = 377;
            rightEntryY[58] = 372;
            rightEntryY[59] = 368;
            rightEntryY[60] = 363;
            rightEntryY[61] = 358;
            rightEntryY[62] = 353;
            rightEntryY[63] = 349;
            rightEntryY[64] = 344;
            rightEntryY[65] = 339;
            rightEntryY[66] = 334;
            rightEntryY[67] = 329;
            rightEntryY[68] = 324;
            rightEntryY[69] = 319;
            rightEntryY[70] = 314;
            rightEntryY[71] = 310;
            rightEntryY[72] = 305;
            rightEntryY[73] = 300;

            rightEntryX[0] = 594;
            rightEntryY[0] = 506;
            rightEntryX[1] = 588;
            rightEntryY[1] = 507;
            rightEntryX[2] = 582;
            rightEntryY[2] = 508;
            rightEntryX[3] = 576;
            rightEntryY[3] = 508;
            rightEntryX[4] = 569;
            rightEntryY[4] = 509;
            rightEntryX[5] = 563;
            rightEntryY[5] = 509;
            rightEntryX[6] = 557;
            rightEntryY[6] = 509;
            rightEntryX[7] = 551;
            rightEntryY[7] = 509;
            rightEntryX[8] = 545;
            rightEntryY[8] = 509;
            rightEntryX[9] = 539;
            rightEntryY[9] = 509;
            rightEntryX[10] = 533;
            rightEntryY[10] = 509;
            rightEntryX[11] = 526;
            rightEntryY[11] = 509;
            rightEntryX[12] = 520;
            rightEntryY[12] = 508;
            rightEntryX[13] = 514;
            rightEntryY[13] = 507;
            rightEntryX[14] = 508;
            rightEntryY[14] = 507;
            rightEntryX[15] = 502;
            rightEntryY[15] = 506;
            rightEntryX[16] = 496;
            rightEntryY[16] = 505;
            rightEntryX[17] = 490;
            rightEntryY[17] = 504;
            rightEntryX[18] = 484;
            rightEntryY[18] = 503;
            rightEntryX[19] = 478;
            rightEntryY[19] = 501;
            rightEntryX[20] = 472;
            rightEntryY[20] = 500;
            rightEntryX[21] = 466;
            rightEntryY[21] = 498;
            rightEntryX[22] = 461;
            rightEntryY[22] = 496;
            rightEntryX[23] = 455;
            rightEntryY[23] = 495;
            rightEntryX[24] = 449;
            rightEntryY[24] = 493;
            rightEntryX[25] = 444;
            rightEntryY[25] = 491;
            rightEntryX[26] = 438;
            rightEntryY[26] = 489;
            rightEntryX[27] = 433;
            rightEntryY[27] = 486;
            rightEntryX[28] = 427;
            rightEntryY[28] = 484;
            rightEntryX[29] = 422;
            rightEntryY[29] = 481;
            rightEntryX[30] = 417;
            rightEntryY[30] = 479;
            rightEntryX[31] = 411;
            rightEntryY[31] = 476;
            rightEntryX[32] = 406;
            rightEntryY[32] = 473;
            rightEntryX[33] = 401;
            rightEntryY[33] = 471;
            rightEntryX[34] = 396;
            rightEntryY[34] = 468;
            rightEntryX[35] = 392;
            rightEntryY[35] = 465;
            rightEntryX[36] = 387;
            rightEntryY[36] = 461;
            rightEntryX[37] = 382;
            rightEntryY[37] = 458;
            rightEntryX[38] = 378;
            rightEntryY[38] = 455;
            rightEntryX[39] = 373;
            rightEntryY[39] = 451;
            rightEntryX[40] = 369;
            rightEntryY[40] = 448;
            rightEntryX[41] = 365;
            rightEntryY[41] = 444;
            rightEntryX[42] = 361;
            rightEntryY[42] = 441;
            rightEntryX[43] = 357;
            rightEntryY[43] = 437;
            rightEntryX[44] = 353;
            rightEntryY[44] = 433;
            rightEntryX[45] = 349;
            rightEntryY[45] = 429;
            rightEntryX[46] = 345;
            rightEntryY[46] = 425;
            rightEntryX[47] = 342;
            rightEntryY[47] = 421;
            rightEntryX[48] = 339;
            rightEntryY[48] = 417;
            rightEntryX[49] = 335;
            rightEntryY[49] = 413;
            rightEntryX[50] = 332;
            rightEntryY[50] = 408;
            rightEntryX[51] = 329;
            rightEntryY[51] = 404;
            rightEntryX[52] = 326;
            rightEntryY[52] = 400;
            rightEntryX[53] = 324;
            rightEntryY[53] = 395;
            rightEntryX[54] = 321;
            rightEntryY[54] = 391;
            rightEntryX[55] = 319;
            rightEntryY[55] = 386;
            rightEntryX[56] = 316;
            rightEntryY[56] = 382;
            rightEntryX[57] = 314;
            rightEntryY[57] = 377;
            rightEntryX[58] = 312;
            rightEntryY[58] = 372;
            rightEntryX[59] = 310;
            rightEntryY[59] = 368;
            rightEntryX[60] = 309;
            rightEntryY[60] = 363;
            rightEntryX[61] = 307;
            rightEntryY[61] = 358;
            rightEntryX[62] = 306;
            rightEntryY[62] = 353;
            rightEntryX[63] = 304;
            rightEntryY[63] = 349;
            rightEntryX[64] = 303;
            rightEntryY[64] = 344;
            rightEntryX[65] = 302;
            rightEntryY[65] = 339;
            rightEntryX[66] = 301;
            rightEntryY[66] = 334;
            rightEntryX[67] = 301;
            rightEntryY[67] = 329;
            rightEntryX[68] = 300;
            rightEntryY[68] = 324;
            rightEntryX[69] = 300;
            rightEntryY[69] = 319;
            rightEntryX[70] = 300;
            rightEntryY[70] = 314;
            rightEntryX[71] = 300;
            rightEntryY[71] = 310;
            rightEntryX[72] = 300;
            rightEntryY[72] = 305;
            rightEntryX[73] = 300;
            rightEntryY[73] = 300;
        }
    }
}


