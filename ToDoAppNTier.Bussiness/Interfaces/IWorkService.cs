using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppNTier.Common.ResponseObjects;
using ToDoAppNTier.Dtos.Interfaces;
using ToDoAppNTier.Dtos.WorkDtos;

namespace ToDoAppNTier.Bussiness.Interfaces
{
    public interface IWorkService 
    { 
        Task<IResponse<List<WorkListDto>>> GetAll();
        Task<IResponse<IDto>> GetById<IDto>(int id); //Normalde task WorkListDto tipindeydi ancak sonradan IDto interface'ini WorkListDto'e implement ettik
        Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto);
        Task<IResponse> Remove(int id);
        Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto);
    }
}
