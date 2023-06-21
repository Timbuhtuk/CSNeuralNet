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
    // title: qsTr("Hello World")


    property var layers: [1, 2, 3, 5, 2, 2]
    property int numberOfLayers: layers.length

    PipeReader {
        id: pipe

        onInitDataFetched: function(data) {


            layers = data;
            connectNeurons()
        }

        onWeightDataFetched: function(layer, neuron, weight, value) {

            print("on weight triggered, with value", value)
            getWeight(layer, neuron, weight).color = rgb(value, 0, 0, 0)


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

                    print("got over here")
                    if (i === layer && j === neuron && k === weight) {
                        print("returning object...")
                        return repeat.itemAt(counter)
                    }

                    counter++


                }
            }
        }
    }

    Button {
        property int red: 0
        text: "Push Me "
        onPressed: {


            pipe.start()



            // red += 20
            // getWeight(0, 0, 1).color = rgb(red, 0, 0, 0)
        }
    }

    Button {
        id: heck
        text: pipe.str
        y: 30
    }

    Item {
        anchors.fill: parent

        RowLayout {
            id: rowlayout

            z: 99

            anchors.fill: parent

            spacing: 0
            property alias repp: rep

            Repeater {
                id: rep

                model: numberOfLayers

                delegate: Layer {
                                required property int index

                                Layout.alignment: Qt.AlignCenter
                                numberOfNeurons: layers[index]
                                numberOfPrevNeurons: layers[index]
                                numberOfNextNeurons: index < (layers.length > index) ? layers[index + 1] : 0
                            }



                }
            }


        }

        function getNeuron(layer, index) {
                    return rowlayout.repp.itemAt(layer).col.list.itemAt(index).heck

        }


        Repeater {
            id: repeat
            model: getNeuroSum(layers)

            delegate: Line {
                    anchors.fill: parent
                    startX: 0
                    startY: 0
                }

        }




        function connectNeurons() {

            var neu = 0

            for (var i = 0; i < layers.length - 1; i++)
            {
                for (var j = 0; j < layers[i]; j++)
                {
                    var startNeuron = getNeuron(i, j)
                    var smh = startNeuron.mapToItem(root, 20, 20)

                    for (var k = 0; k < layers[i + 1]; k++)
                    {



                        var weight = repeat.itemAt(neu)

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





/*


            var item = getNeuron(0, 0)
            var smh = item.mapToGlobal(0, 0)

            var item2 = getNeuron(1, 1)
            var smh2 = item2.mapToGlobal(0, 0)

            neu.startX = smh.x + 20
            neu.startY = smh.y + 20

            neu.endX = smh2.x + 20
            neu.endY = smh2.y + 20*/
        }


        onHeightChanged: {
            print(getNeuroSum(layers))
            connectNeurons()



        }



        onWidthChanged: {
            connectNeurons()



        }
}











