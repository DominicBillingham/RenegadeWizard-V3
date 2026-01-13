
function ScrollToBottom() {
    const display = document.getElementById('consoleOutput');
    if (display) {
        display.scrollTop = display.scrollHeight;
    }
}


window.audioInstance = new Audio();

function PlaySound(src, overrideAudio = false) {


    if (overrideAudio) {
        window.audioInstance.pause();
        window.audioInstance.currentTime = 0;
        window.audioInstance = new Audio(src);
        window.audioInstance.volume = 1;
        window.audioInstance.play();
        return;
    }


    var sound = new Audio(src);
    sound.volume = 0.3;
    sound.play();
}

function ConsoleSound(e) {
    if (e.key === "Enter") {
        playEnterSound();
    } else if (e.key.length === 1) {
        // Only play typing sound for printable characters
        playTypingSound();
    }
}


var lastTypedTime = 0;

function playTypingSound() {

    const now = Date.now();
    const throttle = 50 + Math.random() * 30;  // 50-80ms
    if (now - lastTypedTime < throttle) return; // Throttle typing sounds
    lastTypedTime = now;

    const audio = new Audio("/sound/typing.mp3");
    audio.playbackRate = 0.80 + Math.random() * 0.7; // slight pitch variation
    audio.volume = 0.1 + Math.random() * 0.1;        // volume 0.1–0.2
    audio.play();
}

function playEnterSound() {
    const audio = new Audio("/sound/enter.wav");
    audio.volume = 0.3;
    audio.play();
}
