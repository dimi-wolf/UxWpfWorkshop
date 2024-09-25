using UxWpfWorkshop.Services.DTOs;

namespace UxWpfWorkshop.Services.Impl
{
    public class DataService : IDataService
    {
        public async Task<DataDto> GetDataAsync()
        {
            await Task.Delay(3000).ConfigureAwait(true);

            return new DataDto(1, "Some Data", "Here is your data.");
        }
    }
}
