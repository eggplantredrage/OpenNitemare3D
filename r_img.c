#include "r_img.h"

void R_LoadPalette()
{
    FILE* file = fopen("GAME.PAL", "rb");
    palette = malloc(768);
    fseek(file, 1156, SEEK_SET);
    fread(palette, 768, 1, file);
    fclose(file);
}

bool R_IMGHasOffset(uint32_t offset, uint32_t* offsets, int count)
{
    for(int i = 0; i < count; i++)
    {
        if(offsets[i] == offset)
        {
            return true;
        }
    }
    return false;
}

uint32_t* R_LoadOffsets(FILE* img)
{
    uint32_t* offsets = malloc(sizeof(uint32_t) * 1000);
    fseek(img, 4, SEEK_SET);
    int retval;
	uint32_t offset;
	uint32_t firstOffset = 0;
    int i = 0;
	do
	{
		retval = fread(&offset, 4, 1, img);
		if (offset != 0)
		{
            offsets[i] = offset;
            imgCount++;
		}
		if (firstOffset == 0) { firstOffset = offset; printf("First offset: %x\n", firstOffset); }
	} while (ftell(img) < firstOffset && retval > 0);

    return offsets;
}

void R_LoadSprites(byte episode)
{
    char* filename[5];
    sprintf(filename, "IMG.%d", episode);
    printf("loading sprites for episode %d\n", episode);

    FILE* img = fopen(filename, "rb");
    uint32_t* offsets = R_LoadOffsets(img);

    sprites = malloc(sizeof(r_sprite) * imgCount);
    for(int i = 0; i < imgCount-1127; i++)
    {
        //fseek(img, offsets[i], SEEK_SET);

        byte w, h;
        fread(&w, 1, 1, img);
        fread(&h, 1, 1, img);
        byte* useless = malloc(8);
        fread(useless, 8, 1, img);
        byte* data = malloc(w*h);
        byte* fixed = malloc(w*h);
        fread(data, w*h, 1, img);

        //convert from column order to row order (rotate texture 90 degrees clockwise)
        //I spent almost 2 hours trying to figure this out it's almost midnight
        for(int j = 0; j < w * h; j++)
        {
            int x = j % h;
            int y = j / h;
            int row = j / w;
            int col = j % w;
            fixed[x + y * h] = data[row + col * h];
        }

        sprites[i] = *R_CreateSprite(w, h, fixed);

        //dump raw img entry to bin
        char* filename = (char*)malloc(256);

        sprintf(filename, "imgbin/img%d.bin", i);
        FILE* dump = fopen(filename, "wb");
        fwrite(&w, 1,1,dump);
        fwrite(&h, 1, 1, dump);
        fwrite(useless, 8, 1, dump);
        fwrite(data, w*h, 1, dump);
        fclose(dump);
        
        free(data);
        free(filename);
    }
    

    printf("loaded %d sprites from %s\n", imgCount, filename);
    fclose(img);
}

void R_GetColor(byte i, byte* r, byte* g, byte* b)
{
    *r = palette[i * 3];
    *g = palette[(i * 3) + 1];
    *b = palette[(i * 3) + 2];
}