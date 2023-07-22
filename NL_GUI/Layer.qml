import QtQuick
import QtQuick.Layouts
import QtQuick.Controls

ColumnLayout {
    id: layer

    required property int numberOfNeurons
    property alias items: repeater

    Repeater {

        id: repeater
        model: numberOfNeurons

        delegate: CenteredCircle {
            Layout.fillHeight: true
            Layout.fillWidth: true

        }
    }
}
