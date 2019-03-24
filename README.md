This project is a show case to prove the possibility to employ a plugin system in asp.net core. It is developed to be a prototype for the plugin system used into [RawCMS the asp.net core extensible Headless CMS](https://github.com/arduosoft/RawCMS) and uses the [McMaster's Library](https://github.com/natemcmaster/DotNetCorePlugins).

## Project structure

![app architecture](https://github.com/zeppaman/csharp-plugin/raw/master/assets/csharp-plugin-diagram.png)

### Container
This is the web api container project that import plugin dinamically. Note that in this project there isn't any reference to plugin. All its loaded at runtime.

### Library
This is a library where a dependency class is present. This class will be shared between plugin to ensure all works with same definition.
Moreover, this plugin include a dependency (html  agility pack) that can be used from plugins

### Plugin
This is the plugin. It uses newtownsoft, as private dependency. I consumes a `Dependency` insance from global context and Html Agility pack.




