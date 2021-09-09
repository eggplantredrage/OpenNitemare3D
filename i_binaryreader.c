#include "i_binaryreader.h"

uint32_t I_ReadUint32(FILE* file)
{
    uint32_t out;
    fread(&out, sizeof(uint32_t), 1, file);
    return out;
}

uint16_t I_ReadUint16(FILE* file)
{
    uint16_t out;
    fread(&out, sizeof(uint16_t), 1, file);
    return out;
}

byte I_ReadByte(FILE* file)
{
    byte out;
    fread(&out, 1, 1, file);
    return out;
}

byte* I_ReadBytes(FILE* file, uint16_t count)
{
    byte* out; //what in the yankee doodle fuck
    fread(&out, sizeof(byte), count, file);
    return out;
}

void I_Close(FILE* file)
{
    fclose(file);
}


uint32_t I_GetPosition(FILE* file)
{
    return ftell(file);
}