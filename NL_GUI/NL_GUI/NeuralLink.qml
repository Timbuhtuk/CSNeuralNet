import QtQuick

Item {

    width: 640
    height: 480

    onWidthChanged: {canvas.requestPaint()}
    onHeightChanged: {canvas.requestPaint()}

    // the number of <layers> items is number of NL's layers, the value
    // indicates the number of neurons the layer has
    property var layers: [1, 2, 3, 1]

    Canvas {
        id: canvas

        anchors.fill: parent

        // assumes that elements will be sqare
        property int widthPerElement: width / (layers.length * 2)



        onPaint: {


            function getNeuronX(layer) {
                return (widthPerElement / 2) + (widthPerElement * layer)
            }

            function getNeuronY(number, index) {
                var fullSize = (widthPerElement * number)
                var center = (width / 2) - fullSize
                return center
            }

            var ctx = getContext("2d")

            // for every layer
            for (var i = 0; i < layers.length; i++) {

                // for every neuron
                for (var j = 0; j < layers[i]; j++) {

                    ctx.beginPath()
                    ctx.lineWidth = 5
                    ctx.arc(getNeuronX(i), getNeuronY(layers[i], j), widthPerElement / 2, 0, 2 * Math.PI)
                    //ctx.arc(neuronX, neuronY, widthPerElement / 2, 0, 2 * Math.PI)
                    ctx.stroke()

                }


            }




        }



    }


}
