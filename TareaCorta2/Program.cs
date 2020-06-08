using System;
using System.Diagnostics;

namespace ReinasProbabilistico
{
	class Program
	{
		static void Main(string[] args)
		{
			Tablero t = new Tablero();

			Stopwatch sw = new Stopwatch();

			sw.Start();

			while (true)
			{
				if (t.nReinas(10))
				{
					break;
				}
			}

			sw.Stop();

			Console.WriteLine("Elapsed = {0} ms", sw.ElapsedMilliseconds);
			
		}
	}
}

