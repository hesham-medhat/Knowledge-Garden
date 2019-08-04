(function () { // Immediately invoked startup function

    var connection = $.hubConnection();
    var hubProxy = connection.createHubProxy('notificationsHub');

    connection.logging = true; // DEBUG MODE

    // Define function for server to call
    hubProxy.on('receiveNotification', function (flower) {
        console.log("Online push notification call succeeded");
        reportNotificationsInMsg.call();
        var notificationsList = document.getElementById("notificationsList");
        appendNotification(flower, notificationsList);
    });

    $.connection.hub.stateChanged(function (change) {
        if ($.signalR.connectionState["connected"] === change.newState) {
            alert("We are now connected!");
        }
    });

    /******************************* START: DOM UPDATING FUNCTIONS */
    var reportNotificationsInMsg = function () {
        var notificationsMessage = document.getElementById("notificationsMessage");
        notificationsMessage.textContent = "You have unread notifications!";
    }

    var appendNotification = function (flower, notificationsList) {
        var liFlower = document.createElement("li");

        var a = document.createElement("a");
        a.href = "Flowers/Details/" + flower.Id;
        a.text = flower.OwnerUsername + " has planted a new flower titled: \"" + flower.Title + "\"";

        liFlower.appendChild(a);
        notificationsList.appendChild(liFlower);

        var separator = document.createElement("li");
        separator.className = "divider";

        notificationsList.appendChild(separator);
    }

    var displayNotifications = function (flowers) {
        notificationsComparator =
            function compare(a, b) {
                if (a.LastUpdateDate < b.LastUpdateDate)
                    return -1;
                if (a.LastUpdateDate > b.LastUpdateDate)
                    return 1;
                return 0;
            };

        flowers.sort(notificationsComparator);

        var notificationsList = document.getElementById("notificationsList");

        if (flowers.length > 0) {
            reportNotificationsInMsg.call();

            var separator = document.createElement("li");
            separator.className = "divider";

            notificationsList.appendChild(separator);
        }

        flowers.forEach(
            function (f) {
                appendNotification(f, notificationsList);
            }
            );
    }
    /******************************* END: DOM UPDATING FUNCTIONS */

    // Start the signalR connection
    connection.start()
    .done(
        function () {
            console.log("Connection started and done.");

            // Fetch notifications from server
            hubProxy.invoke('getUnreadNotifications')
            .done(
                function () {
                    console.log("Notifications retrieval call succeeded");
                }
            )
            .fail(
                function () {
                    console.error("Notifications retrieval call failed");
                }
            )
            .then(
                function (flowers) {
                    console.log(flowers);
                    displayNotifications(flowers);
                }
            );
        }
    )
    .fail(
        function () {
            alert("Connection with the notification system failed.");
        }
    );

    

})()
