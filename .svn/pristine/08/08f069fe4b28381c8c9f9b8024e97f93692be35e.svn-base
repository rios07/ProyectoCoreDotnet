using System;
using System.Collections.Generic;
using FuncionesCore;

namespace ModelosCore
{
    public class EnviosDeCorreos : BaseModelo
    {
        public int UsuarioOriginanteId { get; set; }
        public int UsuarioDestinatarioID { get; set; }
        public int TablaId { get; set; }
        public int RegistroId { get; set; }
        public string EmailDeDestino { get; set; }
        public string Asunto { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaPactadaDeEnvio { get; set; }


        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.ninguno;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }
    }


    public class EnviosDeCorreosExt : EnviosDeCorreos
    {
        public string UsuarioOriginante { get; set; }
        public string UsuarioDestinatario { get; set; }


        public string EnvioHacia_Emails { get; set; }
        public string EnvioDesde_Email { get; set; }
        public string EnvioDesde_Pwd { get; set; }
        public string EnvioDesde_Smtp { get; set; }
        public string EnvioDesde_Puerto { get; set; }
        public List<LogEnviosDeCorreosExt> LogEnvios { get; set; }
    }
}