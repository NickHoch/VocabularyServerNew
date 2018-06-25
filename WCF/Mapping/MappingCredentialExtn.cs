using AutoMapper;
using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF.DCs;

namespace WCF.Mapping
{
    public class MappingCredentialExtn
    {
        public static CredentialExtnDTO MappingDCtoDTO(CredentialExtnDC credentialDC)
        {
            MapperConfiguration configDCtoDTO = new MapperConfiguration(cfg => {
                cfg.CreateMap<CredentialExtnDC, CredentialExtnDTO>();
            });
            IMapper iMapper = configDCtoDTO.CreateMapper();
            return iMapper.Map<CredentialExtnDC, CredentialExtnDTO>(credentialDC);
        }
    }
}