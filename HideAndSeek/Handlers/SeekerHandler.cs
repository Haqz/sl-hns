using Exiled.Events.EventArgs.Player;
using Exiled.Events.Handlers;

namespace HideAndSeek.Handlers
{
    public class SeekerHandler {
        public void OnDamage(HurtEventArgs ev)
        {
            if (ev.Player.IsHuman && ev.Attacker.IsScp) {
                var ahp = ev.Player.ArtificialHealth;
                ev.Player.Health -= ev.Amount;
                ev.Player.ArtificialHealth = ahp;
            }
        }
    }
}