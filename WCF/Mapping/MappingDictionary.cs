using AutoMapper;
using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF.DCs;

namespace WCF.Mapping
{
    public class MappingDictionary
    {
        public static DictionaryDTO MappingDCtoDTO(DictionaryDC dictionaryDC)
        {
            MapperConfiguration configDCtoDTO = new MapperConfiguration(cfg => {
                cfg.CreateMap<DictionaryDC, DictionaryDTO>();
            });
            IMapper iMapper = configDCtoDTO.CreateMapper();
            return iMapper.Map<DictionaryDC, DictionaryDTO>(dictionaryDC);
        }
        public static DictionaryDC MappingDTOtoDC(DictionaryDTO dictionaryDTO)
        {
            MapperConfiguration configDTOtoDC = new MapperConfiguration(cfg => {
                cfg.CreateMap<DictionaryDTO, DictionaryDC>();
            });
            IMapper iMapper = configDTOtoDC.CreateMapper();
            return iMapper.Map<DictionaryDTO, DictionaryDC>(dictionaryDTO);
        }
    }
}