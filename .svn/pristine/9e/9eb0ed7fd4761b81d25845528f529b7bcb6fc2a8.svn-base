using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;
using FuncionesCore;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ServiciosCore
{
    public interface IBaseServicios<Modelo, ModeloExt> where Modelo : BaseModelo where ModeloExt : Modelo
    {
        int Insert(Modelo pObj, ref ControllerBag pControllerBag);
        bool Delete(int pId, ref ControllerBag pControllerBag);
        ModeloExt Registro(int pId, ref ControllerBag pControllerBag);
        IEnumerable<ModeloExt> Listado(ref ControllerBag pControllerBag);
        IEnumerable<ModeloExt> Listado(Dictionary<String, String> filtros, ref ListParams pListParams, ref ControllerBag pControllerBag);
        bool PrecargaInicialDeUnaPagina(Operacion pOp, ref ControllerBag pControllerBag);
        void SetDatosDeLogin(DatosDeLogin pDatosDeLogin);
        DatosDeLogin GetDatosDeLogin();
        // void SetMiMsg(List<MensajeDeError> pMiMsg);
        int Update(Modelo pObj, ref ControllerBag pControllerBag);
    }

    /// <summary>
    /// Servicio genérico para manejar objetos y comunicarse con el repositorio correspondiente.
    /// </summary>
    /// <typeparam name="Modelo"></typeparam>
    /// <typeparam name="ModeloExt"></typeparam>
    public abstract class BaseServicios<Modelo, ModeloExt> : IBaseServicios<Modelo, ModeloExt> where Modelo : BaseModelo, new() where ModeloExt : Modelo
    {
        /// <summary>
        /// Debe devolver la instancia del respositorio que va a usarse
        /// </summary>
        /// <returns></returns>
        public abstract IRepositorio<Modelo, ModeloExt> GetRepositorio();

        public bool PrecargaInicialDeUnaPagina(Operacion pOp, ref ControllerBag pControllerBag)
        {
            return GetRepositorio().PrecargaInicialDeUnaPagina(pOp, ref pControllerBag);
        }

        public virtual int Insert(Modelo pObj, ref ControllerBag pControllerBag)
        {
            if (pControllerBag.TieneErrores())
            {
                pControllerBag.Add("No se ejecuta la acción del 'Create'. Es inesperado que en este punto haya traido el mensaje anterior.");
                return 0;
            }
            else
            {
                if (pObj.Valido(ref pControllerBag))  // Acá validamos el modelo
                {
                    return GetRepositorio().Insert(pObj, ref pControllerBag);
                }
                else
                {
                    return 0;
                }
            }
        }

        public virtual bool Delete(int pId, ref ControllerBag pControllerBag)
        {
            if (pControllerBag.TieneErrores())
            {
                pControllerBag.Add("No se ejecuta la acción del 'Delete'. Es inesperado que en este punto haya traido el mensaje anterior.");
                return false;
            }
            else
            { 
                Modelo m = new Modelo();
                if (m.PermiteAnularEliminarValido() != BaseModelo.AnularEliminar.ninguno)  // Acá validamos q el modelo permita la operación
                {
                    return GetRepositorio().Delete(pId, ref pControllerBag);
                }
                else
                {
                    pControllerBag.Add("El registro no permite la opción de anular/eliminar.");
                    return false;
                }
            }
        }

        public virtual ModeloExt Registro(int pId, ref ControllerBag pControllerBag)
        {
            return GetRepositorio().Registro(pId, ref pControllerBag);
        }

        public virtual IEnumerable<ModeloExt> Listado(ref ControllerBag pControllerBag)
        {
            return GetRepositorio().Listado(ref pControllerBag);
        }

        public IEnumerable<ModeloExt> Listado(Dictionary<String, String> filtros, ref ListParams pListParams, ref ControllerBag pControllerBag)
        {
            return GetRepositorio().Listado(filtros, ref pListParams, ref pControllerBag);
        }

        public virtual void SetDatosDeLogin(DatosDeLogin pDatosDeLogin)
        {
            GetRepositorio().SetDatosDeLogin(pDatosDeLogin);
        }

        public virtual int Update(Modelo pObj, ref ControllerBag pControllerBag)
        {
            if (pControllerBag.TieneErrores())
            {
                pControllerBag.Add("No se ejecuta la acción del 'Update'. Es inesperado que en este punto haya traido el mensaje anterior.");
                return 0;
            }
            else
            {
                if (pObj.Valido(ref pControllerBag))  // Acá validamos el modelo
                {
                    return GetRepositorio().Update(pObj, ref pControllerBag);
                }
                else
                {
                    return 0;
                }
            }
        }

        public DatosDeLogin GetDatosDeLogin()
        {
            return GetRepositorio().GetDatosDeLogin();
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class ListadoDDL : Attribute
    {

    }
    
}
