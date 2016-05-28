
namespace osukps
{
	public class NoKeyHandler : IKeyHandler
	{

		private static NoKeyHandler instance = new NoKeyHandler();

		public static IKeyHandler Get()
		{
			return instance;
		}

		public bool Handle()
		{
			return false;
		}

	}
}
