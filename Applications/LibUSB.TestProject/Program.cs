using System;

namespace LibUSB.TestProject
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			System.Diagnostics.Process.Start("lsusb");

			using (Context ctx = new Context())
			{
				while (true)
				{
					Console.WriteLine();
					Console.Write("Enter Device ID (vid:pid) > ");
					string vidpid = Console.ReadLine();
					if (vidpid == "exit")
					{
						break;
					}

					if (!vidpid.Contains(":"))
					{
						Console.WriteLine("not in vid:pid format");
						continue;
					}

					string[] vidpid_n = vidpid.Split(new char[] { ':' });
					if (vidpid_n.Length != 2)
					{
						Console.WriteLine("not in vid:pid format");
						continue;
					}

					string vid_s = vidpid_n[0];
					string pid_s = vidpid_n[1];

					ushort vid = UInt16.Parse(vid_s, System.Globalization.NumberStyles.HexNumber);
					ushort pid = UInt16.Parse(pid_s, System.Globalization.NumberStyles.HexNumber);

					Device[] devs = ctx.GetDevices(vid, pid);
					Console.WriteLine("{0} devices found", devs.Length);
				}
			}
		}
	}
}
