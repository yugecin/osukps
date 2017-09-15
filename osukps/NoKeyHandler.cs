
namespace osukps {
	public class NoKeyHandler : IKeyHandler {

		private static NoKeyHandler instance = new NoKeyHandler();

		public static IKeyHandler Get() {
			return instance;
		}

		public byte Handle() {
			return 0;
		}

	}
}
