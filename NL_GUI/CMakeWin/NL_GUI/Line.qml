import QtQuick

Item {
    id: line

    function rgb(r, g, b, a) {
          return "#"
               + (a ? a.toString(16).padStart(2, "0") : "")
               + r.toString(16).padStart(2, "0")
               + g.toString(16).padStart(2, "0")
               + b.toString(16).padStart(2, "0");
      }

    property int weightValue: 0
    property int old: 0

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
