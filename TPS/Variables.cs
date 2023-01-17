using System.Collections.Generic;
using System.Runtime.CompilerServices;
using xNet;

namespace TPS
{
	public class Variables
	{
		public static List<string> ComboList;

		private List<string> _003CProxyList_003Ek__BackingField;

		public static int Progress
		{
			get;
			set;
		}

		public List<string> ProxyList
		{
			[CompilerGenerated]
			get
			{
				return _003CProxyList_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CProxyList_003Ek__BackingField = value;
			}
		}

		public ProxyType proxyType
		{
			get;
			set;
		}

		public static int Threads
		{
			get;
			set;
		}

		public static int ComboLenght
		{
			get;
			set;
		}

		public static int Hits
		{
			get;
			set;
		}

		public static int Fails
		{
			get;
			set;
		}

		public static int Retries
		{
			get;
			set;
		}

		public static int Index
		{
			get;
			set;
		}
	}
}
