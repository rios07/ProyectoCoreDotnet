﻿using System.Collections.Generic;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace ServiciosCore
{
    public interface IPaginasServicio : IBaseServicios<Paginas, PaginasExt>
    {
    }

    public class PaginasServicio : BaseServicios<Paginas, PaginasExt>, IPaginasServicio
    {
        private readonly IFuncionesDePaginasRepositorio _funcionesDePaginasRepositorio;
        private readonly IPaginasRepositorio _paginasRepositorio;
        private readonly IRolesDeUsuariosRepositorio _rolesDeUsuariosRepositorio;
        private readonly ISeccionesRepositorio _seccionesRepositorio;
        private readonly ITablasRepositorio _tablasRepositorio;

        public PaginasServicio(IPaginasRepositorio pPaginasRepositorio, ITablasRepositorio pTablasRepositorio,
            IFuncionesDePaginasRepositorio pFuncionesDePaginaRepositorio,
            IRolesDeUsuariosRepositorio pRolesDeUsuariosRepositorio, ISeccionesRepositorio pSeccionesRepositorio)
        {
            _paginasRepositorio = pPaginasRepositorio;
            _tablasRepositorio = pTablasRepositorio;
            _funcionesDePaginasRepositorio = pFuncionesDePaginaRepositorio;
            _rolesDeUsuariosRepositorio = pRolesDeUsuariosRepositorio;
            _seccionesRepositorio = pSeccionesRepositorio;
        }

        public override IRepositorio<Paginas, PaginasExt> GetRepositorio()
        {
            return _paginasRepositorio;
        }

        [ListadoDDL]
        public List<TablasExt> TablasDDL(ref ControllerBag pControllerbag, bool? pActivo, int pId)
        {
            _tablasRepositorio.SetDatosDeLogin(_paginasRepositorio.GetDatosDeLogin());
            return (List<TablasExt>) _tablasRepositorio.ListadoDDL(ref pControllerbag, pActivo, pId);
        }

        [ListadoDDL]
        public List<FuncionesDePaginasExt> FuncionesDePaginasDDL(ref ControllerBag pControllerbag, bool? pActivo,
            int pId)
        {
            _funcionesDePaginasRepositorio.SetDatosDeLogin(_paginasRepositorio.GetDatosDeLogin());
            return (List<FuncionesDePaginasExt>) _funcionesDePaginasRepositorio.ListadoDDL(ref pControllerbag, pActivo,
                pId);
        }

        [ListadoDDL]
        public List<RolesDeUsuariosExt> Roles(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            _rolesDeUsuariosRepositorio.SetDatosDeLogin(GetRepositorio().GetDatosDeLogin());
            return (List<RolesDeUsuariosExt>) _rolesDeUsuariosRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }

        [ListadoDDL]
        public List<SeccionesExt> Secciones(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            _seccionesRepositorio.SetDatosDeLogin(GetRepositorio().GetDatosDeLogin());
            return (List<SeccionesExt>) _seccionesRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }
    }
}