# SharePoint WebDav Shell Extension

This is the first version of my SharePoint WebDav Windows Shell Extension, so it could include some bugs :).

I made this tool cause I work a lot with the Windows Explorer since SharePoint has WebDav support, but everytime I need to change a file I had to open the file location in Internet Explorer or SharePoint Designer. That's a slow way to check out and check in files.

With this Windows Shell Extension you can do file operations with a click :). It extends the Windows Explorer context menu on a WebDav mapped network drive.

This version is without logging. Logging will be a part of the next release. My plans for features in the next releases are icon overlays, working dialog for long running operations, better user information dialogs, checkin dialog ... and more operations.

Have fun.

## Download

- v0.1 - [x64](https://github.com/daniellindemann/SharePointWebDavShellExtension/raw/master/Releases/SharePointWebDavShellExtension_2013_v0.1_x64.zip "SharePoint WebDav Shell Extension x64")

## Installation

Extract the zip-File to any location and run `Install.bat`.

To unintall the extension run `Uninstall.bat`.

## Screenshots

![Extension](https://raw.github.com/daniellindemann/SharePointWebDavShellExtension/master/Screenshots/install.png)

![Extension](https://raw.github.com/daniellindemann/SharePointWebDavShellExtension/master/Screenshots/ContextMenu.png)

![Extension](https://raw.github.com/daniellindemann/SharePointWebDavShellExtension/master/Screenshots/checkoutError.png)

## Version History

### v0.1

Simple commands (checkin, checkout, publish, discart checkout)

Logging is not a part of this release

## Used libs

- [SharpShell](https://github.com/dwmkerr/sharpshell)
- [Ninject](https://github.com/ninject/ninject)
- SharePoint Client API