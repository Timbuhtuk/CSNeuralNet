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

        var comp = weights.itemAt(layer + 1)

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

    function connectNeuronsBack() {
        for (var i = 1; i < layers.length; i++) {

            for (var j = 0; j < layers[i]; j++) {

                var startNeuron = getNeuron(i, j)
                var smh = startNeuron.mapToItem(root, 20, 20)

                for (var k = 0; k < layers[i - 1]; k++) {

                    var weight = getWeight(i - 1, j, k)

                    var endNeuron = getNeuron(i - 1, k)
                    // print("connecting weight of ", i, j, k, "from", i, j, "to", i - 1, k, "misc", j, layers[i])

                    if (startNeuron === null || endNeuron === null || weight === null) {
                        print("not found")
                        continue
                    }

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
        model: layers.length

        delegate: Repeater {

            required property int index
            property int botIndex: index
            model: layers[index]

            delegate: Repeater {

                required property int index

                property int anotherIndex: index
                model: (botIndex === 0 ? 0 : layers[botIndex - 1])

                delegate: Line {
                    required property int index

                    anchors.fill: parent

                    Component.onCompleted: {
                        // print("created;", botIndex, anotherIndex, index)
                    }
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
        connectNeuronsBack()
    }

    onHeightChanged: {
        connectNeuronsBack()
    }

    Component.onCompleted: {
        connectNeuronsBack()
    }
}
