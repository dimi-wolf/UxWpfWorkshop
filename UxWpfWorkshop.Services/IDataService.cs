using UxWpfWorkshop.Services.DTOs;

namespace UxWpfWorkshop.Services
{
    public interface IDataService
    {
        Task<DataDto> GetDataAsync();
    }
}
