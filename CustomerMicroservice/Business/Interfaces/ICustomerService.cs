using CustomerMicroservice.Business.Dtos;

namespace CustomerMicroservice.Business.Interfaces
{
    public interface ICustomerService
    {
        int Create(CustomerDto customerDto);
        IEnumerable<CustomerDto> GetAll(); 
    }
}
