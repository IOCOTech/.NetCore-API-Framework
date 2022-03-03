using APIFramework.Models.AppSettings;

namespace APIFramework.Interfaces.API
{
    public interface IAppSettings
    {
        string ApplicationMonitoringKey { get; }
        Authentication Authentication { get; }

    }
}
