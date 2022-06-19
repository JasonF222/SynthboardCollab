// FunkyTown: A A G A  EE A D C A //

document.addEventListener("keydown", button1Pressed, true);
document.addEventListener("keyup", button1Released, true);



var synthKeyContext = new (window.AudioContext || window.webkitAudioContext)();
var synthKeyElements = {
    81 : "synthKey1",
    87 : "synthKey2",
    69 : "synthKey3",
    82 : "synthKey4",
    84 : "synthKey5",
    89 : "synthKey6",
    85 : "synthKey7",
    73 : "synthKey8",
    79 : "synthKey9",
    80 : "synthKey10"
};



function button1Pressed(e) {
    OnOscillatorStart(e.keyCode);
    var synthKey = document.getElementById(synthKeyElements[e.keyCode]);
    keyChangerDown(synthKey);
    // if(e.keyCode == 81) {
    //     var synthKey = document.getElementById(synthKeyElements[e.keyCode]);
    //     keyChangerDown(synthKey);
        
    // }
    // else if(e.keyCode == 87) {
    //     var synthKey = document.getElementById("synthKey2");
    //     keyChangerDown(synthKey);
    // }
    // else if(e.keyCode == 69) {
    //     var synthKey = document.getElementById("synthKey3");
    //     keyChangerDown(synthKey);
    // }
    // else if(e.keyCode == 82) {
    //     var synthKey = document.getElementById("synthKey4");
    //     keyChangerDown(synthKey);
    // }
    // else if(e.keyCode == 84) {
    //     var synthKey = document.getElementById("synthKey5");
    //     keyChangerDown(synthKey);
    // }
    // else if(e.keyCode == 89) {
    //     var synthKey = document.getElementById("synthKey6");
    //     keyChangerDown(synthKey);
    // }
    // else if(e.keyCode == 85) {
    //     var synthKey = document.getElementById("synthKey7");
    //     keyChangerDown(synthKey);
    // }
    // else if(e.keyCode == 73) {
    //     var synthKey = document.getElementById("synthKey8");
    //     keyChangerDown(synthKey);
    // }
    // else if(e.keyCode == 79) {
    //     var synthKey = document.getElementById("synthKey9");
    //     keyChangerDown(synthKey);
    // }
    // else if(e.keyCode == 80) {
    //     var synthKey = document.getElementById("synthKey10");
    //     keyChangerDown(synthKey);
    // }
}

function button1Released(e) {
    OnOscillatorStop(e.keyCode);
    var synthKey = document.getElementById(synthKeyElements[e.keyCode]);
    keyChangerUp(synthKey);
    // if(e.keyCode == 81) {
    // var synthKey = document.getElementById("synthKey");
    // keyChangerUp(synthKey);
    // }
    // else if(e.keyCode == 87) {
    //     var synthKey = document.getElementById("synthKey2");
    //     keyChangerUp(synthKey);
    // }
    // else if(e.keyCode == 69) {
    //     var synthKey = document.getElementById("synthKey3");
    //     keyChangerUp(synthKey);
    // }
    // else if(e.keyCode == 82) {
    //     var synthKey = document.getElementById("synthKey4");
    //     keyChangerUp(synthKey);
    // }
    // else if(e.keyCode == 84) {
    //     var synthKey = document.getElementById("synthKey5");
    //     keyChangerUp(synthKey);
    // }
    // else if(e.keyCode == 89) {
    //     var synthKey = document.getElementById("synthKey6");
    //     keyChangerUp(synthKey);
    // }
    // else if(e.keyCode == 85) {
    //     var synthKey = document.getElementById("synthKey7");
    //     keyChangerUp(synthKey);
    // }
    // else if(e.keyCode == 73) {
    //     var synthKey = document.getElementById("synthKey8");
    //     keyChangerUp(synthKey);
    // }
    // else if(e.keyCode == 79) {
    //     var synthKey = document.getElementById("synthKey9");
    //     keyChangerUp(synthKey);
    // }
    // else if(e.keyCode == 80) {
    //     var synthKey = document.getElementById("synthKey10");
    //     keyChangerUp(synthKey);
    // }
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
    oscillator.type = "sawtooth";
    oscillatorDictionary[key] = oscillator;
    oscillatorDictionary[key].start();
}

function OnOscillatorStop(key) {
    oscillatorDictionary[key].stop();
    oscillatorDictionary[key] = null;
}

function GetFrequency(key) {
    switch (key) {
        case 81:
            return 261.63;
        case 87:
            return 293.66;
        case 69:
            return 329.63;
        case 82:
            return 349.23;
        case 84:
            return 392;
        case 89:
            return 440;
        case 85:
            return 493.88;
        case 73:
            return 523.25;
        case 79:
            return 587.33;
        case 80:
            return 659.25;
        
        // default:
        //     throw Error("Only");
    }
}

function keyChangerDown(synthKey) {
    synthKey.style.marginBottom = "5px";
    synthKey.style.transform = "scale(1.1)";
    synthKey.style.transitionDuration = "0.5s";
    synthKey.style.backgroundColor = "darkslateblue";
    synthKey.style.borderColor = "greenyellow";
}

function keyChangerUp(synthKey) {
    synthKey.style.marginBottom = "0px";
    synthKey.style.transform = "scale(1)";
    synthKey.style.transitionDuration = "0.5s";
    synthKey.style.backgroundColor = "black";
    synthKey.style.borderColor = "whitesmoke";
}