import QtQuick
import QtQuick.Controls
import QtQuick.Layouts
import QtQuick.Window

Window {
    id: dialogWindow

    title: "Confirm restarting application"
    visible: true

    width: 345
    height: 150

    property alias controls: buttonBox

    ColumnLayout {
        id: dialogLayout


        anchors.fill: parent

        Label {
            Layout.margins: 5

            text: "To apply changes, app needs to be restarted."
        }


        Label {
            Layout.margins: 5

            text: "Would you like to restart now?"
        }


        DialogButtonBox {
            id: buttonBox

            Layout.fillWidth: true
            Layout.alignment: Qt.AlignBottom
            standardButtons: DialogButtonBox.Ok | DialogButtonBox.Cancel

            onClicked: (buttonType) => {
                root.close()
                root.destroy()
            }

        }

    }

}
