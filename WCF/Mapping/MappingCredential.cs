using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF.DCs;
using BLL.DTOs;

namespace WCF.Mapping
{
    public class MappingCredential
    {
        public static CredentialDTO MappingDCtoDTO(CredentialDC credentialDC)
        {
            MapperConfiguration configDCtoDTO = new MapperConfiguration(cfg => {
                cfg.CreateMap<CredentialDC, CredentialDTO>();
            });
            IMapper iMapper = configDCtoDTO.CreateMapper();
            return iMapper.Map<CredentialDC, CredentialDTO>(credentialDC);
        }
    }
}