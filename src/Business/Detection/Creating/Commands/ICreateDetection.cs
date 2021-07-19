namespace Business.Detection.Creating.Commands
{
    using Business.Detection.Common.Commands;
    using Business.Detection.Common.Models;
    using Business.Detection.Creating.Models;

    public interface ICreateDetection : ICommand<MCreateDetection, MDetection>
    {
    }
}
