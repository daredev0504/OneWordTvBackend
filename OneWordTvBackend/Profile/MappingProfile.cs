using OneWordTvBackend.Models;
using OneWordTvBackend.Models.Dto;
using AutoMapper;

namespace OneWordTvBackend.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            // source => target
            //oneWordPrograms

            CreateMap<OneWordTvProgram, OneWordProgramTvCreateDTO>();
            CreateMap<OneWordProgramTvCreateDTO, OneWordTvProgram>();
            CreateMap<OneWordProgramTvUpdateDTO, OneWordTvProgram>();
            CreateMap<OneWordTvProgram, OneWordProgramTvUpdateDTO>()
                 .ForMember(c => c.Day, opt =>
                    opt.MapFrom(d => d.Day.ToString()));

        }
    }
}
