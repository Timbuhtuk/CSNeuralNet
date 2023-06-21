import QtQuick

Item {

    property int numberOfWeights: 0


    // Circle
    Rectangle {
        color: "lightblue"
        width: 40
        height: 40
        border { width: 3; color: "black"}
        radius: width * 0.5
    }

    Repeater {
        model: numberOfWeights
        delegate: Line {
            startX: 0
            startY: 0
            endX: 0
            endY: 0
        }


    }


}
