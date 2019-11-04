﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tp3WebApiMarcio.Models
{
    public class Amigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime Aniversario { get; set; }
    }
}