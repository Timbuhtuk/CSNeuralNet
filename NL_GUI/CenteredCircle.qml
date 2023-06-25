import QtQuick

Item {
    property alias circle: circle





    /**
      Connect to each parent's 'onXChanged' and 'onYChanged' signals.
    */
     function setPositionChangedToParents(current, item) {
        while (current && current.parent) {

            var fn = function() {
                calculatePropertyNameX(item)
                calculatePropertyNameY(item)
            }

            current.onXChanged.connect(fn);
            current.onYChanged.connect(fn);
            current = current.parent;
        }
    }


    /**
      Disconnects the signals set to all parents.
    */
     function removePositionChangedFromParents(current) {
        while (current && current.parent) {
            current.onXChanged.disconnect(calculatePropertyNameX);
            current.onYChanged.disconnect(calculatePropertyNameY);
            current = current.parent;
        }
    }


    /**
      When any parent's 'x' changes, recalculate the 'x' value for the 'property name'.
    */
    function calculatePropertyNameX(item) {
        var calculatedX, current;

        calculatedX = 0;
        current = item;

        while (current && current.parent) {
            calculatedX += current.x;
            current = current.parent;
        }

        item.propertyNameX = calculatedX;
    }


    /**
      When any parent's 'y' changes, recalculate the 'y' value for the 'property name'.
    */
     function calculatePropertyNameY(item) {
        var calculatedY, current;

        calculatedY = 0;
        current = item;

        while (current && current.parent) {
            calculatedY += current.y;
            current = current.parent;
        }

        item.propertyNameY = calculatedY;
    }


    Rectangle {
        id: circle

        x: parent.width / 2
        y: parent.height / 2
        width: 40
        height: 40

        color: "lightblue"
        border { width: 3; color: "black"}
        radius: width * 0.5


        property real propertyNameX: 0

        property real propertyNameY: 0


    }
}
