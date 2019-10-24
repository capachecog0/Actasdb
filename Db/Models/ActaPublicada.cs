using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Db.Models
{
    public class ActaPublicada
    {
        public long Id { get; set; }
        public string Pais { get; set; }
        public int NumeroDepartamento { get; set; }
        public string Provincia { get; set; }
        public int NumeroMunicipio { get; set; }
        public string Municipio { get; set; }
        public string Circunscripcion { get; set; }
        public string Localidad { get; set; }
        public String Recinto { get; set; }
        public int NumeroMesa { get; set; }
        public String CodigoMesa { get; set; }
        public String Eleccion { get; set; }
        public int Inscritos { get; set; }
        public int CC { get; set; }
        public int FPV { get; set; }
        public int MTS { get; set; }
        public int UCS { get; set; }
        public int MAS { get; set; }
        public int M21F { get; set; }
        public int PDC { get; set; }
        public int MNR { get; set; }
        public int PanBol { get; set; }
        public int Validos { get; set; }
        public int Blancos { get; set; }
        public int Nulos { get; set; }
        public string Computada { get; set; }
        public string Departamento { get; internal set; }
    }
}
