#include "typedefs.h"
#include "i_binaryreader.h"

//max sprite size is 64x64
#define R_SIZEOF_SPRITE 8202

struct r_sprite
{
    byte width;
    byte height;
    uint16_t unknown;
    uint16_t type;
    byte* data;
};
typedef struct r_sprite r_sprite;

void R_GetSpriteSize(byte* width, byte* height, struct r_sprite* sprite);
struct r_sprite* R_CreateSprite(byte width, byte height, byte* pixels);