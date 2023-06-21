import QtQuick

Item {

    property string color: "black"
    property int startX
    property int startY
    property int endX
    property int endY


    onColorChanged: { canvas.requestPaint() }
    onStartXChanged: { canvas.requestPaint() }
    onStartYChanged: { canvas.requestPaint() }
    onEndXChanged: { canvas.requestPaint() }
    onEndYChanged: { canvas.requestPaint() }



    Canvas {


        id: canvas


        property int startX: parent.startX
        property int startY: parent.startY

        property int endX: parent.endX
        property int endY: parent.endY


        anchors.fill: parent

        onPaint: {
            var ctx = getContext("2d")
            ctx.strokeStyle = color
            ctx.lineWidth = 4
            ctx.beginPath()
            ctx.moveTo(startX, startY)
            ctx.lineTo(endX, endY)

            ctx.stroke()

        }

    }



}
