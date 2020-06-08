using System;

namespace ReinasProbabilistico
{
	class Program
	{
		static void Main(string[] args)
		{
			Tablero t = new Tablero();

			while (true)
			{
				if (t.nReinas(6))
				{
					break;
				}
			}

			//bool reinas = t.nReinas(4);

			//Console.WriteLine(reinas);
		}
	}
}

