using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using Exiled.API.Features.Spawn;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace HideAndSeek.Handlers
{
    public class RoundHandler
    {
        public List<Player> Seekers = new List<Player>();
        public List<Player> Hiders = new List<Player>();
        public List<Vector3> SeekerSpawnpoints = new List<Vector3>();
        public List<Vector3> HidersSpawnpoints = new List<Vector3>();
        public int SeekerMax;
        public void StartRound()
        {
            TeleportPlayers();
            EnableSeekers();
        }
        public void PrepareRound()
        {
            PreparePlayers();
            PrepareDoors();
            PrepareSpawns();
        }
        public void EndRound() => throw new NotImplementedException();
        public void WinRound() => throw new NotImplementedException();

        public void EnableSeekers()
        {
            foreach (var player in Seekers) {
                player.Role.Set(RoleTypeId.Scp939, SpawnReason.None);
            }
        }
        public void TeleportPlayers()
        {
            foreach (var player in Hiders) {
                player.Position = HidersSpawnpoints.RandomItem();
            }
            foreach (var player in Seekers) {
                player.Position = SeekerSpawnpoints.RandomItem() + new Vector3(1, 1, 1);
            }
        }
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
            Hiders = Player.List.Except(Seekers).ToList();

        }
        
        public void PrepareSpawns()
        {
            SeekerSpawnpoints = Door.List.Where(x=> x.IsCheckpoint &&  x.Type is DoorType.CheckpointEzHczA or DoorType.CheckpointEzHczB).Select(x=>x.Position).ToList();
            HidersSpawnpoints.Add(RoleTypeId.Scp939.GetRandomSpawnLocation().Position);
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