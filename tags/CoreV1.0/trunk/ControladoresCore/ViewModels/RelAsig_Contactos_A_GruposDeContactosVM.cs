﻿using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ControladoresCore.ViewModels;

namespace ControladoresCore.ViewModels
{
    public class RelAsig_Contactos_A_GruposDeContactosVM : BaseVM
    {
        public int ContactoId { get; set; }
        public int GrupoDeContactoId { get; set; }
    }
}