import QtQuick

Item {
    id: line

    property int old: 0

    property string color: "black"

    property int startX
    property int startY
    property int endX
    property int endY

    onColorChanged:  { canvas.requestPaint() }
    onStartXChanged: { canvas.requestPaint() }
    onStartYChanged: { canvas.requestPaint() }
    onEndXChanged:   { canvas.requestPaint() }
    onEndYChanged:   { canvas.requestPaint() }

    Canvas {
        id: canvas

        anchors.fill: parent

        onPaint: {
            var ctx = getContext("2d")
            ctx.strokeStyle = color
            ctx.lineWidth = 4
            ctx.beginPath()
            ctx.moveTo(parent.startX, parent.startY)
            ctx.lineTo(parent.endX, parent.endY)

            ctx.stroke()
        }
    }
}
