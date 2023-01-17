using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;

namespace TPS
{
	internal class InfoManager
	{
		private Timer timer;

		private string lastGateway;

		public InfoManager()
		{
			lastGateway = GetGatewayMAC();
		}

		public void StartListener()
		{
			timer = new Timer(delegate
			{
				OnCallBack();
			}, null, 5000, -1);
		}

		private void OnCallBack()
		{
			timer.Dispose();
			if (!(GetGatewayMAC() == lastGateway))
			{
				Constants.Breached = true;
				MessageBox.Show("ARP Cache poisoning has been detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
			}
			else
			{
				lastGateway = GetGatewayMAC();
			}
			timer = new Timer(delegate
			{
				OnCallBack();
			}, null, 5000, -1);
		}

		public static IPAddress GetDefaultGateway()
		{
			return (from g in (from n in NetworkInterface.GetAllNetworkInterfaces()
					where n.OperationalStatus == OperationalStatus.Up
					where n.NetworkInterfaceType != NetworkInterfaceType.Loopback
					select n).SelectMany((NetworkInterface n) => n.GetIPProperties()?.GatewayAddresses)
				select g?.Address into a
				where a != null
				select a).FirstOrDefault();
		}

		private string GetArpTable()
		{
			string pathRoot = Path.GetPathRoot(Environment.SystemDirectory);
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.FileName = pathRoot + "Windows\\System32\\arp.exe";
			processStartInfo.Arguments = "-a";
			processStartInfo.UseShellExecute = false;
			processStartInfo.RedirectStandardOutput = true;
			Process process = Process.Start(processStartInfo);
			StreamReader standardOutput = process.StandardOutput;
			return standardOutput.ReadToEnd();
		}

		private string GetGatewayMAC()
		{
			string arg = GetDefaultGateway().ToString();
			string pattern = $"({arg} [\\W]*) ([a-z0-9-]*)";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(GetArpTable());
			return match.Groups[2].ToString();
		}
	}
}
