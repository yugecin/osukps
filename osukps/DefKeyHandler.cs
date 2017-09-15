using System.Runtime.InteropServices;

namespace osukps {
	class DefKeyHandler : IKeyHandler {

		[DllImport("user32.dll")]
		public static extern short GetAsyncKeyState(int vkey);

		private int keyCode;

		public DefKeyHandler(int keyCode) {
			this.keyCode = keyCode;
		}

		public byte Handle() {
			return (byte) ((GetAsyncKeyState(keyCode) & 0x8000) >> 15);
		}

	}
}
