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

        // TODO: move logic to NeuralVisualization class
        onWeightDataFetched: function(layer, neuron, weight, value) {
            print("entering weight function", layer, neuron, weight, "with value", value)
            var line = neuralVisualization.getWeight(layer, neuron, weight)

            if (line === null) {
                print("weight ", layer, neuron, weight, "with value", value, "doesn't exist")
                return
            }

            if (line.old > value) {
                line.color = neuralVisualization.rgb(value, 0, 0, 0)
                print("setting colors on ", layer, neuron, weight, "with value", ": R: ", value, "G: ", 0, "B: ", 0)

            }

            else {
                line.color = neuralVisualization.rgb(0, value, 0, 0)
                print("setting colors on ", layer, neuron, weight, "with value", ": R: ", 0, "G: ", value, "B: ", 0)

            }



            line.old = value
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











