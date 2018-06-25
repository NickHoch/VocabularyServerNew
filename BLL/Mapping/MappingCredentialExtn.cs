using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapping
{
    public class MappingCredentialExtn
    {
        public static CredentialExtn MappingDTOtoDM(CredentialExtnDTO credentialExtnDTO)
        {
            MapperConfiguration configDTOtoDM = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CredentialExtnDTO, CredentialExtn>();
            });
            IMapper iMapper = configDTOtoDM.CreateMapper();
            return iMapper.Map<CredentialExtnDTO, CredentialExtn>(credentialExtnDTO);
        }
    }
}
