#ifndef M_OBJ
#define M_OBJ
#include "m_type.h"
#include "typedefs.h"
#include "p_player.h"
#define MAXOBJ 256
int m_objcount;

typedef enum objstate
{
    OBJSTATE_PROP,
    OBJSTATE_GUARD_ALERT,
    OBJSTATE_GUARD_MOVING,
    OBJSTATE_GUARD_IDLE,
    OBJSTATE_GUARD_MELEE_SWINGING,
    OBJSTATE_GUARD_DEAD
}objstate;

typedef struct obj_t
{
    float x,y, velx, vely;
    uint8_t id;
    angle_t angle;
    sprite_t sprite;
    m_type type;
    objstate state;
    player_t* player;
}obj_t;

obj_t* m_objects[MAXOBJ];

void M_Update();
obj_t* M_Spawn(m_type type, int x, int y, angle_t angle);

#endif