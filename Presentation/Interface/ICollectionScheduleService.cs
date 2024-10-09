using Domain.Entities;
using Presentation.Dtos;
using Presentation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interface
{
    public interface ICollectionScheduleService
    {
        Task<ResponseModel<bool>> Register(CollectionScheduleDto model);
        Task<ResponseModel<CollectionScheduleDto>> GetById(int id);
        Task<ResponseModel<List<CollectionScheduleDto>>> GetAll();
        Task<ResponseModel<bool>> Update(int id, CollectionScheduleDto model);
        Task<ResponseModel<bool>> Delete(int id);
    }
}
