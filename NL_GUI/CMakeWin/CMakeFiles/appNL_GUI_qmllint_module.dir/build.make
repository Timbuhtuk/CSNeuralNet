# CMAKE generated file: DO NOT EDIT!
# Generated by "Unix Makefiles" Generator, CMake Version 3.26

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:

#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:

# Disable VCS-based implicit rules.
% : %,v

# Disable VCS-based implicit rules.
% : RCS/%

# Disable VCS-based implicit rules.
% : RCS/%,v

# Disable VCS-based implicit rules.
% : SCCS/s.%

# Disable VCS-based implicit rules.
% : s.%

.SUFFIXES: .hpux_make_needs_suffix_list

# Command-line flag to silence nested $(MAKE).
$(VERBOSE)MAKESILENT = -s

#Suppress display of executed commands.
$(VERBOSE).SILENT:

# A target that is always out of date.
cmake_force:
.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

# The shell in which to execute make rules.
SHELL = /bin/sh

# The CMake executable.
CMAKE_COMMAND = /home/kotowhiskas/Documents/mxe/usr/x86_64-pc-linux-gnu/bin/cmake

# The command to remove a file.
RM = /home/kotowhiskas/Documents/mxe/usr/x86_64-pc-linux-gnu/bin/cmake -E rm -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI"

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/CMakeWin"

# Utility rule file for appNL_GUI_qmllint_module.

# Include any custom commands dependencies for this target.
include CMakeFiles/appNL_GUI_qmllint_module.dir/compiler_depend.make

# Include the progress variables for this target.
include CMakeFiles/appNL_GUI_qmllint_module.dir/progress.make

CMakeFiles/appNL_GUI_qmllint_module: /home/kotowhiskas/Documents/mxe/usr/x86_64-pc-linux-gnu/qt6/bin/qmllint
CMakeFiles/appNL_GUI_qmllint_module: /home/kotowhiskas/Programming\ Projects/QML\ Projects/NL_GUI/Main.qml
CMakeFiles/appNL_GUI_qmllint_module: /home/kotowhiskas/Programming\ Projects/QML\ Projects/NL_GUI/Layer.qml
CMakeFiles/appNL_GUI_qmllint_module: /home/kotowhiskas/Programming\ Projects/QML\ Projects/NL_GUI/Line.qml
CMakeFiles/appNL_GUI_qmllint_module: /home/kotowhiskas/Programming\ Projects/QML\ Projects/NL_GUI/CenteredCircle.qml
CMakeFiles/appNL_GUI_qmllint_module: /home/kotowhiskas/Programming\ Projects/QML\ Projects/NL_GUI/Weights.qml
CMakeFiles/appNL_GUI_qmllint_module: /home/kotowhiskas/Programming\ Projects/QML\ Projects/NL_GUI/NeuralVisualization.qml
	cd "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI" && /home/kotowhiskas/Documents/mxe/usr/x86_64-pc-linux-gnu/qt6/bin/qmllint -I /home/kotowhiskas/Programming\ Projects/QML\ Projects/NL_GUI/CMakeWin -I /home/kotowhiskas/Documents/mxe/usr/x86_64-w64-mingw32.static/qt6/./qml --resource /home/kotowhiskas/Programming\ Projects/QML\ Projects/NL_GUI/CMakeWin/.rcc/qmake_NL_GUI.qrc --resource /home/kotowhiskas/Programming\ Projects/QML\ Projects/NL_GUI/CMakeWin/.rcc/appNL_GUI_raw_qml_0.qrc --module NL_GUI

appNL_GUI_qmllint_module: CMakeFiles/appNL_GUI_qmllint_module
appNL_GUI_qmllint_module: CMakeFiles/appNL_GUI_qmllint_module.dir/build.make
.PHONY : appNL_GUI_qmllint_module

# Rule to build all files generated by this target.
CMakeFiles/appNL_GUI_qmllint_module.dir/build: appNL_GUI_qmllint_module
.PHONY : CMakeFiles/appNL_GUI_qmllint_module.dir/build

CMakeFiles/appNL_GUI_qmllint_module.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/appNL_GUI_qmllint_module.dir/cmake_clean.cmake
.PHONY : CMakeFiles/appNL_GUI_qmllint_module.dir/clean

CMakeFiles/appNL_GUI_qmllint_module.dir/depend:
	cd "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/CMakeWin" && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/CMakeWin" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/CMakeWin" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/CMakeWin/CMakeFiles/appNL_GUI_qmllint_module.dir/DependInfo.cmake" --color=$(COLOR)
.PHONY : CMakeFiles/appNL_GUI_qmllint_module.dir/depend

