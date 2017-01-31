//   - Blaster Master Class -
// Purpose:      FMOD
// Rev:          1.0
// Last updated: 22/03/10

using System;
using System.Runtime.InteropServices;

namespace BlasterMaster
{
    public class clsSound
    {
        [DllImport("fmod.dll", EntryPoint = "_FSOUND_Sample_Load@20", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FSOUND_Sample_Load(int index, string name, FSOUND_MODES mode, int offset, int length);
        [DllImport("fmod.dll", EntryPoint = "_FSOUND_PlaySound@8", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FSOUND_PlaySound(int channel, int sptr);
        [DllImport("fmod.dll", EntryPoint = "_FSOUND_Sample_SetMode@8", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern byte FSOUND_Sample_SetMode(int sptr, FSOUND_MODES mode);
        [DllImport("fmod.dll", EntryPoint = "_FSOUND_StopSound@4", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern byte FSOUND_StopSound(int channel);
        [DllImport("fmod.dll", EntryPoint = "_FSOUND_IsPlaying@4", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern byte FSOUND_IsPlaying(int channel);

        // http://www.gamedev.net/reference/articles/article2098.asp
        // http://www.freebasic.net/forum/viewtopic.php?t=11


        private enum FSOUND_MODES
        {

            FSOUND_LOOP_OFF = 0x1,
            // For non looping samples.
            FSOUND_LOOP_NORMAL = 0x2,
            // For forward looping samples.
            FSOUND_LOOP_BIDI = 0x4,
            // For bidirectional looping samples.  (no effect if in hardware).
            FSOUND_8BITS = 0x8,
            // For 8 bit samples.
            FSOUND_16BITS = 0x10,
            // For 16 bit samples.
            FSOUND_MONO = 0x20,
            // For mono samples.
            FSOUND_STEREO = 0x40,
            // For stereo samples.
            FSOUND_UNSIGNED = 0x80,
            // For source data containing unsigned samples.
            FSOUND_SIGNED = 0x100,
            // For source data containing signed data.
            FSOUND_DELTA = 0x200,
            // For source data stored as delta values.
            FSOUND_IT214 = 0x400,
            // For source data stored using IT214 compression.
            FSOUND_IT215 = 0x800,
            // For source data stored using IT215 compression.
            FSOUND_HW3D = 0x1000,
            // Attempts to make samples use 3d hardware acceleration. (if the card supports it)
            FSOUND_2D = 0x2000,
            // Ignores any 3d processing.  overrides FSOUND_HW3D.  Located in software.
            FSOUND_STREAMABLE = 0x4000,
            // For realtime streamable samples.  If you dont supply this sound may come out corrupted.
            FSOUND_LOADMEMORY = 0x8000,
            // For FSOUND_Sample_Load - name will be interpreted as a pointer to data
            FSOUND_LOADRAW = 0x10000,
            // For FSOUND_Sample_Load/FSOUND_Stream_Open - will ignore file format and treat as raw pcm.
            FSOUND_MPEGACCURATE = 0x20000,
            // For FSOUND_Stream_Open - scans MP2/MP3 (VBR also) for accurate FSOUND_Stream_GetLengthMs/FSOUND_Stream_SetTime.
            FSOUND_FORCEMONO = 0x40000,
            // For forcing stereo streams and samples to be mono - needed with FSOUND_HW3D - incurs speed hit
            FSOUND_HW2D = 0x80000,
            // 2d hardware sounds.  allows hardware specific effects
            FSOUND_ENABLEFX = 0x100000,
            // Allows DX8 FX to be played back on a sound.  Requires DirectX 8 - Note these sounds cant be played more than once, or have a changing frequency
            FSOUND_MPEGHALFRATE = 0x200000,
            // For FMODCE only - decodes mpeg streams using a lower quality decode, but faster execution
            FSOUND_XADPCM = 0x400000,
            // For XBOX only - Describes a user sample that its contents are compressed as XADPCM
            FSOUND_VAG = 0x800000,
            // For PS2 only - Describes a user sample that its contents are compressed as Sony VAG format.
            FSOUND_NONBLOCKING = 0x1000000,
            // For FSOUND_Stream_Open - Causes stream to open in the background and not block the foreground app - stream plays only when ready.
            FSOUND_GCADPCM = 0x2000000,
            // For Gamecube only - Contents are compressed as Gamecube DSP-ADPCM format
            FSOUND_MULTICHANNEL = 0x4000000,
            // For PS2 only - Contents are interleaved into a multi-channel (more than stereo) format
            FSOUND_USECORE0 = 0x8000000,
            // For PS2 only - Sample/Stream is forced to use hardware voices 00-23
            FSOUND_USECORE1 = 0x10000000,
            // For PS2 only - Sample/Stream is forced to use hardware voices 24-47
            FSOUND_LOADMEMORYIOP = 0x20000000,
            // For PS2 only - "name" will be interpreted as a pointer to data for streaming and samples.  The address provided will be an IOP address
            FSOUND_IGNORETAGS = 0x40000000,
            // Skips id3v2 etc tag checks when opening a stream, to reduce seek/read overhead when opening files (helps with CD performance)
            //FSOUND_STREAM_NET = 0x80000000,
            // Specifies an internet stream

            FSOUND_NORMAL = FSOUND_16BITS | FSOUND_SIGNED | FSOUND_MONO

        }

        private int fmodHandle;
        private int channel;
        const int FSOUND_FREE = -1;
        const int FSOUND_ALL = -3;

        public clsSound(string filename)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Class constructor  
            //------------------------------------------------------------------------------------------------------------------

            this.fmodHandle = FSOUND_Sample_Load(FSOUND_FREE, filename, 0, 0, 0);
        }

        public void playSND(bool loopSND)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Method (play ound)  
            //------------------------------------------------------------------------------------------------------------------

            if (loopSND)
            {
                FSOUND_Sample_SetMode(this.fmodHandle, FSOUND_MODES.FSOUND_LOOP_NORMAL);
            }

            this.channel = FSOUND_PlaySound(FSOUND_FREE, this.fmodHandle);
        }

        public void stopSND()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Method (cease sound)  
            //------------------------------------------------------------------------------------------------------------------

            FSOUND_StopSound(this.channel);
        }

        public bool isPlaying()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: (is channel playing?)   
            //------------------------------------------------------------------------------------------------------------------

            return Convert.ToBoolean(FSOUND_IsPlaying(this.channel));
        }
    }
}
