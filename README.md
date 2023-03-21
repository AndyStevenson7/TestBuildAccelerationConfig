# Test_BuildAcceleration_ConfigChange
### Context
Visual Studio 2022 v17.5 (Feb 2023) added a new feature called "Build Acceleration" that improves incremental build performance: https://learn.microsoft.com/en-us/visualstudio/releases/2022/release-notes

"Build Acceleration" directs Visual Studio to only build projects that had modifications while skipping projects that were unchanged. https://github.com/dotnet/project-system/blob/main/docs/build-acceleration.md

However, it does not always pick up changes to settings files that have `Build Action` set to `None` or `Content` when running in debug `F5` mode.
Previously VS would run MSBuild, which would update changed files and run a build. Now VS handles the file changes itself, and only calls MSBuild 
when needed. The result is that edits on a settings file don't get picked up, unless you also edit a code file, or explicitly build 
(Ctrl+B or Ctrl+Shift+B) before running debug.

### Testing
1. Run the project: the config values in appsettings.json should be output to the console window
2. Change the `Build Action` property of the appsettings.json file to something like `None`, `Content`, `Resource` or `Embedded Resource`
3. Build and run the application
4. Edit a config setting and run in debug `F5` (_don't_ force a rebuild). Check if the config change is picked up and displayed to the console.
