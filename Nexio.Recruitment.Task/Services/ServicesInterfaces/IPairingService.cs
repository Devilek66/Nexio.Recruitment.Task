using Nexio.Recruitment.Task.Models;

namespace Nexio.Recruitment.Task.Services.ServicesInterfaces
{
    interface IPairingService
    {
        bool DoTheyMatch(PersonModel personModel);
    }
}
