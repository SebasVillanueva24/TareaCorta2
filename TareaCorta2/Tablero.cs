﻿using System;
using System.Collections;
using System.Collections.Generic;

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

		public bool chequearSiExiste(ArrayList lista, int n)
		{ 
			foreach(int num in lista)
			{
				if(num == n)
				{
					return true;
				}
			}
			return false;
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

		public bool validarDiagonal(int fila, int columna)
		{
			foreach (ValueTuple<int, int> elemento in posicionesProhibidas)
			{
				if (columna == elemento.Item2 && fila == elemento.Item1)
				{
					return false;
				}
			}
			return true;
		}

		public bool nReinas(int N)
		{
			bool[,] tablero = new bool[N,N];

			posicionesProhibidas.Clear();
			reinasColocadas.Clear();

			for(int i = 0; i < N; i++)
			{
				Random rnd = new Random();
				int columna = rnd.Next(0, N);

				if (i == 0)
				{
					//Primera fila
					reinasColocadas.Push((i,columna));
					int varx = i;
					int vary = columna;

					for (int k = 0; k <= N; k++)
					{
						if (varx + 1 <= N && vary + 1 <= N)
						{
							posicionesProhibidas.Push((varx++, vary++));
						}

					}
					int varx2 = i;
					int vary2 = columna;


					for (int k = columna+1; k > 0; k--)
					{
						if ( vary2 >= 0)
						{
							posicionesProhibidas.Push((varx2++, vary2--));
						}

					}
					tablero[i, columna] = true;
					
				}
				else
				{
					//El resto de filas
					if(validarColumna(columna) == false)
					{
						ArrayList usadas = new ArrayList();

						while (true)
						{
							//Ciclo que saca una columna hasta que no exista
							columna = rnd.Next(0, N);

							Console.WriteLine(usadas.Count);
							if(usadas.Count >= N)
							{
								return false;
							}
							else
							{
								if (chequearSiExiste(usadas, columna) == false)
								{
									if (validarColumna(columna) == true && validarDiagonal(i, columna) == true)
									{
										break;
									}
									else
									{
										usadas.Add(columna);
									}
								}
							}
							
						}
						foreach (int elemento in usadas)
						{
							Console.WriteLine("ELEMENTOS USADOS PARA LA FILA: " + i);
							Console.WriteLine(elemento);
							Console.WriteLine("---------------------------");
						}
						//Si la columna se repite


						int varx = i;
						int vary = columna;
						//Guardar la diagonal
						for (int k = 0; k <= N; k++)
						{
							if (varx + 1 <= N && vary + 1 <= N)
							{
								posicionesProhibidas.Push((varx++, vary++));
							}

						}

						int varx2 = i;
						int vary2 = columna;


						for (int k = columna + 1; k > 0; k--)
						{
							if (varx2 < N && vary2 >= 0)
							{
								posicionesProhibidas.Push((varx2++, vary2--));
							}

						}

						tablero[i, columna] = true;
						reinasColocadas.Push((i, columna));
					}
					else
					{
						if(validarDiagonal(i,columna) == false)
						{
							ArrayList usadas = new ArrayList();

							while (true)
							{
								//Ciclo que saca una columna hasta que no exista
								columna = rnd.Next(0, N);
								Console.WriteLine(usadas.Count);

								if(usadas.Count >= 4)
								{
									return false;
								}
								else
								{
									if (chequearSiExiste(usadas, columna) == false)
									{

										if (validarColumna(columna) == true && validarDiagonal(i, columna) == true)
										{
											break;
										}
										else
										{
											usadas.Add(columna);
										}

									}
								}
								
							}
								
							foreach (int elemento in usadas)
							{
								Console.WriteLine("ELEMENTOS USADOS PARA LA FILA: " + i);
								Console.WriteLine(elemento);
								Console.WriteLine("---------------------------");
							}
						}

						
						//Si la columna no existe
						int varx = i;
						int vary = columna;

						for (int k = 0; k <= N; k++)
						{
							if (varx + 1 <= N && vary + 1 <= N)
							{
								posicionesProhibidas.Push((varx++, vary++));
							}

						}

						int varx2 = i;
						int vary2 = columna;


						for (int k = columna + 1; k > 0; k--)
						{
							if (varx2 < N && vary2 >= 0)
							{
								posicionesProhibidas.Push((varx2++, vary2--));
							}

						}
						
						tablero[i, columna] = true;
						reinasColocadas.Push((i, columna));
					}
					
				}
			}
			imprimirMatriz(tablero, N);

			//foreach (ValueTuple<int, int> elemento in posicionesProhibidas)
			//{
			//	Console.WriteLine(elemento);
			//}

			return true;
		}
	}
}

