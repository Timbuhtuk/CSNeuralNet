import QtQuick
import QtQuick.Window
import QtQuick.Layouts
import QtQuick.Controls
import QtQuick.Dialogs

import NL_GUI

Item {
    id: root

    ColumnLayout {
        anchors.fill: parent

        Repeater {
            id: rep

            model: configwrt.getNumberOfEntries()

            delegate: RowLayout {
                required property int index
                property alias textField: textField

                Label {
                    text: configwrt.getEntry(index)

                }

                Item {
                    Layout.fillWidth: true
                }

                TextField {
                    id: textField
                    text: configwrt.getValue(index)
                    onTextEdited: {
                        applyButton.enabled = true
                    }
                }
            }
        }

        Item {
            id: spacer
            Layout.fillHeight: true
            Layout.fillWidth: true
        }

        Button {
            Layout.alignment: Qt.AlignRight

            id: applyButton
            enabled: false
            text: "Apply"

            onPressed: {
                print("pressed")
                applyButton.enabled = false

                for (var i = 0; i < configwrt.getNumberOfEntries(); i++) {
                    print("setting value")
                    print(configwrt.getEntry(i), rep.itemAt(i).fld.text)
                    configwrt.setValue(configwrt.getEntry(i), rep.itemAt(i).fld.text)
                }
                configwrt.update("Config.txt")

                var component = Qt.createComponent("CustomDialog.qml")
                var dialog = component.createObject(root)
                dialog.controls.onAccepted.connect(function lambda() {print("rabotaet, blin")} )
                dialog.show()
            }
        }

    }

    ConfigWriter {
        id: configwrt
        Component.onCompleted: {
            configwrt.load()
        }
    }
}
