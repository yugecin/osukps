using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace osukps
{
    class FontHandler
    {
        public static string fontName = "Tahoma";
        public static System.Drawing.FontStyle fontStyle = System.Drawing.FontStyle.Bold;

        public static List<System.Windows.Forms.Label> labels = new List<System.Windows.Forms.Label>();

        static float fontMax = 14;
        static float fontSize = 9.75f;
        static float fontMin = 9.75f;

        public static void changeFont(System.Drawing.Font font)
        {
            fontName = font.FontFamily.Name;
            fontStyle = font.Style;
            if(font.Size < fontMin && font.Size > fontMax)
            {
                fontSize = font.Size;
            } else if(font.Size < fontMin)
            {
                fontSize = fontMin;
            } else
            {
                fontSize = fontMax;
            }
            foreach(System.Windows.Forms.Label label in labels.ToArray())
            {
                label.Font = new System.Drawing.Font(fontName, fontSize, fontStyle);
            }
        }
    }
}
