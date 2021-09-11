#include "g_think.h"

void G_HandleThinking()
{
    for(int i = 0; i < m_objcount; i++)
    {
        switch ((*m_objects[i]).type)
        {
        case M_PLAYER:
            P_PlayerThink();
            break;
        
        default:
            break;
        }
    }
}