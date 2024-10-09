using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Presentation.Dtos;
using Presentation.Interface;
using Presentation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class CollectionScheduleService : ICollectionScheduleService
    {
        private readonly ICollectionScheduleDbContext _context;

        public CollectionScheduleService(ICollectionScheduleDbContext context)
        {
            _context = context;
        }


        public async Task<ResponseModel<bool>> Register(CollectionScheduleDto model)
        {
            try
            {
                if (model == null)
                {
                    return new("Por favor, insira os dados.", false);
                }

                Address address = new()
                {
                    Cep = model.Address.Cep,
                    Street = model.Address.Street,
                    State = model.Address.State,
                    City = model.Address.City,
                    Number = model.Address.Number,
                    Complement = model.Address.Complement
                };

                await _context.Addresses.AddAsync(address);

                var user = await _context.Users.Where(x => x.Id == model.UserId).FirstOrDefaultAsync();

                if (user == null)
                {
                    return new("Por favor, insira um usuário correto.", false);
                }

                CollectionSchedule data = new()
                {
                    CollectionDate = model.CollectionDate,
                    UserId = model.UserId,
                    WasteType = model.WasteType,
                    CollectionScheduleStatus = model.CollectionScheduleStatus,
                    Notes = model.Notes,
                    IsRecurring = model.IsRecurring,
                    RecurringInterval = model.RecurringInterval,
                    ConfirmationDate = model.ConfirmationDate,
                    CollectionWindowEnd = model.CollectionWindowEnd,
                    CollectionWindowStart = model.CollectionWindowStart,
                    Address = address,
                    User = user
                };

                await _context.CollectionSchedules.AddAsync(data);
                await _context.SaveChangesAsync();

                return new($"Coleta cadastrada com sucesso, id: {data.Id}", true);
            }
            catch (Exception ex)
            {
                return new($"Ocorreu um erro ao cadastrar a coleta: {ex.Message}", false);
            }
        }

        public async Task<ResponseModel<CollectionScheduleDto>> GetById(int id)
        {
            try
            {
                var data = await _context.CollectionSchedules
                    .Include(cs => cs.Address)
                    .Include(cs => cs.User)
                    .Where(cs => cs.Id == id)
                    .Select(x => new CollectionScheduleDto() { WasteType = x.WasteType })
                    .FirstOrDefaultAsync();

                if (data == null)
                {
                    return new("Coleta não encontrada.", null, false);
                }

                return new("Coleta encontrada com sucesso.", data, true);
            }
            catch (Exception ex)
            {
                return new($"Ocorreu um erro ao obter a coleta: {ex.Message}", null, false);
            }
        }

        public async Task<ResponseModel<List<CollectionScheduleDto>>> GetAll()
        {
            try
            {
                var data = await _context.CollectionSchedules
                    .Include(cs => cs.Address) 
                    .Select(x=> new CollectionScheduleDto()
                    {
                        UserId = x.UserId,
                    })
                    .ToListAsync();

                return new("Coletas obtidas com sucesso.", data, true);
            }
            catch (Exception ex)
            {
                return new($"Ocorreu um erro ao obter as coletas: {ex.Message}", null, false);
            }
        }

        public async Task<ResponseModel<bool>> Update(int id, CollectionScheduleDto model)
        {
            try
            {
                var data = await _context.CollectionSchedules
                    .Include(cs => cs.Address)
                    .FirstOrDefaultAsync(cs => cs.Id == id);

                if (data == null)
                {
                    return new("Coleta não encontrada.", false);
                }

                data.CollectionDate = model.CollectionDate;
                data.UserId = model.UserId;
                data.WasteType = model.WasteType;
                data.CollectionScheduleStatus = model.CollectionScheduleStatus;
                data.Notes = model.Notes;
                data.IsRecurring = model.IsRecurring;
                data.RecurringInterval = model.RecurringInterval;
                data.ConfirmationDate = model.ConfirmationDate;
                data.CollectionWindowEnd = model.CollectionWindowEnd;
                data.CollectionWindowStart = model.CollectionWindowStart;

                data.Address.Cep = model.Address.Cep;
                data.Address.Street = model.Address.Street;
                data.Address.State = model.Address.State;
                data.Address.City = model.Address.City;
                data.Address.Number = model.Address.Number;
                data.Address.Complement = model.Address.Complement;

                _context.CollectionSchedules.Update(data);
                await _context.SaveChangesAsync();

                return new("Coleta atualizada com sucesso.", true);
            }
            catch (Exception ex)
            {
                return new($"Ocorreu um erro ao atualizar a coleta: {ex.Message}", false);
            }
        }

        public async Task<ResponseModel<bool>> Delete(int id)
        {
            try
            {
                var data = await _context.CollectionSchedules
                    .FirstOrDefaultAsync(cs => cs.Id == id);

                if (data == null)
                {
                    return new("Coleta não encontrada.", false);
                }

                _context.CollectionSchedules.Remove(data);
                await _context.SaveChangesAsync();

                return new("Coleta deletada com sucesso.", true);
            }
            catch (Exception ex)
            {
                return new($"Ocorreu um erro ao deletar a coleta: {ex.Message}", false);
            }
        }
    }
}
