#ifndef P_THINK
#define P_THINK
#include "m_obj.h"
#include "i_keyboard.h"
#include <math.h>

obj_t* p_player;
void P_InitPlayer(obj_t* player);
void P_PlayerThink();
void P_PlayerHandleInput();

#endif