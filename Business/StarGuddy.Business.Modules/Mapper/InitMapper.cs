﻿
using StarGuddy.Api.Models.Account;
using StarGuddy.Api.Models.Dto;
using StarGuddy.Api.Models.Files;
using StarGuddy.Api.Models.Profile;
using StarGuddy.Api.Models.Search;
using StarGuddy.Api.Models.UserJobs;
using StarGuddy.Data.Entities;

namespace StarGuddy.Business.Modules.Mapper
{
    public class InitMapper : AutoMapper.Profile
    {
        public InitMapper()
        {
            this.InitAutoMapper();            
        }

        private void InitAutoMapper()
        {
            CreateMap<Accents, AccentsDto>().ReverseMap(); 
            CreateMap<Language, LanguageDto>().ReverseMap();
            CreateMap<JobSubGroup, AuditionsAndJobsGroupDto>().ReverseMap();
            CreateMap<UserModeling, UserModelingModel>().ReverseMap();
            CreateMap<UserSettings, UserSettingDto>().ReverseMap();
            CreateMap<JobGroup, JobGroupModel>().ReverseMap();
            CreateMap<PhysicalAppearance, PhysicalAppearanceModal>().ReverseMap();

            CreateMap<User, AppUserDto>().ReverseMap();
            CreateMap<UserAddress, AddressDto>().ReverseMap();
            CreateMap<UserDetail, UserDetailDto>().ReverseMap();
            CreateMap<UserEmails, EmailDto>().ReverseMap();
            CreateMap<UserPhones, PhoneDto>().ReverseMap();
            CreateMap<UserProfileHeader, ProfileHeader>().ReverseMap();

            CreateMap<UserDetailModel, UserDetail>().ReverseMap();
            CreateMap<ImageModel, UserImage>().ReverseMap();

            CreateMap<JobGroup, TalentGroup>().ReverseMap();  
        }
    }
}
