using Kamban.Application.Commands.Estados;
using Kamban.Application.Commands.Tareas;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace Kamban.Maui.Services
{
   public class KambanService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _url;

        //Inyectar HttpClient a través del constructor
        public KambanService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _url = "Tareas/";
        }

        public async Task<List<ObtenerTareaCommandResponse>> ObtenerAsync()
        => await GetTAsync<List<ObtenerTareaCommandResponse>>(_url);

        public async Task<List<GetEstadosCommandResponse>> ObtenerEstados()
        => await GetTAsync<List<GetEstadosCommandResponse>>("Estados");

        public async Task<AgregarTareaCommandResponse> AgregarTareaAsync(AgregarTareaCommand tarea)
            => await EnviarPorPostAsync<AgregarTareaCommandResponse>(tarea, _url);

        private async Task<T> GetTAsync<T>(string url)
        {
            HttpClient httpClient;
            HttpRequestMessage request;
            HttpResponseMessage response;

            httpClient = _httpClientFactory.CreateClient();
            request = new HttpRequestMessage(HttpMethod.Get, url);
            response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            else
                throw new Exception($"{response.StatusCode}, {await response.Content.ReadAsStringAsync()}");
        }

        protected async Task<T> EnviarPorPostAsync<T>(object data, string endpoint)
        {
            HttpRequestMessage request;
            HttpResponseMessage response;

            using HttpClient httpClient = _httpClientFactory.CreateClient();
            request = new HttpRequestMessage(HttpMethod.Post, endpoint);
            request.Content = new StringContent(JsonConvert.SerializeObject(data), null, "application/json");
            //if (!string.IsNullOrEmpty(_configuracion.ObtenerToken()))
            //    request.Headers.Add("Authorization", $"Bearer {_configuracion.ObtenerToken()}");
            response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            else
                //return default;
                throw new Exception($"StatusCode: {response.StatusCode}" + await response.Content.ReadAsStringAsync());
        }
    }
}