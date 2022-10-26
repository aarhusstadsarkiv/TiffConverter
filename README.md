# TiffConverter
A Winforms GUI program that uses ghostscript to convert a pdf file to a compressed Tif file based on the chosen output color scheme.

# Installation:
Prebuild windows binaries can be found under releases on the github page for TiffConverter. To use the prebuild binary, download the release zip file and extract it. 
The extracted folder will include a windows executable (.exe) file. For ease of use, you can add a shortcut to the executable on your desktop.

## Dependencies
This program depends on the [Ghostscript](https://www.ghostscript.com/) PDF interpreter in order to create the compressed Tif file.

In order to use this program, you must download and install [Ghostcript](https://www.ghostscript.com/) and add it to your path environment variable.

To test if you have added ghostscript correctly, open a command prompt (cmd or powershell on windows) and type `gswin64c --version`. This should then print out the
version of ghostscript you have installed.

You also need the .net runtime for desktop apps. 
This might already be installed on your pc, but you can download it from microsoft at https://dotnet.microsoft.com/en-us/download/dotnet/6.0/runtime.
