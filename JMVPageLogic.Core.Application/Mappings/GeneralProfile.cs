using AutoMapper;
using JMVPageLogic.Core.Application.Dtos.Actividades;
using JMVPageLogic.Core.Application.Dtos.Biblioteca;
using JMVPageLogic.Core.Application.Dtos.Centro;
using JMVPageLogic.Core.Application.Dtos.Comunidad;
using JMVPageLogic.Core.Application.Dtos.Estatus;
using JMVPageLogic.Core.Application.Dtos.Usuarios;
using JMVPageLogic.Core.Domain.Entities;


namespace JMVPageLogic.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region usuarios
            CreateMap<Usuarios, UsuarioDto>()
                .ReverseMap();
            CreateMap<Usuarios, SaveUsuarioDto>()
                .ReverseMap();
            CreateMap<UsuarioDto, SaveUsuarioDto>()
                .ReverseMap();
            #endregion

            #region Estatus
            CreateMap<Estatus, EstatusDto>()
                .ReverseMap();
            CreateMap<Estatus, SaveEstatusDto>()
                .ReverseMap();
            CreateMap<EstatusDto, SaveEstatusDto>()
                .ReverseMap();
            #endregion

            #region Comunidad
            CreateMap<Comunidad, ComunidadDto>()
                .ReverseMap();
            CreateMap<Comunidad, SaveComunidadDto>()
                .ReverseMap();
            CreateMap<ComunidadDto, SaveComunidadDto>()
                .ReverseMap();
            #endregion

            #region Centro
            CreateMap<Centro, CentroDto>()
                .ReverseMap();
            CreateMap<Centro, SaveCentroDto>()
                .ReverseMap();
            CreateMap<CentroDto, SaveCentroDto>()
                .ReverseMap();
            #endregion

            #region Biblioteca
            CreateMap<Biblioteca, BibliotecaDto>()
                .ReverseMap();
            CreateMap<Biblioteca, SaveBibliotecaDto>()
                .ReverseMap();
            CreateMap<BibliotecaDto, SaveBibliotecaDto>()
                .ReverseMap();
            #endregion

            #region Actividades
            CreateMap<Actividades, ActividadesDto>()
                .ReverseMap();
            CreateMap<Actividades, SaveActividadesDto>()
                .ReverseMap();
            CreateMap<ActividadesDto, SaveActividadesDto>()
                .ReverseMap();
            #endregion
        }
    }
}
