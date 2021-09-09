#ifndef IMG
#define IMG
#include "typedefs.h"
#include "r_sprite.h"
#include <stdio.h>
byte* palette;

r_sprite* sprites;
uint16_t imgCount;
void R_LoadPalette();
void R_LoadSprites(byte episode);
bool R_IMGHasOffset(uint32_t offset, uint32_t* offsets, int count);
uint32_t* R_LoadOffsets(FILE* file);
void R_GetColor(byte i, byte* r, byte* g, byte* b);

#endif