#ifndef M_OBJ
#define M_OBJ
#include "m_type.h"
#include "typedefs.h"
typedef struct m_obj
{
    float x,y;
    uint8_t id;
    angle_t angle;
    sprite_t sprite;
    struct m_mobjdata* data;
    
}m_obj;

m_obj* spawn(m_type type, int x, int y, angle_t angle);

#endif