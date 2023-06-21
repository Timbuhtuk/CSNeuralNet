import QtQuick
import QtQuick.Layouts
import QtQuick.Controls
RowLayout {



    required property int numberOfPrevNeurons
    required property int numberOfNextNeurons
    property int numberOfWeights: numberOfPrevNeurons * numberOfNextNeurons

    required property int numberOfNeurons;
    property Repeater items: nlist


    spacing: 0

    property alias col: neurons
    property alias lst: weigths


    ColumnLayout {
        Layout.fillHeight: true
        id: neurons


        property alias list: nlist

        Repeater {

            id: nlist
            model: numberOfNeurons

            delegate:
                Item {

                property alias heck: neu


                Layout.fillHeight: true

                Layout.fillWidth: true

                Rectangle {

                    id: neu
                    x: parent.width / 2

                    y: parent.height / 2

                    Layout.alignment: Qt.AlignCenter
                    color: "lightblue"
                    width: 40
                    height: 40
                    border { width: 3; color: "black"}
                    radius: width * 0.5
            }
            }

        }




    }


    Item {

        id: weigths
        Layout.alignment: Qt.AlignCenter

        Layout.fillWidth: true

        // Layout.preferredWidth: 50
        Layout.fillHeight: true

        property alias d: wlist


        Repeater {
               id: wlist

               model: numberOfWeights
               delegate: Line {
                   anchors.fill: parent

                   required property int index

                   startX: 0
                   startY: 0
                   endX: parent.width
                   endY: 0

               }
        }
    }





}

