namespace q5_risk_api.Interfaces;

public interface IExternalService
{
    Task<HttpResponse> PostAsync<T>();

    Task<HttpResponse> GetAsync<T>();

    Task<HttpResponse> PatchAsync<T>();
}