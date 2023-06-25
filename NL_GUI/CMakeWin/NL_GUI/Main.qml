import QtQuick
import QtQuick.Window
import QtQuick.Layouts
import QtQuick.Controls
import NL_GUI




Window {

    id: root

    width: 600
    height: 400
    visible: true
    title: "NL GUI"

    property var layersData: [1, 3, 2, 1]

    signal updateModel(var list)

    onUpdateModel: (list) => {
        layersData = list

        root.width += 1
        root.width -= 1
    }

    PipeReader {
        id: pipe

        onInitDataFetched: function(data) {
            root.updateModel(data)
        }

        onWeightDataFetched: function(layer, neuron, weight, value) {
            var line = neuralVisualization.getWeight(layer, neuron, weight)
            line.color = neuralVisualization.rgb(value, value - line.old, 0, 0)

            line.weightValue = value

            print("setting colors on ", line, ": ", line.weightValue, line.weightValue - line.old, 0, 0)
            line.old = line.weightValue
        }
    }

    Button {
        text: "Push Me "
        onPressed: {
            pipe.start()
        }
    }

    NeuralVisualization {
        id: neuralVisualization
        layers: layersData
    }
}











