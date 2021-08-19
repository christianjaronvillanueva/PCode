using AutoMapper;

using Microsoft.EntityFrameworkCore;

using PCode.DataAccess.Models;
using PCode.DataAccess.Repository;
using PCode.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCode.Service
{
    public interface ICustomerService
    {
        Task<CustomerDTO> Get(int id);
        Task<IEnumerable<CustomerDTO>> GetAll();
        Task<CustomerDTO> Add(CustomerDTO customer);
        Task<CustomerDTO> Update(CustomerDTO customer);
        Task<CustomerDTO> Delete(CustomerDTO customer);

    }
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async  Task<CustomerDTO> Add(CustomerDTO customer)
        {
            var result = await _repo.Add(_mapper.Map<Customer>(customer)).ConfigureAwait(false);
            return _mapper.Map<CustomerDTO>(result);
        }

        public async Task<CustomerDTO> Delete(CustomerDTO customer)
        {
            var result = await _repo.Delete(_mapper.Map<Customer>(customer)).ConfigureAwait(false);
            return _mapper.Map<CustomerDTO>(result);
        }

        public async Task<CustomerDTO> Get(int id)
        {
            var result = await _repo.Get(id).ConfigureAwait(false);
            return _mapper.Map<CustomerDTO>(result);
        }

        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            var result = await _repo.GetAll().ToListAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<CustomerDTO>>(result);
        }

        public async Task<CustomerDTO> Update(CustomerDTO customer)
        {
            var result = await _repo.Update(_mapper.Map<Customer>(customer)).ConfigureAwait(false);
            return _mapper.Map<CustomerDTO>(result);
        }
    }
}
