﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace web.Domain.Entities
{
    public partial class Directore
    {
        public Directore()
        {
            Peliculas = new HashSet<Pelicula>();
        }

        public int IdDirector { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaNac { get; set; }

        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}