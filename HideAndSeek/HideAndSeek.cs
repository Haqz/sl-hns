using Exiled.API.Features;
using HideAndSeek.Handlers;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace HideAndSeek
{
    public class HideAndSeek : Plugin<Config>
    {
        private static readonly HideAndSeek Singelton = new();
        public static HideAndSeek Instance => Singelton;
        private ServerHandler _serverHandler;
        private SeekerHandler _seekerHandler;

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
            _seekerHandler = new SeekerHandler();
            Server.RoundStarted += _serverHandler.OnRoundStarted;
            Player.Hurt += _seekerHandler.OnDamage;


        }
        private void UnregisterHandlers()
        {

            Server.RoundStarted -= _serverHandler.OnRoundStarted;
            _serverHandler = null;
            _seekerHandler = null;
        }
        private void CheckConfig()
        {
            
        }
    }
}