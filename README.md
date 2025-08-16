# Command Line Tool for ModAdjuster files.
#### Using the release build requires no dependancies or other installations.

Removes excess xml elements from the mods .SBC files and creates the corrosponding .xml files.
Clean and simple to use following the prompts.

### How to build
* Requires .Net10 Preview 7 to build.
* Build from command-prompt, navigate to the root folder containing these files and type build.
* Build from PowerShell, navigate to the root folder containing these files and type ./build.
* Build from Windows, navigate to the root folder containing these files double click build.bat.

** Application will run automatically after build is completed.  Takes about 7 seconds to build. **

*** For linux builds you will need to edit the build.bat file, replace the win-x64 with linux-x64. ***
## How to run without building

### Step 1:
Download the latest release build from https://github.com/buttheadbob/XML-Element-Nuker/releases and run.

----------------------------------------------------------------------------------------------------------------

### Step 2: 
On first run you will not have the required Elements.txt file, you will be prompted with the following:

```
Starting XML Element Nuker...
Elements.txt file not found, creating one.
Would you like the list populated with default items? [Y] or [N]
```

Selecting [Y] will create the Elements file with a list of default Elements.
Selecting [N] will create the file with no contents.

----------------------------------------------------------------------------------------------------------------

### Step 3:
You will now be given a chance to edit the Elements.txt file and add/remove any xml elements from the sbc files we will process.

```
Populate the Elements.txt file with each element you wish removed.  One element per line.
Example, adding the following
PCU
TieredUpdateTimes
Will remove all <PCU> and <TieredUpdateTimes> elements from the xml files.



You can enter the elements into the file now and then press [C] to continue, or press [X] to exit.
```

----------------------------------------------------------------------------------------------------------------

### Step 4:
After pressing [C] from the previous step, 2 new folders will be created.

``ToNuke`` -> This is where you put "a copy" of the mods SBC files you need ModAdjuster to edit.
``Nuked`` -> The resulting XML files after processing the SBC files.

Now copy the mods original SBC files into the ``ToNuke` folder and press [R].

----------------------------------------------------------------------------------------------------------------

On completion you will get a list of all files processed, the time it took to process them.
Example:
```
[10.5736ms] Finished processing OPC_CP_Cubeblocks.sbc

[6.3093ms] Finished processing OPC_CP_Cubeblocks_Aeolus.sbc

[5.6904ms] Finished processing OPC_CP_Cubeblocks_Moryana.sbc

[8.4347ms] Finished processing OPC_CP_Cubeblocks_Sidhe.sbc

[8.5311ms] Finished processing OPC_CP_Cubeblocks_Stribog.sbc
Press any key to exit...
```

Pressing any key will close the application, you can move your completed files over from the Nuked folder to your ModAdjuster mod folder.
Do not leave your XML files in the Nuked folder, they will be deleted the next time you run the program.




I am available through my Discord server and have a dedicated channel for anybody to use, if you desire.
https://discord.gg/rSuxGrHrrt

