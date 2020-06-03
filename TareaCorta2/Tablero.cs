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
				int columna = rnd.Next(0, N);

				if (i == 0)
				{
					
					reinasColocadas.Push((i,columna));
					int varx = i;
					int vary = columna;

					for (int k = 0; k <= N; k++)
					{
						if (varx + 1 <= N && vary + 1 <= N)
						{
							Console.WriteLine(k);
							Console.WriteLine(N);
							posicionesProhibidas.Push((varx++, vary++));
						}

					}
					int varx2 = i;
					int vary2 = columna;


					for (int k = columna+1; k >= 0; k--)
					{
						if ( vary2 >= 0)
						{
							Console.WriteLine(varx2);
							Console.WriteLine(vary2);
							posicionesProhibidas.Push((varx2++, vary2--));
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
							columna = rnd.Next(0, N);
							if(validarColumna(columna) == true)
							{
								break;
							}
						}

						//Console.WriteLine(validarColumna(columna));
						//Console.Write(Environment.NewLine + Environment.NewLine);
						tablero[i, columna] = true;
						reinasColocadas.Push((i, columna));
					}
					else
					{
						//Console.WriteLine(validarColumna(columna));
						//Console.Write(Environment.NewLine + Environment.NewLine);
						tablero[i, columna] = true;
						reinasColocadas.Push((i, columna));
					}
					
				}
			}
			imprimirMatriz(tablero, N);

			foreach (ValueTuple<int, int> elemento in posicionesProhibidas)
			{
				Console.WriteLine(elemento);
			}
		}
	}
}

