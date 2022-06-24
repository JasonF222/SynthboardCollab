// FunkyTown: A A G A  EE A D C A //

document.addEventListener("keydown", button1Pressed, true);
document.addEventListener("keyup", button1Released, true);

let pitchValue = "mid";
let sliderValue = 1;

var synthKeyContext = new (window.AudioContext || window.webkitAudioContext)();

var synthKeyElements = {
    81 : {
        elementReference : "synthKey1",
        high : 523.25,
        mid : 261.63,
        low : 130.81
    },
    87 : {
        elementReference : "synthKey2",
        high : 587.33,
        mid : 293.66,
        low : 146.83
    },
    69 : {
        elementReference : "synthKey3",
        high : 659.25,
        mid : 329.63,
        low : 164.81
    },
    82 : {
        elementReference : "synthKey4",
        high : 698.46,
        mid : 349.23,
        low : 174.61
    },
    84 : {
        elementReference : "synthKey5",
        high : 783.99,
        mid : 392.00,
        low : 196.00
    },
    89 : {
        elementReference : "synthKey6",
        high : 880.00,
        mid : 440.00,
        low : 220.00
    },
    85 : {
        elementReference : "synthKey7",
        high : 987.77,
        mid : 493.88,
        low : 246.94
    },
    73 : {
        elementReference : "synthKey8",
        high : 1046.50,
        mid : 523.25,
        low : 261.63
    },
    79 : {
        elementReference : "synthKey9",
        high : 1174.66	,
        mid : 587.33,
        low : 293.66
    },
    80 : {
        elementReference : "synthKey10",
        high : 1318.51,
        mid : 659.25,
        low : 329.63
    },

};

function button1Pressed(e) {
    if(e.keyCode == 32) {
        pitchValue = "mid";
        moveSlider(1);
    }
    if(e.keyCode == 16) {
        pitchValue = "high";
        moveSlider(2);
    }
    if(e.keyCode == 17) {
        pitchValue = "low";
        moveSlider(0);
    }
    OnOscillatorStart(e.keyCode);
    var synthKey = document.getElementById(synthKeyElements[e.keyCode].elementReference);
    keyChangerDown(synthKey);
}

function button1Released(e) {
    OnOscillatorStop(e.keyCode);
    var synthKey = document.getElementById(synthKeyElements[e.keyCode].elementReference);
    keyChangerUp(synthKey);
}

var oscillatorDictionary = {};

function OnOscillatorStart(key) {
    if (oscillatorDictionary[key]) {
        return;
    }

    //Create oscillator stuff;
    var oscillator = synthKeyContext.createOscillator();
    var gainNode = synthKeyContext.createGain();

    oscillator.connect(gainNode);
    gainNode.connect(synthKeyContext.destination);

    gainNode.gain.value = 0.02;
    oscillator.frequency.value = GetFrequency(key);
    oscillator.type = "triangle";
    oscillatorDictionary[key] = oscillator;
    oscillatorDictionary[key].start();
}

function OnOscillatorStop(key) {
    oscillatorDictionary[key].stop();
    oscillatorDictionary[key] = null;
}

function GetFrequency(key) {
    var keyGetter = synthKeyElements[key];
    if(pitchValue == "high") {
        return keyGetter.high;
    }
    else if(pitchValue == "low") {
        return keyGetter.low;
    }
    else {
        return keyGetter.mid;
    } 
}

function keyChangerDown(synthKey) {
    synthKey.style.backgroundColor = "rgb(115, 165, 40)";
}

function keyChangerUp(synthKey) {
    synthKey.style.backgroundColor = "black";
}

function moveSlider(val) {
    var textGrabber = document.querySelector(".slider-ball-text");
    var ballGrabber = document.getElementById("slider-ball");
    if(val == sliderValue) {
        return;
    }
    else if(val == 0) {
            ballGrabber.style.marginLeft = "-10px";
            sliderValue = 0;
            textGrabber.innerText = "Lo";
            return;
    }
    else if(val == 2) {
            ballGrabber.style.marginLeft = "54px";
            sliderValue = 2;
            textGrabber.innerText = "Hi";
            return;
    }
    else if(val == 1) {
            ballGrabber.style.marginLeft = "22px";
            sliderValue = 1;
            textGrabber.innerText = "Mid";
            return;
        }
    }

function directionBoxShow() {
    let divGrab = document.getElementById("directionBox");
    divGrab.style.transform = "scaleY(1)";
    divGrab.style.transitionDuration = "1s";
}

function directionBoxHide() {
    let divGrab = document.getElementById("directionBox");
    divGrab.style.transform = "scaleY(0)";
    divGrab.style.transitionDuration = "1s";
}