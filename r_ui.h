#ifndef UI
#define UI
#define PCX_WIDTH 320
#define PCX_HEIGHT 200
#include "d_dat.h"
#include "i_sound.h"
#include <SDL2/SDL.h>
#include <SDL2/SDL_image.h>
typedef enum pcx
{
    PCX_START_SCREEN,
    PCX_PLEASE_WAIT,
    PCX_HUD,
    PCX_MAIN_MENU,
    PCX_CHOOSE_EPISODE,
    PCX_DIFFICULTY,
    PCX_CONFIG_UNSELECTED,
    PCX_CONFIG_SELECTED,
    PCX_CHEAT_MENU,
    PCX_LOAD_SAVE,
    PCX_SAVE,
    PCX_LEVEL_COMPLETE,
    PCX_ORDER_NOW

}pcx;

pcx overlay;
SDL_Texture* pcx_images[12];
void R_FreePCX(pcx tobefreed);
void R_LoadPCXFiles(SDL_Renderer* renderer);
void R_SetPCX(pcx newoverlay);
void R_DrawUI(SDL_Renderer* renderer);
void R_InitUI();
void R_DrawUISprites(SDL_Renderer* renderer);
void R_DrawUIText(SDL_Renderer* renderer);
void R_DrawPCX(SDL_Renderer* renderer);

#endif