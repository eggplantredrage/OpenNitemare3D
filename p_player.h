#ifndef G_PLAYER
#define G_PLAYER
#include "typedefs.h"

typedef enum player_state
{
    PLAYERSTATE_ALIVE,
    PLAYERSTATE_FROZEN,
    PLAYERSTATE_DEAD
}player_state;

typedef struct player_t
{
    float angle;
    float speed;
    player_state state;
}player_t;


#endif