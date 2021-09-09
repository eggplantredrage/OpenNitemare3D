#include "r_ui.h"

void R_LoadPCXFiles(SDL_Renderer* renderer)
{
    for(int i = 0; i <= 12; i++)
    {
        SDL_RWops* data = SDL_RWFromMem(UIF.entries[i+3].data, UIF.entries[i+3].length);
        SDL_Surface* surface = IMG_LoadPCX_RW(data);

        uint32_t keyColor;
		keyColor = SDL_MapRGB(surface->format, 0, 0, 0);
		SDL_SetColorKey(surface, SDL_TRUE, keyColor);

        pcx_images[i] = SDL_CreateTextureFromSurface(renderer, surface);
        SDL_RWclose(data);
        SDL_FreeSurface(surface);
    }

    D_FreeDat(&UIF);
}

void R_SetPCX(pcx newoverlay)
{
    overlay = newoverlay;
}

void R_FreePCX(pcx tobefreed)
{
    SDL_DestroyTexture(pcx_images[overlay]);
}

void R_InitUI()
{

}

void R_DrawUI(SDL_Renderer* renderer)
{
    R_DrawPCX(renderer);
}

void R_DrawUISprites(SDL_Renderer* renderer)
{

}

void R_DrawUIText(SDL_Renderer* renderer)
{

}

void R_DrawPCX(SDL_Renderer* renderer)
{
    SDL_Rect src, dst;
    src.w = PCX_WIDTH;
    src.h = PCX_HEIGHT;
    src.x = 0;
    src.y = 0;
    dst.w = PCX_WIDTH;
    dst.h = 240;
    dst.x = 0;
    dst.y = 0;
    
    SDL_RenderCopy(renderer, pcx_images[overlay], &src, &dst);
}