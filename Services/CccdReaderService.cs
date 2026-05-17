using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CitizenIdentificationReading.Constants;

namespace CitizenIdentificationReading.Services
{
    public class CccdReaderService : ICccdReaderService
    {
        private readonly HttpClient _httpClient;

        public CccdReaderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ScanQrResponse?> ScanCccdAsync(string filePath)
        {
            using (var content = new MultipartFormDataContent())
            {
                using (var fileStream = File.OpenRead(filePath))
                {
                    var fileContent = new StreamContent(fileStream);
                    string extension = Path.GetExtension(filePath).ToLower();
                    string mimeType = extension == ".png" ? "image/png" : "image/jpeg";
                    fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(mimeType);
                    content.Add(fileContent, "file", Path.GetFileName(filePath));

                    var response = await _httpClient.PostAsync(AppConstants.ScanCCCDApiUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadFromJsonAsync<ScanQrResponse>();
                    }
                    return null;
                }
            }
        }
    }
}
