



function playBack(playBackArr){
    pitchValue = "mid";
    console.log("playing back");
    console.log(playBackArr);
    var i = 0;
    return playRecur(playBackArr, i);
}



function playRecur(arr, i){
    if(i < arr.length){
        console.log("playing");
        if(arr[i].pressRelease === true){
            setTimeout(() => {
                button1Pressed(arr[i])
            }, arr[i].time);
        }
        if(arr[i].pressRelease === false){
            setTimeout(() => {
                button1Released(arr[i])
            }, arr[i].time);
        }
        return playRecur(arr, i+1);
    }
}