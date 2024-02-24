using AutoMapper;
using Mobilya.Business.Abstract;
using Mobilya.Business.DTOs.AdminDTOs;
using Mobilya.DataAccess.Abstract;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;
        private readonly IMapper _mapper;
        public AdminManager(IAdminDal adminDal, IMapper mapper)
        {
            _adminDal = adminDal;
            _mapper = mapper;
        }

        public void CreateAdmin(CreateAdminDTO createAdminDTO)
        {
            var admin=_mapper.Map<Admin>(createAdminDTO);
            _adminDal.Insert(admin);
        }

        public void DeleteAdmin(int id)
        {

            _adminDal.Delete(GetAdmin(id));
        }

        public Admin GetAdmin(int id)
        {
            return _adminDal.GetById(id);
        }

        public LoginAdminDTO? GetAdminByLogin(LoginAdminDTO loginAdminDto)
        {
            Admin admin = _mapper.Map<Admin>(loginAdminDto);
           var admin2=_adminDal.Get(x=>x.UserName==loginAdminDto.UserName && x.Password==loginAdminDto.Password);
            if(admin2==null)
                return null;
            return _mapper.Map<LoginAdminDTO>(admin2);
        }

        public List<Admin> GetAdminList()
        {
           return _adminDal.GetAll();
        }

        public void UpdateAdmin(UpdateAdminDTO updateAdminDTO)
        {
            var admin=_mapper.Map<Admin>(updateAdminDTO);
            _adminDal.Update(admin);
        }
    }
}
