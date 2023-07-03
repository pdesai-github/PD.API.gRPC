using gRPC.Server.Protos;
using Grpc.Core;

namespace gRPC.Server.Services
{
    public class MeterReading : MeterReadingService.MeterReadingServiceBase
    {
        public override Task<StatusMessage> AddReading(ReadingMessage request, ServerCallContext context)
        {
           var result = new StatusMessage();
            result.Success = true;

            return Task.FromResult(result);
        }
    }
}
