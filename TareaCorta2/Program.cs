using System;

namespace ReinasProbabilistico
{
	class Program
	{
		static void Main(string[] args)
		{
			Tablero t = new Tablero();

			t.nReinas(4);
		}
	}
}

//if(validarDiagonal(i, columna) == false)
//						{
//							Stack columnasUsadas = new Stack();
//bool bandera = false;

//							while (true)
//							{
//								if(columnasUsadas.Count == N)
//								{
//									Console.WriteLine("Empiece otra vez pa");
									
//								}
//								else
//								{
//									//Ciclo que saca una columna hasta que no exista
//									columna = rnd.Next(0, N);
//									foreach (int elemento in columnasUsadas)
//									{
//										if (elemento == columna)
//										{
//											bandera = true;
//											break;
//										}
//									}
//									if(!bandera)
//									{
//										if (validarColumna(columna) == true && validarDiagonal(i, columna) == true)
//										{
//											break;
//										}
//									}
									
//								}
								
//							}
//						}