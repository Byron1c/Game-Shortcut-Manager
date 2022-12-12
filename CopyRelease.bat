@echo off
del "D:\Temp\Game Shortcut Manager\*.*" /S /Q
del "D:\Temp\Game Shortcut Manager *.*" /S /Q
xcopy "E:\Users\Troy\Dropbox\@Backup\VisualStudio\GameShortcutManager\GameShortcutManager\bin\Release\*.*" "D:\Temp\Game Shortcut Manager\" /S /E
rem Game Shortcut Manager 0.6.1.0.zip
rem "C:\zipper.vbs" "C:\folderToZip\" "C:\mynewzip.zip"
"E:\Users\Troy\Dropbox\@Backup\VisualStudio\GameShortcutManager\zipper.vbs" "D:\Temp\Game Shortcut Manager\" "D:\Temp\Game Shortcut Manager.zip"

pause 