# OpenNitemare3D
reimplementation of the 1994 FPS Nitemare 3D in C#
[Twitter](https://twitter.com/CatboiN).
[Discord](https://discord.gg/pr36YJ9Njw).
[Tumblr](https://www.tumblr.com/blog/bbqgiraffe).

[![Showcase](https://yt-embed.herokuapp.com/embed?v=KLNquQF4iJo)](https://www.youtube.com/watch?v=KLNquQF4iJo-Y "fucking uhhh")



# how to install:
you will need to get the original game files, I reccomend just getting them from archive.org since the [version on David Gray's website](https://www.dgray.com/n3dpage.htm) is newer and has unsupported file types, however you will need to get SND.DAT from the newer version as the old version uses unsupported .VOC sounds [archive to newer version(you only need SND.DAT)](https://archive.org/download/win3_Nite3d3x/win3_Nite3d3x.zip), place SND.DAT(windows version!!!), UIF.DAT MAP.1, IMG.1, and GAME.PAL in bin/Debug/net5.0/data, then you can just launch the executable, it's untested on Windows but it should probably work since it's DotNet, you will probably need to download SFML binaries

note that most of the menu options will crash the game, only new game and sound editor will do anything

# how to help:
if you for some reason want to contribute to my garbage you can join the discord,
I'm open to any help especially with reverse engineering the executable as I'm garbage at assembly,
I also need help labeling all the sound effects

if you're David P Gray please consider open-sourcing Nitemare 3D


## features:
* Loading of original bitmap images
* Loading of original maps
* Playback of MIDI music
* Playback of SFX from Windows version (some Dos SFX *will* play but most of them sound garbage)
* semi-functional main menu

## currently being worked on:
* full support for Dos sound files
* sprites
* implementing curtains, warps, hidden panels
* tile editor that auto-generates code for me

### file formats:

#### DAT:
Nitemare 3D uses the .DAT format(also used by David Gray in the Hugo series),
this consists of a header that contains offsets for every file stored in the container, the offset consists of a unsigned 16 bit integer for the length followed by a unsiged 32 bit integer for the position.
<br></br>
files in SND.DAT consist of MIDI files followed by either 16 bit VOC or 8 bit PCM audio files(depending on the version).
UIF.DAT consists of 256 color 320x200 PCX images


#### MAP:
maps are stored as text files and are very easy to read, the first 514 bytes are still unknown by me(could be tile definitions?)
after that every map is stored as a 8192 byte chunk, every even byte is a tile id and every odd byte is a item id.

