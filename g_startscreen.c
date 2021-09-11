#include "g_startscreen.h"
void G_UpdateStartScreen()
{
}

bool G_StartScreenDone()
{
    return I_IsKeyDown(SDL_SCANCODE_RETURN);
}

void G_InitStartScreen()
{
    startscreen = malloc(sizeof(startscreen));
}
