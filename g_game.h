#ifndef G_GAME
#define G_GAME
#include "typedefs.h"
#include "pcx.h"
#include "r_ui.h"
#include "g_game.h"
#include "m_maptype.h"
#include "i_keyboard.h"
#include "g_info.h"
#include "r_main.h"
#define MAP_OFFSET 514;
uint16_t R_PlayerFace;


bool G_GameIsDone();
void G_ShowWalls();
void G_CreateMapObject(byte id, byte x, byte y);
void G_LoadEpisode(uint8_t episode);
void G_LoadLevel(uint8_t level);
void G_StartMainGame();
void G_UpdateMainGame();
#endif  