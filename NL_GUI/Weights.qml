import QtQuick

Item {
    required property var layers
    property alias items: weights

    Repeater {
        id: weights
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
                }
            }
        }
    }
}
