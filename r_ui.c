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

        uitexture = SDL_CreateTexture(renderer, SDL_PIXELFORMAT_ABGR8888, SDL_TEXTUREACCESS_STREAMING, 320, 200);
        SDL_SetTextureBlendMode(uitexture, SDL_BLENDMODE_BLEND);
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
    R_PlayerFace = 822;
}

void R_DrawUI(SDL_Renderer* renderer)
{
    R_DrawPCX(renderer);
    R_DrawUISprites(renderer);

    for(int x = 0; x < 320; x++)
    {
        for(int y = 0; y < 200; y++)
        {
            byte pixel = uiframebuffer[x][y];
            byte r, g, b, a;
            R_GetColor(pixel, &r, &g, &b);
            a = (pixel == 0) ? 0 : 255;

            uitexturebuffer[4 * (x + y * 320)] = r;
            uitexturebuffer[4 * (x + y * 320) + 1] = g;
            uitexturebuffer[4 * (x + y * 320) + 2] = b;
            uitexturebuffer[4 * (x + y * 320) + 3] = a;

        }
    }
    SDL_Rect dst;
    dst.w = 320;
    dst.h = 240;
    dst.x = 0;
    dst.y = 0;
    SDL_UpdateTexture(uitexture, NULL, uitexturebuffer, 320*4);
    SDL_RenderCopy(renderer, uitexture, NULL, &dst);
}

void R_ClearUI()
{
    for(int x = 0; x < 320; x++)
    {
        for(int y = 0; y < 200; y++)
        {
            uiframebuffer[x][y] = 0;
        }
    }
}

void R_DrawSprite(int x, int y, r_sprite sprite)
{
    for(int tx = 0; tx < sprite.width; tx++)
    {
        for(int ty = 0; ty < sprite.height; ty++)
        {
            uiframebuffer[tx + x][ty + y] = sprite.data[tx + ty * sprite.width];
        }
    }
}

void R_DrawUISprites(SDL_Renderer* renderer)
{
    R_DrawSprite(3 ,162, sprites[822]);
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