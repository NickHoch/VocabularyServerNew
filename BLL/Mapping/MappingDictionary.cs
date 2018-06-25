using AutoMapper;
using BLL.DTOs;
using DAL;

namespace BLL.Mapping
{
    public class MappingDictionary
    {
        public static Dictionary MappingDTOtoDM(DictionaryDTO dictionaryDTO)
        {
            MapperConfiguration configDTOtoDM = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DictionaryDTO, Dictionary>();
            });
            IMapper iMapper = configDTOtoDM.CreateMapper();
            return iMapper.Map<DictionaryDTO, Dictionary>(dictionaryDTO);
        }
        public static DictionaryDTO MappingDMtoDTO(Dictionary dictionary)
        {
            MapperConfiguration configDMtoDTO = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Dictionary, DictionaryDTO>();
            });
            IMapper iMapper = configDMtoDTO.CreateMapper();
            return iMapper.Map<Dictionary, DictionaryDTO>(dictionary);
        }
    }
}
