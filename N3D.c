#include "g_main.h"
int main()
{
    G_Init();
    while(R_IsOpen())
    {
        R_Clear();
        R_ProcessSDLInput();
        G_UpdateGame();
        //R_DrawFrameBuffer();
        R_DrawUI(renderer);
        R_Present();
    }
    R_Close();
}