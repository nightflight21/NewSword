# Sword
You only start with a sword. Good luck.

---
## Getting Started
Make sure you have dotnet 6.0 or newer installed on your machine. Open 
a terminal and browse to the project's root folder. Start the program 
by running the following commands.
```
dotnet build
dotnet run 
```
You can also run the program from an IDE like Visual Studio Code. 
Start your IDE and open the project folder. Select "Run and Debug" on 
the Activity Bar. Next, select the project you'd like to run from the 
drop down list at the top of the Side Bar. Lastly, click the green 
arrow or "start debugging" button.

## Project Structure
The project files and folders are organized as follows:
```
Sword                    (project root folder)
+-- bin                 (dotnet runtimes)
+-- Game                (main scene folder)
+-- Help                (help scene folder)
+-- obj                 (object cache and debug)
+-- Over                (game over scene folder)
+-- Scripting           (source code folder)
+-- Shared              (scene interface folder)
+-- Title               (title screen scene folder)
+-- Program.cs          (program entry point)
+-- settings.json       (customizable settings for the game)    
+-- Sword.csproj        (dotnet project file)
README.md               (general info)
```

## Required Technologies
* dotnet 6.0
* raylib-cs 3.7.0.1

## Authors
* Adam Foster
* Brandon de Leon
* David Cole
* Mark Cuizon