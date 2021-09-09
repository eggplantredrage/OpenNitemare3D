#ifndef BINARY_READER
#define BINARY_READER
#include <stdio.h>
#include "typedefs.h"

FILE* I_OpenBinary(char filename[256]);
uint32_t I_ReadUint32(FILE* file);
uint16_t I_ReadUint16(FILE* file);
byte I_ReadByte(FILE* file);
byte* I_ReadBytes(FILE* file, uint16_t count);
void I_Close(FILE* file);
uint32_t I_GetPosition(FILE* file);

#endif