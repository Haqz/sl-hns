using Exiled.API.Features;
using HideAndSeek.Handlers;
using Server = Exiled.Events.Handlers.Server;

namespace HideAndSeek
{
    public class HideAndSeek : Plugin<Config>
    {
        private static readonly HideAndSeek Singelton = new();
        public static HideAndSeek Instance => Singelton;
        private ServerHandler _serverHandler;

        public override void OnEnabled()
        {
            RegisterHandlers();
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            UnregisterHandlers();
            base.OnDisabled();
        }

        private void RegisterHandlers()
        {
            _serverHandler = new ServerHandler();
            Server.RoundStarted += _serverHandler.OnRoundStarted;


        }
        private void UnregisterHandlers()
        {

            Server.RoundStarted -= _serverHandler.OnRoundStarted;
            _serverHandler = null;
        }
        private void CheckConfig()
        {
            
        }
    }
}