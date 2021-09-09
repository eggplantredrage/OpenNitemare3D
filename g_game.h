#ifndef G_GAME
#define G_GAME

#include "r_renderer.h"
#include "r_ui.h"
#define LEVEL_SIZE 64

typedef struct g_game
{
    uint8_t spriteCount;
    uint8_t midi;
    uint8_t episode;
    uint8_t map;
    uint8_t mapcount;
    uint8_t mapdata[LEVEL_SIZE*LEVEL_SIZE];
}g_game;

g_game* game;
void G_ChanceSong(uint8_t midi);
void G_LoadEpisode(uint8_t episode);
void G_LoadLevel(uint8_t level);
void G_UpdateGame();
void G_Init();

#endif