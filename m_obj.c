#include "m_obj.h"


void M_Update()
{
    for(int i = 0; i < m_objcount; i++)
    {
        obj_t* obj = m_objects[i];
        obj->x += obj->velx;
        obj->y += obj->vely;
    }
}

obj_t* M_Spawn(m_type type, int x, int y, angle_t angle)
{
    obj_t* monster;
    monster->x = x;
    monster->y = y;
    monster->angle = angle;
    m_objects[m_objcount] = monster;
    m_objcount++;

    switch (type)
    {
    case M_FRANKENSTEIN:

        break;
    
    default:
        break;
    }
    return monster;
}