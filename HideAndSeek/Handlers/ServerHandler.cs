using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using MEC;
using PlayerRoles;
using System.Linq;
using UnityEngine;

namespace HideAndSeek.Handlers
{
    public class ServerHandler
    {
        private RoundHandler _roundHandler = new();
        public void OnRoundStarted()
        {
            Timing.CallDelayed(1f, () => _roundHandler.PrepareRound());
            Timing.CallDelayed(10f, () => _roundHandler.StartRound());
        }
    }
}