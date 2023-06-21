import QtQuick

Item {
    property alias circle: circle

    Rectangle {
        id: circle

        x: parent.width / 2
        y: parent.height / 2
        width: 40
        height: 40

        color: "lightblue"
        border { width: 3; color: "black"}
        radius: width * 0.5
    }
}
