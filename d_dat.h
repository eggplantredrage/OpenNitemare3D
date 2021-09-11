#ifndef D_DAT
#define D_DAT
#include "typedefs.h"
#include "i_binaryreader.h"


#define DAT_MAX_ENTRIES 32

typedef struct dat_entry_t
{
    uint16_t length;
    uint32_t offset;
    uint8_t* data;
}dat_entry_t;

typedef struct dat_file_t
{
    int count;
    struct dat_entry_t* entries;
}dat_file_t;

dat_file_t UIF, SND;

dat_file_t D_ReadDat(char filename[256]);
void D_FreeEntry(dat_entry_t entry);
void D_FreeDat(dat_file_t* file);
void D_LoadDats();
#endif