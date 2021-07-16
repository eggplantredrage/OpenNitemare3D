namespace Nitemare3D
{
    public class HealthPickup : Pickup
    {
        public override void OnTouchPlayer()
        {
            Game.player.health += 5;
        }


    }
}