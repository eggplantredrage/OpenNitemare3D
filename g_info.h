#ifndef G_INFO
#define G_INFO
#include "g_gamestate.h"
#include "g_engineversion.h"
#include "typedefs.h"

typedef struct g_info
{
    byte midi;
    byte episode;
    byte mapid;
    byte* mapdata;
    g_engineversion version;
    g_gamestate gamestate;
}g_info;

static g_info gameinfo;

#endif