# Notepad-VB

A simple notepad for Windows with an Arabic, right-to-left interface, written in VB.NET with WPF.

## Versions

| Version | What it is |
|---|---|
| v2.0.0 | A lighter window without the ribbon: New (opens another window), Open, Save As with a choice of text encoding (ASCII, BigEndianUnicode, Unicode, UTF-32, UTF-7, UTF-8), Font and Clear. Long lines wrap. |
| v1.0.0 | A ribbon window (Microsoft Ribbon for WPF): new document, open and save as, undo and redo, clear, cut, copy, paste and select all, find, find next, replace and replace all, insert date and time, go to line, font, bold, italic and underline, alignment, word wrap and an About box. |

## Requirements

Windows with .NET Framework 4.0 or later. Windows 10 and 11 already have it.

## Usage

Download the `.7z` file of the version you want from [Releases](https://github.com/Mohammad-Diab/Notepad-VB/releases), extract it, and run the `.exe` inside (`notpad.exe` in v1.0.0, `Notpad1.exe` in v2.0.0). There is no installer. Keep the two DLLs next to `notpad.exe` in v1.0.0.

The exe is not signed, so Windows SmartScreen may warn the first time you run it (More info, then Run anyway).

## Known limits

- v1.0.0: Save, text colour, background colour, print preview and print have no effect.
- v2.0.0: changing the encoding after opening a file saves that file again in the new encoding. After a Save As without opening a file, changing the encoding twice closes the app with an error.

## Building

Clone the repository, check out the version tag (`git checkout v1.0.0` or `v2.0.0`), open the `.sln` file in Visual Studio and build. v1.0.0 takes the ribbon DLLs from `lib`.

The project targets .NET Framework 4.0 Client Profile, and recent Visual Studio versions don't include its reference assemblies. If the build fails with `MSB3644`, download [Microsoft.NETFramework.ReferenceAssemblies.net40](https://www.nuget.org/packages/Microsoft.NETFramework.ReferenceAssemblies.net40), unzip it, and build with:

```
MSBuild Notpad1.sln /p:Configuration=Release /p:Platform=x86 /p:TargetFrameworkRootPath=<unzipped folder>\build
```

(`notpad.sln` for v1.0.0.)

## Credits

- [Microsoft Ribbon for WPF](https://learn.microsoft.com/en-us/previous-versions/dotnet/netframework-4.0/ff799534(v=vs.100)) (`RibbonControlsLibrary.dll` and `Microsoft.Windows.Shell.dll`, v1.0.0 only), redistributed under its license terms (`lib/Microsoft-Ribbon-for-WPF-license.txt` at the v1.0.0 tag).

## Author

Mohammad Diab
