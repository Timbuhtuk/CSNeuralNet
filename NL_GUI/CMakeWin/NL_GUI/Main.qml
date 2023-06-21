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

    property var layers: [1, 3, 2, 1]
    property var k: layers





    property int numberOfLayers: layers.length

    property alias itemList: layerItems
    property alias weightList: rep



    function rgb(r, g, b, a) {
          return "#"
               + (a ? a.toString(16).padStart(2, "0") : "")
               + r.toString(16).padStart(2, "0")
               + g.toString(16).padStart(2, "0")
               + b.toString(16).padStart(2, "0");
      }

    function getNeuron(layer, index) {
        return itemList.itemAt(layer).items.itemAt(index).circle

    }

    function getNeuroSum(array) {
        var sum = 0

        for (var i = 0; i < layers.length - 1; i++) {

            sum += layers[i] + (layers[i] *layers[i + 1])

        }

        return sum
    }


    function getWeight(layer, neuron, index) {
        var layerobj = weightList.itemAt(layer)
        var neuronobj = layerobj.itemAt(neuron)
        return neuronobj.itemAt(index)

    }

    function connectNeurons(yes) {

        var neu = 0

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

                    neu++
                }
            }
        }


    }


    PipeReader {
        id: pipe

        onInitDataFetched: function(data) {
            layers = data

        }

        onWeightDataFetched: function(layer, neuron, weight, value) {

            var line = getWeight(layer, neuron, weight)
            line.color = rgb(value, value - line.old, 0, 0)

            line.old = line.weightValue
            line.weightValue = value


            print("setting colors on ", line, ": ", line.weightValue, line.weightValue - line.old, 0, 0)
        }
        /*
        onWeightFetchedFlat: function(number, value) {
            repeat.itemAt(number).color = rgb(value, 0, 0, 0)
        }
        */


    }
    Button {
        property int red: 0
        text: "Push Me "
        onPressed: {
            pipe.start()
        }
    }


    Item {
        anchors.fill: parent
        id: it


    Item {

        z: 99

        anchors.fill: parent

        RowLayout {
            id: layerLayout
            anchors.fill: parent
            spacing: 0


            Component.onCompleted: {
                root.width = 600
                root.height = 400
                connectNeurons()
            }


            Repeater {
                id: layerItems
                model: numberOfLayers
                delegate: Layer {
                    required property int index
                    Layout.alignment: Qt.AlignCenter
                    numberOfNeurons: layers[index]
                }
            }
        }
    }

    Repeater {
        id: rep
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
                    startX: 0
                    startY: 0
                    Component.onCompleted: {
                        print("Created")
                    }

                }

            }

        }


    }





    onHeightChanged: {
        connectNeurons()

    }

    onWidthChanged: {
        connectNeurons(true)
    }

    function trigger() {

        root.width = 600
        root.height = 400
    }

    Component.onCompleted: {
        connectNeurons(true)
        root.onLayersChanged.connect(trigger)
        root.onLayersChanged.connect(connectNeurons)

    }

    }
}











