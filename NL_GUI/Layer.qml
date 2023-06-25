import QtQuick
import QtQuick.Layouts
import QtQuick.Controls




ColumnLayout {

    required property int numberOfNeurons
    property alias items: repeater
    id: layout

    Repeater {

        id: repeater
        model: numberOfNeurons

        delegate: CenteredCircle {
            Layout.fillHeight: true
            Layout.fillWidth: true

        }
    }
}



