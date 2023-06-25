import QtQuick
import QtQuick.Layouts
import QtQuick.Controls

Item {

    id: root

    property var circles: []
    property var lines: []


    GridLayout {
        anchors.fill: parent

        id: grid



    }

    function connectCircles() {

        print(lines)
        print(circles)

        for (var i = 0; i < lines.length; i++) {

            var prevCircle = circles[i].mapToItem(root, 20, 20)
            var nextCircle = circles[i + 1].mapToItem(root, 20, 20)

            print(prevCircle.x)
            print(nextCircle.x)


            lines[i].startX = prevCircle.x;
            lines[i].startY = prevCircle.y;
            lines[i].endX = nextCircle.x;
            lines[i].endY = nextCircle.y;


        }
    }

    onHeightChanged: {
        connectCircles()



    }
    onWidthChanged: {
        connectCircles()



    }

    Component.onCompleted: {

        var component = Qt.createComponent("CenteredCircle.qml")
        var componentLine = Qt.createComponent("Line.qml")


        for (var i = 0; i < 10; i++) {
            circles.push(component.createObject(grid))

        }

        for (var i = 0; i < 9; i++) {
            var line = componentLine.createObject(root)
            line.anchors.fill = parent
            lines.push(line)

        }


        connectCircles()

    }




}
