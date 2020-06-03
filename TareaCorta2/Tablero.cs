using System;
using System.Collections;

namespace ReinasProbabilistico
{
	public class Tablero
	{
		Stack posicionesProhibidas = new Stack();
		Stack reinasColocadas = new Stack();

		public void imprimirMatriz(bool[,] tablero, int N)
		{
			for (int k = 0; k < N; k++)
			{
				for (int j = 0; j < N; j++)
				{
					Console.Write(string.Format("{0} ", tablero[k, j]));
				}
				Console.Write(Environment.NewLine + Environment.NewLine);
			}

		}

		public bool validarColumna(int columna)
		{
			foreach (ValueTuple<int, int> elemento in reinasColocadas)
			{
				if(columna == elemento.Item2)
				{
					return false;
				}
			}
			return true;
		}

		public void nReinas(int N)
		{
			bool[,] tablero = new bool[N,N];

			for(int i = 0; i < N; i++)
			{
				Random rnd = new Random();
				int columna = rnd.Next(0, 4);

				if (i == 0)
				{
					;
					reinasColocadas.Push((i,columna));
					int varx = i;
					int vary = columna;

					for (int k = 0; k < N; k++)
					{
						if(varx+1 < N && vary+1 < N)
						{
							posicionesProhibidas.Push((varx++, vary++));
						}
						
					}

					tablero[i, columna] = true;
					//Console.WriteLine("Posicion del true" + i + " " + columna);
				}
				else
				{
					if(validarColumna(columna) == false)
					{
						while(true)
						{
							columna = rnd.Next(0, 4);
							if(validarColumna(columna) == true)
							{
								break;
							}
						}

						Console.WriteLine(validarColumna(columna));
						Console.Write(Environment.NewLine + Environment.NewLine);
						tablero[i, columna] = true;
						reinasColocadas.Push((i, columna));
					}
					else
					{
						Console.WriteLine(validarColumna(columna));
						Console.Write(Environment.NewLine + Environment.NewLine);
						tablero[i, columna] = true;
						reinasColocadas.Push((i, columna));
					}
					
				}
			}
			imprimirMatriz(tablero, N);

			foreach(ValueTuple<int,int> elemento in posicionesProhibidas)
			{
				Console.WriteLine(elemento);
			}
		}
	}
}

