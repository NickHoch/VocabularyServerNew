using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapping
{
    public class MappingDictionaryExtn
    {
        public static DictionaryExtn MappingDTOtoDM(DictionaryExtnDTO dictionaryDTO)
        {
            MapperConfiguration configDTOtoDM = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DictionaryExtnDTO, DictionaryExtn>();
            });
            IMapper iMapper = configDTOtoDM.CreateMapper();
            return iMapper.Map<DictionaryExtnDTO, DictionaryExtn>(dictionaryDTO);
        }
        public static DictionaryExtnDTO MappingDMtoDTO(DictionaryExtn dictionary)
        {
            MapperConfiguration configDMtoDTO = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DictionaryExtn, DictionaryExtnDTO>();
            });
            IMapper iMapper = configDMtoDTO.CreateMapper();
            return iMapper.Map<DictionaryExtn, DictionaryExtnDTO>(dictionary);
        }
    }
}
