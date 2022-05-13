using System;
using AutoMapper;
using Application.DTO;
using Application.Interface;
using Domain.Entity;
using Domain.Interface;
using Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Application.Main
{
    public class CustomersApplication : ICustomersApplication
    {
        private readonly ICustomersDomain _customersDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomersApplication> _logger;

        public CustomersApplication(ICustomersDomain customersDomain, IMapper mapper, IAppLogger<CustomersApplication> logger)
        {
            _customersDomain = customersDomain;
            _mapper = mapper;
            _logger = logger;
        }

        # region Metodos Sincronos
        public Response<bool> Insert(CustomersDto customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var costumer = _mapper.Map<Customers>(customersDto);
                response.Data = _customersDomain.Insert(costumer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Update(CustomersDto customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var costumer = _mapper.Map<Customers>(customersDto);
                response.Data = _customersDomain.Update(costumer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización exitosa!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public Response<bool> Delete(string customerid)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _customersDomain.Delete(customerid);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación exitosa!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<CustomersDto> Get(string customerid)
        {
            var response = new Response<CustomersDto>();
            try
            {
                var customer = _customersDomain.Get(customerid);
                response.Data = _mapper.Map<CustomersDto>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<IEnumerable<CustomersDto>> GetAll()
        {
            var response = new Response<IEnumerable<CustomersDto>> ();
            try
            {
                var customer = _customersDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomersDto>> (customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa!";
                    _logger.LogInformation("Consulta exitosa!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        #endregion


        #region Metodos Asincronos
        public async Task<Response<bool>> InsertAsync(CustomersDto customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var costumer = _mapper.Map<Customers>(customersDto);
                response.Data = await _customersDomain.InsertAsync(costumer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(CustomersDto customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var costumer = _mapper.Map<Customers>(customersDto);
                response.Data = await _customersDomain.UpdateAsync(costumer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización exitosa!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(string customerid)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _customersDomain.DeleteAsync(customerid);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación exitosa!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<CustomersDto>> GetAsync(string customerid)
        {
            var response = new Response<CustomersDto>();
            try
            {
                var customer = await _customersDomain.GetAsync(customerid);
                response.Data =  _mapper.Map<CustomersDto>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<CustomersDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomersDto>>();
            try
            {
                var customer = await _customersDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomersDto>>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        #endregion

    }
}
