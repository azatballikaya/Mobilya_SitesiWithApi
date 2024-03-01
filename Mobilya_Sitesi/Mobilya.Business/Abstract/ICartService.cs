using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobilya.Business.DTOs.CartDTOs;




namespace Mobilya.Business.Abstract
{
    public interface ICartService
    {
        void InitializeCart(int userId);
        ResultCartDTO GetCartByUserId(int userId);


    }
}
