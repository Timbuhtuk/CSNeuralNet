cmake_minimum_required(VERSION 3.16)

project(NL_GUI VERSION 0.1 LANGUAGES CXX

)


set(CMAKE_CXX_STANDARD_REQUIRED ON
)

find_package(Qt6 6.4 REQUIRED COMPONENTS Quick)

qt_standard_project_setup()

qt_add_executable(appNL_GUI
    main.cpp pipe_reader.cpp pipe_worker.cpp pipe_reader.h pipe_worker.h
)


qt_add_qml_module(appNL_GUI
    URI NL_GUI
    VERSION 1.0
    QML_FILES Main.qml Layer.qml Line.qml CenteredCircle.qml
)

set_target_properties(appNL_GUI PROPERTIES
    MACOSX_BUNDLE_GUI_IDENTIFIER my.example.com
    MACOSX_BUNDLE_BUNDLE_VERSION ${PROJECT_VERSION}
    MACOSX_BUNDLE_SHORT_VERSION_STRING ${PROJECT_VERSION_MAJOR}.${PROJECT_VERSION_MINOR}
    MACOSX_BUNDLE TRUE
    WIN32_EXECUTABLE TRUE
)

set(HEADERS
    pipe_reader.h
    pipe_worker.h
)
set(SOURCES
    main.cpp
    pipe_reader.cpp
    pipe_worker.cpp
)


target_link_libraries(appNL_GUI
    PRIVATE Qt6::Quick
)

install(TARGETS appNL_GUI
    BUNDLE DESTINATION .
    LIBRARY DESTINATION ${CMAKE_INSTALL_LIBDIR}
    RUNTIME DESTINATION ${CMAKE_INSTALL_BINDIR}
)

