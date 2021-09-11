#ifndef I_KEYBOARD
#define I_KEYBOARD
#include "typedefs.h"
#include <SDL2/SDL.h>

Uint8* keys;
void I_HandleKeyboard();
bool I_IsKeyDown(SDL_Scancode key);
#endif