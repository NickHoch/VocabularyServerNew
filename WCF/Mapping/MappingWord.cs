using AutoMapper;
using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF.DCs;

namespace WCF.Mapping
{
    public class MappingWord
    {
        public static WordDC MappingDTOtoDC(WordDTO wordDTO)
        {
            MapperConfiguration configDTOtoDC = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WordDTO, WordDC>().MaxDepth(2);
                cfg.CreateMap<DictionaryExtnDTO, DictionaryExtnDC>().MaxDepth(2);
            });
            configDTOtoDC.AssertConfigurationIsValid();
            IMapper iMapper = configDTOtoDC.CreateMapper();
            return iMapper.Map<WordDTO, WordDC>(wordDTO);
        }
        public static WordDTO MappingDCtoDTO(WordDC wordDC)
        {
            MapperConfiguration configDCtoDTO = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WordDC, WordDTO>().MaxDepth(2);
                cfg.CreateMap<DictionaryExtnDC, DictionaryExtnDTO>().MaxDepth(2);
            });
            configDCtoDTO.AssertConfigurationIsValid();
            IMapper iMapper = configDCtoDTO.CreateMapper();
            return iMapper.Map<WordDC, WordDTO>(wordDC);
        }
    }
}