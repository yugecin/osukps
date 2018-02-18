using System;
using System.Drawing;
using System.Windows.Forms;

namespace osukps {
	class DialogPositioner {

		private const int MARGIN = 10;

		public static bool preferSouth = false;

		private static Screen screen;
		private static Size size;
		private static Point midposition;
		private static Point location;

		public static void From(Form from) {
			screen = Screen.FromControl(from);
			location = from.Location;
			size = from.Size;
			midposition = new Point(size.Width / 2, size.Height / 2);
		}

		public static void From(Form from, Point absolutemidposition) {
			From(from);
			midposition = new Point(absolutemidposition.X - location.X, absolutemidposition.Y - location.Y);
		}

		public static void ApplyTo(Form other) {
			other.Location = preferSouth ? CalcSouth(other) : CalcNorth(other);
			preferSouth = false;
		}

		private static Point CalcSouth(Form other) {
			Point south = new Point(
				location.X + midposition.X - other.Size.Width / 2,
				location.Y + size.Height + MARGIN
			);

			south.Y = Math.Max(screen.WorkingArea.Y, south.Y);
			south.X = Math.Max(screen.WorkingArea.X, south.X);

			if (south.X + other.Size.Width > screen.WorkingArea.Width ||
				south.Y + other.Size.Height > screen.WorkingArea.Height)
			{
				return CalcNorth(other);
			}

			return south;
		}

		private static Point CalcNorth(Form other) {
			Point north = new Point(
				location.X + midposition.X - other.Size.Width / 2,
				location.Y - other.Size.Height - MARGIN
			);

			north.Y = Math.Max(screen.WorkingArea.Y, north.Y);
			north.X = Math.Max(screen.WorkingArea.X, north.X);

			return north;
		}

	}
}
