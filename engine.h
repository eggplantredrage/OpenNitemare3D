#ifndef __ENGINE_H__
#define __ENGINE_H__
#include <string>
#include <SDL2/SDL.h>
#undef main

class Engine
{
public:
	std::string title;
	std::string getTitle();
	float version;
	float getVersion();
	
	int width;
	int height;

	void startGame();
	void startGraphics(const char* Name, int displayWidth, int displayHeight);


	//SDL2 stuff
	SDL_Event event;
	SDL_Window* window;
	SDL_Renderer* renderer;
	SDL_Texture* texture;
	

	
};

#endif

