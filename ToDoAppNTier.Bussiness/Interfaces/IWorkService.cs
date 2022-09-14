using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppNTier.Dtos.WorkDtos;

namespace ToDoAppNTier.Bussiness.Interfaces
{
    public interface IWorkService 
    { 
        Task<List<WorkListDto>> GetAll();
        Task<WorkListDto> GetById(int id);
        Task Create(WorkCreateDto dto);
        Task Remove(int id);
        Task Update(WorkUpdateDto dto);
    }
}
