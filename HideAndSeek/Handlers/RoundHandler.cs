using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HideAndSeek.Handlers
{
    public class RoundHandler
    {
        public List<Player> Seekers = new List<Player>();
        public int SeekerMax;
        public void StartRound()
        {
            throw new NotImplementedException();
        }
        public void PrepareRound()
        {
            PreparePlayers();
            PrepareDoors();
        }
        public void EndRound() => throw new NotImplementedException();
        public void WinRound() => throw new NotImplementedException();


        public void PreparePlayers()
        {
            
            SeekerMax = ((int)Math.Floor(Player.List.Count * 0.1f) <= 0)? 1 : (int)Math.Floor(Player.List.Count * 0.1f);
            Random random = new Random();
            int SeekerCurrent = 0;
            while (SeekerCurrent < SeekerMax) {
                int needle = random.Next(0, Player.List.Count);
                Seekers.Add(Player.List.ElementAt(needle));
                SeekerCurrent++;
            }
            foreach (var player in Player.List) {
                player.Role.Set(RoleTypeId.Tutorial, SpawnReason.Respawn);
            }
            
        }

        public void PrepareDoors()
        {
            foreach (var VARIABLE in Door.List.Where(x=> x.IsElevator)) {
                VARIABLE.IsOpen = false;
                VARIABLE.DoorLockType = DoorLockType.AdminCommand;
            }
            foreach (var VARIABLE in Door.List.Where(x=> x.IsGate)) {
                VARIABLE.IsOpen = false;
                VARIABLE.DoorLockType = DoorLockType.AdminCommand;
            }
        }
    }
}