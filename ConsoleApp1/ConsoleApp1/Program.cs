using System;

namespace TP
{
    class Program
    {
        static void Main(string[] args)
        {

            long alu = DameNumero(0, 120, "Cuantos alumnos hay en la cursada?");

            if (alu > 0)

            {
                //Tomo 20 parciales como mÃ¡ximo porque dentro de las 32 clases, tambien deben estar los recuperatorios y el final.
                long exa = DameNumero(2, 20, "Cuantos parciales hay?");

                //Array para Registros
                long[] registros = new long[alu];

                //Matriz para Nombres y Apellidos
                string[,] alumnos = new string[2, alu];

                //Matriz para Notas
                long[,] notas = new long[exa + 1, alu];

                //Comienza la carga de datos
                for (long i = 0; i < alu; i++)
                {
                    registros[i] = DameNumero(100000, 999999, "Cual es el numero de registro del alumno nº" + (i + 1) + "?");
                    alumnos[0, i] = DamePalabra("Cual es el nombre del alumno nº" + (i + 1) + "?");
                    alumnos[1, i] = DamePalabra("Cual es el apellido del alumno nº" + (i + 1) + "?");

                    //Comienza la carga de notas del alumno
                    for (long j = 0; j < exa + 1; j++)
                    {
                        if (j < exa)
                        {
                            notas[j, i] = DameNumero(0, 10, "Cual es la nota del parcial numero " + (j + 1) + "?");
                        }
                        else
                        {
                            notas[j, i] = DameNumero(0, 10, "Cual es la nota de concepto?");
                        }
                    }
                }

                long opcion;

                //Presentamos el panel de opciones
                do
                {

                    PanelOpciones();

                    opcion = DameNumero(0, 13, "Cual opcion eligio? '13' Retorna al panel");

                    if (opcion == 1)
                    {

                        Listado(alumnos, registros, notas, 0, 0, alu, exa + 1, "Ausentes");

                    }

                    if (opcion == 2)
                    {

                        BuscarAlumno(alumnos, registros, notas, alu, exa + 1);

                    }

                    if (opcion == 3)
                    {

                        Console.WriteLine("Disculpas, esta opcion se encuentra en desarrollo. Pusle una tecla para volver al menu");
                        Console.ReadKey();

                    }

                    if (opcion == 4)
                    {
                        Console.WriteLine("Disculpas, esta opcion se encuentra en desarrollo. Pusle una tecla para volver al menu");
                        Console.ReadKey();

                    }

                    if (opcion == 5)
                    {

                        Listado(alumnos, registros, notas, 0, 4, alu, exa + 1, "Insuficientes");

                    }

                    if (opcion == 6)
                    {

                        Condicion(notas, alu, exa + 1);

                    }

                    if (opcion == 7)
                    {

                        ListarDato(alumnos, registros, notas, alu, exa + 1);

                    }

                    if (opcion == 8)
                    {

                        Console.WriteLine("Disculpas, esta opcion se encuentra en desarrollo. Pusle una tecla para volver al menu");
                        Console.ReadKey();

                    }

                    if (opcion == 9)
                    {

                        ListarParciales(registros, notas, alu, exa);

                    }

                    if (opcion == 10)
                    {

                        ListarPromedios(registros, notas, alu, exa + 1);

                    }

                    if (opcion == 11)
                    {

                        Situacion(notas, alu, exa + 1);

                    }

                    if (opcion == 12)
                    {

                        Console.WriteLine("Disculpas, esta opcion se encuentra en desarrollo. Pusle una tecla para volver al menu");
                        Console.ReadKey();


                    }

                } while (opcion > 0);

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Profesor, no hay alumnos inscriptos. Pulse una tecla para salir.");
                Console.ReadKey();
            }

            Exit();

        }

        static long DameNumero(long min, long max, string mensaje)
        {

            long res;

            do
            {

                Console.Clear();
                Console.WriteLine(mensaje);
                Console.WriteLine("Recorda que el numero debe encontrarse entre " + min + " y " + max);

                if (!long.TryParse(Console.ReadLine(), out res))
                {
                    Console.WriteLine("Ingrese por favor un numero");
                    res = -1;
                }

            } while (res < min || res > max);

            return res;

        }

        static string DamePalabra(string mensaje)
        {

            string res;

            do
            {
                Console.Clear();

                Console.WriteLine(mensaje);

                res = Console.ReadLine();

            } while (res == "");

            return res;

        }

        static void Exit()
        {
            Console.Clear();

            Console.WriteLine("Gracias por usar el Sistema TLyA. Hasta el proximo Cuatrimestre.");
            Console.ReadKey();

        }

        static void PanelOpciones()
        {

            Console.Clear();
            Console.WriteLine("SISTEMA TLyA version MC 1.2");
            Console.WriteLine("0 - Salir del Sistema");
            Console.WriteLine("1 - Ausentes");
            Console.WriteLine("2 - Buscar Alumno");
            Console.WriteLine("3 - Editar Dato de un alumno");
            Console.WriteLine("4 - Fechas de los Examenes, Recuperatorios y Final");
            Console.WriteLine("5 - Insuficientes");
            Console.WriteLine("6 - Cantidad de Alumnos discriminados por Condicion de Cursada");
            Console.WriteLine("7 - Listar Datos de los Alumnos");
            Console.WriteLine("8 - Nota de moda en Parciales");
            Console.WriteLine("9 - Notas de los parciales de cada alumno");
            Console.WriteLine("10 - Promedio de cada Alumno");
            Console.WriteLine("11 - Cantidad de Alumnos discriminados por Situacion Final");
            Console.WriteLine("12 - Sacar Alumno del Listado");
            Console.WriteLine("");
            Console.WriteLine("Tome su tiempo en ver que opcion quiere elegir porque cuando continue se borrara el panel");
            Console.ReadKey();

        }

        static void Listado(string[,] nombres, long[] registros, long[,] notas, long min, long max, long cantalu, double cantnotas, string msj)
        {

            Console.Clear();

            double cant = 0;
            double suma;

            for (long a = 0; a < cantalu; a++)
            {
                suma = 0;

                for (long e = 0; e < cantnotas; e++)
                {
                    suma += notas[e, a];
                }

                if (max == 0)
                {
                    if (suma == 0)
                    {
                        Console.WriteLine(registros[a] + " " + nombres[0, a] + " " + nombres[1, a]);
                        cant++;
                    }
                }
                else
                {
                    if ((suma / cantnotas) >= min && (suma / cantnotas) < max)
                    {
                        Console.WriteLine(registros[a] + " " + nombres[0, a] + " " + nombres[1, a]);
                        cant++;
                    }
                }

            }

            Console.WriteLine("");
            Console.WriteLine("El promedio de " + msj + " en la cursada es: " + cant / cantalu * 100 + "%");
            Console.ReadKey();

        }

        static void BuscarAlumno(string[,] nombres, long[] registros, long[,] notas, long cantalu, long cantnotas)
        {
            Console.Clear();

            long reg = DameNumero(100000, 999999, "Cual es el numero de registro del alumno?");

            Console.WriteLine("");

            for (long a = 0; a < cantalu; a++)
            {

                long suma = 0;

                if (registros[a] == reg)
                {
                    Console.WriteLine("Nombre: " + nombres[0, a]);
                    Console.WriteLine("Apellido: " + nombres[1, a]);

                    for (long e = 0; e < cantnotas; e++)
                    {
                        suma += notas[e, a];
                    }

                    if (suma == 0)
                    {
                        Console.WriteLine("CondiciÃ³n: Ausente");
                    }
                    else
                    {
                        Console.WriteLine("CondiciÃ³n: Cursando");
                    }

                    if (suma / cantnotas >= 7)
                    {
                        Console.WriteLine("SituaciÃ³n: Aprobado");
                    }
                    else if (suma / cantnotas >= 4)
                    {
                        Console.WriteLine("SituaciÃ³n: Regularizado");
                    }
                    else if (suma / cantnotas >= 0)
                    {
                        Console.WriteLine("SituaciÃ³n: Insuficiente");
                    }
                    else
                    {
                        Console.WriteLine("SituaciÃ³n: Ausente");
                    }

                }
                else
                {
                    Console.Write("El registro ingresado no fue encontrado");
                }

            }

            Console.ReadKey();

        }

        static void Condicion(long[,] notas, long cantalu, long cantnotas)
        {

            Console.Clear();

            long aus = 0;
            long suma;

            for (long a = 0; a < cantalu; a++)

            {
                suma = 0;

                for (long e = 0; e < cantnotas; e++)
                {
                    suma += notas[e, a];
                }

                if (suma == 0)
                {
                    aus++;

                }

            }

            Console.WriteLine("La cantidad de Ausentes en la cursada es: " + aus);
            Console.WriteLine("La cantidad de Presentes en la cursada es: " + (cantalu - aus));

            Console.WriteLine("");

            Console.WriteLine("El promedio de Ausentes en la cursada es: " + (double)((double)aus / (double)cantalu * 100) + "%");
            Console.WriteLine("El promedio de Presentes en la cursada es: " + (double)((1 - ((double)aus / (double)cantalu)) * 100) + "%");
            Console.ReadKey();

        }

        static void ListarDato(string[,] nombres, long[] registros, long[,] notas, long cantalu, double cantnotas)
        {

            Console.Clear();

            double suma;

            for (long a = 0; a < cantalu; a++)

            {
                suma = 0;

                for (long e = 0; e < cantnotas; e++)
                {
                    suma += notas[e, a];
                }

                if (suma / cantnotas >= 7)
                {
                    Console.WriteLine(registros[a] + " " + nombres[0, a] + " " + nombres[1, a] + " Cursando Aprobado");

                }
                else if (suma / cantnotas >= 4)
                {
                    Console.WriteLine(registros[a] + " " + nombres[0, a] + " " + nombres[1, a] + " Cursando Regularizado");
                }
                else if (suma / cantnotas > 0)
                {
                    Console.WriteLine(registros[a] + " " + nombres[0, a] + " " + nombres[1, a] + " Cursando Insuficiente");
                }
                else
                {
                    Console.WriteLine(registros[a] + " " + nombres[0, a] + " " + nombres[1, a] + " Ausente Ausente");
                }

            }

            Console.ReadKey();
        }

        static void Situacion(long[,] notas, long cantalu, long cantnotas)
        {

            Console.Clear();

            double aus = 0;
            double ins = 0;
            double reg = 0;
            double apr = 0;

            double suma;

            for (long a = 0; a < cantalu; a++)

            {
                suma = 0;

                for (long e = 0; e < cantnotas; e++)
                {
                    suma += notas[e, a];
                }

                if (suma / cantnotas >= 7)
                {
                    apr++;

                }
                else if (suma / cantnotas >= 4)
                {
                    reg++;
                }
                else if (suma / cantnotas > 0)
                {
                    ins++;
                }
                else
                {
                    aus++;
                }

            }

            Console.WriteLine("La cantidad de Ausentes en la cursada es: " + aus);
            Console.WriteLine("La cantidad de Insuficientes en la cursada es: " + ins);
            Console.WriteLine("La cantidad de Regularizados en la cursada es: " + reg);
            Console.WriteLine("La cantidad de Aprobados en la cursada es: " + apr);

            Console.WriteLine("");

            Console.WriteLine("El promedio de Ausentes en la cursada es: " + (double)((double)aus / (double)cantalu * 100) + "%");
            Console.WriteLine("El promedio de Insuficientes en la cursada es: " + (double)(ins / cantalu * 100) + "%");
            Console.WriteLine("El promedio de Regularizados en la cursada es: " + (reg / cantalu * 100) + "%");
            Console.WriteLine("El promedio de Aprobados en la cursada es: " + (double)apr / (double)cantalu * 100 + "%");

            Console.ReadKey();
        }

        static void ListarParciales(long[] registros, long[,] notas, long cantalu, long cantnotas)
        {

            Console.Clear();

            for (long a = 0; a < cantalu; a++)

            {
                Console.Write(registros[a]);

                for (long e = 0; e < cantnotas; e++)
                {
                    Console.Write(" " + notas[e, a]);
                }

                Console.WriteLine("");

            }

            Console.ReadKey();
        }

        static void ListarPromedios(long[] registros, long[,] notas, long cantalu, double cantnotas)
        {
            Console.Clear();

            double suma;

            for (long a = 0; a < cantalu; a++)

            {
                suma = 0;

                for (long e = 0; e < cantnotas; e++)
                {
                    suma += notas[e, a];
                }

                Console.WriteLine(registros[a] + " " + suma / cantnotas);

            }

            Console.ReadKey();

        }

    }

}