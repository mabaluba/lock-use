using AutoMapper;
using Service.Models;
using Service.Models.Dto;

namespace Service.Configuration
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<TransactionDto, Transaction>();
        }
    }
}