namespace ListaComprasCasaNova.Domain.Exceptions;

public class BusinessException : Exception
{
        public BusinessException(string menssage)
        : base(menssage)
    {   
    }
}
