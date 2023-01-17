using System.Runtime.CompilerServices;

namespace TPS
{
	public class configuration
	{
		private static bool _Useproxy;

		private static string _nameChecker;

		public static bool Useproxy
		{
			get
			{
				return _Useproxy;
			}
			set
			{
				_Useproxy = value;
			}
		}

		public static string nameChecker
		{
			get
			{
				return _nameChecker;
			}
			set
			{
				_nameChecker = value;
			}
		}

		public static string Coder
		{
			get;
			set;
		}

		public static string versionChecker
		{
			get;
			set;
		}

		public configuration(bool useProxy, string namechecker, string coder, string versionchecker = null)
		{
			nameChecker = namechecker;
			versionChecker = versionchecker;
			Coder = coder;
			Useproxy = useProxy;
		}
	}
}
