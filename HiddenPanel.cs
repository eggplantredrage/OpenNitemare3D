namespace Nitemare3D
{
    public class HiddenPanel : Entity, IUsable
    {
        public void OnUse()
        {
            SoundEffect.PlaySound(SoundConsts.HIDDENPANEL_OPEN);
        }
    }
}