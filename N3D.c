#include "g_game.h"
int main()
{
    G_Init();
    while(R_IsOpen())
    {
        R_Clear();
        R_ProcessSDLInput();
        G_UpdateGame();
        R_DrawFrameBuffer();
        R_DrawUI(renderer);
        R_Present();
    }
    R_Close();
    free(game);
}