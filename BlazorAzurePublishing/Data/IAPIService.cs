namespace BlazorAzurePublishing.Data
{
    public interface IAPIService
    {

        Task<List<T>?> GetAllFromApiAsync<T>() where T : class;
    }
}