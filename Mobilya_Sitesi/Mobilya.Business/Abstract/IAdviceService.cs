using Mobilya.Business.DTOs.AdviceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Abstract
{
    public interface IAdviceService
    {
        void CreateAdvice(CreateAdviceDTO createAdviceDTO);
        void DeleteAdvice(int id);
        ResultAdviceDTO GetAdviceById(int id);
        List<ResultAdviceDTO> GetAllAdvices();

        
    }
}
