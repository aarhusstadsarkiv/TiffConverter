# TiffConverter
A Winforms GUI program that uses ghostscript to convert a pdf file to a compressed Tif file based on the chosen output color scheme.

## Dependencies
This program depends on the [Ghostscript](https://www.ghostscript.com/) PDF interpreter in order to create the compressed Tif file.

In order to use this program, you must download and install [Ghostcript](https://www.ghostscript.com/) and add it to your path environment variable.

To test if you have added ghostscript correctly, open a command prompt (cmd or powershell on windows) and type `gswin64c --version`. This should then print out the
version of ghostscript you have installed.
