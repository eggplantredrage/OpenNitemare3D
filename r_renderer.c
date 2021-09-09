#include "r_renderer.h"

void R_Init()
{
    window = SDL_CreateWindow(WINDOW_NAME, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, WINDOW_WIDTH, WINDOW_HEIGHT, SDL_WINDOW_RESIZABLE);
    renderer = SDL_CreateRenderer(window, -1, SDL_RENDERER_PRESENTVSYNC);
    SDL_RenderSetLogicalSize(renderer, WINDOW_WIDTH, WINDOW_HEIGHT);
    SDL_SetRenderDrawColor(renderer, 50, 0, 100, 255);
    R_isopen = true;
    R_LoadPalette();
    R_LoadSprites(1);
}

void R_DrawSprite(int x, int y, r_sprite sprite)
{
    for(int sx = y; sx < x + sprite.width; sx++)
    {
        for(int sy = y; sy < y + sprite.height; sy++)
        {
            framebuffer[sx][sy] = sprite.data[sx + sy * sprites->height];
        }
    }
}

void R_DrawFrameBuffer()
{
    for(int x = 0; x < RAYCAST_WIDTH; x++)
    {
        for(int y = 0; y < RAYCAST_HEIGHT; y++)
        {
            byte pixel = framebuffer[x][y];
            byte r, g, b;
            R_GetColor(pixel, &r, &g, &b);

            SDL_SetRenderDrawColor(renderer, r, g, b, 255);
            SDL_RenderDrawPoint(renderer, x, y);
            SDL_SetRenderDrawColor(renderer, 0, 0, 0, 255);
        }
    }
}

void R_Clear()
{
    SDL_RenderClear(renderer);
}

void R_Present()
{
    SDL_RenderPresent(renderer);
}

bool R_IsOpen()
{
    return R_isopen;
}

void R_ProcessSDLWindowEvent()
{
    switch (event.window.event)
    {
    case SDL_WINDOWEVENT_CLOSE:
        R_Close();
        break;
    
    default:
        break;
    }
}

void R_Close()
{
    SDL_DestroyWindow(window);
    SDL_DestroyRenderer(renderer);
    R_isopen = false;
}

void R_ProcessSDLInput()
{
    while(SDL_PollEvent(&event))
    {
        switch (event.type)
        {
        case SDL_WINDOWEVENT:
            R_ProcessSDLWindowEvent();
            break;
        
        default:
            break;
        }
    }
    
}