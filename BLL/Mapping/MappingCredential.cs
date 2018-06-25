using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using DAL;

namespace BLL.Mapping
{
    public class MappingCredential
    {
        public static Credential MappingDTOtoDM(CredentialDTO credentialDTO)
        {
            MapperConfiguration configDTOtoDM = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CredentialDTO, Credential>();
            });
            IMapper iMapper = configDTOtoDM.CreateMapper();
            return iMapper.Map<CredentialDTO, Credential>(credentialDTO);
        }
    }
}
