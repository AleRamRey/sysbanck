using System;
using Domain.Entity;
using Domain.Interface;
using Infraestructura.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Core
{
    public class CustomersDomain : ICustomersDomain
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomersDomain(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        #region Metodos Sincronos
        public bool Insert(Customers customer)
        {
            //Aqui va toda la logica del negocio
            return _customersRepository.Insert(customer);
        }

        public bool Update(Customers customer)
        {
            //Aqui va toda la logica del negocio
            return _customersRepository.Update(customer);
        }

        public bool Delete(string customerid)
        {
            //Aqui va toda la logica del negocio
            return _customersRepository.Delete(customerid);
        }

        public Customers Get(string customerid)
        {
            //Aqui va toda la logica del negocio
            return _customersRepository.Get(customerid);
        }

        public IEnumerable<Customers> GetAll()
        {
            //Aqui va toda la logica del negocio
            return _customersRepository.GetAll();
        }

        #endregion

        #region Metodos Asincronos

        public async Task<bool> InsertAsync(Customers customer)
        {
            //Aqui va toda la logica del negocio
            return await _customersRepository.InsertAsync(customer);
        }

        public async Task<bool> UpdateAsync(Customers customer)
        {
            //Aqui va toda la logica del negocio
            return await _customersRepository.UpdateAsync(customer);
        }

        public async Task<bool> DeleteAsync(string customerid)
        {
            //Aqui va toda la logica del negocio
            return await _customersRepository.DeleteAsync(customerid);
        }

        public async Task<Customers> GetAsync(string customerid)
        {
            //Aqui va toda la logica del negocio
            return await _customersRepository.GetAsync(customerid);
        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            //Aqui va toda la logica del negocio
            return await _customersRepository.GetAllAsync();
        }

        #endregion
    }
}
