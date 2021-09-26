using System;

namespace MBS.Framework.USB.TestProject
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			System.Diagnostics.Process.Start("lsusb");

			using (UsbContext ctx = new UsbContext())
			{
				/*
                Device dev = ctx.GetDevices(0x16c0, 0x05dc)[0];
                dev.Open();
                dev.ClaimInterface(0);

                dev.ControlTransfer(((byte)RequestType.Vendor | (byte)RequestRecipient.Device | (byte)EndpointDirection.Out), 1, 7, 0, new byte[] { 255, 0, 0, 0, 0, 0, 255 }, 0);
				*/

				UsbDevice dev = ctx.GetDevices(0x0801, 0x0005)[0];
				dev.Open();
				dev.ClaimInterface(1);

				int actualLength = 0;
				dev.BulkTransfer(1, new byte[] { 0x1B, 0x81 }, out actualLength, 5000);
				dev.BulkTransfer(1, new byte[] { 0x1B, 0x61 }, out actualLength, 5000);

				return;

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

					UsbDevice[] devs = ctx.GetDevices(vid, pid);
					Console.WriteLine("{0} devices found", devs.Length);
				}
			}
		}
	}
}
