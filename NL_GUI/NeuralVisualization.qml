import QtQuick
import QtQuick.Layouts 1.0

Item {
    id: neurolink

    property var layers: [[]]

    anchors.fill: parent


    function update() {
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
        return neurons.itemAt(layer).items.itemAt(index).circle

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


        // return weights.itemAt(layer).itemAt(neuron).itemAt(index)
    }

    function connectNeurons() {
        for (var i = 0; i < layers.length - 1; i++) {

            for (var j = 0; j < layers[i]; j++) {

                var startNeuron = getNeuron(i, j)


                var smh = startNeuron.mapToItem(root, 20, 20)

                for (var k = 0; k < layers[i + 1]; k++) {

                    var weight = getWeight(i, j, k)

                    var endNeuron = getNeuron(i + 1, k)


                    var smh2 = endNeuron.mapToItem(root, 20, 20)

                    weight.startX = smh.x
                    weight.startY = smh.y
                    weight.endX = smh2.x
                    weight.endY = smh2.y

                }
            }
        }
    }



    Repeater {
        id: weights
        model: layers.length - 1

        delegate: Repeater {

            required property int index
            property int botIndex: index
            model: layers[index]

            delegate: Repeater {

                required property int index
                model: layers[botIndex + 1]

                delegate: Line {
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
                numberOfNeurons: layers[index]
            }
        }
    }



    onWidthChanged: {
        connectNeurons()
    }

    onHeightChanged: {
        connectNeurons()
    }

    Component.onCompleted: {
        connectNeurons()
    }
}
