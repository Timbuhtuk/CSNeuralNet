import QtQuick
import QtQuick.Layouts

// TODO: move object placment and color logic to backend

Item {
    id: neurolink

    property var layers: [[]]

    signal updateModel(var list)

    onUpdateModel: (list) => {
        layers = list
        neurolink.width += 1
        neurolink.width -= 1
    }

    function rgb(r, g, b, a) {
          return "#"
               + (a ? a.toString(16).padStart(2, "0") : "")
               + r.toString(16).padStart(2, "0")
               + g.toString(16).padStart(2, "0")
               + b.toString(16).padStart(2, "0");
      }

    function getNeuron(layer, index) {

        var neu = neurons.itemAt(layer)
        if (neu) {

            neu = neu.items.itemAt(index)
            if (neu) {
                return neu.circle
            }

        }
        return null
    }

    function getWeight(layer, neuron, index) {

        var comp = weights.itemAt(layer)

        if (comp) {

            comp = comp.itemAt(neuron)
            if (comp) {

                comp = comp.itemAt(index)

                return comp
            }
        }
        return null
    }

    function setWeightValue(layer, neuron, weight, value) {
        var line = neuralVisualization.getWeight(layer, neuron, weight)

        if (line === null) {
            return
        }

        if (line.old > value) {
            line.color = neuralVisualization.rgb(value, 0, 0, 0)
        }

        else if (line.old === value) {
            line.color = neuralVisualization.rgb(0, value, 0, 0)
        }

        else if (line.old < value) {
            line.color = neuralVisualization.rgb(0, 0, value, 0)
        }

        line.old = value
    }

    function connectNeuronsBack() {
        for (var i = 1; i < layers.length; i++) {

            for (var j = 0; j < layers[i]; j++) {

                var startNeuron = getNeuron(i, j)
                var startNeuronPosition = startNeuron.mapToItem(root, 20, 20)

                for (var k = 0; k < layers[i - 1]; k++) {

                    var weight = getWeight(i, j, k)

                    var endNeuron = getNeuron(i - 1, k)

                    if (startNeuron === null || endNeuron === null || weight === null) {
                        continue
                    }

                    var endNeuronPosition = endNeuron.mapToItem(root, 20, 20)

                    weight.startX = startNeuronPosition.x
                    weight.startY = startNeuronPosition.y
                    weight.endX = endNeuronPosition.x
                    weight.endY = endNeuronPosition.y


                }
            }
        }
    }


    Repeater {
        id: weights
        model: layers.length

        delegate: Repeater {

            required property int index
            property int botIndex: index
            model: layers[index]

            delegate: Repeater {

                required property int index
                model: (botIndex === 0 ? layers[botIndex] : layers[botIndex - 1])

                delegate: Line {
                    required property int index
                    anchors.fill: parent
                }
            }
        }
    }

    RowLayout {
        id: neuronLayout

        z: 0
        anchors.fill: parent
        spacing: 0


        Repeater {
            id: neurons
            model: layers.length

            delegate: Layer {
                required property int index
                Layout.fillHeight: true
                Layout.fillWidth: true
                numberOfNeurons: layers[index]
            }
        }
    }

    onWidthChanged: {
        connectNeuronsBack()
    }

    onHeightChanged: {
        connectNeuronsBack()
    }

    Component.onCompleted: {
        connectNeuronsBack()
    }
}
