#include "m_type.h"
#include "m_weapondata.h"
typedef struct m_mobjdata
{
    m_type type;
    struct m_weapondata weapon;
    uint8_t health;
}m_mobjdata;