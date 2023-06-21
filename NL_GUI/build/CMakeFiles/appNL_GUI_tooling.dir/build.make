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
CMAKE_COMMAND = /usr/bin/cmake

# The command to remove a file.
RM = /usr/bin/cmake -E rm -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI"

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/build"

# Utility rule file for appNL_GUI_tooling.

# Include any custom commands dependencies for this target.
include CMakeFiles/appNL_GUI_tooling.dir/compiler_depend.make

# Include the progress variables for this target.
include CMakeFiles/appNL_GUI_tooling.dir/progress.make

NL_GUI/Main.qml: /home/kotowhiskas/Programming\ Projects/QML\ Projects/NL_GUI/Main.qml
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --blue --bold --progress-dir="/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/build/CMakeFiles" --progress-num=$(CMAKE_PROGRESS_1) "Generating NL_GUI/Main.qml"
	cd "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI" && /usr/bin/cmake -E copy "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/Main.qml" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/build/NL_GUI/Main.qml"

NL_GUI/Layer.qml: /home/kotowhiskas/Programming\ Projects/QML\ Projects/NL_GUI/Layer.qml
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --blue --bold --progress-dir="/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/build/CMakeFiles" --progress-num=$(CMAKE_PROGRESS_2) "Generating NL_GUI/Layer.qml"
	cd "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI" && /usr/bin/cmake -E copy "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/Layer.qml" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/build/NL_GUI/Layer.qml"

NL_GUI/Line.qml: /home/kotowhiskas/Programming\ Projects/QML\ Projects/NL_GUI/Line.qml
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --blue --bold --progress-dir="/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/build/CMakeFiles" --progress-num=$(CMAKE_PROGRESS_3) "Generating NL_GUI/Line.qml"
	cd "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI" && /usr/bin/cmake -E copy "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/Line.qml" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/build/NL_GUI/Line.qml"

NL_GUI/NeuralLink.qml: /home/kotowhiskas/Programming\ Projects/QML\ Projects/NL_GUI/NeuralLink.qml
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --blue --bold --progress-dir="/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/build/CMakeFiles" --progress-num=$(CMAKE_PROGRESS_4) "Generating NL_GUI/NeuralLink.qml"
	cd "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI" && /usr/bin/cmake -E copy "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/NeuralLink.qml" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/build/NL_GUI/NeuralLink.qml"

NL_GUI/Neuron.qml: /home/kotowhiskas/Programming\ Projects/QML\ Projects/NL_GUI/Neuron.qml
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --blue --bold --progress-dir="/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/build/CMakeFiles" --progress-num=$(CMAKE_PROGRESS_5) "Generating NL_GUI/Neuron.qml"
	cd "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI" && /usr/bin/cmake -E copy "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/Neuron.qml" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/build/NL_GUI/Neuron.qml"

NL_GUI/Weights.qml: /home/kotowhiskas/Programming\ Projects/QML\ Projects/NL_GUI/Weights.qml
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --blue --bold --progress-dir="/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/build/CMakeFiles" --progress-num=$(CMAKE_PROGRESS_6) "Generating NL_GUI/Weights.qml"
	cd "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI" && /usr/bin/cmake -E copy "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/Weights.qml" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/build/NL_GUI/Weights.qml"

appNL_GUI_tooling: NL_GUI/Layer.qml
appNL_GUI_tooling: NL_GUI/Line.qml
appNL_GUI_tooling: NL_GUI/Main.qml
appNL_GUI_tooling: NL_GUI/NeuralLink.qml
appNL_GUI_tooling: NL_GUI/Neuron.qml
appNL_GUI_tooling: NL_GUI/Weights.qml
appNL_GUI_tooling: CMakeFiles/appNL_GUI_tooling.dir/build.make
.PHONY : appNL_GUI_tooling

# Rule to build all files generated by this target.
CMakeFiles/appNL_GUI_tooling.dir/build: appNL_GUI_tooling
.PHONY : CMakeFiles/appNL_GUI_tooling.dir/build

CMakeFiles/appNL_GUI_tooling.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/appNL_GUI_tooling.dir/cmake_clean.cmake
.PHONY : CMakeFiles/appNL_GUI_tooling.dir/clean

CMakeFiles/appNL_GUI_tooling.dir/depend:
	cd "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/build" && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/build" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/build" "/home/kotowhiskas/Programming Projects/QML Projects/NL_GUI/build/CMakeFiles/appNL_GUI_tooling.dir/DependInfo.cmake" --color=$(COLOR)
.PHONY : CMakeFiles/appNL_GUI_tooling.dir/depend

