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

# Utility rule file for appNL_GUI_tooling.

# Include any custom commands dependencies for this target.
include CMakeFiles/appNL_GUI_tooling.dir/compiler_depend.make

# Include the progress variables for this target.
include CMakeFiles/appNL_GUI_tooling.dir/progress.make

NL_GUI/Main.qml: /home/kotowhiskas/Programming\ Projects/QML\ Projects/NL_GUI/Main.qml
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --blue --bold --progress-dir="/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/CMakeWin/CMakeFiles" --progress-num=$(CMAKE_PROGRESS_1) "Generating NL_GUI/Main.qml"
	cd "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI" && /home/kotowhiskas/Documents/mxe/usr/x86_64-pc-linux-gnu/bin/cmake -E copy "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/Main.qml" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/CMakeWin/NL_GUI/Main.qml"

NL_GUI/Layer.qml: /home/kotowhiskas/Programming\ Projects/QML\ Projects/NL_GUI/Layer.qml
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --blue --bold --progress-dir="/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/CMakeWin/CMakeFiles" --progress-num=$(CMAKE_PROGRESS_2) "Generating NL_GUI/Layer.qml"
	cd "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI" && /home/kotowhiskas/Documents/mxe/usr/x86_64-pc-linux-gnu/bin/cmake -E copy "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/Layer.qml" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/CMakeWin/NL_GUI/Layer.qml"

NL_GUI/Line.qml: /home/kotowhiskas/Programming\ Projects/QML\ Projects/NL_GUI/Line.qml
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --blue --bold --progress-dir="/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/CMakeWin/CMakeFiles" --progress-num=$(CMAKE_PROGRESS_3) "Generating NL_GUI/Line.qml"
	cd "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI" && /home/kotowhiskas/Documents/mxe/usr/x86_64-pc-linux-gnu/bin/cmake -E copy "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/Line.qml" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/CMakeWin/NL_GUI/Line.qml"

NL_GUI/CenteredCircle.qml: /home/kotowhiskas/Programming\ Projects/QML\ Projects/NL_GUI/CenteredCircle.qml
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --blue --bold --progress-dir="/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/CMakeWin/CMakeFiles" --progress-num=$(CMAKE_PROGRESS_4) "Generating NL_GUI/CenteredCircle.qml"
	cd "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI" && /home/kotowhiskas/Documents/mxe/usr/x86_64-pc-linux-gnu/bin/cmake -E copy "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/CenteredCircle.qml" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/CMakeWin/NL_GUI/CenteredCircle.qml"

appNL_GUI_tooling: NL_GUI/CenteredCircle.qml
appNL_GUI_tooling: NL_GUI/Layer.qml
appNL_GUI_tooling: NL_GUI/Line.qml
appNL_GUI_tooling: NL_GUI/Main.qml
appNL_GUI_tooling: CMakeFiles/appNL_GUI_tooling.dir/build.make
.PHONY : appNL_GUI_tooling

# Rule to build all files generated by this target.
CMakeFiles/appNL_GUI_tooling.dir/build: appNL_GUI_tooling
.PHONY : CMakeFiles/appNL_GUI_tooling.dir/build

CMakeFiles/appNL_GUI_tooling.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/appNL_GUI_tooling.dir/cmake_clean.cmake
.PHONY : CMakeFiles/appNL_GUI_tooling.dir/clean

CMakeFiles/appNL_GUI_tooling.dir/depend:
	cd "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/CMakeWin" && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/CMakeWin" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/CMakeWin" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/CMakeWin/CMakeFiles/appNL_GUI_tooling.dir/DependInfo.cmake" --color=$(COLOR)
.PHONY : CMakeFiles/appNL_GUI_tooling.dir/depend
