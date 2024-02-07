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
        private RoundHandler _roundHandler;
        public ServerHandler()
        {
            _roundHandler = new RoundHandler();
        }
        public void OnRoundStarted()
        {
            Timing.CallDelayed(1f, () =>
            {
                _roundHandler.PrepareRound();
                // foreach (var VARIABLE in Door.List.Where(x=> x.IsElevator)) {
                //     VARIABLE.IsOpen = false;
                //     VARIABLE.DoorLockType = DoorLockType.AdminCommand;
                // }
                // Door.Get(DoorType.CheckpointGate).DoorLockType = DoorLockType.AdminCommand;
                // foreach (var player in Player.List) {
                //     Log.Info("Auu zmiana");
                //     player.Role.Set(RoleTypeId.Scp939, SpawnReason.Respawn);
                //     var room = Room.List.First(
                //         x => 
                //             x.Doors.Contains(Door.Get(DoorType.CheckpointGate)) && 
                //             (
                //                 x.Doors.Contains(Door.Get(DoorType.CheckpointEzHczA)) 
                //                 || 
                //                 x.Doors.Contains(Door.Get(DoorType.CheckpointEzHczB))
                //             )
                //     );
                //     player.Position = room.WorldPosition(Vector3.zero);
                // }
            });
        }
    }
}