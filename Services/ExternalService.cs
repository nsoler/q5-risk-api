using q5_risk_api.Interfaces;

namespace q5_risk_api.Services;

public class ExternalService : IExternalService
{
    public Task<HttpResponse> PostAsync<T>()
    {
        throw new NotImplementedException();
    }

    public Task<HttpResponse> GetAsync<T>()
    {
        throw new NotImplementedException();
    }

    public Task<HttpResponse> PatchAsync<T>()
    {
        throw new NotImplementedException();
    }
}