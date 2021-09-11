#include "p_think.h"

void P_InitPlayer(obj_t* player)
{
    player->player = malloc(sizeof(player));

    player->player->state = PLAYERSTATE_ALIVE;
    p_player = player;
}

void P_PlayerThink()
{
    player_t* player = p_player->player;
    if(I_IsKeyDown(SDL_SCANCODE_UP))
    {
        p_player->velx = sin(player->angle) * player->speed;
        p_player->vely = sin(player->angle) * player->speed;
    }
}

void P_PlayerHandleInput()
{

}
