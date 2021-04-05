using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using ControladoresCore.ViewModels;
using ModelosCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Http;


namespace ControladoresCore.Base
{
    public class BaseGlobal
    {
        public static void InitAutofac<Conexion>(ContainerBuilder pBuilder)
        {
            var repositorios = Assembly.Load("RepositoriosCore");
            var servicios = Assembly.Load("ServiciosCore");

            //registro todos los controllers (magia)
            pBuilder.RegisterControllers(Assembly.GetExecutingAssembly());
            pBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //busco todas las clases que terminen con "Repositorio" (convencion) y las "publico" como sus interfaces
            pBuilder.RegisterAssemblyTypes(repositorios)
                .Where(t => t.Name.EndsWith("Repositorio"))
                .AsImplementedInterfaces().InstancePerRequest();

            //busco todas las clases que terminen con "Servicio" (convencion) y las "publico" como sus interfaces
            pBuilder.RegisterAssemblyTypes(servicios)
                .Where(t => t.Name.EndsWith("Servicio"))
                .AsImplementedInterfaces().InstancePerRequest();

            //registro la conexion a SQL
            pBuilder.RegisterType<Conexion>().AsImplementedInterfaces().InstancePerRequest();

            IContainer container = pBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);


        }

        public static void InitAutomapper<PMappings>() where PMappings : Profile, new()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CoreMappings>();
                cfg.AddProfile<PMappings>();
            });
        }

        public class CoreMappings : Profile
        {
            public CoreMappings()
            {   
                CreateMap<CategoriasDeInformes, CategoriasDeInformesVM>();
                CreateMap<CategoriasDeInformesExt, CategoriasDeInformesVM>();
                CreateMap<Informes, InformesVM>();
                CreateMap<InformesExt, InformesVM>();
                CreateMap<LogErrores, LogErroresVM>();
                CreateMap<LogErroresExt, LogErroresVM>();
                CreateMap<Usuarios, UsuariosVM>();
                CreateMap<Pass, PassVM>();
                CreateMap<UsuariosExt, UsuariosVM>();
                CreateMap<RolesDeUsuarios, RolesDe_UsuariosVM>();
                CreateMap<Actores, ActoresVM>();
                CreateMap<ActoresExt, ActoresVM>();
                CreateMap<TiposDeActores, TiposDeActorVM>();
                CreateMap<Paginas, PaginasVM>();
                CreateMap<PaginasExt, PaginasVM>();
                CreateMap<Archivos, ArchivosVM>();
                CreateMap<ArchivosVM, ArchivosExt>();
                CreateMap<ArchivosExt, Archivos>();
                CreateMap<Soportes, SoportesVM>();
                CreateMap<SoportesExt, SoportesVM>();
                CreateMap<Notificaciones, NotificacionesVM>();
                CreateMap<NotificacionesExt, NotificacionesVM>();
                CreateMap<EstadosDeSoportes, EstadosDeSoportesVM>();
                CreateMap<EstadosDeSoportesExt, EstadosDeSoportesVM>();
                CreateMap<PrioridadesDeSoportes, PrioridadesDeSoportesVM>();
                CreateMap<PrioridadesDeSoportesExt, PrioridadesDeSoportesVM>();
                CreateMap<RelAsig_RolesDeUsuarios_A_Usuarios, RelAsig_RolesDeUsuarios_A_UsuariosVM>();
                CreateMap<RelAsig_RolesDeUsuarios_A_Paginas, RelAsig_RolesDeUsuarios_A_PaginasVM>();
                CreateMap<RelAsig_RolesDeUsuarios_A_PaginasExt, RelAsig_RolesDeUsuarios_A_PaginasVM>();
                CreateMap<RegistroRolesUsuarios, RegistroRolesUsuariosVM>();
                CreateMap<Tablas, TablasVM>();
                CreateMap<TablasExt, TablasVM>();
                CreateMap<FuncionesDePaginas, FuncionesDePaginasVM>();
                CreateMap<FuncionesDePaginasExt, FuncionesDePaginasVM>();
                CreateMap<LogRegistros, LogRegistrosVM>();
                CreateMap<LogRegistrosExt, LogRegistrosVM>();
                CreateMap<TiposDeOperaciones, TiposDeOperacionesVM>();
                CreateMap<TiposDeOperacionesExt, TiposDeOperacionesVM>();
                CreateMap<TiposDeTareas, TiposDeTareasVM>();
                CreateMap<TiposDeTareasExt, TiposDeTareasVM>();
                CreateMap<EstadosDeTareas, EstadosDeTareasVM>();
                CreateMap<EstadosDeTareasExt, EstadosDeTareasVM>();
                CreateMap<ImportanciasDeTareas, ImportanciasDeTareasVM>();
                CreateMap<ImportanciasDeTareasExt, ImportanciasDeTareasVM>();
                CreateMap<Tareas, TareasVM>();
                CreateMap<TareasExt, TareasVM>();
                CreateMap<CuentasDeEnvios, CuentasDeEnviosVM>();
                CreateMap<CuentasDeEnviosExt, CuentasDeEnviosVM>();
                CreateMap<RelAsig_CuentasDeEnvios_A_Tablas, RelAsig_CuentasDeEnvios_A_TablasVM>();
                CreateMap<RelAsig_CuentasDeEnvios_A_TablasExt, RelAsig_CuentasDeEnvios_A_TablasVM>();
                CreateMap<Dispositivos, DispositivosVM>();
                CreateMap<DispositivosExt, DispositivosVM>();
                CreateMap<Provincias, ProvinciasVM>();
                CreateMap<ProvinciasExt, ProvinciasVM>();
                CreateMap<RolesDeUsuarios, RolesDeUsuariosVM>();
                CreateMap<RolesDeUsuariosExt, RolesDeUsuariosVM>();
                CreateMap<Contactos, ContactosVM>();
                CreateMap<ContactosExt, ContactosVM>();
                CreateMap<TiposDeContactos, TiposDeContactosVM>();
                CreateMap<TiposDeContactosExt, TiposDeContactosVM>();
                CreateMap<GruposDeContactos, GruposDeContactosVM>();
                CreateMap<GruposDeContactosExt, GruposDeContactosVM>();
                CreateMap<LogLogins, LogLoginsVM>();
                CreateMap<LogLoginsExt, LogLoginsVM>();
                CreateMap<Recursos, RecursosVM>();
                CreateMap<RecursosExt, RecursosVM>();
                CreateMap<ReservasDeRecursos, ReservasDeRecursosVM>();
                CreateMap<ReservasDeRecursosExt, ReservasDeRecursosVM>();
                CreateMap<Notas, NotasVM>();
                CreateMap<NotasExt, NotasVM>();
                CreateMap<IconosCSS, IconosCSSVM>();
                CreateMap<IconosCSSExt, IconosCSSVM>();
                CreateMap<ReservasDeRecursos, ReservasDeRecursosVM>();
                CreateMap<ReservasDeRecursosExt, ReservasDeRecursosVM>();
               

            }

        }
        /// <summary>
        /// Recibe un Source y un Destination y chequea si existe un mapeo valido entre ellos.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public static bool ExisteMapa(Type source, Type dest)
        {
            return Mapper.Configuration.GetAllTypeMaps().Where(m => m.SourceType == source && m.DestinationType == dest).Count() > 0; 
        }

        public class CustomModelMetadataProvider : DataAnnotationsModelMetadataProvider
        {
            protected override ModelMetadata CreateMetadata(IEnumerable<System.Attribute> attributes, System.Type containerType, System.Func<object> modelAccessor, System.Type modelType, string propertyName)
            {
                var modelMetadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
                if (string.IsNullOrEmpty(propertyName)) return modelMetadata;

                if (modelType == typeof(String))
                    modelMetadata.ConvertEmptyStringToNull = false;

                return modelMetadata;
            }
        }
    }
}
