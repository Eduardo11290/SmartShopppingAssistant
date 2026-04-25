using SmartShoppingAssistant.BussinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BussinessLogic.Services.Interfaces
{
    public interface IProductService
    {
        public Task<ProductGetDTO> GetByIdAsync(int id);

    }
}
