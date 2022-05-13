using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO;
using Transversal.Common;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ICustomersApplication
    {
        # region Metodos Sincronos
        Response<bool> Insert(CustomersDto customersDto);

        Response<bool> Update(CustomersDto customersDto);

        Response<bool> Delete(string customerid);

        Response<CustomersDto> Get(string customerid);

        Response<IEnumerable<CustomersDto>> GetAll();

        #endregion


        #region Metodos Asincronos
        Task<Response<bool>> InsertAsync(CustomersDto customersDto);

        Task<Response<bool>> UpdateAsync(CustomersDto customersDto);

        Task<Response<bool>> DeleteAsync(string customerid);

        Task<Response<CustomersDto>> GetAsync(string customerid);

        Task<Response<IEnumerable<CustomersDto>>> GetAllAsync();

        #endregion
    }
}
