# Monogame — 3902 Project

First game development project for CSE 3902, built with [MonoGame](https://www.monogame.net/).

## Overview

It's basically just a game with two characters that you can wander around this tiny grid with. You can at least walk over some
letters though!

- **Fox** — moves toward wherever you left-click on screen.
- **Boar** — moves with keyboard input.

They both share the same structure basically. If they had individual interactions or attacks then obviously this would be
different but they are both born from the Player class which is an implementation of the interface IPlayer. Within IPlayer there
is only a few methods, a property to get position, an update method and, and a draw method. The ISprite interface is also
relatively similar but instead for the property utilizes both get and set. They both fundamentally can work on a keyboard or
mouse but at the same time results in some issues that I was unable to figure out. So I thought I'd demonstrate the controllers
through multiplayer. Both controllers implement IController which only contains an update method. Also fundamentally,
KeyboardController and MouseController are relatively similar fundamentally but differ in the way they receive input obviously.

## Issues

- **Animation** -- Just understanding the process behind it was tripping me up for a while and coming up with a solution to cycle
- through took a fair bit of debugging. The easiest part for me was going between the directions of the sprites. I.E pointing the
- sprite up, down, left, or right. The main struggle was once I incorporated a mouse and keyboard the animations broke on me. I
- had to pretty much start from the bottom and figure out why the mouse broke them and ended up creating an L shape movement path
- to prevent this weird flickering. 

- **CombinedControllers** -- I actually tried to make a class that incorporated both controllers to allow for use of both and
- wasn't able to properly figure it out in time. In a last ditch attempt to provide demonstration of both functionally working I
- utilized a second sprite sheet to include a second character to provide local multiplayer as a substitute. I know that's
- probably not the direction our professor was hoping for but hopefully he understands the thought put in even if it was
- desperate. Also every once in a the sprite will glitch out from the mouse. Just a random bug.

- **Time** -- I was sick for all of the week leading up to the due date and wasn't able to really put in some work til the two
- nights before so I'm sure that will reflect on my grade as this probably will come out rushed. On me probably should've
- done more while I was well.

## Controls

| Input | Action |
|---|---|
| Left-click | Fox walks to the clicked location |
| `W` `A` `S` `D` | Move the boar up / left / down / right |
| `Escape` | Quit the game |

## Project Structure

```
3902/
├── Game1.cs              # Main game loop: loads content, updates/draws both players
├── Player.cs              # Binds a controller + sprite together (IPlayer)
├── IPlayer.cs             # Player interface
├── IController.cs         # Controller interface
├── ISprite.cs              # Sprite interface
├── MouseController.cs     # Click-to-move logic for the fox
├── KeyboardController.cs   # WASD movement logic for the boar
├── AnimatedSprite.cs       # Frame-based animation (idle/walk sheets) + drawing
├── Content/images/         # Fox and boar sprite sheets
└── 3902.csproj
```

## Sources 
- **SpriteFonts** - http://rbwhitaker.wikidot.com/monogame-drawing-text-with-spritefonts 
- **Monogame Tutorials** https://docs.monogame.net/articles/tutorials/building_2d_games/index.html
- **Youtube Tutorials** https://www.youtube.com/@batholithentertainment4336
- https://www.youtube.com/watch?v=hm4PkqS2bqY
- **AI Scripts Used** https://chatgpt.com/share/6aa5b276-95a4-83e9-9b33-48cb2ad464ce
- https://chatgpt.com/share/6aa5e1c4-1138-83e9-ba39-8b413b6c19b9
- https://chatgpt.com/share/6aa5e250-60e8-83ea-8def-443164e9f877

## Credits

- Programming: Gavin Brooks
- Sprites: [Free Top-Down Hunt Animals Pixel Sprite Pack]
- (https://craftpix.net/freebies/free-top-down-hunt-animals-pixel-sprite-pack/) via craftpix.net

  
