#ifndef UI
#define UI
#define PCX_WIDTH 320
#define PCX_HEIGHT 200
#include "d_dat.h"
#include "r_img.h"
#include "i_sound.h"
#include <SDL2/SDL.h>
#include <SDL2/SDL_image.h>
#include "pcx.h"
byte uiframebuffer[320][200];
byte uitexturebuffer[320*200*4];
SDL_Texture* uitexture;

pcx overlay;
SDL_Texture* pcx_images[14];
void R_ClearUI();
void R_DrawSprite(int x, int y, r_sprite sprite);
void R_FreePCX(pcx tobefreed);
void R_LoadPCXFiles(SDL_Renderer* renderer);
void R_SetPCX(pcx newoverlay);
void R_DrawUI(SDL_Renderer* renderer);
void R_InitUI();
void R_DrawUISprites(SDL_Renderer* renderer);
void R_DrawUIText(SDL_Renderer* renderer);
void R_DrawPCX(SDL_Renderer* renderer);

#endif