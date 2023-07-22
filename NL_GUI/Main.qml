import QtQuick
import QtQuick.Window
import QtQuick.Layouts
import QtQuick.Controls
import NL_GUI

ApplicationWindow {
    id: root

    width: 1000
    height: 400
    visible: true
    title: "NL GUI"

    property var layersData: [1, 3, 2, 1]

    RowLayout {
        id: mainLayout

        anchors.fill: parent

        NeuralVisualization {
            id: neuralVisualization
            layers: layersData

            Layout.fillWidth: true
            Layout.fillHeight: true
        }

        ControlPanel {
            Layout.fillHeight: true
            Layout.fillWidth: true
        }
    }


    PipeReader {
        id: pipe

        onInitDataFetched: function(data) {
            neuralVisualization.updateModel(data)
        }

        onWeightDataFetched: (layer, neuron, weight, value) => {
            neuralVisualization.setWeightValue(layer, neuron, weight, value)
        }
    }
}











