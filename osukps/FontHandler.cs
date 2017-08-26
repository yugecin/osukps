using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace osukps {
	class FontHandler {
		public static Font defaultFont = new Font("Tahoma", 9.75f, FontStyle.Bold);
		public static Font currentFont = null;

		public static List<Label> labels = new List<Label>();

		static float fontMax = 14;
		static float fontMin = 9.75f;

		public static void changeFont(Font font) {
			if (font.Size < fontMin) {
				font = new Font(font.Name, fontMin, font.Style);
			} else if (font.Size > fontMax) {
				font = new Font(font.Name, fontMax, font.Style);
			}
			foreach (Label label in labels.ToArray()) {
				label.Font = font;
			}
			currentFont = font;
		}

		public static void resetFont() {
			changeFont(defaultFont);
		}
	}
}
