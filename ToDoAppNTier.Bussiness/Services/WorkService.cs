using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppNTier.Bussiness.Interfaces;
using ToDoAppNTier.DataAccess.UnitOfWork;
using ToDoAppNTier.Dtos.WorkDtos;
using ToDoAppNTier.Entities.Domains;

namespace ToDoAppNTier.Bussiness.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUow _uow;

        public WorkService(IUow uow)
        {
            _uow = uow;
        }

        public async Task Create(WorkCreateDto dto)
        {
            await _uow.GetRepository<Work>().Create(new()
            {
                IsCompleted = dto.IsCompleted,
                Definition = dto.Definition
            });
            await _uow.SaveChanges();
        }

        public async Task<List<WorkListDto>> GetAll()
        {
            var list = await _uow.GetRepository<Work>().GetAll();
            var workList = new List<WorkListDto>();

            if (list != null && list.Count > 0)
            {
                foreach (var work in list)
                {
                    workList.Add(new()
                    {
                        Id = work.Id,
                        Definition = work.Definition,
                        IsCompleted = work.IsCompleted
                    });
                }
            }
            return workList;
        }

        public async Task<WorkListDto> GetById(int id)
        {
            var work = await _uow.GetRepository<Work>().GetByFilter(x=> x.Id == id);

            return new()
            {
                Definition = work.Definition,
                IsCompleted=work.IsCompleted
            };
        }

        public async Task Remove(int id)
        {
            _uow.GetRepository<Work>().Remove(id);
            await _uow.SaveChanges();
        }

        public async Task Update(WorkUpdateDto dto)
        {
            _uow.GetRepository<Work>().Update(new()
            {
                Definition = dto.Definition,
                Id = dto.Id,
                IsCompleted = dto.IsCompleted
            });

            await _uow.SaveChanges();
        }
    }
}
