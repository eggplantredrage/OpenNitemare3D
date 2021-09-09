#include "r_renderer.h"

void R_Init()
{
    window = SDL_CreateWindow(WINDOW_NAME, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, WINDOW_WIDTH, WINDOW_HEIGHT, SDL_WINDOW_RESIZABLE);
    renderer = SDL_CreateRenderer(window, -1, SDL_RENDERER_PRESENTVSYNC);
    SDL_RenderSetLogicalSize(renderer, WINDOW_WIDTH, WINDOW_HEIGHT);
    SDL_SetRenderDrawBlendMode(renderer, SDL_BLENDMODE_BLEND)
;    R_isopen = true;
    R_LoadPalette();
    R_LoadSprites(1);
}

void R_DumpSprites()
{
    for(int i = 0; i < imgCount-1127; i++)
    {
        byte width = sprites[i].width;
        byte height = sprites[i].height;
        byte* data = sprites[i].data;
        byte* buffer = malloc(width * height * 4);

        for(int j = 0; j < width*height; j++)
        {
            byte pixel = data[j];
            byte r, g, b;
            R_GetColor(pixel, &r, &g, &b);

            buffer[j * (4)] = b;
            buffer[j * (4) + 1] = g;
            buffer[j * (4) + 2] = r;
            buffer[j * (4) + 3] = 255;
        }
       
        char* filename[256];
        sprintf(filename, "img/img_%d.png", i);
        //R_SaveTexture(filename, renderer, texture);

        SDL_Surface* surface = SDL_CreateRGBSurfaceFrom(buffer, width, height, 32, width*4, 0, 0, 0, 0);
        IMG_SavePNG(surface, filename);
    }
}

void R_DrawFrameBuffer()
{
    for(int x = 0; x < RAYCAST_WIDTH; x++)
    {
        for(int y = 0; y < RAYCAST_HEIGHT; y++)
        {
            //byte pixel = framebuffer[x][y];
            //byte r, g, b;
            //R_GetColor(pixel, &r, &g, &b);

            // SDL_SetRenderDrawColor(renderer, r, g, b, 255);
            // SDL_RenderDrawPoint(renderer, x, y);
            // SDL_SetRenderDrawColor(renderer, 255, 255, 255, 255);
        }
    }
}

void R_Clear()
{
    R_ClearUI();
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