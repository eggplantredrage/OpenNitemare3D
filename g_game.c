#include "g_game.h"

void G_Init(struct g_game* game)
{
    game = malloc(sizeof(g_game));
    D_LoadDats();
    R_Init();
    I_InitMusic();
    R_LoadPCXFiles(renderer);
    R_SetPCX(PCX_HUD);
    //G_LoadEpisode(0);
    //G_LoadLevel(0);

    I_ChangeSong(14);
    I_PlayMusic();
}

void G_LoadEpisode(uint8_t episode)
{
    printf("loading episode %d\n", episode);
    game->mapcount = 10;
    //R_LoadSprites(episode);
}

void G_LoadLevel(uint8_t level)
{
    //free(game->mapdata);
    
    game->map++;
    if(game->map >= game->mapcount)
    {
        G_LoadEpisode(game->episode++);
        game->map = 0;
    }
}

void G_UpdateGame(struct g_game* game)
{
    R_DrawSprite(100,100, sprites[0]);
}