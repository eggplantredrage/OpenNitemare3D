#include "r_sprite.h"
void R_GetSpriteSize(byte* width, byte* height, struct r_sprite* sprite)
{
    width = sprite->width;
    height = sprite->height;
}

struct r_sprite* R_CreateSprite(byte width, byte height, byte* pixels)
{
    struct r_sprite* sprite = (r_sprite*)malloc(sizeof(r_sprite));
    //assert(sizeof(pixels) == width*height);
    sprite->data = pixels;
    sprite->width = width;
    sprite->height = height;
}
