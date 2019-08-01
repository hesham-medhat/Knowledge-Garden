(function () { // Immediately invoked startup function

    var connection = $.hubConnection();
    var hubProxy = connection.createHubProxy('notificationsHub');

    connection.logging = true; // DEBUG MODE

    $.connection.hub.stateChanged(function (change) {
        if ($.signalR.connectionState["connected"] === change.newState) {
            alert("We are now connected!");
        }
    });

    var displayNotification = function (flower) {

    }

    // Start the signalR connection
    connection.start()
    .done(
        function () {
            console.log("Connection started and done.");

            // Define function for server to call
            $.connection.notificationsHub.client.RecieveNotification = function (data) {
                debugger;
            };


            console.log("Before getUnreadNotifications");
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
                }
            );
            console.log("After getUnreadNotifications");
        }
    )
    .fail(
        function () {
            alert("Connection with the notification system failed.");
        }
    );

    

})()
