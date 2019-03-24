# Project structure

## Container
This is the web api container project that import plugin dinamically. Note that in this project there isn't any reference to plugin. All its loaded at runtime.

## Library
This is a library where a dependency class is present. This class will be shared between plugin to ensure all works with same definition.
Moreover, this plugin include a dependency (html  agility pack) that can be used from plugins

## Plugin
This is the plugin. It uses newtownsoft, as private dependency. I consumes a `Dependency` insance from global context and Html Agility pack.




