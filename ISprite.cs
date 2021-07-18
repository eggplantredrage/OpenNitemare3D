namespace Nitemare3D
{
    public interface ISprite
    {
        int spriteIndex{get;set;}
        Vec2 spritePosition{get;set;}
        bool visible{get;set;}
        float yOffset{get;set;}
    }
}