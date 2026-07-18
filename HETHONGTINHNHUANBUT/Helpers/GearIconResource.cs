using System;
using System.Drawing;
using System.IO;

namespace HETHONGTINHNHUANBUT
{
    public static class GearIconResource
    {
        private static readonly string Base64Icon = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAACXBIWXMAAAsTAAALEwEAmpwYAAAB20lEQVR4nL1WO04DQQxdCUJBRwnUCPEpOAASVFCAoIAcgJ3JIDqIvYhuS1h7gTpX4Az8fxIScBI6EAXiJ0/YaAk7m7BEWHIzsd/z2OO38bw2rRyGPWtb233ixtRKXqdNI91r5A9xhXTRUXBjaiWF9JIieC6XD7qKVjqhgW90NZ5NzlaARxPwxFeDaKiRU41nbQ7SRDvgD3UQelfA+xWkJWlJM4FGOtFIiwp4V2Ltmc3NIVHA5z+B+JdOZ04CU40nNdJrUXAF/KaAp3PbpJCocPXA27ngliCgcmZ1SI8K6ejLH7NifOA5d3tMreQDj2vg64yrn5v1vf4k1g+igczBAx+rzZ2Rb4sYhmG3Ar5Lv/Pmyk0KPE2ikZ4cOS8a6VawPROGvS1exaHr1lJxXq5gtyRQSEdOArsLLQjkGhr4Utbf1SI/iAaawVc3dgdzWvQsM7ItSky0xQ+iYYV0lZFwkSax4MCXWUMWCcnVKdcz1VKt9Nz2PbtyHUTzTuAGAfD+H2QizgX3kWYawlWM4D132eqSWxSckznctCXXIlwaONLAy1lbq4BPK9V4QWJsbDtynZCINFSCaKpxtrkz9kN3gmg4+V1i61LfAvxfPpmew0Sv0nvRUXCxon9bPgFR7tyC+uyNsAAAAABJRU5ErkJggg==";

        public static Image GetIcon()
        {
            byte[] bytes = Convert.FromBase64String(Base64Icon);
            using (var ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
