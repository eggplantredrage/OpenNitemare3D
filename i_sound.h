#ifndef I_SOUND
#define I_SOUND
#include "d_dat.h"
#include <SDL2/SDL.h>
#include <SDL2/SDL_mixer.h>

Mix_Music* current_midi;
void I_InitMusic();
void I_PauseMusic();
void I_PlayMusic();
void I_ChangeSong(int id);

#endif