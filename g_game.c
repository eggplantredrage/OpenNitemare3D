#include "g_game.h"

bool G_GameIsDone()
{

}
void G_StartMainGame()
{
    R_PlayerFace = 822;
    G_LoadEpisode(1);
    R_LoadSprites(1);
    G_LoadLevel(0);
}

void G_UpdateMainGame()
{
    R_DrawSprite(3, 162, sprites[R_PlayerFace]);
    G_ShowWalls();
}

void G_LoadEpisode(uint8_t episode)
{
    printf("loading episode %d\n", episode);
    gameinfo.episode = episode;
    
}

void G_CreateMapObject(byte id, uint8_t x, uint8_t y)
{
    bool player = false;
    switch ((m_maptype)id)
    {
        case MT_Nothing:
            /* code */
            break;
        case MT_StartpositionN:
            // p_player->x = x;
            // p_player->y = y;
            player = true;
            break;
        case MT_StartpositionE:
            // p_player->x = x;
            // p_player->y = y;
            player = true;
            break;
        case MT_StartpositionS:
            // p_player->x = x;
            // p_player->y = y;
            player = true;
            break;
        case MT_StartpositionW:
            // p_player->x = x;
            // p_player->y = y;
            player = true;
            break;
        
    default:
        break;
    }
}

void G_ShowWalls()
{
    for(byte x = 0; x < 62; x++)
    {
        for(byte y = 0; y < 36; y++)
        {
            uiframebuffer[256 + x][162 + y] = gameinfo.mapdata[x+y*64];
        }
    }
}

void G_LoadLevel(uint8_t level)
{
    I_ChangeSong(2);
    printf("loading level E%dL%d\n", gameinfo.episode, level + 1);
    byte* data = malloc(8192);
    unsigned char* filename[64];

    sprintf(filename, "MAP.%d", gameinfo.episode);
    FILE* file = fopen(filename, "rb");
    fseek(file, 514, SEEK_SET);
    long off = level * 8192;
    
    fread(data, 8192, 1, file);

    for(int i = 1; i < 8192; i+=2)
    {
        uint8_t x = i % 64;
        uint8_t y = i / 64;
        G_CreateMapObject(data[i], x,y);
    }

    gameinfo.mapdata = malloc(4096);
    
    for(int i = 0; i < 8192; i++)
    {
        if(i % 2 == 0)
        {
            gameinfo.mapdata[i/2] = data[i];
        }
    }

    
}