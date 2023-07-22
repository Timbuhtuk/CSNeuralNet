import QtQuick
import QtQuick.Window
import QtQuick.Layouts
import QtQuick.Controls

Window {

    id: root

    width: 0
    height: 0
    visible: true
    title: "NL GUI"

    property var layers: [1, 3, 2, 1]
    property var neurons: []
    property var weights: []

    function destroyAll() {

        for (var i = 0; i < layers.length; i++) {
            for (var j = 0; j < layers[i]; j++) {

                neurons[i][j].destroy()

                for (var k = 0; k < layers[i + 1]; k++) {
                    weights[i][j][k].destroy()
                }
            }
        }

        weights = []
        neurons = []

        print("destroyed")
    }

    function createNeurons() {
        var neuronComponent = Qt.createComponent("CenteredCircle.qml")
        var lineComponent = Qt.createComponent("Line.qml")


        for (var i = 0; i < layers.length; i++) {
            neurons.push([])
            weights.push([])

            for (var j = 0; j < layers[i]; j++) {

                var neuron = neuronComponent.createObject(layerItems.itemAt(i))


                neuron.Layout.fillHeight = true
                neuron.Layout.fillWidth = true

                neurons[neurons.length - 1].push(neuron)

                if (i + 1 >= layers.length) {
                    continue
                }
                var a = weights[weights.length - 1]
                a.push([])



                for (var k = 0; k < layers[i + 1]; k++) {

                    var lineobj = lineComponent.createObject(root)
                    lineobj.anchors.fill = lineobj.parent


                    var linnes = a[a.length - 1]
                    linnes.push(lineobj)


                }


            }


        }

    }


    function getNeuroSum(array) {
        var sum = 0

        for (var i = 0; i < layers.length - 1; i++) {

            sum += layers[i] + (layers[i] *layers[i + 1])

        }

        return sum
    }


    function rgb(r, g, b, a) {
          return "#"
               + (a ? a.toString(16).padStart(2, "0") : "")
               + r.toString(16).padStart(2, "0")
               + g.toString(16).padStart(2, "0")
               + b.toString(16).padStart(2, "0");
      }


    function getWeight(layer, neuron, weight) {

        var counter = 0
        for (var i = 0; i < layers.length - 1; i++)
        {
            for (var j = 0; j < layers[i]; j++)
            {

                for (var k = 0; k < layers[i + 1]; k++)
                {

                    if (i === layer && j === neuron && k === weight) {
                        return repeat.itemAt(counter)
                    }

                    counter++


                }

            }
        }




    }

    function connectNeurons(x = 0, y = 0) {


        for (var i = 0; i < layers.length - 1; i++) {

            for (var j = 0; j < layers[i]; j++) {

                var startNeuron = neurons[i][j].circle
                var smh = startNeuron.mapToGlobal(20, 20)

                for (var k = 0; k < layers[i + 1]; k++) {


                    var endNeuron = neurons[i + 1][k].circle
                    var smh2 = endNeuron.mapToGlobal(20, 20)


                    var weight = weights[i][j][k]
                    weight.startX = smh.x
                    weight.startY = smh.y
                    weight.endX = smh2.x
                    weight.endY = smh2.y


                }
            }
        }
    }

    /*

    PipeReader {
        id: pipe

        onInitDataFetched: function(data) {
            layers = data
        }

        onWeightDataFetched: function(layer, neuron, weight, value) {
            try {
                weights[layer][neuron][weight].color = rgb(value, 0, 0, 0)
            }

            catch (error) {

            }
        }

        onWeightFetchedFlat: function(number, value) {
            repeat.itemAt(number).color = rgb(value, 0, 0, 0)
        }



    }

    */

    Button {
        property int red: 0
        text: "Push Me "
        onPressed: {
            destroyAll()
            createNeurons()
            connectNeurons()
        }
    }


    RowLayout {
        id: layerLayout
        anchors.fill: parent
        spacing: 0

        Component.onCompleted: {
            createNeurons()
            root.width = 600
            root.height = 400
            connectNeurons()
        }


        Repeater {
            id: layerItems
            model: layers.length
            delegate: Layer {
                required property int index
                Layout.alignment: Qt.AlignCenter
                numberOfNeurons: 0
            }
        }
    }



    onHeightChanged: {
        connectNeurons()
    }

    onWidthChanged: {
        connectNeurons()
    }
}











