﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace web.Domain.Entities
{
    public partial class PeliculasGenero
    {
        public int IdPeliculaGenero { get; set; }
        public int? IdPelicula { get; set; }
        public int? IdGenero { get; set; }

        public virtual Genero IdGeneroNavigation { get; set; }
        public virtual Pelicula IdPeliculaNavigation { get; set; }
    }
}