using Db.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Db
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> archivos = Directory.GetFiles(@"D:\\eleccion").OrderByDescending(s => s);

            var actasArchivo = ParseExcel(archivos.First()).ToList();

            using(var context = new AppContext())
            {
                context.Actas.AddRange(actasArchivo);
                context.SaveChanges();
            }



            decimal cc = actasArchivo
                .Where(acta => acta.Eleccion == "Presidente y Vicepresidente")
                .Sum(acta => acta.CC);

            decimal mas = actasArchivo
                .Where(acta => acta.Eleccion == "Presidente y Vicepresidente")
                .Sum(acta => acta.MAS);

            decimal validos = actasArchivo
                .Where(acta => acta.Eleccion == "Presidente y Vicepresidente")
                .Sum(acta => acta.Validos);

            Console.WriteLine("CC: " + cc/validos*100);
            Console.WriteLine("mas: " + mas/validos*100);

            var repetidos = actasArchivo
                .Where(acta => acta.Eleccion == "Presidente y Vicepresidente")
                .GroupBy(acta => acta.CodigoMesa)
                .Where(grp => grp.Count() > 1)
                .Select(grp => grp.Key)
                .ToList();

            Console.WriteLine("repetidos: " + repetidos.Count);

        }

        public static IEnumerable<ActaPublicada> ParseExcel(string fileName)
        {
            var fileInfo = new FileInfo(fileName);

            using var package = new ExcelPackage(fileInfo);

            var worksheet = package.Workbook.Worksheets[1];
            var count = worksheet.Dimension.Rows;

            for (int i = 2; i <= count; i++)
            {
                var acta = new ActaPublicada
                {
                    Pais = Convert.ToString(worksheet.Cells[i, 1].Value),
                    NumeroDepartamento = Convert.ToInt32(worksheet.Cells[i, 2].Value),
                    Departamento = Convert.ToString(worksheet.Cells[i, 3].Value),
                    Provincia = Convert.ToString(worksheet.Cells[i, 4].Value),
                    NumeroMunicipio = Convert.ToInt32(worksheet.Cells[i, 5].Value),
                    Municipio = Convert.ToString(worksheet.Cells[i, 6].Value),
                    Circunscripcion = Convert.ToString(worksheet.Cells[i, 7].Value),
                    Localidad = Convert.ToString(worksheet.Cells[i, 8].Value),
                    Recinto = Convert.ToString(worksheet.Cells[i, 9].Value),
                    NumeroMesa = Convert.ToInt32(worksheet.Cells[i, 10].Value),
                    CodigoMesa = Convert.ToString(worksheet.Cells[i, 11].Value),
                    Eleccion = Convert.ToString(worksheet.Cells[i, 12].Value),
                    Inscritos = Convert.ToInt32(worksheet.Cells[i, 13].Value),
                    CC = Convert.ToInt32(worksheet.Cells[i, 14].Value),
                    FPV = Convert.ToInt32(worksheet.Cells[i, 15].Value),
                    MTS = Convert.ToInt32(worksheet.Cells[i, 16].Value),
                    UCS = Convert.ToInt32(worksheet.Cells[i, 17].Value),
                    MAS = Convert.ToInt32(worksheet.Cells[i, 18].Value),
                    M21F = Convert.ToInt32(worksheet.Cells[i, 19].Value),
                    PDC = Convert.ToInt32(worksheet.Cells[i, 20].Value),
                    MNR = Convert.ToInt32(worksheet.Cells[i, 21].Value),
                    PanBol = Convert.ToInt32(worksheet.Cells[i, 22].Value),
                    Validos = Convert.ToInt32(worksheet.Cells[i, 23].Value),
                    Blancos = Convert.ToInt32(worksheet.Cells[i, 24].Value),
                    Nulos = Convert.ToInt32(worksheet.Cells[i, 25].Value),
                    Computada = Convert.ToString(worksheet.Cells[i, 25].Value)
                };

                yield return acta;
            }
        }
    }
}
