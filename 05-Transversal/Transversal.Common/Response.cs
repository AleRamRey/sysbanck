using FluentValidation.Results;
using System.Collections.Generic;

namespace Transversal.Common
{
    public class Response<T> //Concentra toda la informacion de los diferentes recursos de nuestras respuesta de API
    {
        //Almacenara respuesta del insert, upd
        public T Data { get; set; }
        //Almacenara el estado de la ejecucion 
        public bool IsSuccess { get; set; }
        //Almacenara informacion afirmativa o excepciones de error 
        public string Message { get; set; }
        //Validacion con librerira FluentValidation
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }

}
