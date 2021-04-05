using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosCore
{
    public interface IEnviosDeCorreosServicio : IBaseServicios<EnviosDeCorreos, EnviosDeCorreosExt>
    {
        void EnviarPendientes();
    }
    public class EnviosDeCorreosServicio : BaseServicios<EnviosDeCorreos, EnviosDeCorreosExt>, IEnviosDeCorreosServicio
    {
        private IEnviosDeCorreosRepositorio _enviosDeCorreosRepositorio;
        private ILogEnviosDeCorreosRepositorio _logEnvioDeCorreosRepositorio;
        public EnviosDeCorreosServicio(IEnviosDeCorreosRepositorio pEnviosDeCorreosRepositorio, ILogEnviosDeCorreosRepositorio pLogEnviosDeCorreosRepositorio)
        {
            _enviosDeCorreosRepositorio = pEnviosDeCorreosRepositorio;
            _logEnvioDeCorreosRepositorio = pLogEnviosDeCorreosRepositorio;
        }

        public override IRepositorio<EnviosDeCorreos, EnviosDeCorreosExt> GetRepositorio()
        {
            return _enviosDeCorreosRepositorio;
        }

        public override void SetDatosDeLogin(DatosDeLogin pDatosDeLogin)
        {
            _logEnvioDeCorreosRepositorio.SetDatosDeLogin(pDatosDeLogin);
            base.SetDatosDeLogin(pDatosDeLogin);
        }
        public void EnviarPendientes()
        {
            ControllerBag controllerBag = new ControllerBag();
            List<EnviosDeCorreosExt> correosPendientes = _enviosDeCorreosRepositorio.ObtenerPendientes(ref controllerBag);

            foreach (EnviosDeCorreosExt Envio in correosPendientes)
            {
                List<string> Destinatarios = Envio.EnvioHacia_Emails.Split(';').ToList();
                foreach (string Destinatario in Destinatarios)
                {
                    LogEnviosDeCorreos Log = new LogEnviosDeCorreos
                    {
                        EnvioDeCorreoId = Envio.Id,
                        Fecha = FFechas.FechaAhora()
                    };
                    try
                    {
                        if (Destinatario != "" && Envio.EnvioDesde_Pwd != "" && Envio.EnvioDesde_Email != "")
                        {
                            FMails.Enviar(Envio.EnvioDesde_Email, Envio.EnvioDesde_Pwd, Destinatario, Envio.Asunto, Envio.Contenido, Envio.EnvioDesde_Smtp, "EnvioDeCorreos", "EnviarPendientes");
                            Log.Satisfactorio = true;
                            Log.Observaciones = "";
                            _logEnvioDeCorreosRepositorio.Insert(Log, ref controllerBag);
                        }

                    }
                    catch (Exception pExc)
                    {
                        Log.Satisfactorio = false;
                        Log.Observaciones = pExc.InnerException.ToString();
                        _logEnvioDeCorreosRepositorio.Insert(Log, ref controllerBag);
                    }
                }
            }
        }
    }

}
