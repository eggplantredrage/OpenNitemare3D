#ifndef G_STARTSCREEN
#define G_STARTSCREEN
#include "typedefs.h"
#include "pcx.h"
#include "i_keyboard.h"
typedef struct g_startscreen
{
}g_startscreen;

g_startscreen* startscreen;
bool G_StartScreenDone();
void G_InitStartScreen();
void G_UpdateStartScreen();
#endif  