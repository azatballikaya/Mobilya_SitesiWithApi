using AutoMapper;
using Mobilya.Business.Abstract;
using Mobilya.Business.DTOs.AdviceDTOs;
using Mobilya.DataAccess.Abstract;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Concrete
{
    public class AdviceManager : IAdviceService
    {
        private readonly IAdviceDal _adviceDal;
        private readonly IMapper _mapper;

        public AdviceManager(IAdviceDal adviceDal, IMapper mapper)
        {
            _adviceDal = adviceDal;
            _mapper = mapper;
        }

        public void CreateAdvice(CreateAdviceDTO createAdviceDTO)
        {
            var advice = _mapper.Map<Advice>(createAdviceDTO);
            _adviceDal.Insert(advice);
        }

        public void DeleteAdvice(int id)
        {
            var advice=_adviceDal.GetById(id);
            _adviceDal.Delete(advice);
        }

        public ResultAdviceDTO GetAdviceById(int id)
        {
           var advice=_adviceDal.GetById(id);
            var dto=_mapper.Map<ResultAdviceDTO>(advice);
            return dto;
        }

        public List<ResultAdviceDTO> GetAllAdvices()
        {
           var advices=_adviceDal.GetAll();
            var dtos=_mapper.Map<List<ResultAdviceDTO>>(advices);
            return dtos;
        }
    }
}
