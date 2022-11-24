﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenqueAppMobile.Models
{
    internal class Setting
    {
        public static Usuario UserBasicDetail { get; set; }
        public static PencaCompartida PencaCompartidaDetail { get; set; }
        public static PencaEmpresa pencaEmpresaDetail { get; set; }
        public const string BaseUrl = "https://localhost:7210";
    }
}
