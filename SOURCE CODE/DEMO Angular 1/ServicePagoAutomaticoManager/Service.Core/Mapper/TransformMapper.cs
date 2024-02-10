using Domain;
using Service.Core.DataContracts.DTO.Output;


namespace Service.Core.Mapper
{
    public interface ITransformMapper
    {
        TDto TransformToDto<TDomain, TDto>(TDomain domain);
        TDomain TransformToDomain<TDto, TDomain>(TDto dto);
    }

    public class TransformMapper : ITransformMapper
    {
        public TransformMapper()
        {
            ToDomainMaps();
            ToDTOMaps();
        }

        #region IMapper Members

        public TDto TransformToDto<TDomain, TDto>(TDomain domain)
        {
            return AutoMapper.Mapper.Map<TDomain, TDto>(domain);
        }

        public TDomain TransformToDomain<TDto, TDomain>(TDto dto)
        {
            return AutoMapper.Mapper.Map<TDto, TDomain>(dto);
        }

        #endregion

        private void ToDomainMaps()
        {
            AutoMapper.Mapper.CreateMap<AbmTabla, AbmTablaDto>();
            AutoMapper.Mapper.CreateMap<atb_abm_tabla, atb_abm_tablaDto>();
        }

        private void ToDTOMaps()
        {

            AutoMapper.Mapper.CreateMap<AbmTablaDto, AbmTabla>();
            AutoMapper.Mapper.CreateMap<atb_abm_tablaDto, atb_abm_tabla>();
        }
    }
}