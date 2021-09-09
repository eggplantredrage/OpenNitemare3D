#include "i_sound.h"

void I_InitMusic()
{
    Mix_OpenAudio( 44100, MIX_DEFAULT_FORMAT, 2, 2048 );
    
}

void I_PauseMusic()
{
    Mix_PauseMusic();
}

void I_PlayMusic()
{
    Mix_PlayMusic(current_midi, -1);
}

void I_ChangeSong(int id)
{
    SDL_RWops* data = SDL_RWFromMem(SND.entries[id+1].data, SND.entries[+1].length);
    current_midi = Mix_LoadMUS_RW(data, 1);
    //SDL_FreeRW(data);
}