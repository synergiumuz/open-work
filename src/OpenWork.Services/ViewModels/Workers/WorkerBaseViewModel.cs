using OpenWork.Domain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace OpenWork.Services.ViewModels.Workers;

public class WorkerBaseViewModel
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public DateTime LastSeen { get; set; }

    //public string Rating { get; set; } = string.Empty;

    public static implicit operator WorkerBaseViewModel(Worker entity)
    {
        return new WorkerBaseViewModel()
        {
            Name = entity.Name,
            Surname = entity.Surname,
            LastSeen = entity.LastSeen,
        };
    }
}
