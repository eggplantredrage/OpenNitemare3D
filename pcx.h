#ifndef PCX_H
#define PCX_H

//todo: port pcx reader to C
typedef enum pcx
{
    PCX_START_SCREEN,
    PCX_PLEASE_WAIT,
    PCX_HUD,
    PCX_MAIN_MENU,
    PCX_CHOOSE_EPISODE,
    PCX_DIFFICULTY,
    PCX_CONFIG_UNSELECTED,
    PCX_CONFIG_SELECTED,
    PCX_CHEAT_MENU,
    PCX_LOAD_SAVE,
    PCX_SAVE,
    PCX_LEVEL_COMPLETE,
    PCX_ORDER_NOW

}pcx;

#endif