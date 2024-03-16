namespace Hackathon.Backend.NETT.Core.Application.CreateVideo
{
    public interface ICreateVideoCommand
    {
        Task<CreateVideoResponse> Execute(CreateVideoRequest request);
    }
}
