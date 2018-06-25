using AutoMapper;
using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF.DCs;

namespace WCF.Mapping
{
    public class MappingDictionaryExtn
    {
        public static DictionaryExtnDTO MappingDCtoDTO(DictionaryExtnDC dictionaryDC)
        {
            MapperConfiguration configDCtoDTO = new MapperConfiguration(cfg => {
                cfg.CreateMap<DictionaryExtnDC, DictionaryExtnDTO>();
            });
            IMapper iMapper = configDCtoDTO.CreateMapper();
            return iMapper.Map<DictionaryExtnDC, DictionaryExtnDTO>(dictionaryDC);
        }
        public static DictionaryExtnDC MappingDTOtoDC(DictionaryExtnDTO dictionaryDTO)
        {
            MapperConfiguration configDTOtoDC = new MapperConfiguration(cfg => {
                cfg.CreateMap<DictionaryExtnDTO, DictionaryExtnDC>();
            });
            IMapper iMapper = configDTOtoDC.CreateMapper();
            return iMapper.Map<DictionaryExtnDTO, DictionaryExtnDC>(dictionaryDTO);
        }
    }
}