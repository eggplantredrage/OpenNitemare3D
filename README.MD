# OpenNitemare3D
reimplementation of the 1994 FPS Nitemare 3D in C#
[Twitter](https://twitter.com/CatboiN).
[Discord](https://discord.gg/pr36YJ9Njw).
[Tumblr](https://www.tumblr.com/blog/bbqgiraffe).

[![Showcase](https://yt-embed.herokuapp.com/embed?v=KLNquQF4iJo)](https://www.youtube.com/watch?v=KLNquQF4iJo-Y "fucking uhhh")

# how to compile:
run "python3 build.py" you'll need SDL2, SDL2_mixer, and SDL2_image

# how to install:
you will need to get the original game files, I reccomend just getting them from archive.org since the [version on David Gray's website](https://www.dgray.com/n3dpage.htm) is newer and has unsupported file types, however you will need to get SND.DAT from the newer version as the old version uses unsupported .VOC sounds [archive to newer version(you only need SND.DAT)](https://archive.org/download/win3_Nite3d3x/win3_Nite3d3x.zip), place UIF.DAT, SND.DAT, IMG.1, MAP.1, and GAME.PAL in the same directory as your executable


# how to help:
if you for some reason want to contribute to my garbage you can join the discord,
I'm open to any help especially with reverse engineering the executable as I'm garbage at assembly,
I also need help labeling all the sound effects

if you're David P Gray please consider open-sourcing Nitemare 3D

### file formats:

#### DAT:
Nitemare 3D uses the .DAT format(also used by David Gray in the Hugo series),
this consists of a header that contains offsets for every file stored in the container, the offset consists of a unsigned 16 bit integer for the length followed by a unsigend 32 bit integer for the position.
<br></br>
files in SND.DAT consist of MIDI files followed by either 16 bit VOC or 8 bit PCM audio files(depending on the version).
UIF.DAT consists of 256 color 320x200 PCX images

#### IMG:
IMG.x files have a header that consists of 4 byte unsigned integer,
there's a bunch of 0's in there for some reason and you only really need
the first entry location, the rest of the file is entries.

image data is 256 color paletted

IMG entry:

| offset   |      size     | descrption |
|----------|:-------------:|------:     |
| 0        |      1        | width      |
| 1        |      1        | height     |
| 2        |      8        | unknown    |
| 10       |  width*height | image data |
#### MAP:
maps are stored as text files and are very easy to read, the first 514 bytes are still unknown by me(could be tile definitions?)
after that every map is stored as a 8192 byte chunk, every even byte is a tile id and every odd byte is a item id.

