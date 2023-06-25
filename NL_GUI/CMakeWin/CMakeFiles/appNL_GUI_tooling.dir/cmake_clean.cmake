file(REMOVE_RECURSE
  "NL_GUI/CenteredCircle.qml"
  "NL_GUI/Layer.qml"
  "NL_GUI/Line.qml"
  "NL_GUI/Main.qml"
  "NL_GUI/NeuralVisualization.qml"
  "NL_GUI/Weights.qml"
)

# Per-language clean rules from dependency scanning.
foreach(lang )
  include(CMakeFiles/appNL_GUI_tooling.dir/cmake_clean_${lang}.cmake OPTIONAL)
endforeach()
