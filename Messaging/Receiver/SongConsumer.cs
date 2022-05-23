using MassTransit;
using SharedLibrary;

namespace Receiver
{
    internal class SongConsumer: IConsumer<Song>
    {
        private ILogger<SongConsumer> _logger;

        public SongConsumer(ILogger<SongConsumer> logger)
        {
            this._logger = logger;
        }

        public async Task Consume(ConsumeContext<Song> context)
        {
            _logger.LogInformation($"Song recieved : {context.Message.title} by {context.Message.artist}");
        }
    }
}
