// ----------------
// Countdown Timer
var countdownTimer = function () {
    var clock = function (endTime) {
        var dateArray = endTime.split('-');

        var end = new Date(dateArray[1] + '/' + dateArray[0] + '/' + dateArray[2]);

        var second = 1000;
        var minute = second * 60;
        var hour = minute * 60;
        var day = hour * 24;
        var timer;

        function showRemaining() {
            var now = new Date();
            var timeLeft = end - now;
            var days = Math.floor(timeLeft / day);
            var hours = Math.floor((timeLeft % day) / hour);
            var minutes = Math.floor((timeLeft % hour) / minute);
            var seconds = Math.floor((timeLeft % minute) / second);

            document.getElementById('days').innerHTML = days;
            document.getElementById('hours').innerHTML = hours;
            document.getElementById('minutes').innerHTML = minutes;
            document.getElementById('seconds').innerHTML = seconds;
        }

        timer = setInterval(showRemaining, 1000);
    };

    return {
        clock: clock
    }
}();

