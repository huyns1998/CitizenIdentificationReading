using System.Threading.Tasks;

namespace CitizenIdentificationReading.Services
{
    public interface ICccdReaderService
    {
        Task<ScanQrResponse?> ScanCccdAsync(string filePath);
    }
}
