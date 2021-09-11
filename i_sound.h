#ifndef I_SOUND
#define I_SOUND
#include "d_dat.h"
#include <SDL2/SDL.h>
#include <SDL2/SDL_mixer.h>

//some of the midis had names hidden in their metadata,
//others I just assigned names myself
typedef enum midi
{
    MIDI_HAUNTEDHOUSE_THEME = 1,
    MIDI_STAR = 4,
    MIDI_FANTASIA = 12,
    MIDI_E1M1 = 11
}midi;

Mix_Music* current_midi;
void I_InitMusic();
void I_PauseMusic();
void I_PlayMusic();
void I_ChangeSong(int id);
void I_SetVolume(byte volume);

#endif