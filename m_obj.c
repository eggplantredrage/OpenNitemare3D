#include "m_obj.h"

m_obj* spawn(m_type type, int x, int y, angle_t angle)
{
    m_obj* monster;
    monster->x = x;
    monster->y = y;
    monster->angle = angle;

    switch (type)
    {
    case M_FRANKENSTEIN:

        break;
    
    default:
        break;
    }
    return monster;
}