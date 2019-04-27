using Nexio.Recruitment.Task.Models.ViewModels;

namespace Nexio.Recruitment.Task.Services.ServicesInterfaces
{
    public interface IPairingService
    {
        bool DoTheyMatch(PersonViewModel woman, PersonViewModel man);
    }
}
