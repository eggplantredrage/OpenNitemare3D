#ifndef R_RENDERER
#define R_RENDERER
#include "r_img.h"
#include <SDL2/SDL_image.h>
#define RAYCAST_WIDTH 320
#define RAYCAST_HEIGHT 200

#define WINDOW_WIDTH 320
#define WINDOW_HEIGHT 240
#define WINDOW_NAME "Nitemare 3D"

byte framebuffer[RAYCAST_WIDTH][RAYCAST_HEIGHT];
bool R_isopen;
r_sprite* sprites;
SDL_Window* window;
SDL_Renderer* renderer;
SDL_Event event;
uint tickcount;

void R_DrawSprite(int x, int y, r_sprite sprite);
void R_Init();
void R_Clear();
void R_DrawFrameBuffer();
void R_Present();
bool R_IsOpen();
void R_ProcessSDLWindowEvent();
void R_ProcessSDLInput();
void R_Close();

#endif
